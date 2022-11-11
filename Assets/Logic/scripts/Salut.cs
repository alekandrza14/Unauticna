using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salut : MonoBehaviour
{
    public GameObject salut1;
    public GameObject salut2;
    public GameObject salut3;
    public void function1()
    {
        Instantiate(salut1, transform.position, transform.rotation);
        Instantiate(salut2, transform.position, transform.rotation); 
        Instantiate(salut3, transform.position, transform.rotation);
    }
}
