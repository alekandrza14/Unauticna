using UnityEngine;
using FFS.Libraries.StaticEcs;

// StaticEcs 2.x. Attach to each model. One shared ECS world for all mobs.
[DisallowMultipleComponent]
public sealed class MobNeedsCode : MonoBehaviour
{
    public Transform player;
    public bool followPlayer;
    [Min(0f)] public float speed = 2f, stopDistance = 1.5f;
    [Min(0f)] public float lossPerMinute = 1f;
    public float labelHeight = 2f;

    [Header("Automatic eating")]
    public bool autoEat = true;
    [Range(0f, 100f)] public float hungryBelow = 20f;
    [Range(0f, 1000f)] public float foodSearchRadius = 10f;
    internal int FoodSlot = -1;
    internal uint FoodEpoch;
    internal bool WantsFood => registered && isActiveAndEnabled && autoEat
        && GetNeeds().food < Mathf.Clamp(hungryBelow, 0f, 100f);

    [Tooltip("Starting values. Current values are stored in ECS; use SetNeeds to change them.")]
    public Needs values = new Needs
        { food = 100, sleep = 100, water = 100, hygiene = 100, social = 100, comfort = 100 };

    // Custom radix-64: a-z=0..25, 0-9=48..57. Preserves the "0u" example.
    public const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUV0123456789WXYZ+/";
    private MobWorld.Entity entity;
    private bool registered;
    private int lastCode = -1;
    private string code = "";
    private GUIStyle style;
    private static int updatedFrame = -1;

    public struct WorldType : IWorldType { }
    public abstract class MobWorld : World<WorldType> { }
    public struct SystemsType : ISystemsType { }
    public abstract class MobSystems : MobWorld.Systems<SystemsType> { }
    public struct View : IComponent { public MobNeedsCode mob; }
    [System.Serializable]
    public struct Needs : IComponent
    {
        [Range(0, 100)] public float food, sleep, water, hygiene, social, comfort;
    }

    void OnEnable()
    {
        if (!MobWorld.IsWorldInitialized)
        {
            MobWorld.Create();
            MobWorld.Types().Component<Needs>().Component<View>();
            MobWorld.Initialize();
            MobSystems.Create();
            MobSystems.Add(new MobSystem(), order: 0);
            MobSystems.Initialize();
            updatedFrame = -1;
        }
        entity = MobWorld.NewEntity<Default>().Set(values, new View { mob = this });
        registered = true;
        lastCode = -1;
        FoodEpoch++;
        MobFoodSearch.Register(this);
    }

    void Update()
    {
        if (!registered || updatedFrame == Time.frameCount) return;
        updatedFrame = Time.frameCount; // Update ALL mobs once, regardless of their count.
        if (!Globalprefs.Pause && Time.deltaTime > 0f)
        {
            MobSystems.Update();
            // Apply eating only after the ECS query has finished.
            MobFoodSearch.Tick();
        }
        MobWorld.Tick();
    }

    void OnDisable()
    {
        if (!registered) return;
        FoodEpoch++;
        MobFoodSearch.Unregister(this);
        registered = false;
        if (!MobWorld.IsWorldInitialized) return;
        values = entity.Read<Needs>(); // Preserve needs when disabled or pooled.
        entity.Destroy();
        if (MobWorld.CalculateEntitiesCount() == 0)
        {
            MobSystems.Destroy();
            MobWorld.Destroy();
        }
    }

    public void SetNeeds(float food, float sleep, float water, float hygiene, float social, float comfort)
    {
        values = new Needs { food = Clean(food), sleep = Clean(sleep), water = Clean(water),
            hygiene = Clean(hygiene), social = Clean(social), comfort = Clean(comfort) };
        if (registered)
        {
            ref var current = ref entity.Ref<Needs>();
            current = values;
        }
    }

    public Needs GetNeeds() => registered ? entity.Read<Needs>() : values;

    static float Clean(float n) => float.IsNaN(n) ? 0f : Mathf.Clamp(n, 0f, 100f);
    static int Level(float n) => Mathf.Min(3, Mathf.FloorToInt(Clean(n) / 25f));

    void OnGUI()
    {
        if (!registered || Event.current.type != EventType.Repaint) return;
        Camera cam = Globalprefs.camera;
        if (cam == null) return;
        Vector3 t = cam.WorldToViewportPoint(transform.position + Vector3.up * labelHeight);
        if (t.z <= 0 || t.x < 0 || t.x > 1 || t.y < 0 || t.y > 1) return;
        Vector3 u = cam.ViewportToScreenPoint(t);
        var n = entity.Read<Needs>();
        int packed = (Level(n.food) << 10) | (Level(n.sleep) << 8) | (Level(n.water) << 6)
            | (Level(n.hygiene) << 4) | (Level(n.social) << 2) | Level(n.comfort);
        if (lastCode != packed)
        {
            code = new string(new[] { Alphabet[packed >> 6], Alphabet[packed & 63] });
            lastCode = packed;
        }
        if (style == null)
        {
            style = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter,
                fontSize = 22, fontStyle = FontStyle.Bold };
            style.normal.textColor = Color.white;
        }
        GUI.Label(new Rect(u.x - 35, Screen.height - u.y - 16, 70, 32), code, style);
    }

    public struct MobSystem : ISystem
    {
        public void Update()
        {
            float dt = Time.deltaTime;
            if (dt <= 0f) return;
            foreach (var e in MobWorld.Query<All<Needs, View>>().Entities())
            {
                var m = e.Read<View>().mob;
                if (m == null || !m.isActiveAndEnabled) continue;
                ref var n = ref e.Ref<Needs>();
                float loss = Mathf.Max(0f, m.lossPerMinute) * dt / 60f;
                n.food = Clean(n.food - loss); n.sleep = Clean(n.sleep - loss);
                n.water = Clean(n.water - loss); n.hygiene = Clean(n.hygiene - loss);
                n.social = Clean(n.social - loss); n.comfort = Clean(n.comfort - loss);
                if (!m.followPlayer) continue;
                Transform target = m.player;
                if (target == null && Globalprefs.camera != null) target = Globalprefs.camera.transform;
                if (target == null) continue;
                Vector3 delta = target.position - m.transform.position;
                delta.y = 0; // Simple model movement on XZ, without physics/pathfinding.
                float distance = delta.magnitude;
                float step = Mathf.Min(Mathf.Max(0f, m.speed) * dt,
                    Mathf.Max(0f, distance - Mathf.Max(0f, m.stopDistance)));
                if (step <= 0f || distance < 0.001f) continue;
                m.transform.position += delta / distance * step;
                m.transform.rotation = Quaternion.LookRotation(delta);
            }
        }
    }
}
