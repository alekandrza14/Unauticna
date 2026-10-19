using System;
using System.Collections.Generic;
using UnityEngine;
using FFS.Libraries.StaticEcs;
using Unauticna.Mechanics;

namespace Unauticna.Mechanics
{
    public struct MechanicWorldType : IWorldType { }
    public abstract class MechanicWorld : World<MechanicWorldType> { }
    public struct MechanicSystemsType : ISystemsType { }
    public abstract class MechanicSystems : MechanicWorld.Systems<MechanicSystemsType> { }
    public struct MechanicSwitch : IComponent { public MechanicId Id; public MechanicMode Mode; public bool Active; }
    public struct MechanicResolveSystem : ISystem
    {
        public void Update()
        {
            foreach (var entity in MechanicWorld.Query<All<MechanicSwitch>>().Entities())
            {
                ref var state = ref entity.Ref<MechanicSwitch>();
                state.Mode = PlayerMechanics.Modes[(int)state.Id];
                state.Active = MechanicPolicy.Evaluate(state.Id, PlayerMechanics.Modes,
                    PlayerMechanics.RendererPresent, PlayerMechanics.HdrpPresent, PlayerMechanics.RemotePresent);
                PlayerMechanics.Hot[(int)state.Id] = state.Active;
            }
        }
    }
}

[DefaultExecutionOrder(-32000)]
public sealed class PlayerMechanics : MonoBehaviour
{
    const string SaveKey = "Unauticna.Mechanics.v1";
    internal static MechanicMode[] Modes = Defaults();
    internal static bool[] Hot = new bool[(int)MechanicId.Count];
    internal static bool RendererPresent, HdrpPresent, RemotePresent;
    public static int RendererRevision { get; private set; }
    public static event Action Changed;
    public static PlayerMechanics Instance { get; private set; }
    public static bool CapturesInput => Instance != null && (Instance.showMenu || Instance.showConsole);
    public static bool Paused => Globalprefs.Pause || Time.timeScale <= 0f;
    public static bool GameplayBlocked => Paused || CapturesInput;
    public static bool Active(MechanicId id) => Hot[(int)id];
    public static MechanicMode Mode(MechanicId id) => Modes[(int)id];

    [Serializable] class Entry { public string id; public int mode; }
    [Serializable] class Settings { public List<Entry> entries = new List<Entry>(); }
    sealed class Binding { public Behaviour target; public MechanicId id; public bool initiallyEnabled; }
    readonly List<Binding> bindings = new List<Binding>();
    bool worldCreated, systemsCreated, showMenu, showConsole, ownsPause;
    Rect window = new Rect(25, 50, 510, 570);
    Vector2 menuScroll, consoleScroll;
    static readonly string[] ModeLabels = { "Off", "On", "Auto" };
    GUIStyle wrappedLabel;
    string command = "", result = "mechanic list | mechanic <id> on/off/auto | mechanic defaults";
    CursorLockMode oldLock;
    bool oldVisible, cursorOwned;
    int suppressFrame = -1;
    public static bool SuppressGameplayFrame => CapturesInput || (Instance != null && Instance.suppressFrame == Time.frameCount);

