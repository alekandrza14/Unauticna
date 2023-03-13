using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformTriggered : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        int i = Random.Range(0, 3);
        if (i == 0)
        {
            Instantiate(Resources.Load("voices/geoane"));
        }
        if (i == 1)
        {
            Instantiate(Resources.Load("voices/geoane1"));
        }
        if (i == 2)
        {
            Instantiate(Resources.Load("voices/geoane2"));
        }
    }
}
