using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerah : MonoBehaviour
{
    public GameObject focus;
    void Update()
    {
        focus.transform.Rotate(Input.GetAxis("Vertical"), 0, 0);
        transform.Rotate(0, -Input.GetAxis("Horizontal"), 0);
    }
}
