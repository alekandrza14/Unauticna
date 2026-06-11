using UnityEngine;
using NativeWebSocket;
using System.Text;
using System.Collections.Generic;

public class WindowsReceiver : MonoBehaviour
{
    public string serverUrl =
        "wss://quifipugora.beget.app";

  

    private WebSocket socket;

    public float stickX;
    public float stickY;
    Queue<string> messages =
new Queue<string>();

    public bool A;
    public bool B;
    public bool X;
    public bool Y;

    async void SendJoin()
    {
        JoinMessage join = new JoinMessage();
        join.room = GeneratorXboxCobe.GenCode().ToString();

        string json = JsonUtility.ToJson(join);

        Debug.Log("JSON = " + json);

        await socket.SendText(json);

        Debug.Log("Join sent");
    }
    async void Start()
    {
        socket = new WebSocket(serverUrl);

        socket.OnOpen += () =>
        {
            Invoke(nameof(SendJoin), 1f);
        };


        socket.OnMessage += bytes =>
        {
            messages.Enqueue(
                Encoding.UTF8.GetString(bytes)
            );
        };
      
        await socket.Connect();
    }


    void Parse(string json)
    {
        if (json.Contains("\"type\":\"joystick\""))
        {
            var msg =
                JsonUtility.FromJson<JoystickMessage>(json);

            stickX = Mathf.Lerp(stickX, msg.x, 0.2f);
            stickY = Mathf.Lerp(stickY, msg.y, 0.2f);
            if (Mathf.Abs(stickX) < 0.1f) stickX = 0;
            if (Mathf.Abs(stickY) < 0.1f) stickY = 0;
        }


        if (json.Contains("\"type\":\"button\""))
        {
            var msg =
                JsonUtility.FromJson
                <ButtonMessage>(json);

            switch(msg.button)
            {
                case "A":
                    A = msg.pressed;
                    break;

                case "B":
                    B = msg.pressed;
                    break;

                case "X":
                    X = msg.pressed;
                    break;

                case "Y":
                    Y = msg.pressed;
                    break;
            }
        }
    }
    float sendTimer;
    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        socket?.DispatchMessageQueue();
#endif

        if (messages.Count > 0)
        {
            for (int i = 0;i<2;i++)
            {
                if (i == 0) Parse(messages.Dequeue());
                if (i == 1) messages.Clear();
            }
        }
       

    }
}