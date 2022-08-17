using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadtrigger2 : MonoBehaviour
{
    public bool tesserakt;
    public bool zellotton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("cry", true); if (!tesserakt&&!zellotton)
            {


                VarSave.SetBool("переломал кости и от правлен в больницу", true);
            }

            if (tesserakt)
            {


                VarSave.SetBool("нравикс попал в ловушку", true);
            }
            if (zellotton)
            {


                VarSave.SetBool("убит фанатиком", true);
            }

            if (musave.player(other.gameObject))
            {


                musave.chargescene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
