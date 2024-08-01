using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    float timer; string[] massiveEffect = new string[]
    {
        "Undyning",
        "invisible",
        "Axelerate",
        "Vampaire",
        "Regeneration",
        "ImbalenceRegeneration"
    };
    public string s;
    CustomObjectData Model = new CustomObjectData();
   
    void Drop()
    {
       
                s = "Gun" + Global.Random.Range(0, int.MaxValue) + Global.Random.Range(0, int.MaxValue);
               
                    Model = new CustomObjectData();
                    Model.nDemention = NDemention._5D;
                    Model.standartKey = StandartKey.leftmouse;
                    Model.functional = Functional.user;
                    Model.scale = Vector3.one;
                    Model._Color = Color.gray;
                    Model.RegenerateHp = Global.Random.Range(-6, 6);
                    if (Global.Random.Chance(3)) Model.itemSpawn = Map_saver.t3[Global.Random.Range(-1, Map_saver.t3.Length)].name;

                    Model.ObjSpawn = "DamageObject";
                    bool monet = false;
                    if (!Global.Random.determindAll)
                    {
                        while (!monet)
                        {
                            Model.effect_no_use.Add(new useeffect(massiveEffect[Global.Random.Range(0, massiveEffect.Length)], Global.Random.Range(-600000, 6000000)));
                            monet = Global.Random.Range(0, 2) == 1;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            Model.effect_no_use.Add(new useeffect(massiveEffect[Global.Random.Range(0, massiveEffect.Length)], Global.Random.Range(-600000, 6000000)));

                        }

                    }
                    Model.DefultInfo = "Hello im gun item";
                    if (Global.Random.Range(-4, 4) == 0) Model.playerMove = Global.math.randomCube(-2, 2);
                    bool monet2 = false;
                    List<float> fn = new List<float>();
                    if (!Global.Random.determindAll)
                    {
                        while (!monet2)
                        {
                            fn.Add(Global.Random.Range(1, 90));

                            monet2 = Global.Random.Range(0, 2) == 1;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            fn.Add(Global.Random.Range(1, 90));
                        }

                    }
                    
                    Model.NameModel = "Gun";
                    File.WriteAllText("res/UserWorckspace/Items/" + s + ".txt", JsonUtility.ToJson(Model));



                    GameObject g = Instantiate(Resources.Load<GameObject>("CustomObject"), gameObject.transform.position, Quaternion.identity);
                    g.GetComponent<CustomObject>().s = s;
              
            
        
    }
    private void OnCollisionStay(Collision collision)
    {

        fashist.AddForce(Vector3.up * 180, ForceMode.Force);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Logic_tag_DamageObject>())
        {
            Globalprefs.LoadTevroPrise(- 100);
            Destroy(gameObject); Drop();
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
        if (lml2.Find())
        {
            Instantiate(Resources.Load("SEffect/Snayp1"));
            Destroy(gameObject); Drop();
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
        }
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
