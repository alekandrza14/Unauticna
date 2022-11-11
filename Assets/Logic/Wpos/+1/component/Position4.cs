using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position4 : MonoBehaviour
{
    public float w;
    public float w2;
    public List<GameObject> gg = new List<GameObject>();
    public string mat;
    public void Start()
    {
        Destroy(GetComponent<MeshRenderer>());
    }
    public void ord(GameObject g)
    {
        gg.Add(g);
    }
    public void old()
    {
        gg.Clear();
    }
}
