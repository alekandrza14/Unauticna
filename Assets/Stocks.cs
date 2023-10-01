using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stocks : MonoBehaviour
{
    [SerializeField] string stocks;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && VarSave.GetMoney("tevro") >= (decimal)Mathf.Abs(MobileComputer.Computer().oldstockConst()) && !Globalprefs.bunkrot && timer > 0.1)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.gameObject == gameObject)
                {
                    VarSave.LoadMoney("Stocks",1);
                    VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") - (decimal)Mathf.Abs( MobileComputer.Computer().oldstockConst()));
                    timer = 0;
                }
            }

        }
    }
}
