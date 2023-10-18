using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.ProBuilder;

public class button6 : MonoBehaviour
{

    public int id;
    public bool enter;
    public bool notsave;
    public bool iaw;
    public string Portal;
    public bool p3;
    public bool p4;
    public bool p5;
    public Collider other;
    public PolarHyperbolicPoint sp;
    public float w;
    private void Start()
    {
        Init();
        Teleport();
    }

    private void Teleport()
    {
        if (portallNumer.Portal == Portal)
        {
            Debug.Log("portaltelep "+ Portal);
            GameManager.load(transform,sp);
            portallNumer.Portal = "";
            mover.main().W_position = w;
        }
    }

    private void Init()
    {
        if (iaw)
        {
            Portal = "iaw";
        }
        if (p3)
        {
            Portal = "p3";
        }
        if (p4)
        {
            Portal = "p4";
        }
        if (p5)
        {
            Portal = "p5";
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
                
                    GameManager.save();
                
                portallNumer.Portal = Portal;
                GameManager.chargescene(id);

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

