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
    public bool mage;
    public bool oman;
    public bool scam;
    public bool cum;
    bool kidat;

    public bool fisttalk;
    public bool rayMarch;
    // Start is called before the first frame update
    void Start()
    {
        if (Global.Random.Chance(20))
        {

            Instantiate(Resources.Load<GameObject>("items/Смачный_плевок_Спамтона"),transform.position,Quaternion.identity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<mover>() && (mage||oman))
        {
            Instantiate(Resources.Load<GameObject>("camGameOver/worker"), other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
        if (other.GetComponent<mover>() && cum)
        {
            kidat = true;
        }
        if (other.GetComponent<CharacterName>() && (mage || oman))
        {
            Instantiate(Resources.Load<GameObject>("Morfs/worker"), other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<mover>() && cum)
        {
            kidat = false;
        }
    }
    private void OnCollisionStay(Collision c)
    {
        if (c.collider.GetComponent<Logic_tag_DamageObject>())
        {
            Globalprefs.LoadTevroPrise(- 100);
            if (VarSave.ExistenceVar("CapiKill"))
            {
                VarSave.LoadInt("CapiKill", 1);
            }
            Destroy(gameObject);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);

        }
    }
    bool game;
    private void OnMouseDown()
    {
        if (!game && (scam||oman))
        {
            List<GameObject> red = new();
            red.Add(Instantiate(Resources.Load<GameObject>("items/Card"), transform.position, Quaternion.identity));
            red.Add(Instantiate(Resources.Load<GameObject>("items/Card"), transform.position, Quaternion.identity));
            red.Add(Instantiate(Resources.Load<GameObject>("items/Card"), transform.position, Quaternion.identity));
            red.Add(Instantiate(Resources.Load<GameObject>("items/Card"), transform.position, Quaternion.identity));
            red.Add(Instantiate(Resources.Load<GameObject>("items/Card"), transform.position, Quaternion.identity));

            List<GameObject> blue = new();
            blue.Add(Instantiate(Resources.Load<GameObject>("items/Card"), mover.main().transform.position, Quaternion.identity));
            blue.Add(Instantiate(Resources.Load<GameObject>("items/Card"), mover.main().transform.position, Quaternion.identity));
            blue.Add(Instantiate(Resources.Load<GameObject>("items/Card"), mover.main().transform.position, Quaternion.identity));
            blue.Add(Instantiate(Resources.Load<GameObject>("items/Card"), mover.main().transform.position, Quaternion.identity));
            blue.Add(Instantiate(Resources.Load<GameObject>("items/Card"), mover.main().transform.position, Quaternion.identity));
            if (!Global.Random.determindAll)
            {
                foreach (GameObject item in blue)
                {
                    Card pl_card = item.GetComponent<Card>();
                    pl_card.red_blue = false;
                    pl_card.pover = Random.Range(-1, 11);
                }
                foreach (GameObject item in red)
                {

                    Card sc_card = item.GetComponent<Card>();
                    sc_card.red_blue = true;
                    sc_card.pover = Random.Range(-1, 11);
                }
            }
            else
            {
                blue[0].GetComponent<Card>().red_blue = false;
                blue[1].GetComponent<Card>().red_blue = false;
                blue[2].GetComponent<Card>().red_blue = false;
                blue[3].GetComponent<Card>().red_blue = false;
                blue[4].GetComponent<Card>().red_blue = false;
                blue[0].GetComponent<Card>().pover = -1;
                blue[1].GetComponent<Card>().pover = 1;
                blue[2].GetComponent<Card>().pover = 4;
                blue[3].GetComponent<Card>().pover = 7;
                blue[4].GetComponent<Card>().pover = 10;
                red[0].GetComponent<Card>().red_blue = true;
                red[1].GetComponent<Card>().red_blue = true;
                red[2].GetComponent<Card>().red_blue = true;
                red[3].GetComponent<Card>().red_blue = true;
                red[4].GetComponent<Card>().red_blue = true;
                red[0].GetComponent<Card>().pover = -1;
                red[1].GetComponent<Card>().pover = 1;
                red[2].GetComponent<Card>().pover = 4;
                red[3].GetComponent<Card>().pover = 7;
                red[4].GetComponent<Card>().pover = 10;
            }
            game = true;
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
    bool kid;
    public void Kammen()
    {
        GameObject g = Resources.Load<GameObject>("Items/Каменьщикоый_камень");
        Instantiate(g, mover.main().transform.position + (Vector3.up * 3), Quaternion.identity);
        GameObject g3 = Resources.Load<GameObject>("voices/юха");
        Instantiate(g3, (Vector3.up), Quaternion.identity); kid = false;
    }
    public void Admmen()
    {
        GameObject g = Resources.Load<GameObject>("Items/РекламаАрмии");
        Instantiate(g, mover.main().transform.position + (Vector3.up * 3), Quaternion.identity);
        GameObject g3 = Resources.Load<GameObject>("voices/юха");
        Instantiate(g3, (Vector3.up), Quaternion.identity); kid = false;
    }
    // Update is called once per frame
    void Update()
    {
        if ((lml2.Find()&&mage)|| (lml2.Find() && cum))
        {
            Instantiate(Resources.Load("SEffect/Snayp1"));
            Destroy(gameObject);
        }
       
        if (oman && !kid)
        {
            Invoke("Kammen", 3);
            Invoke("Admmen", 3);
            kid = true;
        }
        if (FindObjectsByType<Card>(sortmode.main).Length<=0)
        {
            game = false;
        }
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
                transform.position -= transform.forward * 5 * Time.deltaTime;
            }
            if (!down)
            {
                povedenie = 1;
                transform.position -= -transform.forward * 5 * Time.deltaTime;
            }
            if (!right)
            {
                povedenie = 1;
                transform.position -= transform.right * 5 * Time.deltaTime;
            }
            if (!left)
            {
                povedenie = 1;
                transform.position -= -transform.right * 5 * Time.deltaTime;
            }

        }
       
        if (tho)
        {


            tho.transform.position = anim.transform.position;

        } tic += Time.deltaTime * Global.Random.Range(1,3);
        if(tic >= time)
        {
            povedenie = (int)Global.Random.Range(0, 2);
            tic=0;

        }
        if (higamer)
        {
            if (VarSave.GetBool(bol) == false)
            {
                del.s = s;
                del.sm = sm;
                del.se = se;
                del.sme = sme;
                del.se = su;
                del.sme = smu;
                del.text.text = text;
            }
            if (Vector3.Distance(transform.position, GameManager.GetPlayer().position) < 30)
            {
                Vector3 v3 = GameManager.GetPlayer().position;
                float dist = Vector3.Distance(transform.position, new Vector3(v3.x, transform.position.y, v3.z));
                Vector3 dir = (new Vector3(v3.x, transform.position.y, v3.z) - transform.position) / dist;
                transform.rotation = Quaternion.LookRotation(dir);
                
            }
            if (Vector3.Distance(transform.position,GameManager.GetPlayer().position) >5 && Vector3.Distance(transform.position, GameManager.GetPlayer().position) < 30)
            {
                float dist = Vector3.Distance(transform.position, GameManager.GetPlayer().position);
                Vector3 dir = (GameManager.GetPlayer().position - transform.position) / dist;
                anim.Play("spamton_walke");
                transform.position += dir * speed * Time.deltaTime;
                
                povedenie = 3;
                    if (del.enter)
                    {
                        contact();
                    }
                
            }
            if (Vector3.Distance(transform.position, GameManager.GetPlayer().position) < 5)
            {
                
                anim.Play("spamton_stay");
            }
        }
        if (Vector3.Distance(transform.position, GameManager.GetPlayer().position) < 5 && VarSave.GetBool("spamton_contact") == true)
        {
            Vector3 v3 = GameManager.GetPlayer().position;
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
            rot = Global.Random.Range(-2.0f, 3f);
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
