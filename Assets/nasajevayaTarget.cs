using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nasajevayaTarget : MonoBehaviour
{
    public GameObject target;
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (Input.GetKeyDown(KeyCode.R) && !Globalprefs.Pause && hit.collider != null)
        {
            bool o = false;
            for (int i =0;i<2;i++)
            {


                if (i == 0 && target != null) { target = null; o = !o; }
              else if (i == 1 && !o) target = hit.collider.gameObject;

            }
        }
        if (target != null)
        {
            target.transform.position = transform.position;
            target.transform.rotation = transform.rotation;

        }
    }
}
