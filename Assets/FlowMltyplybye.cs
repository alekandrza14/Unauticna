using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMltyplybye : MonoBehaviour
{

    [SerializeField] int Contribution;
    [SerializeField] decimal flowMltyply;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && VarSave.GetMoney("tevro") >= Contribution && Globalprefs.flowteuvro > 0 && !Globalprefs.bunkrot)
        {

            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        decimal coppy = Globalprefs.flowteuvro;
                          coppy  *= flowMltyply;
                        Globalprefs.flowteuvro = (int)coppy;
                        VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);
                        VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") - Contribution);

                    }
                }

            }
        }
    }
}
