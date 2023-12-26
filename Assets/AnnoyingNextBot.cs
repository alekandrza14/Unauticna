using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnoyingNextBot : MonoBehaviour
{
    mover m;
    // Start is called before the first frame update
    void Start()
    {
        m = mover.main();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(m.transform.position- transform.position, transform.up);
        transform.Translate(0,0,5f*Time.deltaTime);
    }
}
