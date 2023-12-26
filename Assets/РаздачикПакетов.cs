using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class РаздачикПакетов : MonoBehaviour
{

    [SerializeField] Transform point;
    [SerializeField] GameObject resource;
    [SerializeField] int maxtevro;
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null) if (hit.collider.gameObject == gameObject && Input.GetKeyDown(KeyCode.Mouse0))
        {


                GameObject obj = Instantiate(resource.gameObject, point.position, Quaternion.identity);

                VarSave.LoadMoney("РаздачикПакетов" + System.DateTime.Now.Day, 1);
                if (VarSave.LoadMoney("РаздачикПакетов" + System.DateTime.Now.Day, 0) > maxtevro)
                {
                    cistalenemy.dies += 2;
                }

            }
    }
}
