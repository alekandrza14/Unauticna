using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[System.Serializable]
public class transform4d 
{
   public Vector4 posistion;
    public Quaternion i, w; public Quaternion i2, w2,w3;
    public Vector4 scale;
    public Transform t;
    public Vector3 localposition()
    {
        Vector3 pos = new Vector4(posistion.x, posistion.y, posistion.z);
        return pos;
    }
    public Quaternion RotateIW(Vector3 rot, Vector3 rot2)
    {
        GameObject.FindObjectsOfType<Enginemanager>()[0].transform.rotation = i;
        GameObject.FindObjectsOfType<Enginemanager>()[0].transform.Rotate(rot);
        i = GameObject.FindObjectsOfType<Enginemanager>()[0].transform.rotation;
        t.Rotate(rot2);
        
        return i;

    }
    
}


public class Uxill_Engine
{
   static public RenderTexture[] d3s;
   static public RenderTexture[] rt;
   static public Vector4[] v4;
   static public List<float> p4 = new List<float>();
   static public List<float> p42 = new List<float>();
   static public List<float> s4 = new List<float>();
   static public List<Vector4> p3d = new List<Vector4>();
   static public List<Vector3> sc = new List<Vector3>();
   
   static public List<Quaternion> camera3d = new List<Quaternion>();
   static public Quaternion camera4d;
   
   static public int speed;
   static public int ots = 10000;
   static public int ots2 = 3;
   static public Vector2Int size = new Vector2Int(200,200);
   static public List<GameObject> pref4d8 = new List<GameObject>();
   static public List<GameObject> pref4d18 = new List<GameObject>();
   static public List<GameObject> pref4d28 = new List<GameObject>();
    static public List<GameObject> pref4d38 = new List<GameObject>(); 
    static public List<GameObject> load = new List<GameObject>();
    static float tic = 0;
    static bool loadend = true;

