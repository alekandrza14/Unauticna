
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColourDNA : InventoryEvent
{

    [SerializeField] itemName itemName;

    string DNA;
    PlayerDNA playerDNA;
    private void Start()
    {
        DNA = GetComponent<itemName>().ItemData;

        if (string.IsNullOrEmpty(DNA))
        {
            if (complsave.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
                playerDNA = new PlayerDNA();
                playerDNA.colour = Random.ColorHSV();
                playerDNA.metabolism = Random.Range(0.01f, 2f);
                DNA = JsonUtility.ToJson(playerDNA);
                GetComponent<itemName>().ItemData = DNA;
            }
        }
    }
    public void Load1()
    {
        if (GetComponent<itemName>())
        {

            DNA = GetComponent<itemName>().ItemData;

            if (string.IsNullOrEmpty(DNA))
            {
               // time = JsonUtility.ToJson(Random.ColorHSV());
               playerDNA = new PlayerDNA();
                playerDNA.colour = Random.ColorHSV();
                playerDNA.metabolism = Random.Range(0.01f, 2f);
                DNA = JsonUtility.ToJson(playerDNA);
                GetComponent<itemName>().ItemData = DNA;
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}