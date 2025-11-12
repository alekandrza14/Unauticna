using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using static UnityEngine.GraphicsBuffer;

public class inputButton
{
	static public int button;
}
[System.Serializable]
public class MassSelect
{
    public GameObject selectobjects;
    public int selects = 0;
}


public class ElementalInventory : MonoBehaviour {

    //Cell massive
    public Cell[] Cells;


    //Max element stack
    public int maxStack;
    public GameObject elementPrefab;
    public GameObject selectobject;
    public GameObject selectingobjects;
    public int select = 0;
    public List<MassSelect> selects = new List<MassSelect>();
    public static string[] itemtags;
    public static string[] itemnames;
    public static string[] itemPrimetiveInts;
    public static GameObject[] itemPrimetive;
    public string[] nunamesA;
    public string[] nunamesB;
    private Transform choosenItem;
    public Cell activeItem;
    public bool planets;
    public bool deletecell;
    public bool nosell;
    public bool nomainiventory;
    public static ElementalInventory instance;
    bool sh;
    private void Awake()
    {
    }
    public void getallitemsroom()
    {
        GameObject[] g = Resources.LoadAll<GameObject>("itms/room" + SceneManager.GetActiveScene().buildIndex);
        nunamesA = new string[g.Length];
        for (int i = 0; i < nunamesA.Length; i++)
        {
            nunamesA[i] = g[i].name;

        }

    }

    public static ElementalInventory main()
    {

        if (instance == null)
        {
            instance = boxItem.getInventory("i3").inventory;
        }
        return instance;
        
    }

