using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class EditorControler : MonoBehaviour
{
    public float f;
    public float f1; 
    public float f2;
    public float f3;
    public bool y;
    public snow[] snows;
    public Transform t;
    public Vector3 v3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t.position = transform.position;
        t.position += v3;
        for (int i =0;i<snows.Length;i++) 
        {
            snows[i].f = f;
            snows[i].f1 = f1;
            snows[i].f2 = f2;
            snows[i].f3 = f3;
            snows[i].y = y;
        }
    }
}
