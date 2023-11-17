using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerExitPHS : MonoBehaviour
{
    bool enter;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            enter = false;
        }
    }
    void Update()
    {
        if (enter && Input.GetKeyDown(KeyCode.Tab))
        {
          SceneManager.LoadScene(VarSave.GetString("SceneNamePosition"));
        }
    }
}
