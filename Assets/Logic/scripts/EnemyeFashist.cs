using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyeFashist : MonoBehaviour
{
    [SerializeField] AudioSource voise;
    [SerializeField] Rigidbody fashist;
    [SerializeField] Transform GunPoint;
    public Collider c;
    System.Random optirand;
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
            Globalprefs.LoadTevroPrise(- 100);
            Destroy(gameObject);
             DeadShit.Spawn(transform.position);
             DeadShit.Spawn(transform.position);
             DeadShit.Spawn(transform.position);
             DeadShit.Spawn(transform.position);
             DeadShit.Spawn(transform.position);
        }
        if (collision.collider.CompareTag("Player") && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("cry", true);
            VarSave.SetBool("Фашист победил", true);



            GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);

        }
    }
    void off()
    {


        if (!attack)
        {
            Debug.Log((float)optirand.Next(-1000, 1000) / 1000f);
            Ray r = new(transform.position, new Vector3(
             (float)optirand.Next(-1000, 1000) / 1000f,
             (float)optirand.Next(-1000, 1000) / 1000f,
            (float)optirand.Next(-1000, 1000) / 1000f));
            Debug.DrawRay(transform.position, r.direction);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                  
                    target = hit.point;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            attack = true;
            voise.Play();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
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
        InvokeRepeating(nameof(off), 1, 10f);
        optirand = new System.Random(7);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (attack && timer >= 0.2)
        {
            if (bullet.safeSpawn == null)
            {
                bullet.safeSpawn = new List<GameObject>();
            }
            if (bullet.safeSpawn.Count < 100)
            {
                bullet.safeSpawn.Add(
                Instantiate(Resources.Load<GameObject>("FashistOrb"), GunPoint.position, transform.rotation));
                timer = 0;
            }
           
                Transform obj = bullet.safeSpawn[optirand.Next(0, bullet.safeSpawn.Count)].transform;
                obj.position = GunPoint.position;
                obj.rotation = transform.rotation;
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                rb.linearVelocity = Vector3.zero;
                rb.MovePosition(obj.position);
                rb.AddForce(transform.forward * obj.GetComponent<bullet>().speed*20, ForceMode.Force);
            timer = 0;

        }
            transform.rotation = Quaternion.LookRotation((target - transform.position), transform.up);

            transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
        transform.Translate(new Vector3(0, 0, 3 * Time.deltaTime));
       
        if (Vector3.Distance(target, transform.position) < 3)
        {

            if (optirand.Next(0, 2) == 1 && attack)
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
