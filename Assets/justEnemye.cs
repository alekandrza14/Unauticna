using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class justEnemye : MonoBehaviour
{

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Logic_tag_DamageObject>())
        {
            GetComponent<Animator>().Play("eegg2"); 
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
        }
    }

}
