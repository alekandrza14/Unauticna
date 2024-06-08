using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Create_4D
{
   // static int mainversion = 0; static int neoversion = 1; static int version = 0;
    [MenuItem("GameObject/4D Object/Hyperbolic geometry/Point", false,-1000)]
    public static void Create()
    {
        //Transform t=  SceneView.currentDrawingSceneView.HB_Camera.transform;
        GameObject g = new GameObject("Point")
        {

        };
        g.AddComponent<HyperbolicPoint>();
    }
    [MenuItem("GameObject/4D Object/Hyperbolic geometry/Cube", false, -1000)]
    public static void CreateCube()
    {
        //Transform t=  SceneView.currentDrawingSceneView.HB_Camera.transform;
        GameObject g = new GameObject("Cube")
        {

        };
        if (Hyperbolicmovetool.mainEdit != null) { g.AddComponent<HyperbolicPoint>().HyperboilcPoistion = Hyperbolicmovetool.mainEdit.HyperboilcPoistion; g.GetComponent<HyperbolicPoint>().v1 = Hyperbolicmovetool.mainEdit.v1; } else g.AddComponent<HyperbolicPoint>();

        g.AddComponent<MeshFilter>().sharedMesh = Resources.Load<Mesh>("Cube");
        g.AddComponent<BoxCollider>();
       g.AddComponent<MeshRenderer>().material = Resources.Load<Material>("Default");
    }
    [MenuItem("GameObject/4D Object/Hyperbolic geometry/sphere", false, -1000)]
    public static void CreateSphere()
    {
        //Transform t=  SceneView.currentDrawingSceneView.HB_Camera.transform;
        GameObject g = new GameObject("sphere")
        {

        };
        if (Hyperbolicmovetool.mainEdit != null) {g.AddComponent<HyperbolicPoint>().HyperboilcPoistion = Hyperbolicmovetool.mainEdit.HyperboilcPoistion; g.GetComponent<HyperbolicPoint>().v1 = Hyperbolicmovetool.mainEdit.v1; } else g.AddComponent<HyperbolicPoint>();
        g.AddComponent<SphereCollider>();
        g.AddComponent<MeshFilter>().sharedMesh = Resources.Load<Mesh>("sphere");
        g.AddComponent<MeshRenderer>().material = Resources.Load<Material>("Default");
    }
}