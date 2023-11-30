using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlockFromMinecraft : MonoBehaviour
{
    [SerializeField] GameObject Obj;
    private void OnCollisionEnter(Collision collision)
    {
        Ray r = new Ray(transform.position + (Vector3.down * 1.01f), Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            if (hit.normal.y < 0.99f)
            {
                Rigidbody rb = Instantiate(Obj, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.velocity = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), Random.Range(-4, 4));
                Destroy(gameObject);
            }
        }
    }
    void Update()
    {
        Ray r = new Ray(transform.position + (Vector3.down*1.01f), Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(r,out hit))
        {
            if (hit.normal.y < 0.99f && hit.distance < 1)
            {
              Rigidbody rb =  Instantiate(Obj,transform.position,Quaternion.identity).GetComponent<Rigidbody>();
                rb.velocity = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), Random.Range(-4, 4));
                Destroy(gameObject);
            }
        }
    }
}