    public void getallitems()
    {
        getallitemsroom();
        GameObject[] g = Map_saver.t3;

        itemnames = new string[g.Length];
        itemtags = new string[g.Length];
        for (int i = 0; i < g.Length; i++)
        {
            itemnames[i] = g[i].name;
            itemtags[i] = g[i].tag;
            if (g[i].GetComponent<breauty>()) g[i].GetComponent<breauty>().integer = 10;
        }
        GameObject[] g2 = Map_saver.t4;
        itemPrimetive = new GameObject[g2.Length];
        itemPrimetiveInts = new string[g2.Length];
        for (int i = 0; i < g2.Length; i++)
        {
            itemPrimetive[i] = g2[i];
            itemPrimetiveInts[i] = g2[i].GetComponent<StandartObject>().init;

        }


    }
    public GameObject inv2(string name)
    {
        GameObject g1 = Resources.Load<GameObject>("death_point");
        for (int i = 0; i < nunamesA.Length; i++)
        {
            if (i < nunamesA.Length)
            {


                if (nunamesA[i] != name)
                {
                    g1 = Resources.Load<GameObject>("items/" + name);
                    i = nunamesA.Length;



                }
            }
            if (i < nunamesA.Length)
            {
                if (nunamesA[i] == name)
                {


                    g1 = Resources.Load<GameObject>("itms/room" + SceneManager.GetActiveScene().buildIndex + "/" + name);
                    i = nunamesA.Length;
                }
            }


        }
        if (nunamesA.Length == 0)
        {

            for (int i = 0; i < itemnames.Length; i++)
            {
                if (i < itemnames.Length)
                {


                    if (itemnames[i] != name)
                    {


                        g1 = Resources.Load<GameObject>("items/" + name);

                    }
                }
                if (i < itemnames.Length)
                {



                    g1 = Resources.Load<GameObject>("items/" + name);


                }

            }
        }
        for (int i = 0; i < itemPrimetive.Length; i++)
        {
            if (i < itemPrimetive.Length)
            {


                if (itemPrimetive[i].name != name)
                {


                    g1 = Resources.Load<GameObject>("Primetives/" + name);

                }
            }
            if (i < itemPrimetive.Length)
            {



                g1 = Resources.Load<GameObject>("Primetives/" + name);


            }

        }
      


                    g1 = Resources.Load<GameObject>("CustomObject");
                    g1.GetComponent<CustomObject>().s = name.Replace("co!","");


       

        int t = 0;
        for (int i = name.Length - 1; i > 0; i--)
        {
            if (name[i] == 'x')
            {
                t++;
            }
            if (name[i] != 'x' && t != 0)
            {
                string namet = name.Remove((name.Length) - t);
                Debug.Log(namet);
                if (true)
                {


                    GameObject p = Resources.Load<GameObject>("items/" + namet);
                    if (p)
                    {
                        if (!p.GetComponent<breauty>())
                        {
                            p.AddComponent<breauty>().integer = 10 - t;
                        }
                        if (p.GetComponent<breauty>())
                        {
                            p.GetComponent<breauty>().integer = 10 - t;
                        }
                        if (true)
                        {


                            g1 = p;
                        }
                    }
                }
                i = 0;


            }

        }

        if (true)
        {


            GameObject p = Resources.Load<GameObject>("death_point");
            p = Resources.Load<GameObject>("items/" + name);

            if (!p)
            {
                for (int i = 0; i < itemPrimetive.Length; i++)
                {



                    if (itemPrimetive[i].name == name)
                    {


                        p = itemPrimetive[i];

                    }


                }
            }
            if (p)
            {
                if (!p.GetComponent<breauty>())
                {
                    p.AddComponent<breauty>().integer = 10;
                }
                if (p.GetComponent<breauty>())
                {
                    p.GetComponent<breauty>().integer = 10;
                }
                if (true)
                {


                    g1 = p;
                }
            }
        }






        t = 0;
        return g1;
    }
    GameObject elementrandom()
    {
        GameObject g = Resources.Load<GameObject>("items/Ti");
        int i = (int)Global.Random.Range(0, 7);
        if (i == 0)
        {
            g = Resources.Load<GameObject>("items/Ti");
        }
        else if (i == 1)
        {
            g = Resources.Load<GameObject>("items/He");
        }
        else if (i == 2)
        {
            g = Resources.Load<GameObject>("items/Fr");
        }
        else if (i == 3)
        {
            g = Resources.Load<GameObject>("items/C");
        }
        else if (i == 4)
        {
            g = Resources.Load<GameObject>("items/Cr");
        }
        else if (i == 5)
        {
            g = Resources.Load<GameObject>("items/Au");
        }
        else if (i == 6)
        {
            g = Resources.Load<GameObject>("items/U");
        }
        return g;

    }
    public string toname(string name)
    {

        int s = 0;


        for (int i2 = 0; i2 < itemtags.Length; i2++)
        {

            if (itemtags[i2] == name)
            {
                s = i2;
            }




        }
        return itemnames[s];

    }
    public bool tag1(string name)
    {

        bool s2 = false;


        for (int i2 = 0; i2 < itemtags.Length; i2++)
        {

            if (itemtags[i2] == name)
            {
                s2 = true;
            }





        }
        return s2;

    }
    public string fullname(RaycastHit h)
    {
        string s = "";
        string s1 = "";
        int x = 0;

        //(clone)
        if (h.collider.name[h.collider.name.Length - 1] == ')')
        {
            s1 = h.collider.name.Remove(h.collider.name.Length - 7);
        }
        s += s1;
        if (h.collider.GetComponent<breauty>()) x = 10 - h.collider.GetComponent<breauty>().integer;
        if (!h.collider.GetComponent<breauty>()) x = 0;


        Destroy(h.collider.gameObject);



        if (h.collider.GetComponent<breauty>()) for (int i = 0; i < x; i++)
            {
                s += 'x';
            }
        return s;
    }
    public string fullnamesafe(RaycastHit h)
    {
        string s = "";
        string s1 = "";
        int x = 0;

        //(clone)
        if (h.collider.name[h.collider.name.Length - 1] == ')')
        {
            s1 = h.collider.name.Remove(h.collider.name.Length - 7);
        }
        s += s1;
        if (h.collider.GetComponent<breauty>()) x = 10 - h.collider.GetComponent<breauty>().integer;
        if (!h.collider.GetComponent<breauty>()) x = 0;


      //  Destroy(h.collider.gameObject);



        if (h.collider.GetComponent<breauty>()) for (int i = 0; i < x; i++)
            {
                s += 'x';
            }
        return s;
    }
    public bool tag2(GameObject name)
    {

        bool s2 = true;




        if ("enemies" == LayerMask.LayerToName(name.layer))
        {
            s2 = false;
        }






        return s2;

    }
    public string nameItem(string name)
    {

        bool s2 = true;
        string rawname1 = name.Replace(" ", "_");

        string fullname = "";
        int t = 0;
        for (int i = rawname1.Length - 1; i > 0; i--)
        {
            if (rawname1[i] == 'x')
            {
                t++;
            }
            if (rawname1[i] != 'x' && t != 0)
            {
                fullname = rawname1.Remove((rawname1.Length) - t);

                if (true)
                {



                }
                i = 0;


            }
            if (rawname1[i] != 'x' && t == 0)
            {
                fullname = rawname1;

                if (true)
                {



                }
                i = 0;


            }

        }






        return fullname;

    }
    public bool tag3(GameObject name)
    {

        bool s2 = true;




        if (name.GetComponent<Logic_tag_1>())
        {
            s2 = false;
        }






        return s2;

    }
    public void removeitem(string name)
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            if (Cells[i].elementCount != 0)
            {
                if (Cells[i].elementName == name)
                {
                    Cells[i].elementName = "";
                    Cells[i].elementCount = 0;
                    Cells[i].UpdateCellInterface();
                    i = Cells.Length;
                }
            }
        }
    }
    public void lowitem(string name, string covert)
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            if (Cells[i].elementName == name)
            {
                Cells[i].elementName = name + "x";
                Cells[i].elementCount = 1;
                Cells[i].UpdateCellInterface();

                return;
            }
            if (Cells[i].elementName == name + "x")
            {
                Cells[i].elementName = name + "xx";
                Cells[i].elementCount = 1;
                Cells[i].UpdateCellInterface();

                return;
            }
            if (Cells[i].elementName == name + "xx")
            {
                Cells[i].elementName = name + "xxx";
                Cells[i].elementCount = 1;
                Cells[i].UpdateCellInterface();

                return;
            }

            if (Cells[i].elementName == name + "xxx")
            {
                Cells[i].elementName = name + "xxxx";
                Cells[i].elementCount = 1;
                Cells[i].UpdateCellInterface();

                return;
            }
            if (Cells[i].elementName == name + "xxxx")
            {
                Cells[i].elementName = name + "xxxxx";
                Cells[i].elementCount = 1;
                Cells[i].UpdateCellInterface();

                return;
            }
            if (Cells[i].elementName == name + "xxxxx")
            {
                if (covert == "")
                {
                    Cells[i].elementName = "";
                    Cells[i].elementCount = 0;
                }
                else
                {
                    Cells[i].elementName = covert;
                    Cells[i].elementCount = 1;
                }
                Cells[i].UpdateCellInterface();

                return;
            }
        }
    }
    public void lowioncube(string name)
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            if (Cells[i].elementName == name)
            {
                Cells[i].elementName = name + "_0%";
                Cells[i].elementCount = 1;
                Cells[i].UpdateCellInterface();
                i = Cells.Length;
            }

        }
    }
    public bool Getitem(string name)
    {
        bool y = false;
        List<int> items = new List<int>();
        for (int i2 = 0; i2 < selects.Count; i2++)
        {
            items.Add(selects[i2].selects);
        }
        items.Add(select);

        foreach (int item in items)
        {
           
                if (Cells[item].elementName == name && Cells[item].elementCount != 0)
                {

                    y = true;

                }
           
        }
        if (Cells[select].elementName == name && Cells[select].elementCount != 0)
        {

            y = true;

        }

        return y;
    }
    public bool GetItemOnAll(string name)
    {
        bool y = false;
        for (int i = 0; i < Cells.Length; i++)
        {
            if (Cells[i].elementName == name && Cells[i].elementCount != 0)
            {

                y = true;

            }
        }
        return y;
    }
    public int priaritet(string name)
    {
        int i = 0;
       

        
        if (Getitem(name))
        {
            i = 1;
        }
        if (Getitem(name + "x"))
        {
            i = 2;
        }
        if (Getitem(name + "xx"))
        {
            i = 3;
        }
        if (Getitem(name + "xxx"))
        {
            i = 3;
        }
        if (Getitem(name + "xxxx"))
        {
            i = 4;
        }
        if (Getitem(name + "xxxxx"))
        {
            i = 5;
        }
        return i;
    }
    IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    int yu;
    int yu2;
    GameObject editObject;
    void itemUse(int selectr)
    {

        bool batteytype = Cells[selectr].elementName == "battery" || Cells[selectr].elementName == "mathimatic_battery" || Cells[selectr].elementName == "Reload_battery";
        bool weitghtelemets = Cells[selectr].elementName == "U" || Cells[selectr].elementName == "Ṳx" || Cells[selectr].elementName == "Nuclear_plant" || Cells[selectr].elementName == "bomb" || Cells[selectr].elementName == "UranMarker";

        if (Input.GetKeyDown(KeyCode.Mouse0) && !Globalprefs.Pause)
        {
            RaycastHit hit = MainRay.MainHit;
            if (hit.collider!=null)
            {
                if (ElementalInventory.main().Getitem("Namer"))
                {

                    GameObject g = Instantiate(Resources.Load<GameObject>("ui/console/Переименовать"), gameObject.transform.position, Quaternion.identity);
                    g.GetComponent<Namer>().g = hit.collider.gameObject;
                    Global.PauseManager.Pause();
                }
            }
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && Getitem("box1") && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(inv2("belock").gameObject, hit.point + Vector3.up * inv2("belock").gameObject.transform.localScale.y / 2, Quaternion.identity);
                Instantiate(inv2("belock").gameObject, hit.point + Vector3.up * inv2("belock").gameObject.transform.localScale.y / 2, Quaternion.identity);


            }

            cistalenemy.dies++;
            removeitem("box1");
            GlobalInputMenager.KeyCode_eat = 0;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1) && Getitem("builder") && Cells[selectr].elementName == "builder" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.layer == 6)
                {
                    Destroy(hit.collider.gameObject);
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                for (int i = 0; i < 2; i++)
                {


                    if (hit.collider.gameObject.tag == "el" && i == 0)
                    {
                        Instantiate(elementrandom().gameObject, hit.point + Vector3.up * elementrandom().gameObject.transform.localScale.y / 2, Quaternion.identity);

                        Destroy(hit.collider.gameObject);
                        return;
                    }

                }
            }

        }

        if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementName == "script" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                //  GameObject g = Instantiate(Resources.Load<GameObject>("ui/script/ui"), Vector3.zero, Quaternion.identity);
                //   g.GetComponent<script>().sc = hit.collider.gameObject;
                //   setItem("", 0, Color.red, selectr);
                //  Cells[selectr].UpdateCellInterface();
                script.Use(Cells[selectr].elementData.Replace('♥', ' ').Replace('♦', '\n'), hit.collider.gameObject);
                cistalenemy.dies++;
                //  Global.PauseManager.Pause();
            }

        }
        if (Input.GetKeyDown(KeyCode.R) && Cells[selectr].elementName == "Диплом_о_минимальном_образовании" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (FindObjectsByType<script>(sortmode.main).Length < 1) if (hit.collider != null)
                    {
                        GameObject g = Instantiate(Resources.Load<GameObject>("ui/script/ui"), Vector3.zero, Quaternion.identity);
                        g.GetComponent<script>().Magic_obj = hit.collider.gameObject;
                        g.GetComponent<script>().Magic_stick = true;
                        //   setItem("", 0, Color.red, selectr);
                        //  Cells[selectr].UpdateCellInterface();
                        //  script.Use((Cells[selectr].elementData.Replace('_', ' ')).Replace('^', '\n'), hit.collider.gameObject);
                        cistalenemy.dies++;
                        Global.PauseManager.Pause();
                    }
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementName == "Диплом_о_минимальном_образовании" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (!hit.collider.GetComponent<CharacterStats>())
                {
                    hit.collider.gameObject.AddComponent<CharacterStats>().data.IQ += 10;
                }
                if (hit.collider.GetComponent<CharacterStats>())
                {
                    hit.collider.GetComponent<CharacterStats>().data.IQ += 10;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Q) && Cells[selectr].elementName == "Диплом_о_минимальном_образовании" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (!hit.collider.GetComponent<CharacterStats>())
                {
                    hit.collider.gameObject.AddComponent<CharacterStats>().data.IQ -= 10;
                }
                if (hit.collider.GetComponent<CharacterStats>())
                {
                    hit.collider.GetComponent<CharacterStats>().data.IQ -= 10;
                }
            }

        }
        //Учебник_по_Всемогуществу
        if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementName == "script.u" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                //  GameObject g = Instantiate(Resources.Load<GameObject>("ui/script/ui"), Vector3.zero, Quaternion.identity);
                //   g.GetComponent<script>().sc = hit.collider.gameObject;
                //   setItem("", 0, Color.red, selectr);
                //  Cells[selectr].UpdateCellInterface();
                UnsFormat uf = new UnsFormat();
                uf.script = Cells[selectr].elementData.Replace('♥', ' ').Replace('♦', '\n');
                hit.collider.gameObject.AddComponent<unScript>().ins = uf;
                cistalenemy.dies++;
                //  Global.PauseManager.Pause();
            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad1) && Cells[selectr].elementName == "Учебник_по_Всемогуществу" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                GameObject g = Instantiate(Resources.Load<GameObject>("ui/CraftPanel/CraftPanel"), Vector3.zero, Quaternion.identity);
                Element e = hit.collider.GetComponent<Element>();
                int c = (int)Global.Random.Range(0, e.element.Length);
                g.GetComponent<CargeText>().text.text = "this + " + e.element[c].element.name + " = " + e.element[c].item.name;
                cistalenemy.dies++;
            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad2) && Cells[selectr].elementName == "Учебник_по_Всемогуществу" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(Resources.Load<GameObject>("items/script"), mover.main().transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/script.u"), mover.main().transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/MltiverseMagicStick"), mover.main().transform.position, Quaternion.identity);

            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad3) && Cells[selectr].elementName == "Учебник_по_Всемогуществу" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(Resources.Load<GameObject>("items/RedColour"), mover.main().transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/ButtonGenerator"), mover.main().transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/Duper"), mover.main().transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/CubeNDfield"), mover.main().transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/YourJuice"), mover.main().transform.position, Quaternion.identity);
                //YourJuice
            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad4) && Cells[selectr].elementName == "Учебник_по_Всемогуществу" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(Resources.Load<GameObject>("items/DeMaker"), mover.main().transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/Deleter"), mover.main().transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/Restorer"), mover.main().transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/FilmCamera"), mover.main().transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/FilmWnidow"), mover.main().transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/builder"), mover.main().transform.position, Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/KsenoMorfin"), mover.main().transform.position, Quaternion.identity);
                //YourJuice
            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad5) && Cells[selectr].elementName == "Учебник_по_Всемогуществу" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Globalprefs.LoadTevroPrise(100);
                //YourJuice
            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad6) && Cells[selectr].elementName == "Учебник_по_Всемогуществу" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(Resources.Load<GameObject>("items/InfinityGreenPlane"), mover.main().transform.position, Quaternion.identity);
                //YourJuice
            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad7) && Cells[selectr].elementName == "Учебник_по_Всемогуществу" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Globalprefs.bunkrot = false;
                VarSave.SetBool("Bunkrot", Globalprefs.bunkrot);

                //YourJuice
                cistalenemy.dies = -10;
            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad8) && Cells[selectr].elementName == "Учебник_по_Всемогуществу" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Globalprefs.bunkrot = false;
                 DeadShit.Spawn(transform.position);

                //deathparticles
            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad9) && Cells[selectr].elementName == "Учебник_по_Всемогуществу" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(Resources.Load<GameObject>("items/1infinityByteDisk"), mover.main().transform.position + PiratAttack.randomCube(6, 6) + new Vector3(0, 6, 0), Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("items/SampleCrown"), mover.main().transform.position + PiratAttack.randomCube(6, 6) + new Vector3(0, 6, 0), Quaternion.identity);
                VarSave.SetString("ProfStatus", "King");
                //SampleCrown
                //Absolute_poison
                Globalprefs.LoadTevroPrise(2500000000);
                cistalenemy.dies -= 10000;
                Globalprefs.flowteuvro = VarSave.LoadMoney("CashFlow", 5500);
            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad0) && Cells[selectr].elementName == "Учебник_по_Всемогуществу" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                Instantiate(Resources.Load<GameObject>("DieRay").gameObject, mover.main().transform.position, mover.main().PlayerCamera.transform.rotation);

            }

        }
        // ЗельеВамперизма

        if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementName == "MltiverseMagicStick" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;


            if (FindObjectsByType<script>(sortmode.main).Length < 1) if (hit.collider != null)
                {
                    GameObject g = Instantiate(Resources.Load<GameObject>("ui/script/ui"), Vector3.zero, Quaternion.identity);
                    g.GetComponent<script>().Magic_obj = hit.collider.gameObject;
                    g.GetComponent<script>().Magic_stick = true;
                    //   setItem("", 0, Color.red, selectr);
                    //  Cells[selectr].UpdateCellInterface();
                    //  script.Use((Cells[selectr].elementData.Replace('_', ' ')).Replace('^', '\n'), hit.collider.gameObject);
                    cistalenemy.dies++;
                    Global.PauseManager.Pause();
                }

        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementName == "MinecraftSandStick" && main() == this)
        {
            RaycastHit hit = MainRay.MainHit;
            GameObject g = Resources.Load<GameObject>("items/FallingSandFromMinecraft");
            for (int i = 0; i < 30; i++)
            {
                Instantiate(g, hit.point + (Vector3.up * i), Quaternion.identity);
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKey(KeyCode.Mouse1) && Cells[selectr].elementName == "builder" && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;
            
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.layer != 6)
                    {
                        Instantiate(inv2("пена").gameObject, hit.point + Vector3.up * inv2("пена").gameObject.transform.localScale.y / 2, Quaternion.identity);

                    }
                }




                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.layer == 6)
                    {
                        if (hit.point.x > hit.collider.transform.position.x + 0.4f)
                        {
                            Instantiate(inv2("пена").gameObject, hit.collider.transform.position + Vector3.right, Quaternion.identity);
                        }

                    }
                    if (hit.collider.gameObject.layer == 6)
                    {
                        if (hit.point.x < hit.collider.transform.position.x - 0.4f)
                        {
                            Instantiate(inv2("пена").gameObject, hit.collider.transform.position - Vector3.right, Quaternion.identity);
                        }

                    }
                    if (hit.collider.gameObject.layer == 6)
                    {
                        if (hit.point.y > hit.collider.transform.position.y + 0.4f)
                        {
                            Instantiate(inv2("пена").gameObject, hit.collider.transform.position + Vector3.up, Quaternion.identity);
                        }

                    }
                    if (hit.collider.gameObject.layer == 6)
                    {
                        if (hit.point.y < hit.collider.transform.position.y - 0.4f)
                        {
                            Instantiate(inv2("пена").gameObject, hit.collider.transform.position - Vector3.up, Quaternion.identity);
                        }

                    }
                    if (hit.collider.gameObject.layer == 6)
                    {
                        if (hit.point.z > hit.collider.transform.position.z + 0.4f)
                        {
                            Instantiate(inv2("пена").gameObject, hit.collider.transform.position + Vector3.forward, Quaternion.identity);
                        }

                    }
                    if (hit.collider.gameObject.layer == 6)
                    {
                        if (hit.point.z < hit.collider.transform.position.z - 0.4f)
                        {
                            Instantiate(inv2("пена").gameObject, hit.collider.transform.position - Vector3.forward, Quaternion.identity);
                        }

                    }
                }

            
            else if (FindObjectsByType<HyperbolicCamera>(sortmode.main).Length > 0)
            {

                if (hit.collider != null)
                {
                    Vector3 v3;
                    v3 = hit.point - GameManager.isplayer().position;
                    v3 /= 20;
                    HyperbolicCamera c = HyperbolicCamera.Main();


                    Transform t = Instantiate(inv2("пена").gameObject, Vector3.up * inv2("пена").gameObject.transform.localScale.y / 2, Quaternion.identity).transform;
                    t.Translate(0, v3.y, 0);
                    t.gameObject.AddComponent<HyperbolicPoint>().HyperboilcPoistion = c.RealtimeTransform.inverse();
                    t.gameObject.GetComponent<HyperbolicPoint>().v1 = c.transform.position.y;
                    t.gameObject.GetComponent<HyperbolicPoint>().HyperboilcPoistion.applyTranslationY(-v3.z);
                    t.gameObject.GetComponent<HyperbolicPoint>().HyperboilcPoistion.applyTranslationZ(-v3.x);
                    t.gameObject.GetComponent<HyperbolicPoint>().ScriptSacle = inv2("пена").gameObject.transform.localScale;
                    //Instantiate(inv2("пена").gameObject, hit.collider.transform.position + Vector3.right, Quaternion.identity);

                }

            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && priaritet("gold") != 0 && Cells[selectr].elementName == "pistol" && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(Resources.Load<GameObject>("DamageObject").gameObject, hit.point + Vector3.up * Resources.Load<GameObject>("DamageObject").gameObject.transform.localScale.y / 2, Quaternion.identity);

                cistalenemy.dies++;
            }

            lowitem("gold", "");
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Cells[selectr].elementName == "МонокварковыйМеч" && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(Resources.Load<GameObject>("DamagePlane").gameObject, mover.main().PlayerCamera.transform.position, mover.main().PlayerCamera.transform.rotation);

                cistalenemy.dies++;
            }

        }
        if (Input.GetKey(KeyCode.Mouse0) && Cells[selectr].elementName == "SunFireGen" && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(inv2("Fire").gameObject, hit.point + Vector3.up * inv2("Fire").gameObject.transform.localScale.y / 2, Quaternion.identity);

                cistalenemy.dies++;
            }

        }
        if (Input.GetKey(KeyCode.Mouse0) && Cells[selectr].elementName == "Обосанная_зажига" && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(inv2("Piss").gameObject, hit.point + Vector3.up * inv2("Piss").gameObject.transform.localScale.y / 2, Quaternion.identity);

                cistalenemy.dies++;
            }

        }
        if (Input.GetKey(KeyCode.Mouse0) && Cells[selectr].elementName == "Хлебапекрная_зажигалка" && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(inv2("Хлеб").gameObject, hit.point + Vector3.up * inv2("Хлеб").gameObject.transform.localScale.y / 2, Quaternion.identity);

            }

        }
        if (Input.GetKey(KeyCode.Mouse0) && Cells[selectr].elementName == "Поглтитель_душ" && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                MonoBehaviour[] mb = hit.collider.gameObject.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour item in mb)
                {
                    item.enabled = false;
                }
            }

        }
        //Хлебапекрна_зажигалка
        //АвтоматКалашникорва
        if (Input.GetKey(KeyCode.Mouse0) && Cells[selectr].elementName == "АвтоматКалашникорва" && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(Resources.Load<GameObject>("DamageObject").gameObject, hit.point + Vector3.up * Resources.Load<GameObject>("DamageObject").gameObject.transform.localScale.y / 2, Quaternion.identity);

                cistalenemy.dies++;
            }


        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Cells[selectr].elementName == "infinity_gun" && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(Resources.Load<GameObject>("DamageObject").gameObject, hit.point + Vector3.up * Resources.Load<GameObject>("DamageObject").gameObject.transform.localScale.y / 2, Quaternion.identity);

                cistalenemy.dies++;
            }


        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Cells[selectr].elementName == "Ban_gun" && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(Resources.Load<GameObject>("BanObject").gameObject, hit.point + Vector3.up * Resources.Load<GameObject>("BanObject").gameObject.transform.localScale.y / 2, Quaternion.identity);

                cistalenemy.dies++;
            }


        }
        if (Input.GetKey(KeyCode.Mouse0) && Cells[selectr].elementName == "RayGun" && main() == this)
        {

            if (JsonUtility.FromJson<GeneratorEnergyData>(Cells[selectr].elementData).energy > 0)
            {
                GeneratorEnergyData ged;
                ged = JsonUtility.FromJson<GeneratorEnergyData>(Cells[selectr].elementData);
                ged.energy = (JsonUtility.FromJson<GeneratorEnergyData>(Cells[selectr].elementData).energy - 12);

                Cells[selectr].elementData = JsonUtility.ToJson(ged);

                Instantiate(Resources.Load<GameObject>("DamageRay").gameObject, mover.main().transform.position, mover.main().PlayerCamera.transform.rotation);


            }


        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Cells[selectr].elementName == "Умножение" && main() == this)
            {

                RaycastHit hit = MainRay.MainHit;

                if (hit.collider != null)
                {
                    if (int.Parse(Cells[selectr].elementData) > 0) for (int i = 0; i < int.Parse(Cells[selectr].elementData); i++)
                        {
                            GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(0, 1f + (1f * i), 0)), Quaternion.identity);
                            obj.name = obj.name.Remove(obj.name.Length - 7);
                        }
                    if (int.Parse(Cells[selectr].elementData) == 0)
                    {
                        Destroy(gameObject);
                    }
                }

            }
            if (Cells[selectr].elementName == "КвадратноеУмножение" && main() == this)
            {

                RaycastHit hit = MainRay.MainHit;

                if (hit.collider != null)
                {
                    if (int.Parse(Cells[selectr].elementData) > 0) for (int x = 0; x < int.Parse(Cells[selectr].elementData); x++)
                        {
                            for (int y = 0; y < int.Parse(Cells[selectr].elementData); y++)
                            {
                                GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 0, 1f + (1f * y))), Quaternion.identity);
                                obj.name = obj.name.Remove(obj.name.Length - 7);
                            }
                        }
                    if (int.Parse(Cells[selectr].elementData) == 0)
                    {
                        Destroy(gameObject);
                    }
                }

            }
            if (Cells[selectr].elementName == "КубическоеУмножение" && main() == this)
            {

                RaycastHit hit = MainRay.MainHit;

                if (hit.collider != null)
                {
                    if (int.Parse(Cells[selectr].elementData) > 0) for (int x = 0; x < int.Parse(Cells[selectr].elementData); x++)
                        {
                            for (int y = 0; y < int.Parse(Cells[selectr].elementData); y++)
                            {
                                for (int z = 0; z < int.Parse(Cells[selectr].elementData); z++)
                                {
                                    GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 1f + (1f * y), 1f + (1f * z))), Quaternion.identity);
                                    obj.name = obj.name.Remove(obj.name.Length - 7);
                                }
                            }
                        }
                    if (int.Parse(Cells[selectr].elementData) == 0)
                    {
                        Destroy(gameObject);
                    }
                }

            }
            if (Cells[selectr].elementName == "ТессерактноеУмножение" && main() == this)
            {

                RaycastHit hit = MainRay.MainHit;

                if (hit.collider != null)
                {
                    if (int.Parse(Cells[selectr].elementData) > 0) for (int x = 0; x < int.Parse(Cells[selectr].elementData); x++)
                        {
                            for (int y = 0; y < int.Parse(Cells[selectr].elementData); y++)
                            {
                                for (int z = 0; z < int.Parse(Cells[selectr].elementData); z++)
                                {
                                    for (int w = 0; w < int.Parse(Cells[selectr].elementData); w++)
                                    {
                                        GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 1f + (1f * y), 1f + (1f * z))), Quaternion.identity);
                                        obj.name = obj.name.Remove(obj.name.Length - 7);
                                    }
                                }
                            }
                        }
                    if (int.Parse(Cells[selectr].elementData) == 0)
                    {
                        Destroy(gameObject);
                    }
                }

            }
            if (Cells[selectr].elementName == "ПентарактноеУмножение" && main() == this)
            {

                RaycastHit hit = MainRay.MainHit;

                if (hit.collider != null)
                {
                    if (int.Parse(Cells[selectr].elementData) > 0) for (int x = 0; x < int.Parse(Cells[selectr].elementData); x++)
                        {
                            for (int y = 0; y < int.Parse(Cells[selectr].elementData); y++)
                            {
                                for (int z = 0; z < int.Parse(Cells[selectr].elementData); z++)
                                {
                                    for (int w = 0; w < int.Parse(Cells[selectr].elementData); w++)
                                    {
                                        for (int h = 0; h < int.Parse(Cells[selectr].elementData); h++)
                                        {
                                            GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 1f + (1f * y), 1f + (1f * z))), Quaternion.identity);
                                            obj.name = obj.name.Remove(obj.name.Length - 7);

                                        }
                                    }
                                }
                            }
                        }
                    if (int.Parse(Cells[selectr].elementData) == 0)
                    {
                        Destroy(gameObject);
                    }
                }

            }
            if (Cells[selectr].elementName == "СикстерактноеУмножение" && main() == this)
            {

                RaycastHit hit = MainRay.MainHit;

                if (hit.collider != null)
                {
                    if (int.Parse(Cells[selectr].elementData) > 0) for (int x = 0; x < int.Parse(Cells[selectr].elementData); x++)
                        {
                            for (int y = 0; y < int.Parse(Cells[selectr].elementData); y++)
                            {
                                for (int z = 0; z < int.Parse(Cells[selectr].elementData); z++)
                                {
                                    for (int w = 0; w < int.Parse(Cells[selectr].elementData); w++)
                                    {
                                        for (int h = 0; h < int.Parse(Cells[selectr].elementData); h++)
                                        {
                                            for (int p = 0; p < int.Parse(Cells[selectr].elementData); p++)
                                            {
                                                GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 1f + (1f * y), 1f + (1f * z))), Quaternion.identity);
                                                obj.name = obj.name.Remove(obj.name.Length - 7);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    if (int.Parse(Cells[selectr].elementData) == 0)
                    {
                        Destroy(gameObject);
                    }
                }

            }
            if (Cells[selectr].elementName == "СемирактноеУмножение" && main() == this)
            {

                RaycastHit hit = MainRay.MainHit;

                if (hit.collider != null)
                {
                    if (int.Parse(Cells[selectr].elementData) > 0) for (int x = 0; x < int.Parse(Cells[selectr].elementData); x++)
                        {
                            for (int y = 0; y < int.Parse(Cells[selectr].elementData); y++)
                            {
                                for (int z = 0; z < int.Parse(Cells[selectr].elementData); z++)
                                {
                                    for (int w = 0; w < int.Parse(Cells[selectr].elementData); w++)
                                    {
                                        for (int h = 0; h < int.Parse(Cells[selectr].elementData); h++)
                                        {
                                            for (int p = 0; p < int.Parse(Cells[selectr].elementData); p++)
                                            {
                                                for (int s = 0; s < int.Parse(Cells[selectr].elementData); s++)
                                                {
                                                    GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 1f + (1f * y), 1f + (1f * z))), Quaternion.identity);
                                                    obj.name = obj.name.Remove(obj.name.Length - 7);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    if (int.Parse(Cells[selectr].elementData) == 0)
                    {
                        Destroy(gameObject);
                    }
                }

            }
            if (Cells[selectr].elementName == "ОкторактноеУмножение" && main() == this)
            {

                RaycastHit hit = MainRay.MainHit;

                if (hit.collider != null)
                {
                    if (int.Parse(Cells[selectr].elementData) > 0) for (int x = 0; x < int.Parse(Cells[selectr].elementData); x++)
                        {
                            for (int y = 0; y < int.Parse(Cells[selectr].elementData); y++)
                            {
                                for (int z = 0; z < int.Parse(Cells[selectr].elementData); z++)
                                {
                                    for (int w = 0; w < int.Parse(Cells[selectr].elementData); w++)
                                    {
                                        for (int h = 0; h < int.Parse(Cells[selectr].elementData); h++)
                                        {
                                            for (int p = 0; p < int.Parse(Cells[selectr].elementData); p++)
                                            {
                                                for (int s = 0; s < int.Parse(Cells[selectr].elementData); s++)
                                                {
                                                    for (int f = 0; f < int.Parse(Cells[selectr].elementData); f++)
                                                    {
                                                        GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 1f + (1f * y), 1f + (1f * z))), Quaternion.identity);
                                                        obj.name = obj.name.Remove(obj.name.Length - 7);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    if (int.Parse(Cells[selectr].elementData) == 0)
                    {
                        Destroy(gameObject);
                    }
                }

            }
            if (Cells[selectr].elementName == "НовеморактноеУмножение" && main() == this)
            {

                RaycastHit hit = MainRay.MainHit;

                if (hit.collider != null)
                {
                    if (int.Parse(Cells[selectr].elementData) > 0) for (int x = 0; x < int.Parse(Cells[selectr].elementData); x++)
                        {
                            for (int y = 0; y < int.Parse(Cells[selectr].elementData); y++)
                            {
                                for (int z = 0; z < int.Parse(Cells[selectr].elementData); z++)
                                {
                                    for (int w = 0; w < int.Parse(Cells[selectr].elementData); w++)
                                    {
                                        for (int h = 0; h < int.Parse(Cells[selectr].elementData); h++)
                                        {
                                            for (int p = 0; p < int.Parse(Cells[selectr].elementData); p++)
                                            {
                                                for (int s = 0; s < int.Parse(Cells[selectr].elementData); s++)
                                                {
                                                    for (int f = 0; f < int.Parse(Cells[selectr].elementData); f++)
                                                    {
                                                        for (int c = 0; c < int.Parse(Cells[selectr].elementData); c++)
                                                        {
                                                            GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 1f + (1f * y), 1f + (1f * z))), Quaternion.identity);
                                                            obj.name = obj.name.Remove(obj.name.Length - 7);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    if (int.Parse(Cells[selectr].elementData) == 0)
                    {
                        Destroy(gameObject);
                    }
                }

            }
            if (Cells[selectr].elementName == "ДесерактноеУмножение" && main() == this)
            {

                RaycastHit hit = MainRay.MainHit;

                if (hit.collider != null)
                {
                    if (int.Parse(Cells[selectr].elementData) > 0) for (int x = 0; x < int.Parse(Cells[selectr].elementData); x++)
                        {
                            for (int y = 0; y < int.Parse(Cells[selectr].elementData); y++)
                            {
                                for (int z = 0; z < int.Parse(Cells[selectr].elementData); z++)
                                {
                                    for (int w = 0; w < int.Parse(Cells[selectr].elementData); w++)
                                    {
                                        for (int h = 0; h < int.Parse(Cells[selectr].elementData); h++)
                                        {
                                            for (int p = 0; p < int.Parse(Cells[selectr].elementData); p++)
                                            {
                                                for (int s = 0; s < int.Parse(Cells[selectr].elementData); s++)
                                                {
                                                    for (int f = 0; f < int.Parse(Cells[selectr].elementData); f++)
                                                    {
                                                        for (int c = 0; c < int.Parse(Cells[selectr].elementData); c++)
                                                        {
                                                            for (int o = 0; o < int.Parse(Cells[selectr].elementData); o++)
                                                            {
                                                                GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 1f + (1f * y), 1f + (1f * z))), Quaternion.identity);
                                                                obj.name = obj.name.Remove(obj.name.Length - 7);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    if (int.Parse(Cells[selectr].elementData) == 0)
                    {
                        Destroy(gameObject);
                    }
                }

            }
            if (Cells[selectr].elementName == "УдециморактноеУмножение" && main() == this)
            {

                RaycastHit hit = MainRay.MainHit;

                if (hit.collider != null)
                {
                    if (int.Parse(Cells[selectr].elementData) > 0) for (int x = 0; x < int.Parse(Cells[selectr].elementData); x++)
                        {
                            for (int y = 0; y < int.Parse(Cells[selectr].elementData); y++)
                            {
                                for (int z = 0; z < int.Parse(Cells[selectr].elementData); z++)
                                {
                                    for (int w = 0; w < int.Parse(Cells[selectr].elementData); w++)
                                    {
                                        for (int h = 0; h < int.Parse(Cells[selectr].elementData); h++)
                                        {
                                            for (int p = 0; p < int.Parse(Cells[selectr].elementData); p++)
                                            {
                                                for (int s = 0; s < int.Parse(Cells[selectr].elementData); s++)
                                                {
                                                    for (int f = 0; f < int.Parse(Cells[selectr].elementData); f++)
                                                    {
                                                        for (int c = 0; c < int.Parse(Cells[selectr].elementData); c++)
                                                        {
                                                            for (int o = 0; o < int.Parse(Cells[selectr].elementData); o++)
                                                            {
                                                                for (int t = 0; t < int.Parse(Cells[selectr].elementData); t++)
                                                                {
                                                                    GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 1f + (1f * y), 1f + (1f * z))), Quaternion.identity);
                                                                    obj.name = obj.name.Remove(obj.name.Length - 7);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    if (int.Parse(Cells[selectr].elementData) == 0)
                    {
                        Destroy(gameObject);
                    }
                }

            }
            if (Cells[selectr].elementName == "ДуодециморактноеУмножение" && main() == this)
            {

                RaycastHit hit = MainRay.MainHit;

                if (hit.collider != null)
                {
                    if (int.Parse(Cells[selectr].elementData) > 0) for (int x = 0; x < int.Parse(Cells[selectr].elementData); x++)
                        {
                            for (int y = 0; y < int.Parse(Cells[selectr].elementData); y++)
                            {
                                for (int z = 0; z < int.Parse(Cells[selectr].elementData); z++)
                                {
                                    for (int w = 0; w < int.Parse(Cells[selectr].elementData); w++)
                                    {
                                        for (int h = 0; h < int.Parse(Cells[selectr].elementData); h++)
                                        {
                                            for (int p = 0; p < int.Parse(Cells[selectr].elementData); p++)
                                            {
                                                for (int s = 0; s < int.Parse(Cells[selectr].elementData); s++)
                                                {
                                                    for (int f = 0; f < int.Parse(Cells[selectr].elementData); f++)
                                                    {
                                                        for (int c = 0; c < int.Parse(Cells[selectr].elementData); c++)
                                                        {
                                                            for (int o = 0; o < int.Parse(Cells[selectr].elementData); o++)
                                                            {
                                                                for (int t = 0; t < int.Parse(Cells[selectr].elementData); t++)
                                                                {
                                                                    for (int e = 0; e < int.Parse(Cells[selectr].elementData); e++)
                                                                    {
                                                                        GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 1f + (1f * y), 1f + (1f * z))), Quaternion.identity);
                                                                        obj.name = obj.name.Remove(obj.name.Length - 7);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    if (int.Parse(Cells[selectr].elementData) == 0)
                    {
                        Destroy(gameObject);
                    }
                }

            }
        }
        //ТессерактноеУмножение
        if (Input.GetKeyDown(KeyCode.Mouse0) && !batteytype && priaritet(nameItem(Cells[selectr].elementName)) != 0 && Cells[selectr].elementCount != 0 && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<GeneratorEnergy>())
                {
                    if (hit.collider.GetComponent<GeneratorEnergy>().TypeGenergy == GeneratorEnergyType.bio)
                    {

                        lowitem(nameItem(Cells[selectr].elementName), "");
                        hit.collider.GetComponent<GeneratorEnergy>().energyData.energy += 25;
                        hit.collider.GetComponent<GeneratorEnergy>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<GeneratorEnergy>().energyData);

                    }
                }
            }



        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && weitghtelemets && !batteytype && Cells[selectr].elementCount != 0 && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<GeneratorEnergy>())
                {
                    if (hit.collider.GetComponent<GeneratorEnergy>().TypeGenergy == GeneratorEnergyType.atom)
                    {

                        Cells[selectr].elementName = "";
                        Cells[selectr].elementCount = 0;
                        Cells[selectr].UpdateCellInterface();
                        hit.collider.GetComponent<GeneratorEnergy>().energyData.atomenergy += 10;
                        hit.collider.GetComponent<GeneratorEnergy>().energyData.atomenergy %= 100;
                        hit.collider.GetComponent<GeneratorEnergy>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<GeneratorEnergy>().energyData);

                    }
                }
            }



        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementCount != 0 && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<InfinityByteDisk>())
                {

                    hit.collider.GetComponent<InfinityByteDisk>().itemsinfo.namesitem.Add(Cells[selectr].elementName);
                    hit.collider.GetComponent<InfinityByteDisk>().itemsinfo.datasitem.Add(Cells[selectr].elementData);
                    hit.collider.GetComponent<InfinityByteDisk>().itemsinfo.socialsitem.Add(Cells[selectr].elementSocial);
                    hit.collider.GetComponent<InfinityByteDisk>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<InfinityByteDisk>().itemsinfo);

                    setItem("", 0, Color.red, selectr);

                    Cells[selectr].UpdateCellInterface();
                }
            }



        }
        else if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementCount == 0 && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<InfinityByteDisk>())
                {

                    List<string> s = hit.collider.GetComponent<InfinityByteDisk>().itemsinfo.namesitem;
                    List<string> s2 = hit.collider.GetComponent<InfinityByteDisk>().itemsinfo.datasitem;
                    List<string> s3 = hit.collider.GetComponent<InfinityByteDisk>().itemsinfo.socialsitem;

                    setItem(s[s.Count - 1], 1, Color.red, s2[s2.Count - 1], s3[s3.Count - 1], selectr);

                    Cells[selectr].UpdateCellInterface();


                    s.RemoveAt(s.Count - 1);
                    s2.RemoveAt(s2.Count - 1);
                    s3.RemoveAt(s3.Count - 1);
                    hit.collider.GetComponent<InfinityByteDisk>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<InfinityByteDisk>().itemsinfo);

                }
            }



        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementCount != 0 && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ComputerSave>())
                {
                    if (hit.collider.GetComponent<ComputerSave>().SigIn)
                    {
                        
                    hit.collider.GetComponent<ComputerSave>().itemsinfo.namesitem.Add(Cells[selectr].elementName);
                    hit.collider.GetComponent<ComputerSave>().itemsinfo.datasitem.Add(Cells[selectr].elementData);
                    hit.collider.GetComponent<ComputerSave>().itemsinfo.socialsitem.Add(Cells[selectr].elementSocial);

                        hit.collider.GetComponent<ComputerSave>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<ComputerSave>().itemsinfo);

                        setItem("", 0, Color.red, selectr);

                        Cells[selectr].UpdateCellInterface();
                    }
                }
            }



        }
        else if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementCount == 0 && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ComputerSave>())
                {
                    if (hit.collider.GetComponent<ComputerSave>().SigIn)
                    {
                        List<string> s = hit.collider.GetComponent<ComputerSave>().itemsinfo.namesitem;
                        List<string> s2 = hit.collider.GetComponent<ComputerSave>().itemsinfo.datasitem;
                        List<string> s3 = hit.collider.GetComponent<ComputerSave>().itemsinfo.socialsitem;

                        setItem(s[s.Count - 1], 1, Color.red, s2[s2.Count - 1], s3[s3.Count - 1], selectr);

                        Cells[selectr].UpdateCellInterface();


                        s.RemoveAt(s.Count - 1);
                        s2.RemoveAt(s2.Count - 1);
                        s3.RemoveAt(s3.Count - 1);
                    }

                }
            }



        }
      
       
        if (Input.GetKeyDown(KeyCode.Mouse0) && batteytype && Cells[selectr].elementCount != 0 && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;


            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<accumulator>())
                {
                    hit.collider.GetComponent<accumulator>().energy = (float.Parse(hit.collider.GetComponent<accumulator>().energy) + float.Parse(Cells[selectr].elementData)).ToString();
                    hit.collider.GetComponent<accumulator>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<accumulator>().energy;
                    Cells[selectr].elementData = "0";
                    //  Cells[selectr].elementData = 
                }
            }



        }
        // Grimoire_Gravity_Sphere_(1000000000)
        if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementName == "Grimoire_Gravity_Sphere_(1000000000)" && priaritet(nameItem(Cells[selectr].elementName)) != 0 && Cells[selectr].elementCount != 0 && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;


            Instantiate(inv2("UcnaHole").gameObject, hit.point + Vector3.up * inv2("UcnaHole").gameObject.transform.localScale.y / 2, Quaternion.identity);



        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementName == "Насос" && Cells[selectr].elementCount != 0 && main() == this)
        {

            mover.main().transform.localScale += mover.main().transform.localScale / 10;
            mover.main().CamDistanceMult += mover.main().CamDistanceMult / 10;



        }
        decimal C_Fool = 1000000000;
        decimal C_Position = VarSave.GetMoney("C_late") % C_Fool;

        if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementName == "Удочка" && Cells[selectr].elementCount != 0 && main() == this)
        {

            GameObject obj = Instantiate(Resources.Load<GameObject>("Поплывок"), mover.main().transform.position + mover.main().PlayerCamera.transform.forward, Quaternion.identity);

            obj.GetComponent<Rigidbody>().AddForce(mover.main().PlayerCamera.transform.forward * 10, ForceMode.Impulse);

        }
        if (Input.GetKeyDown(KeyCode.Q) && Cells[selectr].elementName == "Удочка" && Cells[selectr].elementCount != 0 && main() == this)
        {

            Поплывок[] pplv = FindObjectsByType<Поплывок>(sortmode.main);
            foreach (Поплывок item in pplv)
            {
                if (item.povid == povidПоплывок.klyoet)
                {
                    item.gameObject.AddComponent<Poplovok>();
                }
            }
           
        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementName == "ContinuumCloner" && Cells[selectr].elementCount != 0 && main() == this)
        {

            Directory.CreateDirectory("unsave/maps");

            Map_saver.ObjectSaveManager.SaveMap("unsave/maps/_Continuum" + (VarSave.LoadMoney("C_max", 0) % C_Fool));
            VarSave.LoadMoney("C_max", 1);



        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && Cells[selectr].elementName == "ContinuumCloner" && Cells[selectr].elementCount != 0 && main() == this)
        {

            Map_saver.ObjectSaveManager.SaveMap("unsave/maps/_Continuum" + C_Position % C_Fool);
            C_Position++; C_Position %= C_Fool;
            Debug.Log(C_Position);
            if (File.Exists("unsave/maps/_Continuum" + C_Position.ToString() + ".map"))
            {
                MapData r = new MapData();

                r = JsonUtility.FromJson<MapData>(File.ReadAllText("unsave/maps/_Continuum" + C_Position.ToString() + ".map"));
                Map_saver.mapLoad = "unsave/maps/_Continuum" + C_Position.ToString() + ".map";
                VarSave.SetMoney("C_late", C_Position % C_Fool);
                SceneManager.LoadSceneAsync(r.sceneName); 
            }

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && Cells[selectr].elementName == "ContinuumCloner" && Cells[selectr].elementCount != 0 && main() == this)
        {

            Map_saver.ObjectSaveManager.SaveMap("unsave/maps/_Continuum" + C_Position % C_Fool);
            C_Position--; C_Position %= C_Fool;
            Debug.Log(C_Position);
            if (File.Exists("unsave/maps/_Continuum" + C_Position.ToString()+".map"))
            {
                MapData r = new MapData();

                r = JsonUtility.FromJson<MapData>(File.ReadAllText("unsave/maps/_Continuum" + C_Position.ToString() + ".map"));
                Map_saver.mapLoad = "unsave/maps/_Continuum" + C_Position.ToString() + ".map"; 
                VarSave.SetMoney("C_late", C_Position % C_Fool);
                SceneManager.LoadSceneAsync(r.sceneName);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && Cells[selectr].elementName == "Насос" && Cells[selectr].elementCount != 0 && main() == this)
        {

            mover.main().transform.localScale -= mover.main().transform.localScale / 10;
            mover.main().CamDistanceMult -= mover.main().CamDistanceMult / 10;




        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementName != "mathimatic_battery" && batteytype && priaritet(nameItem(Cells[selectr].elementName)) != 0 && Cells[selectr].elementCount != 0 && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;


            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<accumulator>() && float.Parse(hit.collider.GetComponent<accumulator>().energy) - 100 >= 0)
                {
                    hit.collider.GetComponent<accumulator>().energy = (float.Parse(hit.collider.GetComponent<accumulator>().energy) - 100).ToString();
                    hit.collider.GetComponent<accumulator>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<accumulator>().energy;

                    Cells[selectr].elementData = (float.Parse(Cells[selectr].elementData) + 100).ToString();
                    //  Cells[selectr].elementData = 
                }
            }



        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementName == "mathimatic_battery" && priaritet(nameItem(Cells[selectr].elementName)) != 0 && Cells[selectr].elementCount != 0 && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;


            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<accumulator>())
                {
                    float energy = float.Parse(hit.collider.GetComponent<accumulator>().energy);
                    hit.collider.GetComponent<accumulator>().energy = (0).ToString();
                    hit.collider.GetComponent<accumulator>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<accumulator>().energy;

                    Cells[selectr].elementData = (float.Parse(Cells[selectr].elementData) + energy).ToString();
                    //  Cells[selectr].elementData = 
                }
            }



        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementName == "Чип-Подчинеия" && Cells[selectr].elementCount != 0 && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;


            if (hit.collider != null)
            {
                if (!hit.collider.GetComponent<Slave>())
                {
                    hit.collider.gameObject.AddComponent<Slave>();
                    setItem("", 0, Color.red, selectr);

                    Cells[selectr].UpdateCellInterface();
                }
            }



        }
        if (Cells[selectr].elementName.Length > 2 && Cells[selectr].elementName.Remove(3, Cells[selectr].elementName.Length - 3) == "co!")
        {
            if (Input.GetKeyDown(KeyCode.E) && main() == this)
            {

                
                            CustomObjectData cod = JsonUtility.FromJson<CustomObjectData>(File.ReadAllText("res/UserWorckspace/Items/"+ Cells[selectr].elementName.Replace("co!","") + ".txt"));
                            if (cod.standartKey == StandartKey.E)
                            {
                                CustomFunctionalItem(cod);
                            }
                    
                



            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this)
            {

               
                            CustomObjectData cod = JsonUtility.FromJson<CustomObjectData>(File.ReadAllText("res/UserWorckspace/Items/" + Cells[selectr].elementName.Replace("co!", "") + ".txt"));
                            if (cod.standartKey == StandartKey.leftmouse)
                            {



                                CustomFunctionalItem(cod);
                            }
                    

                



            }
            if (Input.GetKeyDown(KeyCode.LeftShift) && main() == this)
            {

                DirectoryInfo dif = new DirectoryInfo("res/UserWorckspace/Items");

               
                            CustomObjectData cod = JsonUtility.FromJson<CustomObjectData>(File.ReadAllText("res/UserWorckspace/Items/" + Cells[selectr].elementName.Replace("co!", "")+".txt"));
                            if (cod.standartKey == StandartKey.leftshift)
                            {



                                CustomFunctionalItem(cod);
                            }
                   
                



            }
            if (Input.GetKeyDown(KeyCode.Q) && main() == this)
            {

                DirectoryInfo dif = new DirectoryInfo("res/UserWorckspace/Items");

               
                            CustomObjectData cod = JsonUtility.FromJson<CustomObjectData>(File.ReadAllText("res/UserWorckspace/Items/" + Cells[selectr].elementName.Replace("co!", "") + ".txt"));
                            if (cod.standartKey == StandartKey.Q)
                            {



                                CustomFunctionalItem(cod);
                            }
                 



            }
        }
        //  1infinityByteDisk
        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Mouse0) && Getitem("ionic_cube") && priaritet("ionic_cube") != 1 + 1 && main() == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                for (int i = 0; i < 200; i++)
                {


                    Instantiate(inv2("bomb").gameObject, hit.point + Vector3.up * inv2("bomb").gameObject.transform.localScale.y / 2, Quaternion.identity);

                    cistalenemy.dies++;
                }

            }


            ionenergy.energy = 1;
            lowioncube("ionic_cube");

        }
        //ionic_cube
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("file_рыбы") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Meats", 1);

            VarSave.LoadFloat("mana", 1f);
            lowitem("file_рыбы", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("belock") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Meats", 1);
            int i = (int)Global.Random.Range(0, 3);
            if (i == 0)
            {
                Instantiate(Resources.Load("voices/belock"));
            }
            VarSave.LoadFloat("mana", 1f);

            lowitem("belock", "seed");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //4Dvkusnashka
        //СвитокПравды
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("4Dvkusnashka") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));
            playerdata.Addeffect("Trin", 60);


            VarSave.LoadFloat("mana", 1f);
            lowitem("4Dvkusnashka", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("ЗлойМультик") != 0 && main() == this)
        {

            if (VarSave.GetFloat("Vorast" + "_gameSettings", SaveType.global) > 18)
            {
                GameManager.saveandhill();

                VarSave.LoadMoney("Meats", 1);
                SceneManager.LoadScene("Disclamer");


                VarSave.LoadFloat("mana", 1f);
                lowitem("ЗлойМультик", "Пустота в сердце");
                GlobalInputMenager.KeyCode_eat = 0;
            }
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("СвитокПравды") != 0 && main() == this)
        {
            SceneManager.LoadSceneAsync("room90");

            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Grib") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));
            playerdata.Addeffect("Trip", 60);


            VarSave.LoadFloat("mana", 1f);
            lowitem("Grib", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Vodka(100 градусов)") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));
            playerdata.Addeffect("Trip", 120);
            DirectoryInfo directory = new DirectoryInfo("res/UserWorckspace/Iterface");
            FileInfo[] now = directory.GetFiles();
            for (int i = 0; i < 1; i++)
            {
                Acaunt.Spawn((now[Random.Range(0, now.Length)].Name).Replace(".json", ""));
            }
            VarSave.LoadFloat("mana", 1f);
            lowitem("Vodka(100 градусов)", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("СамагонДеда") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));

            playerdata.Addeffect("InfaltionUp", 120);
            playerdata.Addeffect("MetabolismUp", 120);
            playerdata.Addeffect("Tripl3", 120);
            DirectoryInfo directory = new DirectoryInfo("res/UserWorckspace/Iterface");
            FileInfo[] now = directory.GetFiles();
            for (int i = 0; i < 7; i++)
            {
                Acaunt.Spawn((now[Random.Range(0, now.Length)].Name).Replace(".json", ""));
            }
            VarSave.LoadFloat("mana", 1f);
            lowitem("СамагонДеда", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Гашиш") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));

            playerdata.Addeffect("mild hangover", 120);
            playerdata.Addeffect("Tripl3", 120);
            VarSave.LoadFloat("mana", 1f);
            lowitem("Гашиш", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("U") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Shits", 1);

            //  Instantiate(Resources.Load("voices/belock"));



            VarSave.LoadFloat("mana", 1f);
            lowitem("U", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("пильмени") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Meats", 1);

            //  Instantiate(Resources.Load("voices/belock"));



            VarSave.LoadFloat("mana", 1f);
            lowitem("пильмени", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Мусор") != 0 && main() == this)
        {


            GameManager.saveandhill();


            VarSave.LoadMoney("Meats", 1);
            //  Instantiate(Resources.Load("voices/belock"));

            if (Global.Random.Chance(10)) VarSave.SetInt("libirist", 0);


            VarSave.LoadFloat("mana", 1f);
            lowitem("Мусор", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
      
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Мясо") != 0 && main() == this)
        {


            GameManager.saveandhill();
            VarSave.LoadMoney("Meats",1);

            //  Instantiate(Resources.Load("voices/belock"));

            if (Global.Random.Chance(10)) VarSave.SetInt("libirist", 0);


            VarSave.LoadFloat("mana", 1f);
            lowitem("Мясо", "Ca");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Клевер") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));



            VarSave.LoadFloat("mana", 1f);
            lowitem("Клевер", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Капуста") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));



            VarSave.LoadFloat("mana", 1f);
            lowitem("Капуста", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Летун") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));

            VarSave.LoadMoney("Meats", 1);


            VarSave.LoadFloat("mana", 1f);
            lowitem("Летун", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Pizza") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));

            VarSave.LoadMoney("Meats", 1);


            VarSave.LoadFloat("mana", 1f);
            lowitem("Pizza", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Пиво") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));

            VarSave.LoadMoney("Meats", 1);


            VarSave.LoadFloat("mana", 1f);
            lowitem("Пиво", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Лепёха") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));

            VarSave.LoadMoney("Meats", 1);


            VarSave.LoadFloat("mana", 1f);
            lowitem("Лепёха", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //Борщ
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Борщ") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Meats", 1);
            VarSave.LoadMoney("Shits", 1);

            VarSave.LoadMoney("Tears", 1);
            VarSave.LoadMoney("Relics", 1);

            VarSave.LoadMoney("Meats", 1);

            playerdata.Addeffect("Undyning", float.PositiveInfinity);
            playerdata.Addeffect("Шизфрения", float.PositiveInfinity);
            playerdata.Addeffect("mild hangover", float.PositiveInfinity);
            playerdata.Addeffect("Trin", float.PositiveInfinity);
            playerdata.Addeffect("Совиное Зрение", float.PositiveInfinity);
            playerdata.Addeffect("Metabolism", float.PositiveInfinity);



            VarSave.LoadFloat("mana", 100f);
            lowitem("Борщ", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("ДомТорт") != 0 && main() == this)
        {


            GameManager.saveandhill();


            VarSave.LoadMoney("Clumbs", 1);
            //  Instantiate(Resources.Load("voices/belock"));



            VarSave.LoadFloat("mana", 1f);
            lowitem("ДомТорт", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Взрыв") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));



            VarSave.LoadFloat("mana", 1f);
            lowitem("Взрыв", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Water") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));



            VarSave.LoadFloat("mana", 1f);
            lowitem("Water", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("TreeMaodelbulb") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));



            VarSave.LoadFloat("mana", 1f);
            lowitem("TreeMaodelbulb", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }//FreedomHat
        if (GlobalInputMenager.KeyCode_eat == 1 && Cells[selectr].elementName == "GPU"
         && Cells[selectr].elementCount > 0 && main() == this)
        {
            GameManager.saveandhill();

            VarSave.LoadFloat("BGPU", 1f);

            VarSave.LoadFloat("mana", 1f);
            Cells[selectr].elementName = "";
            Cells[selectr].elementCount = 0;
            Cells[selectr].elementData = "";
            Cells[selectr].UpdateCellInterface();

            Global.MEM.UE();

            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && Cells[selectr].elementName == "UT.SevenSouls"
         && Cells[selectr].elementCount > 0 && main() == this)
        {
            GameManager.saveandhill();

            VarSave.LoadFloat("SevenSouls", 1f);

            VarSave.LoadMoney("Shits", 1000);
            VarSave.LoadMoney("Clumbs", 14);
            VarSave.LoadFloat("mana", 1f);
            Cells[selectr].elementName = "";
            Cells[selectr].elementCount = 0;
            Cells[selectr].elementData = "";
            Cells[selectr].UpdateCellInterface();

            Global.MEM.UE();

            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && Cells[selectr].elementName == "PetDetermination"
         && Cells[selectr].elementCount > 0 && main() == this)
        {
            GameManager.saveandhill();

            VarSave.LoadFloat("PetDetermination", 1f);

            GameObject g = Resources.Load<GameObject>("Determination");
            Instantiate(g, transform.position,Quaternion.identity);
            VarSave.LoadMoney("Shits", 200);
            VarSave.LoadMoney("Clumbs", 2);
            VarSave.LoadFloat("mana", 1f);
            Cells[selectr].elementName = "";
            Cells[selectr].elementCount = 0;
            Cells[selectr].elementData = "";
            Cells[selectr].UpdateCellInterface();

            Global.MEM.UE();

            GlobalInputMenager.KeyCode_eat = 0;
        }
        //WinksBox
        if (GlobalInputMenager.KeyCode_eat == 1 && Cells[selectr].elementName == "WinksBox"
         && Cells[selectr].elementCount > 0 && main() == this)
        {
            GameManager.saveandhill();

            VarSave.LoadFloat("Winks", 100f);

            VarSave.LoadFloat("mana", 1f);
            Cells[selectr].elementName = "";
            Cells[selectr].elementCount = 0;
            Cells[selectr].elementData = "";
            Cells[selectr].UpdateCellInterface();

            Global.MEM.UE();

            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && Cells[selectr].elementName == "Winks"
         && Cells[selectr].elementCount > 0 && main() == this)
        {
            GameManager.saveandhill();

            VarSave.LoadFloat("Winks", 1f);

            VarSave.LoadFloat("mana", 1f);
            Cells[selectr].elementName = "";
            Cells[selectr].elementCount = 0;
            Cells[selectr].elementData = "";
            Cells[selectr].UpdateCellInterface();

            Global.MEM.UE();

            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (main() == this && !Globalprefs.Pause && Input.GetKey(KeyCode.Tab) && Input.GetKey(KeyCode.Alpha1))
        {
            GameManager.saveandhill();
            float fh = VarSave.LoadFloat("FH", 0f);
            for (int i =0;i < fh;i++)
            {
                Instantiate(Resources.Load<GameObject>("Items/FreedomHat"), mover.main().transform.position, Quaternion.identity);
            }

            VarSave.SetFloat("FH", 0f);
            Global.MEM.UE();
            
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && Cells[selectr].elementName == "FreedomHat"
         && Cells[selectr].elementCount > 0 && main() == this)
        {
            GameManager.saveandhill();

            VarSave.LoadFloat("FH", 1f);

            VarSave.LoadFloat("mana", 1f);
            Cells[selectr].elementName = "";
            Cells[selectr].elementCount = 0;
            Cells[selectr].elementData = "";
            Cells[selectr].UpdateCellInterface();

            Global.MEM.UE();

            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && Cells[selectr].elementName == "Херург-Ключ"
         && Cells[selectr].elementCount > 0 && main() == this)
        {
            GameManager.saveandhill();

            if (VarSave.GetFloat("BGPU") > 0)
            {
                VarSave.LoadFloat("BGPU", -1f);

                Instantiate(Resources.Load<GameObject>("Items/GPU"), mover.main().transform.position, Quaternion.identity);

                VarSave.LoadFloat("mana", 1f);

            }
            if (VarSave.GetFloat("Winks") > 0)
            {
                VarSave.LoadFloat("Winks", -1f);

                Instantiate(Resources.Load<GameObject>("Items/Winks"), mover.main().transform.position, Quaternion.identity);

                VarSave.LoadFloat("mana", 1f);

            }

            Global.MEM.UE();

            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Fire") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));



            VarSave.LoadFloat("mana", 1f);
            lowitem("Fire", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("BlackGrib") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));
            playerdata.Addeffect("Trip", 120);

            playerdata.Addeffect("BigShot", 100);

            VarSave.LoadFloat("mana", 1f);
            lowitem("BlackGrib", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Зелье_Чистки_Инвенторя") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));
            clear();

            VarSave.LoadFloat("mana", 1f);
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Non-exist-colour-Grib") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));
            playerdata.Addeffect("Tripl3", 120);


            VarSave.LoadFloat("mana", 1f);
            lowitem("Non-exist-colour-Grib", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //Non-exist-colour-Grib
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("jeltok") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Meats", 1);


            //  Instantiate(Resources.Load("voices/belock"));

            VarSave.LoadFloat("mana", 1f);

            lowitem("jeltok", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("mad") != 0 && main() == this)
        {


            GameManager.saveandhill();


            VarSave.LoadMoney("Meats", 1);

            //  Instantiate(Resources.Load("voices/belock"));

            playerdata.Addeffect("Tripl2", 600);

            VarSave.LoadFloat("mana", 1f);

            lowitem("mad", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Скалапендра") != 0 && main() == this)
        {


            GameManager.saveandhill();


            VarSave.LoadMoney("Meats", 1);

            //  Instantiate(Resources.Load("voices/belock"));

            cistalenemy.dies += 100;
            playerdata.Addeffect("Tripl2", 600);

            VarSave.LoadFloat("mana", 1f);

            lowitem("Скалапендра", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //Скалапендра
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("sosisca") != 0 && main() == this)
        {


            GameManager.saveandhill();
            VarSave.LoadMoney("Meats", 1);

            VarSave.LoadMoney("Shits", 1);


            int i = (int)Global.Random.Range(0, 6);
            if (i == 0)
            {
                //  Instantiate(Resources.Load("voices/belock"));
                playerdata.Addeffect("Trip", 60);
            }
            VarSave.LoadFloat("mana", 1f);

            lowitem("sosisca", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //RedColour
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("RedColour") != 0 && main() == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));
            playerdata.Cleareffect();

            VarSave.LoadFloat("mana", 1f);

            lowitem("RedColour", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //AnyphingJuice
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("AnyphingJuice") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Clumbs", 1);

            VarSave.LoadMoney("Meats", 1);

            VarSave.LoadMoney("Relics", 1);

            VarSave.LoadMoney("Tears", 1);

            VarSave.LoadMoney("Shits", 1);


            Instantiate(Resources.Load<GameObject>("Right_of_Fly"));


            VarSave.LoadFloat("mana", 1f);
            lowitem("AnyphingJuice", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("MalineColour") != 0 && main() == this)
        {


            GameManager.saveandhill();


            Instantiate(Resources.Load<GameObject>("Right_of_Fly"));

            VarSave.LoadFloat("mana", 1f);

            lowitem("MalineColour", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("BlueColour") != 0 && main() == this)
        {


            GameManager.saveandhill();

            int i = (int)Global.Random.Range(0, 2);
            if (i == 0)
            {
                playerdata.Addeffect("invisible", 60);
            }

            VarSave.LoadFloat("mana", 1f);
            lowitem("BlueColour", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("GreenColour") != 0 && main() == this)
        {


            GameManager.saveandhill();

            int i = (int)Global.Random.Range(0, 2);
            if (i == 0)
            {
                playerdata.Addeffect("Axelerate", 60);
            }

            VarSave.LoadFloat("mana", 1f);
            lowitem("GreenColour", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("UltravioletColour") != 0 && main() == this)
        {


            GameManager.saveandhill();

            int i = (int)Global.Random.Range(0, 2);
            if (i == 0)
            {
                playerdata.Addeffect("MetabolismUp", 60);
            }
            VarSave.LoadFloat("mana", 1f);

            lowitem("UltravioletColour", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Pipis") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Meats", 1);
            int i = (int)Global.Random.Range(0, 20);
            if (i == 0)
            {
                playerdata.Addeffect("BigShot", 600);

            }
            VarSave.LoadFloat("mana", 1f);

            lowitem("Pipis", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Cat") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Meats", 1);
            cistalenemy.dies += 100;

            VarSave.LoadFloat("mana", 1f);
            VarSave.SetInt("libirist", 0);
            if (FindAnyObjectByType<Lederist>())
            {

                VarSave.SetBool("lol you Banned", true);
                SceneManager.LoadSceneAsync("Banned forever");
            }
            lowitem("Cat", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Absolute_poison") != 0 && main() == this)
        {


            GameManager.saveandhill();
            VarSave.LoadMoney("Shits", 1);


            playerdata.Addeffect("BigShot", 600);
            playerdata.Addeffect("MetabolismUp", 600);
            playerdata.Addeffect("Axelerate", 600);
            playerdata.Addeffect("invisible", 600);
            playerdata.Addeffect("Trip", 600);
            playerdata.Addeffect("Tripl2", 600);

            VarSave.SetInt("libirist", 0);
            VarSave.LoadFloat("mana", 1f);


            lowitem("Absolute_poison", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Absolute_poison_II") != 0 && main() == this)
        {


            GameManager.saveandhill();
            VarSave.LoadMoney("Shits", 1);


            playerdata.Addeffect("BigShot", 600);
            playerdata.Addeffect("MetabolismUp", 600);
            playerdata.Addeffect("Axelerate", 600);
            playerdata.Addeffect("invisible", 600);
            playerdata.Addeffect("Trip", 600);
            playerdata.Addeffect("Tripl2", 600);
            playerdata.Addeffect("KsenoMorfin", 600);
            VarSave.SetInt("CurrentMorf", (int)Global.Random.Range(0, Map_saver.t5.Length));
            playerdata.Addeffect("Regeneration", 600);
            playerdata.Addeffect("ImbalenceRegeneration", 600);
            playerdata.Addeffect("severe hangover", 600);
            playerdata.Addeffect("InfaltionUp", 600);

            VarSave.SetInt("libirist", 0);
            VarSave.LoadFloat("mana", 1f);
            playerdata.FreezeAlleffect();

            lowitem("Absolute_poison_II", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("KsenoMorfin") != 0 && main() == this)
        {


            GameManager.saveandhill();
            VarSave.LoadMoney("Shits", 1);


            playerdata.Addeffect("KsenoMorfin", 600);
            VarSave.SetInt("CurrentMorf", (int)Global.Random.Range(0, Map_saver.t5.Length));
            VarSave.LoadFloat("mana", 1f);
            GameManager.saveandhill();
            lowitem("KsenoMorfin", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
            StartCoroutine(ReloadScene());

        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("StoneJuice") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Shits", 1);


            VarSave.LoadFloat("mana", 1f);


            lowitem("StoneJuice", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("AppleJuice") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadFloat("mana", 1f);

            playerdata.Addeffect("Regeneration", 600);



            lowitem("AppleJuice", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("WarQuest") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadFloat("mana", 1f);
            GameObject g = Resources.Load<GameObject>("ui/quests/killKapitalism");
            Instantiate(g, g.transform); 
            VarSave.LoadInt("CapiKill", 0);

            lowitem("WarQuest", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }

        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("DamageJuice") != 0 && main() == this)
        {


            GameManager.saveandDamage();
            VarSave.LoadMoney("Shits", 1);




            VarSave.LoadFloat("mana", 1f);

            lowitem("DamageJuice", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //ЗельеМанны
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("YourJuice") != 0 && main() == this)
        {


            GameManager.saveandhill();



            VarSave.LoadFloat("mana", 1f);
            playerdata.Addeffect("ImbalenceRegeneration", 600);

            lowitem("YourJuice", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //Зелье(БуйнойУдачи)
        //Зелье(Неудачи)
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Зелье(БуйнойУдачи)") != 0 && main() == this)
        {


            GameManager.saveandhill();



            VarSave.LoadFloat("mana", 1f);

            VarSave.LoadFloat("luck", 10f);

            lowitem("Зелье(БуйнойУдачи)", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //Зелье(Удачи)
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Зелье(Неудачи)") != 0 && main() == this)
        {


            GameManager.saveandhill();



            VarSave.LoadFloat("mana", 1f);
            VarSave.SetFloat("luck", 0f);

            lowitem("Зелье(Неудачи)", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Зелье(Удачи)") != 0 && main() == this)
        {


            GameManager.saveandhill();



            VarSave.LoadFloat("mana", 1f);
            VarSave.LoadFloat("luck", 0.1f);

            lowitem("Зелье(Удачи)", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("ЗельеМанны") != 0 && main() == this)
        {


            GameManager.saveandhill();




            VarSave.LoadFloat("mana", 5);

            lowitem("ЗельеМанны", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("ЗельеИстощения") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Shits", 1);




            VarSave.SetFloat("mana", 0);

            lowitem("ЗельеМанны", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("УнивёрсиумнаяКарточка") != 0 && main() == this)
        {


            GameManager.saveandhill();


            VarSave.LoadFloat("mana", 1f);
            playerdata.Addeffect("Unyverseium_money_cart", float.PositiveInfinity);


            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Vine") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Shits", 1);

            VarSave.LoadMoney("Meats", 1);

            VarSave.LoadFloat("mana", 1f);

            if (playerdata.Geteffect("mild hangover") != null)
            {
                playerdata.Upeffect("mild hangover", 60);
                if (playerdata.Geteffect("mild hangover").time >= 400)
                {
                    playerdata.Addeffect("severe hangover", 400);
                }
            }
            if (playerdata.Geteffect("mild hangover") == null) playerdata.Addeffect("mild hangover", 100);



            lowitem("Vine", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Дтine") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Shits", 1);

            VarSave.LoadMoney("Meats", 1);

            playerdata.Addeffect("Шизфрения", 600);

            VarSave.LoadFloat("mana", 1f);


            lowitem("Дтine", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //РекламаАрмии
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("РекламаАрмии") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Shits", 1);
            VarSave.LoadMoney("Relics", 1);


            VarSave.LoadFloat("mana", 1f);


            lowitem("РекламаАрмии", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //КамунийскийХлеб
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("HotDog") != 0 && main() == this)
        {


            GameManager.saveandhill();


            Instantiate(Resources.Load<GameObject>("Блювота"));
            VarSave.LoadMoney("Clumbs", 1);
            VarSave.LoadMoney("Meats", 1);
            VarSave.LoadMoney("Shits", 1);

            VarSave.LoadFloat("mana", 1f);


            lowitem("HotDog", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Shaverma") != 0 && main() == this)
        {


            GameManager.saveandhill();


            VarSave.LoadMoney("Clumbs", 1);
            VarSave.LoadMoney("Meats", 1);

            VarSave.LoadFloat("mana", 1f);


            lowitem("Shaverma", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("КамунийскийХлеб") != 0 && main() == this)
        {


            GameManager.saveandhill();


            VarSave.LoadMoney("Clumbs", 1);

            VarSave.LoadFloat("mana", 1f);


            lowitem("КамунийскийХлеб", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Хлеб") != 0 && main() == this)
        {


            GameManager.saveandhill();


            VarSave.LoadMoney("Clumbs", 1);

            VarSave.LoadFloat("mana", 1f);


            lowitem("Хлеб", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("EffectFreezer") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Shits", 1);

            VarSave.LoadFloat("mana", 1f);


            playerdata.FreezeAlleffect();


            lowitem("EffectFreezer", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("EffectBaker") != 0 && main() == this)
        {


            GameManager.saveandhill();


            VarSave.LoadMoney("Shits", 1);


            VarSave.LoadFloat("mana", 1f);

            playerdata.BakeAlleffect();

            lowitem("EffectBaker", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Метанфитамин") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Shits", 1);

            VarSave.LoadFloat("mana", 1f);

            playerdata.Addeffect("meat", 600);

            lowitem("Метанфитамин", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //ChaosPoution

        // ЗельеВамперизма
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("ЗельеВамперизма") != 0 && main() == this)
        {

            VarSave.LoadFloat("mana", 1f);
            playerdata.Addeffect("Vampaire", 740);
            lowitem("ЗельеВамперизма", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //Nuclear_plant
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Nuclear_plant") != 0 && main() == this)
        {
            GameManager.saveandhill();
            VarSave.LoadMoney("Shits", 1);
            for (int i = 0; i < 5; i++)
            {


                Transform t = Instantiate(inv2("Взрыв").gameObject, mover.main().transform.position, Quaternion.identity).transform;
            }
            VarSave.LoadFloat("mana", 1f);
            lowitem("Nuclear_plant", "Взрыв");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("ChaosPoution") != 0 && main() == this)
        {
            GameManager.saveandhill();
            VarSave.LoadMoney("Shits", 1);
            for (int i = 0; i < 5; i++)
            {


                Transform t = Instantiate(inv2("Chaos_cube").gameObject, mover.main().transform.position, Quaternion.identity).transform; if (t.GetComponent<itemName>())
                    Chaos_cube.ChaosFunction(t.GetComponent<Chaos_cube>());
            }

            VarSave.LoadFloat("mana", 1f);
            lowitem("ChaosPoution", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("ЗельеСовы") != 0 && main() == this)
        {


            GameManager.saveandhill();



            playerdata.Addeffect("Совиное Зрение", 600);
            VarSave.LoadFloat("mana", 1f);
            lowitem("ЗельеСовы", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //ЗельеТупости
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("ЗельеТупости") != 0 && main() == this)
        {


            GameManager.saveandhill();



            playerdata.Addeffect("Тупость", 600);
            VarSave.LoadFloat("BGPU", -0.1f);
            VarSave.LoadFloat("mana", 1f);
            lowitem("ЗельеТупости", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("ЗельеВсеЗрения") != 0 && main() == this)
        {


            GameManager.saveandhill();



            playerdata.Addeffect("Все Зрение", 600);
            VarSave.LoadFloat("mana", 1f);
            lowitem("ЗельеВсеЗрения", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Зелье_-1FPS") != 0 && main() == this)
        {


            GameManager.saveandhill();


            VarSave.LoadFloat("mana", 1f);

            playerdata.Addeffect("-1FPS", 30);
            playerdata.Saveeffect();
            lowitem("Зелье_-1FPS", "Колба");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //БилетБезплано
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("БилетБезплано") != 0 && main() == this)
        {


            GameManager.saveandhill();


            VarSave.LoadFloat("mana", 1f);
            playerdata.Addeffect("free", 300);
            cistalenemy.dies += 0;
            lowitem("БилетБезплано", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
      
        //  █_█__██
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("IcyCube") != 0 && main() == this)
        {


            GameManager.saveandhill();
            VarSave.LoadMoney("Shits", 1);

            VarSave.LoadMoney("Relics", 1);


            VarSave.LoadFloat("mana", 1f);
            cistalenemy.dies += 1;
            lowitem("IcyCube", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //Таблетки_для_GodMode
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Таблетки_для_GodMode") != 0 && main() == this)
        {


            GameManager.saveandhill();

            VarSave.LoadMoney("Shits", 1);

            VarSave.LoadFloat("mana", 1f);
            playerdata.Addeffect("█_GodMode_█", float.PositiveInfinity);
            lowitem("Таблетки_для_GodMode", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("█_█__██") != 0 && main() == this)
        {


            GameManager.saveandhill();


            VarSave.LoadFloat("mana", 1f);
            playerdata.Addeffect("█_█__██", 30);

            lowitem("█_█__██", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && main() == this
              && Cells[selectr].elementName == "ItemSandFromMinecraft" && Cells[selectr].elementCount > 0)
        {
            Cells[selectr].elementName = "FallingSandFromMinecraft";
            Cells[selectr].UpdateCellInterface();

            //  lowitem("DNAColour", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (Getstats.GetPlayerLevel() >= 1)
        {
            if (GlobalInputMenager.KeyCode_eat == 1 && main() == this
                && Cells[selectr].elementName == "DNAColour" && Cells[selectr].elementCount > 0)
            {
                mover.main().DNA.colour = JsonUtility.FromJson<PlayerDNA>(Cells[selectr].elementData).colour;

                VarSave.SetString("DNA", JsonUtility.ToJson(mover.main().DNA));

                VarSave.LoadFloat("mana", 1f);

                //  lowitem("DNAColour", "");
                GlobalInputMenager.KeyCode_eat = 0;
            }
            if (GlobalInputMenager.KeyCode_eat == 1 && main() == this
                && Cells[selectr].elementName == "DNAColour" && Cells[selectr].elementCount > 0)
            {
                mover.main().DNA.colour = JsonUtility.FromJson<PlayerDNA>(Cells[selectr].elementData).colour;

                VarSave.SetString("DNA", JsonUtility.ToJson(mover.main().DNA));

                VarSave.LoadFloat("mana", 1f);

                //  lowitem("DNAColour", "");
                GlobalInputMenager.KeyCode_eat = 0;
            }
            if (GlobalInputMenager.KeyCode_eat == 1 && main() == this
                && Cells[selectr].elementName == "DNAFourLapra" && Cells[selectr].elementCount > 0)
            {
                PoverkaDNA(); if (mover.main().DNA.talant != null) if (mover.main().DNA.talant.Count > 0) if (Global.Random.Chance(2)) { mover.main().DNA.talant[0] = (int)TalantDNA.fourLapka; } else { mover.main().DNA.talant[1] = (int)TalantDNA.fourLapka; }

                VarSave.SetString("DNA", JsonUtility.ToJson(mover.main().DNA));


                VarSave.LoadFloat("mana", 1f);
                //  lowitem("DNAColour", "");
                GlobalInputMenager.KeyCode_eat = 0;
            }
            if (GlobalInputMenager.KeyCode_eat == 1 && main() == this
                && Cells[selectr].elementName == "DNAKillZone" && Cells[selectr].elementCount > 0)
            {
                PoverkaDNA(); if (mover.main().DNA.talant != null) if (mover.main().DNA.talant.Count > 0) if (Global.Random.Chance(2)) { mover.main().DNA.talant[0] = (int)TalantDNA.KillZone; } else { mover.main().DNA.talant[1] = (int)TalantDNA.KillZone; }

                VarSave.SetString("DNA", JsonUtility.ToJson(mover.main().DNA));


                VarSave.LoadFloat("mana", 1f);
                //  lowitem("DNAColour", "");
                GlobalInputMenager.KeyCode_eat = 0;
            }
            if (GlobalInputMenager.KeyCode_eat == 1 && main() == this
                && Cells[selectr].elementName == "DNAKillGod" && Cells[selectr].elementCount > 0)
            {
                PoverkaDNA(); if (mover.main().DNA.talant != null) if (mover.main().DNA.talant.Count > 0) if (Global.Random.Chance(2)) { mover.main().DNA.talant[0] = (int)TalantDNA.KillGod; } else { mover.main().DNA.talant[1] = (int)TalantDNA.KillGod; }
                mover.main().DNA.colour = new Color(3,4,1f);
                VarSave.SetString("DNA", JsonUtility.ToJson(mover.main().DNA));


                VarSave.LoadFloat("mana", 1f);
                //  lowitem("DNAColour", "");
                GlobalInputMenager.KeyCode_eat = 0;
            }
            if (GlobalInputMenager.KeyCode_eat == 1 && main() == this
                && Cells[selectr].elementName == "DNABorn" && Cells[selectr].elementCount > 0)
            {
                PoverkaDNA(); if (mover.main().DNA.talant != null) if (mover.main().DNA.talant.Count > 0) if (Global.Random.Chance(2)) { mover.main().DNA.talant[0] = (int)TalantDNA.born; } else { mover.main().DNA.talant[0] = (int)TalantDNA.born; }

                VarSave.SetString("DNA", JsonUtility.ToJson(mover.main().DNA));


                VarSave.LoadFloat("mana", 1f);
                //  lowitem("DNAColour", "");
                GlobalInputMenager.KeyCode_eat = 0;
            }
            if (GlobalInputMenager.KeyCode_eat == 1 && main() == this
                && Cells[selectr].elementName == "DNAmuscles" && Cells[selectr].elementCount > 0)
            {
                mover.main().DNA.Jumping = JsonUtility.FromJson<PlayerDNA>(Cells[selectr].elementData).Jumping;
                mover.main().DNA.hp = JsonUtility.FromJson<PlayerDNA>(Cells[selectr].elementData).hp;
                mover.main().DNA.regeneration = JsonUtility.FromJson<PlayerDNA>(Cells[selectr].elementData).regeneration;

                VarSave.SetString("DNA", JsonUtility.ToJson(mover.main().DNA));

                VarSave.LoadFloat("mana", 1f);

                //  lowitem("DNAColour", "");
                GlobalInputMenager.KeyCode_eat = 0;
            }
            if (GlobalInputMenager.KeyCode_eat == 1 && main() == this
                && Cells[selectr].elementName == "DNAFixer" && Cells[selectr].elementCount > 0)
            {

                mover.main().DNA.bakeeffects = JsonUtility.FromJson<PlayerDNA>(Cells[selectr].elementData).bakeeffects;

                VarSave.SetString("DNA", JsonUtility.ToJson(mover.main().DNA));

                VarSave.LoadFloat("mana", 1f);

                //  lowitem("DNAColour", "");
                GlobalInputMenager.KeyCode_eat = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[selectr].elementName == "Мусор" && main() == this && Cells[selectr].elementCount > 0)
        {

            VarSave.LoadMoney("Shits", 1);

            string[] itemObject = Cells[selectr].elementData.Split('♥');
            string itemname = "";
            if (itemObject[0] == "item")
            {
                foreach (GameObject item in Map_saver.t3)
                {
                    if (item.GetComponent<itemName>()._Name == itemObject[1])
                    {
                        itemname = item.name;
                    }
                }
                Cells[selectr].elementName = itemname;
            }
            if (itemObject[0] == "co")
            {
                
                Cells[selectr].elementName = "co!" + itemObject[1];
            }
            Cells[selectr].UpdateCellInterface();
        }
        //УпаковщикМусора
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
          && Cells[selectr].elementName == "УпаковщикМусора" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<CustomSaveObject>())
                {
                    GameObject g = Instantiate(Resources.Load<GameObject>("items/Мусор"), hit.point, Quaternion.identity);
                    GameObject select = g; if (select.GetComponent<itemName>())
                    {
                        if (select.GetComponent<itemName>().ItemDangerLiberty != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty2 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty2, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty3 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty3, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty4 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty4, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty5 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty5, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty6 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty6, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty7 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty7, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty8 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty8, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty9 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty9, 1);

                        }
                    }
                    if (select.GetComponent<CustomObject>())
                    {
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty2 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty2, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty3 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty3, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty4 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty4, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty5 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty5, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty6 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty6, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty7 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty7, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty8 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty8, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty9 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty9, 1);

                        }
                    }
                    if (hit.collider.GetComponent<itemName>()) g.GetComponent<itemName>().ItemData = "item♥" + hit.collider.GetComponent<itemName>()._Name;
                    if (hit.collider.GetComponent<CustomObject>()) g.GetComponent<itemName>().ItemData = "co♥" + hit.collider.GetComponent<CustomObject>().s;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        if (Input.GetKey(KeyCode.Mouse0) && main() == this
          && Cells[selectr].elementName == "Marker" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;


            GameObject g = Instantiate(Resources.Load<GameObject>("items/ColorMarker"), hit.point, Quaternion.identity);

        }
        if (Input.GetKey(KeyCode.Mouse0) && main() == this
          && Cells[selectr].elementName == "UranMarker" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;


            GameObject g = Instantiate(Resources.Load<GameObject>("items/u"), hit.point, Quaternion.identity);

        }
        //ПроигратьМузыку
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
         && Cells[selectr].elementName == "AudioPlayer" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                GameObject g = Instantiate(Resources.Load<GameObject>("ui/console/ПроигратьМузыку"), Vector3.zero, Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && main() == this
         && Cells[selectr].elementName == "Чертёж" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<itemName>())
                {
                    if (hit.collider.GetComponent<itemName>()._Name != "Fundament")
                    {
                        GameObject g = Instantiate(Resources.Load<GameObject>("items/Fundament"), hit.point + (Vector3.up * 10), Quaternion.identity);
                    }
                    else
                    {
                        GameObject g = Instantiate(Resources.Load<GameObject>("items/Stena"), hit.collider.transform.position + (Vector3.up * 2.5f), Quaternion.identity);
                    }
                }
                else
                {

                    GameObject g = Instantiate(Resources.Load<GameObject>("items/Fundament"), hit.point + (Vector3.up * 10), Quaternion.identity);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
         && Cells[selectr].elementName == "Чертёж" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<itemName>())
                {
                    if (hit.collider.GetComponent<itemName>()._Name != "WoodFundament")
                    {
                        GameObject g = Instantiate(Resources.Load<GameObject>("items/WoodFundament"), hit.point + (Vector3.up * 10), Quaternion.identity);
                    }
                    else
                    {
                        GameObject g = Instantiate(Resources.Load<GameObject>("items/WoodStena"), hit.collider.transform.position + (Vector3.up * 2.5f), Quaternion.identity);
                    }
                }
                else
                {

                    GameObject g = Instantiate(Resources.Load<GameObject>("items/WoodFundament"), hit.point + (Vector3.up * 10), Quaternion.identity);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
         && Cells[selectr].elementName == "Hummer" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
               if(hit.collider.GetComponent<itemName>()._Name == "ChaosResource")
                {
                    GameObject g = Instantiate(Resources.Load<GameObject>("Items/OrangeTablet"), hit.point, Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        //ƥ███_█
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
         && Cells[selectr].elementName == "ƥ███_█" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                GameObject g = Instantiate(Resources.Load<GameObject>("items/infCilindr"), hit.point, Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
         && Cells[selectr].elementName == "LifeCleaner" && Cells[selectr].elementCount > 0)
        {
            CharacterName[] CharacterNames = FindObjectsByType<CharacterName>(sortmode.main);
            foreach (CharacterName item in CharacterNames)
            {
                item.gameObject.AddComponent<DELETE>();
            }
            SocialObject[] CharacterNames2 = FindObjectsByType<SocialObject>(sortmode.main);
            foreach (SocialObject item in CharacterNames2)
            {
                item.gameObject.AddComponent<DELETE>();
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
         && Cells[selectr].elementName == "██__█_Poution" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                GameObject g = Instantiate(Resources.Load<GameObject>("ui/compas/compas"), Vector3.zero, Quaternion.identity);
                if (Global.Random.Range(0,100)<=14)
                {
                    hello.windowmesenge.Dialog_Radar();
                    Globalprefs.RadarOn = true;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && main() == this
         && Cells[selectr].elementName == "Reload_battery" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Cells[selectr].elementData = "1000";
                Instantiate(Resources.Load<GameObject>("audios/battery_reload"), Vector3.zero, Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
         && Cells[selectr].elementName == "SampleCrown" && Cells[selectr].elementCount > 0 && VarSave.GetString("ProfStatus") == "King")
        {

            VarSave.SetMoney("tevro", 2500000000);
            cistalenemy.dies = -10000;
            VarSave.SetMoney("CashFlow", 5500);
            Globalprefs.flowteuvro = 5500;

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
         && Cells[selectr].elementName == "Kley" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;



            if (hit.collider != null)
            {



                Instantiate(inv2("KleySharp").gameObject, hit.point + Vector3.up * inv2("KleySharp").gameObject.transform.localScale.y / 2, Quaternion.identity);



            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
         && Cells[selectr].elementName == "4D-Glasses" && Cells[selectr].elementCount > 0)
        {
            MultyObject[] mo = FindObjectsByType<MultyObject>(sortmode.main);
            show4D[] sh = FindObjectsByType<show4D>(sortmode.main);
            Tag_4D_metka[] targs = FindObjectsByType<Tag_4D_metka>(sortmode.main);
            GameObject Target = Resources.Load<GameObject>("4D-Metka");
            if (targs.Length > 0) for (int i = 0; i < targs.Length; i++)
                {


                    targs[i].gameObject.AddComponent<deleter1>();
                }

            for (int i = 0; i < mo.Length; i++)
            {

                GameObject g = Instantiate(Target, mo[i].transform.position, Quaternion.identity);
                g.GetComponent<NoscaleParent>().Obj = mo[i].transform;

            }
            for (int i = 0; i < sh.Length; i++)
            {

                GameObject g = Instantiate(Target, sh[i].transform.position, Quaternion.identity);
                g.GetComponent<NoscaleParent>().Obj = sh[i].transform;

            }

        }
        //GravityAx
        //   WarpEngine
        if (main() == this
       && Cells[selectr].elementName == "GravityAx"
       && Cells[selectr].elementCount > 0 && Input.GetKeyDown(KeyCode.E))
        {
            mover.main().transform.Rotate(0, 0, 180);
        }
        if (main() == this
       && Cells[selectr].elementName == "T█████okeg"
       && Cells[selectr].elementCount > 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(Resources.Load("Items/Kout█████"), mover.main().transform.position, Quaternion.identity);
        }
        if (main() == this
       && Cells[selectr].elementName == "WarpEngine"
       && Cells[selectr].elementCount > 0 && Input.GetKeyDown(KeyCode.E))
        {
            mover.main().transform.position += mover.main().PlayerCamera.transform.forward * 1000;
        }
        if (main() == this
       && Cells[selectr].elementName == "WarpEngine"
       && Cells[selectr].elementCount > 0 && Input.GetKeyUp(KeyCode.E))
        {
            yu = 0;
        }
        if (main() == this
       && Cells[selectr].elementName == "WarpEngine"
       && Cells[selectr].elementCount > 0 && Input.GetKey(KeyCode.E))
        {
            yu++;
            if (yu > 60)
            {

                mover.main().transform.position += mover.main().PlayerCamera.transform.forward * 1000;
            }
        }
        if (main() == this
       && Cells[selectr].elementName == "WarpEngine"
       && Cells[selectr].elementCount > 0 && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.LeftShift))
        {
            yu++;
            if (yu > 60)
            {

                mover.main().transform.position += mover.main().PlayerCamera.transform.forward * 100000;
            }
        }
        if (main() == this
       && Cells[selectr].elementName == "WarpEngine"
       && Cells[selectr].elementCount > 0 && Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.LeftShift))
        {
            yu2++;
            if (yu2 > 2)
            {

                mover.main().transform.position += mover.main().PlayerCamera.transform.forward * 100000;

                yu2 = 0;
            }
        }
        if (main() == this
         && Cells[selectr].elementName == "Gift_item_from_other_Universe"
         && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;
            if (hit.collider != null)
            {
                if (!Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.R)) editObject = hit.collider.gameObject;
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Globalprefs.LockRotate = true;
                }
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    editObject.transform.Rotate(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), Input.GetAxis("Mouse ScrollWheel") * 20);
                }
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    Globalprefs.LockRotate = false;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Globalprefs.LockRotate = true;
                }
                if (Input.GetKey(KeyCode.E))
                {
                    editObject.transform.localScale += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), Input.GetAxis("Mouse ScrollWheel") * 20);
                }
                if (Input.GetKeyUp(KeyCode.E))
                {
                    Globalprefs.LockRotate = false;
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    Globalprefs.LockRotate = true;
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    editObject.transform.position += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), Input.GetAxis("Mouse ScrollWheel") * 20);
                }
                if (Input.GetKeyUp(KeyCode.Q))
                {
                    Globalprefs.LockRotate = false;
                }
                if (Input.GetKey(KeyCode.R))
                {
                    Destroy(editObject);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
     && priaritet("CatCorm") != 0 && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                if (hit.collider.GetComponent<itemName>())
                {
                    if (hit.collider.GetComponent<itemName>()._Name == "Cat")
                    {

                        lowitem("CatCorm", "");
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && priaritet("CatReplicatorCorm") != 0 && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                if (hit.collider.GetComponent<itemName>())
                {
                    if (hit.collider.GetComponent<itemName>()._Name == "Cat")
                    {
                        GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + new Vector3(Global.Random.Range(-4, 4), Global.Random.Range(-4, 4), Global.Random.Range(-4, 4)), Quaternion.identity);
                        obj.name = obj.name.Remove(obj.name.Length - 7);
                        lowitem("CatReplicatorCorm", "");
                    }
                }
            }
        }
        //Метанфитамин
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && priaritet("SkalapendraReplicatorCorm") != 0 && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                if (hit.collider.GetComponent<itemName>())
                {
                    if (hit.collider.GetComponent<itemName>()._Name == "Скалапендра")
                    {
                        GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + new Vector3(Global.Random.Range(-4, 4), Global.Random.Range(-4, 4), Global.Random.Range(-4, 4)), Quaternion.identity);
                        obj.name = obj.name.Remove(obj.name.Length - 7);
                        lowitem("SkalapendraReplicatorCorm", "");
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && main() == this
            && priaritet("UPortalGun") != 0 && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                GameObject g = Instantiate(inv2("UPortal"), hit.point, Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && main() == this
            && priaritet("UPortalGun") != 0 && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                GameObject g = Instantiate(inv2("UcnaGranate"), mover.main().transform.position+(mover.main().PlayerCamera.transform.forward*4f), Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && priaritet("Null") != 0 && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                if (hit.collider.GetComponent<itemName>())
                {
                    if (hit.collider.GetComponent<itemName>()._Name == "Скалапендра")
                    {

                        Instantiate(inv2("Скалапендрадра").gameObject, hit.point + Vector3.up * inv2("Скалапендрадра").gameObject.transform.localScale.y / 2, Quaternion.identity);
                        Destroy(hit.collider.gameObject);

                        lowitem("Null", "");
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && priaritet("Null") != 0 && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                if (hit.collider.GetComponent<itemName>())
                {
                    if (hit.collider.GetComponent<itemName>()._Name == "battery")
                    {

                        Instantiate(inv2("Reload_battery").gameObject, hit.point + Vector3.up * inv2("Reload_battery").gameObject.transform.localScale.y / 2, Quaternion.identity);
                        Destroy(hit.collider.gameObject);

                        lowitem("Null", "");
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && priaritet("Метанфитамин") != 0 && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                if (hit.collider.GetComponent<itemName>())
                {
                    if (hit.collider.GetComponent<itemName>()._Name == "Скалапендра")
                    {

                        GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + new Vector3(Global.Random.Range(-4, 4), Global.Random.Range(-4, 4), Global.Random.Range(-4, 4)), Quaternion.identity);
                        obj.name = obj.name.Remove(obj.name.Length - 7);
                        lowitem("Метанфитамин", "");
                    }
                }
            }
        }
        //КормДляHextBot'ов
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && priaritet("Летунский корм") != 0 && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                if (hit.collider.GetComponent<itemName>())
                {
                    if (hit.collider.GetComponent<itemName>()._Name == "Летун")
                    {
                        GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + new Vector3(Global.Random.Range(-4, 4), Global.Random.Range(-4, 4), Global.Random.Range(-4, 4)), Quaternion.identity);
                        obj.name = obj.name.Remove(obj.name.Length - 7);
                        lowitem("Летунский корм", "");
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && priaritet("КормДляNextBot\'ов") != 0 && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                if (hit.collider.GetComponent<itemName>())
                {
                    if (hit.collider.GetComponent<itemName>()._Name == "AnnoyingNextBot")
                    {
                        GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + new Vector3(Global.Random.Range(-4, 4), Global.Random.Range(-4, 4), Global.Random.Range(-4, 4)), Quaternion.identity);
                        obj.name = obj.name.Remove(obj.name.Length - 7);
                        lowitem("КормДляNextBot\'ов", "");
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && batteytype && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<GeneratorEnergy>())
                {
                    Cells[selectr].elementData = (float.Parse(Cells[selectr].elementData) + hit.collider.GetComponent<GeneratorEnergy>().energyData.energy).ToString();
                    //  Cells[selectr].elementData = 
                    hit.collider.GetComponent<GeneratorEnergy>().energyData.energy = 0;
                    hit.collider.GetComponent<GeneratorEnergy>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<GeneratorEnergy>().energyData);

                }
            }

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<LightStick>())
                {
                    hit.collider.GetComponent<LightStick>().energyData.energy += float.Parse(Cells[selectr].elementData);
                    hit.collider.GetComponent<LightStick>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<LightStick>().energyData);
                    Cells[selectr].elementData = "0";
                    //  Cells[selectr].elementData = 
                }
            }
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<DarkStick>())
                {
                    hit.collider.GetComponent<DarkStick>().energyData.energy += float.Parse(Cells[selectr].elementData);
                    hit.collider.GetComponent<DarkStick>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<DarkStick>().energyData);
                    Cells[selectr].elementData = "0";
                    //  Cells[selectr].elementData = 
                }
            }
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<RayGun>())
                {
                    hit.collider.GetComponent<RayGun>().energyData.energy += float.Parse(Cells[selectr].elementData);
                    hit.collider.GetComponent<RayGun>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<RayGun>().energyData);
                    Cells[selectr].elementData = "0";
                    //  Cells[selectr].elementData = 
                }
            }

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ColdGenerator>())
                {
                    hit.collider.GetComponent<ColdGenerator>().energyData.energy += float.Parse(Cells[selectr].elementData);
                    hit.collider.GetComponent<ColdGenerator>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<ColdGenerator>().energyData);
                    Cells[selectr].elementData = "0";
                    //  Cells[selectr].elementData = 
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && Cells[selectr].elementName == "Grib" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[selectr].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[selectr].elementName = "BlackGrib";
                        Cells[selectr].UpdateCellInterface();
                    }
                }
            }

        }
        bool itsdna = false;
        if (Cells[selectr].elementName.Length > 4) if (Cells[selectr].elementName.Remove(3, Cells[selectr].elementName.Length - 3) == "DNA") itsdna = true;

        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
             && itsdna && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 10)
                    {
                        //  Cells[selectr].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 10f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[selectr].elementData = "";
                        Cells[selectr].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && Cells[selectr].elementName == "Лицензия_на_запрещёный_предмет" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[selectr].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[selectr].elementName = "Null";
                        Cells[selectr].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && Cells[selectr].elementName == "U" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[selectr].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[selectr].elementName = "-U";
                        Cells[selectr].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && Cells[selectr].elementName == "Ṳx" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[selectr].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[selectr].elementName = "-Ṳx";
                        Cells[selectr].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && Cells[selectr].elementName == "C" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[selectr].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[selectr].elementName = "-C";
                        Cells[selectr].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && Cells[selectr].elementName == "Cr" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[selectr].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[selectr].elementName = "-Cr";
                        Cells[selectr].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && Cells[selectr].elementName == "Fr" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[selectr].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[selectr].elementName = "-Fr";
                        Cells[selectr].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && Cells[selectr].elementName == "Au" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[selectr].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[selectr].elementName = "-Au";
                        Cells[selectr].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && Cells[selectr].elementName == "He" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[selectr].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[selectr].elementName = "-He";
                        Cells[selectr].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && Cells[selectr].elementName == "Ti" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[selectr].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[selectr].elementName = "-Ti";
                        Cells[selectr].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && Cells[selectr].elementName == "Vine" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[selectr].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[selectr].elementName = "Дтine";
                        Cells[selectr].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && Cells[selectr].elementName == "Мясо" && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[selectr].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[selectr].elementName = "vine";
                        Cells[selectr].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && main() == this
            && batteytype && Cells[selectr].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[selectr].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[selectr].elementData = (float.Parse(Cells[selectr].elementData) * -1).ToString();
                        Cells[selectr].UpdateCellInterface();
                    }
                }
            }

        }
        if (GlobalInputMenager.KeyCode_eat == 1 && main() == this
             && Cells[selectr].elementName == "PortativeHyperbolicSpace_" && Cells[selectr].elementCount > 0)
        {
            if (SceneManager.GetActiveScene().name != "PortativeHyperbolicSpace")
            {
                VarSave.SetString("SceneNamePosition", SceneManager.GetActiveScene().name);
                VarSave.LoadFloat("mana", 1f);
                GameManager.save();
                SceneManager.LoadScene("PortativeHyperbolicSpace");
            }
            //  lowitem("DNAColour", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }

        //  lowitem("DNAColour", "");
        //PortativeHyperbolicSpace_

        //GenColour
        //Absolute_poison
        //sosisca
        VarSave.SetInt("Agr", cistalenemy.dies);
    }

    private static void PoverkaDNA()
    {
        if (mover.main().DNA.talant == null) mover.main().DNA.talant = new List<int>(2) { 0, 0 }; else if (mover.main().DNA.talant != null) if (mover.main().DNA.talant.Count == 0) mover.main().DNA.talant = new List<int>(2) { 0, 0 };
    }

    private void CustomFunctionalItem(CustomObjectData cod)
    {
        mover m = mover.main();
        if (cod.functional == Functional.user)
        {
            RaycastHit hit = MainRay.MainHit;
            if (!string.IsNullOrEmpty(cod.itemSpawn)) Instantiate(Resources.Load<GameObject>("items/" + cod.itemSpawn), hit.point, Quaternion.identity);
            if (!string.IsNullOrEmpty(cod.ObjSpawn)) Instantiate(Resources.Load<GameObject>(cod.ObjSpawn), hit.point, Quaternion.identity);
            foreach (useeffect item in cod.effect_no_use)
            {
                playerdata.Addeffect(item.effect, item.time);
            }
            if (!string.IsNullOrEmpty(cod.CoSpawn))
            {
                GameObject g = Instantiate(Resources.Load<GameObject>("CustomObject"), hit.point, Quaternion.identity);
                g.GetComponent<CustomObject>().s = cod.CoSpawn;

            }
            if (!string.IsNullOrEmpty(cod.EventSpawn)) Instantiate(Resources.Load<GameObject>("Event/" + cod.EventSpawn), hit.point, Quaternion.identity);
        }
        if (cod.functional == Functional.spawner)
        {
            RaycastHit hit = MainRay.MainHit;
            if (!string.IsNullOrEmpty(cod.itemSpawn)) Instantiate(Resources.Load<GameObject>("items/" + cod.itemSpawn), hit.point, Quaternion.identity);
            if (!string.IsNullOrEmpty(cod.ObjSpawn)) Instantiate(Resources.Load<GameObject>(cod.ObjSpawn), hit.point, Quaternion.identity);

            if (!string.IsNullOrEmpty(cod.CoSpawn))
            {
                GameObject g = Instantiate(Resources.Load<GameObject>("CustomObject"), hit.point, Quaternion.identity);
                g.GetComponent<CustomObject>().s = cod.CoSpawn;

            }
            if (!string.IsNullOrEmpty(cod.EventSpawn)) Instantiate(Resources.Load<GameObject>("Event/" + cod.EventSpawn), hit.point, Quaternion.identity);

        }
        if (cod.functional == Functional.spawner || cod.functional == Functional.user || cod.functional == Functional.steyk)
        {
            Map_saver cps = Map_saver.ObjectSaveManager;
            if (cod.AnigilateItem) cps.ClearObjects();
            if ((long)m.hp + (long)cod.RegenerateHp < int.MaxValue) m.hp += cod.RegenerateHp;
            m.W_position += cod.playerWHMove.x;
            m.H_position += cod.playerWHMove.y;
            if(!string.IsNullOrEmpty(cod.AppOpen)) hello.windowmesenge.LoadApplication(cod.AppOpen);
            VarSave.LoadMoney("Inflation", ((decimal)cod.Recycler / 2000) + ((decimal)cod.InfinityRecycler) + ((decimal)cod.Redecycler * 10), SaveType.global);
            Globalprefs.LoadTevroPrise(+ (int)cod.Recycler);
            VarSave.SetTrash("inftevro", VarSave.GetTrash("inftevro") + cod.InfinityRecycler);
            VarSave.SetMoney("CashFlow", VarSave.GetMoney("CashFlow") + (decimal)cod.Redecycler);
            Globalprefs.flowteuvro += (decimal)cod.Redecycler;
            if (cod.Dublicate)
            {
                Instantiate(mover.main().gameObject);
            }
            m.PlayerBody.transform.Rotate(cod.playerRotate.x, cod.playerRotate.y, cod.playerRotate.z);
            m.PlayerBody.transform.Translate(new Vector3(cod.playerMove.x, cod.playerMove.y, cod.playerMove.z));
        }
        if (cod.functional == Functional.steyk)
        {
            if (!string.IsNullOrEmpty(cod.AppOpen)) hello.windowmesenge.LoadApplication(cod.AppOpen);
            foreach (useeffect item in cod.effect_no_use)
            {
                playerdata.Addeffect(item.effect, item.time);
            }
            if (cod.ClearEffect)
            {
                playerdata.Cleareffect();
            }
            if (cod.FreezeEffect)
            {
                playerdata.FreezeAlleffect();
            }
            if (cod.Dublicate)
            {
                Instantiate(mover.main().gameObject);
            }
        }
        if (cod.functional == Functional.steyk)
        {
            setItem("", 0, Color.red, select);
            Cells[select].UpdateCellInterface();
        }
    }
    public string itemselect;
    public string itemselectold;
    public typeItem GetTypeItem()
    {
        typeItem item = typeItem.none;
        if(Cells[select].elementName.Contains("co!"))
        {
            CustomObjectData cod = JsonUtility.FromJson<CustomObjectData>(File.ReadAllText("res/UserWorckspace/Items/" + Cells[select].elementName.Replace("co!", "") + ".txt"));
            if (cod.functional == Functional.mgickStick)
            {
                item = typeItem.gun;
            }
            if (cod.functional == Functional.user)
            {
                item = typeItem.gun;
            }
            if (cod.functional == Functional.spawner)
            {
                item = typeItem.gun;
            }
            if (cod.RunToPlayer) 
            {
                item = typeItem.mobe;
            }
            if (cod.social)
            {
                item = typeItem.mobe;
            }
            if (cod.Timer2!=0)
            {
                item = typeItem.mobe;
            }
        }
        else
        {
            if (isnotitem(Cells[select].elementName))
            {
                if (Resources.Load<itemName>("items/" + Cells[select].elementName).itemtype == 1)
                {

                    item = typeItem.gun;
                }
                if (Resources.Load<itemName>("items/" + Cells[select].elementName).itemtype == 2)
                {

                    item = typeItem.mobe;
                }
            }
            else
            {
                item = typeItem.none;
            }
        }
        return item;
    }
    bool isnotitem(string itemfind)
    {
        foreach (GameObject item in Map_saver.t3)
        {
            if (item.name.Replace("(Clone)","") == itemfind)
            {
                return true;
            }
        }
        return false;
    }
    private void Update()
    {
        if (main() == this)
        {
            if (!Globalprefs.Pause && main() == this) if (Cells[select].elementName.Length > 2 && Cells[select].elementName.Remove(3, Cells[select].elementName.Length - 3) == "co!") if (main() == this)
                    {

                     
                                    CustomObjectData cod = JsonUtility.FromJson<CustomObjectData>(File.ReadAllText("res/UserWorckspace/Items/" + Cells[select].elementName.Replace("co!", "") + ".txt"));
                                    if (cod.standartKey == StandartKey.notrequired)
                                    {



                                        CustomFunctionalItem(cod);
                                    }
                       



                    }
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    SelectLayItem();
                }
                if (i == 1)
                {
                    DeselectLayItem();
                }
            }

            if (main() == this)
            {
                Globalprefs.item = instance.Cells[select].elementName;
               if(Input.GetKeyDown(KeyCode.V)&&!Globalprefs.Pause)
                {
                    bool arelyselected = false;
                    int i=0;
                    foreach (MassSelect item in selects)
                    {
                        if (item.selects == select)
                        {
                            arelyselected = true;
                            
                            break;
                        }
                        i++;
                    }
                    if (!arelyselected) 
                    {
                        MassSelect selecto = new MassSelect();
                        selecto.selects = select;
                        GameObject obj = Instantiate(selectingobjects, activeItem.transform);
                        obj.transform.localPosition = Vector3.zero;
                        obj.SetActive(true);
                        selecto.selectobjects = obj;
                        selects.Add(selecto);
                    }
                    else
                    {
                        GameObject obj = selects[i].selectobjects;
                        Destroy(obj);
                        selects.RemoveAt(i);

                    }
                }
            }
            int vaule = 0;
            if (File.Exists("C:/myMods/give.sig"))
            {
                vaule = int.Parse(File.ReadAllText("C:/myMods/give.sig"));

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    setItem(toname(itemtags[vaule]), 1, Color.red, select);
                    File.Delete("C:/myMods/give.sig");
                }


            }
            if (instance.nosell == true && instance != this)
            {
                nosell = false;

            }
            if (instance.Getitem("position_planet_seloria") && planets)
            {
                Cells[4].elementCount = 3;
                Cells[4].elementName = "seloria";
            }
            if (instance.nosell == false && instance != this)
            {
                nosell = true;
            }
            if (deletecell)
            {
                if (Cells[Cells.Length - 1].elementName != "")
                {
                    if (tag3(inv2(Cells[Cells.Length - 1].elementName)))
                    {
                        setItem("", 0, Color.red, Cells.Length - 1);
                        Cells[Cells.Length - 1].UpdateCellInterface();
                    }
                }
            }
            if (!Input.GetKey(KeyCode.Mouse0) && instance != this)
            {


                select = LayItem();
            }
            if (Input.GetKey(KeyCode.Mouse0) && nosell && main() == this)
            {


                select = LayItem();
            }
            if (!nosell && main() == this)
            {



                select = LayItem();
            }
            for (int i = 0; i < Cells.Length && selectobject; i++)
            {
                if (i == select)
                {
                    selectobject.transform.position = Cells[i].transform.position;

                }
            }
            List<int> items = new List<int>();
            for(int i = 0; i < selects.Count; i++)
            {
                items.Add(selects[i].selects);
            }
            items.Add(select);
            if (!Globalprefs.Pause && main() == this)
                foreach (int item in items)
                {
                    itemUse(item); 
                }


            ItemDetector.coutnitem = Cells[select].elementCount;
            itemselect = Cells[select].elementName;
            if (itemselect != itemselectold)
            {
                ItemDetector.type = GetTypeItem();
                itemselect = itemselectold;
            }
            if (Input.GetKeyDown(KeyCode.Tab) && main() == this && !nosell)
            {



                Globalprefs.selectitem = "";
                RaycastHit hit = MainRay.MainHit;

                if (hit.collider.gameObject.layer != 3)
                {
                    if (hit.collider && Cells[select].elementCount == 0 && tag1(hit.collider.tag) && tag2(hit.collider.gameObject) && hit.collider.GetComponent<itemName>())
                    {

                        if (!VarSave.ExistenceVar("researchs/" + fullname(hit)))
                        {
                            Directory.CreateDirectory("unsave/var/researchs");


                            VarSave.LoadMoney("research", 1);

                            Globalprefs.research = VarSave.GetMoney("research");
                            VarSave.SetInt("researchs/" + fullname(hit), 0);

                        }
                        if (VarSave.GetString("Relic") == fullname(hit))
                        {
                            VarSave.LoadFloat("reason", 3);
                        }

                        setItem(fullname(hit), 1, Color.red, hit.collider.GetComponent<itemName>().ItemData, (hit.collider.GetComponent<Slave>() == true ? "Slave" : "") + "♥"
                            + (hit.collider.GetComponent<CharacterStats>() == true ? JsonUtility.ToJson(hit.collider.GetComponent<CharacterStats>().data) : "") + "♥"
                            + (hit.collider.GetComponent<Slave>() == true ? hit.collider.GetComponent<Slave>().slaveData : "") + "♥"
                            + (hit.collider.GetComponent<Slave>() == true ? "" + hit.collider.GetComponent<Slave>().WorkQualityTEVRO : "") + "♥"
                            + (hit.collider.GetComponent<Slave>() == true ? "" + hit.collider.GetComponent<Slave>().solarytimeold : ""), select);
                        Cells[select].UpdateCellInterface();
                        sh = true;

                    }
                    else if (hit.collider && Cells[select].elementCount == 0 && hit.collider.GetComponent<StandartObject>())
                    {


                        if (!VarSave.ExistenceVar("researchs/" + fullname(hit)))
                        {
                            Directory.CreateDirectory("unsave/var/researchs");


                            VarSave.LoadMoney("research", 1);

                            Globalprefs.research = VarSave.GetMoney("research");
                            VarSave.SetInt("researchs/" + fullname(hit), 0);

                        }
                        if (VarSave.GetString("Relic") == fullname(hit))
                        {
                            VarSave.LoadFloat("reason", 3);
                        }
                        setItem(fullname(hit), 1, Color.red, select);
                        Cells[select].UpdateCellInterface();
                        sh = true;

                    }
                    else if (hit.collider && Cells[select].elementCount == 0 && hit.collider.GetComponent<CustomObject>())
                    {

                        CustomObject co = hit.collider.GetComponent<CustomObject>();

                        if (VarSave.GetString("Relic") == fullname(hit))
                        {
                            VarSave.LoadFloat("reason", 3);
                        }
                        setItem("co!" + co.s, 1, Color.red, "6", (hit.collider.GetComponent<Slave>() == true ? "Slave" : "") + "♥"
                            + (hit.collider.GetComponent<CharacterStats>() == true ? JsonUtility.ToJson(hit.collider.GetComponent<CharacterStats>().data) : "") + "♥"
                            + (hit.collider.GetComponent<Slave>() == true ? hit.collider.GetComponent<Slave>().slaveData : "") + "♥"
                            + (hit.collider.GetComponent<Slave>() == true ? "" + hit.collider.GetComponent<Slave>().WorkQualityTEVRO : "") + "♥"
                            + (hit.collider.GetComponent<Slave>() == true ? "" + hit.collider.GetComponent<Slave>().solarytimeold : ""), select);
                        Destroy(co.gameObject);

                        Cells[select].UpdateCellInterface();
                        sh = true;

                    }

                }



            }
            if (Input.GetKeyDown(KeyCode.Tab) && main() == this && !nosell)
            {

                RaycastHit hit = MainRay.SecondHit; if (hit.collider)
                    if (Cells[select].elementCount == 1 && Cells[select].elementName == "ItemKey" && hit.collider.GetComponent<itemName>())
                    {



                        setItem(fullname(hit), 1, Color.red, hit.collider.GetComponent<itemName>().ItemData, (hit.collider.GetComponent<Slave>() == true ? "Slave" : "") + "♥"
                            + (hit.collider.GetComponent<CharacterStats>() == true ? JsonUtility.ToJson(hit.collider.GetComponent<CharacterStats>().data) : "") + "♥"
                            + (hit.collider.GetComponent<Slave>() == true ? hit.collider.GetComponent<Slave>().slaveData : "") + "♥"
                            + (hit.collider.GetComponent<Slave>() == true ? "" + hit.collider.GetComponent<Slave>().WorkQualityTEVRO : "") + "♥"
                            + (hit.collider.GetComponent<Slave>() == true ? "" + hit.collider.GetComponent<Slave>().solarytimeold : ""), select);
                        Cells[select].UpdateCellInterface();
                        sh = true;

                    }
            }
            if (Input.GetKeyDown(KeyCode.Tab) && main() == this && !nosell)
            {

                RaycastHit hit = MainRay.SecondHit; if (hit.collider)
                    if (Cells[select].elementCount == 1 && Cells[select].elementName == "ItemKey(Copy)" && hit.collider.GetComponent<itemName>())
                    {



                        setItem(fullnamesafe(hit), 1, Color.red, hit.collider.GetComponent<itemName>().ItemData, (hit.collider.GetComponent<Slave>() == true ? "Slave" : "") + "♥"
                            + (hit.collider.GetComponent<CharacterStats>() == true ? JsonUtility.ToJson(hit.collider.GetComponent<CharacterStats>().data) : "") + "♥"
                            + (hit.collider.GetComponent<Slave>() == true ? hit.collider.GetComponent<Slave>().slaveData : "") + "♥"
                            + (hit.collider.GetComponent<Slave>() == true ? "" + hit.collider.GetComponent<Slave>().WorkQualityTEVRO : "") + "♥"
                            + (hit.collider.GetComponent<Slave>() == true ? "" + hit.collider.GetComponent<Slave>().solarytimeold : ""), select);
                        Cells[select].UpdateCellInterface();
                        sh = true;

                    }
            }
            if (Input.GetKeyDown(KeyCode.Tab) && main() == this && !nosell)
            {

                RaycastHit hit2 = MainRay.SecondHit; if (hit2.collider)
                    if (Cells[select].elementCount == 1 && Cells[select].elementName == "ItemKey(Aktivator)" && hit2.collider.GetComponent<itemName>())
                    {



                        hit2.collider.GetComponent<InventoryEvent>().Invoke("OnSignal",0);
                        Cells[select].UpdateCellInterface();
                        sh = true;

                    }
            }
            if (Input.GetKeyDown(KeyCode.Delete) && main() == this && !nosell)
            {


                setItem("", 0, Color.red, select);
                Cells[select].UpdateCellInterface();



            }






            if (HyperbolicCamera.Main())
            {


                hyperbolicray();
            }
            else if (PlanetGravity.main())
            {


                Sphericalray();
            }
            else
            {


                euclideanray();
            }

            if (Input.GetKeyDown(KeyCode.Tab) && main() == this)
            {
                if (Input.GetKeyDown(KeyCode.Tab) && Getitem("box_") && main() == this)
                {




                    cistalenemy.dies++;
                }
                if (Input.GetKeyDown(KeyCode.Tab) && Getitem("Ṳx") && main() == this)
                {




                    cistalenemy.dies++;
                }
                if (Input.GetKeyDown(KeyCode.Tab) && Getitem("AntiMatter") && main() == this)
                {




                    cistalenemy.dies++;
                }
                if (Input.GetKeyDown(KeyCode.Tab) && Getitem("Fire") && main() == this)
                {




                    cistalenemy.dies++;
                }
                if (Input.GetKeyDown(KeyCode.Tab) && Getitem("ionic_cube") && main() == this)
                {




                    cistalenemy.dies++;
                }
                Globalprefs.selectitem = "";
                inputButton.button = 0;
            }
            sh = false;
        }

    } 

    public IEnumerator setSphericalitem(RaycastHit hit)
    {


        yield return new WaitForSeconds(0.5f);

        

        if (hit.distance < MainRay.RayMarhHit.distance && hit.collider && Cells[select].elementCount != 0)
        {

            Transform body = Instantiate(inv2(Cells[select].elementName).gameObject, hit.point + hit.normal * ScaleOffset() / 2, Quaternion.identity).transform;
            LoadSocial(body);
            if (GameObject.FindFirstObjectByType<PlanetGravity>() != null)
            {
                Vector3 gravityUp = (body.position - Vector3.zero).normalized;
                Vector3 bodyup = body.up;
                Quaternion targetrotation = Quaternion.FromToRotation(bodyup, gravityUp) * body.rotation;
                body.rotation = Quaternion.Slerp(body.rotation, targetrotation, 5000000 * Time.deltaTime);
            }
            if (body.GetComponent<itemName>()) body.GetComponent<itemName>().ItemData = Cells[select].elementData;
            setItem("", 0, Color.red, select);
            Cells[select].UpdateCellInterface();

        }
        else if (hit.distance >= MainRay.RayMarhHit.distance && Cells[select].elementCount != 0 && !Globalprefs.RaymarchHitError)
        {
            Transform body = Instantiate(inv2(Cells[select].elementName).gameObject, (MainRay.RayMarhHit.point), Quaternion.identity).transform;
            LoadSocial(body);
            if (GameObject.FindFirstObjectByType<PlanetGravity>() != null)
            {
                Vector3 gravityUp = (body.position - Vector3.zero).normalized;
                Vector3 bodyup = body.up;
                Quaternion targetrotation = Quaternion.FromToRotation(bodyup, gravityUp) * body.rotation;
                body.rotation = Quaternion.Slerp(body.rotation, targetrotation, 5000000 * Time.deltaTime);
            }
            if (body.GetComponent<itemName>()) body.GetComponent<itemName>().ItemData = Cells[select].elementData;
            setItem("", 0, Color.red, select);
            Cells[select].UpdateCellInterface();
        }
        else if (hit.collider == null && Cells[select].elementCount != 0 && !Globalprefs.RaymarchHitError)
        {
            Transform body = Instantiate(inv2(Cells[select].elementName).gameObject, (MainRay.RayMarhHit.point), Quaternion.identity).transform;
            LoadSocial(body);
            if (GameObject.FindFirstObjectByType<PlanetGravity>() != null)
            {
                Vector3 gravityUp = (body.position - Vector3.zero).normalized;
                Vector3 bodyup = body.up;
                Quaternion targetrotation = Quaternion.FromToRotation(bodyup, gravityUp) * body.rotation;
                body.rotation = Quaternion.Slerp(body.rotation, targetrotation, 5000000 * Time.deltaTime);
            }
            if (body.GetComponent<itemName>()) body.GetComponent<itemName>().ItemData = Cells[select].elementData;
            setItem("", 0, Color.red, select);
            Cells[select].UpdateCellInterface();
        }
        else if (Cells[select].elementCount != 0 && Globalprefs.RaymarchHitError)
        {
            Transform body = Instantiate(inv2(Cells[select].elementName).gameObject, hit.point + hit.normal * ScaleOffset() / 2, Quaternion.identity).transform;
            LoadSocial(body);
            if (GameObject.FindFirstObjectByType<PlanetGravity>() != null)
            {
                Vector3 gravityUp = (body.position - Vector3.zero).normalized;
                Vector3 bodyup = body.up;
                Quaternion targetrotation = Quaternion.FromToRotation(bodyup, gravityUp) * body.rotation;
                body.rotation = Quaternion.Slerp(body.rotation, targetrotation, 5000000 * Time.deltaTime);
            }
            if (body.GetComponent<itemName>()) body.GetComponent<itemName>().ItemData = Cells[select].elementData;
            setItem("", 0, Color.red, select);
            Cells[select].UpdateCellInterface();
        }




    }

    private void LoadSocial(Transform body)
    {
        body.localScale *= mover.main().transform.localScale.y;
        string[] SocialAspects = Cells[select].elementSocial.Split('♥');
        if (SocialAspects.Length>0) if (SocialAspects[0] == "Slave")
        {
            body.gameObject.AddComponent<Slave>();
                if (SocialAspects.Length > 2) if (SocialAspects[2] != "")
                    {

                        if (body.gameObject.GetComponent<Slave>()) body.gameObject.GetComponent<Slave>().slaveData = SocialAspects[2];
                    }
                if (SocialAspects.Length > 3) if (SocialAspects[3] != "")
                    {

                        if (body.gameObject.GetComponent<Slave>()) body.gameObject.GetComponent<Slave>().WorkQualityTEVRO = int.Parse(SocialAspects[3]);
                    }
                if (SocialAspects.Length > 4) if (SocialAspects[4] != "")
                    {

                        if (body.gameObject.GetComponent<Slave>()) body.gameObject.GetComponent<Slave>().solarytimeold = int.Parse(SocialAspects[4]);
                    }
            }
        if (SocialAspects.Length > 1) if (SocialAspects[1] != "")
            {
                body.gameObject.AddComponent<CharacterStats>().data = JsonUtility.FromJson<CharacterStatsData>(SocialAspects[1]);
            }
        if (VarSave.GetBool("full4D"))
        {
            body.gameObject.AddComponent<MultyObject>();
            body.gameObject.GetComponent<MultyObject>().shape = Shape.cube5D;
        }


    }

    public IEnumerator seteuclideanitem(RaycastHit hit)
    {


        yield return new WaitForSeconds(0.5f);

        if (hit.distance < MainRay.RayMarhHit.distance && hit.collider && Cells[select].elementCount != 0)
        {

            Transform t = Instantiate(inv2(Cells[select].elementName).gameObject, hit.point + Vector3.up * ScaleOffset() / 2, Quaternion.identity).transform; if (t.GetComponent<itemName>()) t.GetComponent<itemName>().ItemData = Cells[select].elementData;
            LoadSocial(t);
            setItem("", 0, Color.red, select);
            Cells[select].UpdateCellInterface();

        }
        else if (hit.distance >= MainRay.RayMarhHit.distance && Cells[select].elementCount != 0 && !Globalprefs.RaymarchHitError)
        {
            Transform t = Instantiate(inv2(Cells[select].elementName).gameObject, (MainRay.RayMarhHit.point) + Vector3.up * ScaleOffset() / 2, Quaternion.identity).transform; if (t.GetComponent<itemName>()) t.GetComponent<itemName>().ItemData = Cells[select].elementData;
            LoadSocial(t);
            setItem("", 0, Color.red, select);
            Cells[select].UpdateCellInterface();
        }
        else if (hit.collider == null && Cells[select].elementCount != 0 && !Globalprefs.RaymarchHitError)
        {
            Transform t = Instantiate(inv2(Cells[select].elementName).gameObject, (MainRay.RayMarhHit.point) + Vector3.up * ScaleOffset() / 2, Quaternion.identity).transform; if (t.GetComponent<itemName>()) t.GetComponent<itemName>().ItemData = Cells[select].elementData;
            LoadSocial(t);
            setItem("", 0, Color.red, select);
            Cells[select].UpdateCellInterface();
        }
        else if (Cells[select].elementCount != 0 && Globalprefs.RaymarchHitError)
        {
            Transform t = Instantiate(inv2(Cells[select].elementName).gameObject, hit.point + Vector3.up * ScaleOffset() / 2, Quaternion.identity).transform; if (t.GetComponent<itemName>()) t.GetComponent<itemName>().ItemData = Cells[select].elementData;
            LoadSocial(t);
            setItem("", 0, Color.red, select);
            Cells[select].UpdateCellInterface();
        }






    }

    private float ScaleOffset()
    {
        return (inv2(Cells[select].elementName).gameObject.transform.localScale.y * mover.main().transform.localScale.y);
    }

    float mouseDoubele;
    float mouseDoubele2;
    private void euclideanray()
    {

        if (Input.GetKeyDown(KeyCode.Tab) && !sh && main() == this && !nosell)
        {
            Globalprefs.selectitem = "";
            RaycastHit hit = MainRay.MainHit;


            StartCoroutine(seteuclideanitem(hit));




        }

    }
    private void Sphericalray()
    {

        if (Input.GetKeyDown(KeyCode.Tab) && !sh && main() == this && !nosell)
        {
            Globalprefs.selectitem = "";
            RaycastHit hit = MainRay.MainHit;


            StartCoroutine(setSphericalitem(hit));




        }

    }
    public IEnumerator sethyperbolicitem(RaycastHit hit)
    {


        yield return new WaitForSeconds(0.5f);

        if (hit.collider && Cells[select].elementCount != 0)
        {
            Vector3 v3;
            v3 = hit.point - GameManager.isplayer().position;
            v3 /= 20;
            HyperbolicCamera c = HyperbolicCamera.Main();


            Transform t = Instantiate(inv2(Cells[select].elementName).gameObject, Vector3.up * ScaleOffset() / 2, Quaternion.identity).transform;
            LoadSocial(t);
            t.gameObject.AddComponent<HyperbolicPoint>().HyperboilcPoistion = c.RealtimeTransform.inverse();
            t.transform.position = new Vector3(
				t.transform.position.x, 
				c.transform.position.y,
                t.transform.position.z
                );
            t.gameObject.GetComponent<HyperbolicPoint>().ScriptSacle = Vector3.one * ScaleOffset();
           if(t.GetComponent<itemName>()) t.GetComponent<itemName>().ItemData = Cells[select].elementData;

            if (GetComponent<Rigidbody>())
            {
                t.gameObject.GetComponent<Rigidbody>().linearDamping = 999999;
                t.gameObject.GetComponent<Rigidbody>().mass = 999999;
                t.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
                setItem("", 0, Color.red, select);
            Cells[0].UpdateCellInterface();
        }
       else if (Cells[select].elementCount != 0)
        {
            Vector3 v3;
            v3 = (MainRay.Ray.origin + (MainRay.Ray.direction * 3f)) - GameManager.isplayer().position;
            v3 /= 20;
            HyperbolicCamera c = HyperbolicCamera.Main();


            Transform t = Instantiate(inv2(Cells[select].elementName).gameObject, Vector3.up * ScaleOffset() / 2, Quaternion.identity).transform;
            LoadSocial(t);
            t.gameObject.AddComponent<HyperbolicPoint>().HyperboilcPoistion = c.RealtimeTransform.inverse();
            t.transform.position = new Vector3(
                t.transform.position.x,
                c.transform.position.y,
                t.transform.position.z
                );
            t.gameObject.GetComponent<HyperbolicPoint>().ScriptSacle = Vector3.one * ScaleOffset();
            if (t.GetComponent<itemName>()) t.GetComponent<itemName>().ItemData = Cells[select].elementData;

            if (GetComponent<Rigidbody>())
            {
                t.gameObject.GetComponent<Rigidbody>().linearDamping = 999999;
                t.gameObject.GetComponent<Rigidbody>().mass = 999999;
                t.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
            setItem("", 0, Color.red, select);
            Cells[0].UpdateCellInterface();
        }






    }
    private void hyperbolicray()
    {

        if (Input.GetKeyDown(KeyCode.Tab) && !sh && main() == this && !nosell)
        {
            Globalprefs.selectitem = "";
            RaycastHit hit = MainRay.MainHit;
            StartCoroutine(sethyperbolicitem(hit));



        }

    }
    public itemName it;
    public CustomObject co2;
    public void SelectLayItem()
	{
        if (it == null)
        {


            RaycastHit hit = MainRay.MainHit;
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<itemName>() && main() == this && !nosell)
                {


                    for (int i = 0; i < hit.collider.gameObject.name.Length - 7; i++)
                    {


                        if (hit.collider.gameObject.name[i] != '_')
                        {
                            Globalprefs.ItemPrise = (decimal)hit.collider.GetComponent<itemName>().ItemPrise;
                            Globalprefs.selectitemobj = hit.collider.GetComponent<itemName>();


                            Globalprefs.selectitem += hit.collider.gameObject.name[i];

                        }
                        if (hit.collider.gameObject.name[i] == '_')
                        {

                            Globalprefs.ItemPrise = 0;

                            Globalprefs.selectitemobj = null;
                            Globalprefs.selectitem += " ";

                        }


                    }

                    it = hit.collider.GetComponent<itemName>();
                }
            }
        }
        if (co2 == null)
        {


            RaycastHit hit = MainRay.MainHit;
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<CustomObject>() && main() == this && !nosell)
                {


                    for (int i = 0; i < hit.collider.gameObject.name.Length - 7; i++)
                    {


                        if (hit.collider.gameObject.name[i] != '_')
                        {
                            Globalprefs.ItemPrise = (decimal)hit.collider.GetComponent<CustomObject>().Model.ItemPrice;

                            Globalprefs.selectcoobj = hit.collider.GetComponent<CustomObject>();
                            Globalprefs.selectitem += hit.collider.gameObject.name[i];

                        }
                        if (hit.collider.gameObject.name[i] == '_')
                        {

                            Globalprefs.ItemPrise = 0;

                            Globalprefs.selectitemobj = null;
                            Globalprefs.selectitem += " ";

                        }


                    }

                    co2 = hit.collider.GetComponent<CustomObject>();
                }
            }
        }
    }
	public void DeselectLayItem()
	{
        if (it != null)
        {
            RaycastHit hit = MainRay.MainHit;
            if (!hit.collider.GetComponent<itemName>() && main() == this && !nosell)
            {


                Globalprefs.selectitemobj = null;
                Globalprefs.ItemPrise = 0;
                Globalprefs.selectitem = "";
                it = null;
            }
            if (hit.collider.GetComponent<itemName>()!=it && main() == this && !nosell)
            {


                Globalprefs.selectitemobj = null;
                Globalprefs.ItemPrise = 0;
                Globalprefs.selectitem = "";
                it = null;
            }

            if (MainRay.HitError && main() == this && !nosell)
            {
                Globalprefs.selectitemobj = null;
                Globalprefs.ItemPrise = 0;
                Globalprefs.selectitem = "";
                it = null;
            }

        }
        if (co2 != null)
        {
            RaycastHit hit = MainRay.MainHit;
            if (!hit.collider.GetComponent<CustomObject>() && main() == this && !nosell)
            {


                Globalprefs.selectitemobj = null;
                Globalprefs.ItemPrise = 0;
                Globalprefs.selectitem = "";
                co2 = null;
            }
            if (hit.collider.GetComponent<CustomObject>()!=co2 && main() == this && !nosell)
            {


                Globalprefs.selectitemobj = null;
                Globalprefs.ItemPrise = 0;
                Globalprefs.selectitem = "";
                co2 = null;
            }

            if (MainRay.HitError && main() == this && !nosell)
            {
                Globalprefs.selectitemobj = null;
                Globalprefs.ItemPrise = 0;
                Globalprefs.selectitem = "";
                co2 = null;
            }

        }




    }
    public bool contains (string name, int count, Color color)
	{
		int inventoryCount = 0;
		for (int i = 0; i < Cells.Length; i++) {
			if (Cells [i].elementCount != 0 && Cells [i].elementName == name && Cells [i].elementColor == color) {
				inventoryCount += Cells [i].elementCount;
			}
		}
		if (count <= inventoryCount) {
			return true;
		} else {
			return false;
		}
	}

    //Set item from link
    public void setItemLink(string name, int count, Color color, Transform cell)
    {
        Cell thisCell = cell.GetComponent<Cell>();
        thisCell.elementName = name;
        thisCell.elementCount = count;
        thisCell.elementColor = color;
    }
    public void setItemLink(string name, int count, Color color, string data, Transform cell)
    {
        Cell thisCell = cell.GetComponent<Cell>();
        thisCell.elementName = name;
        thisCell.elementCount = count;
        thisCell.elementColor = color;
        thisCell.elementData = data;
    }
    public void setItemLink(string name, int count, Color color, string data, string social, Transform cell)
    {
        Cell thisCell = cell.GetComponent<Cell>();
        thisCell.elementName = name;
        thisCell.elementCount = count;
        thisCell.elementColor = color;
        thisCell.elementData = data;
        thisCell.elementSocial = social;
    }

    //Moves item
    public void moveItem(int moveFrom, int moveTo)
    {

        setItem(Cells[moveFrom].elementName, Cells[moveFrom].elementCount, Cells[moveFrom].elementColor, Cells[moveFrom].elementData, Cells[moveFrom].elementSocial, moveTo);
        setItem("", 0, new Color(), moveFrom);

    }
    public int LayItem()
    {
        int i = 0;
		int i2 = 0;
		if (main() == this)
		{
			if (activeItem)
			{
				foreach (Cell cell in Cells)
				{
					if (cell.name == activeItem.name)
					{
						i2 = i;
					}
					if (activeItem)
					{
						if (cell.name != activeItem.name)
						{
							i++;
						}
					}
				}
			}
			if (!activeItem)
			{
				i2 = 1;

			}
		}
		return i2;
    }

    //Moves item with link
    //First - element, second - cell
    public void moveItemLink (Transform moveFrom, Transform moveTo) {
		if (moveFrom != null && moveTo != null) {
			Cell moveFromCell = moveFrom.parent.GetComponent<Cell> ();
			moveTo.GetComponent<Cell> ().elementTransform = moveFromCell.elementTransform;
			moveFromCell.elementTransform = null;
			setItemLink (moveFromCell.elementName, moveFromCell.elementCount, moveFromCell.elementColor, moveFromCell.elementData, moveTo);
			moveFromCell.elementCount = 0;
			moveFrom.parent = moveTo;
			moveFrom.localPosition = new Vector3 (0,0,0);
		}
	}

	public void moveItemLinkFirst (Transform t) 
	{

		if (main() == this)
		{


			choosenItem = t;
		}
	}

	public void moveItemLinkSecond (Transform t) 
	{
		if (main() == this)
		{
			moveItemLink(choosenItem, t);
			choosenItem = null;
		}
	}

    //Sets item
    public void setItem(string name, int count, Color color, int cellId)
    {
        Cells[cellId].ChangeElement(name, count, color);
        Cells[cellId].UpdateCellInterface();

    }
    public void setItem(string name, int count, Color color, string data, int cellId)
    {
        Cells[cellId].ChangeElement(name, count, color, data);
        Cells[cellId].UpdateCellInterface();

    }
    public void setItem(string name, int count, Color color, string data, string social, int cellId)
    {
        Cells[cellId].ChangeElement(name, count, color, data,social);
        Cells[cellId].UpdateCellInterface();

    }

    //Loads inventory from string
    public void loadFromString (string s_Inventory) {
		string[] splitedInventory = s_Inventory.Split ("\n"[0]);
		for (int i = 0; i < Cells.Length; i++) {
			string[] splitedLine = splitedInventory [i].Split(" "[0]);
			setItem (splitedLine [0], int.Parse(splitedLine [1]), SimpleMethods.stringToColor(splitedLine [2]), splitedLine[3], splitedLine[4], i);
		}
	}

	//Returns inventory as string
	public string convertToString () {
		string s_Inventory = "";
		for (int i = 0; i < Cells.Length; i++) {
			s_Inventory += Cells[i].elementName+" ";
			s_Inventory += Cells [i].elementCount + " ";
			s_Inventory += SimpleMethods.colorToString (Cells[i].elementColor) + " ";
            s_Inventory += Cells[i].elementData + " ";
            s_Inventory += Cells[i].elementSocial;
            if (i != Cells.Length) {
				s_Inventory += "\n";
			}
		}
		return s_Inventory;
	}

	//Clear inventory
	public void clear () {
		for (int i = 0; i < Cells.Length; i++) {
			if (Cells [i].elementCount != 0) {
				Cells [i].elementCount = 0;
				Cells [i].UpdateCellInterface ();
			}
		}
	}

	//Add element to inventory
	public void addItem (string name, int count, Color color) {
		int cellId = getEquals (name, color);
		if (cellId != -1) {
			Cells [cellId].elementCount = count;
		} else {
			cellId = getFirst ();
			if (cellId == -1) {
				return;
			}
			Cells [cellId].elementCount += count;
		}
		//Set up element count
		if (Cells [cellId].elementCount > maxStack) {
			int remain = Cells [cellId].elementCount - maxStack;
			Cells [cellId].elementCount = maxStack;
			addItem (name, remain, color);
		} else {
			Cells [cellId].elementCount = count;
		}
		Cells [cellId].elementName = name;
		Cells [cellId].elementColor = color;
		Cells [cellId].UpdateCellInterface ();
	}

	//Returns id of first ClearObjects cell
	public int getFirst () {
		for (int i = 0; i < Cells.Length; i++) {
			if (Cells [i].elementCount == 0) {
				
				return i;
			}
		}
		return -1;
	}

	//Returns id of first same element cell
	public int getEquals (string name, Color color) {
		for (int i = 0; i < Cells.Length; i++) {
			if (Cells [i].elementCount != 0 && Cells [i].elementCount <= maxStack && Cells [i].elementName == name && Cells [i].elementColor == color) {
				return i;
			}
		}
		return -1;
	}

}
