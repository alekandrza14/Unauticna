using UnityEngine;

public class Попрашайка : MonoBehaviour
{
    public float randomAPovid;
    public float randomBPovid;
    public float randomCPovid;
    public float randomDPovid;
    GameObject eat;
    GameObject atak;
    public Animator anim;
    public float timer;
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
                    //   anim.SetBool("run", false);
                    lF = PovidLFT.spat;
                    //   anim.SetBool("run", false);
                    if (timer > 3)
                    {
                        Instantiate(Resources.Load<GameObject>("voices/кусь"));
                        if (eat.GetComponent<mover>())
                        {
                            eat.GetComponent<mover>().hp -= 1;
                        }
                        timer = 0;
                    }
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
        }
        if (collision.collider.GetComponent<Logic_tag_DamageObject>())
        {
            randomAPovid += Global.Random.Range(0, 0.1f);
            eat = collision.collider.gameObject;
        }
        if (collision.collider.GetComponent<Logic_tag_exploution>())
        {
            randomAPovid += Global.Random.Range(0, 0.1f);
            eat = collision.collider.gameObject;
        }
        if (collision.collider.GetComponent<Logic_tag_Equepment>())
        {
            randomAPovid += Global.Random.Range(0, 0.1f);
            eat = collision.collider.gameObject;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<itemName>())
        {
            if (eat == null) eat = other.gameObject;
            randomAPovid += Global.Random.Range(0, 0.01f);
            randomBPovid += Global.Random.Range(0, 0.1f);
        }
    }
    private void OnMouseDrag()
    {
        randomAPovid += Global.Random.Range(0, 0.1f);
        randomDPovid += Global.Random.Range(0, 0.1f);
        eat = mover.main().PlayerBody;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Попрошайничество", 0, 5);
    }
    void Попрошайничество()
    {

        Instantiate(Resources.Load<GameObject>("voices/ппрш"));
    }
    // Update is called once per frame
    void Update()
    {
        Ray r2 = new Ray(transform.position, Vector3.down);

        RaycastHit hit2;
        if (Physics.Raycast(r2, out hit2))
        {
            if (hit2.collider != null)
            {
                GetComponent<Rigidbody>().useGravity = true;
            }
            else
            {
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
            }
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
        }
        randomAPovid += Global.Random.Range(0, 0.2f);
        timer += Time.deltaTime;
        if (randomCPovid > 1) randomCPovid += Global.Random.Range(0, 0.001f);
        if (randomBPovid > 3) randomBPovid += Global.Random.Range(0, 0.01f);
        if (lF != PovidLFT.RandomRun) randomDPovid += Global.Random.Range(0, 0.01f);
        if (lF != PovidLFT.safety) if (randomAPovid > 1)
            {
                //   anim.SetBool("run", true);
                lF = PovidLFT.safety;
            }
        if (lF != PovidLFT.Ploty) if (randomBPovid > 1)
            {
                //    anim.SetBool("run", true);
                lF = PovidLFT.Ploty;
            }

        if (lF != PovidLFT.RandomRun) if (randomDPovid > 1)
            {
                transform.rotation = Random.rotationUniform;
                //  anim.SetBool("run", true);
                lF = PovidLFT.RandomRun;

            }


        if (lF == PovidLFT.Ploty)
        {
            if (eat != null)
            {
                randomBPovid += Global.Random.Range(0, 0.05f);
            }
            if (eat == null)
            {
                //  anim.SetBool("run", false);
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
                //   anim.SetBool("run", false);
                lF = PovidLFT.spat;
            }

            if (eat != null)
            {
                transform.rotation = Quaternion.LookRotation(eat.transform.position - transform.position, Vector3.up);
                transform.Translate(0, 0, 20 * Time.deltaTime);

                randomAPovid -= Global.Random.Range(0, 0.2f);
            }
            if (eat == null)
            {
                //   anim.SetBool("run", false);
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

                    //   anim.SetBool("run", false);
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

    }
}
