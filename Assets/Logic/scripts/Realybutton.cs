using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Realybutton : MonoBehaviour
{
    [SerializeField] Transform point;
    [SerializeField] GameObject item;
    [SerializeField] bool offOwerLoad;
    public static Realybutton instance;
    private void Update()
    {
        if (instance == null)
        {
           
            if (Input.GetKeyDown(KeyCode.E))
            {

                RaycastHit hit = MainRay.MainHit;
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        instance = this;
                    }
                }

            }
        }
        else
        {
            if (instance.gameObject == gameObject) Instantiate(item, point.transform.position, Quaternion.identity);
            if (Input.GetKeyDown(KeyCode.E))
            {

                RaycastHit hit = MainRay.MainHit;
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        instance = null;
                    }
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            RaycastHit hit = MainRay.MainHit;
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Instantiate(item, point.transform.position, Quaternion.identity);
                }
            }

        }
       if(offOwerLoad) if (Input.GetKey(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
        {

            RaycastHit hit = MainRay.MainHit;
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Instantiate(item, point.transform.position, Quaternion.identity);
                }
            }

        }
    }
    public void OnSignal()
    {
        Instantiate(item, point.transform.position, Quaternion.identity);
    }
}

