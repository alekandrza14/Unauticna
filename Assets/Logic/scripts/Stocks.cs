using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stocks : MonoBehaviour
{
    [SerializeField] string stocks;
    [SerializeField] string NameStock="UMU";
    float timer;
   

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && Globalprefs.LoadTevroPrise(0) >= (decimal)Mathf.Abs(MobileComputer.Computer().oldstockConst()) && NameStock =="UMU" && !Globalprefs.bunkrot && timer > 0.1)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    VarSave.LoadMoney("Stocks", 1);
                    VarSave.LoadMoney("Stocks" + NameStock, 1);
                    Globalprefs.LoadTevroPrise(- (decimal)Mathf.Abs(MobileComputer.Computer().oldstockConst()));
                    timer = 0;
                }
            }

        }
        if (Input.GetKey(KeyCode.Mouse0) && Globalprefs.LoadTevroPrise(0) >= (decimal)Mathf.Abs(MobileComputer.Computer().oldstockConst1()) && NameStock == "CrinjeGame" && !Globalprefs.bunkrot && timer > 0.1)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    VarSave.LoadMoney("Stocks", 1);
                    VarSave.LoadMoney("Stocks" + NameStock, 1);
                    Globalprefs.LoadTevroPrise(- (decimal)Mathf.Abs(MobileComputer.Computer().oldstockConst1()));
                    timer = 0;
                }
            }

        }
        if (Input.GetKey(KeyCode.Mouse0) && Globalprefs.LoadTevroPrise(0) >= (decimal)Mathf.Abs(MobileComputer.Computer().oldstockConst2()) && NameStock == "DupCorporated" && !Globalprefs.bunkrot && timer > 0.1)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    VarSave.LoadMoney("Stocks", 1);
                    VarSave.LoadMoney("Stocks" + NameStock, 1);
                    Globalprefs.LoadTevroPrise(- (decimal)Mathf.Abs(MobileComputer.Computer().oldstockConst2()));
                    timer = 0;
                }
            }

        }
        if (Input.GetKey(KeyCode.Mouse0) && VarSave.GetMoney("tevro") >= (decimal)Mathf.Abs(MobileComputer.Computer().oldstockConst3()) && NameStock == "Ceribrals" && !Globalprefs.bunkrot && timer > 0.1)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    VarSave.LoadMoney("Stocks", 1);
                    VarSave.LoadMoney("Stocks" + NameStock, 1);
                    Globalprefs.LoadTevroPrise(- (decimal)Mathf.Abs(MobileComputer.Computer().oldstockConst3()));
                    timer = 0;
                }
            }

        }
        if (Input.GetKey(KeyCode.Mouse0) && Globalprefs.LoadTevroPrise(0) >= (decimal)Mathf.Abs(MobileComputer.Computer().oldstockConst4()) && NameStock == "MiniHome" && !Globalprefs.bunkrot && timer > 0.1)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    VarSave.LoadMoney("Stocks", 1);
                    VarSave.LoadMoney("Stocks" + NameStock, 1);
                    Globalprefs.LoadTevroPrise(- (decimal)Mathf.Abs(MobileComputer.Computer().oldstockConst4()));
                    timer = 0;
                }
            }

        }
    }
}
