using UnityEngine;

public class Light1 : MonoBehaviour
{
    void Update()
    {
        GetComponent<Light>().cookie = null;
    }
}
