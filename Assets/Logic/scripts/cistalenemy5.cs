using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cistalenemy5 : MonoBehaviour
{
    public int povedenie;
    public float tic, time = 10;
    public Rigidbody rb;
    public Animator anim;
    public float rot;
    public Transform player; public Transform craft; public Transform craft1;
    public float move_speed = 30;
    public float rotation_speed = 100;
    public Transform enemy;
    public MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        mr.material = Resources.Load<Material>("UF/jeltok");
    }
    private void OnCollisionStay(Collision c)
    {


        if (c.collider.tag == "bl" && craft1)
        {
            

            povedenie = 5;
        }
        if (c.collider.tag == "bl" && craft)
        {
            craft1 = c.collider.transform;

            povedenie = 7;
        }
        if (c.collider.tag == "bl" && !player)
        {
            GetComponent<Rigidbody>().linearVelocity = new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), Random.Range(-10, 11));
            player = c.collider.transform;
            povedenie = 5;
        }
        if (c.collider.tag == "bl" && player)
        {
            craft = c.collider.transform;

            povedenie = 6;
        }
        


    }

    // Update is called once per frame
    void Update()
    {


        if (povedenie == 5 && player != null)
        {
            if (Vector3.Distance(player.position, enemy.position) < 6)
            {

                player.GetComponent<cistalenemy2>().player = transform;
                

                var look_dir = player.position - transform.position;
                look_dir.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(look_dir), rotation_speed * Time.deltaTime);
                transform.position -= transform.forward * move_speed * Time.deltaTime *5;
            }


        }
        if (povedenie == 6 && craft != null)
        {
            if (Vector3.Distance(craft.position, enemy.position) < 6)
            {

                craft.GetComponent<cistalenemy2>().player = transform;
                

            }


        }
        if (povedenie == 7 && craft1 != null)
        {
            if (Vector3.Distance(craft1.position, enemy.position) < 6)
            {


                craft1.GetComponent<cistalenemy2>().player = transform; craft.GetComponent<cistalenemy2>().player = transform;
                

            }


        }
    }
}
