using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialMenu : MonoBehaviour
{
    public int[] tr1; public int[] tr2; public int[] tr3;
    public Text tr1t,tr2t,tr3t;
    public Button tr2b, tr3b, c;
    public void exitTutorial()
    {
        SceneManager.LoadScene(0);
    }
    public void Update()
    {
        tr1t.text = VarSave.GetInt("tr1").ToString() + "/10"; 
        tr2t.text = VarSave.GetInt("tr2").ToString() + "/10";
        tr3t.text = VarSave.GetInt("tr3").ToString() + "/10";
        if (VarSave.GetInt("tr1") >= 10)
        {
            tr2b.interactable = true;
        }
        if (VarSave.GetInt("tr2") >= 10)
        {
            tr3b.interactable = true;
        }
        if (VarSave.GetInt("tr3") >= 10)
        {
           c.interactable = true;
        }
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void starttr1()
    {
        SceneManager.LoadScene(tr1[Random.Range(0, tr1.Length)]);
    }
    public void starttr2()
    {
        SceneManager.LoadScene(tr2[Random.Range(0, tr2.Length)]);
    }
    public void starttr3()
    {
        SceneManager.LoadScene(tr3[Random.Range(0, tr3.Length)]);
    }
    public void endTutorial()
    {
        VarSave.SetBool("t3end",true);
        SceneManager.LoadScene(0);
    }
}
