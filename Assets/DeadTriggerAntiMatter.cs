using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadTriggerAntiMatter : MonoBehaviour
{
  

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" && !Input.GetKey(KeyCode.G))
        {



            VarSave.SetBool("cry", true);
            VarSave.SetBool("Касание анти материи", true);
         




            GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
