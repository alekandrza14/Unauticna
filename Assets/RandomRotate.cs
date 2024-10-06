using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("Jingle",0,0.02f);
    }

    void Jingle()
    {
        transform.Rotate(Random.Range(-1,2), Random.Range(-1, 2), Random.Range(-1, 2));
    }
    
}
