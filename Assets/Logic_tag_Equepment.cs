using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic_tag_Equepment : MonoBehaviour
{
    public string Varible;
    public double Value;
 
    public void UpdateEquepment()
    {
        if (VarSave.GetTrash(Varible) < Value)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        if (VarSave.GetTrash(Varible) >= Value)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }

}
