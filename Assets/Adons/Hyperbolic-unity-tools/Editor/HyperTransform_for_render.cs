using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;
[EditorTool("Hyperbolic move tool",typeof(HyperbolicCamera))]
public class HyperTransform_for_render : EditorTool
{
    public Texture2D toolIcon;
    public static HyperbolicPoint mainEdit;

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
        Hyperbolic2D trgetpolartransform = ((HyperbolicCamera)target).HyperbolicTransform;
        
        Hyperbolic2D oldpos = ((HyperbolicCamera)target).HyperbolicTransform;
        Transform trgettransform = ((HyperbolicCamera)target).transform;
        EditorGUI.BeginChangeCheck();
        // Quaternion q = Handles.RotationHandle(new Quaternion(trgetpolartransform.n, 1, trgetpolartransform.m,0), SceneView.currentDrawingSceneView.HB_Camera.transform.forward+ SceneView.currentDrawingSceneView.HB_Camera.transform.position);

        Vector3 v3 = Handles.PositionHandle(new Vector3(0, 0, 0), Quaternion.identity);

      //  trgetpolartransform.applyTranslationY(v3.x / 200);
       // trgetpolartransform.applyTranslationZ(v3.z / 200);
       // trgetpolartransform.applyRotation(v3.y / 200);
        //  ((HyperbolicPoint)target).p2 = newpos;
        //  ((HyperbolicPoint)target).p2 = newpos;
        //  Vector3 v32 = Handles.PositionHandle(new Vector3(trgettransform.position.x, trgettransform.position.y, trgettransform.position.z), Quaternion.identity);
        //  ((HyperbolicPoint)target).v1 = v32.y;

        if (EditorGUI.EndChangeCheck())
        {





            Undo.RecordObject(target, "Hyperbolic move tool");
            ((HyperbolicCamera)target).HyperbolicTransform = trgetpolartransform;
            //    ((Camd)target).transform.position = Vector3.up * v32.y;
           

           
          


        }



    }
}
