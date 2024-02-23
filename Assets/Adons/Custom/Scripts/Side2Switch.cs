using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side2Switch : MonoBehaviour
{
    private Camera Cam;

    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
   
}
