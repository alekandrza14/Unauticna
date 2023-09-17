using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLife : MonoBehaviour
{
    float timer;
   

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }
}
