using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class РаздачикДенег : MonoBehaviour
{

    [SerializeField] int maxtevro;
    [SerializeField] bool crack;
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null) if (hit.collider.gameObject == gameObject && Input.GetKeyDown(KeyCode.Mouse0))
        {
                if (crack)
                {
                    Globalprefs.LoadTevroPrise(1000);
                }
                if (!crack)
                {
                    Globalprefs.LoadTevroPrise(1);
                    VarSave.LoadMoney("РаздачикДенег" + System.DateTime.Now.Day, 1);
                    if (VarSave.LoadMoney("РаздачикДенег" + System.DateTime.Now.Day, 0) > maxtevro)
                    {
                        cistalenemy.dies += 2;
                    }
                }

            }
    }
}
