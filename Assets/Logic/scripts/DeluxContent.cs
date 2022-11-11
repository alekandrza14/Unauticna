using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeluxContent : MonoBehaviour
{
    public string var;
    // Start is called before the first frame update
    void Start()
    {
        if (VarSave.GetBool(var) != true)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
