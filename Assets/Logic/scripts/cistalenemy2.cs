using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Chat;
using Photon.Realtime;

public class cistalenemy2 : MonoBehaviour
{
    public int povedenie;
    public float tic, time = 10;
    public Rigidbody rb;
    public Animator anim;
    public float rot;
    public Transform player; public Transform craft; public Transform craft1; public Transform craft2; public Transform craft3;
    public float move_speed = 30;
    public float rotation_speed = 100;
    public Transform enemy;
    public MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        mr.material = Resources.Load<Material>("mats/beloc1");
    }
    private void OnCollisionStay(Collision c)
    {
        if (c.collider.tag == "item1")
        {
            if (craft1 != null)
            {
                Destroy(craft1.gameObject);
                Destroy(c.collider.gameObject);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/bomb"), gameObject.transform.position, Quaternion.identity);
            }
            if (craft2 != null)
            {
                Destroy(craft2.gameObject);
                Destroy(c.collider.gameObject);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity); Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity); Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/bomb"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/ionic_cube"), gameObject.transform.position, Quaternion.identity);
            }
            if (craft1 != null && craft2 != null)
            {
                VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") - 100);
                Destroy(gameObject);
            }
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
        }
        if (c.collider.tag == "box1")
        {
            if (craft1 != null)
            {
                Destroy(craft1.gameObject);
                Destroy(c.collider.gameObject);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/belock"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/belock"), gameObject.transform.position, Quaternion.identity);
            }
            VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") - 1);
            Destroy(gameObject);
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
        }
        if (c.collider.tag == "bl")
        {
            player = c.collider.transform;
            povedenie = 5;
        }
        if (c.collider.tag == "jk")
        {
            player = c.collider.transform;
            craft3 = c.collider.transform;
            povedenie = 5;
        }
        if (c.collider.tag == "swamppig")
        {
            craft1 = c.collider.transform;
            mr.material = Resources.Load<Material>("mats/beloc2");

        }
        if (c.collider.tag == "booble")
        {
            craft = c.collider.transform;
            mr.material = Resources.Load<Material>("mats/beloc2");

        }
        if (c.collider.tag == "gold")
        {
            if (craft != null)
            {
                craft2 = c.collider.transform;
                mr.material = Resources.Load<Material>("mats/beloc3");
            }

        }

    }

    // Update is called once per frame
    void Update()
    {


        if (povedenie == 5 && player != null)
        {
            if (Vector3.Distance(player.position, enemy.position) < 6)
            {

                var look_dir = player.position - transform.position;
                look_dir.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look_dir), rotation_speed * Time.deltaTime);
                transform.position += transform.forward * move_speed * Time.deltaTime / 2;


            }


        }
        if (craft3 != null)
        {
            if (Vector3.Distance(craft3.position, enemy.position) < 6)
            {

                var look_dir = craft3.position - transform.position;
                look_dir.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look_dir), rotation_speed * Time.deltaTime);
                transform.position += transform.forward * move_speed * Time.deltaTime *2;


            }


        }
    }
}
