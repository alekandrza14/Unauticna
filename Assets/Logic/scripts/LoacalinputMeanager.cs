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
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        GlobalInputMenager.KeyCode_eat = 1;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1f);
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

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
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

       if(build) GlobalInputMenager.KeyCode_build = build.text;

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1f);
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }
}
