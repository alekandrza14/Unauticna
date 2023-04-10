using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;
[EditorTool("Hyperbolic move tool",typeof(Camd))]
public class HyperTransform_for_render : EditorTool
{
    public Texture2D toolIcon;
    public static Sphere mainEdit;

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
        Polar3 trgetpolartransform = ((Camd)target).polarTransform;
        
        Polar3 oldpos = ((Camd)target).polarTransform;
        Transform trgettransform = ((Camd)target).transform;
        EditorGUI.BeginChangeCheck();
        // Quaternion q = Handles.RotationHandle(new Quaternion(trgetpolartransform.n, 1, trgetpolartransform.m,0), SceneView.currentDrawingSceneView.camera.transform.forward+ SceneView.currentDrawingSceneView.camera.transform.position);
        Vector3 v3 = Handles.PositionHandle(new Vector3(0, 0, 0), Quaternion.identity);
        Polar3 newpos = new Polar3(trgetpolartransform.n+ (v3.x)/(40), trgetpolartransform.s + (v3.y) / 40, trgetpolartransform.m + (v3.z) / 40);
      //  ((Sphere)target).p2 = newpos;
      //  Vector3 v32 = Handles.PositionHandle(new Vector3(trgettransform.position.x, trgettransform.position.y, trgettransform.position.z), Quaternion.identity);
        //  ((Sphere)target).v1 = v32.y;
       
        if (EditorGUI.EndChangeCheck())
        {





            Undo.RecordObject(target, "Hyperbolic move tool");
            ((Camd)target).polarTransform = newpos;
            //    ((Camd)target).transform.position = Vector3.up * v32.y;
           

           
          


        }



    }
}
