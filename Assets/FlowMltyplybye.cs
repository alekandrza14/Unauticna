using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMltyplybye : MonoBehaviour
{

    [SerializeField] int Contribution;
    [SerializeField] string flowMltyply;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && VarSave.GetMoney("tevro") >= Contribution && Globalprefs.flowteuvro > 0 && !Globalprefs.bunkrot)
        {

            RaycastHit hit = MainRay.MainHit;
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    decimal coppy = Globalprefs.flowteuvro;
                    coppy *= decimal.Parse(flowMltyply);
                    Globalprefs.flowteuvro = coppy;
                    VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);
                    VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") - Contribution);

                }
            }

        }
    }
}
