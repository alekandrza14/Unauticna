using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMltyplybye : MonoBehaviour
{

    [SerializeField] float Contribution;
    [SerializeField] string flowMltyply;
    [SerializeField] bool flowInvest;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Globalprefs.flowteuvro > 0 && !Globalprefs.bunkrot)
        {

            RaycastHit hit = MainRay.MainHit;
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    decimal coppy2 = Globalprefs.flowteuvro;
                    decimal coppy = Globalprefs.flowteuvro;
                    coppy *= decimal.Parse(flowMltyply);
                    if (VarSave.GetMoney("tevro") >= (((decimal)Contribution * (coppy - coppy2)) * 10m) && !flowInvest)
                    {
                        Globalprefs.flowteuvro = coppy;
                        VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);
                       VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") - (((decimal)Contribution * (coppy - coppy2)) * 10m));
                      
                    }
                    if (flowInvest)
                    {
                        Globalprefs.flowteuvro = coppy;
                        VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);
                       
                            VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") + (coppy2 / 2) * 10m);
                       
                    }

                }
            }

        }
    }
}
