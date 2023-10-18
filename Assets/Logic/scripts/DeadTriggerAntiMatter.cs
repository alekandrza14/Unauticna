using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadTriggerAntiMatter : MonoBehaviour
{
  

    public void OnCollisionEnter(Collision collision)
    {
        bool e = !Input.GetKey(KeyCode.G) && !Input.GetKey(KeyCode.F);
        if (collision.collider.tag == "Player" && e)
        {



            VarSave.SetBool("cry", true);
            VarSave.SetBool("Касание анти материи", true);
         




            GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
