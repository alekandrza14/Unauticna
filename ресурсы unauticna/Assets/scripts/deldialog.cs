using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class deldialog : MonoBehaviour
{
    public GameObject button;
    public string del;
    public string[] s = new string[1]; public string sm = "Очевидно...";
    public TextMeshProUGUI text;
    public bool enter; public bool act;
    public float tic; public int tir; public int tir2;

    void Start()
    {
       tir2 = VarSave.GetInt(del);
        s[0] = text.text;
        VarSave.SetInt("delbutton" + del, 0);
        button.SetActive(false);
        text.text = "";
    }

    
    void Update()
    {
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
                    }
                }

                else
                {
                    text.text += sm[tir];
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
                    tir2 = 0;
                    tir = 0;


                }
                tic = 0;
            }
        }
        if (!enter)
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
        }
        
        if (VarSave.GetInt("delbutton" + del) == 1)
        {
            button.SetActive(true);
            
            
        }
        else
        {
            button.SetActive(false);
        }
        VarSave.SetInt(del ,tir2);
    }
    private void OnTriggerEnter(Collider s)
    {
        Debug.Log(1);
        if (s.tag == "Player")
        {
            enter = true;
            Debug.Log(1);
            VarSave.SetInt("delbutton" + del, 1);
        }
    }
    private void OnTriggerExit(Collider s)
    {
        if (s.tag == "Player")
        {
            enter = false;
            VarSave.SetInt("delbutton" + del, 0);
        }
    }
}
