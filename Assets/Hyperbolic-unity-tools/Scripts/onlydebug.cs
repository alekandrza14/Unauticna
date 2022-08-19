using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class onlydebug : MonoBehaviour
{
    
    void Start()
    {
        if (!Directory.Exists("debug"))
        {
            Destroy(gameObject);
        }
    }

    
}
