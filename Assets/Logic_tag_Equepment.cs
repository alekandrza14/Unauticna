using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic_tag_Equepment : MonoBehaviour
{
    public string Varible;
    public double Value;

    void Start()
    {
        if (VarSave.GetTrash(Varible)<Value)
        {
            Destroy(gameObject.GetComponent<MeshRenderer>());
            Destroy(gameObject.GetComponent<MeshFilter>());
        }
    }

}
