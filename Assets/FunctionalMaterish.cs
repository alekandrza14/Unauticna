using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionalMaterish : MonoBehaviour
{
    public void spawnMatrs(string matr)
    {
        if (matr != "магия")
        {
            if (VarSave.GetFloat("mana") >= 10)
            {
                Instantiate(Resources.Load<GameObject>("ui/mats/" + matr).gameObject, transform.position, Quaternion.identity);
                if (VarSave.LoadFloat("luck", 0f) > 0.5 && Random.Range(0, 2) == 0)
                {

                    VarSave.LoadFloat("mana", 1);
                }
                if (VarSave.LoadFloat("luck", 0f) > 2 && Random.Range(0, 2) == 0)
                {

                    VarSave.LoadFloat("mana", 2);
                }
                if (VarSave.LoadFloat("luck", 0f) > 3 && Random.Range(0, 2) == 0)
                {

                    VarSave.LoadFloat("mana", 2);
                }
                if (VarSave.LoadFloat("luck", 0f) > 4 && Random.Range(0, 2) == 0)
                {

                    VarSave.LoadFloat("mana", 3);
                }
                if (VarSave.LoadFloat("luck", 0f) > 6 && Random.Range(0, 2) == 0)
                {

                    VarSave.LoadFloat("mana", 5);
                }
                if (VarSave.LoadFloat("luck", 0f) > 9 && Random.Range(0, 2) == 0)
                {

                    VarSave.LoadFloat("mana", 10);
                }
                if (VarSave.LoadFloat("luck", 0f) > 24 && Random.Range(0, 2) == 0)
                {

                    VarSave.LoadFloat("mana", 20);
                }
                if (VarSave.LoadFloat("luck", 0f) >= 666 && VarSave.LoadFloat("luck", 0f) <= 905 && Random.Range(0, 3) == 0)
                {

                    VarSave.SetFloat("mana", 0);
                    VarSave.SetBool("подавлен запрещёным уровнем удачи", true);
                    VarSave.SetBool("cry", true);
                    //  Uxill_Engine.kill();



                    GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);
                }
                if (VarSave.LoadFloat("luck", 0f) >= 906 && Random.Range(0, 2) == 0)
                {

                    VarSave.LoadFloat("mana", 999);
                }
                Destroy(gameObject);
                VarSave.LoadFloat("mana", -10);
            }
        }
        else
        {
            VarSave.LoadFloat("mana", 2);

            Instantiate(Resources.Load<GameObject>("ui/mats/" + matr).gameObject, transform.position, Quaternion.identity);
        }
    }
}
