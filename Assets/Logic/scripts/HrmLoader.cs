using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Vector6
{
    public float x, y, z, w, h, p;
    public Vector6(float x, float y, float z, float w, float h, float p)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
        this.h = h;
        this.p = p;
    }
}

[System.Serializable]
public class HRM
{
    [SerializeField] public List<Vector4> pos = new List<Vector4>();
    [SerializeField] public List<Vector4> scale = new List<Vector4>();
    [SerializeField] public List<Vector6> rot = new List<Vector6>();
    [SerializeField] public List<Color> color = new List<Color>();
    [SerializeField] public List<Shape4D.ShapeType> shapeTypes = new List<Shape4D.ShapeType>();
    [SerializeField] public List<Shape4D.Operation> Operations = new List<Shape4D.Operation>();
    [SerializeField] public List<float> Blend = new List<float>();
    [SerializeField] public List<int> parent = new List<int>();
}

public class HrmLoader : MonoBehaviour
{
    List<GameObject> g = new List<GameObject>();
    [SerializeField] TMP_InputField ifd;
    [SerializeField] itemName u;
    string model;
    bool loaded;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public void load()
    {
        u.ItemData = ifd.text;
        foreach (GameObject obj in g)
        {
            obj.AddComponent<DELETE>();
        }
        if (File.Exists("res/"+ ifd.text+ ".hrm"))
        {
            for (int i = 0; i < FindObjectsOfType<HyperObject>().Length; i++)
            {
                FindObjectsOfType<HyperObject>()[i].gameObject.AddComponent<DELETE>();
            }
            
            HRM hrm = JsonUtility.FromJson<HRM>(File.ReadAllText("res/"+ ifd.text+ ".hrm"));
            for (int i = 0; i < hrm.color.Count; i++)
            {
                GameObject s = Instantiate(Resources.Load<GameObject>("Rm/Hyper_object"), new Vector3(hrm.pos[i].x, hrm.pos[i].y, hrm.pos[i].z), Quaternion.identity);
                g.Add(s);
                Shape4D t = s.GetComponent<Shape4D>();
                t.operation = hrm.Operations[i];
                t.GetComponent<HyperObject>().c = hrm.color[i];
                t.scaleW = hrm.scale[i].w;
                t.positionW = hrm.pos[i].w;
                t.rotationW = new Vector3(hrm.rot[i].w, hrm.rot[i].h, hrm.rot[i].p);
                t.shapeType = hrm.shapeTypes[i];
                t.smoothRadius = hrm.Blend[i];
                t.transform.localScale = new Vector3(hrm.scale[i].x, hrm.scale[i].y, hrm.scale[i].z);
                t.transform.rotation = Quaternion.Euler(new Vector3(hrm.rot[i].x, hrm.rot[i].y, hrm.rot[i].z));
                t.transform.position += transform.position;

            }
        }
    }
    private void Update()
    {
        model = u.ItemData;
        if (!string.IsNullOrEmpty(model) && !loaded)
        {
            ifd.text = model;
            load();
            loaded = true;
        }
    }
    private void OnDestroy()
    {
        foreach (GameObject obj in g)
        {
            obj.AddComponent<DELETE>();
        }
    }
    // Update is called once per frame

}
