using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadtrigger : MonoBehaviour
{
    public bool chervyash;
    public bool terratist;
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("cry", true); if (!chervyash && !terratist)
            {


                VarSave.SetBool("переломал кости и от правлен в больницу", true);
            }
            if (chervyash)
            {


                VarSave.SetBool("„≈–¬яЎ победил", true);
            }
            if (terratist)
            {


                VarSave.SetBool("терратскичикий корабль победил", true);
            }

          


                GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
}
