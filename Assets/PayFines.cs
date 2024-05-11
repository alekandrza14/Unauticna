using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayFines : MonoBehaviour
{

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            

            RaycastHit hit = MainRay.MainHit;
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    
                    if (Globalprefs.LoadTevroPrise(0) >= 100)
                    {
                        cistalenemy.dies -= 1;
                        VarSave.SetMoney("Agr", cistalenemy.dies);
                        Globalprefs.LoadTevroPrise(-100);

                    }
                  

                }
            }

        }
    }
}
