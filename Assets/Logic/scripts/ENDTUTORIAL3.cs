using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDTUTORIAL3 : MonoBehaviour
{
    
    void Start()
    {
        if (!VarSave.ExistenceVar("t3end"))
        {
            Destroy(gameObject);
        }
    }

}
