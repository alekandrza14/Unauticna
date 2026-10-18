using System;
using UnityEngine;
using UnityEngine.UI;
using FFS.Libraries.StaticEcs;
using Unauticna.NeedsEcs;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

// One instance per scene. Dedicated ECS world for ONE player's six needs.
// Requires StaticEcs 2.x (World<T>, Types(), Query<All<T>> API) and StaticPack.
[DefaultExecutionOrder(100)]
[DisallowMultipleComponent]
public sealed class StaticEcsNeeds : MonoBehaviour
{
    [Serializable]
    public class NeedSettings
    {
        [Range(0f, 100f)] public float initialValue = 100f;
        [Min(0f)] public float lossPerMinute = 1f;
        public Slider slider;
        public Text valueText;
    }

    public NeedSettings food = new NeedSettings { lossPerMinute = 2f };
    public NeedSettings water = new NeedSettings { lossPerMinute = 3f };
    public NeedSettings energy = new NeedSettings { lossPerMinute = 1f };
    public NeedSettings hygiene = new NeedSettings { lossPerMinute = 1f };
    public NeedSettings social = new NeedSettings { lossPerMinute = 0.5f };
    public NeedSettings comfort = new NeedSettings { lossPerMinute = 0.5f };

    [Header("Sleep (Energy)")]
    public mover playerMover;
    [Min(0.01f)] public float sleepRecoveryPerMinute = 30f;
    [Range(1f, 100f)] public float wakeEnergy = 100f;
    [Min(0f)] public float stationarySpeed = 0.1f;
    [Min(0f)] public float settleTime = 0.5f;
    public Text sleepText;
    public bool IsSleeping { get; private set; }
    private Rigidbody playerBody;
    private Vector3 previousPosition;

    public bool paused;
    private static StaticEcsNeeds owner;
    private bool ready, worldCreated, systemsCreated;

    void Awake()
    {
        if (owner != null && owner != this)
        {
            Debug.LogError("Only one StaticEcsNeeds instance is supported. Disable the duplicate.", this);
            enabled = false;
            return;
        }
        if (playerMover == null) playerMover = GetComponent<mover>();
        if (playerMover == null)
        {
            Debug.LogError("Assign playerMover or put StaticEcsNeeds on the player.", this);
            enabled = false;
            return;
        }
        playerBody = playerMover.GetComponent<Rigidbody>();
        previousPosition = playerMover.transform.position;
        owner = this;
        try
        {
            NeedsWorld.Create();
            worldCreated = true;
            NeedsWorld.Types().Component<NeedValues>().Component<NeedDecay>().Component<SleepState>();
            NeedsWorld.Initialize();
            NeedsSystems.Create();
            systemsCreated = true;
            NeedsSystems.Add(new DecaySystem(), order: 0);
            NeedsSystems.Initialize();

            NeedsWorld.NewEntity<Default>().Set(new NeedValues
            {
                Food = Mathf.Clamp(food.initialValue, 0f, 100f),
                Water = Mathf.Clamp(water.initialValue, 0f, 100f),
                Energy = Mathf.Clamp(energy.initialValue, 0f, 100f),
                Hygiene = Mathf.Clamp(hygiene.initialValue, 0f, 100f),
                Social = Mathf.Clamp(social.initialValue, 0f, 100f),
                Comfort = Mathf.Clamp(comfort.initialValue, 0f, 100f)
            }, new NeedDecay(), new SleepState());
            ready = true;
            ApplyDecaySettings();
            if (VarSave.ExistenceVar("Energy")) LoadNeeds();
            RefreshUI();
        }
        catch (Exception)
        {
            Cleanup();
            enabled = false;
            throw;
        }
    }

    void Update()
    {
        if (!ready) return;
        ApplyDecaySettings(); // Live editing of rates in Inspector.
        if (!paused && !Globalprefs.Pause && Time.deltaTime > 0f)
        {
            SampleSleep();
            NeedsSystems.Update();
            SyncSleep();
        }
        previousPosition = playerMover.transform.position;
        NeedsWorld.Tick();
        RefreshUI();
#if ENABLE_INPUT_SYSTEM
        if (Keyboard.current != null)
        {
            if (Keyboard.current.f1Key.wasPressedThisFrame) SaveNeeds();
            if (Keyboard.current.f2Key.wasPressedThisFrame) LoadNeeds();
        }
#elif ENABLE_LEGACY_INPUT_MANAGER
        if (Input.GetKeyDown(KeyCode.F1)) SaveNeeds();
        if (Input.GetKeyDown(KeyCode.F2)) LoadNeeds();
#endif
    }

