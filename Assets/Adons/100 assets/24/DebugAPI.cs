using UnityEngine;

public class DebugAPI
{
    public void Log(object s)
    {
        Debug.Log(s);
    }

    public void Error(object s)
    {
        Debug.LogError(s);
    }
}