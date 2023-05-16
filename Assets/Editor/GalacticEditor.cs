using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Gen_galactic))]
public class GalacticEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Gen_galactic mp = (Gen_galactic)target;
        base.OnInspectorGUI();
        if (EditorGUILayout.LinkButton("Generate"))
        {
            mp.Run();
        }
    }
}
