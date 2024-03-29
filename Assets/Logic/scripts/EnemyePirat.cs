using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyePirat : MonoBehaviour
{
    [SerializeField] AudioSource voise;
    [SerializeField] Rigidbody fashist;
    [SerializeField] GameObject GunPoint;
    public Collider c;
    Vector3 target;
    bool attack;
    float timer;

    Vector3 v3;
    private void OnCollisionStay(Collision collision)
    {

        fashist.AddForce(Vector3.up * 180, ForceMode.Force);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Logic_tag_DamageObject>())
        {
            Globalprefs.LoadTevroPrise(- 100);
            Destroy(gameObject);
         
        }
        if (collision.collider.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("cry", true);
            VarSave.SetBool("Фашист победил", true);



            GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);

        }
    }
    void off()
    {

        c = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            attack = true;
            voise.Play();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Random.Range(1, 5) == 1 && attack)
            {
                c = GameManager.GetPlayer().gameObject.GetComponent<Collider>();
                target = GameManager.GetPlayer().transform.position;

            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("off", 1, 10f );
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
       if(attack && timer >= 0.2)
        {
            Instantiate(Resources.Load<GameObject>("PiratOrb"),GunPoint.transform.position,transform.rotation);
            timer = 0;
        }
        Ray r = new Ray(transform.position, new Vector3(
         Random.Range(-1f, 1f),
         Random.Range(-1f, 1f),
         Random.Range(-1f, 1f)));
        Debug.DrawRay(transform.position, r.direction);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit) && !c)
        {
            if (hit.collider != null)
            {
                c = hit.collider;
                target = hit.point;
            }
        }
        Ray r2 = new Ray(transform.position, Vector3.down);
       
        RaycastHit hit2;
        if (Physics.Raycast(r2, out hit2))
        {
            if (hit2.collider != null)
            {
                fashist.useGravity = true;
            }
           else
            {
                fashist.useGravity = false;
                fashist.AddForce(Vector3.up,ForceMode.Impulse);
            }
        }
        else
        {
            fashist.useGravity = false;
            fashist.AddForce(Vector3.up, ForceMode.Impulse);
        }
        transform.rotation = Quaternion.LookRotation((target - transform.position), transform.up);

        transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
        
        if (c) transform.Translate(new Vector3(0, 0, 3 * Time.deltaTime));
        transform.Translate(new Vector3(
            Random.Range(-0.02f, 0.02f),
            Random.Range(-0.02f, 0.02f),
            Random.Range(-0.02f, 0.02f)));
        if (Vector3.Distance(target, transform.position) < 3) 
        {

            if (Random.Range(1, 2) == 1 && attack)
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
