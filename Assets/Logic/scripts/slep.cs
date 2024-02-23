using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slep : MonoBehaviour
{
    public ParticleSystem particle;
    
    void Update()
    {
        if (stateworld.Eanchitmoning)
        {
            particle.Play();
        }
    }
}
