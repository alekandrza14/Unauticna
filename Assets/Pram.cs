using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PramArrayProdukt
{
    public List<GameObject> breads = new();
    public List<GameObject> Charas = new();
    public List<GameObject> lifeCleaners = new();
    public List<GameObject> Builders = new();
    public List<GameObject> chips = new();
    public List<GameObject> iceMines = new();
    public List<GameObject> ConstuctorTualet = new();
    public List<GameObject> Eggs = new();
}

public class Pram : InventoryEvent
{
    PramArrayProdukt array = new();

    public void Load1()
    {
        ArrayInit();
    }
    public void Start()
    {
        if (Map_saver.LoadADone)
        {
            ArrayInit();
        }
    }

    private void ArrayInit()
    {
        array = new();
        itemName[] items = FindObjectsByType<itemName>(sortmode.main);
        foreach (itemName item in items)
        {
            if (item._Name == "Хлеб")
            {
                array.breads.Add(item.gameObject);
            }
        }
        itemName[] items2 = FindObjectsByType<itemName>(sortmode.main);
        foreach (itemName item in items2)
        {
            if (item._Name == "LifeCleaner")
            {
                array.lifeCleaners.Add(item.gameObject);
            }
        }
        itemName[] items3 = FindObjectsByType<itemName>(sortmode.main);
        foreach (itemName item in items3)
        {
            if (item._Name == "builder")
            {
                array.Builders.Add(item.gameObject);
            }
        }
        itemName[] items4 = FindObjectsByType<itemName>(sortmode.main);
        foreach (itemName item in items4)
        {
            if (item._Name == "Чип-Подчинеия")
            {
                array.chips.Add(item.gameObject);
            }
        }
        itemName[] items5 = FindObjectsByType<itemName>(sortmode.main);
        foreach (itemName item in items5)
        {
            if (item._Name == "Ice_mine")
            {
                array.iceMines.Add(item.gameObject);
            }
        }
        itemName[] items6 = FindObjectsByType<itemName>(sortmode.main);
        foreach (itemName item in items6)
        {
            if (item._Name == "КонструкрорТуалета")
            {
                array.ConstuctorTualet.Add(item.gameObject);
            }
        }
        itemName[] items7 = FindObjectsByType<itemName>(sortmode.main);
        foreach (itemName item in items7)
        {
            if (item._Name == "Eggs")
            {
                array.Eggs.Add(item.gameObject);
            }
        }
        CustomObject[] cos = FindObjectsByType<CustomObject>(sortmode.main);
        foreach (CustomObject item in cos)
        {
            if (item.s == "Chara")
            {
                array.Charas.Add(item.gameObject);
            }
        }
    }

    public void BreadGive()
    {
        int countbread = 0;
        foreach (GameObject item in array.breads)
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
            array.breads.Add(bread);
        }
    }
    public void LCGive()
    {
        int countbread = 0;
        foreach (GameObject item in array.lifeCleaners)
        {
            if (item != null)
            {
                countbread++;
            }
        }
        if (countbread < 1)
        {
            GameObject item = Resources.Load<GameObject>("Items/LifeCleaner");
            GameObject bread = Instantiate(item, mover.main().transform.position, Quaternion.identity);
            array.lifeCleaners.Add(bread);
        }
    }
    public void BiuilderGive()
    {
        int countbread = 0;
        foreach (GameObject item in array.Builders)
        {
            if (item != null)
            {
                countbread++;
            }
        }
        if (countbread < 1)
        {
            GameObject item = Resources.Load<GameObject>("Items/builder");
            GameObject bread = Instantiate(item, mover.main().transform.position, Quaternion.identity);
            array.Builders.Add(bread);
        }
    }
    public void chipsGive()
    {
        int countbread = 0;
        foreach (GameObject item in array.chips)
        {
            if (item != null)
            {
                countbread++;
            }
        }
        if (countbread < 1)
        {
            GameObject item = Resources.Load<GameObject>("Items/Чип-Подчинеия");
            GameObject bread = Instantiate(item, mover.main().transform.position, Quaternion.identity);
            array.chips.Add(bread);
        }
    }
    public void IceminesGive()
    {
        int countbread = 0;
        foreach (GameObject item in array.iceMines)
        {
            if (item != null)
            {
                countbread++;
            }
        }
        if (countbread < 3)
        {
            GameObject item = Resources.Load<GameObject>("Items/Ice_mine");
            GameObject bread = Instantiate(item, mover.main().transform.position, Quaternion.identity);
            array.iceMines.Add(bread);
        }
    }
    public void TualetGive()
    {
        int countbread = 0;
        foreach (GameObject item in array.ConstuctorTualet)
        {
            if (item != null)
            {
                countbread++;
            }
        }
        if (countbread < 2)
        {
            GameObject item = Resources.Load<GameObject>("Items/КонструкрорТуалета");
            GameObject bread = Instantiate(item, mover.main().transform.position, Quaternion.identity);
            array.ConstuctorTualet.Add(bread);
        }
    }
    public void EggsGive()
    {
        int countbread = 0;
        foreach (GameObject item in array.Eggs)
        {
            if (item != null)
            {
                countbread++;
            }
        }
        if (countbread < 20)
        {
            GameObject item = Resources.Load<GameObject>("Items/Eggs");
            GameObject bread = Instantiate(item, mover.main().transform.position, Quaternion.identity);
            array.Eggs.Add(bread);
        }
    }
    public void FSGive()
    {
       
            GameObject item = Resources.Load<GameObject>("Items/fractalSpace");
            Instantiate(item, mover.main().transform.position, Quaternion.identity);
          
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
        foreach (GameObject item in array.Charas)
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
            array.Charas.Add(objs);
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
