using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Realybutton : MonoBehaviour
{
    [SerializeField] Transform point;
    [SerializeField] GameObject item;
    private void Update()
    {
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
    }
}

