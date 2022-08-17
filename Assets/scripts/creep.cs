using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creep : MonoBehaviour
{
    public GameObject ob;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && Random.Range(0,9) == 1)
        {
            Instantiate(ob.gameObject, transform.position, Quaternion.identity);
        }
    }
}
