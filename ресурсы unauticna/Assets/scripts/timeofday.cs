using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class stateworld
{
    public static bool Eanchitmoning;
    public static bool Eanchitday;
    public static bool Eanchitevening;
    public static bool Eanchitnight;
}

public class timeofday : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (System.DateTime.Now.Hour >= 5 && System.DateTime.Now.Hour <= 12)
        {
            stateworld.Eanchitmoning = true;
        }
        if (System.DateTime.Now.Hour >= 12 && System.DateTime.Now.Hour <= 16)
        {
            stateworld.Eanchitday = true;
        }
        if (System.DateTime.Now.Hour >= 16 && System.DateTime.Now.Hour <= 21)
        {
            stateworld.Eanchitevening = true;
        }
        if (System.DateTime.Now.Hour >= 21 && System.DateTime.Now.Hour <= 5)
        {
            stateworld.Eanchitnight = true;
        }
    }
}
