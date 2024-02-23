using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compas : MonoBehaviour
{
    
    void Update()
    {
        string s = "";
        int i = 0;
        foreach(float pos in mover.main().N_position)
        {
            s += "["+i+"] :> " + pos;
            i++;
        }
        GetComponent<Text>().text = s;
    }
}
