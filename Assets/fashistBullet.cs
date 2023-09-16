using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fashistBullet : MonoBehaviour
{
    public string Name_Die;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("cry", true); 
        

                VarSave.SetBool(Name_Die, true);

            GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}