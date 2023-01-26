using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class question : MonoBehaviour
{
    public string[] s;
    public string[] ds;

    public void but1()
    {
        VarSave.SetInt(s[0], 1);
        VarSave.SetInt(ds[0], 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void but2()
    {
        VarSave.SetInt(s[1], 1);
        VarSave.SetInt(ds[1], 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void but3()
    {
        VarSave.SetInt(s[2], 1);
        VarSave.SetInt(ds[2], 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
