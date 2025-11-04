using UnityEngine;
using UnityEngine.UI;

public class Kisy : MonoBehaviour
{
    public static float alphaProze;
    public static float Hp = 100;
    public static Kisy main;
    public bool blockregen;
    public Image Poze;
    public GameObject soundStones;
    public Text HpText;
    public Vibratorkamera vibrator;
    private void Start()
    {
        main = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MashineDig>())
        {
            Hp -= 1;
            alphaProze = 1;
        }
    }
    private void Update()
    {
        if (this == main)
        {
            Poze.color = new Color(1, 1, 1, alphaProze);
            HpText.text = "Hp " + Hp + " ≈нтер станать дл€ востановлени€ Hp";
            if (!blockregen) alphaProze -= Time.deltaTime;
            if (blockregen) alphaProze -= Time.deltaTime/10;
            if (!blockregen)  if(alphaProze>0.8f) if (Input.GetKeyDown(KeyCode.Return))
            {
                Hp += 6;
                if (Hp > 100)
                {
                    Hp = 100;
                }
                Instantiate(soundStones);

            }
            if (Hp < 50)
            {
                vibrator.transform.Rotate(Random.Range(-1, 2), Random.Range(-1, 2), Random.Range(-1, 2));
            }
            if (Hp < 25)
            {
                vibrator.transform.Rotate(Random.Range(-5, 6), Random.Range(-5, 6), Random.Range(-5, 6));
            }
            if (Hp < 0)
            {
                vibrator.transform.Rotate(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));
            } 
        }
    }
}
