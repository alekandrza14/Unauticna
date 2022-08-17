using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float tic, time = 40;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tic += Time.deltaTime * Random.Range(1, 3);
        if (tic >= time)
        {
            Destroy(gameObject);
            tic = 0;

        }
        GetComponent<Rigidbody>().velocity = new Vector3(10,0,0);
    }
}
