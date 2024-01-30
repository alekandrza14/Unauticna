using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiosourseout : MonoBehaviour
{
    public string playerFunction;
    void Update()
    {
        if (GetComponent<AudioSource>().isPlaying == false)
        {
            mover.main().Invoke(playerFunction,0);
            Destroy(gameObject);
        }
    }
}
