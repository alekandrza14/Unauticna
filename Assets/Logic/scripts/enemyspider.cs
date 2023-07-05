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
        if (collision.collider.tag == "box1")
        {
            VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") - 100);
            Destroy(gameObject);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
        }
        if (collision.collider.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("cry", true);
            VarSave.SetBool("страшный паук победил", true);

            if (musave.player(collision.collider.gameObject))
            {


                musave.chargescene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Ray r= new Ray(transform.position,new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)));
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
            Random.Range(-0.02f, 0.02f),
            Random.Range(-0.02f, 0.02f),
            Random.Range(-0.02f, 0.02f)));
        if (Vector3.Distance(target,transform.position) < 3)
        {

            if (Random.Range(1, 4) == 1)
            {
                c = musave.GetPlayer().gameObject.GetComponent<Collider>();
                target = musave.GetPlayer().transform.position;

            }
            else
            {


                c = null;
            }
        }
    }
}
