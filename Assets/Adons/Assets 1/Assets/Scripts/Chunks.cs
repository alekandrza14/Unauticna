using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Chunks : MonoBehaviour
{
    Chunk[] chunks = GameObject.FindObjectsOfType<Chunk>();
    public Chunks getThis()
    {
        return this;
    }
    // Start is called before the first frame update
    void Start()
    {
        chunks = GameObject.FindObjectsOfType<Chunk>();

    }
    void OnCollisionEnter(Collision col)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
