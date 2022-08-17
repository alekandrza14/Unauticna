using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject g; 
    List<GameObject> gs = new List<GameObject>();
    public InputField ifd;
    public void Start()
    {
        getWorld();
        Cursor.lockState = CursorLockMode.None;
    }

    public void getWorld()
    {
        
    }
    public void CreateWorld()
    {
        Directory.CreateDirectory("worlds/" + ifd.text);
        getWorld();
    }
}
