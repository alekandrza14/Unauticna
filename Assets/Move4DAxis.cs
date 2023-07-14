using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Move4DAxis : MonoBehaviour
{
    GameObject select;
   [SerializeField] GameObject[] axis;
    int curaxis = 3;

    // Update is called once per frame
    void Update()
    {
        if (select != null)
        {
            transform.position = select.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.layer != LayerMask.NameToLayer("Interface"))
                    {
                        select = hit.collider.gameObject;
                    }
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Interface"))
                    {
                        if (axis[0] == hit.collider.gameObject)
                        {
                            curaxis = 0;
                        }
                        if (axis[1] == hit.collider.gameObject)
                        {
                            curaxis = 1;
                        }
                        if (axis[2] == hit.collider.gameObject)
                        {
                            curaxis = 2;
                        }
                    }
                }

            }
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            curaxis = 3;
        }
        if (curaxis == 0)
        {
            select.transform.position += (Vector3.right * Input.GetAxis("Mouse X"));
        }
        if (curaxis == 1)
        {
            select.transform.position += (Vector3.up * Input.GetAxis("Mouse X"));
        }
        if (curaxis == 2)
        {
            select.transform.position += (Vector3.forward * Input.GetAxis("Mouse X"));
        }
    }
}
