using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


[CustomEditor(typeof(Transform))]
public class TransformViewer : Editor
{



    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();
        Vector3 ls = new Vector3();
        Quaternion q = new Quaternion();
        Vector4 v4 = new Vector4();
        Vector3 v3 = new Vector3();

        Transform mp = (Transform)target;
        

        bool Hyperblic = mp.gameObject.GetComponent<Sphere>();
        bool Hyperbliccam = mp.gameObject.GetComponent<Camd>();


        if (!Hyperblic && !Hyperbliccam)
        {
            EditorGUI.BeginChangeCheck();

            v3 = EditorGUILayout.Vector3Field("Poisition", mp.position);

            Vector3 rot = EditorGUILayout.Vector3Field("Rotatation", mp.rotation.eulerAngles);
            q = Quaternion.Euler(rot.x, rot.y, rot.z);

           ls = EditorGUILayout.Vector3Field("Scale", mp.localScale);
        }
        if (Hyperblic)
        {
            EditorGUI.BeginChangeCheck();
            Sphere hyperbolicTransform = mp.gameObject.GetComponent<Sphere>();

            Sphere ht = hyperbolicTransform;

            v4 = EditorGUILayout.Vector4Field("Hyperblic Poisition", ht.position);

            Vector3 rot = EditorGUILayout.Vector3Field("Rotatation", ht.rotation.eulerAngles);
            q = Quaternion.Euler(rot.x, rot.y, rot.z);

           ls = EditorGUILayout.Vector3Field("Scale", ht.ls);
            ht.Update();
            ht.edit();
        }

        if (Hyperbliccam)
        {
            EditorGUI.BeginChangeCheck();
            Camd hyperbolicTransform = mp.gameObject.GetComponent<Camd>();

            Camd ht = hyperbolicTransform;

            v4 = EditorGUILayout.Vector4Field("Hyperblic Poisition", ht.position);

            Vector3 rot = EditorGUILayout.Vector3Field("Rotatation", ht.rotation.eulerAngles);
            q = Quaternion.Euler(rot.x, rot.y, rot.z);

            EditorGUILayout.Vector3Field("Scale (No Work)", Vector3.zero);
            ht.Update();

            ht.edit();
        }

        if (EditorGUI.EndChangeCheck())
        {

            Undo.RecordObject(target, "Transform");

            // base.OnInspectorGUI();
            if (!Hyperblic && !Hyperbliccam)
            {


                mp.position = v3;

                
                mp.rotation = q;

                mp.localScale = ls;
            }
            if (Hyperblic)
            {
                Sphere hyperbolicTransform = mp.gameObject.GetComponent<Sphere>();

                Sphere ht = hyperbolicTransform;

                ht.position = v4;

              
                ht.rotation = q;

                ht.ls = ls;
                ht.Update();
                ht.edit();
            }

            if (Hyperbliccam)
            {
                Camd hyperbolicTransform = mp.gameObject.GetComponent<Camd>();

                Camd ht = hyperbolicTransform;

                ht.position = v4;


                ht.rotation = q;

                EditorGUILayout.Vector3Field("Scale (No Work)", Vector3.zero);
                ht.Update();

                ht.edit();
            }

        }
        

    }


}


