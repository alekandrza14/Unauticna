using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PovidLFT
{
    safety,
    Ploty,
    Dory,
    spat,
    RandomRun
}
public class lIFE_file : MonoBehaviour
{
    public float randomAPovid;
    public float randomBPovid;
    public float randomCPovid;
    public float randomDPovid;
    GameObject eat;
    GameObject atak;
    public GameObject salut;
    public Animator anim;
    public PovidLFT lF;

    private void OnCollisionStay(Collision collision)
    {
        if (lF == PovidLFT.Ploty)
        {
            if (eat != null)
            {
                if (eat == collision.collider.gameObject)
                {
                    randomAPovid = 0;
                    randomBPovid = 0;
                    anim.SetBool("run", false);
                    lF = PovidLFT.spat;
                    anim.SetBool("run", false);
                    Destroy(eat);
                }
            }
        }
        if (collision.collider.GetComponent<itemName>())
        {
            randomAPovid += Global.Random.Range(0, 0.01f);
            randomBPovid += Global.Random.Range(0, 0.1f);
            if (eat == null) eat = collision.collider.gameObject;
        }
        if (collision.collider.GetComponent<mover>())
        {
            if (eat == null) eat = collision.collider.gameObject;
            randomAPovid += Global.Random.Range(0, 0.1f);
            randomBPovid += Global.Random.Range(0, 0.05f);
            atak = collision.collider.gameObject;
        }
        if (collision.collider.GetComponent<Logic_tag_DamageObject>())
        {
            randomAPovid += Global.Random.Range(0, 0.1f);
            atak = collision.collider.gameObject;
        }
        if (collision.collider.GetComponent<Logic_tag_exploution>())
        {
            randomAPovid += Global.Random.Range(0, 0.1f);
            atak = collision.collider.gameObject;
        }
        if (collision.collider.GetComponent<Logic_tag_Equepment>())
        {
            randomAPovid += Global.Random.Range(0, 0.1f);
            atak = collision.collider.gameObject;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<itemName>())
        {
          if(eat == null)  eat = other.gameObject;
           randomAPovid += Global.Random.Range(0, 0.01f);
            randomBPovid += Global.Random.Range(0, 0.1f);
        }
    }
    private void OnMouseDrag()
    {
        randomAPovid += Global.Random.Range(0,0.1f);
        randomDPovid += Global.Random.Range(0, 0.1f);
        atak = mover.main().PlayerBody;
    }

    // Start is called before the first frame update
    void Start()
    {

        randomAPovid += Global.Random.Range(0, 4f);
        randomBPovid += Global.Random.Range(0, 5f);
        randomCPovid += Global.Random.Range(0, 3f);
        randomDPovid += Global.Random.Range(0, 4f);
    }

    // Update is called once per frame
    void Update()
    {

        if(randomCPovid > 1) randomCPovid += Global.Random.Range(0, 0.001f);
        if (randomBPovid > 3) randomBPovid += Global.Random.Range(0, 0.01f);
        if (lF != PovidLFT.RandomRun) randomDPovid += Global.Random.Range(0, 0.01f);
        if (lF != PovidLFT.safety) if (randomAPovid > 5)
            {
                anim.SetBool("run", true);
                lF = PovidLFT.safety;
        }
        if (lF != PovidLFT.Ploty) if (randomBPovid > 25)
            {
                anim.SetBool("run", true);
                lF = PovidLFT.Ploty;
        }
        if (lF != PovidLFT.Dory) if (randomCPovid > 5)
            {

                lF = PovidLFT.Dory;
            }
        if (lF != PovidLFT.RandomRun) if (randomDPovid > 7)
            {
                transform.rotation = Random.rotationUniform;
                anim.SetBool("run", true);
                lF = PovidLFT.RandomRun;
                
            }

        if (lF == PovidLFT.Dory) if (
            randomCPovid < 1 )
            {
                anim.SetBool("run", false);
                lF = PovidLFT.spat;
        }
        if (lF == PovidLFT.Ploty)
        {
            if (eat != null)
            {
                randomBPovid += Global.Random.Range(0, 0.05f);
            }
            if (eat == null)
            {
                anim.SetBool("run", false);
                lF = PovidLFT.spat; randomBPovid -= Global.Random.Range(0, 0.2f);
            }
            if (eat != null)
            {
                transform.rotation = Quaternion.LookRotation(eat.transform.position - transform.position, Vector3.up);
                transform.Translate(0, 0, 20 * Time.deltaTime);
                
            }
            randomBPovid -= Global.Random.Range(0, 0.2f);
        }
        if (lF == PovidLFT.safety)
        {
            if (randomAPovid < 0)
            {
                anim.SetBool("run", false);
                lF = PovidLFT.spat;
            }

            if (atak != null)
            {
                transform.rotation = Quaternion.LookRotation(atak.transform.position - transform.position, Vector3.up);
                transform.Translate(0, 0, 20 * Time.deltaTime);

                randomAPovid -= Global.Random.Range(0, 0.2f);
            }
            if (atak == null)
            {
                anim.SetBool("run", false);
                randomAPovid -= Global.Random.Range(0, 0.2f);

            }
            randomAPovid -= Global.Random.Range(0, 0.2f);
        }
        if (lF == PovidLFT.RandomRun)
        {
            if (randomDPovid < 0)
            {
                if (Global.Random.Range(0, 10.0f) < 0.5f)
                {
                   
                        anim.SetBool("run", false);
                        lF = PovidLFT.spat;
                   
                }
                else
                {
                    transform.rotation = Random.rotationUniform;
                    randomDPovid += Global.Random.Range(0, 8f);
                }
            }
                transform.Translate(0, 0, 5 * Time.deltaTime);

          
            randomDPovid -= Global.Random.Range(0, 0.2f);
        }
        if (lF == PovidLFT.Dory)
        {
            salut.SetActive(true);
            transform.rotation = Random.rotationUniform;
            transform.Translate(0, 0, 20 * Time.deltaTime);
            randomCPovid -= Global.Random.Range(0, 0.2f);
        }
        else
        {

            salut.SetActive(false);
        }
    }
}
