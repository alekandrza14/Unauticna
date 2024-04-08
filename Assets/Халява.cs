using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Халява : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
        {
            if (hit.collider.gameObject == gameObject && Input.GetKeyDown(KeyCode.Mouse0))
            {

                Globalprefs.LoadTevroPrise(1000000);


            }
        }
    }
}
