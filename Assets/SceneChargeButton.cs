using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChargeButton : MonoBehaviour
{
    public void ChargeSceneByNumber(int scene)
    {

        SceneManager.LoadScene(scene);
    }
    public void ChargeSceneByString(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
