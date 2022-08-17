using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raymarchActivator : MonoBehaviour
{
    public RaymarchCam rc;
    void Update()
    {
        if (GameObject.FindObjectsOfType<Shape4D>().Length != 0)
        {
            rc.enabled = true;
        }
        if (GameObject.FindObjectsOfType<Shape4D>().Length == 0)
        {
            rc.enabled = false;
        }
    }
}
