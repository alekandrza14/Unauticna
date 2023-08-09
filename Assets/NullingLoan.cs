using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullingLoan : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && Globalprefs.flowteuvro < 0 && VarSave.GetMoney("tevro") > -15000)
        {

            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        Globalprefs.flowteuvro += 1;
                        VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);
                        VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") - 10000);
                    }
                }

            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Globalprefs.flowteuvro < 0 && VarSave.GetMoney("tevro") < -15000)
        {

            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        Globalprefs.flowteuvro = 0;
                        VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);
                        VarSave.SetMoney("tevro", 0);
                        Globalprefs.bunkrot = true;

                        VarSave.SetBool("Bunkrot", Globalprefs.bunkrot);
                    }
                }

            }
        }
    }
}
