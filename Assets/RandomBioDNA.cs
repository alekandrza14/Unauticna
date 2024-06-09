
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum dnaType
{
    muscules, fixbakeeffects,effects
}

public class RandomBioDNA : InventoryEvent
{

    [SerializeField] itemName itemName;
    [SerializeField] dnaType _dnaType;
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
                if (_dnaType == dnaType.muscules)
                {


                    playerDNA = new PlayerDNA();
                    if (!Global.Random.determindAll)
                    {
                        playerDNA.Jumping = Random.Range(0.005f, 10f);
                        playerDNA.hp = Random.Range(0f, 1000f);
                        playerDNA.regeneration = Random.Range(0f, 100f);
                    }
                    else
                    {
                        playerDNA.Jumping = 5;
                        playerDNA.hp = 500;
                        playerDNA.regeneration = 50;
                    }
                    DNA = JsonUtility.ToJson(playerDNA);
                    GetComponent<itemName>().ItemData = DNA;
                }
                if (_dnaType == dnaType.fixbakeeffects)
                {


                    playerDNA = new PlayerDNA();
                    playerDNA.bakeeffects = mover.main().DNA.bakeeffects;
                    if (playerDNA.bakeeffects.Count > 0) playerDNA.bakeeffects.RemoveAt(Random.Range(0, playerDNA.bakeeffects.Count));
                    DNA = JsonUtility.ToJson(playerDNA);
                    GetComponent<itemName>().ItemData = DNA;
                }
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
                if (_dnaType == dnaType.muscules)
                {


                    playerDNA = new PlayerDNA(); 
                    if (!Global.Random.determindAll)
                    {
                        playerDNA.Jumping = Random.Range(0.005f, 10f);
                        playerDNA.hp = Random.Range(0f, 1000f);
                        playerDNA.regeneration = Random.Range(0f, 100f);
                    }
                    else
                    {
                        playerDNA.Jumping = 5;
                        playerDNA.hp = 500;
                        playerDNA.regeneration = 50;
                    }
                    DNA = JsonUtility.ToJson(playerDNA);
                    GetComponent<itemName>().ItemData = DNA;
                }
                if (_dnaType == dnaType.fixbakeeffects)
                {


                    playerDNA = new PlayerDNA();
                    playerDNA.bakeeffects = mover.main().DNA.bakeeffects;
                  if(playerDNA.bakeeffects.Count > 0)  playerDNA.bakeeffects.RemoveAt(Random.Range(0, playerDNA.bakeeffects.Count));
                    DNA = JsonUtility.ToJson(playerDNA);
                    GetComponent<itemName>().ItemData = DNA;
                }
            }


        }
    }

}
