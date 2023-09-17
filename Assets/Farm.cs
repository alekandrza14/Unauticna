using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Farm : InventoryEvent
{
   [SerializeField] itemName itemName;
   string time;
   public void Load1()
    {
        if (GetComponent<itemName>())
        {

            time =  GetComponent<itemName>().ItemData;

            if (string.IsNullOrEmpty( time))
            {
                time = (DateTime.Now.Hour + (DateTime.Now.DayOfYear * 24)).ToString();
                GetComponent<itemName>().ItemData = time;
            }


        }
    }
    void Update()
    {
        if (!string.IsNullOrEmpty(time))
        {
            if (time != (DateTime.Now.Hour + (DateTime.Now.DayOfYear * 24)).ToString())
            {
                Instantiate(Resources.Load<GameObject>("items/belock"), transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/belock"), transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
