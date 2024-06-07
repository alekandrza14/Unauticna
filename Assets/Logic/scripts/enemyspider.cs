using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyspider : MonoBehaviour
{
   public Collider c;
    Vector3 target;
    bool attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Logic_tag_DamageObject>() && cistalenemy.dies > 0)
        {
            Globalprefs.LoadTevroPrise(- 100);
            Destroy(gameObject);
             DeadShit.Spawn(transform.position);
             DeadShit.Spawn(transform.position);
             DeadShit.Spawn(transform.position);
             DeadShit.Spawn(transform.position);
             DeadShit.Spawn(transform.position);
            cistalenemy.dies++;

            VarSave.SetInt("Agr", cistalenemy.dies);
        }
        if (collision.collider.tag == "Player" && !Input.GetKey(KeyCode.G) && cistalenemy.dies > 0)
        {
            VarSave.SetBool("cry", true);
            VarSave.SetBool("страшный паук победил", true);

          

                GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);
           
        }
    }
    // Update is called once per frame
    void Update()
    {
        Ray r= new Ray(transform.position,new Vector3(
            Global.Random.Range(-1f, 1f),
            Global.Random.Range(-1f, 1f),
            Global.Random.Range(-1f, 1f)));
        Debug.DrawRay(transform.position,r.direction);
        RaycastHit hit;
        if (Physics.Raycast(r,out hit) && !c)
        {
            if (hit.collider != null)
            {
                c = hit.collider;
                target = hit.point;
            }
        }
        transform.rotation = Quaternion.LookRotation( -(target-transform.position),transform.up);
        if (c) transform.Translate(new Vector3(0, 0, -15 * Time.deltaTime));
        transform.Translate(new Vector3(
            Global.Random.Range(-0.02f, 0.02f),
            Global.Random.Range(-0.02f, 0.02f),
            Global.Random.Range(-0.02f, 0.02f)));
        if (Vector3.Distance(target,transform.position) < 3 && cistalenemy.dies > 0)
        {

            if (Global.Random.Range(1, 4) == 1)
            {
                c = GameManager.GetPlayer().gameObject.GetComponent<Collider>();
                target = GameManager.GetPlayer().transform.position;

            }
            else
            {


                c = null;
            }
        }
    }
}
