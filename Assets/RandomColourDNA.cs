
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
            if (Map_saver.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
                playerDNA = new PlayerDNA();
                if (!Global.Random.determindAll)
                {
                    playerDNA.colour = Random.ColorHSV();
                    playerDNA.metabolism = Random.Range(0.01f, 2f);
                }
                else
                {
                    playerDNA.colour = Color.gray;
                    playerDNA.metabolism = 1;
                }
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
                if (!Global.Random.determindAll)
                {
                    playerDNA.colour = Random.ColorHSV();
                    playerDNA.metabolism = Random.Range(0.01f, 2f);
                }
                else
                {
                    playerDNA.colour = Color.gray;
                    playerDNA.metabolism = 1;
                }
                DNA = JsonUtility.ToJson(playerDNA);
                GetComponent<itemName>().ItemData = DNA;
            }


        }
    }

}
