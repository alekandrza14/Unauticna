using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldData
{
    static public string path = "unsave/capter";
}


public class EnterWorld : MonoBehaviour
{
    
    public void Enter()
    {
        
        SceneManager.LoadScene("World");
    }
}
