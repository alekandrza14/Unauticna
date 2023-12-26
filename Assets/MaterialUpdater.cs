using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialUpdater : MonoBehaviour
{
    [SerializeField] MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        mr.material.color = Color.white;
    }
}
