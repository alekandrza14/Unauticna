using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;


[EditorTool("Hyperbolic rotate tool", typeof(PolarHyperbolicPoint))]
public class HyperRotate : EditorTool
{
    public Texture2D toolIcon;

    public override GUIContent toolbarIcon
    {
        get
        {
            return new GUIContent
            {
                image = toolIcon,
                text = "Hyperbolic move tool"

            };
        }
    }

    public override void OnToolGUI(EditorWindow window)
    {
        PolarHyperbolicPoint trgetpolartransform = ((PolarHyperbolicPoint)target);
        EditorGUI.BeginChangeCheck();
        // Quaternion q = Handles.RotationHandle(new Quaternion(trgetpolartransform.n, 1, trgetpolartransform.m,0), SceneView.currentDrawingSceneView.camera.transform.forward+ SceneView.currentDrawingSceneView.camera.transform.position);
        Quaternion q = Handles.RotationHandle(trgetpolartransform.rotation, trgetpolartransform.mposition);
       

        if (EditorGUI.EndChangeCheck())
        {



            Undo.RecordObject(target, "Hyperbolic rotate tool");


            ((PolarHyperbolicPoint)target).rotation = q;


          



        }
        /*
        if (((PolarHyperbolicPoint)target).GetComponent<tringle>())
        {


            Gizmos.color = Color.green;
            Gizmos.DrawSphere(((PolarHyperbolicPoint)target).mposition, 0.3f);
        }
        */



    }

}
