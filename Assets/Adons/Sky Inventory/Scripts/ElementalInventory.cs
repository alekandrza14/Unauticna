using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;

public class inputButton
{
	static public int button;
}



public class ElementalInventory : MonoBehaviour {

	//Cell massive
	public Cell[] Cells;
	
	
	//Max element stack
	public int maxStack;
	public GameObject elementPrefab;
	public GameObject selectobject;
	public int select = 0;
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
	bool sh;
    private void Awake()
    {
		//getallitems();
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
      return  boxItem.getInventory("i3").inventory;
    }

    public void getallitems()
    {
        getallitemsroom();
        GameObject[] g = complsave.t3;

        itemnames = new string[g.Length];
        itemtags = new string[g.Length];
        for (int i = 0; i < g.Length; i++)
        {
            itemnames[i] = g[i].name;
            itemtags[i] = g[i].tag;

        }
        GameObject[] g2 = complsave.t4;
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
					


						g1 =  Resources.Load<GameObject>("items/" + name);
						
					
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
        DirectoryInfo dif = new DirectoryInfo("res/UserWorckspace/Items");

        for (int i = 0; i < dif.GetFiles().Length; i++)
        {
            if (i < dif.GetFiles().Length)
            {


                if ("co!"+(dif.GetFiles()[i].Name.Replace(".txt","")) == name)
                {


                    g1 = Resources.Load<GameObject>("CustomObject");
                    g1.GetComponent<CustomObject>().s = (dif.GetFiles()[i].Name.Replace(".txt", ""));

                }
            }

        }
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
		int i = Random.Range(0, 7);
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
        return	g;

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
		
       

        if (h.collider.GetComponent<breauty>()) for (int i =0;i<x;i++)
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
        string rawname1 = name.Replace(" ","_");

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
	public void lowitem(string name,string covert)
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
		if (Getitem(name+"x"))
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
    void itemUse()
	{

        bool batteytype = Cells[select].elementName == "battery" || Cells[select].elementName == "mathimatic_battery" || Cells[select].elementName == "Reload_battery";
        if (GlobalInputMenager.KeyCode_eat == 1 && Getitem("box1") && boxItem.getInventory("i3").inventory == this)
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

        if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1) && Getitem("builder") && Cells[select].elementName == "builder" && boxItem.getInventory("i3").inventory == this)
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

        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this)
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

        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "script" && boxItem.getInventory("i3").inventory == this)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                //  GameObject g = Instantiate(Resources.Load<GameObject>("ui/script/ui"), Vector3.zero, Quaternion.identity);
                //   g.GetComponent<script>().sc = hit.collider.gameObject;
                //   setItem("", 0, Color.red, select);
                //  Cells[select].UpdateCellInterface();
                script.Use((Cells[select].elementData.Replace('_', ' ')).Replace('^', '\n'), hit.collider.gameObject);
                cistalenemy.dies++;
                //  Global.PauseManager.Pause();
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "MltiverseMagicStick" && boxItem.getInventory("i3").inventory == this)
        {
            RaycastHit hit = MainRay.MainHit;


            if (FindObjectsByType<script>(sortmode.main).Length < 1) if (hit.collider != null)
                {
                    GameObject g = Instantiate(Resources.Load<GameObject>("ui/script/ui"), Vector3.zero, Quaternion.identity);
                    g.GetComponent<script>().Magic_obj = hit.collider.gameObject;
                    g.GetComponent<script>().Magic_stick = true;
                    //   setItem("", 0, Color.red, select);
                    //  Cells[select].UpdateCellInterface();
                    //  script.Use((Cells[select].elementData.Replace('_', ' ')).Replace('^', '\n'), hit.collider.gameObject);
                    cistalenemy.dies++;
                    Global.PauseManager.Pause();
                }

        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "MinecraftSandStick" && boxItem.getInventory("i3").inventory == this)
        {
            RaycastHit hit = MainRay.MainHit;
            GameObject g = Resources.Load<GameObject>("items/FallingSandFromMinecraft");
            for (int i = 0;i<30;i++)
            {
                Instantiate(g,hit.point+(Vector3.up*i),Quaternion.identity);
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKey(KeyCode.Mouse1) && Getitem("builder") && Cells[select].elementName == "builder" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;
            if (FindObjectsByType<HyperbolicCamera>(sortmode.main).Length == 0)
            {

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

        if (Input.GetKeyDown(KeyCode.Mouse0) && Getitem("pistol") && priaritet("gold") != 0 && Cells[select].elementName == "pistol" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(Resources.Load<GameObject>("DamageObject").gameObject, hit.point + Vector3.up * Resources.Load<GameObject>("DamageObject").gameObject.transform.localScale.y / 2, Quaternion.identity);

                cistalenemy.dies++;
            }

            lowitem("gold", "");
        }
        if (Input.GetKey(KeyCode.Mouse0) && Getitem("SunFireGen") && Cells[select].elementName == "SunFireGen" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(inv2("Fire").gameObject, hit.point + Vector3.up * inv2("Fire").gameObject.transform.localScale.y / 2, Quaternion.identity);

                cistalenemy.dies++;
            }

        }
        if (Input.GetKey(KeyCode.Mouse0) && Getitem("Обосанная_зажига") && Cells[select].elementName == "Обосанная_зажига" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(inv2("Piss").gameObject, hit.point + Vector3.up * inv2("Piss").gameObject.transform.localScale.y / 2, Quaternion.identity);

                cistalenemy.dies++;
            }

        }
        if (Input.GetKey(KeyCode.Mouse0) && Getitem("Хлебапекрная_зажигалка") && Cells[select].elementName == "Хлебапекрная_зажигалка" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(inv2("Хлеб").gameObject, hit.point + Vector3.up * inv2("Хлеб").gameObject.transform.localScale.y / 2, Quaternion.identity);

            }

        }
        if (Input.GetKey(KeyCode.Mouse0) && Getitem("Поглтитель_душ") && Cells[select].elementName == "Поглтитель_душ" && boxItem.getInventory("i3").inventory == this)
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && Getitem("infinity_gun") && Cells[select].elementName == "infinity_gun" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Instantiate(Resources.Load<GameObject>("DamageObject").gameObject, hit.point + Vector3.up * Resources.Load<GameObject>("DamageObject").gameObject.transform.localScale.y / 2, Quaternion.identity);

                cistalenemy.dies++;
            }


        }
        if (Input.GetKey(KeyCode.Mouse0) && Cells[select].elementName == "RayGun" && boxItem.getInventory("i3").inventory == this)
        {

            if (JsonUtility.FromJson<GeneratorEnergyData>(Cells[select].elementData).energy > 0)
            {
                GeneratorEnergyData ged;
                ged = JsonUtility.FromJson<GeneratorEnergyData>(Cells[select].elementData);
                ged.energy = (JsonUtility.FromJson<GeneratorEnergyData>(Cells[select].elementData).energy - 12);

                Cells[select].elementData = JsonUtility.ToJson(ged);

                Instantiate(Resources.Load<GameObject>("DamageRay").gameObject, mover.main().transform.position, mover.main().PlayerCamera.transform.rotation);


            }


        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "Умножение" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (int.Parse(Cells[select].elementData) > 0) for (int i = 0; i < int.Parse(Cells[select].elementData); i++)
                    {
                        GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(0, 1f+(1f*i), 0)), Quaternion.identity);
                        obj.name = obj.name.Remove(obj.name.Length - 7);
                    }
                if (int.Parse(Cells[select].elementData) == 0)
                {
                    Destroy(gameObject);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "КвадратноеУмножение" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (int.Parse(Cells[select].elementData) > 0) for (int x = 0; x < int.Parse(Cells[select].elementData); x++)
                    {
                        for (int y = 0; y < int.Parse(Cells[select].elementData); y++)
                        {
                            GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 0, 1f + (1f * y))), Quaternion.identity);
                            obj.name = obj.name.Remove(obj.name.Length - 7);
                        }
                    }
                if (int.Parse(Cells[select].elementData) == 0)
                {
                    Destroy(gameObject);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "КубическоеУмножение" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (int.Parse(Cells[select].elementData) > 0) for (int x = 0; x < int.Parse(Cells[select].elementData); x++)
                    {
                        for (int y = 0; y < int.Parse(Cells[select].elementData); y++)
                        {
                            for (int z = 0; z < int.Parse(Cells[select].elementData); z++)
                            {
                                GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 1f + (1f * y), 1f + (1f * z))), Quaternion.identity);
                                obj.name = obj.name.Remove(obj.name.Length - 7);
                            }
                        }
                    }
                if (int.Parse(Cells[select].elementData) == 0)
                {
                    Destroy(gameObject);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "ТессерактноеУмножение" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (int.Parse(Cells[select].elementData) > 0) for (int x = 0; x < int.Parse(Cells[select].elementData); x++)
                    {
                        for (int y = 0; y < int.Parse(Cells[select].elementData); y++)
                        {
                            for (int z = 0; z < int.Parse(Cells[select].elementData); z++)
                            {
                                for (int w = 0; w < int.Parse(Cells[select].elementData); w++)
                                {
                                    GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 1f + (1f * y), 1f + (1f * z))), Quaternion.identity);
                                    obj.name = obj.name.Remove(obj.name.Length - 7);
                                }
                            }
                        }
                    }
                if (int.Parse(Cells[select].elementData) == 0)
                {
                    Destroy(gameObject);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "ПентарактноеУмножение" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (int.Parse(Cells[select].elementData) > 0) for (int x = 0; x < int.Parse(Cells[select].elementData); x++)
                    {
                        for (int y = 0; y < int.Parse(Cells[select].elementData); y++)
                        {
                            for (int z = 0; z < int.Parse(Cells[select].elementData); z++)
                            {
                                for (int w = 0; w < int.Parse(Cells[select].elementData); w++)
                                {
                                    for (int h = 0; h < int.Parse(Cells[select].elementData); h++)
                                    {
                                        GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 1f + (1f * y), 1f + (1f * z))), Quaternion.identity);
                                        obj.name = obj.name.Remove(obj.name.Length - 7);

                                    }
                                }
                            }
                        }
                    }
                if (int.Parse(Cells[select].elementData) == 0)
                {
                    Destroy(gameObject);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "СикстерактноеУмножение" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (int.Parse(Cells[select].elementData) > 0) for (int x = 0; x < int.Parse(Cells[select].elementData); x++)
                    {
                        for (int y = 0; y < int.Parse(Cells[select].elementData); y++)
                        {
                            for (int z = 0; z < int.Parse(Cells[select].elementData); z++)
                            {
                                for (int w = 0; w < int.Parse(Cells[select].elementData); w++)
                                {
                                    for (int h = 0; h < int.Parse(Cells[select].elementData); h++)
                                    {
                                        for (int p = 0; p < int.Parse(Cells[select].elementData); p++)
                                        {
                                            GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + (new Vector3(1f + (1f * x), 1f + (1f * y), 1f + (1f * z))), Quaternion.identity);
                                            obj.name = obj.name.Remove(obj.name.Length - 7);
                                        }
                                    }
                                }
                            }
                        }
                    }
                if (int.Parse(Cells[select].elementData) == 0)
                {
                    Destroy(gameObject);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "СемирактноеУмножение" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (int.Parse(Cells[select].elementData) > 0) for (int x = 0; x < int.Parse(Cells[select].elementData); x++)
                    {
                        for (int y = 0; y < int.Parse(Cells[select].elementData); y++)
                        {
                            for (int z = 0; z < int.Parse(Cells[select].elementData); z++)
                            {
                                for (int w = 0; w < int.Parse(Cells[select].elementData); w++)
                                {
                                    for (int h = 0; h < int.Parse(Cells[select].elementData); h++)
                                    {
                                        for (int p = 0; p < int.Parse(Cells[select].elementData); p++)
                                        {
                                            for (int s = 0; s < int.Parse(Cells[select].elementData); s++)
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
                if (int.Parse(Cells[select].elementData) == 0)
                {
                    Destroy(gameObject);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "ОкторактноеУмножение" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (int.Parse(Cells[select].elementData) > 0) for (int x = 0; x < int.Parse(Cells[select].elementData); x++)
                    {
                        for (int y = 0; y < int.Parse(Cells[select].elementData); y++)
                        {
                            for (int z = 0; z < int.Parse(Cells[select].elementData); z++)
                            {
                                for (int w = 0; w < int.Parse(Cells[select].elementData); w++)
                                {
                                    for (int h = 0; h < int.Parse(Cells[select].elementData); h++)
                                    {
                                        for (int p = 0; p < int.Parse(Cells[select].elementData); p++)
                                        {
                                            for (int s = 0; s < int.Parse(Cells[select].elementData); s++)
                                            {
                                                for (int f = 0; f < int.Parse(Cells[select].elementData); f++)
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
                if (int.Parse(Cells[select].elementData) == 0)
                {
                    Destroy(gameObject);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "НовеморактноеУмножение" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (int.Parse(Cells[select].elementData) > 0) for (int x = 0; x < int.Parse(Cells[select].elementData); x++)
                    {
                        for (int y = 0; y < int.Parse(Cells[select].elementData); y++)
                        {
                            for (int z = 0; z < int.Parse(Cells[select].elementData); z++)
                            {
                                for (int w = 0; w < int.Parse(Cells[select].elementData); w++)
                                {
                                    for (int h = 0; h < int.Parse(Cells[select].elementData); h++)
                                    {
                                        for (int p = 0; p < int.Parse(Cells[select].elementData); p++)
                                        {
                                            for (int s = 0; s < int.Parse(Cells[select].elementData); s++)
                                            {
                                                for (int f = 0; f < int.Parse(Cells[select].elementData); f++)
                                                {
                                                    for (int c = 0; c < int.Parse(Cells[select].elementData); c++)
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
                if (int.Parse(Cells[select].elementData) == 0)
                {
                    Destroy(gameObject);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "ДесерактноеУмножение" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (int.Parse(Cells[select].elementData) > 0) for (int x = 0; x < int.Parse(Cells[select].elementData); x++)
                    {
                        for (int y = 0; y < int.Parse(Cells[select].elementData); y++)
                        {
                            for (int z = 0; z < int.Parse(Cells[select].elementData); z++)
                            {
                                for (int w = 0; w < int.Parse(Cells[select].elementData); w++)
                                {
                                    for (int h = 0; h < int.Parse(Cells[select].elementData); h++)
                                    {
                                        for (int p = 0; p < int.Parse(Cells[select].elementData); p++)
                                        {
                                            for (int s = 0; s < int.Parse(Cells[select].elementData); s++)
                                            {
                                                for (int f = 0; f < int.Parse(Cells[select].elementData); f++)
                                                {
                                                    for (int c = 0; c < int.Parse(Cells[select].elementData); c++)
                                                    {
                                                        for (int o = 0; o < int.Parse(Cells[select].elementData); o++)
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
                if (int.Parse(Cells[select].elementData) == 0)
                {
                    Destroy(gameObject);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "УдециморактноеУмножение" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (int.Parse(Cells[select].elementData) > 0) for (int x = 0; x < int.Parse(Cells[select].elementData); x++)
                    {
                        for (int y = 0; y < int.Parse(Cells[select].elementData); y++)
                        {
                            for (int z = 0; z < int.Parse(Cells[select].elementData); z++)
                            {
                                for (int w = 0; w < int.Parse(Cells[select].elementData); w++)
                                {
                                    for (int h = 0; h < int.Parse(Cells[select].elementData); h++)
                                    {
                                        for (int p = 0; p < int.Parse(Cells[select].elementData); p++)
                                        {
                                            for (int s = 0; s < int.Parse(Cells[select].elementData); s++)
                                            {
                                                for (int f = 0; f < int.Parse(Cells[select].elementData); f++)
                                                {
                                                    for (int c = 0; c < int.Parse(Cells[select].elementData); c++)
                                                    {
                                                        for (int o = 0; o < int.Parse(Cells[select].elementData); o++)
                                                        {
                                                            for (int t = 0; t < int.Parse(Cells[select].elementData); t++)
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
                if (int.Parse(Cells[select].elementData) == 0)
                {
                    Destroy(gameObject);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "ДуодециморактноеУмножение" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (int.Parse(Cells[select].elementData) > 0) for (int x = 0; x < int.Parse(Cells[select].elementData); x++)
                    {
                        for (int y = 0; y < int.Parse(Cells[select].elementData); y++)
                        {
                            for (int z = 0; z < int.Parse(Cells[select].elementData); z++)
                            {
                                for (int w = 0; w < int.Parse(Cells[select].elementData); w++)
                                {
                                    for (int h = 0; h < int.Parse(Cells[select].elementData); h++)
                                    {
                                        for (int p = 0; p < int.Parse(Cells[select].elementData); p++)
                                        {
                                            for (int s = 0; s < int.Parse(Cells[select].elementData); s++)
                                            {
                                                for (int f = 0; f < int.Parse(Cells[select].elementData); f++)
                                                {
                                                    for (int c = 0; c < int.Parse(Cells[select].elementData); c++)
                                                    {
                                                        for (int o = 0; o < int.Parse(Cells[select].elementData); o++)
                                                        {
                                                            for (int t = 0; t < int.Parse(Cells[select].elementData); t++)
                                                            {
                                                                for (int e = 0; e < int.Parse(Cells[select].elementData); e++)
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
                if (int.Parse(Cells[select].elementData) == 0)
                {
                    Destroy(gameObject);
                }
            }

        }
        //ТессерактноеУмножение
        if (Input.GetKeyDown(KeyCode.Mouse0) && !batteytype && priaritet(nameItem(Cells[select].elementName)) != 0 && Cells[select].elementCount != 0 && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<GeneratorEnergy>())
                {
                    if (hit.collider.GetComponent<GeneratorEnergy>().get == GeneratorEnergyType.bio)
                    {

                        lowitem(nameItem(Cells[select].elementName), "");
                        hit.collider.GetComponent<GeneratorEnergy>().energyData.energy += 25;
                        hit.collider.GetComponent<GeneratorEnergy>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<GeneratorEnergy>().energyData);

                    }
                }
            }



        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementCount != 0 && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<InfinityByteDisk>())
                {

                    hit.collider.GetComponent<InfinityByteDisk>().itemsinfo.namesitem.Add(Cells[select].elementName);
                    hit.collider.GetComponent<InfinityByteDisk>().itemsinfo.datasitem.Add(Cells[select].elementData);
                    hit.collider.GetComponent<InfinityByteDisk>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<InfinityByteDisk>().itemsinfo);

                    setItem("", 0, Color.red, select);
                  
                    Cells[select].UpdateCellInterface();
                }
            }



        }
      else  if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementCount == 0 && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<InfinityByteDisk>())
                {

                    List<string> s = hit.collider.GetComponent<InfinityByteDisk>().itemsinfo.namesitem;
                    List<string> s2 = hit.collider.GetComponent<InfinityByteDisk>().itemsinfo.datasitem;

                    setItem(s[s.Count - 1], 1, Color.red, s2[s2.Count - 1], select);

                    Cells[select].UpdateCellInterface();

                  
                        s.RemoveAt(s.Count - 1);
                        s2.RemoveAt(s2.Count - 1);
                        hit.collider.GetComponent<InfinityByteDisk>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<InfinityByteDisk>().itemsinfo);
                 
                }
            }



        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && batteytype && Cells[select].elementCount != 0 && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;


            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<accumulator>())
                {
                    hit.collider.GetComponent<accumulator>().energy = (float.Parse(hit.collider.GetComponent<accumulator>().energy) + float.Parse(Cells[select].elementData)).ToString();
                    hit.collider.GetComponent<accumulator>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<accumulator>().energy;
                    Cells[select].elementData = "0";
                    //  Cells[select].elementData = 
                }
            }



        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName != "mathimatic_battery" && batteytype && priaritet(nameItem(Cells[select].elementName)) != 0 && Cells[select].elementCount != 0 && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;


            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<accumulator>() && float.Parse(hit.collider.GetComponent<accumulator>().energy) - 100 >= 0)
                {
                    hit.collider.GetComponent<accumulator>().energy = (float.Parse(hit.collider.GetComponent<accumulator>().energy) - 100).ToString();
                    hit.collider.GetComponent<accumulator>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<accumulator>().energy;

                    Cells[select].elementData = (float.Parse(Cells[select].elementData) + 100).ToString();
                    //  Cells[select].elementData = 
                }
            }



        }
        if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName == "mathimatic_battery" && priaritet(nameItem(Cells[select].elementName)) != 0 && Cells[select].elementCount != 0 && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;


            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<accumulator>())
                {
                    float energy = float.Parse(hit.collider.GetComponent<accumulator>().energy);
                    hit.collider.GetComponent<accumulator>().energy = (0).ToString();
                    hit.collider.GetComponent<accumulator>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<accumulator>().energy;

                    Cells[select].elementData = (float.Parse(Cells[select].elementData) + energy).ToString();
                    //  Cells[select].elementData = 
                }
            }



        }
        if (Cells[select].elementName.Length > 2) if (Input.GetKeyDown(KeyCode.E) && Cells[select].elementName[2] == '!' && Cells[select].elementCount != 0 && boxItem.getInventory("i3").inventory == this)
        {

            DirectoryInfo dif = new DirectoryInfo("res/UserWorckspace/Items");

            for (int i = 0; i < dif.GetFiles().Length; i++)
            {
                if (i < dif.GetFiles().Length)
                {


                    if ("co!" + (dif.GetFiles()[i].Name.Replace(".txt", "")) == Cells[select].elementName)
                    {
                        CustomObjectData cod = JsonUtility.FromJson<CustomObjectData>(File.ReadAllText(dif.GetFiles()[i].FullName));
                        if (cod.standartKey == StandartKey.E)
                        {
                            CustomFunctionalItem(cod);
                        }
                    }
                }

            }



        }
      if(Cells[select].elementName.Length > 2)  if (Input.GetKeyDown(KeyCode.Mouse0) && Cells[select].elementName[2] == '!' && Cells[select].elementCount != 0 && boxItem.getInventory("i3").inventory == this)
        {

            DirectoryInfo dif = new DirectoryInfo("res/UserWorckspace/Items");

            for (int i = 0; i < dif.GetFiles().Length; i++)
            {
                if (i < dif.GetFiles().Length)
                {


                    if ("co!" + (dif.GetFiles()[i].Name.Replace(".txt", "")) == Cells[select].elementName)
                    {
                        CustomObjectData cod = JsonUtility.FromJson<CustomObjectData>(File.ReadAllText(dif.GetFiles()[i].FullName));
                        if (cod.standartKey == StandartKey.leftmouse)
                        {



                            CustomFunctionalItem(cod);
                        }
                    }
                }

            }



        }
        if (Cells[select].elementName.Length > 2) if (Input.GetKeyDown(KeyCode.LeftShift) && Cells[select].elementName[2] == '!' && Cells[select].elementCount != 0 && boxItem.getInventory("i3").inventory == this)
        {

            DirectoryInfo dif = new DirectoryInfo("res/UserWorckspace/Items");

            for (int i = 0; i < dif.GetFiles().Length; i++)
            {
                if (i < dif.GetFiles().Length)
                {


                    if ("co!" + (dif.GetFiles()[i].Name.Replace(".txt", "")) == Cells[select].elementName)
                    {
                        CustomObjectData cod = JsonUtility.FromJson<CustomObjectData>(File.ReadAllText(dif.GetFiles()[i].FullName));
                        if (cod.standartKey == StandartKey.leftshift)
                        {



                            CustomFunctionalItem(cod);
                        }
                    }
                }

            }



        }
        if (Cells[select].elementName.Length > 2) if (Input.GetKeyDown(KeyCode.Q) && Cells[select].elementName[2] == '!' && Cells[select].elementCount != 0 && boxItem.getInventory("i3").inventory == this)
        {

            DirectoryInfo dif = new DirectoryInfo("res/UserWorckspace/Items");

            for (int i = 0; i < dif.GetFiles().Length; i++)
            {
                if (i < dif.GetFiles().Length)
                {


                    if ("co!" + (dif.GetFiles()[i].Name.Replace(".txt", "")) == Cells[select].elementName)
                    {
                        CustomObjectData cod = JsonUtility.FromJson<CustomObjectData>(File.ReadAllText(dif.GetFiles()[i].FullName));
                        if (cod.standartKey == StandartKey.Q)
                        {



                            CustomFunctionalItem(cod);
                        }
                    }
                }

            }



        }
        //  1infinityByteDisk
        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Mouse0) && Getitem("ionic_cube") && priaritet("ionic_cube") != 1 + 1 && boxItem.getInventory("i3").inventory == this)
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
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("file_рыбы") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();



            lowitem("file_рыбы","");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("belock") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();

            int i = Random.Range(0, 3);
            if (i == 0)
            {
                Instantiate(Resources.Load("voices/belock"));
            }

            lowitem("belock", "seed");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Grib") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));
            playerdata.Addeffect("Trip", 60);


            lowitem("Grib", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("BlackGrib") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));
            playerdata.Addeffect("Trip", 120);

            playerdata.Addeffect("BigShot", 100);

            lowitem("BlackGrib", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("jeltok") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();

          
                //  Instantiate(Resources.Load("voices/belock"));
         

            lowitem("jeltok", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("mad") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));

            playerdata.Addeffect("Tripl2", 600);


            lowitem("mad", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Скалапендра") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();


            //  Instantiate(Resources.Load("voices/belock"));

            cistalenemy.dies += 100;
            playerdata.Addeffect("Tripl2", 600);


            lowitem("Скалапендра", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //Скалапендра
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("sosisca") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();

            int i = Random.Range(0, 6);
            if (i == 0)
            {
                //  Instantiate(Resources.Load("voices/belock"));
                playerdata.Addeffect("Trip", 60);
            }

            lowitem("sosisca", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //RedColour
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("RedColour") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();

          
                //  Instantiate(Resources.Load("voices/belock"));
                playerdata.Cleareffect();
          

            lowitem("RedColour", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("BlueColour") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();

            int i = Random.Range(0, 2);
            if (i == 0)
            {
                playerdata.Addeffect("invisible", 60);
            }

            lowitem("BlueColour", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("GreenColour") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();

            int i = Random.Range(0, 2);
            if (i == 0)
            {
                playerdata.Addeffect("Axelerate", 60);
            }

            lowitem("GreenColour", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("UltravioletColour") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();

            int i = Random.Range(0, 2);
            if (i == 0)
            {
                playerdata.Addeffect("MetabolismUp", 60);
            }

            lowitem("UltravioletColour", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Pipis") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();

            int i = Random.Range(0, 20);
            if (i == 0)
            {
                playerdata.Addeffect("BigShot", 600);

            }

            lowitem("Pipis", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Cat") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();

            cistalenemy.dies+=100;

            lowitem("Cat", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Absolute_poison") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();

            playerdata.Addeffect("BigShot", 600);
            playerdata.Addeffect("MetabolismUp", 600);
            playerdata.Addeffect("Axelerate", 600);
            playerdata.Addeffect("invisible", 600);
            playerdata.Addeffect("Trip", 600);
            playerdata.Addeffect("Tripl2", 600);



            lowitem("Absolute_poison", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Absolute_poison_II") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();

            playerdata.Addeffect("BigShot", 600);
            playerdata.Addeffect("MetabolismUp", 600);
            playerdata.Addeffect("Axelerate", 600);
            playerdata.Addeffect("invisible", 600);
            playerdata.Addeffect("Trip", 600);
            playerdata.Addeffect("Tripl2", 600);
            playerdata.Addeffect("KsenoMorfin", 600);
            VarSave.SetInt("CurrentMorf", Random.Range(0, complsave.t5.Length));
            playerdata.Addeffect("Regeneration", 600);
            playerdata.Addeffect("ImbalenceRegeneration", 600);
            playerdata.Addeffect("severe hangover", 600);
            playerdata.Addeffect("InfaltionUp", 600);

            playerdata.FreezeAlleffect();

            lowitem("Absolute_poison_II", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("KsenoMorfin") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();

            playerdata.Addeffect("KsenoMorfin", 600);
            VarSave.SetInt("CurrentMorf",Random.Range(0,complsave.t5.Length));

            GameManager.saveandhill();
            lowitem("KsenoMorfin", "");
            GlobalInputMenager.KeyCode_eat = 0;
            StartCoroutine(ReloadScene());

        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("StoneJuice") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();





            lowitem("StoneJuice", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("AppleJuice") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();



            playerdata.Addeffect("Regeneration", 600);



            lowitem("AppleJuice", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }

        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("DamageJuice") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandDamage();





            lowitem("DamageJuice", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("YourJuice") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();



            playerdata.Addeffect("ImbalenceRegeneration", 600);


            lowitem("YourJuice", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Vine") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();



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
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Дтine") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();



            playerdata.Addeffect("Шизфрения", 600);



            lowitem("Дтine", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Хлеб") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();






            lowitem("Хлеб", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("EffectFreezer") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();




            playerdata.FreezeAlleffect();


            lowitem("EffectFreezer", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("EffectBaker") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();




           
            playerdata.BakeAlleffect();

            lowitem("EffectBaker", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Метанфитамин") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();



            playerdata.Addeffect("meat", 600);

            lowitem("Метанфитамин", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        //ChaosPoution
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("ChaosPoution") != 0 && boxItem.getInventory("i3").inventory == this)
        {
            GameManager.saveandhill();
            for (int i = 0; i < 5; i++)
            {


                Transform t = Instantiate(inv2("Chaos_cube").gameObject, mover.main().transform.position , Quaternion.identity).transform; if (t.GetComponent<itemName>())
                    Chaos_cube.ChaosFunction(t.GetComponent<Chaos_cube>());
            }

            lowitem("ChaosPoution", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("ЗельеСовы") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();



            playerdata.Addeffect("Совиное Зрение", 600);

            lowitem("ЗельеСовы", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("Зелье_-1FPS") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();



            playerdata.Addeffect("-1FPS", 30);

            lowitem("Зелье_-1FPS", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("IcyCube") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();


            cistalenemy.dies += 1;

            lowitem("IcyCube", "");
            GlobalInputMenager.KeyCode_eat = 0;
        }
        if (GlobalInputMenager.KeyCode_eat == 1 && boxItem.getInventory("i3").inventory == this
              && Cells[select].elementName == "ItemSandFromMinecraft" && Cells[select].elementCount > 0)
        {
            Cells[select].elementName = "FallingSandFromMinecraft";
            Cells[select].UpdateCellInterface();

           //  lowitem("DNAColour", "");
           GlobalInputMenager.KeyCode_eat = 0;
        }
        if (Getstats.GetPlayerLevel() >= 1)
        {
            if (GlobalInputMenager.KeyCode_eat == 1 && boxItem.getInventory("i3").inventory == this
                && Cells[select].elementName == "DNAColour" && Cells[select].elementCount > 0)
            {
                mover.main().DNA.colour = JsonUtility.FromJson<PlayerDNA>(Cells[select].elementData).colour;

                VarSave.SetString("DNA", JsonUtility.ToJson(mover.main().DNA));


                //  lowitem("DNAColour", "");
                GlobalInputMenager.KeyCode_eat = 0;
            }
            if (GlobalInputMenager.KeyCode_eat == 1 && boxItem.getInventory("i3").inventory == this
                && Cells[select].elementName == "DNAMetabolism" && Cells[select].elementCount > 0)
            {
                mover.main().DNA.metabolism = JsonUtility.FromJson<PlayerDNA>(Cells[select].elementData).metabolism;

                VarSave.SetString("DNA", JsonUtility.ToJson(mover.main().DNA));


                //  lowitem("DNAColour", "");
                GlobalInputMenager.KeyCode_eat = 0;
            }
            if (GlobalInputMenager.KeyCode_eat == 1 && boxItem.getInventory("i3").inventory == this
                && Cells[select].elementName == "DNAmuscles" && Cells[select].elementCount > 0)
            {
                mover.main().DNA.Jumping = JsonUtility.FromJson<PlayerDNA>(Cells[select].elementData).Jumping;
                mover.main().DNA.hp = JsonUtility.FromJson<PlayerDNA>(Cells[select].elementData).hp;
                mover.main().DNA.regeneration = JsonUtility.FromJson<PlayerDNA>(Cells[select].elementData).regeneration;

                VarSave.SetString("DNA", JsonUtility.ToJson(mover.main().DNA));


                //  lowitem("DNAColour", "");
                GlobalInputMenager.KeyCode_eat = 0;
            }
            if (GlobalInputMenager.KeyCode_eat == 1 && boxItem.getInventory("i3").inventory == this
                && Cells[select].elementName == "DNAFixer" && Cells[select].elementCount > 0)
            {

                mover.main().DNA.bakeeffects = JsonUtility.FromJson<PlayerDNA>(Cells[select].elementData).bakeeffects;

                VarSave.SetString("DNA", JsonUtility.ToJson(mover.main().DNA));


                //  lowitem("DNAColour", "");
                GlobalInputMenager.KeyCode_eat = 0;
            }
        }

        //ПроигратьМузыку
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
         && Cells[select].elementName == "AudioPlayer" && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                GameObject g = Instantiate(Resources.Load<GameObject>("ui/console/ПроигратьМузыку"), Vector3.zero, Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && boxItem.getInventory("i3").inventory == this
         && Cells[select].elementName == "Reload_battery" && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                Cells[select].elementData = "1000";
                Instantiate(Resources.Load<GameObject>("audios/battery_reload"), Vector3.zero, Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
         && Cells[select].elementName == "SampleCrown" && Cells[select].elementCount > 0 && VarSave.GetString("ProfStatus") == "King")
        {

            VarSave.SetMoney("tevro", 2500000000);
            cistalenemy.dies = -10000;
            VarSave.SetMoney("CashFlow", 5500);
            Globalprefs.flowteuvro = 5500;

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
         && Cells[select].elementName == "Kley" && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;



            if (hit.collider != null)
            {



                Instantiate(inv2("KleySharp").gameObject, hit.point + Vector3.up * inv2("KleySharp").gameObject.transform.localScale.y / 2, Quaternion.identity);



            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
         && Cells[select].elementName == "4D-Glasses" && Cells[select].elementCount > 0)
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

              GameObject g =  Instantiate(Target, mo[i].transform.position, Quaternion.identity);
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
        if (boxItem.getInventory("i3").inventory == this
       && Cells[select].elementName == "GravityAx"
       && Cells[select].elementCount > 0 && Input.GetKeyDown(KeyCode.E))
        {
            mover.main().transform.Rotate(0, 0, 180);
        }
        if (boxItem.getInventory("i3").inventory == this
       && Cells[select].elementName == "WarpEngine"
       && Cells[select].elementCount > 0 && Input.GetKeyDown(KeyCode.E))
        {
            mover.main().transform.position += mover.main().PlayerCamera.transform.forward * 1000;
        }
        if (boxItem.getInventory("i3").inventory == this
       && Cells[select].elementName == "WarpEngine"
       && Cells[select].elementCount > 0 && Input.GetKeyUp(KeyCode.E))
        {
            yu = 0;
        }
        if (boxItem.getInventory("i3").inventory == this
       && Cells[select].elementName == "WarpEngine"
       && Cells[select].elementCount > 0 && Input.GetKey(KeyCode.E))
        {
            yu++;
            if (yu > 60)
            {

                mover.main().transform.position += mover.main().PlayerCamera.transform.forward * 1000;
            }
        }
        if (boxItem.getInventory("i3").inventory == this
       && Cells[select].elementName == "WarpEngine"
       && Cells[select].elementCount > 0 && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.LeftShift))
        {
            yu++;
            if (yu > 60)
            {

                mover.main().transform.position += mover.main().PlayerCamera.transform.forward * 100000;
            }
        }
        if (boxItem.getInventory("i3").inventory == this
       && Cells[select].elementName == "WarpEngine"
       && Cells[select].elementCount > 0 && Input.GetKeyDown(KeyCode.E) && Input.GetKey(KeyCode.LeftShift))
        {
            yu2++;
            if (yu2 > 2)
            {

                mover.main().transform.position += mover.main().PlayerCamera.transform.forward * 100000;

                yu2 = 0;
            }
        }
        if (boxItem.getInventory("i3").inventory == this
         && Cells[select].elementName == "Gift_item_from_other_Universe"
         && Cells[select].elementCount > 0)
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
                    editObject.transform.position += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), Input.GetAxis("Mouse ScrollWheel")*20);
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
            if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
         && priaritet("CatCorm") != 0 && Cells[select].elementCount > 0)
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && priaritet("CatReplicatorCorm") != 0 && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                if (hit.collider.GetComponent<itemName>())
                {
                    if (hit.collider.GetComponent<itemName>()._Name == "Cat")
                    {
                        GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), Random.Range(-4, 4)), Quaternion.identity);
                        obj.name = obj.name.Remove(obj.name.Length - 7);
                        lowitem("CatReplicatorCorm", "");
                    }
                }
            }
        }
        //Метанфитамин
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && priaritet("SkalapendraReplicatorCorm") != 0 && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                if (hit.collider.GetComponent<itemName>())
                {
                    if (hit.collider.GetComponent<itemName>()._Name == "Скалапендра")
                    {
                        GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), Random.Range(-4, 4)), Quaternion.identity);
                        obj.name = obj.name.Remove(obj.name.Length - 7);
                        lowitem("SkalapendraReplicatorCorm", "");
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && priaritet("Null") != 0 && Cells[select].elementCount > 0)
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && priaritet("Null") != 0 && Cells[select].elementCount > 0)
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && priaritet("Метанфитамин") != 0 && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                if (hit.collider.GetComponent<itemName>())
                {
                    if (hit.collider.GetComponent<itemName>()._Name == "Скалапендра")
                    {

                        GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), Random.Range(-4, 4)), Quaternion.identity);
                        obj.name = obj.name.Remove(obj.name.Length - 7);
                        lowitem("Метанфитамин", "");
                    }
                }
            }
        }
        //КормДляHextBot'ов
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && priaritet("Летунский корм") != 0 && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                if (hit.collider.GetComponent<itemName>())
                {
                    if (hit.collider.GetComponent<itemName>()._Name == "Летун")
                    {
                        GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), Random.Range(-4, 4)), Quaternion.identity);
                        obj.name = obj.name.Remove(obj.name.Length - 7);
                        lowitem("Летунский корм", "");
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && priaritet("КормДляNextBot\'ов") != 0 && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {

                if (hit.collider.GetComponent<itemName>())
                {
                    if (hit.collider.GetComponent<itemName>()._Name == "AnnoyingNextBot")
                    {
                        GameObject obj = Instantiate(hit.collider.gameObject, hit.collider.transform.position + new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), Random.Range(-4, 4)), Quaternion.identity);
                        obj.name = obj.name.Remove(obj.name.Length - 7);
                        lowitem("КормДляNextBot\'ов", "");
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && batteytype && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<GeneratorEnergy>())
                {
                    Cells[select].elementData = (float.Parse(Cells[select].elementData) + hit.collider.GetComponent<GeneratorEnergy>().energyData.energy).ToString();
                    //  Cells[select].elementData = 
                    hit.collider.GetComponent<GeneratorEnergy>().energyData.energy = 0;
                    hit.collider.GetComponent<GeneratorEnergy>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<GeneratorEnergy>().energyData);

                }
            }

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<LightStick>())
                {
                    hit.collider.GetComponent<LightStick>().energyData.energy += float.Parse(Cells[select].elementData);
                    hit.collider.GetComponent<LightStick>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<LightStick>().energyData);
                    Cells[select].elementData = "0";
                    //  Cells[select].elementData = 
                }
            }
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<RayGun>())
                {
                    hit.collider.GetComponent<RayGun>().energyData.energy += float.Parse(Cells[select].elementData);
                    hit.collider.GetComponent<RayGun>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<RayGun>().energyData);
                    Cells[select].elementData = "0";
                    //  Cells[select].elementData = 
                }
            }

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ColdGenerator>())
                {
                    hit.collider.GetComponent<ColdGenerator>().energyData.energy += float.Parse(Cells[select].elementData);
                    hit.collider.GetComponent<ColdGenerator>().GetComponent<itemName>().ItemData = JsonUtility.ToJson(hit.collider.GetComponent<ColdGenerator>().energyData);
                    Cells[select].elementData = "0";
                    //  Cells[select].elementData = 
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && Cells[select].elementName == "Grib" && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[select].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[select].elementName = "BlackGrib";
                        Cells[select].UpdateCellInterface();
                    }
                }
            }

        }
        bool itsdna  = false;
        if (Cells[select].elementName.Length > 4) if (Cells[select].elementName.Remove(3, Cells[select].elementName.Length - 3) == "DNA") itsdna = true;

       if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && itsdna && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 10)
                    {
                        //  Cells[select].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 10f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[select].elementData = "";
                        Cells[select].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && Cells[select].elementName == "Лицензия_на_запрещёный_предмет" && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[select].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[select].elementName = "Null";
                        Cells[select].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && Cells[select].elementName == "U" && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[select].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[select].elementName = "-U";
                        Cells[select].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && Cells[select].elementName == "Ṳx" && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[select].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[select].elementName = "-Ṳx";
                        Cells[select].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && Cells[select].elementName == "C" && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[select].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[select].elementName = "-C";
                        Cells[select].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && Cells[select].elementName == "Cr" && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[select].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[select].elementName = "-Cr";
                        Cells[select].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && Cells[select].elementName == "Fr" && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[select].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[select].elementName = "-Fr";
                        Cells[select].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && Cells[select].elementName == "Au" && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[select].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[select].elementName = "-Au";
                        Cells[select].UpdateCellInterface();
                    }
                    }
                }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && Cells[select].elementName == "He" && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[select].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[select].elementName = "-He";
                        Cells[select].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && Cells[select].elementName == "Ti" && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[select].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[select].elementName = "-Ti";
                        Cells[select].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && Cells[select].elementName == "Vine" && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[select].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[select].elementName = "Дтine";
                        Cells[select].UpdateCellInterface();
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory == this
            && batteytype && Cells[select].elementCount > 0)
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<ПлевковаяКастрюля>())
                {
                    if (hit.collider.GetComponent<ПлевковаяКастрюля>().плевки > 1000)
                    {
                        //  Cells[select].elementData = 
                        hit.collider.GetComponent<ПлевковаяКастрюля>().плевки -= 1000f;
                        hit.collider.GetComponent<ПлевковаяКастрюля>().GetComponent<itemName>().ItemData = hit.collider.GetComponent<ПлевковаяКастрюля>().плевки.ToString();
                        Cells[select].elementData = (float.Parse(Cells[select].elementData) * -1).ToString();
                        Cells[select].UpdateCellInterface();
                    }
                }
            }

        }
        if (GlobalInputMenager.KeyCode_eat == 1 && boxItem.getInventory("i3").inventory == this
             && Cells[select].elementName == "PortativeHyperbolicSpace_" && Cells[select].elementCount > 0)
        {
            if (SceneManager.GetActiveScene().name != "PortativeHyperbolicSpace")
            {
                VarSave.SetString("SceneNamePosition", SceneManager.GetActiveScene().name);
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

    private void CustomFunctionalItem(CustomObjectData cod)
    {
        mover m = mover.main();
        if (cod.functional == Functional.spawner)
        {
            if (!string.IsNullOrEmpty(cod.itemSpawn)) Instantiate(Resources.Load<GameObject>("items/" + cod.itemSpawn), m.transform.position, Quaternion.identity);
            if (!string.IsNullOrEmpty(cod.ObjSpawn)) Instantiate(Resources.Load<GameObject>(cod.ObjSpawn), m.transform.position, Quaternion.identity);

            if (!string.IsNullOrEmpty(cod.CoSpawn))
            {
                GameObject g = Instantiate(Resources.Load<GameObject>("CustomObject"), m.transform.position, Quaternion.identity);
                g.GetComponent<CustomObject>().s = cod.CoSpawn;

            }
            if (!string.IsNullOrEmpty(cod.EventSpawn)) Instantiate(Resources.Load<GameObject>("Event/" + cod.EventSpawn), m.transform.position, Quaternion.identity);
        }
        if (cod.functional == Functional.user)
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
            complsave cps = FindFirstObjectByType<complsave>();
           if(cod.AnigilateItem) cps.clear();
           if((long)m.hp + (long)cod.RegenerateHp < int.MaxValue) m.hp += cod.RegenerateHp;
            m.W_position += cod.playerWHMove.x;
            m.H_position += cod.playerWHMove.y;
            VarSave.LoadMoney("Inflation", ((decimal)cod.Recycler / 2000 )+((decimal)cod.InfinityRecycler)+((decimal)cod.Redecycler * 10), SaveType.global);
            VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") + (int)cod.Recycler);
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
               Instantiate( mover.main().gameObject);
            }
        }
        if (cod.functional == Functional.steyk)
        {
            setItem("",0,Color.red,select);
            Cells[select].UpdateCellInterface();
        }
    }

    private void Update()
    {
        if (Cells[select].elementName.Length > 2) if (Cells[select].elementName[2] == '!' && Cells[select].elementCount != 0 && boxItem.getInventory("i3").inventory == this)
        {

            DirectoryInfo dif = new DirectoryInfo("res/UserWorckspace/Items");

            for (int i = 0; i < dif.GetFiles().Length; i++)
            {
                if (i < dif.GetFiles().Length)
                {


                    if ("co!" + (dif.GetFiles()[i].Name.Replace(".txt", "")) == Cells[select].elementName)
                    {
                        CustomObjectData cod = JsonUtility.FromJson<CustomObjectData>(File.ReadAllText(dif.GetFiles()[i].FullName));
                        if (cod.standartKey == StandartKey.notrequired)
                        {



                            CustomFunctionalItem(cod);
                        }
                    }
                }

            }



        }
        for (int i =0;i<2;i++)
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

        if (boxItem.getInventory("i3").inventory == this)
		{
			Globalprefs.item = boxItem.getInventory("i3").inventory.Cells[select].elementName;

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
		if (boxItem.getInventory("i3").inventory.nosell == true && boxItem.getInventory("i3").inventory != this)
        {
            nosell = false;

        }
        if (boxItem.getInventory("i3").inventory.Getitem("position_planet_seloria") && planets)
        {
            Cells[4].elementCount = 3;
            Cells[4].elementName = "seloria";
        }
        if (boxItem.getInventory("i3").inventory.nosell == false && boxItem.getInventory("i3").inventory != this)
        {
            nosell = true;
        }
        if (deletecell)
        {
			if (Cells[Cells.Length - 1].elementName != "") {
				if (tag3(inv2(Cells[Cells.Length - 1].elementName)))
				{
					setItem("", 0, Color.red, Cells.Length - 1);
					Cells[Cells.Length - 1].UpdateCellInterface();
				}
			}
		}
        if (!Input.GetKey(KeyCode.Mouse0) && boxItem.getInventory("i3").inventory != this)
        {


			select = LayItem();
        }
        if (Input.GetKey(KeyCode.Mouse0) && nosell && boxItem.getInventory("i3").inventory == this)
        {


            select = LayItem();
        }
        if (!nosell && boxItem.getInventory("i3").inventory == this)
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
		if(!Globalprefs.Pause)
            itemUse();

    
        if (Input.GetKeyDown(KeyCode.Tab) && boxItem.getInventory("i3").inventory == this && !nosell)
        {
           
			

				Globalprefs.selectitem = "";
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider && Cells[select].elementCount == 0 && tag1(hit.collider.tag) && tag2(hit.collider.gameObject)&&hit.collider.GetComponent<itemName>())
            {

                if (!VarSave.ExistenceVar("researchs/" + fullname(hit)))
                {
                    Directory.CreateDirectory("unsave/var/researchs");
                   

                            VarSave.LoadMoney("research", 1);

                            Globalprefs.research = VarSave.GetMoney("research");
                            VarSave.SetInt("researchs/" + fullname(hit), 0);
                   
                }

                setItem(fullname(hit), 1, Color.red, hit.collider.GetComponent<itemName>().ItemData, select);
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
                setItem(fullname(hit), 1, Color.red, select);
                Cells[select].UpdateCellInterface();
                sh = true;

            }
            else if (hit.collider && Cells[select].elementCount == 0 && hit.collider.GetComponent<CustomObject>() && !Input.GetKey(KeyCode.C))
            {

                CustomObject co = hit.collider.GetComponent<CustomObject>();


                setItem("co!" + co.s, 1, Color.red, select);
                Destroy(co.gameObject);

                Cells[select].UpdateCellInterface();
                sh = true;

            }
            else if (hit.collider && Cells[select].elementCount == 0 && hit.collider.GetComponent<CustomObject>() && Input.GetKey(KeyCode.C))
            {

                CustomObject co = hit.collider.GetComponent<CustomObject>();


                setItem("co!" + co.s, 1, Color.red, select);
                

                Cells[select].UpdateCellInterface();
                sh = true;

            }




        }
        if (Input.GetKeyDown(KeyCode.Tab) && boxItem.getInventory("i3").inventory == this && !nosell)
        {

            RaycastHit hit2 = MainRay.SecondHit; if (hit2.collider)
            if (Cells[select].elementCount == 1 && Cells[select].elementName == "ItemKey" && hit2.collider.GetComponent<itemName>())
            {



                setItem(fullname(hit2), 1, Color.red, hit2.collider.GetComponent<itemName>().ItemData,  select);
                Cells[select].UpdateCellInterface();
                sh = true;

            }
        }
            if (Input.GetKeyDown(KeyCode.Delete) && boxItem.getInventory("i3").inventory == this && !nosell)
            {
               

                        setItem("", 0, Color.red, select);
                        Cells[select].UpdateCellInterface();
                


            }
      
		
		


		
        if (FindObjectsByType<HyperbolicCamera>(sortmode.main).Length > 0)
        {


            hyperbolicray();
        }
        else if (FindObjectsByType<PlanetGravity>(sortmode.main).Length > 0)
        {


            Sphericalray();
        }
        else 
        {


            euclideanray();
        }

        if (Input.GetKeyDown(KeyCode.Tab) && boxItem.getInventory("i3").inventory == this)
        {
            if (Input.GetKeyDown(KeyCode.Tab) && Getitem("box_") && boxItem.getInventory("i3").inventory == this)
            {




                cistalenemy.dies++;
            }
            if (Input.GetKeyDown(KeyCode.Tab) && Getitem("Ṳx") && boxItem.getInventory("i3").inventory == this)
            {




                cistalenemy.dies++;
            }
            if (Input.GetKeyDown(KeyCode.Tab) && Getitem("AntiMatter") && boxItem.getInventory("i3").inventory == this)
            {




                cistalenemy.dies++;
            }
            if (Input.GetKeyDown(KeyCode.Tab) && Getitem("Fire") && boxItem.getInventory("i3").inventory == this)
            {




                cistalenemy.dies++;
            }
            if (Input.GetKeyDown(KeyCode.Tab) && Getitem("ionic_cube") && boxItem.getInventory("i3").inventory == this)
            {




                cistalenemy.dies++;
            }
            Globalprefs.selectitem = "";
            inputButton.button = 0;
        }
        sh = false;


    }

    public IEnumerator setSphericalitem(RaycastHit hit)
    {


        yield return new WaitForSeconds(0.5f);

        

        if (hit.distance < MainRay.RayMarhHit.distance && hit.collider && Cells[select].elementCount != 0)
        {

            Transform body = Instantiate(inv2(Cells[select].elementName).gameObject, hit.point + hit.normal * inv2(Cells[select].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity).transform;
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
            Transform body = Instantiate(inv2(Cells[select].elementName).gameObject, hit.point + hit.normal * inv2(Cells[select].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity).transform;
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
    public IEnumerator seteuclideanitem(RaycastHit hit)
    {


        yield return new WaitForSeconds(0.5f);

        if (hit.distance < MainRay.RayMarhHit.distance && hit.collider && Cells[select].elementCount != 0)
        {

            Transform t = Instantiate(inv2(Cells[select].elementName).gameObject, hit.point + Vector3.up * inv2(Cells[select].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity).transform; if (t.GetComponent<itemName>()) t.GetComponent<itemName>().ItemData = Cells[select].elementData;
            setItem("", 0, Color.red, select);
            Cells[select].UpdateCellInterface();

        }
        else if (hit.distance >= MainRay.RayMarhHit.distance && Cells[select].elementCount != 0 && !Globalprefs.RaymarchHitError)
        {
            Transform t = Instantiate(inv2(Cells[select].elementName).gameObject, (MainRay.RayMarhHit.point) + Vector3.up * inv2(Cells[select].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity).transform; if (t.GetComponent<itemName>()) t.GetComponent<itemName>().ItemData = Cells[select].elementData;
            setItem("", 0, Color.red, select);
            Cells[select].UpdateCellInterface();
        }
        else if (hit.collider == null && Cells[select].elementCount != 0 && !Globalprefs.RaymarchHitError)
        {
            Transform t = Instantiate(inv2(Cells[select].elementName).gameObject, (MainRay.RayMarhHit.point) + Vector3.up * inv2(Cells[select].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity).transform; if (t.GetComponent<itemName>()) t.GetComponent<itemName>().ItemData = Cells[select].elementData;
            setItem("", 0, Color.red, select);
            Cells[select].UpdateCellInterface();
        }
        else if (Cells[select].elementCount != 0 && Globalprefs.RaymarchHitError)
        {
            Transform t = Instantiate(inv2(Cells[select].elementName).gameObject, hit.point + Vector3.up * inv2(Cells[select].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity).transform; if (t.GetComponent<itemName>()) t.GetComponent<itemName>().ItemData = Cells[select].elementData;
            setItem("", 0, Color.red, select);
            Cells[select].UpdateCellInterface();
        }






    }
    float mouseDoubele;
    float mouseDoubele2;
    private void euclideanray()
    {

        if (Input.GetKeyDown(KeyCode.Tab) && !sh && boxItem.getInventory("i3").inventory == this && !nosell)
        {
            Globalprefs.selectitem = "";
            RaycastHit hit = MainRay.MainHit;


            StartCoroutine(seteuclideanitem(hit));




        }

    }
    private void Sphericalray()
    {

        if (Input.GetKeyDown(KeyCode.Tab) && !sh && boxItem.getInventory("i3").inventory == this && !nosell)
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


            Transform t = Instantiate(inv2(Cells[select].elementName).gameObject, Vector3.up * inv2(Cells[select].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity).transform;
            
            t.gameObject.AddComponent<HyperbolicPoint>().HyperboilcPoistion = c.RealtimeTransform.inverse();
            t.transform.position = new Vector3(
				t.transform.position.x, 
				c.transform.position.y,
                t.transform.position.z
                );
            t.gameObject.GetComponent<HyperbolicPoint>().ScriptSacle = inv2(Cells[select].elementName).gameObject.transform.localScale;
           if(t.GetComponent<itemName>()) t.GetComponent<itemName>().ItemData = Cells[select].elementData;

            if (GetComponent<Rigidbody>())
            {
                t.gameObject.GetComponent<Rigidbody>().drag = 999999;
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


            Transform t = Instantiate(inv2(Cells[select].elementName).gameObject, Vector3.up * inv2(Cells[select].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity).transform;
           
            t.gameObject.AddComponent<HyperbolicPoint>().HyperboilcPoistion = c.RealtimeTransform.inverse();
            t.transform.position = new Vector3(
                t.transform.position.x,
                c.transform.position.y,
                t.transform.position.z
                );
            t.gameObject.GetComponent<HyperbolicPoint>().ScriptSacle = inv2(Cells[select].elementName).gameObject.transform.localScale;
            if (t.GetComponent<itemName>()) t.GetComponent<itemName>().ItemData = Cells[select].elementData;

            if (GetComponent<Rigidbody>())
            {
                t.gameObject.GetComponent<Rigidbody>().drag = 999999;
                t.gameObject.GetComponent<Rigidbody>().mass = 999999;
                t.gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
            setItem("", 0, Color.red, select);
            Cells[0].UpdateCellInterface();
        }






    }
    private void hyperbolicray()
    {

        if (Input.GetKeyDown(KeyCode.Tab) && !sh && boxItem.getInventory("i3").inventory == this && !nosell)
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
                if (hit.collider.GetComponent<itemName>() && boxItem.getInventory("i3").inventory == this && !nosell)
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
                if (hit.collider.GetComponent<CustomObject>() && boxItem.getInventory("i3").inventory == this && !nosell)
                {


                    for (int i = 0; i < hit.collider.gameObject.name.Length - 7; i++)
                    {


                        if (hit.collider.gameObject.name[i] != '_')
                        {
                            Globalprefs.ItemPrise = (decimal)100;


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
            if (!hit.collider.GetComponent<itemName>() && boxItem.getInventory("i3").inventory == this && !nosell)
            {


                Globalprefs.selectitemobj = null;
                Globalprefs.ItemPrise = 0;
                Globalprefs.selectitem = "";
                it = null;
            }

            if (MainRay.HitError && boxItem.getInventory("i3").inventory == this && !nosell)
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
            if (!hit.collider.GetComponent<CustomObject>() && boxItem.getInventory("i3").inventory == this && !nosell)
            {


                Globalprefs.selectitemobj = null;
                Globalprefs.ItemPrise = 0;
                Globalprefs.selectitem = "";
                co2 = null;
            }

            if (MainRay.HitError && boxItem.getInventory("i3").inventory == this && !nosell)
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

    //Moves item
    public void moveItem(int moveFrom, int moveTo)
    {

        setItem(Cells[moveFrom].elementName, Cells[moveFrom].elementCount, Cells[moveFrom].elementColor, Cells[moveFrom].elementData, moveTo);
        setItem("", 0, new Color(), moveFrom);

    }
    public int LayItem()
    {
        int i = 0;
		int i2 = 0;
		if (boxItem.getInventory("i3").inventory == this)
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

		if (boxItem.getInventory("i3").inventory == this)
		{


			choosenItem = t;
		}
	}

	public void moveItemLinkSecond (Transform t) 
	{
		if (boxItem.getInventory("i3").inventory == this)
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
    public void setItem(string name, int count, Color color,string data, int cellId)
    {
        Cells[cellId].ChangeElement(name, count, color,data);
        Cells[cellId].UpdateCellInterface();

    }

    //Loads inventory from string
    public void loadFromString (string s_Inventory) {
		string[] splitedInventory = s_Inventory.Split ("\n"[0]);
		for (int i = 0; i < Cells.Length; i++) {
			string[] splitedLine = splitedInventory [i].Split(" "[0]);
			setItem (splitedLine [0], int.Parse(splitedLine [1]), SimpleMethods.stringToColor(splitedLine [2]), splitedLine[3], i);
		}
	}

	//Returns inventory as string
	public string convertToString () {
		string s_Inventory = "";
		for (int i = 0; i < Cells.Length; i++) {
			s_Inventory += Cells[i].elementName+" ";
			s_Inventory += Cells [i].elementCount + " ";
			s_Inventory += SimpleMethods.colorToString (Cells[i].elementColor) + " ";
			s_Inventory += Cells[i].elementData;
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

	//Returns id of first clear cell
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
