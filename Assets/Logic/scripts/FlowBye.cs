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

    decimal shorta;
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && Globalprefs.LoadTevroPrise(0) >= Contribution && !Globalprefs.bunkrot && realestatename != "" && !VarSave.ExistenceVar("re/" + realestatename))
        {
            Directory.CreateDirectory("unsave/var/re");

            RaycastHit hit = MainRay.MainHit;

            if (VarSave.LoadFloat("luck", 0f) > 0.5 && UnityEngine.Random.Range(0, 7) == 0)
            {
                shorta += 1m;
            }
           
            if (VarSave.LoadFloat("luck", 0f) > 906 && UnityEngine.Random.Range(0, 1) == 0)
            {

                shorta += 1m;
            }
            if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        Globalprefs.flowteuvro += flow+shorta;
                        Globalprefs.flowteuvro -= (decimal)(loan * Procent);

                        VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);
                    Globalprefs.LoadTevroPrise(- Contribution);
                        VarSave.SetInt("re/" + realestatename, 0);
                    }
                }

           
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Globalprefs.LoadTevroPrise(0) >= Contribution && !Globalprefs.bunkrot && realestatename == "")
        {
            RaycastHit hit = MainRay.MainHit;
            if (VarSave.LoadFloat("luck", 0f) > 0.5 && UnityEngine.Random.Range(0, 7) == 0)
            {
                shorta += 1m;
            }

            if (VarSave.LoadFloat("luck", 0f) > 906 && UnityEngine.Random.Range(0, 1) == 0)
            {

                shorta += 1m;
            }
            if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        Globalprefs.flowteuvro += flow + shorta;
                        Globalprefs.flowteuvro -= (decimal)(loan * Procent);
                   
                    VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);
                    Globalprefs.LoadTevroPrise(- Contribution);
                    }
                }

        }
        if (Globalprefs.LoadTevroPrise(0) <= -15000 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Globalprefs.bunkrot = true;
            VarSave.SetBool("Bunkrot", Globalprefs.bunkrot);
        }
    }
}
