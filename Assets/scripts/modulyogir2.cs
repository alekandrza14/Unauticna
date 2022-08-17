using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modulyogir2 : MonoBehaviour
{
    public int povedenie;
    public float tic, time = 10;
    public Rigidbody rb;
    public Animator anim;
    public float rot;
    public GameObject tho;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnCollisionStay(Collision c)
    {
        if (c.collider.tag == "item1")
        {
            Destroy(gameObject);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
        }
    }
    public void delete()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        tic += Time.deltaTime * Random.Range(1,3);
        if(tic >= time)
        {
            povedenie = Random.Range(0, 2);
            tic=0;

        }
        if (povedenie == 0)
        {
            
            anim.SetBool("New Bool",false);
        }
        if (povedenie == 1)
        {
            rot = Random.Range(-2.0f, 3f);
            transform.Rotate(0, rot * 180, 0);
            povedenie = 2;
            anim.SetBool("New Bool", true);
            
        }
        if (povedenie == 2)
        {
            if (anim.GetBool("New Bool") == false)
            {
                anim.SetBool("New Bool", true);
            }
            
            transform.Translate(0,0,4*Time.deltaTime);
        }
    }
}
