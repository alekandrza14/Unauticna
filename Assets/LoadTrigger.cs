using UnityEngine;

public class LoadTrigger : MonoBehaviour
{
    public GameObject PeramanentLoad;
    private void OnTriggerEnter(Collider other)
    {
        PeramanentLoad.SetActive(true);
    }
}
