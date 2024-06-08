using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayGun : InventoryEvent
{


    [SerializeField] itemName itemName;
    [SerializeField] Text EnergyCounter;
    string energy;
    public GeneratorEnergyData energyData = new GeneratorEnergyData();
    private void Start()
    {
        if (GetComponent<itemName>())
        {
            energy = GetComponent<itemName>().ItemData;

            if (string.IsNullOrEmpty(energy))
            {
                if (Map_saver.LoadADone)
                {
                    // time = JsonUtility.ToJson(Random.ColorHSV());

                    energyData.energy = 0;
                    energyData.maxEnergy = 1000000;
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
    }
    public void Load1()
    {
        if (GetComponent<itemName>())
        {

            energy = GetComponent<itemName>().ItemData;

            if (string.IsNullOrEmpty(energy))
            {


                energyData.energy = 0;
                energyData.maxEnergy = 1000000;
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
    public void OnSignal()
    {
        if (energyData.energy > 0)
        {
            GeneratorEnergyData ged;
            ged = energyData;
            ged.energy = (energyData.energy - 12);

            itemName.ItemData = JsonUtility.ToJson(ged);

            Instantiate(Resources.Load<GameObject>("DamageRay").gameObject, transform.position, transform.rotation);


        }
    }
    void Update()
    {

        EnergyCounter.text = "Energy : " + energyData.energy + " / " + energyData.maxEnergy;
    }
}
