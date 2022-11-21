using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum type1
{
    inty,booly
}

public class apple : MonoBehaviour
{
    [Header("до")]
    public int varpp;
    public bool varpp2;
    public type1 yt = type1.inty;
    public string var = "ap";
    public GameObject[] objects;
    [Header("после")]
    public GameObject[] objects2;
    public GameObject[] objects3;
    public GameObject[] objects4;
    public GameObject[] objects5;

    void Start()
    {
        if (yt == type1.inty) 
        {
            if (VarSave.GetInt(var) == 1 && yt == type1.inty)
            {
                varpp = 1;
            }
            if (VarSave.GetInt(var) == 0 && yt == type1.inty)
            {
                varpp = 0;
            }
            if (VarSave.GetInt(var) == 2 && yt == type1.inty)
            {
                varpp = 2;
            }
        }
        if (yt == type1.booly)
        {
            if (VarSave.GetBool(var) == false && yt == type1.booly)
            {
                varpp = 3;
            }
            if (VarSave.GetBool(var) == true && yt == type1.booly)
            {
                varpp = 0;
            }
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
        if (varpp == 3)
        {
            for (int i = 0; i < objects.Length; i++)
            {


                objects[i].SetActive(false);

            }
            for (int i = 0; i < objects2.Length; i++)
            {



                objects2[i].SetActive(false);
            }
            for (int i = 0; i < objects4.Length; i++)
            {



                objects4[i].SetActive(false);
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
    public void OnTriggerStay(Collider collision)
    {
        if (yt == type1.inty)
        {


            if (collision.tag == "Player" && VarSave.GetInt(var) != 1 && VarSave.GetInt(var) != 2)
            {
                musave.save();
                VarSave.SetInt(var, 1);
                musave.chargescene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (yt == type1.booly)
        {
            if (collision.tag == "Player" && VarSave.GetBool(var) && !VarSave.GetBool(var+1))
            {
                musave.save();
                VarSave.SetBool(var, true);
                VarSave.SetBool(var+1, true);
                musave.chargescene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
