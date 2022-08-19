using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Camd))]
public class ED1 : Editor
{
    const string resourceFilename = "custom-editor-uie";
    public static bool load;
    public override void OnInspectorGUI()
    {
     

        
            


    Camd mp = (Camd)target;
        if (File.Exists("Assets/player.json") &&!load)
        {
            editorsave es = new editorsave();
            es = JsonUtility.FromJson<editorsave>(File.ReadAllText("Assets/player.json"));
            mp.polarTransform = es.pos;
            load = true;
        }
        mp.move();

        for (int i = 0; i < GameObject.FindObjectsOfType<tringle>().Length; i++)
        {
            GameObject.FindObjectsOfType<tringle>()[i].up2(Camd.Main().polarTransform);
        }
        for (int i = 0; i < GameObject.FindObjectsOfType<Sphere>().Length; i++)
        {
            GameObject.FindObjectsOfType<Sphere>()[i].Update();
        }
        base.OnInspectorGUI();
    }



}
