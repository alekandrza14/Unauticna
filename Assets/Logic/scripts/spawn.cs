using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject ob;
    public string varible;
    
    void Update()
    {
        if (!VarSave.ExistenceVar(varible))
        {
            Destroy(ob);
        }
    }
}
