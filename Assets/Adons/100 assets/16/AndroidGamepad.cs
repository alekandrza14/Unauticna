using UnityEngine;
using NativeWebSocket;

public class AndroidGamepad : MonoBehaviour
{
    public string serverUrl =
        "wss://quifipugora.beget.app";


    private WebSocket socket;

    async void Start()
    {
        socket = new WebSocket(serverUrl);

        socket.OnOpen += () =>
        {
            JoinRoom();
        };

        await socket.Connect();
    }

    async void JoinRoom()
    {
        JoinMessage msg = new JoinMessage();
        msg.room = GeneratorXboxCobe.GenCode().ToString();

        await socket.SendText(
            JsonUtility.ToJson(msg)
        );
    }

    public async void SendJoystick(
        float x,
        float y)
    {
        JoystickMessage msg =
            new JoystickMessage();

        msg.x = x;
        msg.y = y;

        await socket.SendText(
            JsonUtility.ToJson(msg)
        );
    }
    float timer;

    
    
    public async void SendButton(
        string button,
        bool pressed)
    {
        ButtonMessage msg =
            new ButtonMessage();

        msg.button = button;
        msg.pressed = pressed;

        await socket.SendText(
            JsonUtility.ToJson(msg)
        );
    }

    float sendTimer;
    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        socket?.DispatchMessageQueue();
#endif

       
    }

    async void OnApplicationQuit()
    {
        if (socket != null)
            await socket.Close();
    }
}