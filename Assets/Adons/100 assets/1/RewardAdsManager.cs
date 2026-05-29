using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using UnityEngine.UI;

public class RewardAdsManager : MonoBehaviour
{
    public YandexGame sdk;
    public int coins;
    public Text coinsTxt;
    private void Start()
    {
        //VarSave.SetFloat("руб", 1000, SaveType.computer);
        //color=green>Bot Response ({theme}):</color>
        coinsTxt.text = "<color=green>" + VarSave.GetFloat("руб", SaveType.computer)+ " руб.</color>";
    }

    public void AdButton()
    {
        sdk._RewardedShow(1);
    }

    public void AdButtonCul()
    {
        VarSave.LoadFloat("руб", 15, SaveType.computer);
        coinsTxt.text = "<color=green>" + VarSave.GetFloat("руб", SaveType.computer) + " руб.</color>";
    }
}
