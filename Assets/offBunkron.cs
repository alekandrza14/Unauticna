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
            if (Input.GetKeyDown(KeyCode.Mouse0) && VarSave.GetInt("tevro") >= 1000 && Globalprefs.bunkrot)
            {

                Ray r = musave.pprey();
                RaycastHit hit;
                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject == gameObject)
                        {

                            Globalprefs.flowteuvro -= 1;
                            VarSave.SetInt("CashFlow", Globalprefs.flowteuvro);

                            Globalprefs.bunkrot = false;

                            VarSave.SetBool("Bunkrot", Globalprefs.bunkrot);
                        }
                    }

                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && Globalprefs.OverFlowteuvro >= 1 && Globalprefs.bunkrot)
            {

                Ray r = musave.pprey();
                RaycastHit hit;
                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject == gameObject)
                        {

                            Globalprefs.OverFlowteuvro -= 1;
                            Globalprefs.flowteuvro += 2121467510;
                            VarSave.SetInt("CashFlow", Globalprefs.flowteuvro);

                            VarSave.SetInt("uptevro", Globalprefs.OverFlowteuvro);
                            Globalprefs.bunkrot = false;

                            VarSave.SetBool("Bunkrot", Globalprefs.bunkrot);
                        }
                    }

                }
            }
        }
    }
}