    public void SaveNeeds()
    {
        if (!ready) return;
        NeedValues v = GetValues();
        VarSave.SetInt("Food", Mathf.RoundToInt(v.Food));
        VarSave.SetInt("Water", Mathf.RoundToInt(v.Water));
        VarSave.SetInt("Energy", Mathf.RoundToInt(v.Energy));
        VarSave.SetInt("Hygiene", Mathf.RoundToInt(v.Hygiene));
        VarSave.SetInt("Social", Mathf.RoundToInt(v.Social));
        VarSave.SetInt("Comfort", Mathf.RoundToInt(v.Comfort));
    }

    public void LoadNeeds()
    {
        if (!ready) return;
        NeedValues v = GetValues();
        if (VarSave.ExistenceVar("Food")) v.Food = VarSave.GetInt("Food");
        if (VarSave.ExistenceVar("Water")) v.Water = VarSave.GetInt("Water");
        if (VarSave.ExistenceVar("Energy")) v.Energy = VarSave.GetInt("Energy");
        if (VarSave.ExistenceVar("Hygiene")) v.Hygiene = VarSave.GetInt("Hygiene");
        if (VarSave.ExistenceVar("Social")) v.Social = VarSave.GetInt("Social");
        if (VarSave.ExistenceVar("Comfort")) v.Comfort = VarSave.GetInt("Comfort");
        // Saving stores needs only, so rebuild the rest state from loaded energy.
        foreach (var entity in NeedsWorld.Query<All<SleepState>>().Entities())
        {
            ref var sleep = ref entity.Ref<SleepState>();
            sleep = default;
        }
        SetValues(v);
    }

    [ContextMenu("Test / Set Energy to Zero")]
    private void TestExhaustion()
    {
        if (!Application.isPlaying || !ready) return;
        var values = GetValues();
        values.Energy = 0f;
        SetValues(values);
    }

    private void SampleSleep()
    {
        float speed = (playerMover.transform.position - previousPosition).magnitude / Time.deltaTime;
        bool still = speed <= stationarySpeed;
        if (playerBody != null)
            still &= playerBody.linearVelocity.sqrMagnitude <= stationarySpeed * stationarySpeed
                && playerBody.angularVelocity.sqrMagnitude <= 0.04f;

        foreach (var entity in NeedsWorld.Query<All<SleepState>>().Entities())
        {
            ref var state = ref entity.Ref<SleepState>();
            state.Stationary = still;
            state.SettleTime = Mathf.Max(0f, settleTime);
            state.RecoveryPerMinute = Mathf.Max(0.01f, sleepRecoveryPerMinute);
            state.WakeEnergy = Mathf.Clamp(wakeEnergy, 1f, 100f);
        }
    }

    private void SyncSleep()
    {
        foreach (var entity in NeedsWorld.Query<All<SleepState>>().Entities())
        {
            ref readonly var state = ref entity.Read<SleepState>();
            IsSleeping = state.IsSleeping;
            playerMover.SetNeedsRest(state.Exhausted);
        }
        if (sleepText != null) sleepText.text = IsSleeping ? "Мы спим" : "";
    }

    private void OnEnable()
    {
        if (playerMover != null) previousPosition = playerMover.transform.position;
    }

    private void OnDisable()
    {
        if (owner != this) return;
        if (playerMover != null) playerMover.SetNeedsRest(false);
        IsSleeping = false;
        if (sleepText != null) sleepText.text = "";
        if (!ready) return;
        foreach (var entity in NeedsWorld.Query<All<SleepState>>().Entities())
        {
            ref var state = ref entity.Ref<SleepState>();
            state = default;
        }
    }

