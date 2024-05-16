using System;
using System.Collections.Generic;
using UnityEngine;

public class RincarnationButton : MonoBehaviour
{
    public string CreachureName;
    public void CreachureNewBoth()
    {
        int index = 0;

        for (int i2 = 0; i2 < SpawnRinkarnation.t5.Length; i2++)
        {
            if (SpawnRinkarnation.t5[i2].name == CreachureName)
            {
                index = i2; break;
            }
        }
        if (VarSave.GetFloat(
          "reynkarnatcia" + "_gameSettings", SaveType.global) >= .5f)
        {
            useeffect effect = new useeffect("KsenoMorfin", float.PositiveInfinity);
           
            if (VarSave.ExistenceVar("DNA"))
            {
                PlayerDNA dna = JsonUtility.FromJson<PlayerDNA>(VarSave.GetString("DNA"));

              

                for (int i = 0; i < 3; i++)
                {
                   
                      
                       
                    
                    if (i == 0) if (CreachureName != "Nravix" &&
                            CreachureName != "Player" &&
                            CreachureName != "Null" &&
                            CreachureName != "")
                        {
                            dna.bakeeffects = new List<useeffect>() { effect };
                            VarSave.SetInt("CurrentMorf", index);



                        }
                   else if (CreachureName == "Nravix" ||
                        CreachureName == "Player" ||
                        CreachureName == "Null" ||
                        CreachureName == "")
                        {

                            dna.bakeeffects = new List<useeffect>() { };

                           

                        }
                    if (i == 1) VarSave.SetString("DNA", JsonUtility.ToJson(dna));
                    if (i == 2) GameManager.loadoutReincarnation();

                }
            }
            else
            {
                PlayerDNA dna = new PlayerDNA();
                dna.metabolism = 1;
                VarSave.SetString("DNA", JsonUtility.ToJson(new PlayerDNA()));
            }
        }
    }
}
