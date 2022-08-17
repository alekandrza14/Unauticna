using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogRotation : MonoBehaviour
{
    public deldialog del;
    public GameObject obj;
    public Transform target;
    public string character;
    void Start()
    {
        if (VarSave.GetInt("dies-"+character) == 1)
        {
            Destroy(target.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (del.text.text == "s2-attackforse()")
        {
            Instantiate(obj,target.position,target.rotation);
            VarSave.SetInt(del.delattack+ "attackforse", 1);
            Destroy(target.gameObject);
        }
    }
}
