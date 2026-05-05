using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerah : MonoBehaviour
{
    public GameObject focus;
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            focus.transform.Rotate(Input.GetAxis("Mouse Y"), 0, 0);
            transform.Rotate(0, -Input.GetAxis("Mouse X"), 0);
        }
    }
}
