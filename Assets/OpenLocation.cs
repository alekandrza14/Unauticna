using UnityEngine;

public class OpenLocation : MonoBehaviour
{
    public GameObject obj;
    public void OnOpenLocation()
    {
        obj.SetActive(true);
    }
}
