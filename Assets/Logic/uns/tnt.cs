using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tnt : MonoBehaviour
{
    public GameObject g;
    public void OnCollisionEnter(Collision c)
    {
        
            Instantiate(g,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
