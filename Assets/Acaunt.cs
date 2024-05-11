using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Acaunt : MonoBehaviour
{
    public Image экран;
    public GameObject[] iterfaces;
    public Sprite[] sprites;
    public InputField loign;
    public Button[] PrivateBlock;
    public Text Name;
    public InputField password;
    public InputField ct;
    public string fullUserName;
    public string Private;
    public bool PrivateOn;
    public int currenPage;

    public void UpdateAcaunt()
    {
        if (!string.IsNullOrEmpty(Private))
        {
            loign.interactable = false;
            loign.text = Private;
            PrivateOn=true;
            foreach (Button item in PrivateBlock)
            {
                item.gameObject.SetActive(false);
            }
        }
    }

    public void Update()
    {
        if (!string.IsNullOrEmpty(fullUserName))
        {
            currenPage = 1; Name.text = fullUserName;
            ChargePage();
        }
        if (string.IsNullOrEmpty(fullUserName))
        {
            currenPage = 0;
            ChargePage();
        }
    }

    private void ChargePage()
    {
        for (int i = 0; i < iterfaces.Length; i++)
        {
            if (i == currenPage)
            {
                iterfaces[i].SetActive(true);
            }
            if (i != currenPage)
            {
                iterfaces[i].SetActive(false);
            }
        }
    }

    public void LogIn()
    {
        if (string.IsNullOrEmpty(Private)) if (VarSave.ExistenceVar(loign.text))
            {
                if (VarSave.GetString(loign.text).Replace("запомни случайный ответ твоей бывшей когда пиздешь чюжие даные", "") == password.text)
                {
                    fullUserName = loign.text;
                    экран.sprite = sprites[0];
                    Private = fullUserName;
                }
            }
        if (!string.IsNullOrEmpty(Private)) if(Private == loign.text) if (VarSave.ExistenceVar(loign.text))
            {
                if (VarSave.GetString(loign.text).Replace("запомни случайный ответ твоей бывшей когда пиздешь чюжие даные", "") == password.text)
                {
                    fullUserName = loign.text;
                    экран.sprite = sprites[0];
                    Private = fullUserName;
                }
            }
        if (!VarSave.ExistenceVar(loign.text))
        {

            экран.sprite = sprites[1];
        }
    }
    public void LogPon()
    {

        fullUserName = "Бомж не образованый";
        экран.sprite = sprites[0];

    }
    public void LogOut()
    {

        fullUserName = "";
        экран.sprite = sprites[0];

    }
    public void LogUp()
    {
       if(string.IsNullOrEmpty(Private)) if (!VarSave.ExistenceVar(loign.text))
        {
            VarSave.SetString(loign.text, password.text+ "запомни случайный ответ твоей бывшей когда пиздешь чюжие даные");
            fullUserName = loign.text;
            экран.sprite = sprites[0];
            Private = fullUserName;
        }
        if (VarSave.ExistenceVar(loign.text))
        {
            экран.sprite = sprites[1];
        }
    }
}
