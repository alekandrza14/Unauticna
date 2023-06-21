using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endstart2 : MonoBehaviour
{

    void Start()
    {

        if (!VarSave.ExistenceVar("ì.ê"))
        {
            VarSave.SetInt("ì.ê", 1);
            SceneManager.LoadScene(60);
        }
    }


}
