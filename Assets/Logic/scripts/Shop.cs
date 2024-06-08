using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
   
    public bool adecvat;
    public string inv;
    public Text[] number;
    public Text tevro;
    public Text my_tevro;
    public decimal tevroint;
    public string ShopPosition;
    public string TeuvroTraider = "1200";
    public produktid[] produkt;
    public void Start()
    {
        if (VarSave.GetFloat(
             "Creative" + "_gameSettings", SaveType.global) >= .1f)
        {
            VarSave.LoadFloat("reason", 1);
        }
        ShopPosition = ((int)transform.position.x).ToString() +
            ((int)transform.position.y).ToString() +
            ((int)transform.position.z).ToString() +
            SceneManager.GetActiveScene().name +
            Globalprefs.GetIdPlanet().ToString();
        if (!VarSave.ExistenceVar(ShopPosition,SaveType.world))
        {
            VarSave.SetMoney(ShopPosition,decimal.Parse(TeuvroTraider),SaveType.world);
        }
        else
        {
            TeuvroTraider = VarSave.LoadMoney(ShopPosition, 0, SaveType.world).ToString();
        }
        tevroint = Globalprefs.LoadTevroPrise(0);
        for (int i = 0; i < produkt.Length; i++)
        {
            if (produkt[i].name == "Random()")
            {
                System.Random r = new System.Random((int)(Globalprefs.GetIdPlanet() + VarSave.GetMoney("LastSesion") + (i + SceneManager.GetActiveScene().buildIndex * 526)));
                int num = r.Next(0, Map_saver.t3.Length);
                produkt[i].name = Map_saver.t3[num].name;
                if (!VarSave.ExistenceVar("researchs/" + produkt[i].name))
                {
                    produkt[i].price = (Map_saver.t3[num].GetComponent<itemName>().ItemPrise * 2.3f).ToString();
                }
                if (VarSave.ExistenceVar("researchs/" + produkt[i].name))
                {
                    produkt[i].price = (Map_saver.t3[num].GetComponent<itemName>().ItemPrise * 1.3f).ToString();
                }
                produkt[i].Give_or_Minus = (r.Next(0, 3) == 1);
            }
            if (!VarSave.ExistenceVar("researchs/" + produkt[i].name))
            {
                decimal prise = decimal.Parse(produkt[i].price);
                prise *= 2.5m;
                produkt[i].price = prise.ToString();
            }
            if (VarSave.LoadFloat("luck", 0f) > 3 && Random.Range(0, 2) == 0)
            {
                decimal prise = decimal.Parse(produkt[i].price);
                prise /= 1.5m;
                produkt[i].price = prise.ToString();
            }
            if (VarSave.LoadFloat("luck", 0f) > 24 && Random.Range(0, 7) == 0)
            {
                decimal prise = decimal.Parse(produkt[i].price);
                prise /= 4.5m;
                produkt[i].price = prise.ToString();
            }
            if (VarSave.LoadFloat("luck", 0f) > 666 && Random.Range(0, 80) == 0)
            {
                decimal prise = decimal.Parse(produkt[i].price);
                prise /= 400.5m;
                produkt[i].price = prise.ToString();
            }
            if (VarSave.LoadFloat("luck", 0f) > 906 && Random.Range(0, 100) == 0)
            {
                decimal prise = decimal.Parse(produkt[i].price);
                prise = 0m;
                produkt[i].price = prise.ToString();
            }
            if (VarSave.LoadFloat("luck", 0f) < -40 && Random.Range(0, 1) == 0)
            {
                decimal prise = decimal.Parse(produkt[i].price);
                prise /= 0m;
                produkt[i].price = prise.ToString();
            }
            //etProcentInflitiuon()
            decimal prise2 = decimal.Parse(produkt[i].price);
            prise2 *= Globalprefs.GetProcentInflitiuon()+1;
            produkt[i].price = prise2.ToString();
        }
    }
    private void Update()
    {
        tevro.text = tevroint.ToString();
       if(my_tevro) my_tevro.text = TeuvroTraider;
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
                VarSave.LoadMoney("Inflaition", -tevroint/2000, SaveType.global);
                Globalprefs.LoadTevroPrise(tevroint);

                if (produkt[product].name == "script" && Globalprefs.signedgamejolt == true)
                {
                    GameJolt.API.Trophies.TryUnlock(177824);
                }
                VarSave.LoadMoney(ShopPosition, decimal.Parse(produkt[product].price),SaveType.world);

                TeuvroTraider = VarSave.LoadMoney(ShopPosition, 0, SaveType.world).ToString();

                GameManager.save();
            }
            if (produkt[product].Give_or_Minus == true)
            {

                for (int i = 0; i < produkt[product].count && GameObject.FindGameObjectWithTag(inv).GetComponent<ElementalInventory>().GetItemOnAll(produkt[product].name) && VarSave.LoadMoney(ShopPosition,0,SaveType.world) > 0; i++)
                {

                    tevroint += decimal.Parse(produkt[product].price);
                    Globalprefs.LoadTevroPrise(tevroint);
                    GameObject.FindGameObjectWithTag(inv).GetComponent<ElementalInventory>().removeitem(produkt[product].name);

                    VarSave.LoadMoney(ShopPosition, -decimal.Parse(produkt[product].price), SaveType.world);

                    TeuvroTraider = VarSave.LoadMoney(ShopPosition, 0, SaveType.world).ToString();
                }

                GameManager.save();
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
