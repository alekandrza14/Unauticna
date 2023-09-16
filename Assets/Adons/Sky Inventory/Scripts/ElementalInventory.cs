using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
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
    public string[] itemtags;
    public string[] itemnames;
    public string[] itemPrimetiveInts;
    public GameObject[] itemPrimetive;
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
		getallitems();
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
	

	public void getallitems()
    {
		getallitemsroom();
		 GameObject[] g = Resources.LoadAll<GameObject>("items");
		itemnames = new string[g.Length]; 
		itemtags = new string[g.Length];
		for (int i =0;i<g.Length;i++)
        {
			itemnames[i] = g[i].name;
			itemtags[i] = g[i].tag;

		}
        GameObject[] g2 = Resources.LoadAll<GameObject>("Primetives");
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
		if(h.collider.GetComponent<breauty>()) x = 10 - h.collider.GetComponent<breauty>().integer;
        

			Destroy(h.collider.gameObject);
		
        if (h.collider.GetComponent<breauty>()) if (x < 0)
		{

			h.collider.GetComponent<breauty>().integer -= 10;
			h.collider.GetComponent<breauty>().resset();
		}

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
			if (Cells[i].elementName == name)
			{
				Cells[i].elementName = "";
				Cells[i].elementCount = 0;
				Cells[i].UpdateCellInterface();
				i = Cells.Length;
			}
		}
	}
	public void lowitem(string name)
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
				Cells[i].elementName = "";
				Cells[i].elementCount = 0;
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
	private void Update()
    {

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
		if (GlobalInputMenager.KeyCode_eat == 1 && Getitem("box1") && boxItem.getInventory("i3").inventory == this)
		{

			RaycastHit hit = MainRay.MainHit;
			
				if (hit.collider != null)
				{
					Instantiate(inv2("belock").gameObject, hit.point + Vector3.up * inv2("belock").gameObject.transform.localScale.y / 2, Quaternion.identity);
					Instantiate(inv2("belock").gameObject, hit.point + Vector3.up * inv2("belock").gameObject.transform.localScale.y / 2, Quaternion.identity);


				}

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
					for (int i =0;i<2; i++)
					{


						if (hit.collider.gameObject.tag == "el" && i==0)
						{
							Instantiate(elementrandom().gameObject, hit.point + Vector3.up * elementrandom().gameObject.transform.localScale.y / 2, Quaternion.identity);

							Destroy(hit.collider.gameObject);
							return;
						}
					    
					}
					}
			
        }
       
        if (Input.GetKeyDown(KeyCode.Mouse0) && Getitem("script") && Cells[select].elementName == "script" && boxItem.getInventory("i3").inventory == this)
		{
			RaycastHit hit = MainRay.MainHit;
			
				if (hit.collider != null)
				{
					GameObject g = Instantiate(Resources.Load<GameObject>("ui/script/ui"), Vector3.zero, Quaternion.identity);
					g.GetComponent<script>().sc = hit.collider.gameObject;
					setItem("", 0, Color.red, select);
					Cells[select].UpdateCellInterface();

                    Global.PauseManager.Pause();
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
			else if(FindObjectsByType<HyperbolicCamera>(sortmode.main).Length > 0)
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
                   
                }

            lowitem("gold");
        }
        //infinity_gun
        if (Input.GetKeyDown(KeyCode.Mouse0) && Getitem("infinity_gun")  && Cells[select].elementName == "infinity_gun" && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;
          
                if (hit.collider != null)
                {
                Instantiate(Resources.Load<GameObject>("DamageObject").gameObject, hit.point + Vector3.up * Resources.Load<GameObject>("DamageObject").gameObject.transform.localScale.y / 2, Quaternion.identity);

            }


        }
        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Mouse0) && Getitem("ionic_cube") && priaritet("ionic_cube") != 1 + 1 && boxItem.getInventory("i3").inventory == this)
        {

            RaycastHit hit = MainRay.MainHit;
           
                if (hit.collider != null)
                {
                    for (int i = 0; i < 200; i++)
                    {


                        Instantiate(inv2("bomb").gameObject, hit.point + Vector3.up * inv2("bomb").gameObject.transform.localScale.y / 2, Quaternion.identity);

                    }

                }

           
            ionenergy.energy = 1;
            lowioncube("ionic_cube");

        }
        //ionic_cube
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("file_рыбы") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();



            lowitem("file_рыбы");
			GlobalInputMenager.KeyCode_eat = 0;
		}
        if (GlobalInputMenager.KeyCode_eat == 1 && priaritet("belock") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            GameManager.saveandhill();

            int i = Random.Range(0, 3);
            if (i == 0)
            {
              //  Instantiate(Resources.Load("voices/belock"));
            }

            lowitem("belock");
			GlobalInputMenager.KeyCode_eat = 0;
		}

    
        if (Input.GetKeyDown(KeyCode.Tab) && boxItem.getInventory("i3").inventory == this && !nosell)
        {
           
			

				Globalprefs.selectitem = "";
				RaycastHit hit = MainRay.MainHit;

            if (hit.collider && Cells[select].elementCount == 0 && tag1(hit.collider.tag) && tag2(hit.collider.gameObject)&&hit.collider.GetComponent<itemName>())
            {



                setItem(fullname(hit), 1, Color.red, hit.collider.GetComponent<itemName>().ItemData, select);
                Cells[select].UpdateCellInterface();
                sh = true;

            }
            else if (hit.collider && Cells[select].elementCount == 0 && hit.collider.GetComponent<StandartObject>())
            {



                setItem(fullname(hit), 1, Color.red, select);
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

            Destroy(t.gameObject.GetComponent<Rigidbody>());
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
            Destroy(t.gameObject.GetComponent<Rigidbody>());
            setItem("", 0, Color.red, select);
            Cells[0].UpdateCellInterface();
        }






    }
    private void hyperbolicray()
	{
        if (mouseDoubele > 0)
        {
            mouseDoubele -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && mouseDoubele < 3)
		{
			mouseDoubele++;

        }
		if (mouseDoubele >= 1.5f&& !sh && boxItem.getInventory("i3").inventory == this && !nosell)
		{
            Globalprefs.selectitem = "";
			RaycastHit hit = MainRay.MainHit;
				StartCoroutine(sethyperbolicitem(hit));
			


			}

		}
	public itemName it;
	public void SelectLayItem()
	{
		if (it == null)
		{


			RaycastHit hit = MainRay.MainHit;
			if (hit.collider!= null)
			{
				if (hit.collider.GetComponent<itemName>() && boxItem.getInventory("i3").inventory == this && !nosell)
				{


					for (int i = 0; i < hit.collider.gameObject.name.Length - 7; i++)
					{


						if (hit.collider.gameObject.name[i] != '_')
						{
							Globalprefs.ItemPrise = hit.collider.GetComponent<itemName>().ItemPrise;
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
