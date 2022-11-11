using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Chat;
using Photon.Realtime;

public class cistalenemy : MonoBehaviour
{
    public int povedenie;
    public float tic, time = 10;
    public Rigidbody rb;
    public Animator anim;
    public float rot;
    public Transform player;
    public float move_speed = 10;
    public float rotation_speed = 100;
    public Transform enemy;
    public bool isbig;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool efinv()
    {
        bool i = true;
        if (playerdata.Geteffect("invisible") != null)
        {
            i = false;

        }
        if (playerdata.Geteffect("invisible") == null)
        {
            i = true;
        }
        return i;
    }
    private void OnCollisionStay(Collision c)
    {
        if (!isbig)
        {


            if (c.collider.tag == "bomb" && ionenergy.energy == 1)
            {
                Destroy(c.collider.gameObject);
                Destroy(gameObject);


            }
            if (c.collider.tag == "bomb" && ionenergy.energy == 0)
            {
                Destroy(c.collider.gameObject);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if (c.collider.tag == "item1")
            {
                Destroy(gameObject);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            }
            if (c.collider.tag == "box1")
            {
                Destroy(gameObject);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            }
        }
            if (c.collider.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("cry", true);
            VarSave.SetBool("��������� �������", true); if (musave.player(c.collider.gameObject))
            {


                musave.chargescene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        tic += Time.deltaTime * Random.Range(1, 3);
        if (tic >= time)
        {
            povedenie = Random.Range(0, 3);
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
            player = musave.isplayer();
            
            povedenie = 4;
        }
        if (povedenie == 3)
        {
            
            transform.rotation = new Quaternion(0, rot, 0, 1);
            transform.Translate(0, 0, 4 * Time.deltaTime);
            if (!GetComponent<AudioSource>().isPlaying)
            {


                GetComponent<AudioSource>().Play();
            }
        }
        if (povedenie == 4 && player != null && efinv())
        {

            var look_dir = player.position - transform.position;
            look_dir.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look_dir), rotation_speed * Time.deltaTime);
            transform.position += transform.forward * move_speed * Time.deltaTime;
            if (!GetComponent<AudioSource>().isPlaying)
            {


                GetComponent<AudioSource>().Play();
            }
        }

    }
}
