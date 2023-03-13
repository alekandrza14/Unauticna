using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameInit : MonoBehaviour
{
   
    static public void Init(GameObject g)
    {
        g.AddComponent<gameInit>();
    }
    void Start()
    {
        if (VarSave.EnterFloat("res3")) Screen.SetResolution(VarSave.GetInt("res3"), VarSave.GetInt("res4"), !VarSave.GetBool("windowed"));
      //  Screen.SetResolution(1600,1200,false);
        PlayerPrefs.DeleteAll();
    }
    private void Update()
    {
        PlayerPrefs.DeleteAll();
    }
    
    private void OnApplicationQuit()
    {
        if (VarSave.EnterFloat("res3")) Screen.SetResolution(VarSave.GetInt("res3"), VarSave.GetInt("res4"), !VarSave.GetBool("windowed"));
    }
    private void OnDestroy()
    {
        if (VarSave.EnterFloat("res3")) Screen.SetResolution(VarSave.GetInt("res3"), VarSave.GetInt("res4"), !VarSave.GetBool("windowed"));
    }

}
