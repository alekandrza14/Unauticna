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
            button6.TabUse = Instantiate(Resources.Load<GameObject>("ui/info/PressTabToUse"));

            enter = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (button6.TabUse) Destroy(button6.TabUse);

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
