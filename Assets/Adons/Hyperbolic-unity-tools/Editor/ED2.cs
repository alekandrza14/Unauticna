using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HyperbolicPoint))]
public class ED2 : Editor
{
    const string resourceFilename = "custom-editor-uie";

    
    public override void OnInspectorGUI()
    {
        /*"LoadTerraform new point"*/
        
        HyperbolicPoint mp = (HyperbolicPoint)target;
       // for (int i = 0; i < GameObject.FindObjectsOfType<tringle>().Length; i++)
       // {
       //     GameObject.FindObjectsOfType<tringle>()[i].up2(HyperbolicCamera.Main().polarTransform);
       // }
      
       

        base.OnInspectorGUI();

        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("=============");
        if (EditorGUILayout.LinkButton("LoadTerraform new point"))
        {
            GameObject g = new GameObject("point" + GameObject.FindObjectsByType<HyperbolicPoint>(sortmode.main).Length.ToString());
            g.AddComponent<HyperbolicPoint>().HyperboilcPoistion = ((HyperbolicPoint)target).HyperboilcPoistion.copy();
            g.GetComponent<HyperbolicPoint>().v1 = ((HyperbolicPoint)target).v1;
            //  (HyperbolicPoint)target;
        }

        EditorGUILayout.LabelField("=============");
    }



}
