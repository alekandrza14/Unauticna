using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonSystemGameSettings : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Slider slider;
    [SerializeField] string Varible;
    [SerializeField] float min,max;
    
    void Start()
    {
        slider.value = VarSave.GetFloat(Varible+"_gameSettings",SaveType.global);
        float vaule = slider.value * (max);
        if (vaule < min) vaule = min;
        text.text = Varible + " / " + (int)(vaule);
    }
    public void OnCharge()
    {

        float vaule = slider.value * (max);
        if (vaule < min) vaule = min;
        text.text = Varible + " / " + (int)(vaule);
        VarSave.SetFloat(Varible + "_gameSettings", slider.value, SaveType.global);
    }
}
