using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class work : MonoBehaviour
{
    public GameObject g;
    void Update()
    {
        if (!stateworld.Eanchitmoning)
        {
            Destroy(g);
        }
    }
}
