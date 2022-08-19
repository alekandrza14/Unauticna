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
    public List<float> v83 = new List<float>();
    public List<PolarTransform> p81 = new List<PolarTransform>();
    public List<float> v81 = new List<float>();
    public List<PolarTransform> p82 = new List<PolarTransform>();
    public List<float> v82 = new List<float>();
    public List<PolarTransform> p83 = new List<PolarTransform>();
    public List<float> v91 = new List<float>();
    public List<PolarTransform> p91 = new List<PolarTransform>();
    public List<float> v92 = new List<float>();
    public List<PolarTransform> p92 = new List<PolarTransform>();
    public List<float> v93 = new List<float>();
    public List<PolarTransform> p93 = new List<PolarTransform>();
    public List<tringle> g8 = new List<tringle>();
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
        /*
        if (EditorGUILayout.LinkButton("generate_verticles"))
        {
            p81.Clear();
            p82.Clear();
            p83.Clear();
            p91.Clear();
            p92.Clear();
            p93.Clear();

            v81.Clear();
            v82.Clear();
            v83.Clear();
            v91.Clear();
            v92.Clear();
            v93.Clear();

            g8.Clear();
            for (int i = 0; i < FindObjectsOfType<tringle>().Length; i++)
            {
                if (!FindObjectsOfType<tringle>()[i].gameObject.GetComponent<sc>())
                {


                    p81.Add(FindObjectsOfType<tringle>()[i].p2);
                    p82.Add(FindObjectsOfType<tringle>()[i].p3);
                    p83.Add(FindObjectsOfType<tringle>()[i].p4);
                    v81.Add(FindObjectsOfType<tringle>()[i].v1);
                    v82.Add(FindObjectsOfType<tringle>()[i].v2);
                    v83.Add(FindObjectsOfType<tringle>()[i].v3);
                    g8.Add(FindObjectsOfType<tringle>()[i]);
                }
            }
            p91.Add(g8[0].p2);
            v91.Add(g8[0].v1);
            p92.Add(g8[0].p3);
            v92.Add(g8[0].v2); 
            p93.Add(g8[0].p4);
            v93.Add(g8[0].v3);
            for (int i = 0; i < p81.Count; i++)
            {

                PolarTransform v42 = g8[i].p2;
                bool t2 = true;
                for (int i2 = 0; i2 < p91.Count; i2++)
                {


                    if (p91[i2] == v42)
                    {

                        t2 = false;


                    }


                }
                if (t2 == true)
                {
                    p91.Add(p81[i] = v42);
                    v91.Add(v81[i]);
                }

            }
            for (int i = 0; i < p82.Count; i++)
            {

                PolarTransform v42 = g8[i].p3;
                bool t2 = true;
                for (int i2 = 0; i2 < p92.Count; i2++)
                {


                    if (p92[i2] == v42)
                    {

                        t2 = false;


                    }


                }
                if (t2 == true)
                {
                    p92.Add(p82[i] = v42);
                    v92.Add(v82[i]);
                }

            }
            for (int i = 0; i < p83.Count; i++)
            {

                PolarTransform v42 = g8[i].p4;
                bool t2 = true;
                for (int i2 = 0; i2 < p93.Count; i2++)
                {


                    if (p93[i2] == v42)
                    {

                        t2 = false;


                    }


                }
                if (t2 == true)
                {
                    p93.Add(p83[i] = v42);
                    v93.Add(v83[i]);
                }

            }
            bool[] t = new bool[g8.Count];
            bool[] t1 = new bool[g8.Count];
            bool[] t3 = new bool[g8.Count];
            for (int x = 0; x < g8.Count; x++)
            {
                
                if (!g8[x].gameObject.GetComponent<sc>())
                {



                    for (int i = 0; i < p91.Count && !t[x]; i++)
                    {
                        GameObject sp = Instantiate(Resources.Load<GameObject>("1/Sphere"), Resources.Load<GameObject>("1/Sphere").transform.position, Quaternion.identity);
                        sp.GetComponent<Sphere>().p2 = p91[i];
                        sp.GetComponent<Sphere>().v1 = v91[i];
                        if (g8[x].p2 == p91[i])
                        {
                            g8[x].gameObject.AddComponent<sc>();
                            g8[x].GetComponent<sc>().sp1 = sp.GetComponent<Sphere>();
                            t[x] = true;
                        }



                    }
                    for (int i = 0; i < p92.Count && !t1[x]; i++)
                    {
                        GameObject sp = Instantiate(Resources.Load<GameObject>("1/Sphere"), Resources.Load<GameObject>("1/Sphere").transform.position, Quaternion.identity);
                        sp.GetComponent<Sphere>().p2 = p92[i];
                        sp.GetComponent<Sphere>().v1 = v92[i];
                        if (g8[x].p3 == p92[i])
                        {
                            g8[x].gameObject.AddComponent<sc>();
                            g8[x].GetComponent<sc>().sp2 = sp.GetComponent<Sphere>();
                            t1[x] = true;
                        }



                    }
                    for (int i = 0; i < p93.Count && !t3[x]; i++)
                    {
                        GameObject sp = Instantiate(Resources.Load<GameObject>("1/Sphere"), Resources.Load<GameObject>("1/Sphere").transform.position, Quaternion.identity);
                        sp.GetComponent<Sphere>().p2 = p93[i];
                        sp.GetComponent<Sphere>().v1 = v93[i];
                        if (g8[x].p4 == p93[i])
                        {
                            g8[x].gameObject.AddComponent<sc>();
                            g8[x].GetComponent<sc>().sp3 = sp.GetComponent<Sphere>();
                            t3[x] = true;
                        }



                    }
                }

            }

            }*/
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
