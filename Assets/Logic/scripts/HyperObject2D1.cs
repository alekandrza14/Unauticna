using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class HyperObject2D1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float scaleW;
    Vector3 Pos;
    public Vector3 Pos2;
    public MeshRenderer mr;
    void Start()
    {
        Vector3 Pos1 = Vector3.zero;
        Vector3 s1 = Vector3.one;
        
        Pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = HT(Camera.main, transform);
        
    }
   

    public Vector3 HT(Camera c, Transform g)
    {
        Vector3 v3 = new Vector3(1, 1, 1);
        float size = scaleW - Vector3.Distance(c.transform.position, g.position);
        if (size >= 0f)
        {
            v3 = new Vector3(size, size, size);
        }
        if (size < 0f)
        {
            v3 = new Vector3(0, 0, 0);
        }
        if (Vector3.Distance(c.transform.position, g.position) < scaleW)
        {
            mr.enabled = true;
        }
        if (Vector3.Distance(c.transform.position, g.position) > scaleW)
        {
            mr.enabled = false;
        }
        return v3;
    }
   
   
   
}
