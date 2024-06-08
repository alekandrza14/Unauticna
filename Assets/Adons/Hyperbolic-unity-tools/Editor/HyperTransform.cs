using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;
using Unity.Mathematics;

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
    public static Vector3 oldpos2;
    public static Vector3 oldpos3;
    public static Vector3 oldpos4;
    public static Hyperbolic2D oldpos5;
    public override void OnToolGUI(EditorWindow window)
    {
        Hyperbolic2D trgetpolartransform = ((HyperbolicPoint)target).HyperboilcPoistion;
        Hyperbolicmovetool.mainEdit = ((HyperbolicPoint)target);

        Transform trgettransform = ((HyperbolicPoint)target).transform;
        EditorGUI.BeginChangeCheck();
        // Quaternion q = Handles.RotationHandle(new Quaternion(trgetpolartransform.n, 1, trgetpolartransform.m,0), SceneView.currentDrawingSceneView.HB_Camera.transform.forward+ SceneView.currentDrawingSceneView.HB_Camera.transform.position);
        Vector3 v3 = (Handles.PositionHandle(SceneView.currentDrawingSceneView.camera.transform.forward + SceneView.currentDrawingSceneView.camera.transform.position, Quaternion.identity) - (SceneView.currentDrawingSceneView.camera.transform.forward + SceneView.currentDrawingSceneView.camera.transform.position));


        trgetpolartransform.applyTranslationY(obrez(v3.x) / 20);
        trgetpolartransform.applyTranslationZ(obrez(v3.z) / 20);
        //  trgetpolartransform.applyRotation(v3.y / 200);
        //  ((HyperbolicPoint)target).p2 = newpos;
       // Vector3 v32 = Handles.PositionHandle(new Vector3(trgettransform.position.x, ((HyperbolicPoint)target).v1, trgettransform.position.z), Quaternion.identity);

        //  ((HyperbolicPoint)target).v1 = v32.y;

        if (EditorGUI.EndChangeCheck())
        {



            Undo.RecordObject(target, "Hyperbolic move tool");
            trgettransform.position = Vector3.up * v3.y;
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

    private static float obrez(float x)
    {
        if (x > 10f)
        {
            x = 10f;
        }
        if (x < -10f)
        {
            x = -10f;
        }

        return x;
    }
}

