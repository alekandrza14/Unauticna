using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endstart2 : MonoBehaviour
{

    void Start()
    {

        if (!VarSave.ExistenceVar("�.�"))
        {
            VarSave.SetInt("�.�", 1);
            SceneManager.LoadScene(60);
        }
    }


}
