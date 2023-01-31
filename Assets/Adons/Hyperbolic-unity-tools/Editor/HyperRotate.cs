using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;


[EditorTool("Hyperbolic rotate tool", typeof(Sphere))]
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
        Sphere trgetpolartransform = ((Sphere)target);
        EditorGUI.BeginChangeCheck();
        // Quaternion q = Handles.RotationHandle(new Quaternion(trgetpolartransform.n, 1, trgetpolartransform.m,0), SceneView.currentDrawingSceneView.camera.transform.forward+ SceneView.currentDrawingSceneView.camera.transform.position);
        Quaternion q = Handles.RotationHandle(trgetpolartransform.rotation, trgetpolartransform.mposition);
       

        if (EditorGUI.EndChangeCheck())
        {



            Undo.RecordObject(target, "Hyperbolic rotate tool");


            ((Sphere)target).rotation = q;


          
            ((Sphere)target).Update();



        }
        /*
        if (((Sphere)target).GetComponent<tringle>())
        {


            Gizmos.color = Color.green;
            Gizmos.DrawSphere(((Sphere)target).mposition, 0.3f);
        }
        */



    }

}
