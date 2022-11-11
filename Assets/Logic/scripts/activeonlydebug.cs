using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class activeonlydebug : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!Directory.Exists("debug") && GetComponent<SkinnedMeshRenderer>())
        {
            GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
        if (!Directory.Exists("debug") && GetComponent<MeshRenderer>())
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    
}
