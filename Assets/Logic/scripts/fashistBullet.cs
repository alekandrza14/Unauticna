using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fashistBullet : MonoBehaviour
{
    public string Name_Die;
    public bool moneytheft;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("cry", true);

            if (moneytheft)
            {
                VarSave.LoadMoney("tevro", -VarSave.LoadMoney("tevro", 0) / 2);
                VarSave.LoadTrash("inftevro", -VarSave.LoadTrash("inftevro", 0) / 2);
            }
                VarSave.SetBool(Name_Die, true);

            GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}