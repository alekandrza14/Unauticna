using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phuisicmoneta : MonoBehaviour
{
    public float velplus;
    Vector3 vel;
    // Start is called before the first frame update
    void Start()
    {
        vel = GetComponent<BoxCollider>().size;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<BoxCollider>().size = vel  * GetComponent<Rigidbody>().linearVelocity.y * velplus;
    }
}