    private void ApplyDecaySettings()
    {
        foreach (var entity in NeedsWorld.Query<All<NeedDecay>>().Entities())
        {
            ref var rate = ref entity.Ref<NeedDecay>();
            rate.Food = Mathf.Max(0f, food.lossPerMinute);
            rate.Water = Mathf.Max(0f, water.lossPerMinute);
            rate.Energy = Mathf.Max(0f, energy.lossPerMinute);
            rate.Hygiene = Mathf.Max(0f, hygiene.lossPerMinute);
            rate.Social = Mathf.Max(0f, social.lossPerMinute);
            rate.Comfort = Mathf.Max(0f, comfort.lossPerMinute);
        }
    }

    // Returns a copy, suitable for JSON serialization. Use SetValues to restore.
    public NeedValues GetValues()
    {
        RequireReady();
        foreach (var entity in NeedsWorld.Query<All<NeedValues>>().Entities())
            return entity.Read<NeedValues>();
        throw new InvalidOperationException("Needs entity is missing.");
    }

    public void SetValues(NeedValues values)
    {
        RequireReady();
        CheckFinite(values.Food);
        values.Food = Mathf.Clamp(values.Food, 0f, 100f);
        CheckFinite(values.Water);
        values.Water = Mathf.Clamp(values.Water, 0f, 100f);
        CheckFinite(values.Energy);
        values.Energy = Mathf.Clamp(values.Energy, 0f, 100f);
        CheckFinite(values.Hygiene);
        values.Hygiene = Mathf.Clamp(values.Hygiene, 0f, 100f);
        CheckFinite(values.Social);
        values.Social = Mathf.Clamp(values.Social, 0f, 100f);
        CheckFinite(values.Comfort);
        values.Comfort = Mathf.Clamp(values.Comfort, 0f, 100f);
        foreach (var entity in NeedsWorld.Query<All<NeedValues>>().Entities())
        {
            ref var current = ref entity.Ref<NeedValues>();
            current = values;
        }
        foreach (var entity in NeedsWorld.Query<All<SleepState>>().Entities())
        {
            ref var sleep = ref entity.Ref<SleepState>();
            if (values.Energy <= 0f) sleep.Exhausted = true;
            if (values.Energy >= Mathf.Clamp(wakeEnergy, 1f, 100f))
                sleep.Exhausted = false;
            if (!sleep.Exhausted)
            {
                sleep.IsSleeping = false;
                sleep.StillSeconds = 0f;
            }
        }
        SyncSleep();
        RefreshUI();
    }

    public enum Need { Food, Water, Energy, Hygiene, Social, Comfort }

    public void AddNeed(Need need, float amount)
    {
        CheckFinite(amount);
        NeedValues values = GetValues();
        switch (need)
        {
            case Need.Food: values.Food = Mathf.Clamp(values.Food + amount, 0f, 100f); break;
            case Need.Water: values.Water = Mathf.Clamp(values.Water + amount, 0f, 100f); break;
            case Need.Energy: values.Energy = Mathf.Clamp(values.Energy + amount, 0f, 100f); break;
            case Need.Hygiene: values.Hygiene = Mathf.Clamp(values.Hygiene + amount, 0f, 100f); break;
            case Need.Social: values.Social = Mathf.Clamp(values.Social + amount, 0f, 100f); break;
            case Need.Comfort: values.Comfort = Mathf.Clamp(values.Comfort + amount, 0f, 100f); break;
            default: throw new ArgumentOutOfRangeException(nameof(need));
        }
        SetValues(values);
    }

    // These methods can be assigned directly to Button.onClick (float argument).
    public void AddFood(float amount) => AddNeed(Need.Food, amount);
    public void AddWater(float amount) => AddNeed(Need.Water, amount);
    public void AddEnergy(float amount) => AddNeed(Need.Energy, amount);
    public void AddHygiene(float amount) => AddNeed(Need.Hygiene, amount);
    public void AddSocial(float amount) => AddNeed(Need.Social, amount);
    public void AddComfort(float amount) => AddNeed(Need.Comfort, amount);

    public void FillAll()
    {
        SetValues(new NeedValues
        {
            Food = 100f, Water = 100f, Energy = 100f,
            Hygiene = 100f, Social = 100f, Comfort = 100f
        });
    }

    private void RefreshUI()
    {
        NeedValues values = GetValues();
        Show(food, values.Food);
        Show(water, values.Water);
        Show(energy, values.Energy);
        Show(hygiene, values.Hygiene);
        Show(social, values.Social);
        Show(comfort, values.Comfort);
    }

