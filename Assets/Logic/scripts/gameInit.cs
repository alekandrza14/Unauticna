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
        Screen.SetResolution(1600,1200,false);
        PlayerPrefs.DeleteAll();
    }
    private void Update()
    {
        PlayerPrefs.DeleteAll();
    }
    private void OnApplicationQuit()
    {
        Screen.SetResolution(1, 1, false);
    }
    private void OnDestroy()
    {
        Screen.SetResolution(1, 1, false);
    }

}
