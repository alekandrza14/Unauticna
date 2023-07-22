

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class portallNumer
{
    public static string Portal = "";
}

public class button8 : MonoBehaviour
{

    public int id;
    public bool enter;
    public bool notsave;
    public string Portal;
    public Collider other;
    public InputField ifd;
    public string pasword;
    public Canvas c;

    public HyperbolicPoint sp;

    private void Start()
    {
        c.gameObject.SetActive(false);
        if (portallNumer.Portal == pasword)
        {
            musave.load(transform,sp);
            portallNumer.Portal = "";
        }

    }
    public void startcol()
    {
        enter = true;
        c.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider s)
    {
        if (s.gameObject.tag == "Player")
        {

            startcol();



        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && ifd.text == pasword)
        {
           
            if (enter)
            {
                if (!notsave)
                {
                    musave.save();
                }
                portallNumer.Portal = pasword;
                musave.chargescene(id);

            }
          
        }
    }
    private void OnTriggerExit(Collider s)
    {
        if (s.gameObject.tag == "Player")
        {

            enter = false;
            PlayerPrefs.SetString("text", "");
            c.gameObject.SetActive(false);
            other = s;

        }
    }

}