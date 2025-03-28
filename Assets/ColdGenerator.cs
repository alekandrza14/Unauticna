using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColdGenerator : InventoryEvent
{


    [SerializeField] itemName itemName;
    [SerializeField] Text EnergyCounter;
    [SerializeField] GameObject g;
    string energy;
    public GeneratorEnergyData energyData = new GeneratorEnergyData();
    private void Start()
    {
        energy = GetComponent<itemName>().ItemData;

        if (string.IsNullOrEmpty(energy))
        {
            if (Map_saver.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
                energyData.time = days();
                energyData.energy = 0;
                energyData.maxEnergy = 1000;
                energy = JsonUtility.ToJson(energyData);
                GetComponent<itemName>().ItemData = energy;
            }
            else
            {
                energyData = JsonUtility.FromJson<GeneratorEnergyData>(energy);
            }
        }
        else
        {
            energyData = JsonUtility.FromJson<GeneratorEnergyData>(energy);
        }

    }
    public void Load1()
    {
        if (GetComponent<itemName>())
        {

            energy = GetComponent<itemName>().ItemData;

            if (string.IsNullOrEmpty(energy))
            {

                energyData.time = days();
                energyData.energy = 0;
                energyData.maxEnergy = 1000;
                energy = JsonUtility.ToJson(energyData);
                GetComponent<itemName>().ItemData = energy;


            }
            else
            {
                energyData = JsonUtility.FromJson<GeneratorEnergyData>(energy);
            }
        }
        else
        {
            energyData = JsonUtility.FromJson<GeneratorEnergyData>(energy);
        }

    }
    float days()
    {
        return ( (DateTime.Now.DayOfYear));

    }
    public void OnSignal()
    {
        if (energyData.energy > 0)
        {
            GeneratorEnergyData ged;
            ged = energyData;
            ged.energy = (energyData.energy - 12);

            itemName.ItemData = JsonUtility.ToJson(ged);

            Instantiate(g, transform.position, transform.rotation);


        }
    }
    void Update()
    {
        EnergyCounter.text = "Energy : " + energyData.energy + " / " + energyData.maxEnergy;
        if (!string.IsNullOrEmpty(energy))
        {
            if (energyData.energy > 1)
            {
            }
            if (energyData.energy > energyData.maxEnergy)
            {
                energyData.energy = energyData.maxEnergy;
            }
            if (energyData.time != days())
            {

                if (energyData.energy > 1)
                {
                    energyData.energy += energyData.time - days();
                    energyData.time = days();

                    energy = JsonUtility.ToJson(energyData);

                    GetComponent<itemName>().ItemData = energy;

                }
            }
        }
    }
}
