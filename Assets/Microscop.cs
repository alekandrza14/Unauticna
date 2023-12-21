using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microscop : MonoBehaviour
{
    [SerializeField] Camera cam;
    public void zoomUp(float x)
    {
        cam.orthographicSize *= x;
    }
    public void zoomDown(float x)
    {
        cam.orthographicSize /= x;
    }
}
