using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRealybutton : MonoBehaviour
{
    [SerializeField] GameObject monitor;
    [SerializeField] GameObject monitor2;
    public void MONITOR2()
    {
        monitor2.SetActive(!monitor2.active);
    }
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
                        monitor.SetActive(!monitor.active);
                    }
                }

            }
        }
    }
}

