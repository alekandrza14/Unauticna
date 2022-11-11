using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class sc : MonoBehaviour
{
    public tringle tr;
    public Sphere sp1, sp2, sp3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sp1&&sp2&&sp3)
        {


            tr.p2 = sp1.p2;
            tr.v1 = sp1.v1;
            tr.p3 = sp2.p2;
            tr.v2 = sp2.v1;
            tr.p4 = sp3.p2;
            tr.v3 = sp3.v1;

        }
    }
}
