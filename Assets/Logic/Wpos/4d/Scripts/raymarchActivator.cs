using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raymarchActivator : MonoBehaviour
{
    public RaymarchCam rc;
    void Update()
    {
        if (GameObject.FindObjectsByType<Shape4D>(sortmode.main).Length != 0)
        {
            GetComponent<Camera>().renderingPath = RenderingPath.DeferredShading;
            rc.enabled = true;
        }
        if (GameObject.FindObjectsByType<Shape4D>(sortmode.main).Length == 0)
        {
            GetComponent<Camera>().renderingPath = RenderingPath.DeferredShading;
            rc.enabled = false;
        }
    }
}
