using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ionenergy
{
   static public int energy;
}

public class cistalenemy4 : MonoBehaviour
{
    public int povedenie = 1;
    public float tic, time = 7; 
    public float tic2, tic3, time2 = 1;
    public Rigidbody rb;
    public Animator anim;
    public float rot;
    public float hp = 500;
    public Transform player;
    public float move_speed = 10;
    public float rotation_speed = 100;
    public Transform enemy;
    public CharacterName cn;
    public Vector3 v3;
    // Start is called before the first frame update
    void Start()
    {
        v3 = transform.position;
    }
    void dies()
    {
        VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") - 100);
        VarSave.SetInt("dies-zellotton",1);
        Destroy(gameObject);
    }
    private void OnCollisionStay(Collision c)
    {
        if (c.collider.tag == "item1" && hp <= 0)
        {
            dies();
            for (int i = 0; i < 250; i++)
            {


                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            }

        }

        if (c.collider.tag == "bomb" && hp <= 0&& ionenergy.energy == 0)
        {
            Destroy(c.collider.gameObject);
            dies();
            for (int i = 0; i < 250; i++)
            {


                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            }
        } if (c.collider.tag == "bomb" && hp <= 0&& ionenergy.energy == 1)
        {
            Destroy(c.collider.gameObject);
            dies();
            
        }
        if (c.collider.tag == "errorybox")
        {
            Destroy(c.collider.gameObject);
            dies();
            for (int i = 0; i < 250; i++)
            {


                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            }
        }
        if (c.collider.tag == "item1" && hp > 0 && tic3 > 0.1f)
        {

            for (int i = 0; i < 25; i++)
            {


                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            }
            player = GameManager.isplayer(); povedenie = 4;
            hp--;
            tic3 = 0;
        }
        if (c.collider.tag == "bomb" && hp > 0 && tic3 > 0.1f&& ionenergy.energy == 0)
        {

            for (int i = 0; i < 60; i++)
            {


                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            }
            player = GameManager.isplayer(); povedenie = 4;
            hp -= 10;
            tic3 = 0;
        }
        if (c.collider.tag == "bomb" && ionenergy.energy == 1&& tic3 > 0.1f)
        {

            
            player = GameManager.isplayer(); povedenie = 4;
            hp -= 100;
            tic3 = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        cn.CharactorHpInterface = "Hitpoint : "+ "50" + "/"+hp;
        tic += Time.deltaTime * Random.Range(1, 3);
        tic2 += Time.deltaTime * Random.Range(1, 3); 
        tic3 += Time.deltaTime * Random.Range(1, 3);
        if (v3.y - 100 > transform.position.y)
        {
            dies();


        }
        if (tic >= time)
        {
            povedenie = Random.Range(0, 8);
            tic = 0;
        }
        if (povedenie == 0)
        {
            transform.rotation = new Quaternion(0, rot, 0, 1);
            
        }
        if (povedenie == 1)
        {
            rot = Random.Range(-2.0f, 3f);
            transform.rotation = new Quaternion(0, rot, 0, 1);
            povedenie = 3;
        }
        if (povedenie == 2)
        {
            player = GameManager.isplayer(); povedenie = 4;
        }
        if (povedenie == 3)
        {
            tic += Time.deltaTime * Random.Range(1, 3);
            transform.rotation = new Quaternion(0, rot, 0, 1);
            transform.Translate(0, 0, 8 * Time.deltaTime);

        }
        if (povedenie >= 4 && povedenie <= 7 && player == null)
        {
            povedenie = 2;
        }
        if (povedenie >= 4 && povedenie <= 7 && player != null)
        {


            var look_dir = player.position - transform.position;
            look_dir.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look_dir), rotation_speed * Time.deltaTime);
            transform.position += transform.right * move_speed * Time.deltaTime;

            if (tic2 >= time2)
            {
                Instantiate(Resources.Load("ztBullet"), transform.position, transform.rotation);

                tic2 = 0;
            }



        }
        if (povedenie >= 6 && povedenie <= 7 && player != null)
        {


            Instantiate(Resources.Load<GameObject>("attaks/zt"), GameObject.FindGameObjectsWithTag("Player")[Random.Range(0, GameObject.FindGameObjectsWithTag("Player").Length)].transform.position, Quaternion.identity); 
            Instantiate(Resources.Load<GameObject>("attaks/zt1"), GameObject.FindGameObjectsWithTag("Player")[Random.Range(0, GameObject.FindGameObjectsWithTag("Player").Length)].transform.position, Quaternion.identity);
            player = GameManager.isplayer(); povedenie = 4;


        }
    }
    }
