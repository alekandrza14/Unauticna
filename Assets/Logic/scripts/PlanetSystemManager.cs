using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSystemManager : MonoBehaviour
{
    public GameObject[] Planet;
    void Start()
    {

        if (VarSave.GetBool("NoStop"))
        {
            foreach (GameObject g in Planet)
            {
                g.SetActive(false);
            }
        }
    }

    
}
