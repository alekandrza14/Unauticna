using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class planet_and_retranslator : MonoBehaviour
{
    [SerializeField] string Target;
    public void Buttonclick()
    {
        SceneManager.LoadScene(Target);
    }
}
