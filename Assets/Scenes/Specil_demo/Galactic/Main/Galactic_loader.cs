using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Galactic_loader : MonoBehaviour
{
    public size s;
    void Start()
    {
        if (s == size.Stars)
        {


            if (VarSave.GetString("Universe_Position") != "")
            {
                SceneManager.LoadScene(VarSave.GetString("Universe_Position"));
            }
            else
            {
                SceneManager.LoadScene("Galactic demo");
            }

        }
        if (s == size.Galaxy)
        {


            if (VarSave.GetString("Universe_galaxy_Position") != "")
            {
                SceneManager.LoadScene(VarSave.GetString("Universe_galaxy_Position"));
            }
            else
            {
                SceneManager.LoadScene("Galactic full");
            }

        }
        if (s == size.Universe)
        {


            if (VarSave.GetString("Multyverse_Universe_Position") != "")
            {
                SceneManager.LoadScene(VarSave.GetString("Multyverse_Universe_Position"));
            }
            else
            {
                SceneManager.LoadScene("Universe");
            }

        }
    }


}
