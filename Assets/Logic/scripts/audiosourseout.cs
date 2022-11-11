using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiosourseout : MonoBehaviour
{
    void Update()
    {
        if (GetComponent<AudioSource>().isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
