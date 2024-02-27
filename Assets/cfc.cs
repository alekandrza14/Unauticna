using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cfc : MonoBehaviour
{
    public Vector3 cursevelosity;

    void Update()
    {
        transform.position += cursevelosity;
    }
}
