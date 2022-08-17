using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(tringle))]
public class ED3 : EditorWindow
{
    static public int v1; static public int v2; static public int v3;
    static public bool v11; static public bool v21; static public bool v31;
    static public bool v1s;
  static public List<int> s = new List<int>();
    public List<float> v = new List<float>();
    public List<PolarTransform> p = new List<PolarTransform>(); 
    public List<float> v6 = new List<float>();
    public List<PolarTransform> p6 = new List<PolarTransform>(); 
    public List<float> v7 = new List<float>();
    public List<PolarTransform> p7 = new List<PolarTransform>();
    static public GameObject t2; static public Object t9; static public Object t0;
    [MenuItem("Window/ed3")]
    
    static void Init()
    {
        
        // Get existing open window or if none, make a new one:
        ED3 window = (ED3)EditorWindow.GetWindow(typeof(ED3));
        window.Show();
        tringle.iseditor = true;
    }
    public void endv()
    {

    }
    
    void OnGUI()
    {
        
       
        t2 = (GameObject)EditorGUILayout.ObjectField("obj2", t2, typeof(GameObject), true);
        if (v11 = EditorGUILayout.Toggle("v1", v11))
        {
            if (v1 == 4)
            {
                v1 = 0;
            }
            v1 += 1;
            
        }
        if (v21 = EditorGUILayout.Toggle("v2", v21))
        {
            if (v2 == 4)
            {
                v2 = 0;
            }
            v2 += 1;
            
        }
        if (v31 = EditorGUILayout.Toggle("v3", v31))
        {
            if (v3 == 4)
            {
                v3 = 0;
            }
            v3 += 1;
            
        }

        if (v11||v21||v31)
        {


            if (v1 == 1)
            {
                v.Add(ED.mp1.GetComponent<tringle>().v1); 
                s.Add(1);
                p.Add(ED.mp1.GetComponent<tringle>().p2);
                ED.mp1.GetComponent<tringle>().v1 = t2.GetComponent<tringle>().v1;
                ED.mp1.GetComponent<tringle>().p2 = t2.GetComponent<tringle>().p2;
                

            }
            if (v2 == 1)
            {
                v6.Add(ED.mp1.GetComponent<tringle>().v2);
                s.Add(2);
                p6.Add(ED.mp1.GetComponent<tringle>().p3);
                ED.mp1.GetComponent<tringle>().v2 = t2.GetComponent<tringle>().v2;
                ED.mp1.GetComponent<tringle>().p3 = t2.GetComponent<tringle>().p3;
                
            }
            if (v3 == 1)
            {
                v7.Add(ED.mp1.GetComponent<tringle>().v3);
                s.Add(3);
                p7.Add(ED.mp1.GetComponent<tringle>().p4);
                ED.mp1.GetComponent<tringle>().v3 = t2.GetComponent<tringle>().v3;
                ED.mp1.GetComponent<tringle>().p4 = t2.GetComponent<tringle>().p4;
                
            }
            if (v1 == 2)
            {
                s.Add(1);
                v.Add(ED.mp1.GetComponent<tringle>().v1);
                p.Add(ED.mp1.GetComponent<tringle>().p2);
                ED.mp1.GetComponent<tringle>().v1 = t2.GetComponent<tringle>().v3;
                ED.mp1.GetComponent<tringle>().p2 = t2.GetComponent<tringle>().p4;
                

            }
            if (v2 == 2)
            {
                s.Add(2);
                v6.Add(ED.mp1.GetComponent<tringle>().v2);
                p6.Add(ED.mp1.GetComponent<tringle>().p3);
                ED.mp1.GetComponent<tringle>().v2 = t2.GetComponent<tringle>().v1;
                ED.mp1.GetComponent<tringle>().p3 = t2.GetComponent<tringle>().p2;
                
            }
            if (v3 == 2)
            {
                s.Add(3);
                v7.Add(ED.mp1.GetComponent<tringle>().v3);
                p7.Add(ED.mp1.GetComponent<tringle>().p4);
                ED.mp1.GetComponent<tringle>().v3 = t2.GetComponent<tringle>().v2;
                ED.mp1.GetComponent<tringle>().p4 = t2.GetComponent<tringle>().p3;
                
            }
            if (v1 == 3)
            {
                s.Add(1);
                v.Add(ED.mp1.GetComponent<tringle>().v1);
                p.Add(ED.mp1.GetComponent<tringle>().p2);
                ED.mp1.GetComponent<tringle>().v1 = t2.GetComponent<tringle>().v2;
                ED.mp1.GetComponent<tringle>().p2 = t2.GetComponent<tringle>().p3;

                
            }
            if (v2 == 3)
            {
                s.Add(2);
                v6.Add(ED.mp1.GetComponent<tringle>().v2);
                p6.Add(ED.mp1.GetComponent<tringle>().p3);
                ED.mp1.GetComponent<tringle>().v2 = t2.GetComponent<tringle>().v3;
                ED.mp1.GetComponent<tringle>().p3 = t2.GetComponent<tringle>().p4;
                
            }
            if (v3 == 3 )
            {
                s.Add(3);
                v7.Add(ED.mp1.GetComponent<tringle>().v3);
                p7.Add(ED.mp1.GetComponent<tringle>().p4);
                ED.mp1.GetComponent<tringle>().v3 = t2.GetComponent<tringle>().v1;
                ED.mp1.GetComponent<tringle>().p4 = t2.GetComponent<tringle>().p2;
                

            }

            if (true)
            {
                v31 = false;
                v21 = false; 
                v11 = false;
            }
            
        }


            if (EditorGUILayout.Toggle("v1s", v1s) && s.Count !=0)
        {
            if (v.Count != 0 && s[s.Count - 1] ==1)
                ED.mp1.GetComponent<tringle>().v1 = v[v.Count-1];
            if (v6.Count != 0 && s[s.Count - 1] == 2)
                ED.mp1.GetComponent<tringle>().v2 = v6[v6.Count - 1];
            if (v7.Count != 0 && s[s.Count - 1] == 3)
                ED.mp1.GetComponent<tringle>().v3 = v7[v7.Count - 1];
            if (p.Count != 0 && s[s.Count - 1] == 1)
                ED.mp1.GetComponent<tringle>().p2 = p[p.Count - 1];
            if (p6.Count != 0 && s[s.Count - 1] == 2)
                ED.mp1.GetComponent<tringle>().p3 = p6[p6.Count - 1];
            if (p7.Count != 0 && s[s.Count - 1] == 3)
                ED.mp1.GetComponent<tringle>().p4 = p7[p7.Count - 1];
            if (v.Count != 0 && s[s.Count - 1] == 1)
                v.RemoveAt(v.Count - 1);
            if (v6.Count != 0 && s[s.Count - 1] == 2)
                v6.RemoveAt(v6.Count - 1);
            if (v7.Count != 0 && s[s.Count - 1] == 3)
                v7.RemoveAt(v7.Count - 1);
            if (p.Count != 0 && s[s.Count - 1] == 1)
                p.RemoveAt(p.Count - 1);
            if (p6.Count != 0 && s[s.Count - 1] == 2)
                p6.RemoveAt(p6.Count - 1);
            if (p7.Count != 0 && s[s.Count- 1] == 3)
                p7.RemoveAt(p7.Count - 1);
            if (s.Count != 0)
                s.RemoveAt(s.Count - 1);
            v1s = false;

        }
        
    }
    
}
