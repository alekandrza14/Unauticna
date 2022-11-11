using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(sity))]
class ED4 : Editor
{


   
    private void OnSceneGUI()
    {
        for (int i = 0; i < GameObject.FindObjectsOfType<sity>().Length; i++)
        {
            GameObject.FindObjectsOfType<sity>()[i].EditorUpdate(SceneView.lastActiveSceneView.camera.transform.position);
        }

    }



}


