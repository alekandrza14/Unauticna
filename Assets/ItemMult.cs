using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMult : InventoryEvent
{
    [SerializeField] itemName itemName;

    [SerializeField] InputField EnergyCounter;
    string energy;
    private void Start()
    {
        energy = GetComponent<itemName>().ItemData;

        if (string.IsNullOrEmpty(energy))
        {
            if (Map_saver.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());

                energy = "0";
                GetComponent<itemName>().ItemData = energy;
            }
        }
        EnergyCounter.text = energy;
    }
    public void Load1()
    {
        if (GetComponent<itemName>())
        {

            energy = GetComponent<itemName>().ItemData;

            if (string.IsNullOrEmpty(energy))
            {

                // time = JsonUtility.ToJson(Random.ColorHSV());

                energy = "0";
                GetComponent<itemName>().ItemData = energy;


            }
        }
        EnergyCounter.text = energy;
    }
    private void Update()
    {
      if(EnergyCounter.text !="")  energy = EnergyCounter.text; else
        {
            energy = "0";
        }
      if(Map_saver.LoadADone)  GetComponent<itemName>().ItemData = energy;
    }
}
