using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class otvet : MonoBehaviour
{
    public InputField ifd;
    public string otvit;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Destroy(gameObject);
        }
        if (ifd.text == otvit)
        {
            VarSave.SetBool(otvit+"получен",true);
            Destroy(gameObject);
        }
    }
}
