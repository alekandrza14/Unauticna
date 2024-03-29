using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class charity : MonoBehaviour
{
    [SerializeField] int Contribution = 30000;
    [SerializeField] string Deflaition = "10";
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && VarSave.GetMoney("tevro") >= Contribution && !Globalprefs.bunkrot)
        {
            Directory.CreateDirectory("unsave/var/re");

            RaycastHit hit = MainRay.MainHit;


            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    VarSave.LoadMoney("Inflation", -decimal.Parse(Deflaition), SaveType.global);
                    Globalprefs.LoadTevroPrise(- Contribution);
                }
            }


        }
    }
}
