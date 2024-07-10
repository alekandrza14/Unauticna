using UnityEngine;

public class MainCameraSetup : MonoBehaviour
{
    void Start()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }

    
}