    static public RenderTextureDescriptor s;
    static public WorldSave1 ws = new WorldSave1();
    static public void kill() 
    {
        for (int i = 0; i < GameObject.FindObjectsOfType<Cube>().Length; i++)
        {
            GameObject.FindObjectsOfType<Cube>()[i].gameObject.AddComponent<DELETE>();
        }
        pref4d8 = new List<GameObject>();
        pref4d18 = new List<GameObject>();
        pref4d28 = new List<GameObject>();
        pref4d38 = new List<GameObject>();
         d3s = new RenderTexture[0]; 
         rt = new RenderTexture[0];
         v4 = new Vector4[0];
         p4 = new List<float>();
        p42 = new List<float>();
        s4 = new List<float>();
         p3d = new List<Vector4>();
         sc = new List<Vector3>();
        load = new List<GameObject>();
        camera3d = new List<Quaternion>();
        camera4d = new Quaternion();

    }
    static public void Load(transform4d transform, GameObject[] gs,bool isstart)
    {
        pref4d38.Add(GameManager.GetPlayer().gameObject);
        if (Input.GetKeyDown(KeyCode.F2) && File.Exists(WorldData.path + SceneManager.GetActiveScene().buildIndex +"/worlddata.wd") && !isstart)
        {


            load = new List<GameObject>();
            
            Enginemanager e = GameObject.FindObjectsOfType<Enginemanager>()[0];
            ws = new WorldSave1();
            ws = JsonUtility.FromJson<WorldSave1>(File.ReadAllText(WorldData.path + SceneManager.GetActiveScene().buildIndex + "/worlddata.wd"));
            transform.posistion = ws.pv4;
            
            Transform4DSetRotation(transform, ws.w, ws.i);
            for (int i = 0; i < GameObject.FindObjectsOfType<Cube>().Length; i++)
            {
                if (GameObject.FindObjectsOfType<Cube>().Length != 0)
                {


                    GameObject.FindObjectsOfType<Cube>()[i].gameObject.AddComponent<DELETE>();
                }
            }
            for (int i = 0; i < GameObject.FindObjectsOfType<Position4>().Length; i++)
            {
                if (GameObject.FindObjectsOfType<Position4>().Length != 0)
                {
                    GameObject.FindObjectsOfType<Position4>()[i].gameObject.AddComponent<DELETE>();
                }
            }
            for (int i = 0; i < ws.mats.Length; i++)
            {

                load.Add(e.create(gs[4], new Vector3(ws.v4[i].x, ws.v4[i].y, ws.v4[i].z), Quaternion.identity));
                load[i].GetComponent<Position4>().mat = ws.mats[i];
                load[i].GetComponent<Position4>().w = ws.v4[i].w;
                load[i].GetComponent<Position4>().transform.localScale = ws.sv3[i];
                load[i].GetComponent<Position4>().transform.rotation = ws.qs4[i];
            }
            
                kill();
            Start(transform,gs);


        }
        if (File.Exists(WorldData.path + SceneManager.GetActiveScene().buildIndex + "/worlddata.wd") && isstart)
        {
            
            loadend = false;
            load = new List<GameObject>();
            Enginemanager e = GameObject.FindObjectsOfType<Enginemanager>()[0];
            ws = new WorldSave1();
            ws = JsonUtility.FromJson<WorldSave1>(File.ReadAllText(WorldData.path + SceneManager.GetActiveScene().buildIndex + "/worlddata.wd"));

            if (ws.v4.Length != 0)
            {
                transform.posistion = ws.pv4;

                for (int i = 0; i < GameObject.FindObjectsOfType<Cube>().Length; i++)
                {
                    if (GameObject.FindObjectsOfType<Cube>().Length != 0)
                    {
                        GameObject.FindObjectsOfType<Cube>()[i].gameObject.AddComponent<DELETE>();
                    }
                }

                for (int i = 0; i < GameObject.FindObjectsOfType<Position4>().Length; i++)
                {
                    if (GameObject.FindObjectsOfType<Position4>().Length != 0)
                    {
                        GameObject.FindObjectsOfType<Position4>()[i].gameObject.AddComponent<DELETE>();
                    }
                }
                for (int i = 0; i < ws.mats.Length; i++)
                {

                    load.Add(e.create(gs[4], new Vector3(ws.v4[i].x, ws.v4[i].y, ws.v4[i].z), Quaternion.identity));
                    load[i].GetComponent<Position4>().mat = ws.mats[i];
                    load[i].GetComponent<Position4>().w = ws.v4[i].w;
                    load[i].GetComponent<Position4>().transform.localScale = ws.sv3[i];
                    load[i].GetComponent<Position4>().transform.rotation = ws.qs4[i];
                }
                
               
                loadend = true;
            }
            kill();
            Start(transform, gs);

        }


    }
    static public void Save(transform4d transform)
    {
        if (Input.GetKey(KeyCode.F1))
        {


            ws = new WorldSave1();
            ws.i = transform.i;
            ws.i2 = transform.i2;
            ws.w = transform.w; 
            ws.w2 = transform.w2;
            ws.w3 = transform.w3; 
            ws.pv4 = transform.posistion;
            ws.mats = new string[GameObject.FindObjectsOfType<Position4>().Length];
            ws.sv3 = new Vector4[GameObject.FindObjectsOfType<Position4>().Length];
            ws.v4 = new Vector4[GameObject.FindObjectsOfType<Position4>().Length];
            ws.qs4 = new Quaternion[GameObject.FindObjectsOfType<Position4>().Length];
            for (int i = 0; i < GameObject.FindObjectsOfType<Position4>().Length; i++)
            {
                Vector3 v3s = GameObject.FindObjectsOfType<Position4>()[i].transform.position;
                
                ws.v4[i] = new Vector4(v3s.x, v3s.y, v3s.z, GameObject.FindObjectsOfType<Position4>()[i].w);

                ws.mats[i] = GameObject.FindObjectsOfType<Position4>()[i].mat;
                ws.sv3[i] = GameObject.FindObjectsOfType<Position4>()[i].transform.localScale;
                ws.qs4[i] = GameObject.FindObjectsOfType<Position4>()[i].transform.rotation;



            }
            File.WriteAllText(WorldData.path+SceneManager.GetActiveScene().buildIndex+"/worlddata.wd",JsonUtility.ToJson(ws));
        }

    }
    static public void Update(transform4d transform, GameObject[] gs)
    {
        Enginemanager e = GameObject.FindObjectsOfType<Enginemanager>()[0];
        
        if (v4.Length != GameObject.FindObjectsOfType<Position4>().Length && GameObject.FindObjectsOfType<Position4>().Length != 0 &&loadend)
        {
            
            kill();
            Start(transform, gs); 
            for (int i3 = 0; i3 < p4.Count; i3++)
            {
                pref4d18[i3].transform.rotation= transform.i2;
                pref4d18[i3].transform.GetChild(0).transform.rotation = transform.w2;
                pref4d18[i3].transform.GetChild(1).transform.rotation = transform.w2;
            }
        }
        Save(transform);

    }
    static public void Start(transform4d transform, GameObject[] gs)
    {
        
        Enginemanager e = GameObject.FindObjectsOfType<Enginemanager>()[0];
        


            s = new RenderTextureDescriptor(Screen.width, Screen.height, RenderTextureFormat.ARGB32);
            p4 = new List<float>();
        s4 = new List<float>();
            p3d = new List<Vector4>();
            sc = new List<Vector3>();
            pref4d8 = new List<GameObject>();
            pref4d18 = new List<GameObject>();
            pref4d28 = new List<GameObject>();
            camera3d = new List<Quaternion>();
            Vector3 y = transform.localposition();
            Vector4 pos = transform.posistion;

            v4 = new Vector4[GameObject.FindObjectsOfType<Position4>().Length];
            Vector3 v3s2 = GameObject.FindObjectsOfType<Position4>()[0].transform.position;
            Vector4 v422 = new Vector4(v3s2.x, v3s2.y, v3s2.z, GameObject.FindObjectsOfType<Position4>()[0].w);
            p4.Add(v4[0].w = v422.w);
            for (int i = 0; i < v4.Length; i++)
            {
                Vector3 v3s = GameObject.FindObjectsOfType<Position4>()[i].transform.position;
                Vector4 v42 = new Vector4(v3s.x, v3s.y, v3s.z, GameObject.FindObjectsOfType<Position4>()[i].w);
                bool t2 = true;
                for (int i2 = 0; i2 < p4.Count; i2++)
                {


                    if (p4[i2] == v42.w)
                    {

                        t2 = false;


                    }


                }
                if (t2 == true)
                {
                    p4.Add(v4[i].w = v42.w);
                }

            }
            for (int i = 0; i < v4.Length; i++)
            {

                Vector3 v3s = GameObject.FindObjectsOfType<Position4>()[i].transform.position;
                Vector4 v42 = new Vector4(v3s.x, v3s.y, v3s.z, GameObject.FindObjectsOfType<Position4>()[i].w);


                p3d.Add(v42);
                sc.Add(GameObject.FindObjectsOfType<Position4>()[i].transform.localScale);
                s4.Add(GameObject.FindObjectsOfType<Position4>()[i].w);
                camera3d.Add(GameObject.FindObjectsOfType<Position4>()[i].transform.rotation);




            }
            d3s = new RenderTexture[p4.Count];

            for (int i = 0; i < p4.Count; i++)
            {

                d3s[i] = new RenderTexture(s);
                d3s[i].width = size.x;
                d3s[i].height = size.y;
                d3s[i].format = RenderTextureFormat.ARGB32;
                float t = ots * p4[i];
                pref4d8.Add(e.create(gs[0], new Vector3(0, 0, ots2 * p4[i]), Quaternion.identity));
                pref4d18.Add(e.create(gs[1], new Vector3(pos.x, pos.y, pos.z + t), Quaternion.identity));
                pref4d18[i].GetComponent<camera3D>().w = p4[i];
                Material m = pref4d8[i].GetComponent<MeshRenderer>().material;
                m.SetTexture("_MainTex", d3s[i]);


            }
            
            for (int i = 0; i < pref4d18.Count && pref4d38.Count != 0; i++)
            {


            pref4d18[i].GetComponentInChildren<Camera>().targetTexture = d3s[i];

            if (getwposcamera(Mathf.FloorToInt(pos.w)).w == p4[i])
                {
                    float d4s = ots * p4[i] + pos.w;

                    pref4d38[0].transform.position = new Vector3(pos.x, pos.y, pos.z);
                    pref4d38[0].transform.position += new Vector3(0, 0, d4s);
                }

            }
        
        for (int i = 0; i < p3d.Count; i++)
            {

                float t = ots * p3d[i].w;
                pref4d28.Add(e.create(gs[2], new Vector3(p3d[i].x, p3d[i].y, p3d[i].z + t), Quaternion.identity));
                pref4d28[i].transform.localScale = sc[i];
            pref4d28[i].transform.rotation = camera3d[i];
            pref4d28[i].GetComponent<MeshRenderer>().material = Resources.Load<Material>("mats/"+ GameObject.FindObjectsOfType<Position4>()[i].mat);


            }

            rt = new RenderTexture[p4.Count];
        

    }
    static public Vector3 Transform4Dforward(transform4d transform,Vector4 position)
    {
        Vector4 p = position;
        Vector3 n = new Vector3();



        Vector3 old = pref4d18[0].transform.position;





        pref4d18[0].transform.Translate(new Vector3(p.x, p.y, p.z));
        n = pref4d18[0].transform.position - old;


        transform.posistion += new Vector4(n.x, n.y, n.z, p.w);

        for (int i4 = 0; i4 < p4.Count; i4++)
        {
            if (getwposcamera(Mathf.FloorToInt(transform.posistion.w)).w == p4[i4])
            {
                float d4s = ots * p4[i4] + transform.posistion.w;

                pref4d38[0].transform.position = new Vector3(transform.posistion.x, transform.posistion.y, transform.posistion.z);
                pref4d38[0].transform.position += new Vector3(0, 0, d4s);
            }
        }
        return n;
    }
    static public camera3D getwposcamera(float w)
    {
        camera3D c3 = new camera3D();
        for (int i = 0; i < pref4d8.Count; i++)
        {




            if (pref4d18[i].GetComponent<camera3D>().w == w)
            {
                c3 = pref4d18[i].GetComponent<camera3D>();
            }
        }
        return c3;
    }
    static public void Transform4DRotate(transform4d transform,Vector3 _x_y_z, Vector3 _wx_wy_wz)
    {

        transform.RotateIW(new Vector3(0, _wx_wy_wz.y, _wx_wy_wz.z), new Vector3(_wx_wy_wz.x, 0, _wx_wy_wz.z*2));
        


        for (int i = 0; i < pref4d18.Count; i++)
        {




            pref4d18[i].transform.Rotate(new Vector3(0, _x_y_z.y, _x_y_z.z));
            pref4d18[i].transform.GetChild(0).transform.Rotate(new Vector3(_x_y_z.x, 0, _x_y_z.z));
            pref4d18[i].transform.GetChild(1).transform.Rotate(new Vector3(_x_y_z.x, 0, _x_y_z.z));
            transform.i2 = pref4d18[i].transform.rotation;
            transform.w2 = pref4d18[i].transform.GetChild(0).transform.rotation;

        }
        if (pref4d38.Count != 0 && pref4d18.Count != 0)
        {


            pref4d38[0].transform.rotation = pref4d18[0].transform.rotation;
        }
    }
    static public void Transform4DSetRotation(transform4d transform, Quaternion _x_y_z_w, Quaternion _wx_wy_wz_ww)
    {
        transform.w = _wx_wy_wz_ww;
        for (int i = 0; i < pref4d8.Count; i++)
        {




            pref4d18[i].transform.rotation = _x_y_z_w;
            pref4d18[i].transform.GetChild(0).rotation = _x_y_z_w;
            pref4d18[i].transform.GetChild(1).rotation = _x_y_z_w;

        }
    }
    static public List<float> render(transform4d transform ,RawImage window)
    {
        tic += Time.deltaTime;
        for (int i2 = 0; i2 < pref4d8.Count; i2++)
        {




            float d4s = ots * p4[i2] + transform.posistion.w;
            float d4s2 = ots2 * p4[i2] - transform.posistion.w;

            pref4d8[i2].transform.position = new Vector3(0, 0, d4s2);

            pref4d18[i2].transform.position = new Vector3(transform.posistion.x, transform.posistion.y, transform.posistion.z);
            pref4d18[i2].transform.position += new Vector3(0, 0, d4s);
            pref4d18[i2].GetComponentInChildren<Camera>().targetTexture = d3s[i2];




        }
        for (int i2 = 0; i2 < pref4d28.Count; i2++)
        {
            float d4s = ots * p3d[i2].w + transform.posistion.w;



            pref4d28[i2].transform.position = new Vector3(p3d[i2].x, p3d[i2].y, p3d[i2].z);
            pref4d28[i2].transform.position += new Vector3(0, 0, d4s);

        }
        for (int i3 = 0; i3 < p4.Count; i3++)
        {
            Material m = pref4d8[i3].GetComponent<MeshRenderer>().material;
            m.SetTexture("_MainTex", d3s[i3]);

            if (getwposcamera(Mathf.FloorToInt(transform.posistion.w)).w == p4[i3] && pref4d38.Count !=0)
            {
                Vector3 p5 = pref4d38[0].GetComponent<mover>().transform.position;
                float d4s = ots * p4[i3] + transform.posistion.w;
                transform.posistion = new Vector4(p5.x, p5.y, p5.z - d4s, transform.posistion.w);
                
            }
        }
        if (tic >= 0.1f)
        {

            window.color = new Color(0, 0, 0, 0);
            for (int i3 = 0; i3 < p4.Count; i3++)
            {




                if (getwposcamera(Mathf.FloorToInt(transform.posistion.w)).w == p4[i3])
                {

                    
                    transform.i2 = pref4d18[i3].transform.rotation;
                    transform.w2 = pref4d18[i3].transform.GetChild(0).transform.rotation;
                    Ray r = new Ray(pref4d18[i3].transform.GetChild(0).transform.position, pref4d18[i3].transform.GetChild(0).transform.forward);
                    RaycastHit hit;
                    if (Physics.Raycast(r, out hit))
                    {
                        if (Input.GetKeyDown(KeyCode.Tab))
                        {
                            float d4s = ots * p4[i3] + transform.posistion.w;
                            Position4 p = GameObject.FindObjectsOfType<Enginemanager>()[0].create(Resources.Load<GameObject>("block").gameObject, hit.point - new Vector3(0, 0, d4s), Quaternion.identity).GetComponent<Position4>();
                            p.w = Mathf.FloorToInt(transform.posistion.w);


                        }
                        

                    }
                }





            }
            tic = 0;
        }
        return p4;
    }
}
