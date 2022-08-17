using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorHyperRenderer : EditorWindow
{
    // Start is called before the first frame update
    public static bool hyperrenderer = false;

    [MenuItem("Window/Rendering/HyperRender")]
    public static void ShowWindow()
    {
        GetWindow<EditorHyperRenderer>("render");
    }

    private void OnGUI()
    {
        hyperrenderer = EditorGUILayout.Toggle("hyperrenderer", hyperrenderer);
        if (EditorGUILayout.LinkButton("HyperRenderstop"))
        {
            hyperrenderer = false;
            for (int i = 0; i < GameObject.FindObjectsOfType<HyperObject2D>().Length; i++)
            {
                if (GameObject.FindObjectsOfType<HyperObject2D>().Length != 0)
                {




                    HyperObject2D.stoprender(GameObject.FindObjectsOfType<HyperObject2D>()[i].transform, GameObject.FindObjectsOfType<HyperObject2D>()[i], SceneView.lastActiveSceneView.camera.transform.position);

                }

            }
            

        }
    }
    private void OnInspectorUpdate()
    {
        if (hyperrenderer)
        {
            for (int i = 0; i < GameObject.FindObjectsOfType<HyperObject2D>().Length; i++)
            {

                if (GameObject.FindObjectsOfType<HyperObject2D>().Length != 0)
                {



                    HyperObject2D.startrender(GameObject.FindObjectsOfType<HyperObject2D>()[i].transform, GameObject.FindObjectsOfType<HyperObject2D>()[i], SceneView.lastActiveSceneView.camera.transform.position);


                }

            }
            

        }


    }
        

        
        







}
