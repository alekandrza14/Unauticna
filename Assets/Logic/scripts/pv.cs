using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pv : MonoBehaviour
{
    private void setPVector(float v1, float v2, float v3, float v4)
    {
        

            GetComponent<Camdpoint>().p2 = new PolarHyperbolic2D(v1, v2, v3);
            GetComponent<Camdpoint>().v1 = v4;
        

    }
   
}
