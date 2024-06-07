using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exner : MonoBehaviour
{
    void zaseranie()
    {
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);
         DeadShit.Spawn(transform.position);

        cistalenemy.dies++;

        VarSave.SetInt("Agr", cistalenemy.dies);
    }
    private void OnCollisionStay(Collision c)
    {

        if (c.collider.GetComponent<Logic_tag_exploution>() && ionenergy.energy == 0)
        {
            Globalprefs.LoadTevroPrise(- 100);
            Destroy(gameObject);
            zaseranie();
        }
        if (c.collider.GetComponent<Logic_tag_exploution>() && ionenergy.energy == 1)
        {
            Globalprefs.LoadTevroPrise(- 100);
            Destroy(gameObject);
            
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Global.Random.Range(-1030, 1031) * Time.deltaTime, 0));
        transform.Translate(new Vector3(20 * Time.deltaTime, Global.Random.Range(-13, 14) * Time.deltaTime,0));
    }
}
