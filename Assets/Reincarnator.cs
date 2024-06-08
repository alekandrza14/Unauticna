using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reincarnator : MonoBehaviour
{
    [SerializeField] InputField ifd;
    public void reincornition()
    {
        if (VarSave.GetFloat(
          "reynkarnatcia" + "_gameSettings", SaveType.global) >= .2f)
        {
          useeffect effect = new useeffect("KsenoMorfin", float.PositiveInfinity);
            int index = 0;
            for (int i = 0; i < Map_saver.t5.Length; i++)
            {
                if (Map_saver.t5[i].name == ifd.text)
                {
                    index = i; break;
                }
            }
            PlayerDNA dna = mover.main().DNA; for (int i = 0; i < 2; i++)
            {
              if(i==0)  if (ifd.text != "Nravix" &&
                ifd.text != "Player" &&
                ifd.text != "Null" &&
                ifd.text != "" &&
                ifd.text != null)
                {
                    VarSave.SetInt("CurrentMorf", index);

                    if (playerdata.Geteffect("KsenoMorfin", dna.bakeeffects) == null)
                    {
                        if (dna.bakeeffects != null)
                            dna.bakeeffects.Add(effect);
                        if (dna.bakeeffects == null)
                        {
                            dna.bakeeffects = new List<useeffect>() { effect };

                        }
                    }
                }
                if (i == 1) if (ifd.text == "Nravix" ||
                    ifd.text == "Player" ||
                    ifd.text == "Null" ||
                    ifd.text == "" ||
                    ifd.text == null)
                {
                    while (playerdata.Geteffect("KsenoMorfin", dna.bakeeffects) != null)
                    {
                        dna.bakeeffects.Remove(playerdata.Geteffect("KsenoMorfin", dna.bakeeffects));
                    }
                    playerdata.hasClearEffect("KsenoMorfin");
                }
            }
            VarSave.SetString("DNA", JsonUtility.ToJson(mover.main().DNA));
            GameManager.saveandhill();
        }
    }
}
