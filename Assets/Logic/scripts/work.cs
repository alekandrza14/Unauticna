using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class work : MonoBehaviour
{
    public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!stateworld.Eanchitmoning)
        {
            Destroy(g);
        }
    }
}
