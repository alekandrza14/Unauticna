using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float tic, time = 40;
    public float speed = 10;
    public bool buletdj;
    public static List<GameObject> safeSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
        if (!buletdj) GetComponent<Rigidbody>().AddForce(speed * 20*transform.forward , ForceMode.Force);
        if (buletdj)
        {

            GetComponent<Rigidbody>().AddForce(speed*transform.right, ForceMode.VelocityChange);
        }
        safedata();
    }
    void safedata()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buletdj)
        {
           
            GetComponent<Rigidbody>().AddForce(speed*transform.right, ForceMode.VelocityChange);
        }
    }
}
