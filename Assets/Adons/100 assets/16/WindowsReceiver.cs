using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using NativeWebSocket;
using Unauticna.Mechanics;

public struct RemoteGamepadInput
{
    public float stickX, stickY;
    public bool A, B, X, Y;
    public bool ADown, BDown, XDown, YDown;
}

[DefaultExecutionOrder(-1000)]
public class WindowsReceiver : MonoBehaviour
{
    public string serverUrl = "wss://quifipugora.beget.app";
    public float stickX, stickY;
    public bool A, B, X, Y;
    [Min(0.5f)] public float inputTimeout = 2f;
    public bool HasInput { get; private set; }
    static WindowsReceiver instance;
    WebSocket socket;
    readonly Queue<string> messages = new Queue<string>();
    readonly object gate = new object();
    bool overflow;
    volatile bool opened, closed;
    string networkError;
    float retryAt, lastInput;
    int downs;
    [Serializable] class Envelope { public string type; }

    public static RemoteGamepadInput GetInput()
    {
        if (instance == null || !instance.isActiveAndEnabled || !instance.HasInput
            || PlayerMechanics.GameplayBlocked || !PlayerMechanics.Active(MechanicId.RemoteInput)) return default;
        return new RemoteGamepadInput { stickX = instance.stickX, stickY = instance.stickY,
            A = instance.A, B = instance.B, X = instance.X, Y = instance.Y,
            ADown = (instance.downs & 1) != 0, BDown = (instance.downs & 2) != 0,
            XDown = (instance.downs & 4) != 0, YDown = (instance.downs & 8) != 0 };
    }
    void OnEnable()
    {
        if (instance != null && instance != this) { enabled = false; return; }
        instance = this; PlayerMechanics.Changed += PolicyChanged; retryAt = 0;
    }
    void PolicyChanged() { if (PlayerMechanics.Mode(MechanicId.RemoteInput) == MechanicMode.Off) { ClearInput(); CloseSocket(); } }
    async Task Connect()
    {
        var current = new WebSocket(serverUrl); socket = current;
        current.OnOpen += () => { if (socket == current) opened = true; };
        current.OnClose += code => { if (socket == current) closed = true; };
        current.OnError += message => { if (socket == current) networkError = message; };
        current.OnMessage += bytes =>
        {
            if (socket != current || bytes.Length > 4096) return;
            lock (gate) { if (messages.Count >= 256) overflow = true; else messages.Enqueue(Encoding.UTF8.GetString(bytes)); }
        };
        try { await current.Connect(); }
        catch (Exception ex) { if (socket == current) { networkError = ex.Message; closed = true; } }
    }
    async void SendJoin(WebSocket current, string room)
    {
        try { await current.SendText(JsonUtility.ToJson(new JoinMessage { room = room })); }
        catch (Exception ex) { if (socket == current) { networkError = ex.Message; closed = true; } }
    }
    void Update()
    {
        downs = 0;
        if (PlayerMechanics.Mode(MechanicId.RemoteInput) == MechanicMode.Off) return;
        if (socket == null && Time.unscaledTime >= retryAt) { retryAt = Time.unscaledTime + 3f; _ = Connect(); }
#if !UNITY_WEBGL || UNITY_EDITOR
        socket?.DispatchMessageQueue();
#endif
        if (opened)
        {
            opened = false;
            if (socket != null) SendJoin(socket, GeneratorXboxCobe.GenCode().ToString());
        }
        if (closed) { closed = false; ClearInput(); CloseSocket(); retryAt = Time.unscaledTime + 3f; }
        if (networkError != null) { string error = networkError; networkError = null; Debug.LogWarning("Gamepad: " + error, this); }
        bool overloaded;
        lock (gate) { overloaded = overflow; overflow = false; if (overloaded) messages.Clear(); }
        if (overloaded) ClearInput();
        // Bounded work; preserve every accepted button/release packet in arrival order.
        for (int i = 0; i < 128; i++)
        {
            string json; lock (gate) { if (messages.Count == 0) break; json = messages.Dequeue(); }
            if (!PlayerMechanics.GameplayBlocked) Parse(json);
        }
        if (PlayerMechanics.GameplayBlocked || (HasInput && Time.unscaledTime - lastInput > inputTimeout)) ClearInput();
    }
    void Parse(string json)
    {
        try
        {
            var envelope = JsonUtility.FromJson<Envelope>(json);
            bool meaningful = false;
            if (envelope == null) return;
            if (envelope.type == "joystick")
            {
                var value = JsonUtility.FromJson<JoystickMessage>(json);
                if (float.IsNaN(value.x) || float.IsNaN(value.y) || float.IsInfinity(value.x) || float.IsInfinity(value.y)) return;
                stickX = Mathf.Abs(value.x) < 0.1f ? 0f : Mathf.Clamp(value.x, -1f, 1f);
                stickY = Mathf.Abs(value.y) < 0.1f ? 0f : Mathf.Clamp(value.y, -1f, 1f);
                meaningful = stickX != 0 || stickY != 0;
            }
            else if (envelope.type == "button")
            {
                var value = JsonUtility.FromJson<ButtonMessage>(json);
                switch (value.button)
                {
                    case "A": if (value.pressed && !A) downs |= 1; A = value.pressed; break;
                    case "B": if (value.pressed && !B) downs |= 2; B = value.pressed; break;
                    case "X": if (value.pressed && !X) downs |= 4; X = value.pressed; break;
                    case "Y": if (value.pressed && !Y) downs |= 8; Y = value.pressed; break;
                    default: return;
                }
                meaningful = value.pressed;
            }
            else return; // Join/ack/keepalive never activates player controls.
            if (meaningful && !HasInput) { HasInput = true; PlayerMechanics.SetRemotePresent(true); }
            lastInput = Time.unscaledTime;
        }
        catch (ArgumentException) { } // Ignore malformed protocol messages.
    }
    void ClearInput()
    {
        stickX = stickY = 0; A = B = X = Y = false; downs = 0;
        HasInput = false; PlayerMechanics.SetRemotePresent(false);
    }
    async void CloseSocket()
    {
        var current = socket; socket = null; opened = closed = false;
        lock (gate) { messages.Clear(); overflow = false; }
        if (current != null) try { await current.Close(); } catch (Exception) { }
    }
    void OnApplicationFocus(bool focus) { if (!focus) ClearInput(); }
    void OnDisable()
    {
        PlayerMechanics.Changed -= PolicyChanged;
        if (instance == this) { instance = null; ClearInput(); }
        CloseSocket();
    }
    void OnApplicationQuit() { CloseSocket(); }
}
