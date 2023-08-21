using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRay : MonoBehaviour
{
    public static RaycastHit MainHit;
    public static Ray Ray;

    private void Awake()
    {
        MainHit = new RaycastHit();
        Ray = new Ray();
    }

    void Update()
    {
        Ray r = GameManager.pprey();
        Ray = r;
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            MainHit = hit;
        } 
    }
}
