using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Interface
{
    public Vector2[] imagepos = new Vector2[] { new Vector2(0, 0) };
    public Vector2[] imagewh = new Vector2[] { new Vector2(100, 100) };
    public Vector4[] actors = new Vector4[] { new Vector4(1, 1, 1, 1) };
    public string[] texture = new string[] { "image\\customJuice.png" };
    public Vector2[] buttonpos = new Vector2[] {};
    public Vector2[] buttonwh = new Vector2[] {};
    public Vector4[] buttonactors = new Vector4[] {};
    public string[] buttontexture = new string[] {};
    public Vector4[] buttonPosSpawn = new Vector4[] {};
    public string[] buttonNameSpawn = new string[] {};
}

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
    public InputField Interface;
    public string fullUserName;
    public string Private;
    public bool PrivateOn;
    public int currenPage;
    public Texture tex2;
    public void loadInterface()
    {
        Spawn(Interface.text);
        VarSave.SetString("interface",Interface.text);
    }

    public static void Spawn(string text)
    {
        Interface InterfaceFile = new Interface();
        GameObject canvas = Instantiate(Resources.Load<GameObject>("DefaultCanvas"));
        if (File.Exists("res/UserWorckspace/Iterface/" + text + ".json"))
        {
            InterfaceFile = JsonUtility.FromJson<Interface>(File.ReadAllText("res/UserWorckspace/Iterface/" + text + ".json"));
            for (int i = 0; i < InterfaceFile.imagepos.Length; i++)
            {
                GameObject obj = Instantiate(Resources.Load<GameObject>("DefaultImage"), canvas.transform);
                obj.GetComponent<RawImage>().rectTransform.anchoredPosition = InterfaceFile.imagepos[i];
                obj.GetComponent<RawImage>().rectTransform.sizeDelta = InterfaceFile.imagewh[i];
                obj.GetComponent<RawImage>().rectTransform.anchorMin = new Vector2(InterfaceFile.actors[i].x, InterfaceFile.actors[i].y);
                obj.GetComponent<RawImage>().rectTransform.anchorMax = new Vector2(InterfaceFile.actors[i].z, InterfaceFile.actors[i].w);
                new GameObject().AddComponent<ChildNode>().StartCoroutine(DnSpyFunctionalEasyActivator.GetTextResFolder(InterfaceFile.texture[i], obj.GetComponent<RawImage>()));
            }
            for (int i = 0; i < InterfaceFile.buttonpos.Length; i++)
            {
                GameObject obj = Instantiate(Resources.Load<GameObject>("DefaultButton"), canvas.transform);
                obj.GetComponent<RawImage>().rectTransform.anchoredPosition = InterfaceFile.buttonpos[i];
                obj.GetComponent<RawImage>().rectTransform.sizeDelta = InterfaceFile.buttonwh[i];
                obj.GetComponent<RawImage>().rectTransform.anchorMin = new Vector2(InterfaceFile.buttonactors[i].x, InterfaceFile.buttonactors[i].y);
                obj.GetComponent<RawImage>().rectTransform.anchorMax = new Vector2(InterfaceFile.buttonactors[i].z, InterfaceFile.buttonactors[i].w);
                obj.GetComponent<SpawnButton>().resobj = InterfaceFile.buttonNameSpawn[i];
                obj.GetComponent<SpawnButton>().pos = new Vector3(InterfaceFile.buttonPosSpawn[i].x, InterfaceFile.buttonPosSpawn[i].y, InterfaceFile.buttonPosSpawn[i].z);
                obj.GetComponent<SpawnButton>().off = (offsetpos)((int)InterfaceFile.buttonPosSpawn[i].w);
                new GameObject().AddComponent<ChildNode>().StartCoroutine(DnSpyFunctionalEasyActivator.GetTextResFolder(InterfaceFile.buttontexture[i], obj.GetComponent<RawImage>()));
            }
        }
    }


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
