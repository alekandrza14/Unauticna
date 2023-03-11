using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold : MonoBehaviour
{

   
    private void OnMouseDown()
    {

        VarSave.SetInt("tevro", VarSave.GetInt("tevro") + 3);
        Destroy(gameObject);
    }
}
