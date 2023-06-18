using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowMltyplybye : MonoBehaviour
{

    [SerializeField] int Contribution;
    [SerializeField] float flowMltyply;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && VarSave.GetInt("tevro") >= Contribution && Globalprefs.flowteuvro > 0 && !Globalprefs.bunkrot)
        {

            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        float coppy = Globalprefs.flowteuvro;
                          coppy  *= flowMltyply;
                        Globalprefs.flowteuvro = (int)coppy;
                        VarSave.SetInt("CashFlow", Globalprefs.flowteuvro);
                        VarSave.SetInt("tevro", VarSave.GetInt("tevro") - Contribution);

                    }
                }

            }
        }
    }
}
