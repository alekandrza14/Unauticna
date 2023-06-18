using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Chunks : MonoBehaviour
{
    Chunk[] chunks;
    public Chunks getThis()
    {
        return this;
    }
    // Start is called before the first frame update
    void Start()
    {
        chunks = FindObjectsByType<Chunk>(FindObjectsSortMode.None);

    }
    void OnCollisionEnter(Collision col)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