    static MechanicMode[] Defaults()
    {
        var values = new MechanicMode[(int)MechanicId.Count];
        for (int i = 0; i < values.Length; i++) values[i] = MechanicPolicy.Default((MechanicId)i);
        return values;
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetStatics()
    {
        Instance = null; Modes = Defaults(); Hot = new bool[(int)MechanicId.Count];
        RendererPresent = HdrpPresent = RemotePresent = false; RendererRevision = 0; Changed = null;
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Bootstrap() { if (Instance == null) new GameObject("Player mechanics").AddComponent<PlayerMechanics>(); }
    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this; DontDestroyOnLoad(gameObject);
        try
        {
            string json = PlayerPrefs.GetString(SaveKey, "");
            if (!string.IsNullOrEmpty(json))
            {
                var data = JsonUtility.FromJson<Settings>(json);
                if (data != null && data.entries != null) foreach (var item in data.entries)
                    if (item != null && MechanicPolicy.TryId(item.id, out var id) && item.mode >= 0 && item.mode <= 2)
                        Modes[(int)id] = (MechanicMode)item.mode;
            }
        }
        catch (Exception ex) { Debug.LogWarning("Настройки механик: " + ex.Message); }
        MechanicWorld.Create(); worldCreated = true;
        MechanicWorld.Types().Component<MechanicSwitch>(); MechanicWorld.Initialize();
        for (int i = 0; i < (int)MechanicId.Count; i++) MechanicWorld.NewEntity<Default>().Set(new MechanicSwitch { Id = (MechanicId)i });
        MechanicSystems.Create(); systemsCreated = true;
        MechanicSystems.Add(new MechanicResolveSystem(), order: 0); MechanicSystems.Initialize();
        Resolve(); gameObject.AddComponent<RendererWindowProbe>();
    }
    // Registered once. A disabled component stays registered so it can be re-enabled without scene scans.
    public static void Register(Behaviour component, MechanicId id)
    {
        if (!Application.isPlaying || component == null || Instance == null) return;
        foreach (var b in Instance.bindings) if (b.target == component) return;
        var binding = new Binding { target = component, id = id, initiallyEnabled = component.enabled };
        Instance.bindings.Add(binding);
        component.enabled = binding.initiallyEnabled && Active(id);
    }
    public static void Unregister(Behaviour component)
    {
        if (Instance != null) Instance.bindings.RemoveAll(b => b.target == null || b.target == component);
    }
    public static void SetMode(MechanicId id, MechanicMode mode)
    {
        if ((int)id < 0 || id >= MechanicId.Count || !Enum.IsDefined(typeof(MechanicMode), mode)) return;
        Modes[(int)id] = mode;
        if (Instance != null) { Instance.SaveSettings(); Instance.Resolve(); }
    }
    public static void SetRemotePresent(bool value)
    {
        if (RemotePresent == value) return;
        RemotePresent = value; if (Instance != null) Instance.Resolve();
    }
    public static void SetRendererPresent(bool any, bool hdrp, bool restarted)
    {
        if (!restarted && any == RendererPresent && hdrp == HdrpPresent) return;
        RendererPresent = any; HdrpPresent = hdrp; RendererRevision++;
        if (Instance != null) Instance.Resolve();
    }
    void Resolve()
    {
        // ECS scheduling is event-driven; no systems/query traversal on every player frame.
        if (!systemsCreated) return;
        MechanicSystems.Update(); MechanicWorld.Tick();
        for (int i = bindings.Count - 1; i >= 0; i--)
        {
            var b = bindings[i]; if (b.target == null) { bindings.RemoveAt(i); continue; }
            bool enable = b.initiallyEnabled && Active(b.id);
            if (b.target.enabled != enable) b.target.enabled = enable;
        }
        Changed?.Invoke();
    }
    void SaveSettings()
    {
        var data = new Settings();
        for (int i = 0; i < Modes.Length; i++) data.entries.Add(new Entry { id = MechanicPolicy.Names[i], mode = (int)Modes[i] });
        PlayerPrefs.SetString(SaveKey, JsonUtility.ToJson(data)); PlayerPrefs.Save();
    }
    public static string Execute(string text)
    {
        var words = (text ?? "").Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        if (words.Length == 0 || !string.Equals(words[0], "mechanic", StringComparison.OrdinalIgnoreCase))
            return "Команды: mechanic list; mechanic <id> on/off/auto; mechanic defaults";
        if (words.Length == 2 && words[1].Equals("list", StringComparison.OrdinalIgnoreCase))
        {
            var lines = new List<string>();
            for (int i = 0; i < Modes.Length; i++) lines.Add(MechanicPolicy.Names[i] + " = " + Modes[i] + " / " + (Hot[i] ? "работает" : "спит"));
            return string.Join("\n", lines);
        }
        if (words.Length == 2 && words[1].Equals("defaults", StringComparison.OrdinalIgnoreCase))
        {
            Modes = Defaults(); if (Instance != null) { Instance.SaveSettings(); Instance.Resolve(); }
            return "Настройки по умолчанию сохранены.";
        }
        if (words.Length >= 3 && words[1].Equals("windows", StringComparison.OrdinalIgnoreCase))
            return RendererWindowProbe.Configure(string.Join(" ", words, 2, words.Length - 2));
        if (words.Length == 3 && MechanicPolicy.TryId(words[1], out var id)
            && Enum.TryParse(words[2], true, out MechanicMode mode) && Enum.IsDefined(typeof(MechanicMode), mode))
        { SetMode(id, mode); return words[1] + " = " + mode + (Active(id) ? " — работает" : " — выключено или ожидает зависимость"); }
        return "Неизвестная команда. mechanic list — список механик.";
    }
    void Update()
    {
        // Project already uses legacy Input. Configure Active Input Handling = Both.
        if (Input.GetKeyDown(KeyCode.F10))
        {
            showConsole = !showConsole; suppressFrame = Time.frameCount;
            if (showConsole && !Paused) { Global.PauseManager.Pause(); ownsPause = true; }
        }
        if (Paused && Input.GetMouseButtonDown(1))
        { showMenu = !showMenu; if (showMenu) { window.x = Input.mousePosition.x; window.y = Screen.height - Input.mousePosition.y; } suppressFrame = Time.frameCount; }
        if (!Paused) showMenu = false;
        if (CapturesInput && Input.GetKeyDown(KeyCode.Escape))
        { showMenu = showConsole = false; suppressFrame = Time.frameCount; }
        if (CapturesInput) KeepMenuCursor();
        else ReleaseCursor();
    }
    void LateUpdate() { if (CapturesInput) KeepMenuCursor(); }
    void KeepMenuCursor()
    {
        if (!cursorOwned) { oldLock = Cursor.lockState; oldVisible = Cursor.visible; cursorOwned = true; }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void ReleaseCursor()
    {
        if (!CapturesInput && ownsPause) { ownsPause = false; Global.PauseManager.Play(); }
        if (!cursorOwned) return;
        Cursor.lockState = oldLock; Cursor.visible = oldVisible; cursorOwned = false;
    }
    void OnGUI()
    {
        if (!CapturesInput) return;
        KeepMenuCursor();
        int previousDepth = GUI.depth;
        bool previousEnabled = GUI.enabled;
        Matrix4x4 previousMatrix = GUI.matrix;
        Color previousColor = GUI.color, previousContent = GUI.contentColor, previousBackground = GUI.backgroundColor;
        try
        {
            // Other pause/debug GUI must not leave this menu disabled or scaled.
            GUI.depth = -10000; GUI.enabled = true; GUI.matrix = Matrix4x4.identity;
            GUI.color = GUI.contentColor = GUI.backgroundColor = Color.white;
            if (wrappedLabel == null) wrappedLabel = new GUIStyle(GUI.skin.label) { wordWrap = true };
            window = FitWindow(window, Screen.width, Screen.height);
            // Fixed layout: content cannot expand the window instead of scrolling.
            window = GUI.Window(GetInstanceID(), window, DrawWindow, "Механики игрока — настройки сохраняются");
        }
        finally
        {
            GUI.depth = previousDepth; GUI.enabled = previousEnabled; GUI.matrix = previousMatrix;
            GUI.color = previousColor; GUI.contentColor = previousContent; GUI.backgroundColor = previousBackground;
        }
    }
    static Rect FitWindow(Rect value, float screenWidth, float screenHeight)
    {
        value.width = Mathf.Max(1f, Mathf.Min(550f, screenWidth - 16f));
        value.height = Mathf.Max(1f, Mathf.Min(650f, screenHeight - 16f));
        value.x = Mathf.Clamp(value.x, 0f, Mathf.Max(0f, screenWidth - value.width));
        value.y = Mathf.Clamp(value.y, 0f, Mathf.Max(0f, screenHeight - value.height));
        return value;
    }
    void DrawWindow(int id)
    {
        GUI.Label(new Rect(12, 26, window.width - 24, 34),
            "База: движение, здоровье, физика и ручные сохранения — всегда.", wrappedLabel);
        Rect body = new Rect(12, 64, Mathf.Max(1f, window.width - 24), Mathf.Max(1f, window.height - 108));
        if (showMenu && showConsole)
        {
            float menuHeight = body.height * 0.56f;
            DrawMechanics(new Rect(body.x, body.y, body.width, menuHeight));
            DrawConsole(new Rect(body.x, body.y + menuHeight + 8, body.width, Mathf.Max(1f, body.height - menuHeight - 8)));
        }
        else if (showMenu) DrawMechanics(body);
        else if (showConsole) DrawConsole(body);
        if (GUI.Button(new Rect(12, window.height - 36, window.width - 24, 28), "Закрыть"))
        { showMenu = showConsole = false; suppressFrame = Time.frameCount; ReleaseCursor(); }
        // Only the title bar moves the window. Scrollbar/rows retain their mouse capture.
        GUI.DragWindow(new Rect(0, 0, window.width, 22));
    }
    void DrawMechanics(Rect viewport)
    {
        const float rowHeight = 34f;
        float contentWidth = Mathf.Max(420f, viewport.width - 22f);
        float labelWidth = contentWidth - 235f;
        Rect content = new Rect(0, 0, contentWidth, Modes.Length * rowHeight + 4f);
        menuScroll = GUI.BeginScrollView(viewport, menuScroll, content, false, true);
        try
        {
            for (int i = 0; i < Modes.Length; i++)
            {
                float y = i * rowHeight;
                GUI.Label(new Rect(0, y, labelWidth, rowHeight), MechanicPolicy.Titles[i], wrappedLabel);
                int selected = GUI.Toolbar(new Rect(labelWidth + 5, y + 3, 155, 28), (int)Modes[i], ModeLabels);
                if (selected != (int)Modes[i]) SetMode((MechanicId)i, (MechanicMode)selected);
                GUI.Label(new Rect(labelWidth + 165, y + 6, 70, 24), Hot[i] ? "работает" : "спит");
            }
        }
        finally { GUI.EndScrollView(); }
    }
    void DrawConsole(Rect area)
    {
        GUI.Label(new Rect(area.x, area.y, area.width, 22), "Консоль F10 — mechanic list");
        GUI.SetNextControlName("MechanicCommand");
        command = GUI.TextField(new Rect(area.x, area.y + 24, Mathf.Max(1f, area.width - 112), 28), command);
        bool enter = Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return
            && GUI.GetNameOfFocusedControl() == "MechanicCommand";
        if (GUI.Button(new Rect(area.x + area.width - 104, area.y + 24, 104, 28), "Выполнить") || enter)
        { result = Execute(command); if (enter) Event.current.Use(); }
        Rect viewport = new Rect(area.x, area.y + 60, area.width, Mathf.Max(1f, area.height - 60));
        float width = Mathf.Max(1f, viewport.width - 22);
        float height = Mathf.Max(viewport.height, wrappedLabel.CalcHeight(new GUIContent(result), width) + 8);
        consoleScroll = GUI.BeginScrollView(viewport, consoleScroll, new Rect(0, 0, width, height), false, true);
        try { GUI.Label(new Rect(0, 0, width, height), result, wrappedLabel); }
        finally { GUI.EndScrollView(); }
    }
    void OnDestroy()
    {
        if (Instance != this) return;
        showMenu = showConsole = false;
        ReleaseCursor(); Changed = null;
        try { if (systemsCreated) MechanicSystems.Destroy(); }
        finally { if (worldCreated) MechanicWorld.Destroy(); Instance = null; }
    }
}
