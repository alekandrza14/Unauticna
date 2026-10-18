using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Compatibility with living Item/CO scripts and existing map/inventory saves.
// Automatically installed at runtime; no component needs to be added manually.
public sealed class MobNeedsBridge : MonoBehaviour
{
    private const string SocialPrefix = "mobneeds:v1:";
    private static MobNeedsBridge instance;
    private float nextScan;
    private readonly HashSet<GameObject> scanned = new HashSet<GameObject>();
    private static readonly HashSet<string> Markers = new HashSet<string>
        { "Мясо", "SocialSystem", "CharacterName", "Realtime", "CppRealtime", "RunToPlayer", "SocialObject", "Slave", "CharacterStats", "telo" };
    private static readonly Dictionary<Type, bool> markerTypes = new Dictionary<Type, bool>();

    [Serializable]
    public sealed class Snapshot
    {
        public int version;
        public MobNeedsCode.Needs needs;
        public float lossPerMinute;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void Install()
    {
        if (instance != null) return;
        instance = FindFirstObjectByType<MobNeedsBridge>();
        if (instance == null) instance = new GameObject("Mob needs registration").AddComponent<MobNeedsBridge>();
        DontDestroyOnLoad(instance.gameObject);
    }

    private void Update()
    {
        if (Time.unscaledTime < nextScan) return;
        nextScan = Time.unscaledTime + 1f;
        scanned.Clear();
        foreach (var script in FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
        {
            if (script == null || !(script is itemName || script is CustomObject || IsMarker(script.GetType()))) continue;
            GameObject owner = Owner(script.gameObject);
            if (owner != null && scanned.Add(owner)) Ensure(owner);
        }
    }

    private static bool IsMarker(Type type)
    {
        if (markerTypes.TryGetValue(type, out bool known)) return known;
        for (Type t = type; t != null && t != typeof(MonoBehaviour); t = t.BaseType)
            if (Markers.Contains(t.Name)) return markerTypes[type] = true;
        return markerTypes[type] = false;
    }

    private static GameObject Owner(GameObject go)
    {
        if (go == null) return null;
        var co = go.GetComponentInParent<CustomObject>();
        if (co != null) return co.gameObject;
        var item = go.GetComponentInParent<itemName>();
        return item != null ? item.gameObject : go;
    }

    private static bool IsSceneMob(GameObject go)
    {
        return go != null && go.scene.IsValid() && go.scene.isLoaded
            && go.GetComponentInParent<mover>() == null
            && go.GetComponentInParent<StaticEcsNeeds>() == null;
    }

    public static MobNeedsCode Ensure(GameObject go)
    {
        go = Owner(go);
        if (!IsSceneMob(go)) return null;
        var existing = go.GetComponent<MobNeedsCode>();
        if (existing != null) return existing;
        foreach (var script in go.GetComponentsInChildren<MonoBehaviour>(true))
        {
            if (script == null || Owner(script.gameObject) != go) continue;
            bool living = IsMarker(script.GetType());
            if (script is itemName item)
                living |= item.isLife || item.itemtype == 2;
            if (script is CustomObject co && co.Model != null)
            {
                var model = co.Model;
                living |= model.Meat || model.social || model.RunToPlayer || model.Timer2 != 0f
                    || !string.IsNullOrEmpty(model.Realtime) || !string.IsNullOrEmpty(model.ExeRealtime);
            }
            if (living) return go.AddComponent<MobNeedsCode>(); // followPlayer defaults to false.
        }
        return null;
    }

    public static string Capture(GameObject go)
    {
        var mob = Ensure(go);
        return mob == null ? "" : JsonUtility.ToJson(new Snapshot
            { version = 1, needs = mob.GetNeeds(), lossPerMinute = mob.lossPerMinute });
    }

    public static void Restore(GameObject go, List<string> data, int index)
    {
        Restore(go, data != null && index >= 0 && index < data.Count ? data[index] : null);
    }

    public static void Restore(GameObject go, string json)
    {
        go = Owner(go);
        if (!IsSceneMob(go)) return;
        if (string.IsNullOrEmpty(json)) { Ensure(go); return; } // Old map or inventory entry.
        try
        {
            var data = JsonUtility.FromJson<Snapshot>(json);
            if (data == null || data.version != 1) throw new FormatException("Unknown needs format");
            var mob = go.GetComponent<MobNeedsCode>();
            if (mob == null) mob = go.AddComponent<MobNeedsCode>();
            var n = data.needs;
            mob.SetNeeds(n.food, n.sleep, n.water, n.hygiene, n.social, n.comfort);
            mob.lossPerMinute = float.IsNaN(data.lossPerMinute) || float.IsInfinity(data.lossPerMinute)
                ? 1f : Mathf.Max(0f, data.lossPerMinute);
        }
        catch (Exception ex) { Debug.LogWarning("Mob needs could not be loaded: " + ex.Message, go); }
    }

    public static string AppendSocial(GameObject go, string social)
    {
        string json = Capture(go);
        if (string.IsNullOrEmpty(json)) return social ?? "";
        var parts = new List<string>((social ?? "").Split('♥'));
        while (parts.Count < 6) parts.Add(""); // Preserve the six existing social/mod fields.
        for (int i = parts.Count - 1; i >= 6; i--)
            if (parts[i].StartsWith(SocialPrefix, StringComparison.Ordinal)) parts.RemoveAt(i);
        parts.Add(SocialPrefix + Convert.ToBase64String(Encoding.UTF8.GetBytes(json)));
        return string.Join("♥", parts);
    }

    public static void RestoreSocial(GameObject go, string[] parts)
    {
        if (parts != null)
            for (int i = 6; i < parts.Length; i++)
            {
                if (!parts[i].StartsWith(SocialPrefix, StringComparison.Ordinal)) continue;
                try
                {
                    Restore(go, Encoding.UTF8.GetString(Convert.FromBase64String(parts[i].Substring(SocialPrefix.Length))));
                }
                catch (FormatException ex) { Debug.LogWarning("Invalid mob needs payload: " + ex.Message, go); }
                return;
            }
        Ensure(go);
    }
}
