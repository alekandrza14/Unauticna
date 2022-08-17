


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Web.UI;

[CustomEditor(typeof(Transform))]
public class generator : Editor
{
    private Transform gm;
    public Texture2D s2;
    public Texture2D s3;
    public int list;

    public void OnEnable()
    {
        gm = (Transform)target;

    }
    public override void OnInspectorGUI()
    {
        
        if (list == 0)
        {


            if (GUILayout.Button("create item"))
            {

                
                PrefabUtility.SaveAsPrefabAsset( gm.gameObject,"Assets/Resources/items/" + gm.gameObject.name + ".prefab");
            }
            



        }
        

    }
}