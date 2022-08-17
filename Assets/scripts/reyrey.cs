using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reyrey : MonoBehaviour
{
    public Camera cam;
    public Vector3 camv3;
    public float s1;

    // Start is called before the first frame update
    void Start()
    {
        camv3 = cam.transform.position; 
        s1 = cam.transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.rotation.y >= 0)
        {
            cam.lensShift = new Vector2(-Camera.main.transform.rotation.y + transform.rotation.y, -Camera.main.transform.rotation.x + transform.rotation.x) * Vector3.Distance(Camera.main.transform.position, transform.position);
            cam.transform.position = new Vector3(Camera.main.transform.rotation.y + transform.rotation.y, Camera.main.transform.rotation.x + transform.rotation.x) * Vector3.Distance(Camera.main.transform.position, transform.position) * 2.5f;
            cam.transform.position += new Vector3(camv3.x - 1.5f, camv3.y, camv3.z);
        }
        if (Camera.main.transform.rotation.w < 0)
        {
            cam.lensShift = new Vector2(Camera.main.transform.rotation.y + transform.rotation.y, Camera.main.transform.rotation.x + transform.rotation.x) * Vector3.Distance(Camera.main.transform.position, transform.position);
            cam.transform.position = -new Vector3(Camera.main.transform.rotation.y + transform.rotation.y, Camera.main.transform.rotation.x + transform.rotation.x) * Vector3.Distance(Camera.main.transform.position, transform.position) * 2.5f;
            cam.transform.position += new Vector3(camv3.x + 1.5f, camv3.y, camv3.z);
        }
    }
}
