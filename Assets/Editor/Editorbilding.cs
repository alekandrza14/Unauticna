


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Web.UI;

[CustomEditor(typeof(EditorTag1))]
public class generator : Editor
{
    private EditorTag1 gm;

    public void OnEnable()
    {
        gm = (EditorTag1)target;

    }
    public override void OnInspectorGUI()
    {
        


            if (GUILayout.Button("Set Tag"))
            {


            gm.tag = gm.newTag;
            }

        base.OnInspectorGUI();





    }
}