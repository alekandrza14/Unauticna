using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorExplushon : MonoBehaviour
{

    public float velplus;
    Vector3 vel;
    // Start is called before the first frame update
    void Start()
    {
        vel = GetComponent<BoxCollider>().size;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody>())
        {


            GetComponent<BoxCollider>().size = vel * GetComponent<Rigidbody>().velocity.y * velplus;

        }
    
    }
        private void OnCollisionEnter(Collision c)
    {
        if (c.collider.tag == "bomb" && ionenergy.energy == 1)
        {
            Destroy(c.collider.gameObject);
            Destroy(gameObject);


        }
        if (c.collider.tag == "bomb" && ionenergy.energy == 0)
        {
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity); 
            Destroy(c.collider.gameObject);
            gameObject.AddComponent<Rigidbody>().velocity = new Vector3(0,0,0);


        }

    }
}
