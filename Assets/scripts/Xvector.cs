using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xvector : MonoBehaviour
{
    public MeshRenderer mr;float i = 0;
    public void Update()
    {
        i+=Time.deltaTime;
        mr.material.SetFloat("_XVector",i);
    }
}
