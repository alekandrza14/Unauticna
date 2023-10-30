using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haker : MonoBehaviour
{
    float timer;
    [SerializeField] GameObject hakerbug;
    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.GetComponent<Logic_tag_DamageObject>() && cistalenemy.dies > 0)
        {
            VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") - 100);
            Destroy(gameObject);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            cistalenemy.dies++;

            VarSave.SetInt("Agr", cistalenemy.dies);
        }
        transform.rotation = Random.rotation;
    }
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(0,0,-Time.deltaTime*2);
        if (timer >= 10)
        {
           if(cistalenemy.dies > 0) Instantiate(hakerbug);
            transform.rotation = Random.rotation;
            timer = 0;
        }
    }
}
