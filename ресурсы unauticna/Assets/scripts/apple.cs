using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class apple : MonoBehaviour
{
    [Header("до")]
    public bool varpp;
    public GameObject[] objects;
    [Header("после")]
    public GameObject[] objects2;

    void Start()
    {
        if (VarSave.GetInt("ap") == 1)
        {
            varpp = true;
        }
        if (!varpp)
        {
            for (int i = 0; i < objects.Length; i++)
            {


                objects[i].SetActive(true);
                
            }
            for (int i = 0; i < objects2.Length; i++)
            {


                
                objects2[i].SetActive(false);
            }
        }
        if (varpp)
        {
            for (int i = 0; i < objects.Length; i++)
            {


                objects[i].SetActive(false);
               
            }
            for (int i = 0; i < objects2.Length; i++)
            {


                
                objects2[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player" && VarSave.GetInt("ap") != 1) 
        {
            GameObject.FindObjectOfType<mover>().saveing();
            VarSave.SetInt("ap",1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
