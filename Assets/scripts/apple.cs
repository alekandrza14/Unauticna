using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class apple : MonoBehaviour
{
    [Header("до")]
    public int varpp;
    public string var = "ap";
    public GameObject[] objects;
    [Header("после")]
    public GameObject[] objects2;
    public GameObject[] objects3;
    public GameObject[] objects4;
    public GameObject[] objects5;

    void Start()
    {
        if (VarSave.GetInt(var) == 1)
        {
            varpp = 1;
        }
        if (VarSave.GetInt(var) == 0)
        {
            varpp = 0;
        }
        if (VarSave.GetInt(var) == 2)
        {
            varpp = 2;
        }
        if (varpp == 0)
        {
            for (int i = 0; i < objects.Length; i++)
            {


                objects[i].SetActive(true);
                
            }
            for (int i = 0; i < objects2.Length; i++)
            {



                objects2[i].SetActive(false);
            }
            for (int i = 0; i < objects4.Length; i++)
            {



                objects4[i].SetActive(false);
            }
        }
        if (varpp == 1)
        {
            for (int i = 0; i < objects.Length; i++)
            {


                objects[i].SetActive(false);

            }
            for (int i = 0; i < objects2.Length; i++)
            {



                objects2[i].SetActive(true);
            }
            for (int i = 0; i < objects5.Length; i++)
            {



                objects5[i].SetActive(false);
            }
        }
        if (varpp == 2)
        {
            for (int i = 0; i < objects.Length; i++)
            {


                objects[i].SetActive(false);

            }
            for (int i = 0; i < objects2.Length; i++)
            {



                objects2[i].SetActive(false);
            }
            for (int i = 0; i < objects3.Length; i++)
            {



                objects3[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player" && VarSave.GetInt(var) != 1 && VarSave.GetInt(var) != 2) 
        {
            musave.save();
            VarSave.SetInt(var, 1);
            musave.chargescene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
