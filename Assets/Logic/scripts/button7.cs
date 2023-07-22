using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.ProBuilder;

public class button7 : MonoBehaviour
{

    public int id;
    public bool enter;
    string Portal = "p2";
    public bool notsave; public Collider other;

    public HyperbolicPoint sp;

    private void Start()
    {
        if (portallNumer.Portal == Portal)
        {
            musave.load(transform,sp);
            portallNumer.Portal = "";
        }

    }
    public void startcol()
    {
        enter = true;

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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (enter)
            {
                if (!notsave)
                {
                    musave.save();
                }
                portallNumer.Portal = Portal;
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

            other = s;

        }
    }

}


