using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spamton_meetigg : MonoBehaviour
{
    
    void Update()
    {
        if (VarSave.ExistenceVar("spamton_contact") ==false)
        {


            FindFirstObjectByType<spamton>().fisttalk = true;
            FindFirstObjectByType<spamton>().higamer = true;
            FindFirstObjectByType<spamton>().del.stopPlayer = true;

        }
    }

}
