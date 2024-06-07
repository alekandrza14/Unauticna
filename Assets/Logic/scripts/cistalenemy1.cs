using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cistalenemy1 : MonoBehaviour
{
    public int povedenie;
    public float tic, time = 10; 
    public float tic2, time2 = 1;
    public Rigidbody rb;
    public Animator anim;
    public float rot;
    public Transform player;
    public float move_speed = 10;
    public float rotation_speed = 100;
    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionStay(Collision c)
    {
        if (c.collider.GetComponent<Logic_tag_exploution>() && ionenergy.energy == 1)
        {

            Globalprefs.LoadTevroPrise(- 100);
            Destroy(gameObject); cistalenemy.dies++;

            VarSave.SetInt("Agr", cistalenemy.dies);
        }
        if (c.collider.GetComponent<Logic_tag_exploution>() && ionenergy.energy == 0)
        {
            Globalprefs.LoadTevroPrise(- 100);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            Destroy(gameObject); cistalenemy.dies++;

            VarSave.SetInt("Agr", cistalenemy.dies);
        }
        if (c.collider.GetComponent<Logic_tag_DamageObject>())
        {
            Globalprefs.LoadTevroPrise(- 100);
            Destroy(gameObject);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position); cistalenemy.dies++;

            VarSave.SetInt("Agr", cistalenemy.dies);
        }
        if (c.collider.GetComponent<Logic_tag_DamageObject>())
        {
            Globalprefs.LoadTevroPrise(- 100);
            Destroy(gameObject);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position); cistalenemy.dies++;

            VarSave.SetInt("Agr", cistalenemy.dies);
        }
        if (c.collider.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("cry", true);
            VarSave.SetBool("×ÅÐÂßØ ïîáåäèë", true);
         


                GameManager.chargescene(SceneManager.GetActiveScene().buildIndex);
         
        }   
    }

    // Update is called once per frame
    void Update()
    {
        tic += Time.deltaTime * Global.Random.Range(1, 3);
        tic2 += Time.deltaTime * Global.Random.Range(1, 3);
        if (tic >= time)
        {
            povedenie = (int)Global.Random.Range(0, 3);
            tic = 0;
            anim.SetInteger("run", povedenie);
        }
        if (povedenie == 0)
        {
            transform.rotation = new Quaternion(0, rot, 0, 1);
            
        }
        if (povedenie == 1)
        {
            rot = Global.Random.Range(-2.0f, 3f);
            transform.rotation = new Quaternion(0, rot, 0, 1);
            povedenie = 3;

            anim.SetInteger("run", povedenie);
        }
        if (povedenie == 2)
        {
            player = GameManager.isplayer(); povedenie = 4;
            anim.SetInteger("run", povedenie);
        }
        if (povedenie == 3)
        {
            
            transform.rotation = new Quaternion(0, rot, 0, 1);
            transform.Translate(0, 0, 4 * Time.deltaTime);
            
        }
        if (povedenie == 4 && player != null && cistalenemy.dies > 0)
        {
            if (Vector3.Distance(player.position, enemy.position) < 15)
            {

                var look_dir = player.position - transform.position;
                look_dir.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look_dir), rotation_speed * Time.deltaTime);
                transform.position += transform.forward * move_speed * Time.deltaTime;

                if (tic2 >= time2)
                {
                    Instantiate(Resources.Load("fire"), transform.position, transform.rotation);
                    tic2 = 0;
                }
            }


        }
    }
    }
