using UnityEngine;

public class Ucna_kerfus_narukah : MonoBehaviour
{
    public GameObject norm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("slez",Random.Range(6,60));
    }
    void slez()
    {
        Instantiate(norm,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
