using UnityEngine;

public class LoadTrigger : MonoBehaviour
{
    public GameObject PeramanentLoad;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") PeramanentLoad.SetActive(true);
    }
}
