using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
[ExecuteInEditMode]
public class KomplexPosition : MonoBehaviour
{
    [SerializeField] public double[] ImVector3 = new double[4];
    [SerializeField] static double[] ImVector3Global = new double[4];
    Vector3 Projection;
   
    public void HyperbolicKomplexPosition()
    {
        Projection.x = (float)(math.sin((ImVector3[0] - (ImVector3Global[0]) / math.cosh(ImVector3[1] - (ImVector3Global[1])))));
        Projection.z = (float)(math.cos((ImVector3[0] - (ImVector3Global[0]) / math.cosh(ImVector3[1] - (ImVector3Global[1])))));
        Projection.x *= (float)(ImVector3[1] - ImVector3Global[1]);
        Projection.z *= (float)(ImVector3[1] - ImVector3Global[1]);
    }
  

    // Update is called once per frame
    void Update()
    {
        HyperbolicKomplexPosition();
        ImVector3Global[0] += 1 * Time.deltaTime;
        ImVector3Global[1] += Input.GetAxisRaw("HyperHorizontal") * Time.deltaTime*0.1f;

        transform.position = Projection;
    }
}
