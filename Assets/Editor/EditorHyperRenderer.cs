using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class EditorHyperRenderer : EditorWindow
{
    // Start is called before the first frame update
    public static bool hyperrenderer = false;
    public static bool hyperrendererworldstrtart = true;

    [MenuItem("Window/Rendering/HyperRender")]
    public static void ShowWindow()
    {
        GetWindow<EditorHyperRenderer>("render");
    }

    private void OnGUI()
    {

        if (GUILayout.Button("addlicense"))
        {
            File.WriteAllText("unauticna.license", Resources.Load<license>("delux/license").code + Resources.Load<license>("delux/license").version);
        }
        if (EditorGUILayout.LinkButton("HyperRenderStart"))
        {

            for (int i = 0; i < GameObject.FindObjectsOfType<World>().Length; i++)
            {
                if (GameObject.FindObjectsOfType<World>().Length != 0)
                {




                    GameObject.FindObjectsOfType<World>()[i].editorcamera = SceneView.lastActiveSceneView.camera.transform;

                    GameObject.FindObjectsOfType<World>()[i].editorhrst();
                }

            }
        }
        if (EditorGUILayout.LinkButton("HyperRenderUpdate"))
        {

            for (int i = 0; i < GameObject.FindObjectsOfType<World>().Length; i++)
            {
                if (GameObject.FindObjectsOfType<World>().Length != 0)
                {




                    GameObject.FindObjectsOfType<World>()[i].editorcamera = SceneView.lastActiveSceneView.camera.transform;

                    GameObject.FindObjectsOfType<World>()[i].editorhrup();
                }

            }
        }

    }












    }
/*using System.Collections;
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
            for (int i = 0; i < GameObject.FindObjectsOfType<LevelsDetermination>().Length; i++)
            {

                if (GameObject.FindObjectsOfType<LevelsDetermination>().Length != 0)
                {



                    LevelsDetermination.Stoprenderdetermination(GameObject.FindObjectsOfType<LevelsDetermination>()[i]);


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
            for (int i = 0; i < GameObject.FindObjectsOfType<LevelsDetermination>().Length; i++)
            {

                if (GameObject.FindObjectsOfType<LevelsDetermination>().Length != 0)
                {



                    LevelsDetermination.renderdetermination(GameObject.FindObjectsOfType<LevelsDetermination>()[i]);


                }

            }

        }


    }
        

        
        







}*/