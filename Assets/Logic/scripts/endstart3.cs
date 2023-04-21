using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class endstart3 : MonoBehaviour
{

    void Start()
    {

        if (!VarSave.EnterFloat("ñ.í.î.ê"))
        {
            if (Globalprefs.signedgamejolt == true)
            {
                GameJolt.API.Trophies.TryUnlock(184979);
            }
            VarSave.SetInt("ñ.í.î.ê", 1);
            SceneManager.LoadScene(85);
        }
    }


}