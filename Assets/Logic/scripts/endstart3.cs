using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class endstart3 : MonoBehaviour
{

    void Start()
    {

        if (!VarSave.EnterFloat("�.�.�.�"))
        {
            if (Globalprefs.signedgamejolt == true)
            {
                GameJolt.API.Trophies.TryUnlock(184979);
            }
            VarSave.SetInt("�.�.�.�", 1);
            SceneManager.LoadScene(85);
        }
    }


}