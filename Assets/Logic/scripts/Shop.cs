using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
   
    public bool adecvat;
    public string inv;
    public Text[] number;
    public Text tevro; 
    public decimal tevroint;
    public produktid[] produkt;
    public void Start()
    {
        tevroint = VarSave.GetMoney("tevro");
        for (int i = 0; i < produkt.Length; i++)
        {
            if (produkt[i].name == "Random()")
            {
                System.Random r = new System.Random((int)(Globalprefs.GetIdPlanet()+ VarSave.GetMoney("LastSesion")+(i+ SceneManager.GetActiveScene().buildIndex *526)));
                int num = r.Next(0, complsave.t3.Length);
                produkt[i].name = complsave.t3[num].name;
                produkt[i].price = (complsave.t3[num].GetComponent<itemName>().ItemPrise*1.3f).ToString();
                produkt[i].Give_or_Minus = (r.Next(0, 3) == 1);
            }
        }
    }
    private void Update()
    {
        GameManager.save();
        tevro.text = tevroint.ToString();
        for (int i = 0; i < produkt.Length && !adecvat; i++)
        {
            number[i].text = produkt[i].name;
            if (produkt[i].Give_or_Minus == true)
            {
                number[i].color = Color.red;
            }
            if (produkt[i].Give_or_Minus == false)
            {
                number[i].color = Color.white;
            }
            if (!VarSave.ExistenceVar(produkt[i].us) && produkt[i].us != "")
            {
                number[i].color = Color.gray;
            }
        }
        for (int i = 0; i < produkt.Length && adecvat; i++)
        {
            if (produkt[i].Give_or_Minus == true)
            {

                number[i].text = "Покупаеться : имя " + produkt[i].name + " количество " + produkt[i].count + " цена " + produkt[i].price;
                number[i].color = Color.blue;
            }
            if (produkt[i].Give_or_Minus == false)
            {
                number[i].text = "Продаёться : имя " + produkt[i].name + " количество " + produkt[i].count + " цена " + produkt[i].price;

                number[i].color = Color.white;
            }
            if (!VarSave.ExistenceVar(produkt[i].us) && produkt[i].us != "")
            {
                number[i].text = "Х Продаёться : имя " + produkt[i].name + " количество " + produkt[i].count + " цена " + produkt[i].price;

                number[i].color = Color.gray;
            }

        }
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Destroy(gameObject);
        }
    }
    public void sell(int product)
    {
        if (VarSave.ExistenceVar(produkt[product].us) || produkt[product].us == "")
        {
            if (produkt[product].Give_or_Minus == false && tevroint >= decimal.Parse(produkt[product].price))
            {
                for (int i = 0; i < produkt[product].count; i++)
                {
                    Instantiate(Resources.Load<GameObject>("items/" + produkt[product].name), GameManager.GetPlayer().transform.position, Quaternion.identity);
                }
                tevroint -= decimal.Parse( produkt[product].price);
                VarSave.SetMoney("tevro", tevroint);
                if (produkt[product].name == "script" && Globalprefs.signedgamejolt == true)
                {
                    GameJolt.API.Trophies.TryUnlock(177824);
                }
              
            }
            if (produkt[product].Give_or_Minus == true)
            {

                for (int i = 0; i < produkt[product].count && GameObject.FindGameObjectWithTag(inv).GetComponent<ElementalInventory>().Getitem(produkt[product].name); i++)
                {

                    tevroint += decimal.Parse(produkt[product].price);
                    VarSave.SetMoney("tevro", tevroint);
                    GameObject.FindGameObjectWithTag(inv).GetComponent<ElementalInventory>().removeitem(produkt[product].name);

                }

            }
        }
    }
}
[System.Serializable]
public class produktid
{
    public string name;
    public bool Give_or_Minus;
    public int count; 
    public string price = "0";
    public string us;
    
}
