using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cistalenemy3 : MonoBehaviour
{
    public int povedenie = 1;
    public float tic, time = 7;
    public float tic2, tic3, time2 = 1;
    public Rigidbody rb;
    public Animator anim;
    public float rot;
    public float hp = 5;
    public Transform player;

    public CharacterName cn;
    public float move_speed = 10;
    public float rotation_speed = 100;
    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {

    }
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
    }
    private void OnCollisionStay(Collision c)
    {
        if (c.collider.GetComponent<Logic_tag_DamageObject>() && hp <= 0)
        {
            Globalprefs.LoadTevroPrise(- 100);
            Destroy(gameObject);
            zaseranie(); cistalenemy.dies++;

            VarSave.SetInt("Agr", cistalenemy.dies);
        }
        if (c.collider.GetComponent<Logic_tag_exploution>() && ionenergy.energy == 0)
        {
            Globalprefs.LoadTevroPrise(- 100);
            zaseranie();
            Destroy(gameObject); cistalenemy.dies++;

            VarSave.SetInt("Agr", cistalenemy.dies);

        }
        if (c.collider.GetComponent<Logic_tag_exploution>() && ionenergy.energy == 1)
        {
            Globalprefs.LoadTevroPrise(- 100);
            Destroy(gameObject); cistalenemy.dies++;

            VarSave.SetInt("Agr", cistalenemy.dies);

        }
        if (c.collider.tag == "errorybox")
        {
            Globalprefs.LoadTevroPrise(- 100);
            Destroy(c.collider.gameObject);
            Destroy(gameObject);
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
        }
        if (c.collider.GetComponent<Logic_tag_DamageObject>() && hp > 0 && tic3 > 0.1f)
        {

            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            DeadShit.Spawn(transform.position);
            player = GameManager.isplayer(); povedenie = 4;
            hp--;
            tic3 = 0;
        }

    }
    public bool efinv()
    {
        bool i = true;
        if (playerdata.Geteffect("invisible") != null)
        {
            i = false;
           
        }
        if(playerdata.Geteffect("invisible") == null)
        {
            i = true;
        }
        return i;
    }

    // Update is called once per frame
    void Update()
    {

        cn.CharactorHpInterface = "Hitpoint : " + "40" + "/" + hp;
        tic += Time.deltaTime * Global.Random.Range(1, 3);
        tic2 += Time.deltaTime * Global.Random.Range(1, 3); 
        tic3 += Time.deltaTime * Global.Random.Range(1, 3);
        if (tic >= time)
        {
            povedenie = (int)Global.Random.Range(0, 8);
            tic = 0;
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
        }
        if (povedenie == 2)
        {
            player = GameManager.isplayer(); povedenie = 4;
        }
        if (povedenie == 3)
        {

            transform.rotation = new Quaternion(0, rot, 0, 1);
            transform.Translate(0, 0, 8 * Time.deltaTime);

        }
        if (povedenie == 5)
        {
            rot = Global.Random.Range(-2.0f, 3f);
            transform.rotation = new Quaternion(0, rot, 0, 1);
            povedenie = 3;
        }
        
        if (povedenie == 7)
        {

            transform.rotation = new Quaternion(0, rot, 0, 1);
            transform.Translate(0, 0, 8 * Time.deltaTime);

        }
        if (povedenie == 4 && player != null && efinv() && cistalenemy.dies > 0)
        {
            if (Vector3.Distance(player.position, enemy.position) < 270)
            {

                var look_dir = player.position - transform.position;
                look_dir.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look_dir), rotation_speed * Time.deltaTime);
                transform.position += transform.forward * move_speed * Time.deltaTime;

                if (tic2 >= time2)
                {
                    Instantiate(Resources.Load("boll"), transform.position, transform.rotation);
                    Instantiate(Resources.Load("boll"), transform.position, transform.rotation);
                    Instantiate(Resources.Load("boll"), transform.position, transform.rotation);
                    tic2 = 0;
                }
            }


        }
    }
    }
