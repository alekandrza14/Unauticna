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
public enum GeneratorEnergyType
{
    Sunpanel,button,sigular,termo,atom,bio
}

public class GeneratorEnergy : InventoryEvent
{
    [SerializeField] itemName itemName;
    [SerializeField] Text EnergyCounter;
    string energy;
    [SerializeField] public GeneratorEnergyType get;
  public  GeneratorEnergyData energyData = new GeneratorEnergyData();
    float getMaxenergyPluss()
    {
        if (get == GeneratorEnergyType.button)
        {
            return -99;
        }
        if (get == GeneratorEnergyType.termo)
        {
            return 200;
        }
        if (get == GeneratorEnergyType.bio)
        {
            return 400;
        }
        if (get == GeneratorEnergyType.atom)
        {
            return 900;
        }
        if (get == GeneratorEnergyType.sigular)
        {
            return 9999999900;
        }
        return 0;
    }
    float getGenenergyMultyply()
    {
        if (get == GeneratorEnergyType.button)
        {
            return 0;
        }
        if (get == GeneratorEnergyType.termo)
        {
            return 2;
        }
        if (get == GeneratorEnergyType.bio)
        {
            return 0;
        }
        if (get == GeneratorEnergyType.atom)
        {
            return 0;
        }
        if (get == GeneratorEnergyType.sigular)
        {
            return 10;
        }
        return 1;
    }
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
                energyData.maxEnergy += getMaxenergyPluss();
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
        if (get == GeneratorEnergyType.button)
        {
            energyData.energy = 1;
        }
        EnergyCounter.text = "Energy : " + energyData.energy + " / " + energyData.maxEnergy;
        if (!string.IsNullOrEmpty(energy))
        {
            if (energyData.time != minutes())
            {

                if (energyData.energy < energyData.maxEnergy)
                {
                    energyData.energy -= (energyData.time - minutes())* getGenenergyMultyply();
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
