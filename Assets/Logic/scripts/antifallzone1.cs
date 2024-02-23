using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class antifallzone1 : MonoBehaviour
{
    public GameObject up1;
    
    public void OnTriggerStay(Collider other)
    {
        GameManager.fall(up1.gameObject);
    }
}
