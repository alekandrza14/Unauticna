using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRay : MonoBehaviour
{
    public static RaycastHit MainHit;
    public static Ray Ray;

    void Update()
    {
        Ray r = musave.pprey();
        Ray = r;
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            MainHit = hit;
        } 
    }
}
