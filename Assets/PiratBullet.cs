using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiratBullet : MonoBehaviour
{
    Vector3 v3;
    [SerializeField] Rigidbody rb;
    int s;
    void Start()
    {
        v3 = transform.position - mover.main().transform.position;
        v3 /= Vector3.Distance(transform.position, mover.main().transform.position);
      //  transform.localScale = Vector3.one * Vector3.Distance(transform.position, mover.main().transform.position) / 4;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity =- v3 * 60;
       // transform.position -= v3 * Time.deltaTime *30;
        s++;
        if (s>800)
        {
            Destroy(gameObject);
        }
    }
}
