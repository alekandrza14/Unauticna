using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taktikpoint : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray r = GameManager.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r,out hit))
            {
                transform.position = hit.point;
                if (hit.collider != null)
                {
                    if (hit.collider.GetComponent<Unit>())
                    {
                        hit.collider.GetComponent<Unit>().onSelect();
                    }
                    if (hit.collider.GetComponent<Slave>())
                    {
                        hit.collider.GetComponent<Slave>().onSelect();
                    }
                }
            }
        }
    }
}
