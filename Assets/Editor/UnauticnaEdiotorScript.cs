using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UnauticnaEdiotorScript {
    [MenuItem("GameObject/4D Object/Eucidian geometry/Sphere", false, -1000)]
    public static void Create()
    {
        //Transform t=  SceneView.currentDrawingSceneView.camera.transform;
        GameObject g = new GameObject("Sphere 4D")
        {

        };
        g.AddComponent<Shape4D>();
        g.transform.position = SceneView.lastActiveSceneView.camera.transform.position;
    }
    [MenuItem("GameObject/4D move Up")]
    public static void CreateUp()
    {
        GameObject.FindObjectOfType<RaymarchCam>()._wPosition += 1f;
    }
    [MenuItem("GameObject/4D move Down")]
    public static void CreateDown()
    {
        GameObject.FindObjectOfType<RaymarchCam>()._wPosition -= 1f;
    }

}
