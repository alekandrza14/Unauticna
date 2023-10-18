using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum FarmType
{
    seed,gen
}

public class Farm : InventoryEvent
{
    [SerializeField] itemName itemName;

    [SerializeField] GameObject[] Objects;
    [SerializeField] FarmType type;
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
                foreach (GameObject item in Objects)
                {
                    Instantiate(item, transform.position, Quaternion.identity);
                }
              if(type == FarmType.seed)  Destroy(gameObject);
                if (type == FarmType.gen)
                {
                    time = (DateTime.Now.Hour + (DateTime.Now.DayOfYear * 24)).ToString();
                    GetComponent<itemName>().ItemData = time;
                }
            }
        }
    }
}
