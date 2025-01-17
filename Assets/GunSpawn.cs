using UnityEngine;

public class GunSpawn : MonoBehaviour
{
    public GameObject spawnPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("pisat",1,1);
    }
    public void pisat()
    {
        Rigidbody paladinskiypinok = Instantiate(spawnPrefab,transform.position, transform.rotation).GetComponent<Rigidbody>();
        paladinskiypinok.linearVelocity = paladinskiypinok.transform.forward*500 ;
    }

}
