using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;

[EditorTool("Hyperbolic move tool",typeof(Sphere))]
public class HyperTransform : EditorTool
{
    public Texture2D toolIcon;

    public override GUIContent toolbarIcon {
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
        PolarTransform trgetpolartransform = ((Sphere)target).p2;
        Hyperbolicmovetool.mainEdit = ((Sphere)target);
        PolarTransform oldpos = ((Sphere)target).p2;
        Transform trgettransform = ((Sphere)target).transform;
        EditorGUI.BeginChangeCheck();
        // Quaternion q = Handles.RotationHandle(new Quaternion(trgetpolartransform.n, 1, trgetpolartransform.m,0), SceneView.currentDrawingSceneView.camera.transform.forward+ SceneView.currentDrawingSceneView.camera.transform.position);
        Vector3 v3 = Handles.PositionHandle(new Vector3(0, 0, 0), Quaternion.identity);
        PolarTransform newpos = new PolarTransform(trgetpolartransform.n+ (v3.x)/(1000), trgetpolartransform.s + (v3.y) / 1000, trgetpolartransform.m + (v3.z) / 1000);
      //  ((Sphere)target).p2 = newpos;
        Vector3 v32 = Handles.PositionHandle(new Vector3(trgettransform.position.x, ((Sphere)target).v1, trgettransform.position.z), Quaternion.identity);
        //  ((Sphere)target).v1 = v32.y;
      
        if (EditorGUI.EndChangeCheck())
        {
            


                Undo.RecordObject(trgettransform, "Hyperbolic move tool");
                ((Sphere)target).p2 = newpos;
                ((Sphere)target).v1 = v32.y;
           

           ((Sphere)target).LateUpdate();
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
