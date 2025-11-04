using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.IO;
using WebSocketSharp;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class SocialSystem : MonoBehaviour
{
    public List<SocialTriggerArray> loadedSTA = new();
    public GameObject self;
    public InputField InputMsg;
    public InputField OutputMsg;
    public Text respectCounter;
    string[] words;
    public int respect;
    private void Start()
    {
        respect = 1;
    }
    public void Exit()
    {
        Global.PauseManager.Play();
        Destroy(gameObject);
    }
    public void KilAll()
    {
        CharacterName[] CharacterNames = FindObjectsByType<CharacterName>(sortmode.main);
        foreach (CharacterName item in CharacterNames)
        {
            item.gameObject.AddComponent<DELETE>();
        }
        SocialObject[] CharacterNames2 = FindObjectsByType<SocialObject>(sortmode.main);
        foreach (SocialObject item in CharacterNames2)
        {
            item.gameObject.AddComponent<DELETE>();
        }
    }
    public void raidUniverse()
    {
        itemName[] CharacterNames = FindObjectsByType<itemName>(sortmode.main);
        foreach (itemName item in CharacterNames)
        {
            item.gameObject.AddComponent<DELETE>();
        }
        CustomObject[] CharacterNames2 = FindObjectsByType<CustomObject>(sortmode.main);
        foreach (CustomObject item in CharacterNames2)
        {
            item.gameObject.AddComponent<DELETE>();
        }
        StandartObject[] CharacterNames3 = FindObjectsByType<StandartObject>(sortmode.main);
        foreach (StandartObject item in CharacterNames3)
        {
            item.gameObject.AddComponent<DELETE>();
        }
        telo[] CharacterNames4 = FindObjectsByType<telo>(sortmode.main);
        foreach (telo item in CharacterNames4)
        {
            item.gameObject.AddComponent<DELETE>();
        }
    }
    public void EnterText()
    {
        respectCounter.text = respect.ToString();
        OutputMsg.text = "";
        string msg = InputMsg.text.Replace(".", " ");
        msg = msg.Replace("*", "");
        msg = msg.Replace("\\", "");
        msg = msg.Replace("/", "");
        msg = msg.Replace("?", "");
        msg = msg.Replace("-", "");
        msg = msg.Replace(",", "");
        msg = msg.Replace("!", "");
        msg = msg.Replace("\'", "");
        msg = msg.Replace("\"", "");
        msg = msg.Replace("\n", "");
        msg = msg.ToLower();
        words = msg.Split(' ');
        foreach (SocialTriggerArray array in loadedSTA)
        {
            foreach (SocialTrigger trigger in array.array)
            {
                bool qn = false;
                foreach (string trig in trigger.InputText)
                {
                    foreach (string word in words)
                    {
           
                        
                        
                        foreach (string iF in trigger.IfText)
                        {
                            if (iF == word)
                            {
                                //  OutputMsg.text += "..a..";
                                qn = true;
                            }
                        }
                        if (trigger.IfText != null)
                        {
                            if (trigger.IfText.Length <= 0)
                            {
                                qn = true;
                            }
                            
                        }
                        else
                        {
                            qn = true;
                        }
                        if (qn) if (trig == word)
                            {
                                if (!string.IsNullOrEmpty(trigger.Url))
                                {
                                    string target = trigger.Url;
                                    //Use no more than one assignment when you test this code.
                                    //string target = "ftp://ftp.microsoft.com";
                                    //string target = "C:\\Program Files\\Microsoft Visual Studio\\INSTALL.HTM";
                                    try
                                    {
                                        System.Diagnostics.Process.Start(target);
                                    }
                                    catch (System.ComponentModel.Win32Exception noBrowser)
                                    {

                                        //   MessageBox.Show(noBrowser.Message);
                                    }
                                    catch (System.Exception other)
                                    {
                                        //   MessageBox.Show(other.Message);
                                    }
                                }

                                if (!string.IsNullOrEmpty(trigger.exe))
                                {
                                    hello.windowmesenge.LoadApplication(trigger.exe);
                                }
                                OutputMsg.text += trigger.OutputText;
                                Globalprefs.LoadTevroPrise(trigger.teuvroMine);
                                if (trigger.respectConst <= respect || trigger.teuvroConst <= Globalprefs.LoadTevroPrise(0))
                                {
                                    if (trigger.morph != null)
                                    {
                                        Instantiate(trigger.morph, self.transform.position, Quaternion.identity);
                                        Destroy(self);
                                    }
                                    if (!string.IsNullOrEmpty(trigger.Itemsmorph))
                                    {
                                        Instantiate(Resources.Load<GameObject>("Items/" + trigger.Itemsmorph), self.transform.position, Quaternion.identity);
                                        Destroy(self);
                                    }
                                    if (trigger.gift != null) Instantiate(trigger.gift, self.transform.position, Quaternion.identity);
                                    if (!string.IsNullOrEmpty(trigger.Itemsgift)) Instantiate(Resources.Load<GameObject>("Items/" + trigger.Itemsgift), self.transform.position, Quaternion.identity);

                                    if (trigger.PriseSlave)
                                    {
                                        if (!self.GetComponent<Slave>()) self.AddComponent<Slave>();
                                    }
                                    if (trigger.KrimBurocrat)
                                    {
                                        Directory.Delete("res", true);
                                        Directory.Delete("unsave", true);
                                        Directory.Delete("unsavet", true);
                                        Directory.Delete("world", true);
                                    }
                                   if(trigger.sex) { 
                                    if (GetComponent<itemName>())
                                    {
                                        if (File.Exists("res/UserWorckspace/socialScene/in!" + GetComponent<itemName>()._Name + ".txt"))
                                        {
                                            Globalprefs.SexObject = JsonUtility.FromJson<SocialSystemSexEncounter>(File.ReadAllText("res/UserWorckspace/socialScene/in!" + GetComponent<itemName>()._Name + ".txt")).CoAnimation;
                                            SceneManager.LoadSceneAsync("CSex");
                                        }
                                    }
                                    if (GetComponent<CustomObject>())
                                    {
                                        if (File.Exists("res/UserWorckspace/socialScene/co!" + GetComponent<CustomObject>().s + ".txt"))
                                        {
                                            Globalprefs.SexObject = JsonUtility.FromJson<SocialSystemSexEncounter>(File.ReadAllText("res/UserWorckspace/socialScene/co!" + GetComponent<CustomObject>().s + ".txt")).CoAnimation;
                                            SceneManager.LoadSceneAsync("CSex");
                                        }
                                    }
                                }
                            
                                    if (trigger.Born7)
                                    {
                                        if (self.GetComponent<Fertilness>())
                                        {
                                            Globalprefs.flowteuvro += -10;
                                            VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);
                                            Instantiate(self.GetComponent<Fertilness>().Child, self.transform.position, Quaternion.identity);
                                        }
                                        else
                                        {
                                            OutputMsg.text += " не откуда я не жешина или гермофродит";
                                        }
                                    }
                                    if (self.GetComponent<Slave>()) self.GetComponent<Slave>().slaveData = trigger.SlaveCommnad;
                                    if (self.GetComponent<Slave>()) self.GetComponent<Slave>().WorkQualityTEVRO -= trigger.teuvroMine;
                                    
                                  if(!string.IsNullOrEmpty(trigger.dataCommnad))  Invoke(trigger.dataCommnad,0);
                                }
                                else
                                {

                                    OutputMsg.text += trigger.ErrorText;
                                }
                                if (trigger.teuvroConst <= Globalprefs.LoadTevroPrise(0)) Globalprefs.LoadTevroPrise(-trigger.teuvroConst);

                                if (trigger.respectConst <= respect) respect -= trigger.respectConst;
                                Globalprefs.LoadTevroPrise(trigger.teuvroMine);
                                respect += trigger.respectMine;

                                respectCounter.text = respect.ToString();
                            }
                    
                    }
                }
            }
        }
    }
}
