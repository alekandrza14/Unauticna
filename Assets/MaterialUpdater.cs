using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialUpdater : MonoBehaviour
{
    [SerializeField] MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        if(mr==null) mr = GetComponent<MeshRenderer>();
        mr.material.color = Color.white;
    }
}
