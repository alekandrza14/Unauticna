using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenecont : MonoBehaviour
{
    public int command;
    public int scene;
    public float tic;
    public float time;
    public GameObject Object1;
    public GameObject[] Object2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (command == 1)
        {


            SceneManager.LoadScene(scene);
        }
        if (command == 2)
        {
            tic += Time.deltaTime;

            if (tic >= time)
            {

                Instantiate(Object1,Object2[Random.Range(0,Object2.Length)].transform);
                tic = 0;
            }
        }

    }
}
