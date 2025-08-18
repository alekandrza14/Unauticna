using UnityEngine;

public class SleepTimer : MonoBehaviour
{
    public GameObject refab;
    void Start()
    {
        Invoke("Swap",10);
    }
    public void Swap()
    {
        Instantiate(refab,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
