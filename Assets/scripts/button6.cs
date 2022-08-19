using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class button6 : MonoBehaviour
{

    public int id;
    public bool enter;
    public bool notsave;
    public bool iaw;
    public bool p3;
    public bool p4;
    public bool p5;
    public Collider other;
    public Sphere sp;
    private void Start()
    {
        if (!sp)
        {
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
            if (portallNumer.p5 == true && p5)
            {
                musave.load(transform);
                portallNumer.p5 = false;
            }
        }
        if (sp)
        {
            PolarTransform pt = sp.p2.inverse();

            if (portallNumer.p2 == true && iaw)
            {
                musave.load5(pt, sp.v1);
                portallNumer.p2 = false;
            }
            if (portallNumer.p3 == true && p3)
            {
                musave.load5(pt, sp.v1);
                portallNumer.p3 = false;
            }
            if (portallNumer.p4 == true && p4)
            {
                musave.load5(pt, sp.v1);
                portallNumer.p4 = false;
            }
            if (portallNumer.p5 == true && p5)
            {
                musave.load5(pt, sp.v1);
                portallNumer.p5 = false;
            }
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
            if (enter && p5)
            {
                if (!notsave)
                {
                    musave.save();
                }
                portallNumer.p5 = true;
                musave.chargescene(id);

            }
            if (enter)
            {
                if (!notsave)
                {
                    musave.save();
                }
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

