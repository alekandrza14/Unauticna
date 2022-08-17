using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport : MonoBehaviour
{
    public int sceneid; public int sceneid1;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {


            SceneManager.LoadScene(sceneid);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {


            SceneManager.LoadScene(sceneid1);
        }
    }
}
