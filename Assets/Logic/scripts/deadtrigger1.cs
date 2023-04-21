using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deadtrigger1 : MonoBehaviour
{
    public Animator anim;
    public bool stop;
    public Vector3 pos;
    // Start is called before the first frame update
    void Awake()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pos;
        if (stop)
        {
            anim.SetBool("New Bool", false);
            stop = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !stop && !Input.GetKey(KeyCode.G))
        {
            anim.SetBool("New Bool", true);
            
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" && !Input.GetKey(KeyCode.G))
        {
            VarSave.SetBool("cry", true);
            VarSave.SetBool("подъездный маг победил", true);

            if (musave.player(collision.collider.gameObject))
            {


                musave.chargescene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
