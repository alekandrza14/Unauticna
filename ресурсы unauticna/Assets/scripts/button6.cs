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
   
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            if (enter)
            {
                if (!notsave)
                {
                    GameObject.FindObjectOfType<mover>().saveing();
                }
                    SceneManager.LoadScene(id);
            }
        }
    }
    private void OnTriggerExit(Collider s)
    {
        if (s.gameObject.tag == "Player")
        {

            enter = false;
            PlayerPrefs.SetString("text", "");



        }
    }
    
}

