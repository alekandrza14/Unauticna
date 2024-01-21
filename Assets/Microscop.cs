using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microscop : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform[] origin;
    [SerializeField] GameObject script;
    public void zoomUp(float x)
    {
        cam.orthographicSize *= x;
    }
    public void zoomDown(float x)
    {
        cam.orthographicSize /= x;
    }
    public void GetDNALog()
    {
        Ray r = new Ray(origin[0].position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(r,out hit))
        {
            if (hit.collider != null)
            {
                if(hit.collider.GetComponent<itemName>())
                {
                    GameObject sc = Instantiate(script, origin[1].position,Quaternion.identity);
                    sc.GetComponent<itemName>().ItemData = hit.collider.GetComponent<itemName>().ItemData;
                }
            }
        }
    }
    public void OnSignal()
    {
        GetDNALog();
        Debug.Log("its Work");
    }
}
