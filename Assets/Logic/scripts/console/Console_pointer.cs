using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console_pointer : MonoBehaviour
{
    public InputField text;
    private void Start()
    {
        if (PolitDate.IsGood(politicfreedom.avtoritatian))
        {
            gameObject.SetActive(false);
            Global.PauseManager.Play();
        }
    }
}
