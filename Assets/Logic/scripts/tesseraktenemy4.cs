using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tesseraktenemy4 : MonoBehaviour
{
    public int povedenie;
    public float tic = 9, time = 10;
    public Rigidbody rb;
    public Animator anim;
    public float rot; public float rotx; public float roty; public float rotz;
    public Transform player;
    public float move_speed = 10;
    public float rotation_speed = 100;
    public Transform enemy;
    public bool tes;
 
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
            transform.rotation = new Quaternion(rotx, roty, rotz, rot);

        }
        if (povedenie == 1)
        {
            rot = Random.Range(-2.0f, 3f);
            rotx = Random.Range(-2.0f, 3f);
            roty = Random.Range(-2.0f, 3f);
            rotz = Random.Range(-2.0f, 3f);
            player = GameManager.isplayer();
            transform.rotation = new Quaternion(rotx, roty, rotz, rot);
            povedenie = 3;
            

        }
        if (povedenie == 2)
        {
            player = GameManager.isplayer();
            
            povedenie = 4;
        }
        if (povedenie == 3)
        {

            transform.rotation = new Quaternion(rotx, roty, rotz, rot);
            
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position += new Vector3(move_speed * Time.deltaTime * Random.Range(-1.0f, 1.001f),0, move_speed * Time.deltaTime * Random.Range(-1.0f, 1.001f));

            if (!GetComponent<AudioSource>().isPlaying)
            {


                GetComponent<AudioSource>().Play();
            }
        }
        

    }
}
