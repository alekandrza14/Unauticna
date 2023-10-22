using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;

[EditorTool("Hyperbolic move tool", typeof(HyperbolicPoint))]
public class HyperTransform : EditorTool
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
        Hyperbolic2D trgetpolartransform = ((HyperbolicPoint)target).HyperboilcPoistion;
        Hyperbolicmovetool.mainEdit = ((HyperbolicPoint)target);
        Hyperbolic2D oldpos = ((HyperbolicPoint)target).HyperboilcPoistion;
        Transform trgettransform = ((HyperbolicPoint)target).transform;
        EditorGUI.BeginChangeCheck();
        // Quaternion q = Handles.RotationHandle(new Quaternion(trgetpolartransform.n, 1, trgetpolartransform.m,0), SceneView.currentDrawingSceneView.camera.transform.forward+ SceneView.currentDrawingSceneView.camera.transform.position);
        Vector3 v3 = (Handles.PositionHandle(SceneView.currentDrawingSceneView.camera.transform.forward + SceneView.currentDrawingSceneView.camera.transform.position, Quaternion.identity) - (SceneView.currentDrawingSceneView.camera.transform.forward + SceneView.currentDrawingSceneView.camera.transform.position));

      //  trgetpolartransform.applyTranslationY(v3.x / 200);
       // trgetpolartransform.applyTranslationZ(v3.z / 200);
      //  trgetpolartransform.applyRotation(v3.y / 200);
        //  ((HyperbolicPoint)target).p2 = newpos;
        Vector3 v32 = Handles.PositionHandle(new Vector3(trgettransform.position.x, ((HyperbolicPoint)target).v1, trgettransform.position.z), Quaternion.identity);
        //  ((HyperbolicPoint)target).v1 = v32.y;

        if (EditorGUI.EndChangeCheck())
        {



            Undo.RecordObject(target, "Hyperbolic move tool");
            ((HyperbolicPoint)target).v1 = v32.y;

            ((HyperbolicPoint)target).HyperboilcPoistion = trgetpolartransform;

            ((HyperbolicPoint)target).LateUpdate();



        }
        /*
        if (((HyperbolicPoint)target).GetComponent<tringle>())
        {


            Gizmos.color = Color.green;
            Gizmos.DrawSphere(((HyperbolicPoint)target).mposition, 0.3f);
        }
        */



    }

}

