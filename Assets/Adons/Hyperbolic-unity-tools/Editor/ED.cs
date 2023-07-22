using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


[CustomEditor(typeof(HyperbolicTriangeRenederer))]
public class ED : Editor
{
    const string resourceFilename = "custom-editor-uie";
    public static HyperbolicTriangeRenederer mp1; public static HyperbolicTriangeRenederer mp2;
    
    
    public override void OnInspectorGUI()
    {
        
         
        
        HyperbolicTriangeRenederer mp = (HyperbolicTriangeRenederer)target;
        
        mp1 = (HyperbolicTriangeRenederer)target;
         
      //  for (int i = 0; i < GameObject.FindObjectsOfType<tringle>().Length; i++)
     //   {
     //       GameObject.FindObjectsOfType<tringle>()[i].up2(HyperbolicCamera.Main().polarTransform);
     //       GameObject.FindObjectsOfType<tringle>()[i].move();
     //   }
      


        base.OnInspectorGUI();
        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("=============");
    }



}


