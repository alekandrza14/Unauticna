

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class portallNumer
{
    public static string Portal = "";
}

public class button8 : MonoBehaviour
{

    public int id;
    public bool enter;
    public bool notsave;
    public string Portal;
    public Collider other;
    public InputField ifd;
    public string pasword;
    public Canvas c;

    public HyperbolicPoint sp;

    private void Start()
    {
        c.gameObject.SetActive(false);
        if (portallNumer.Portal == pasword)
        {
            GameManager.load(transform,sp);
            portallNumer.Portal = "";
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

            button6.TabUse = Instantiate(Resources.Load<GameObject>("ui/info/PressTabToUse"));
            startcol();



        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && ifd.text == pasword)
        {
           
            if (enter)
            {
                if (!notsave)
                {
                    GameManager.save();
                }
                portallNumer.Portal = pasword;
                GameManager.chargescene(id);

            }
          
        }
    }
    private void OnTriggerExit(Collider s)
    {
        if (s.gameObject.tag == "Player")
        {

            if (button6.TabUse) Destroy(button6.TabUse);
            enter = false;
            PlayerPrefs.SetString("text", "");
            c.gameObject.SetActive(false);
            other = s;

        }
    }

}