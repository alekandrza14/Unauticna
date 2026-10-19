using System;
using System.Collections.Generic;
using UnityEngine;
using NativeWebSocket;

// Android sender. Only changed values, releases and a held-input heartbeat are transmitted.
public class AndroidGamepad : MonoBehaviour
{
    public string serverUrl = "wss://quifipugora.beget.app";
    WebSocket socket;
    readonly Queue<string> outgoing = new Queue<string>();
    readonly bool[] buttons = new bool[4];
    static readonly string[] names = { "A", "B", "X", "Y" };
    float x, y, heartbeat, retryAt;
    bool sending, joined;
    volatile bool opened, closed;
    string error;
    void OnEnable() { retryAt = 0; }
    async void Connect()
    {
        var current = new WebSocket(serverUrl); socket = current;
        current.OnOpen += () => { if (socket == current) opened = true; };
        current.OnClose += code => { if (socket == current) closed = true; };
        current.OnError += message => { if (socket == current) error = message; };
        try { await current.Connect(); } catch (Exception ex) { if (socket == current) { error = ex.Message; closed = true; } }
    }
    void Queue(string json)
    {
        if (!joined) return;
        if (outgoing.Count >= 128) { ResetInput(); CloseSocket(); retryAt = Time.unscaledTime + 3; return; }
        outgoing.Enqueue(json); Flush();
    }
    async void Flush()
    {
        if (sending || socket == null) return;
        var current = socket; sending = true;
        try
        {
            while (socket == current && outgoing.Count > 0) await current.SendText(outgoing.Dequeue());
        }
        catch (Exception ex) { if (socket == current) { error = ex.Message; closed = true; } }
        finally { if (socket == current) sending = false; }
    }
    public void SendJoystick(float horizontal, float vertical)
    {
        if (!isActiveAndEnabled) return;
        horizontal = Mathf.Clamp(horizontal, -1, 1); vertical = Mathf.Clamp(vertical, -1, 1);
        if (Mathf.Abs(horizontal - x) < 0.001f && Mathf.Abs(vertical - y) < 0.001f) return;
        x = horizontal; y = vertical;
        Queue(JsonUtility.ToJson(new JoystickMessage { x = x, y = y }));
    }
    public void SendButton(string button, bool pressed)
    {
        if (!isActiveAndEnabled) return;
        int index = Array.IndexOf(names, button); if (index < 0 || buttons[index] == pressed) return;
        buttons[index] = pressed; Queue(JsonUtility.ToJson(new ButtonMessage { button = button, pressed = pressed }));
    }
    void Update()
    {
        if (socket == null && Time.unscaledTime >= retryAt) { retryAt = Time.unscaledTime + 3; Connect(); }
#if !UNITY_WEBGL || UNITY_EDITOR
        socket?.DispatchMessageQueue();
#endif
        if (closed) { closed = false; ResetInput(); CloseSocket(); retryAt = Time.unscaledTime + 3; }
        if (opened)
        {
            opened = false; joined = true;
            Queue(JsonUtility.ToJson(new JoinMessage { room = GeneratorXboxCobe.GenCode().ToString() }));
            heartbeat = 0;
        }
        if (error != null) { string message = error; error = null; Debug.LogWarning("Gamepad: " + message, this); }
        if (!joined || Time.unscaledTime < heartbeat) return;
        heartbeat = Time.unscaledTime + 0.5f;
        if (x != 0 || y != 0) Queue(JsonUtility.ToJson(new JoystickMessage { x = x, y = y }));
        for (int i = 0; i < buttons.Length; i++) if (buttons[i]) Queue(JsonUtility.ToJson(new ButtonMessage { button = names[i], pressed = true }));
    }
    void ResetInput() { x = y = 0; Array.Clear(buttons, 0, buttons.Length); }
    public void ReleaseAll()
    {
        SendJoystick(0, 0); for (int i = 0; i < buttons.Length; i++) SendButton(names[i], false);
    }
    async void CloseSocket()
    {
        var current = socket; socket = null; joined = sending = opened = closed = false; outgoing.Clear();
        if (current != null) try { await current.Close(); } catch (Exception) { }
    }
    void OnApplicationFocus(bool focus) { if (!focus) ReleaseAll(); }
    void OnDisable() { ResetInput(); CloseSocket(); }
    void OnApplicationQuit() { CloseSocket(); }
}
