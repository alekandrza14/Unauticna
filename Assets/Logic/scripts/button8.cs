

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class portallNumer
{
    public static bool p1 = false;
    public static bool p2 = false;
    public static bool p3 = false;
    public static bool p4 = false;
    public static bool p5 = false; 
    public static bool p6 = false; 
    public static bool p7 = false; 
    public static bool p8 = false;
}

public class button8 : MonoBehaviour
{

    public int id;
    public bool enter;
    public bool notsave;
    public bool iaw;
    public bool p3;
    public bool p4;
    public bool p5;
    public Collider other;
    public InputField ifd;
    public string pasword;
    public Canvas c;

    private void Start()
    {
        c.gameObject.SetActive(false);
        if (portallNumer.p5 == true && p5)
        {
            musave.load(transform);
            portallNumer.p5 = false;
        }
        if (portallNumer.p2 == true && iaw)
        {
            musave.load(transform);
            portallNumer.p2 = false;
        }
        if (portallNumer.p3 == true && p3)
        {
            musave.load(transform);
            portallNumer.p3 = false;
        }
        if (portallNumer.p4 == true && p4)
        {
            musave.load(transform);
            portallNumer.p4 = false;
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
            if (enter && p5)
            {
                if (!notsave)
                {
                    musave.save();
                }
                musave.chargescene(id);
                portallNumer.p5 = true;
            }
            if (enter && iaw)
            {
                if (!notsave)
                {
                    musave.save();
                }
                portallNumer.p2 = true;
                musave.chargescene(id);

            }
            if (enter && p3)
            {
                if (!notsave)
                {
                    musave.save();
                }
                portallNumer.p3 = true;
                musave.chargescene(id);

            }
            if (enter && p4)
            {
                if (!notsave)
                {
                    musave.save();
                }
                portallNumer.p4 = true;
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