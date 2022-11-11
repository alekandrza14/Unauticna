using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChanse : MonoBehaviour
{
    private void Start()
    {
        if (Random.Range(0,2)==1)
        {
            Destroy(gameObject);
        }
    }
}
