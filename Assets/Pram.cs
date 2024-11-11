using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pram : InventoryEvent
{
    List<GameObject> breads = new();
    List<GameObject> Charas = new();

    public void Load1()
    {
        itemName[] items = FindObjectsByType<itemName>(sortmode.main);
        foreach (itemName item in items)
        {
            if (item._Name == "Хлеб")
            {
                breads.Add(item.gameObject);
            }
        }
        CustomObject[] cos = FindObjectsByType<CustomObject>(sortmode.main);
        foreach (CustomObject item in cos)
        {
            if (item.s == "Chara")
            {
                Charas.Add(item.gameObject);
            }
        }
    }
    public void Start()
    {
        if (Map_saver.LoadADone)
        {
            itemName[] items = FindObjectsByType<itemName>(sortmode.main);
            foreach (itemName item in items)
            {
                if (item._Name == "Хлеб")
                {
                    breads.Add(item.gameObject);
                }
            }
            CustomObject[] cos = FindObjectsByType<CustomObject>(sortmode.main);
            foreach (CustomObject item in cos)
            {
                if (item.s == "Chara")
                {
                    Charas.Add(item.gameObject);
                }
            }
        }
    }

    public void BreadGive()
    {
        int countbread = 0;
        foreach (GameObject item in breads)
        {
            if (item != null)
            {
                countbread++;
            }
        }
        if (countbread < 20)
        {
            GameObject item = Resources.Load<GameObject>("Items/Хлеб");
           GameObject bread = Instantiate(item, mover.main().transform.position, Quaternion.identity);
            breads.Add(bread);
        }
    }
    public void Tevro1000give()
    {

        if (VarSave.LoadInt("Tevro1000givePram", 1) <= 3)
        {
            Globalprefs.LoadTevroPrise(1000);
        }
    }
    public void Tevro1000tax()
    {

        // if (VarSave.LoadInt("TevroBank", 0))
        // {
        Globalprefs.LoadTevroPrise(-1000);
        VarSave.LoadInt("TevroBank", 1000);
        // }
    }
    public void Tevro1000voz()
    {

        if (VarSave.LoadInt("TevroBank", 0)>=1000)
        {
        Globalprefs.LoadTevroPrise(1000);
        VarSave.LoadInt("TevroBank", -1000);
        }
    }
    public void StatusKing()
    {
        Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"), mover.main().transform.position + PiratAttack.randomCube(6, 6) + new Vector3(0, 6, 0), Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("items/SampleCrown"), mover.main().transform.position + PiratAttack.randomCube(6, 6) + new Vector3(0, 6, 0), Quaternion.identity);
        VarSave.SetString("ProfStatus", "King");
        //SampleCrown
        //Absolute_poison
        VarSave.LoadMoney("tevro", 2500000000);
        cistalenemy.dies -= 10000;
        Globalprefs.flowteuvro = VarSave.LoadMoney("CashFlow", 5500);
    }
    public void Avoritet()
    {
        if (VarSave.LoadInt("AvtoritetgivePram" + ((System.DateTime.Now.Year * 365) + System.DateTime.Now.DayOfYear), 1) <= 3)
        {
            VarSave.LoadMoney("Avtoritet", 1);
        }
    }
    public void CharaNoPnat()
    {

        int countchara = 0;
        foreach (GameObject item in breads)
        {
            if (item != null)
            {
                countchara++;
            }
        }
        if (countchara < 12)
        {
            GameObject item = Resources.Load<GameObject>("CustomObject");
            GameObject objs = Instantiate(item, mover.main().transform.position, Quaternion.identity);
            objs.GetComponent<CustomObject>().s = "Chara";
            Charas.Add(objs);
        }

    }
    public void slaverying()
    {
       
            VarSave.SetBool("Slave", true);
       
        if (VarSave.GetBool("Slave"))
        {
            if (SceneManager.GetActiveScene().name != "Slave")
            {
                SceneManager.LoadScene("Slave");
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Destroy(gameObject);
        }
    }
}
