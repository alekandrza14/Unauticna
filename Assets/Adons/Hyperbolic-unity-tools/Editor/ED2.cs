using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Sphere))]
public class ED2 : Editor
{
    const string resourceFilename = "custom-editor-uie";

    
    public override void OnInspectorGUI()
    {
        /*"generate new point"*/
        
        Sphere mp = (Sphere)target;
       // for (int i = 0; i < GameObject.FindObjectsOfType<tringle>().Length; i++)
       // {
       //     GameObject.FindObjectsOfType<tringle>()[i].up2(HyperbolicCamera.Main().polarTransform);
       // }
        for (int i = 0; i < GameObject.FindObjectsByType<Sphere>(sortmode.main).Length; i++)
        {
            GameObject.FindObjectsByType<Sphere>(sortmode.main)[i].Update(); 
        }
       

        base.OnInspectorGUI();

        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("=============");
        if (EditorGUILayout.LinkButton("generate new point"))
        {
            GameObject g = new GameObject("point" + GameObject.FindObjectsByType<Sphere>(sortmode.main).Length.ToString());
            g.AddComponent<Sphere>().p2 = ((Sphere)target).p2.copy();
            g.GetComponent<Sphere>().v1 = ((Sphere)target).v1;
            //  (Sphere)target;
        }

        EditorGUILayout.LabelField("=============");
    }



}
