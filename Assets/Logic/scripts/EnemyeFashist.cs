using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyeFashist : MonoBehaviour
{
    [SerializeField] AudioSource voise;
    [SerializeField] Rigidbody fashist;
    [SerializeField] GameObject GunPoint;
    public Collider c;
    Vector3 target;
    bool attack;
    float timer;
    private void OnCollisionStay(Collision collision)
    {

        fashist.AddForce(Vector3.up * 180, ForceMode.Force);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Logic_tag_DamageObject>())
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
            VarSave.SetBool("������ �������", true);



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
            Instantiate(Resources.Load<GameObject>("FashistOrb"),GunPoint.transform.position,transform.rotation);
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