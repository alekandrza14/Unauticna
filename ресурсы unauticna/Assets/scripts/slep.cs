using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slep : MonoBehaviour
{
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stateworld.Eanchitmoning)
        {
            particle.Play();
        }
    }
}
