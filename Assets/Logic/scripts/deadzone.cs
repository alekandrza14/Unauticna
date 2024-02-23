using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadzone : MonoBehaviour
{
   
    public void OnTriggerExit(Collider other)
    {
        
        if (other.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("отравлен и от правлен в больницу", true); 
            VarSave.SetBool("cry", true);
          //  Uxill_Engine.kill();
         

                
                GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);
           
        }
    }
}
