using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject ob;
    public string varible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!VarSave.ExistenceVar(varible))
        {
            Destroy(ob);
        }
    }
}
