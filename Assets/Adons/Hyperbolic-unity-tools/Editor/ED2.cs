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
        
        Sphere mp = (Sphere)target;
        for (int i = 0; i < GameObject.FindObjectsOfType<tringle>().Length; i++)
        {
            GameObject.FindObjectsOfType<tringle>()[i].up2(Camd.Main().polarTransform);
        }
        for (int i = 0; i < GameObject.FindObjectsOfType<Sphere>().Length; i++)
        {
            GameObject.FindObjectsOfType<Sphere>()[i].Update(); 
            GameObject.FindObjectsOfType<Sphere>()[i].move();
        }


        base.OnInspectorGUI();
    }



}
