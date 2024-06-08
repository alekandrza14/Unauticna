using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public bool red_blue;
    public Text[] lables;
    public int pover;
    string spover;
    public MeshRenderer card;
    private void SStart()
    {
        spover = GetComponent<itemName>().ItemData;

        if (string.IsNullOrEmpty(spover))
        {
            if (Map_saver.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());

                spover = pover.ToString() + "!" + red_blue.ToString();
                GetComponent<itemName>().ItemData = spover;
            }
        }
        pover = int.Parse(spover.Split('!')[0]);
        red_blue = bool.Parse(spover.Split('!')[1]);
    }
    public void Load1()
    {
        if (GetComponent<itemName>())
        {

            spover = GetComponent<itemName>().ItemData;

            if (string.IsNullOrEmpty(spover))
            {

                // time = JsonUtility.ToJson(Random.ColorHSV());

                spover = "0";
                GetComponent<itemName>().ItemData = spover;


            }
            pover = int.Parse(spover.Split('!')[0]);
            red_blue = bool.Parse(spover.Split('!')[1]);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
        if (other.GetComponent<Card>())
        {
            Card ot_card = other.GetComponent<Card>();
            if (ot_card.red_blue!= red_blue)
            {
                if (red_blue)
                {
                    Globalprefs.LoadTevroPrise(3 * ot_card.pover - pover);
                    other.gameObject.AddComponent<DELETE>();
                    gameObject.AddComponent<DELETE>();
                }
            }
        }
    }

    private void Start()
    {
        if (red_blue)
        {
           
            card.material.color = Color.red;
        }
        else
        {
           
            card.material.color = Color.blue;
        }
        foreach (Text item in lables)
        {
            item.text = ""+pover;
        }
        SStart();
    }
    private void Update()
    {
        if (red_blue)
        {

            card.material.color = Color.red;
        }
        else
        {

            card.material.color = Color.blue;
        }
        foreach (Text item in lables)
        {
            item.text = "" + pover;
        }
        GetComponent<itemName>().ItemData = pover.ToString()+"!"+red_blue.ToString();
    }
}
