using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Pviduk
{
    jdat = 6,
    sebatisya = 1,
    napdat = 2,
    spat = 0,
    trahotsa = 3,
    strelat = 4,
    tepehatsa = 5,
    randwalke = 7,
    moverwalke = 8,
    hlebpech = 9
}
public class UcnaKerfur : MonoBehaviour
{
    public static UcnaKerfur Instance;
    public Pviduk povid;
    mover m;
    public ParticleSystem love;
    public ParticleSystem agr;
    public ParticleSystem ska;
    public Animator anim;
    public TextMesh txt;
    float timer;
    float timer2;
    float timer3;
    float timer4;

    int function;
    public bool psiho;
    public bool stat; private void OnCollisionStay(Collision c)
    {
        if (c.collider.GetComponent<Logic_tag_DamageObject>())
        {
            Globalprefs.LoadTevroPrise(- 100);
          
            Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            cistalenemy.dies+=10;

        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        m = mover.main();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Function : " + function;
        if (!stat) timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (!stat) timer3 += Time.deltaTime;
        if (!stat) timer4 += Time.deltaTime;
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
        {
            if (hit.collider.gameObject == gameObject && Input.GetKeyDown(KeyCode.E))
            {
                if (function == 0)
                {
                    if (povid != Pviduk.trahotsa) povid = Pviduk.trahotsa;
                    else
                        povid = Pviduk.spat; stat = !stat;
                    Globalprefs.LoadTevroPrise(-10);
                }
                if (function == 1)
                {
                    if (povid != Pviduk.moverwalke) povid = Pviduk.moverwalke;
                    else
                        povid = Pviduk.spat; stat = !stat;
                    Globalprefs.LoadTevroPrise(-10);
                }
                if (function == 2)
                {
                    if (povid != Pviduk.strelat) povid = Pviduk.strelat;
                    else
                        povid = Pviduk.spat; stat = !stat;
                    Globalprefs.LoadTevroPrise(-10);
                }
                if (function == 3)
                {
                    Instantiate(Resources.Load("items/Хлеб"), transform.position, Quaternion.identity);
                    Globalprefs.LoadTevroPrise(-20);
                }
                if (function == 4)
                {
                    Instantiate(Resources.Load("items/Ucna_kerfur_наруках"), transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    Globalprefs.LoadTevroPrise(-20);
                }
            }
            if (!stat) if (hit.collider.gameObject == gameObject && Input.GetKeyDown(KeyCode.Q))
            {
                function += 1;
                if (function > 4)
                {
                    function =0;
                }
                    Globalprefs.LoadTevroPrise(-2);
            }
        }

        if (timer > 3 * 60)
        {
            povid = (Pviduk)Random.Range(0, 7);
            if (Random.Range(0, 70) == 0 && !psiho)
            {
                psiho = !psiho;
            }
            if (Random.Range(0, 700) == 0 && psiho)
            {
                psiho = !psiho;
            }
            if (!psiho)
            {
                timer = 0;
            }
        }
        if (timer3 > 20)
        {
            povid = Pviduk.randwalke;
            if (!psiho)
            {
                timer3 = 0;
            }
        }


        if (cistalenemy.dies>-100)    if (povid == Pviduk.strelat)
        {

            Instantiate(Resources.Load<GameObject>("SGNBoll"), gameObject.transform.position, Quaternion.identity);
        }


        if (povid == Pviduk.sebatisya)
        {
            ska.gameObject.SetActive(true);
        }
        else
        {
            ska.gameObject.SetActive(false);
        }
        if (povid == Pviduk.napdat)
        {
            if (!GetComponent<Logic_tag_DamageObject>())
            {
                gameObject.AddComponent<Logic_tag_DamageObject>();
            }
            agr.gameObject.SetActive(true);
        }
        else
        {
            if (GetComponent<Logic_tag_DamageObject>())
            {
                Destroy(gameObject.GetComponent<Logic_tag_DamageObject>());
            }
            agr.gameObject.SetActive(false);
        }
        if (cistalenemy.dies <= 0)
        {
            if (povid == Pviduk.trahotsa)
            {

                love.gameObject.SetActive(true);
                if (!anim.GetBool("sex")) anim.SetBool("sex", true);
                if (timer2 > 2)
                {
                    Globalprefs.LoadTevroPrise(-1);
                    timer2 = 0;
                }
                if (Globalprefs.LoadTevroPrise(0) < 0)
                {

                    Globalprefs.LoadTevroPrise(-10);
                    povid = Pviduk.sebatisya;

                }
            }
            else
            {
                love.gameObject.SetActive(false);
                anim.SetBool("sex", false);
            }
        }
      
        if (povid == Pviduk.sebatisya) transform.rotation = Quaternion.LookRotation(m.transform.position);
        if (povid == Pviduk.napdat || povid == Pviduk.trahotsa || povid == Pviduk.moverwalke) transform.rotation = Quaternion.LookRotation(m.transform.position - Vector3.up - transform.position);
        if (povid == Pviduk.randwalke) if (timer4>5) { transform.rotation = Random.rotation; timer4 = 0; }
        if (povid == Pviduk.sebatisya || povid == Pviduk.napdat || povid == Pviduk.moverwalke|| povid == Pviduk.randwalke) transform.Translate(0, 0, 1 * Time.deltaTime);
        if (povid == Pviduk.trahotsa)
        {
          if(Vector3.Distance(m.transform.position - Vector3.up, transform.position)>0.6f)  transform.Translate(0, 0, 1f * Time.deltaTime); 
        }
        if (povid == Pviduk.sebatisya || povid == Pviduk.napdat || povid == Pviduk.randwalke || povid == Pviduk.moverwalke)
        {

            anim.SetBool("move", true);
        }
        else
        {
            anim.SetBool("move", false);
        }

        if (povid == Pviduk.tepehatsa)
        {
            transform.position = m.transform.position;
            povid = (Pviduk)Random.Range(0, 8);
        }
    }
}

