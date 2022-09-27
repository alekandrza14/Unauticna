using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spamton_meetigg : MonoBehaviour
{
    
    void Update()
    {
        if (VarSave.GetBool("spamton_contact") ==false)
        {


            FindObjectOfType<spamton>().fisttalk = true;
            FindObjectOfType<spamton>().higamer = true;
            FindObjectOfType<spamton>().del.stopPlayer = true;

        }
    }

}
