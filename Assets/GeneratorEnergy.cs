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
    public float atomenergy;
}
public enum GeneratorEnergyType
{
    Sunpanel,button,sigular,termo,atom,bio
}

public class GeneratorEnergy : InventoryEvent
{
    [SerializeField] itemName itemName;
    [SerializeField] Text EnergyCounter;
    [SerializeField] Text AtomEnergyCounter;
    string energy;
    string AtomMaterial;
    public GeneratorEnergyType TypeGenergy;
    public  GeneratorEnergyData energyData = new();
    float Get_Maxenergy_Pluss()
    {
        if (TypeGenergy == GeneratorEnergyType.button)
        {
            return -99;
        }
        if (TypeGenergy == GeneratorEnergyType.termo)
        {
            return 200;
        }
        if (TypeGenergy == GeneratorEnergyType.bio)
        {
            return 400;
        }
        if (TypeGenergy == GeneratorEnergyType.atom)
        {
            return 50000;
        }
        if (TypeGenergy == GeneratorEnergyType.sigular)
        {
            return 9999999900;
        }
        return 0;
    }
    float Get_Genenergy_Multyply()
    {
        if (TypeGenergy == GeneratorEnergyType.button)
        {
            return 0;
        }
        if (TypeGenergy == GeneratorEnergyType.termo)
        {
            return 2;
        }
        if (TypeGenergy == GeneratorEnergyType.bio)
        {
            return 0;
        }
        if (TypeGenergy == GeneratorEnergyType.atom)
        {
            return 200;
        }
        if (TypeGenergy == GeneratorEnergyType.sigular)
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
                if (Map_saver.LoadADone)
                {
                    // time = JsonUtility.ToJson(Random.ColorHSV());
                    energyData.time = ComputeMinutes();
                    energyData.energy = 0;
                    energyData.maxEnergy = 100;
                    energyData.maxEnergy += Get_Maxenergy_Pluss();
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

                    energyData.time = ComputeMinutes();
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
    float ComputeMinutes()
    {
        return (DateTime.Now.Minute + (DateTime.Now.Hour * 60) + (DateTime.Now.DayOfYear * 60 * 24));
            
    }
    void Update()
    {
        if (TypeGenergy == GeneratorEnergyType.button)
        {
            energyData.energy = 1;
        }
        EnergyCounter.text = "Energy : " + energyData.energy + " / " + energyData.maxEnergy;
        if (AtomEnergyCounter) AtomEnergyCounter.text = energyData.atomenergy.ToString() + "%";
        if (!string.IsNullOrEmpty(energy))
        {
            if (energyData.time != ComputeMinutes())
            {

                if (energyData.energy < energyData.maxEnergy)
                {
                    if (TypeGenergy != GeneratorEnergyType.atom)
                    {
                        energyData.energy -= (energyData.time - ComputeMinutes()) * Get_Genenergy_Multyply();
                    }
                    if (TypeGenergy == GeneratorEnergyType.atom)
                    {
                        if (energyData.atomenergy > 0)
                        {
                            energyData.atomenergy %= 100;
                            energyData.atomenergy += (energyData.time - ComputeMinutes()) * 1;
                            energyData.energy -= (energyData.time - ComputeMinutes()) * Get_Genenergy_Multyply(); 
                        }
                    }
                    energyData.time = ComputeMinutes();

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
