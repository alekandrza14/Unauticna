using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float tic, time = 40;
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Rigidbody>().AddForce(transform.forward * speed*20, ForceMode.Force);
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
        if (tic >= time/2)
        {
            Vector3 target;
            target = GameManager.GetPlayer().transform.position;
            transform.rotation = Quaternion.LookRotation((target - transform.position), transform.up);

        }
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }
}
