using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class SocialSystem : MonoBehaviour
{
    public List<SocialTriggerArray> loadedSTA = new();
    public GameObject self;
    public InputField InputMsg;
    public InputField OutputMsg;
    public Text respectCounter;
    string[] words;
    public int respect; 
    public void Exit()
    {
        Global.PauseManager.Play();
        Destroy(gameObject);
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
                                if (trigger.respectConst < respect || trigger.teuvroConst < Globalprefs.LoadTevroPrise(0))
                                {
                                    if (trigger.morph != null)
                                    {
                                        Instantiate(trigger.morph, self.transform.position, Quaternion.identity);
                                        Destroy(self);
                                    }
                                    if (trigger.gift != null) Instantiate(trigger.gift, self.transform.position, Quaternion.identity);
                                    respect += trigger.respectMine;
                                    if (trigger.PriseSlave)
                                    {
                                       if(!self.GetComponent<Slave>()) self.AddComponent<Slave>();
                                    }
                                    if(self.GetComponent<Slave>())  self.GetComponent<Slave>().slaveData = trigger.SlaveCommnad;
                                    Globalprefs.LoadTevroPrise(trigger.teuvroMine);
                                }
                                else
                                {

                                    OutputMsg.text += trigger.ErrorText;
                                }
                                if (trigger.teuvroConst < Globalprefs.LoadTevroPrise(0)) Globalprefs.LoadTevroPrise(-trigger.teuvroConst);

                                if (trigger.respectConst < respect) respect -= trigger.respectConst;

                            }
                    
                    }
                }
            }
        }
        respectCounter.text = respect.ToString();
    }
}
