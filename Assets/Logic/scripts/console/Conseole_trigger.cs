using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conseole_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void run(string console)
    {
        if(console == "Xray")
        {
            ((mover)FindFirstObjectByType(typeof(mover))).xray();
        }
        if (console == "Next")
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (console == "Back")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        

        List<string> s = new List<string>();
        string pre ="" ;
        for (int i = 0; i < console.Length; i++)
        {
            if (console[i]==' ')
            {
                s.Add(pre);
                pre = "";
            }else 
            {
                pre += console[i];
            }
        }
        s.Add(pre);
        string a = "";
        for (int i = 0; i < 2; i++)
        {
            if (s[0] == "scene")
            {
                a = "1";
            }
            if (s[0] == "movex")
            {
                a = "2";
            }
            if (s[0] == "movey")
            {
                a = "3";
            }
            if (s[0] == "movez")
            {
                a = "4";
            }
            if (s[0] == "movew")
            {
                a = "5";
            }
            if (i == 1 && a == "1")
            {
                SceneManager.LoadScene(int.Parse(s[1]));

            }
            if (i == 1 && a == "2")
            {
                mover.FindFirstObjectByType<mover>().transform.position += Vector3.right * int.Parse(s[1]);

            }
            if (i == 1 && a == "3")
            {
                mover.FindFirstObjectByType<mover>().transform.position += Vector3.up * int.Parse(s[1]);

            }
            if (i == 1 && a == "4")
            {
                mover.FindFirstObjectByType<mover>().transform.position += Vector3.forward * int.Parse(s[1]);

            }
            if (i == 1 && a == "2")
            {
                mover.FindFirstObjectByType<mover>().w +=  int.Parse(s[1]);

            }
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F9) && !GameObject.FindWithTag("console"))
        {
            Instantiate(Resources.Load<GameObject>("ui/console/Console").gameObject, transform.position, Quaternion.identity);


        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            run(FindObjectOfType<Console_pointer>().text.text);
            Destroy(GameObject.FindWithTag("console"));


        }
    }
}