using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fontan : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float s = Random.Range(1,5);
        transform.localScale = new Vector3(s,s,s);
    }
}
