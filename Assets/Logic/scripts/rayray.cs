using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayray : MonoBehaviour
{
    public Camera c;
    public Quaternion q;
    public Quaternion q2;
    public Transform t;
    

    // Update is called once per frame
    void Update()
    {
        q2 = Camera.main.transform.rotation;
        t.rotation = q2;
        t.Rotate(0, 180, 0);
        c.transform.rotation = Quaternion.LerpUnclamped(t.rotation, q,0.5f);
    }
}
