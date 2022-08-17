

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class button9 : MonoBehaviour
{

    public int id;
    public bool enter;
    public bool notsave;
    public bool iaw;
    public bool p3;
    public bool p4;
    public bool p5;
    public Collider other;
   
    
    

    private void Start()
    {
        
        

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
    public GameObject notme()
    {
        GameObject r = gameObject;
        for (int i=0;i<GameObject.FindObjectsOfType<button9>().Length;i++)
        {
            if (GameObject.FindObjectsOfType<button9>()[i].gameObject != gameObject)
            {
                if (GameObject.FindObjectsOfType<button9>()[i].iaw == iaw)
                {
                    if (iaw == true)
                    {
                        r = GameObject.FindObjectsOfType<button9>()[i].gameObject;
                    }
                }
                if (GameObject.FindObjectsOfType<button9>()[i].p3 == p3)
                {
                    if (p3 == true)
                    {
                        r = GameObject.FindObjectsOfType<button9>()[i].gameObject;
                    }
                }
                if (GameObject.FindObjectsOfType<button9>()[i].p4 == p4)
                {
                    if (p4 == true)
                    {
                        r = GameObject.FindObjectsOfType<button9>()[i].gameObject;
                    }
                }
                if (GameObject.FindObjectsOfType<button9>()[i].p5 == p5)
                {
                    if (p5 == true)
                    {
                        r = GameObject.FindObjectsOfType<button9>()[i].gameObject;
                    }
                }
                

            }
        }
        return r;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (enter && p5)
            {
                if (!notsave)
                {
                    musave.save();
                }
               musave.GetPlayer().position =  notme().gameObject.transform.position;
               
            }
            if (enter && iaw)
            {
                if (!notsave)
                {
                    musave.save();
                }
                musave.GetPlayer().position = notme().gameObject.transform.position;
                
                

            }
            if (enter && p3)
            {
                if (!notsave)
                {
                    musave.save();
                }
                musave.GetPlayer().position = notme().gameObject.transform.position;
                
                

            }
            if (enter && p4)
            {
                if (!notsave)
                {
                    musave.save();
                }
                musave.GetPlayer().position = notme().gameObject.transform.position;
                
                

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