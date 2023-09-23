using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side1Switch : MonoBehaviour
{
    [SerializeField] Camera Cam;

    private GameObject Player;
    public LayerMask l1;
    public LayerMask c;
    public LayerMask al1;
    public LayerMask ac;
   static bool on;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        Cam = Camera.main;
        on = VarSave.GetBool("Side");
        if (on)
        {
            Player.GetComponent<Rigidbody>().excludeLayers = l1;
            Player.GetComponent<Rigidbody>().includeLayers = l1;
            Cam.cullingMask = c;
            Player.layer = 12;
        }
        if (!on)
        {
            Player.GetComponent<Rigidbody>().excludeLayers = al1;
            Player.GetComponent<Rigidbody>().includeLayers = al1;
            Cam.cullingMask = ac;
            Player.layer = 11;
        }
    }

    // Update is called once per frame
    void Update()
    {

        Cam = Camera.main;

        if (Input.GetKeyDown(KeyCode.F1)) VarSave.SetBool("Side", on);
        if (Input.GetKeyDown(KeyCode.F2))
        {
            on = VarSave.GetBool("Side");
            if (on)
            {
                Player.GetComponent<Rigidbody>().excludeLayers = l1;
                Player.GetComponent<Rigidbody>().includeLayers = l1;
                Cam.cullingMask = c;
                Player.layer = 12;
            }
            if (!on)
            {
                Player.GetComponent<Rigidbody>().excludeLayers = al1;
                Player.GetComponent<Rigidbody>().includeLayers = al1;
                Cam.cullingMask = ac;
                Player.layer = 11;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        on = !on;
        if (on)
        {
            Player.GetComponent<Rigidbody>().excludeLayers = l1;
            Player.GetComponent<Rigidbody>().includeLayers = l1;
            Cam.cullingMask = c;
            Player.layer = 12;
        }
        if (!on)
        {
            Player.GetComponent<Rigidbody>().excludeLayers = al1;
            Player.GetComponent<Rigidbody>().includeLayers = al1;
            Cam.cullingMask = ac;
            Player.layer = 11;
        }
    }
}
