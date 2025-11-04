using UnityEngine;

public class SpawnLoop : MonoBehaviour
{
    public GameObject spawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpaenCooldown",5,5);
    }

    // Update is called once per frame
    void SpaenCooldown()
    {
        Instantiate(spawn,transform.position,Quaternion.identity);
    }
}
