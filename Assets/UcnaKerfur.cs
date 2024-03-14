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
    float timer;
    float timer2;
    public bool psiho;
    public bool stat; private void OnCollisionStay(Collision c)
    {
        if (c.collider.GetComponent<Logic_tag_DamageObject>())
        {
            VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") - 100);
          
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

        if (!stat) timer += Time.deltaTime;
         timer2 += Time.deltaTime;
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null)
        {
            if (hit.collider.gameObject == gameObject && Input.GetKeyDown(KeyCode.E))
            {
               if(povid != Pviduk.trahotsa) povid = Pviduk.trahotsa; else
                    povid = Pviduk.spat; stat = !stat;
                VarSave.LoadMoney("tevro", -10);
            }
        }
                if (timer > 60)
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


        if(cistalenemy.dies>-100)    if (povid == Pviduk.strelat)
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
                    VarSave.LoadMoney("tevro", -1);
                    timer2 = 0;
                }
                if (VarSave.LoadMoney("tevro", 0) < 0)
                {

                    VarSave.LoadMoney("tevro", -10);
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
        if (povid == Pviduk.napdat || povid == Pviduk.trahotsa) transform.rotation = Quaternion.LookRotation(m.transform.position - Vector3.up - transform.position );
        if (povid == Pviduk.sebatisya || povid == Pviduk.napdat) transform.Translate(0, 0, 1 * Time.deltaTime);
        if (povid == Pviduk.trahotsa)
        {
          if(Vector3.Distance(m.transform.position - Vector3.up, transform.position)>0.1f)  transform.Translate(0, 0, 1f * Time.deltaTime); 
        }
        if (povid == Pviduk.sebatisya || povid == Pviduk.napdat)
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

