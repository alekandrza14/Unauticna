using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class button7 : MonoBehaviour
{

    public int id;
    public bool enter;
    public bool notsave; public Collider other;

    private void Start()
    {
        if (portallNumer.p1 == true)
        {
            musave.load(transform);
            portallNumer.p1 = false;
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
                musave.chargescene(id);
                portallNumer.p1 = true;
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


