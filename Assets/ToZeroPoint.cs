using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToZeroPoint : MonoBehaviour
{
    
    void Update()
    {
        GetComponent<Rigidbody>().linearVelocity = -transform.position;
    }
}
