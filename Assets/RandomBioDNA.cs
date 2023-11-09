
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBioDNA : InventoryEvent
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
                playerDNA.Jumping = Random.Range(0.005f, 10f);
                playerDNA.hp = Random.Range(0f, 1000f);
                playerDNA.regeneration = Random.Range(0f, 100f);
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
                playerDNA.Jumping = Random.Range(0.005f, 10f);
                playerDNA.hp = Random.Range(0f, 1000f);
                playerDNA.regeneration = Random.Range(0f, 100f);
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
