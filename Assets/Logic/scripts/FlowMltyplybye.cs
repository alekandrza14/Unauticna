using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMltyplybye : MonoBehaviour
{

    [SerializeField] float Contribution;
    [SerializeField] string flowMltyply;
    [SerializeField] bool flowInvest;
    decimal shorta;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Globalprefs.flowteuvro > 0 && !Globalprefs.bunkrot)
        {

            if (VarSave.LoadFloat("luck", 0f) > 13 && UnityEngine.Random.Range(0, 3) == 0)
            {
                shorta += (decimal)VarSave.LoadFloat("luck", 0f)/13m;
            }

            
            RaycastHit hit = MainRay.MainHit;
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    decimal coppy2 = Globalprefs.flowteuvro;
                    decimal coppy = Globalprefs.flowteuvro;
                    coppy *= decimal.Parse(flowMltyply);
                    if (Globalprefs.LoadTevroPrise(0) >= (((decimal)Contribution * (coppy - coppy2)) * 400m) && !flowInvest)
                    {
                        Globalprefs.flowteuvro = coppy * shorta;
                        VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);
                        Globalprefs.LoadTevroPrise(- (((decimal)Contribution * (coppy - coppy2)) * 400m));
                      
                    }
                    if (flowInvest)
                    {
                        Globalprefs.flowteuvro = coppy;
                        VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);

                        Globalprefs.LoadTevroPrise(+ (coppy2 / 2) * 400m * shorta);
                       
                    }

                }
            }

        }
    }
}
