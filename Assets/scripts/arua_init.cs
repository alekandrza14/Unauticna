using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arua_init : MonoBehaviour
{
    public GameObject[] u;
    void Start()
    {
        for (int i = 0;i<u.Length;i++)
        {
            u[i].SetActive(true);
        }
    }

}
