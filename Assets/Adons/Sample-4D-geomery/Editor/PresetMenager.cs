using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PresetMenager
{
    [MenuItem("GameObject/ND Object/Cube", false, -2)]
    public static void Create_ND_Cube()
    {
        GameObject g = new GameObject("ND_cube")
        {

        };
        g.AddComponent<MultyObject>();
        g.GetComponent<MeshFilter>().sharedMesh = Resources.Load<Mesh>("Cube");
        g.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Default");
        g.transform.position = SceneView.lastActiveSceneView.camera.transform.position + (SceneView.lastActiveSceneView.camera.transform.forward * 10);

    }
    [MenuItem("GameObject/ND Object/Sphere", false, -2)]
    public static void Create_ND_Sphere()
    {
        GameObject g = new GameObject("ND_sphere")
        {

        };
        g.AddComponent<MultyObject>();
        g.GetComponent<MeshFilter>().sharedMesh = Resources.Load<Mesh>("Sphere");
        g.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Default");
        g.transform.position = SceneView.lastActiveSceneView.camera.transform.position + (SceneView.lastActiveSceneView.camera.transform.forward * 10);

    }

}