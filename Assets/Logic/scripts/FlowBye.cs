using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlowBye : MonoBehaviour
{
    [SerializeField] int Contribution;
    [SerializeField] float Procent = 1;
    [SerializeField] int loan;
    [SerializeField] int flow;
    [SerializeField] string realestatename;

    private void Start()
    {
        if (realestatename != "") realestatename = ((int)transform.position.x).ToString() +
            ((int)transform.position.y).ToString() +
            ((int)transform.position.z).ToString() +
            SceneManager.GetActiveScene().name +
            Globalprefs.GetIdPlanet().ToString();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && VarSave.GetMoney("tevro") >= Contribution && !Globalprefs.bunkrot && realestatename != "" && !VarSave.ExistenceVar("re/" + realestatename))
        {
            Directory.CreateDirectory("unsave/var/re");

            RaycastHit hit = MainRay.MainHit;


                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        Globalprefs.flowteuvro += flow;
                        Globalprefs.flowteuvro -= (decimal)(loan * Procent);

                        VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);
                        VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") - Contribution);
                        VarSave.SetInt("re/" + realestatename, 0);
                    }
                }

           
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && VarSave.GetMoney("tevro") >= Contribution && !Globalprefs.bunkrot && realestatename == "")
        {
            RaycastHit hit = MainRay.MainHit;
           
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        Globalprefs.flowteuvro += flow;
                        Globalprefs.flowteuvro -= (decimal)(loan * Procent);
                   
                    VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);
                        VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") - Contribution);
                    }
                }

        }
        if (VarSave.GetMoney("tevro") <= -15000 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Globalprefs.bunkrot = true;
            VarSave.SetBool("Bunkrot", Globalprefs.bunkrot);
        }
    }
}
