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
           
            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
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
}

