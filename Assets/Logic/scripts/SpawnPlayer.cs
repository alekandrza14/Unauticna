using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject mover;

    void Start()
    {
        Ray r = new Ray(gameObject.transform.position, Vector2.down);
        RaycastHit hit;
        if (Physics.Raycast(r,out hit))
        {
            Instantiate(mover,hit.point,Quaternion.identity);
        }
    }
    public IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(0.5f);
        
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2f);

        //  SceneManager.LoadScene("game");
        Ray r = new Ray(gameObject.transform.position, Vector2.down);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            Instantiate(mover, hit.point, Quaternion.identity);
        }
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }

}
