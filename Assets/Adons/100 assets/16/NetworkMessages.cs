using System;

[System.Serializable]
public class JoinMessage
{
    public string type = "join";
    public string room;
}
[Serializable]
public class JoystickMessage
{
    public string type = "joystick";
    public float x;
    public float y;
}

[Serializable]
public class ButtonMessage
{
    public string type = "button";
    public string button;
    public bool pressed;
}