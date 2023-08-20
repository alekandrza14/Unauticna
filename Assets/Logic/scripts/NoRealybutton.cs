using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRealybutton : MonoBehaviour
{
    [SerializeField] GameObject monitor;
    [SerializeField] GameObject monitor2;
    public void MONITOR2()
    {
        monitor2.SetActive(!monitor2.activeSelf);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           
            RaycastHit hit = MainRay.MainHit;
           
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        monitor.SetActive(!monitor.activeSelf);
                    }
                }

            
        }
    }
}

