using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endstart1 : MonoBehaviour
{
    
    void Start()
    {
        
        if (!VarSave.EnterFloat("�.�.�"))
        {
            VarSave.SetInt("�.�.�", 1);
            SceneManager.LoadScene(43);
        }
    }

    
}
