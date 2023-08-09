using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameInit : MonoBehaviour
{
    static public GameObject init;

    static public void Init(GameObject g)
    {
        if (init==null) {
            g.AddComponent<gameInit>();
            init = g;
        }
        else
        {
            g.AddComponent<deleter1>();
        }
    
    }
    void Start()
    {
        if (VarSave.ExistenceVar("res3", SaveType.global) && SceneManager.GetActiveScene().buildIndex != 129) 
            Screen.SetResolution(VarSave.GetInt("res3", SaveType.global), VarSave.GetInt("res4", SaveType.global), !VarSave.GetBool("windowed", SaveType.global));
      //  Screen.SetResolution(1600,1200,false);
        PlayerPrefs.DeleteAll();
    }
    private void Update()
    {
        
        if (VarSave.ExistenceVar("res3", SaveType.global)&& SceneManager.GetActiveScene().buildIndex != 129) Screen.SetResolution(VarSave.GetInt("res3", SaveType.global), VarSave.GetInt("res4", SaveType.global), !VarSave.GetBool("windowed", SaveType.global));

        PlayerPrefs.DeleteAll();
    }
    
    private void OnApplicationQuit()
    {
        if (VarSave.ExistenceVar("res3", SaveType.global) && SceneManager.GetActiveScene().buildIndex != 129) Screen.SetResolution(VarSave.GetInt("res3", SaveType.global), VarSave.GetInt("res4", SaveType.global), !VarSave.GetBool("windowed", SaveType.global));
    }
    private void OnDestroy()
    {
        if (VarSave.ExistenceVar("res3", SaveType.global) && SceneManager.GetActiveScene().buildIndex != 129) Screen.SetResolution(VarSave.GetInt("res3", SaveType.global), VarSave.GetInt("res4", SaveType.global), !VarSave.GetBool("windowed", SaveType.global));
    }

}
