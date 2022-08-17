using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamehater : MonoBehaviour
{
    public Animator anim;
    public bool end; public bool end1; public bool end2;
    public GameObject lordhaterarm;
    public GameObject des;
    public ends i;public UnsFormat n;
    private void Start()
    {
        if (VarSave.GetInt("el") == 1)
        {
            anim.SetTrigger("end");
            for (int i = 0; i < GameObject.FindObjectsOfType<unScript>().Length; i++)
            {
                if (GameObject.FindObjectsOfType<unScript>()[i].ins == n)
                {
                    GameObject.FindObjectsOfType<unScript>()[i].gameObject.AddComponent<deleter1>();
                }
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !end && VarSave.GetInt("el") != 1)
        {
            anim.SetTrigger("lord hater");
            for (int i = 0; i < GameObject.FindObjectsOfType<unScript>().Length; i++)
            {
                if (GameObject.FindObjectsOfType<unScript>()[i].ins == n)
                {
                    GameObject.FindObjectsOfType<unScript>()[i].gameObject.AddComponent<deleter1>();
                }
            }
            end = true;
        }
    }
    private void Update()
    {
        if (end1 == false && end == true && i.endactorone)
        {
            musave.GetPlayer().transform.position = lordhaterarm.transform.position;
            anim.SetTrigger("lord hater1");
            end1 = true;
        }
        if (end1 == true && i.endactortho && end2 == false)
        {
            
            anim.SetTrigger("lord hater fall");
            end2 = true;
        }
        if (end1 == true && end2 == false)
        {
            musave.GetPlayer().transform.position = lordhaterarm.transform.position;
            for (int i = 0; i < GameObject.FindObjectsOfType<unScript>().Length; i++)
            {
                if (GameObject.FindObjectsOfType<unScript>()[i].ins == n)
                {
                    GameObject.FindObjectsOfType<unScript>()[i].gameObject.AddComponent<deleter1>();
                }
            }

        }
        if (i.endactorthee)
        {
            VarSave.SetInt("el",1);


        }
    }
}
