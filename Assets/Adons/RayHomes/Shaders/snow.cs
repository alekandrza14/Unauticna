using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum param
{
    i, j, k, u, y, o
}

[ExecuteAlways]
[ExecuteInEditMode]
public class snow : MonoBehaviour
{
    public Vector3 campos; 
    public Vector3 ppos;
    public Transform t;
    public mover m5;
    public Transform t2;
    Vector3 v3;
    public float f;
    public float f1;
    public float f2;
    public float f3;
    public float f4;
    public bool y;
    public MeshRenderer m;
    public param p;
    public decimal Fract(decimal value) { return value - decimal.Truncate(value); }

    public float Frac(float value)
    {
        return (float)Fract((decimal)value);
    }
    float Hash(Vector2 p)
    {
        float d = Vector2.Dot(-p, new Vector2(12.9898f, 78.233f));
        return Frac(Mathf.Sin(d) * 43758.5453123f);
    }
    
    float Noise(Vector2 p)
    {
        
        Vector2 i = new Vector2(Mathf.Floor(p.x),Mathf.Floor(p.y));
        Vector2 f = new Vector2(Frac(p.x), Frac(p.y));
        Vector2 f2;
        f2 = new Vector2(Mathf.SmoothStep(0.0f, 1.0f, f.x), Mathf.SmoothStep(0.0f, 1.0f, f.y));
        float a = Hash(i + new Vector2(0.0f, 0.0f));
        float b = Hash(i + new Vector2(0.0f, 1.0f));
        float c = Hash(i + new Vector2(1.0f, 0.0f));
        float d = Hash(i + new Vector2(1.0f, 1.0f));

        return Mathf.Lerp(Mathf.Lerp(a, c, f2.x), Mathf.Lerp(b, d, f2.x), f2.y);
    }
    

    private void Start()
    {
        
        t = gameObject.transform;
    }
    float fbn1(Vector2 p)
    {
        float v = 0.0f;
        v += Noise(p) * 0.35f;
        return v;
    }
    float t7(float a)
    {
        if (a < 0)
        {
            a *= -1;
        }
        return a;
    }

    void LateUpdate()
    {
        if (p == param.u)
        {
            Debug.DrawRay(new Vector3(t.position.x, v3.y * 3f, t.position.z), Vector3.down * 1);
            Debug.DrawRay(new Vector3(t.position.x, v3.y * 3f, t.position.z), Vector3.up * 1);
        }
        if (p == param.y)
        {
            Debug.DrawRay(new Vector3(t.position.x, v3.y * 3f, t.position.z), Vector3.down * 1);
            Debug.DrawRay(new Vector3(t.position.x, v3.y * 3f, t.position.z), Vector3.up * 1);
        }
        if (!y)
        {


            if (t.position.x < 0 && t.position.z < 0)
            {


                v3 = Vector3.up * (f3 - (fbn1(new Vector2((-t.position.z) / f, (-t.position.x) / f)) * f1)) + new Vector3(t.position.x, f2, t.position.z);

            }
            if (t.position.x > 0 && t.position.z < 0)
            {


                v3 = Vector3.up * (f3 - (fbn1(new Vector2((-t.position.z) / f, (-t.position.x) / -f)) * f1)) + new Vector3(t.position.x, f2, t.position.z);

            }
            if (t.position.x < 0 && t.position.z > 0)
            {


                v3 = Vector3.up * (f3 - (fbn1(new Vector2((-t.position.z) / -f, (-t.position.x) / f)) * f1)) + new Vector3(t.position.x, f2, t.position.z);

            }
            if (t.position.x > 0 && t.position.z > 0)
            {


                v3 = Vector3.up * (f3 - (fbn1(new Vector2((-t.position.z) / -f, (-t.position.x) / -f)) * f1)) + new Vector3(t.position.x, f2, t.position.z);

            }
        }
        if (y)
        {


            if (t.position.z < 0 && t.position.x < 0)
            {


                v3 = Vector3.up * (f3 - (fbn1(new Vector2((-t.position.x) / f, (-t.position.z) / f)) * f1)) + new Vector3(t.position.x, f2, t.position.z);

            }
            if (t.position.z > 0 && t.position.x < 0)
            {


                v3 = Vector3.up * (f3 - (fbn1(new Vector2((-t.position.x) / f, (-t.position.z) / -f)) * f1)) + new Vector3(t.position.x, f2, t.position.z);

            }
            if (t.position.z < 0 && t.position.x > 0)
            {


                v3 = Vector3.up * (f3 - (fbn1(new Vector2((-t.position.x) / -f, (-t.position.z) / f)) * f1)) + new Vector3(t.position.x, f2, t.position.z);

            }
            if (t.position.z > 0 && t.position.x > 0)
            {


                v3 = Vector3.up * (f3 - (fbn1(new Vector2((-t.position.x) / -f, (-t.position.z) / -f)) * f1)) + new Vector3(t.position.x, f2, t.position.z);

            }
        }

        /*
        if (t.position.x > 0)
        {


            v3 = Vector3.up * (f3 - (fbn1(new Vector2((t.position.x) / f, 0)) * f1)) + new Vector3(t.position.x, f2, t.position.z);
        }
        if (t.position.x < 0)
        {


            v3 = Vector3.up * (f3 - (fbn1(new Vector2((t.position.x) / -f, 0)) * f1)) + new Vector3(t.position.x, f2, t.position.z);
        }
        */


        if (p == param.i)
        {


            
            t.position = v3;
            
        }
        /*
        if (v3.x > 40 * f)
        {
            v3.y = -Mathf.Infinity;
        }
        if (v3.x < -40 * f)
        {
            v3.y = -Mathf.Infinity;
        }
        if (v3.z > 40 * f)
        {
            v3.y = -Mathf.Infinity;
        }
        if (v3.z < -40 * f)
        {
            v3.y = -Mathf.Infinity;
        }
        */
       f4 = v3.y;
        
        if (p == param.j)
        {
            m.material.color = new Color(v3.x, v3.y, v3.z, 1);
        }
        if (p == param.k || p == param.u)
        {
            m.material.color = new Color(v3.y, v3.y, v3.y, 0.2f);
        }


    }
    public void EditorUpdate( Vector3 cam)
    {
      
    }
}
