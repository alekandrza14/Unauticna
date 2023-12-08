using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Move4DAxis : MonoBehaviour
{
    GameObject select;
   public static GameObject GetSelect;
    [SerializeField] GameObject[] axis;
    int curaxis = 3;

    // Update is called once per frame
    void Update()
    {
        if (select != null)
        {
            if (select.GetComponent<MultyObject>())
            {
                transform.position = select.transform.position + (new Vector3(1, 0, -1) * (select.GetComponent<MultyObject>().W_Position - mover.main().W_position));
                transform.position += (new Vector3(1, 1, 1) * (select.GetComponent<MultyObject>().H_Position - mover.main().H_position));
            }
            else transform.position = select.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            
                if (MainRay.MainHit.collider != null)
                {
                    if (MainRay.MainHit.collider.gameObject.layer != LayerMask.NameToLayer("Interface"))
                    {
                        select = MainRay.MainHit.collider.gameObject;
                    }
                }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            
                if (MainRay.MainHit.collider != null)
                {
                    if (MainRay.MainHit.collider.gameObject.layer == LayerMask.NameToLayer("Interface"))
                    {
                        if (axis[0] == MainRay.MainHit.collider.gameObject)
                        {
                            curaxis = 0;
                        }
                        if (axis[1] == MainRay.MainHit.collider.gameObject)
                        {
                            curaxis = 1;
                        }
                        if (axis[2] == MainRay.MainHit.collider.gameObject)
                        {
                            curaxis = 2;
                        }
                    if (axis[3] == MainRay.MainHit.collider.gameObject)
                    {
                        curaxis = 4;
                    }
                    if (axis[4] == MainRay.MainHit.collider.gameObject)
                    {
                        curaxis = 5;
                    }
                }
                }

            
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            curaxis = 3;
        }
        if (select && !Input.GetKey(KeyCode.LeftControl))
        {
            if (curaxis == 0)
            {
                if (select.GetComponent<MultyObject>())
                {
                    select.GetComponent<MultyObject>().startPosition.x += Input.GetAxis("Mouse X");
                }
                else
                    select.transform.position += (Vector3.right * Input.GetAxis("Mouse X"));
            }
            if (curaxis == 1)
            {
                if (select.GetComponent<MultyObject>())
                {
                    select.GetComponent<MultyObject>().startPosition.y += Input.GetAxis("Mouse X");
                }
                else
                    select.transform.position += (Vector3.up * Input.GetAxis("Mouse X"));
            }
            if (curaxis == 2)
            {
                if (select.GetComponent<MultyObject>())
                {
                    select.GetComponent<MultyObject>().startPosition.z += Input.GetAxis("Mouse X");
                }else
                    select.transform.position += (Vector3.forward * Input.GetAxis("Mouse X"));
            }
            if (curaxis == 4)
            {
                if (select.GetComponent<MultyObject>())
                    select.GetComponent<MultyObject>().W_Position += Input.GetAxis("Mouse X");
            }
            if (curaxis == 5)
            {
                if (select.GetComponent<MultyObject>())
                    select.GetComponent<MultyObject>().H_Position += Input.GetAxis("Mouse X");
            }
        }
        if (select && Input.GetKey(KeyCode.LeftControl))
        {
            if (curaxis == 1)
            {
                select.transform.localScale += (Vector3.one * (Input.GetAxis("Mouse X")));
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Destroy(select);
        }
    }
}
