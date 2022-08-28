using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


[CustomEditor(typeof(tringle))]
public class ED : Editor
{
    const string resourceFilename = "custom-editor-uie";
    public static tringle mp1; public static tringle mp2;
    
    
    public override void OnInspectorGUI()
    {
        
         
        
        tringle mp = (tringle)target;
        
        mp1 = (tringle)target;
         
        for (int i = 0; i < GameObject.FindObjectsOfType<tringle>().Length; i++)
        {
            GameObject.FindObjectsOfType<tringle>()[i].up2(Camd.Main().polarTransform);
            GameObject.FindObjectsOfType<tringle>()[i].move();
        }
        for (int i = 0; i < GameObject.FindObjectsOfType<Sphere>().Length; i++)
        {
            GameObject.FindObjectsOfType<Sphere>()[i].Update();
        }


        base.OnInspectorGUI();
    }



}


