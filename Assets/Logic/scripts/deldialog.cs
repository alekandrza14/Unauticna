﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deldialog : MonoBehaviour
{
    public GameObject button;
    public GameObject button2;
    public string del; public string delattack;
    [Multiline(3)]
    public string[] s = new string[1];
    public string sm = "Очевидно...";
    [Multiline(3)]
    public string[] se = new string[1];
    public string sme = "yeap...";
    [Multiline(3)]
    public string[] su = new string[1];
    public string smu = "Очивитдн...";

    public TextMeshProUGUI text;
    public question qu;
    public Animator anim;
    public bool enter; public bool act;
    public float tic; public int tir; public int tir2;
    public bool stopPlayer;
    public int chargescene;
    public bool deleteing;
    public bool oneraz; public bool oneraz1;
    public bool startActivate;
    public string[] animationsnames;
    public int cur;
    public bool question;
    public string tr;

    void resset()
    {
        
    }
    void Start()
    {
       tir2 = VarSave.GetInt(del);
        if (s[0].Length ==0) {
            s[0] = text.text; 
        }
        VarSave.SetInt("delbutton" + del, 0);
        button.SetActive(false);
        text.text = "";

        if (startActivate)
        {
            button.SetActive(true);
            text.text = "";
                act = true;
                if (anim)
                {
                    anim.SetTrigger(animationsnames[cur]);
                }
            
        }
    }
    public void nabor(string sm, string[] s)
    {
        if (animationsnames.Length < cur) 
        {
            cur = 0;
        }
        if (act && enter)
        {

            tic += 1 * Time.deltaTime;
            if (tic >= 0.1f)
            {
                if (s.Length > tir2)
                {


                    if (s[tir2].Length > tir)
                    {
                        text.text += s[tir2][tir];
                        Instantiate(Resources.Load<GameObject>("dial"));
                    }
                }

                else
                {
                    if (sm.Length > 1)
                    {


                        bool rt = sm != "s2-resset()";
                        if (rt)
                        {


                            text.text += sm[tir];
                            Instantiate(Resources.Load<GameObject>("dial"));
                        }
                    }

                }

                tir += 1; if (s.Length > tir2)
                {
                    if (s[tir2].Length <= tir)
                    {
                        tir2 += 1;
                        tir = 0;

                        act = false;
                    }
                }
                else if (sm.Length <= tir)
                {
                    tir2 += 1;
                    tir = 0;

                    act = false;
                }
                else if (sm.Length <= tir && sm[0] != 's' && sm[1] != '2' && sm[2] != '-')
                {
                    tir2 += 1;
                    tir = 0;

                    act = false;
                }
                else if (sm == "s2-resset()")
                {
                    stopPlayer = false;
                    tir2 = 0;
                    tir = 0;


                }
                else if (sm == "s2-question()")
                {
                    stopPlayer = false;
                    tir2 = 0;
                    tir = 0;
                    button2.SetActive(true);
                    VarSave.SetInt(delattack, 0);
                }
                else if (sm == "s2-attack()")
                {
                    stopPlayer = false;
                    tir2 = 0;
                    tir = 0;
                    VarSave.SetBool(delattack, true);

                }
                else if (sm == "s2-BattlePlay()")
                {
                    stopPlayer = false;
                    tir2 = 0;
                    tir = 0;
                    VarSave.SetBool(delattack, true);

                    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                }
                else if (sm == "s2-charge()")
                {
                    stopPlayer = false;
                    tir2 = 0;
                    tir = 0;
                    if (deleteing == true)
                    {
                        GameObject.FindFirstObjectByType<mover>().deleteing();
                        SceneManager.LoadScene(chargescene);
                    }
                    if (deleteing == false)
                    {


                        GameManager.chargescene(chargescene);
                    }

                }
                else if (sm == "s2-charge().")
                {
                    stopPlayer = false;
                    tir2 = 0;
                    tir = 0;
                    if (deleteing == true)
                    {
                        GameObject.FindFirstObjectByType<mover>().deleteing();
                        SceneManager.LoadScene(chargescene);
                    }
                    if (deleteing == false)
                    {


                        GameManager.chargescene(chargescene);
                    }

                }
                else if (sm == "s2-chargetr()")
                {
                    stopPlayer = false;
                    tir2 = 0;
                    tir = 0;
                    if (deleteing == true)
                    {
                        GameObject.FindFirstObjectByType<mover>().deleteing();
                        VarSave.SetInt(tr, VarSave.GetInt(tr) + 1);
                        SceneManager.LoadScene(45);
                    }


                }
                else if (sm == "s2-chargedialog")
                {
                    stopPlayer = false;


                    resset();


                        tir2 = 0;
                        tir = 0;
                    


                }
                    else if (sm == "s2-chargetr().")
                {
                    stopPlayer = false;
                    tir2 = 0;
                    tir = 0;
                    if (deleteing == true)
                    {
                        GameObject.FindFirstObjectByType<mover>().deleteing();
                        VarSave.SetInt(tr, VarSave.GetInt(tr) + 1);
                        SceneManager.LoadScene(45);
                        
                    }
                    

                }
                else if (sm == "s2-attackforse()")
                {
                    stopPlayer = false;


                    VarSave.SetBool(delattack, true);

                }
                else if (sm == "s2-attackforse().")
                {
                    stopPlayer = false;


                    VarSave.SetBool(delattack, true);

                }
                else if (sm == "s2-resset().")
                {
                    stopPlayer = false;
                    tir2 = 0;
                    tir = 0;


                }
                else if (sm == "s2-attack().")
                {
                    stopPlayer = false;
                    tir2 = 0;
                    tir = 0;
                    VarSave.SetBool(delattack, true);

                }
                else if (sm == "s2-Shop()")
                {
                    stopPlayer = false;
                    Instantiate(Resources.Load<GameObject>("ui/shop/" + delattack));
                    tir2 = 0;
                    tir = 0;
                }
                else if (sm == "s2-Pram()")
                {
                    stopPlayer = false;
                    Instantiate(Resources.Load<GameObject>("ui/pram/" + delattack));
                    tir2 = 0;
                    tir = 0;
                }
                else if (sm == "s2-Stopkatscene()")
                {

                    if (deleteing == true)
                    {
                        GameObject.FindFirstObjectByType<mover>().deleteing();
                        SceneManager.LoadScene(chargescene);
                    }
                    if (deleteing == false)
                    {


                        GameManager.chargescene(chargescene);
                    }
                    tir2 = 0;
                    tir = 0;

                }
                else if (sm == "s2-Shop().")
                {
                    stopPlayer = false;
                    Instantiate(Resources.Load<GameObject>("ui/shop/" + delattack));
                    tir2 = 0;
                    tir = 0;
                }




                tic = 0;
            }
        }
    }
    
    void Update()
    {
        if (VarSave.GetString("lenguage_english")== "True")
        {
            nabor(sme,se);
        }
        if (VarSave.GetString("lenguage_english") == "False")
        {
            nabor(sm, s);
        }
        if (VarSave.GetString("lenguage_english") == "")
        {
            nabor(sm, s);
        }
        if (VarSave.GetString("lenguage_english") == "none")
        {
            nabor(smu, su);
        }
        if (!enter && !startActivate)
        {
            tir = 0;
            text.text = "";
            tic = 0;
            act = false;
        }
        if (Input.GetKeyDown(KeyCode.Tab) && enter)
        {
            text.text = "";
            act = true;
            if (VarSave.GetFloat(
               "Social" + "_gameSettings", SaveType.global) >= .1f)
            {
                VarSave.LoadFloat("reason", 1);
            }
            if (anim)
            {
                anim.SetTrigger("talke");
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && enter)
        {
            text.text = "";
            if (VarSave.GetString("lenguage_english") == "True")
            {
                act = false;
                text.text = se[tir2];
                tir = se[tir2].Length - 1;
            }
            if (VarSave.GetString("lenguage_english") == "False")
            {
                act = false;
                text.text = s[tir2];
                tir = s[tir2].Length - 1;
            }
            if (VarSave.GetString("lenguage_english") == "")
            {
                act = false;
                text.text = s[tir2];
                tir = s[tir2].Length - 1;
            }
            if (VarSave.GetString("lenguage_english") == "none")
            {
                act = false;
                text.text = su[tir2];
                tir = su[tir2].Length - 1;
            }
            tir++;
        }
        if (Input.GetKeyDown(KeyCode.Tab) && startActivate)
        {
            text.text = "";
            act = true;
            cur++;
            if (anim)
            {
                anim.SetTrigger(animationsnames[cur]);
            }
        }
        if (text.text == "event")
        {

            Instantiate(Resources.Load<GameObject>("вопрос" + delattack));
            text.text = "";
        }
        if (text.text == "event.")
        {

            Instantiate(Resources.Load<GameObject>("вопрос" + delattack));
            text.text = "";
        }
        if (VarSave.GetInt("delbutton" + del) == 1)
        {
            button.SetActive(true);
            
            
        }
        else if(!startActivate)
        {
            button.SetActive(false);
        }
        VarSave.SetInt(del ,tir2);
    }
    private void OnTriggerEnter(Collider s)
    {
        if (!oneraz1)
        {
            Debug.Log(1);
            if (s.tag == "Player")
            {
                if (s.GetComponent<mover>())
                {


                }
               
                enter = true;
                Debug.Log(1);
                VarSave.SetInt("delbutton" + del, 1);
            }
        }
    }
        private void OnTriggerExit(Collider s)
    {
        if (s.tag == "Player")
        {
            if (oneraz)
            {
                oneraz1 = true;
            }
            enter = false;
            VarSave.SetInt("delbutton" + del, 0);
        }
    }
}
