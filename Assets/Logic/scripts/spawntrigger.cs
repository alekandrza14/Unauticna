using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawntrigger : MonoBehaviour
{
    public GameObject poop;
    public Transform traget;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(poop,traget);
        }
    }
}
