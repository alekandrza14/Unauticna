using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offBunkron : MonoBehaviour
{
    [SerializeField] bool oft;

    // Update is called once per frame
    void Update()
    {
        if (!oft)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && VarSave.GetMoney("tevro") >= 2000 && Globalprefs.bunkrot)
            {

                RaycastHit hit = MainRay.MainHit;
               
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject == gameObject)
                        {
                        VarSave.LoadMoney("tevro", 2000);
                            Globalprefs.flowteuvro -= 1;
                            VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);

                            Globalprefs.bunkrot = false;

                            VarSave.SetBool("Bunkrot", Globalprefs.bunkrot);
                        }
                    }

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && Globalprefs.OverFlowteuvro >= 1 && Globalprefs.bunkrot)
            {

                RaycastHit hit = MainRay.MainHit;
               
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject == gameObject)
                        {

                            Globalprefs.OverFlowteuvro -= 1;
                            Globalprefs.flowteuvro += 2121467510;
                            VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);

                            VarSave.SetMoney("uptevro", Globalprefs.OverFlowteuvro);
                            Globalprefs.bunkrot = false;

                            VarSave.SetBool("Bunkrot", Globalprefs.bunkrot);
                        }
                    }

               
            }
        }
    }
}
