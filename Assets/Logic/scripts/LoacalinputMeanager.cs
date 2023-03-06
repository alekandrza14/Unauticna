using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoacalinputMeanager : MonoBehaviour
{
    [SerializeField] InputField build;
    public void eat()
    {
        StartCoroutine(input());
    }

    IEnumerator input()
    {

        GlobalInputMenager.KeyCode_eat = 1;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1f);

    }
    public void Update()
    {
        StartCoroutine(inputb());
    }
    public void hilow()
    {
        VarSave.SetBool("postrender", !VarSave.GetBool("postrender"));
       if(!VarSave.EnterFloat("res1"))
        {
            VarSave.SetInt("res1", 320);
            VarSave.SetInt("res2", 240);
        }
        musave.saveandhill();
        musave.chargescene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator inputb()
    {

       if(build) GlobalInputMenager.KeyCode_build = build.text;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1f);

    }
}
