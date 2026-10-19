using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Unauticna.Mechanics;

public sealed class RendererWindowProbe : MonoBehaviour
{
    const string NamesKey = "Unauticna.Mechanics.RendererTitles.v1";
    static RendererWindowProbe instance;
    [Tooltip("Words in the external Unity player window title; case-insensitive.")]
    public string[] titleWords = { "URP", "HDRP", "LRP" };
    [Min(0.25f)] public float interval = 1f;
    struct Result { public bool any, hdrp; public long fingerprint; }
    Task<Result> pending;
    long fingerprint;
    float next;
    uint ownProcess;
    int version, inFlightVersion;
    void Awake()
    {
        instance = this;
        titleWords = PlayerPrefs.GetString(NamesKey, "URP,HDRP,LRP").Split(',');
        using (var process = System.Diagnostics.Process.GetCurrentProcess()) ownProcess = (uint)process.Id;
    }
    public static string Configure(string names)
    {
        var words = names.Split(',');
        for (int i = 0; i < words.Length; i++)
        { words[i] = words[i].Trim(); if (words[i].Length < 2) return "Имя окна должно содержать хотя бы 2 символа."; }
        PlayerPrefs.SetString(NamesKey, string.Join(",", words)); PlayerPrefs.Save();
        if (instance != null) { instance.titleWords = words; instance.version++; instance.next = 0; }
        return "Заголовки окон сохранены: " + string.Join(", ", words);
    }
    void Update()
    {
        bool wanted = PlayerMechanics.Mode(MechanicId.Sync) != MechanicMode.Off;
        if (pending != null && pending.IsCompleted)
        {
            if (pending.Status == TaskStatus.RanToCompletion && wanted && version == inFlightVersion)
            {
                Result r = pending.Result;
                PlayerMechanics.SetRendererPresent(r.any, r.hdrp, fingerprint != r.fingerprint);
                fingerprint = r.fingerprint;
            }
            else if (pending.IsFaulted) { var ignored = pending.Exception; PlayerMechanics.SetRendererPresent(false, false, false); }
            pending = null;
        }
        if (!wanted) { PlayerMechanics.SetRendererPresent(false, false, false); return; }
        if (pending != null || Time.unscaledTime < next) return;
        next = Time.unscaledTime + Mathf.Max(0.25f, interval);
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        string[] words = (string[])titleWords.Clone(); uint pid = ownProcess;
        inFlightVersion = version;
        pending = Task.Run(() => Scan(words, pid));
#endif
    }
    void OnDestroy() { if (instance == this) instance = null; }
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
    delegate bool EnumProc(IntPtr hWnd, IntPtr value);
    [DllImport("user32.dll")] static extern bool EnumWindows(EnumProc callback, IntPtr value);
    [DllImport("user32.dll")] static extern bool IsWindowVisible(IntPtr hWnd);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)] static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int length);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)] static extern int GetClassName(IntPtr hWnd, StringBuilder text, int length);
    [DllImport("user32.dll")] static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
    static bool HasWord(string title, string word)
    {
        if (string.IsNullOrWhiteSpace(word)) return false;
        int at = 0;
        while ((at = title.IndexOf(word, at, StringComparison.OrdinalIgnoreCase)) >= 0)
        {
            int end = at + word.Length;
            if ((at == 0 || !char.IsLetterOrDigit(title[at - 1])) && (end == title.Length || !char.IsLetterOrDigit(title[end]))) return true;
            at++;
        }
        return false;
    }
    static Result Scan(string[] words, uint ownPid)
    {
        Result result = default;
        var text = new StringBuilder(1024); var cls = new StringBuilder(128);
        EnumWindows((window, unused) =>
        {
            if (!IsWindowVisible(window)) return true;
            GetWindowThreadProcessId(window, out uint pid); if (pid == ownPid) return true;
            GetClassName(window, cls, cls.Capacity);
            // Avoid matching a browser tab or an editor document named HDRP.
            if (!cls.ToString().Equals("UnityWndClass", StringComparison.Ordinal)) return true;
            GetWindowText(window, text, text.Capacity); string title = text.ToString();
            foreach (string word in words) if (HasWord(title, word))
            { result.any = true; result.hdrp |= HasWord(title, "HDRP"); result.fingerprint ^= window.ToInt64() ^ ((long)pid << 32); break; }
            return true;
        }, IntPtr.Zero);
        return result;
    }
#endif
}
