using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


[ExecuteAlways]
public class HyperbolicTriangle : MonoBehaviour
{
    public HyperbolicTriangeRenederer tr;
    public HyperbolicPoint sp1, sp2, sp3;
    bool done;
    // Start is called before the first frame update
    void Start()
    {

    }
    void selfClear()
    {
        sp1.selfClear();
        sp2.selfClear();
        sp3.selfClear();
        Destroy(this);
    }
    // Update is called once per frame
    void Update()
    {
        if (tr != null)
        {

            if (sp1 && sp2 && sp3 && !done)
            {


                tr.p2 = sp1.HyperboilcPoistion;
                tr.v1 = sp1.v1;
                tr.p3 = sp2.HyperboilcPoistion;
                tr.v2 = sp2.v1;
                tr.p4 = sp3.HyperboilcPoistion;
                tr.v3 = sp3.v1;

                done = true;
            }
        }
        else
        {
            if (GetComponent<HyperbolicTriangeRenederer>()) tr = GetComponent<HyperbolicTriangeRenederer>();
        }
    }
}
