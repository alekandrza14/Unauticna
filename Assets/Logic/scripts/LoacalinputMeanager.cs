using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
