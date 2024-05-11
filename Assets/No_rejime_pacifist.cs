using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class No_rejime_pacifist : MonoBehaviour
{
    float timer;
    void Update()
    {
        timer = Time.deltaTime;
        if (cistalenemy.dies > 100) cistalenemy.dies = 100;
        if (timer > 6) 
        {
            if (cistalenemy.dies < 100) 
            {
                cistalenemy.dies -= 1;
                timer = 0;
            }
        }
    }
}
