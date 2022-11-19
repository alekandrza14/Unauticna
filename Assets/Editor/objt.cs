using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

using UnityEditor.Callbacks;
using System.IO;
using UnityEditor.Build;
using System.Diagnostics;
using UnityEngine.SceneManagement;


public class objt
{
    
}

public class ScriptBatch2 : EditorWindow
{
    GameObject[] g;
    [MenuItem("MyTools/intend scene")]
    
    public static void ShowWindow()
    {
        GetWindow<ScriptBatch2>("ya");
    }

    private void OnGUI()
    {

        if (GUILayout.Button("intend scene ya?"))
        {

            g = FindObjectsOfType<GameObject>();
            for (int i = 0; i < g.Length; i++)
            {
                if (!g[i].GetComponent<ind>())
                {


                    g[i].AddComponent<ind>().getind = i.ToString();
                }
                else
                {
                    g[i].GetComponent<ind>().getind = i.ToString();
                }
            }
        }

    }
}
