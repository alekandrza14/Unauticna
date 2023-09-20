using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class raymarchActivator : MonoBehaviour
{
    public RaymarchCam rc;
    Light[] AllLinght;

    private void Start()
    {
        AllLinght = FindObjectsByType<Light>(sortmode.main);
        foreach (Light light in AllLinght)
        {
            if (light.type == LightType.Directional)
            {
                rc._directionalLight = light.transform;
            }
        }
    }

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

            rc._max_iteration = 0;
        }
    }
}
