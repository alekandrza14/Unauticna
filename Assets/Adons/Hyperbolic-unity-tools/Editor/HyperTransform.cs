using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

[EditorTool("Hyperbolic move tool", typeof(PolarHyperbolicPoint))]
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
        PolarHyperbolic2D trgetpolartransform = ((PolarHyperbolicPoint)target).HyperboilcPoistion;
        Hyperbolicmovetool.mainEdit = ((PolarHyperbolicPoint)target);
        PolarHyperbolic2D oldpos = ((PolarHyperbolicPoint)target).HyperboilcPoistion;
        Transform trgettransform = ((PolarHyperbolicPoint)target).transform;
        EditorGUI.BeginChangeCheck();
        // Quaternion q = Handles.RotationHandle(new Quaternion(trgetpolartransform.n, 1, trgetpolartransform.m,0), SceneView.currentDrawingSceneView.camera.transform.forward+ SceneView.currentDrawingSceneView.camera.transform.position);
        Vector3 v3 = (Handles.PositionHandle(SceneView.currentDrawingSceneView.camera.transform.forward + SceneView.currentDrawingSceneView.camera.transform.position, Quaternion.identity) - (SceneView.currentDrawingSceneView.camera.transform.forward + SceneView.currentDrawingSceneView.camera.transform.position));

      //  trgetpolartransform.applyTranslationY(v3.x / 200);
       // trgetpolartransform.applyTranslationZ(v3.z / 200);
      //  trgetpolartransform.applyRotation(v3.y / 200);
        //  ((PolarHyperbolicPoint)target).p2 = newpos;
        Vector3 v32 = Handles.PositionHandle(new Vector3(trgettransform.position.x, ((PolarHyperbolicPoint)target).v1, trgettransform.position.z), Quaternion.identity);
        //  ((PolarHyperbolicPoint)target).v1 = v32.y;

        if (EditorGUI.EndChangeCheck())
        {



            Undo.RecordObject(target, "Hyperbolic move tool");
            ((PolarHyperbolicPoint)target).v1 = v32.y;

            ((PolarHyperbolicPoint)target).HyperboilcPoistion = trgetpolartransform;

            ((PolarHyperbolicPoint)target).LateUpdate();



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

