using System;
using UnityEngine;
using UnityEngine.UI;

public class DarkStick : InventoryEvent
{


    [SerializeField] itemName itemName;
    [SerializeField] Text EnergyCounter;
    [SerializeField] GameObject dobj;
    string energy;
    public GeneratorEnergyData energyData = new();
    private void Start()
    {
        energy = GetComponent<itemName>().ItemData;

        if (string.IsNullOrEmpty(energy))
        {
            if (Map_saver.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
                energyData.time = ComputeDays();
                energyData.energy = 0;
                energyData.maxEnergy = -100;
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

                energyData.time = ComputeDays();
                energyData.energy = 0;
                energyData.maxEnergy = -100;
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
    float ComputeDays()
    {
        return ((DateTime.Now.DayOfYear));

    }
    void Update()
    {
        EnergyCounter.text = "Energy : " + energyData.energy + " / " + energyData.maxEnergy;
        if (!string.IsNullOrEmpty(energy))
        {
            if (energyData.energy < -1)
            {
                dobj.SetActive(true);
            }
            else
            {
                dobj.SetActive(false);
            }
            if (energyData.energy < energyData.maxEnergy)
            {
                energyData.energy = energyData.maxEnergy;
            }
            if (energyData.time != ComputeDays())
            {

                if (energyData.energy < -1)
                {
                    energyData.energy -= energyData.time - ComputeDays();
                    energyData.time = ComputeDays();

                    energy = JsonUtility.ToJson(energyData);

                    GetComponent<itemName>().ItemData = energy;

                }
            }
        }
    }
}
