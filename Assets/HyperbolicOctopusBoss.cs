using UnityEngine;
using UnityEngine.UI;

public class HyperbolicOctopusBoss : MonoBehaviour
{
    System.Random rand;
    public Scrollbar HPBar;
    public Text HPLable;
    static public int HP = 100;
    public GameObject Tin;
    public GameObject Shaverma;
    HyperbolicPoint hp;
    HyperbolicPoint hp2;
    HyperbolicPoint hp3;
    HyperbolicPoint hp4;
    HyperbolicPoint hp5;
    HyperbolicPoint shaverma;
    private void Awake()
    {
        rand = new System.Random((int)Globalprefs.GetIdPlanet());
        HP = 100;
    }
    void Update()
    {
        HPBar.size = ((float)HP)/100f;
        HPLable.text = "Hyperbolic octopus " + HP + " / 100";
        if (Input.GetKeyDown(KeyCode.F2))
        {
            HP = 100;
        }
        if (hp == null)
        {
            hp = Instantiate(Tin, this.transform.position, Quaternion.identity).GetComponent<HyperbolicPoint>();
            hp.HyperboilcPoistion = HyperbolicCamera.Main().RealtimeTransform.copy().inverse();
            hp.HyperboilcPoistion.applyTranslationY(rand.Next(-3000, 3000) / 1000f);
            hp.HyperboilcPoistion.applyTranslationZ(rand.Next(-3000, 3000) / 1000f);
        }
        if (hp2 == null)
        {
            hp2 = Instantiate(Tin, this.transform.position, Quaternion.identity).GetComponent<HyperbolicPoint>();
            hp2.HyperboilcPoistion = HyperbolicCamera.Main().RealtimeTransform.copy().inverse();
            hp2.HyperboilcPoistion.applyTranslationY(rand.Next(-3000, 3000) / 1000f);
            hp2.HyperboilcPoistion.applyTranslationZ(rand.Next(-3000, 3000) / 1000f);
        }
        if (hp3 == null)
        {
            hp3 = Instantiate(Tin, this.transform.position, Quaternion.identity).GetComponent<HyperbolicPoint>();
            hp3.HyperboilcPoistion = HyperbolicCamera.Main().RealtimeTransform.copy().inverse();
            hp3.HyperboilcPoistion.applyTranslationY(rand.Next(-3000, 3000) / 1000f);
            hp3.HyperboilcPoistion.applyTranslationZ(rand.Next(-3000, 3000) / 1000f);
        }
        if (hp4 == null)
        {
            hp4 = Instantiate(Tin, this.transform.position, Quaternion.identity).GetComponent<HyperbolicPoint>();
            hp4.HyperboilcPoistion = HyperbolicCamera.Main().RealtimeTransform.copy().inverse();
            hp4.HyperboilcPoistion.applyTranslationY(rand.Next(-3000, 3000) / 1000f);
            hp4.HyperboilcPoistion.applyTranslationZ(rand.Next(-3000, 3000) / 1000f);
        }
        if (hp5 == null)
        {
            hp5 = Instantiate(Tin, this.transform.position, Quaternion.identity).GetComponent<HyperbolicPoint>();
            hp5.HyperboilcPoistion = HyperbolicCamera.Main().RealtimeTransform.copy().inverse();
            hp5.HyperboilcPoistion.applyTranslationY(rand.Next(-3000, 3000) / 1000f);
            hp5.HyperboilcPoistion.applyTranslationZ(rand.Next(-3000, 3000) / 1000f);
        }
        if (shaverma == null && HP <= 0)
        {
            shaverma = Instantiate(Shaverma, this.transform.position, Quaternion.identity).gameObject.AddComponent<HyperbolicPoint>();
            shaverma.HyperboilcPoistion = HyperbolicCamera.Main().RealtimeTransform.copy().inverse();
            shaverma.HyperboilcPoistion.applyTranslationY(rand.Next(-500, 500) / 1000f);
            shaverma.HyperboilcPoistion.applyTranslationZ(rand.Next(-500, 500) / 1000f);
        }
    }
}
