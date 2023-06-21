using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FlowBye : MonoBehaviour
{
  [SerializeField]  int Contribution;
    [SerializeField] int loan;
    [SerializeField] int flow;
    [SerializeField] string realestatename;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && VarSave.GetInt("tevro") >= Contribution && !Globalprefs.bunkrot && realestatename != "" && !VarSave.ExistenceVar("re/" + realestatename))
        {
            Directory.CreateDirectory("unsave/var/re");
            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        Globalprefs.flowteuvro += flow;
                        Globalprefs.flowteuvro -= loan;
                        VarSave.SetInt("CashFlow", Globalprefs.flowteuvro);
                        VarSave.SetInt("tevro", VarSave.GetInt("tevro") - Contribution);
                        VarSave.SetInt("re/"+realestatename, 0);
                    }
                }

            }
        }
    }
}
