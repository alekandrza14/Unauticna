using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duper : MonoBehaviour
{
    [SerializeField] Transform point;
    [SerializeField] bool delete;
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
            if (hit.collider.gameObject == gameObject && Input.GetKeyDown(KeyCode.E))
            {
                Ray updown = new Ray(point.position, -point.up);
                RaycastHit hitupdown;
                if (Physics.Raycast(updown, out hitupdown))
                {
                    if (!delete)
                    {
                        GameObject obj = Instantiate(hitupdown.collider.gameObject, point.position, Quaternion.identity);
                        obj.name = obj.name.Remove(obj.name.Length - 7);
                    }
                    if (delete)
                    {
                      if(hitupdown.collider.gameObject != gameObject)  Destroy(hitupdown.collider.gameObject);
                    }
                }
            }
    }
}
