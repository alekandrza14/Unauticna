using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum vector{
    up,down,right,left,zero
}

public class spamton : MonoBehaviour
{
    public int povedenie;
    public float tic, time = 10;
    public float speed=6;
    public Rigidbody rb;
    public Animator anim;
    public float rot;
    public GameObject tho;
    public bool  up, down, right, left;
    public bool higamer;
    public deldialog del;
    public string[] s;
    public string sm;
    public string[] se;
    public string sme;
    public string[] su;
    public string smu;
    public string text;
    public string bol;
    public bool iznendial;

    public bool fisttalk;
    public bool rayMarch;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnCollisionStay(Collision c)
    {
        if (c.collider.tag == "item1")
        {
            Destroy(gameObject);

        }
    }

    public void delete()
    {
        Destroy(gameObject);
    }
    public void contact()
    {
        higamer = false;
        VarSave.SetBool("spamton_contact",true);
    }
    // Update is called once per frame
    void Update()
    {
        if (true)
        {


            up = false;
            down = false;
            right = false;
            left = false;
        }
        Ray r = new Ray(transform.position + (transform.right * 2), (transform.right * 2) - transform.up);
        Debug.DrawRay(transform.position + (transform.right * 2), (transform.right * 2) + (-transform.up * 80));
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            if (hit.collider != null)
            {
                right = true;
            }
        }
        Ray r2 = new Ray(transform.position + (-transform.right * 2), (-transform.right * 2)  -transform.up);
        RaycastHit hit2;
        if (Physics.Raycast(r2, out hit2))
        {
            if (hit2.collider != null)
            {
                left = true;
            }
        }
        Ray r3 = new Ray(transform.position + (transform.forward * 2), (transform.forward * 2)  -transform.up);
        RaycastHit hit3;
        if (Physics.Raycast(r3, out hit3))
        {
            if (hit3.collider != null)
            {
               up = true;
            }
        }
        Ray r4 = new Ray(transform.position + (-transform.forward * 2), (-transform.forward * 2) - transform.up);
        RaycastHit hit4;
        if (Physics.Raycast(r4, out hit4))
        {
            if (hit4.collider != null)
            {
                down = true;
            }
        }
        if (!rayMarch)
        {


            if (!up)
            {
                povedenie = 1;
                transform.position -= Vector3.forward * 5 * Time.deltaTime;
            }
            if (!down)
            {
                povedenie = 1;
                transform.position -= Vector3.back * 5 * Time.deltaTime;
            }
            if (!right)
            {
                povedenie = 1;
                transform.position -= Vector3.right * 5 * Time.deltaTime;
            }
            if (!left)
            {
                povedenie = 1;
                transform.position -= Vector3.left * 5 * Time.deltaTime;
            }
        }
       
        if (tho)
        {


            tho.transform.position = anim.transform.position;

        } tic += Time.deltaTime * Random.Range(1,3);
        if(tic >= time)
        {
            povedenie = Random.Range(0, 2);
            tic=0;

        }
        if (higamer)
        {
            if (VarSave.GetBool(bol) == !iznendial)
            {
                del.s = s;
                del.sm = sm;
                del.se = se;
                del.sme = sme;
                del.se = su;
                del.sme = smu;
                del.text.text = text;
            }
            if (Vector3.Distance(transform.position, musave.GetPlayer().position) < 30)
            {
                Vector3 v3 = musave.GetPlayer().position;
                float dist = Vector3.Distance(transform.position, new Vector3(v3.x, transform.position.y, v3.z));
                Vector3 dir = (new Vector3(v3.x, transform.position.y, v3.z) - transform.position) / dist;
                transform.rotation = Quaternion.LookRotation(dir);
                
            }
            if (Vector3.Distance(transform.position,musave.GetPlayer().position) >5 && Vector3.Distance(transform.position, musave.GetPlayer().position) < 30)
            {
                float dist = Vector3.Distance(transform.position, musave.GetPlayer().position);
                Vector3 dir = (musave.GetPlayer().position - transform.position) / dist;
                anim.Play("spamton_walke");
                transform.position += dir * speed * Time.deltaTime;
                
                povedenie = 3;
                    if (del.enter)
                    {
                        contact();
                    }
                
            }
            if (Vector3.Distance(transform.position, musave.GetPlayer().position) < 5)
            {
                
                anim.Play("spamton_stay");
            }
        }
        if (Vector3.Distance(transform.position, musave.GetPlayer().position) < 5 && VarSave.GetBool("spamton_contact") == true)
        {
            Vector3 v3 = musave.GetPlayer().position;
            float dist = Vector3.Distance(transform.position, new Vector3(v3.x, transform.position.y, v3.z));
            Vector3 dir = (new Vector3(v3.x, transform.position.y, v3.z) - transform.position) / dist;
            transform.rotation = Quaternion.LookRotation(dir);
            tic = 0;
            povedenie = 0;
        }
        if (povedenie == 0)
        {

            anim.Play("spamton_stay");
        }
        if (povedenie == 3)
        {
            if (!higamer)
            {
                povedenie = 0;

            }
            
        }
        if (povedenie == 1)
        {
            rot = Random.Range(-2.0f, 3f);
            transform.Rotate(0, rot * 180, 0);
            povedenie = 2;
            anim.Play("spamton_stay");

        }
        if (povedenie == 2)
        {
            anim.Play("spamton_walke");
            
            transform.Translate(0,0,4*Time.deltaTime);
        }
    }
}
