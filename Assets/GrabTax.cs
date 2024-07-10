using UnityEngine;
using System;

public class GrabTax : MonoBehaviour
{

    
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider.gameObject == gameObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
               DateTime dateTime = DateTime.Now;
                string time = (dateTime.Year * 12).ToString() + dateTime.Month.ToString();
                if (!VarSave.ExistenceVar("TaxMonth"+time))
                {
                    VarSave.LoadMoney("TaxMonth" + time, VarSave.GetInt("pepole")*100);
                    Globalprefs.LoadTevroPrise(VarSave.GetInt("pepole") * 100);
                }
            }
        }
    }
}
