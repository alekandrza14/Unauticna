using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorEnergyData
{
    public float energy;
    public float maxEnergy;
    public float time;
}

public class GeneratorEnergy : InventoryEvent
{
    [SerializeField] itemName itemName;
    [SerializeField] Text EnergyCounter;
    string energy;
  public  GeneratorEnergyData energyData = new GeneratorEnergyData();
    private void Start()
    {
        energy = GetComponent<itemName>().ItemData;

        if (string.IsNullOrEmpty(energy))
        {
            if (complsave.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
                energyData.time = minutes();
                energyData.energy = 0;
                energyData.maxEnergy = 100;
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

                energyData.time = minutes();
                energyData.energy = 0;
                energyData.maxEnergy = 100;
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
    float minutes()
    {
        return (DateTime.Now.Minute + (DateTime.Now.Hour * 60) + (DateTime.Now.DayOfYear * 60 * 24));
            
    }
    void Update()
    {
        EnergyCounter.text = "Energy : " + energyData.energy + " / " + energyData.maxEnergy;
        if (!string.IsNullOrEmpty(energy))
        {
            if (energyData.time != minutes())
            {

                if (energyData.energy < energyData.maxEnergy)
                {
                    energyData.energy -= energyData.time - minutes();
                    energyData.time = minutes();

                    energy = JsonUtility.ToJson(energyData);

                    GetComponent<itemName>().ItemData = energy;
                }
                if (energyData.energy > energyData.maxEnergy)
                {
                    energyData.energy = energyData.maxEnergy;
                }

            }
        }
    }
}