    private static void Show(NeedSettings settings, float value)
    {
        if (settings.slider != null)
        {
            settings.slider.minValue = 0f;
            settings.slider.maxValue = 100f;
            settings.slider.wholeNumbers = false;
            settings.slider.interactable = false;
            settings.slider.SetValueWithoutNotify(value);
        }
        if (settings.valueText != null)
        {
            string label = Mathf.CeilToInt(value).ToString() + " / 100";
            if (settings.valueText.text != label) settings.valueText.text = label;
        }
    }

    private void RequireReady()
    {
        if (!ready) throw new InvalidOperationException("StaticEcsNeeds is not initialized yet.");
    }

    private static void CheckFinite(float value)
    {
        if (float.IsNaN(value) || float.IsInfinity(value))
            throw new ArgumentException("Need values must be finite.");
    }

    void OnDestroy() { Cleanup(); }

    private void Cleanup()
    {
        if (owner == this && playerMover != null) playerMover.SetNeedsRest(false);
        ready = false;
        try
        {
            if (systemsCreated) NeedsSystems.Destroy();
        }
        finally
        {
            systemsCreated = false;
            try { if (worldCreated) NeedsWorld.Destroy(); }
            finally
            {
                worldCreated = false;
                if (owner == this) owner = null;
            }
        }
    }
}

namespace Unauticna.NeedsEcs
{
    public struct NeedsWorldType : IWorldType { }
    public abstract class NeedsWorld : World<NeedsWorldType> { }
    public struct NeedsSystemsType : ISystemsType { }
    public abstract class NeedsSystems : NeedsWorld.Systems<NeedsSystemsType> { }

    [Serializable]
    public struct NeedValues : IComponent
    {
        public float Food, Water, Energy, Hygiene, Social, Comfort;
    }

    public struct NeedDecay : IComponent
    {
        public float Food, Water, Energy, Hygiene, Social, Comfort;
    }

    // Attached to the same ECS entity as the player's needs.
    public struct SleepState : IComponent
    {
        public bool Exhausted, Stationary, IsSleeping;
        public float StillSeconds, SettleTime, RecoveryPerMinute, WakeEnergy;
    }

    public struct DecaySystem : ISystem
    {
        public void Update()
        {
            float minutes = Time.deltaTime / 60f;
            foreach (var entity in NeedsWorld.Query<All<NeedValues, NeedDecay, SleepState>>().Entities())
            {
                ref var value = ref entity.Ref<NeedValues>();
                ref readonly var rate = ref entity.Read<NeedDecay>();
                value.Food = Mathf.Clamp(value.Food - rate.Food * minutes, 0f, 100f);
                value.Water = Mathf.Clamp(value.Water - rate.Water * minutes, 0f, 100f);
                ref var sleep = ref entity.Ref<SleepState>();
                if (!sleep.Exhausted)
                {
                    value.Energy = Mathf.Clamp(value.Energy - rate.Energy * minutes, 0f, 100f);
                    if (value.Energy <= 0f) sleep.Exhausted = true;
                }
                sleep.StillSeconds = sleep.Exhausted && sleep.Stationary
                    ? sleep.StillSeconds + Time.deltaTime : 0f;
                sleep.IsSleeping = sleep.Exhausted && sleep.Stationary
                    && sleep.StillSeconds >= sleep.SettleTime;
                if (sleep.IsSleeping)
                    value.Energy = Mathf.Clamp(value.Energy + sleep.RecoveryPerMinute * minutes, 0f, 100f);
                if (sleep.Exhausted && value.Energy >= sleep.WakeEnergy)
                {
                    sleep.Exhausted = false;
                    sleep.IsSleeping = false;
                    sleep.StillSeconds = 0f;
                }
                value.Hygiene = Mathf.Clamp(value.Hygiene - rate.Hygiene * minutes, 0f, 100f);
                value.Social = Mathf.Clamp(value.Social - rate.Social * minutes, 0f, 100f);
                value.Comfort = Mathf.Clamp(value.Comfort - rate.Comfort * minutes, 0f, 100f);
            }
        }
    }
}
