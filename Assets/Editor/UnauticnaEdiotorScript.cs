using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UnauticnaEdiotorScript {
    [MenuItem("GameObject/4D Object/Eucidian geometry/Raymarch Sphare", false, -1000)]
    public static void Create()
    {
        //Transform t=  SceneView.currentDrawingSceneView.camera.transform;
        GameObject g = new GameObject("HyperbolicPoint 4D")
        {

        };
        g.AddComponent<Shape4D>();
        g.transform.position = SceneView.lastActiveSceneView.camera.transform.position;
    }
    [MenuItem("GameObject/4D Object/Eucidian geometry/Poilgon Sphare(multyTransform need)", false, -1000)]
    public static void Create2()
    {
        //Transform t=  SceneView.currentDrawingSceneView.camera.transform;
        GameObject g = new GameObject("Cube 4D")
        {

        };


        g.AddComponent<MeshFilter>().sharedMesh = Resources.Load<Mesh>("Cube");
        g.AddComponent<BoxCollider>();
        g.AddComponent<MeshRenderer>().material = Resources.Load<Material>("Default");
        g.AddComponent<MultyObject>();
    }
    [MenuItem("GameObject/4D System/Eucidian geometry/multyTransform", false, -1000)]
    public static void Create3()
    {
        //Transform t=  SceneView.currentDrawingSceneView.camera.transform;
        GameObject g = new GameObject("4D Controler")
        {

        };


        g.AddComponent<MultyTransform>();
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
