using UnityEngine;

public class InputAPI
{
    public bool GetKey(string key)
    {
        return Input.GetKey(key);
    }

    public bool GetMouseButton(int i)
    {
        return Input.GetMouseButton(i);
    }
}