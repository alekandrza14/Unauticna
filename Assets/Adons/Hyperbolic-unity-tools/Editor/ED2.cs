using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PolarHyperbolicPoint))]
public class ED2 : Editor
{
    const string resourceFilename = "custom-editor-uie";

    
    public override void OnInspectorGUI()
    {
        /*"generate new point"*/

        PolarHyperbolicPoint mp = (PolarHyperbolicPoint)target;
       // for (int i = 0; i < GameObject.FindObjectsOfType<tringle>().Length; i++)
       // {
       //     GameObject.FindObjectsOfType<tringle>()[i].up2(HyperbolicCamera.Main().polarTransform);
       // }
      
       

        base.OnInspectorGUI();

        EditorGUILayout.LabelField("");
        EditorGUILayout.LabelField("=============");
        if (EditorGUILayout.LinkButton("generate new point"))
        {
            GameObject g = new GameObject("point" + GameObject.FindObjectsByType<PolarHyperbolicPoint>(sortmode.main).Length.ToString());
            g.AddComponent<PolarHyperbolicPoint>().HyperboilcPoistion = ((PolarHyperbolicPoint)target).HyperboilcPoistion.copy();
            g.GetComponent<PolarHyperbolicPoint>().v1 = ((PolarHyperbolicPoint)target).v1;
            //  (HyperbolicPoint)target;
        }

        EditorGUILayout.LabelField("=============");
    }



}
