using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransformObject
{
    public Vector3[] v3;
    public Quaternion[] q4;
    public Vector3[] s3;
    public string[] name;
    public Vector3[] initpos;

}

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

#if !UNITY_EDITOR
        dnSpyModer.MainModData.Main();
#endif
        if (VarSave.ExistenceVar("res3", SaveType.global) && SceneManager.GetActiveScene().buildIndex != 129) 
            Screen.SetResolution(VarSave.GetInt("res3", SaveType.global), VarSave.GetInt("res4", SaveType.global), !VarSave.GetBool("windowed", SaveType.global));
      //  Screen.SetResolution(1600,1200,false);
        PlayerPrefs.DeleteAll();
    }
    private void Update()
    {
       
      
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
