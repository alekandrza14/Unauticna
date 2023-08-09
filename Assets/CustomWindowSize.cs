using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomWindowSize : MonoBehaviour
{
    [SerializeField] Text ResolutionText;
    void Start()
    {
        Screen.SetResolution(640,480,false);
    }

    void Update()
    {
        ResolutionText.text = "X : " + Screen.width + ", Y : " + Screen.height;
    }

    public void Setup()
    {

        VarSave.SetInt("res3", Screen.width,SaveType.global);
        VarSave.SetInt("res4", Screen.height, SaveType.global);
        SceneManager.LoadScene(0);
    }
}
