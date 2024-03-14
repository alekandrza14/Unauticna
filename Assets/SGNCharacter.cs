using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum PvidSGN
{
    jdat=6,
    sebatisya=1,
    napdat=2,
    srat=3,
    spat=0,
    trahotsa=4,
    strelat = 5,
    tepehatsa = 7,
    grstnosebatisya = 8
}

public class SGNCharacter : MonoBehaviour
{
    [SerializeField] Text CraracterLable;
    public static SGNCharacter Instance;
    mover m;
    public float hp = 1000;
    public float lv = 2;
    public PvidSGN povid;
    public ParticleSystem love;
    public ParticleSystem agr;
    public ParticleSystem ska;
    float timer;
    float timer2;
    public bool psiho;
    // Start is called before the first frame update
    void Awake()
    {
        m = mover.main();
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (CraracterLable.gameObject.activeInHierarchy)
        {
            timer += Time.deltaTime;
            if (povid != PvidSGN.grstnosebatisya)
            {
                if (timer > 20)
                {
                    povid = (PvidSGN)Random.Range(0, 8);
                    if (Random.Range(0, 7) == 0 && !psiho)
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
            }
            else
            {
                timer2 += Time.deltaTime;
                //StartLineChapter2
                if (timer2>60)
                {
                    SceneManager.LoadScene("StartLineChapter2");
                }
            }
            CraracterLable.text = "Spamton Giga Neo : " + hp + "/1000 hp , " + lv + "/4m lv";
            if (hp < 0)
            {
                lv *= 2;

                hp = 1000;
            }
            if (lv>4000000)
            {

                povid = PvidSGN.grstnosebatisya;
            }
            if (povid == PvidSGN.srat)
            {

                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
            }
            if (povid == PvidSGN.sebatisya)
            {
                ska.gameObject.SetActive(true);
            }
            else
            {
                ska.gameObject.SetActive(false);
            }
            if (povid == PvidSGN.napdat)
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
            if (povid == PvidSGN.trahotsa)
            {
                love.gameObject.SetActive(true);
            }
            else
            {
                love.gameObject.SetActive(false);
            }
            if (povid == PvidSGN.sebatisya|| povid == PvidSGN.grstnosebatisya) transform.rotation = Quaternion.LookRotation(m.transform.position);
            if (povid == PvidSGN.napdat || povid == PvidSGN.trahotsa) transform.rotation = Quaternion.LookRotation( m.transform.position-transform.position);
            if (povid == PvidSGN.sebatisya || povid == PvidSGN.napdat || povid == PvidSGN.trahotsa) transform.Translate(0, 0, 20 * Time.deltaTime);
            if (povid == PvidSGN.grstnosebatisya) transform.Translate(0, 0, 1 * Time.deltaTime);
            if (povid == PvidSGN.tepehatsa) 
            {
                transform.position = m.transform.position;
                povid = (PvidSGN)Random.Range(0, 8);
            }
        }
    }
}
