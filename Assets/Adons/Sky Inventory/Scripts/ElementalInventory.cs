using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

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
	public int select = 3;
	public string[] itemtags;
	public string[] itemnames;
	public string[] nunames;
	private Transform choosenItem;
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
		nunames = new string[g.Length];
		for (int i = 0; i < nunames.Length; i++)
		{
			nunames[i] = g[i].name;

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
	}
	public GameObject inv2(string name)
	{
		GameObject g1 = Resources.Load<GameObject>("death_point");
		for (int i = 0; i < nunames.Length; i++)
		{
			if (i < nunames.Length)
			{


				if (nunames[i] != name)
				{


					return Resources.Load<GameObject>("death_point");
					
				}
			}
			if (i < nunames.Length)
			{
				if (nunames[i] == name && Resources.GetBuiltinResource<GameObject>("itms/room" + SceneManager.GetActiveScene().buildIndex + "/" + name))
				{


					g1 = Resources.Load<GameObject>("itms/room" + SceneManager.GetActiveScene().buildIndex + "/" + name);
					i = nunames.Length;
				}
			}
			if (i < nunames.Length)
			{
				if (!Resources.GetBuiltinResource<GameObject>("itms/room" + SceneManager.GetActiveScene().buildIndex + "/" + name))
				{
					

						g1 = Resources.Load<GameObject>("items/" + name);
						i = nunames.Length;
					
				}
			}

		}
        if (nunames.Length == 0)
        {
			
			for (int i = 0; i < itemnames.Length; i++)
			{
				if (i < itemnames.Length)
				{


					if (itemnames[i] != name)
					{


					g1=  Resources.Load<GameObject>("death_point");
						
					}
				}
				if (i < itemnames.Length)
				{
					


						g1 =  Resources.Load<GameObject>("items/" + name);
						
					
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


			GameObject p = Resources.Load<GameObject>("items/" + name);
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
		if (h.collider.name[h.collider.name.Length-1] ==')')
		{
			s1 = h.collider.name.Remove(h.collider.name.Length - 7);
		}
		s += s1;
		x = 10 - h.collider.GetComponent<breauty>().integer;
		if (x >= 0)
		{

			Destroy(h.collider.gameObject);
		}
		if (x < 0)
		{

			h.collider.GetComponent<breauty>().integer -= 10;
			h.collider.GetComponent<breauty>().resset();
		}
		if (x ==0)
        {
			Debug.Log("pipets");
        }
		for (int i =0;i<x;i++)
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
		for (int i = 0; i < Cells.Length; i++)
		{
			if (Cells[i].elementName == name)
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
	private void Update()
    {
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
        if (!Input.GetKey(KeyCode.LeftShift) && boxItem.getInventory("i3").inventory != this)
        {


            if (select <= Cells.Length - 1 && Input.GetKeyDown(KeyCode.E) && selectobject && !nosell)
            {
                select += 1;
            }
            if (select > 0 && Input.GetKeyDown(KeyCode.Q) && selectobject && !nosell)
            {
                select -= 1;
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && nosell && boxItem.getInventory("i3").inventory == this)
        {


            if (select <= Cells.Length - 1 && Input.GetKeyDown(KeyCode.E) && selectobject && nosell)
            {
                select += 1;
            }
            if (select > 0 && Input.GetKeyDown(KeyCode.Q) && selectobject && nosell)
            {
                select -= 1;
            }
        }
        if (!nosell && boxItem.getInventory("i3").inventory == this)
        {


            if (select <= Cells.Length - 1 && Input.GetKeyDown(KeyCode.E) && selectobject && !nosell)
            {
                select += 1;
            }
            if (select > 0 && Input.GetKeyDown(KeyCode.Q) && selectobject && !nosell)
            {
                select -= 1;
            }
        }
        for (int i = 0; i < Cells.Length && selectobject; i++)
        {
            if (i == select)
            {
                selectobject.transform.position = Cells[i].transform.position;

            }
        }
		if (Input.GetKeyDown(KeyCode.F4) && Getitem("box1") && boxItem.getInventory("i3").inventory == this)
		{

			Ray r = musave.pprey();
			RaycastHit hit;
			if (Physics.Raycast(r, out hit))
			{
				if (hit.collider != null)
				{
					Instantiate(inv2("belock").gameObject, hit.point + Vector3.up * inv2("belock").gameObject.transform.localScale.y / 2, Quaternion.identity);
					Instantiate(inv2("belock").gameObject, hit.point + Vector3.up * inv2("belock").gameObject.transform.localScale.y / 2, Quaternion.identity);


				}

			}
			removeitem("box1");
		}
		if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1) && Getitem("builder") && Cells[select].elementName == "builder" && boxItem.getInventory("i3").inventory == this)
		{
			Ray r = musave.pprey();
			RaycastHit hit;
			if (Physics.Raycast(r, out hit))
			{
				if (hit.collider != null)
				{
					if (hit.collider.gameObject.layer == 6)
					{
						Destroy(hit.collider.gameObject);
					}
				}
			}
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !Input.GetKey(KeyCode.Mouse1) && Getitem("builder") && Cells[select].elementName == "builder" && boxItem.getInventory("i3").inventory == this)
		{

			Ray r = musave.pprey();
			RaycastHit hit;
			if (Physics.Raycast(r, out hit))
			{
				if (hit.collider != null)
				{
					if (hit.collider.gameObject.layer != 6)
					{
						Instantiate(inv2("пена").gameObject, hit.point + Vector3.up * inv2("пена").gameObject.transform.localScale.y / 2, Quaternion.identity);

					}
				}

			}
			if (Physics.Raycast(r, out hit))
			{
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
		}
		if (Input.GetKeyDown(KeyCode.Mouse0) && Getitem("pistol") && priaritet("gold") != 0 && Cells[select].elementName == "pistol" && boxItem.getInventory("i3").inventory == this)
        {

            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    Instantiate(inv2("box").gameObject, hit.point + Vector3.up * inv2("box_").gameObject.transform.localScale.y / 2, Quaternion.identity);
                    Instantiate(inv2("box").gameObject, hit.point + Vector3.up * inv2("box_").gameObject.transform.localScale.y / 2, Quaternion.identity);
                    Instantiate(inv2("box").gameObject, hit.point + Vector3.up * inv2("box_").gameObject.transform.localScale.y / 2, Quaternion.identity);
                    Instantiate(inv2("box").gameObject, hit.point + Vector3.up * inv2("box_").gameObject.transform.localScale.y / 2, Quaternion.identity);
                    Instantiate(inv2("box").gameObject, hit.point + Vector3.up * inv2("box_").gameObject.transform.localScale.y / 2, Quaternion.identity);
                    Instantiate(inv2("box").gameObject, hit.point + Vector3.up * inv2("box_").gameObject.transform.localScale.y / 2, Quaternion.identity);

                }

            }
            lowitem("gold");
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Mouse0) && Getitem("ionic_cube") && priaritet("ionic_cube") != 1 + 1 && boxItem.getInventory("i3").inventory == this)
        {

            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    for (int i = 0; i < 200; i++)
                    {


                        Instantiate(inv2("bomb").gameObject, hit.point + Vector3.up * inv2("bomb").gameObject.transform.localScale.y / 2, Quaternion.identity);

                    }

                }

            }
            ionenergy.energy = 1;
            lowioncube("ionic_cube");

        }
        //ionic_cube
        if (Input.GetKeyDown(KeyCode.F4) && priaritet("file_рыбы") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            musave.saveandhill();



            lowitem("file_рыбы");
        }
        if (Input.GetKeyDown(KeyCode.F4) && priaritet("belock") != 0 && boxItem.getInventory("i3").inventory == this)
        {


            musave.saveandhill();



            lowitem("belock");
        }
		if (select != Cells.Length - 1)
		{


			if (Input.GetKeyDown(KeyCode.Tab) && boxItem.getInventory("i3").inventory == this && !nosell)
			{

				Ray r = musave.pprey();
				RaycastHit hit;
				if (Physics.Raycast(r, out hit))
				{
					if (hit.collider && Cells[select].elementCount == 0 && tag1(hit.collider.tag) && tag2(hit.collider.gameObject))
					{


						setItem(fullname(hit), 1, Color.red, select);
						Cells[select].UpdateCellInterface();
						sh = true;
					}

				}



			}
        }
        else
		{
			if (Input.GetKeyDown(KeyCode.Tab) && boxItem.getInventory("i3").inventory == this && !nosell)
			{

				Ray r = musave.pprey();
				RaycastHit hit;
				if (Physics.Raycast(r, out hit))
				{
					if (hit.collider && Cells[select].elementCount == 0 && tag1(hit.collider.tag) && tag2(hit.collider.gameObject) && !hit.collider.GetComponent<Logic_tag_1>())
					{


						setItem(fullname(hit), 1, Color.red, select);
						Cells[select].UpdateCellInterface();
						sh = true;
					}

				}



			}
		}
		
		if (FindObjectsOfType<Camd>().Length == 0)
		{


			euclideanray();
		}
		if (FindObjectsOfType<Camd>().Length > 0)
		{


			hyperbolicray();
		}
		if (Input.GetKeyDown(KeyCode.Tab) && boxItem.getInventory("i3").inventory == this)
        {
            inputButton.button = 0;
        }
        sh = false;


    }

	private void euclideanray()
	{
		if (Input.GetKeyDown(KeyCode.Tab) && !sh && boxItem.getInventory("i3").inventory == this && !nosell)
		{

			Ray r = musave.pprey();
			RaycastHit hit;
			if (Physics.Raycast(r, out hit))
			{
				if (hit.collider && Cells[select].elementCount != 0)
				{
					Instantiate(inv2(Cells[select].elementName).gameObject, hit.point + Vector3.up * inv2(Cells[select].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity);
					setItem("", 0, Color.red, select);
					Cells[select].UpdateCellInterface();
				}

			}



		}
		
	}
	private void hyperbolicray()
	{
		if (Input.GetKeyDown(KeyCode.Tab) && !sh && boxItem.getInventory("i3").inventory == this && !nosell)
		{

			Ray r = musave.pprey();
			RaycastHit hit;
			if (Physics.Raycast(r, out hit))
			{
				if (hit.collider && Cells[select].elementCount != 0)
				{
					Vector3 v3;
					v3 = hit.point - musave.isplayer().position;
					v3 /= 20;
					Camd c = Camd.Main();
					
					
					Transform t = Instantiate(inv2(Cells[select].elementName).gameObject, Vector3.up * inv2(Cells[select].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity).transform;
					t.Translate(0,v3.y,0);
					t.gameObject.AddComponent<Sphere>().p2 = c.polarTransform.inverse();
					t.gameObject.GetComponent<Sphere>().v1 = c.transform.position.y;
					t.gameObject.GetComponent<Sphere>().p2.applyTranslationY(-v3.z);
					t.gameObject.GetComponent<Sphere>().p2.applyTranslationZ(-v3.x);
					t.gameObject.GetComponent<Sphere>().ls = inv2(Cells[select].elementName).gameObject.transform.localScale;

					Destroy(t.gameObject.GetComponent<Rigidbody>());
					setItem("", 0, Color.red, select);
					Cells[0].UpdateCellInterface();
				}

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
	public void setItemLink (string name, int count, Color color, Transform cell) {
		Cell thisCell = cell.GetComponent<Cell> ();
		thisCell.elementName = name;
		thisCell.elementCount = count;
		thisCell.elementColor = color;
	}

	//Moves item
	public void moveItem (int moveFrom, int moveTo) {
		setItem (Cells[moveFrom].elementName, Cells[moveFrom].elementCount, Cells[moveFrom].elementColor, moveTo);
		setItem ("", 0, new Color(), moveFrom);
		
	}

	//Moves item with link
	//First - element, second - cell
	public void moveItemLink (Transform moveFrom, Transform moveTo) {
		if (moveFrom != null && moveTo != null) {
			Cell moveFromCell = moveFrom.parent.GetComponent<Cell> ();
			moveTo.GetComponent<Cell> ().elementTransform = moveFromCell.elementTransform;
			moveFromCell.elementTransform = null;
			setItemLink (moveFromCell.elementName, moveFromCell.elementCount, moveFromCell.elementColor, moveTo);
			moveFromCell.elementCount = 0;
			moveFrom.parent = moveTo;
			moveFrom.localPosition = new Vector3 (0,0,0);
		}
	}

	public void moveItemLinkFirst (Transform t) {
		choosenItem = t;
	}

	public void moveItemLinkSecond (Transform t) {
		moveItemLink (choosenItem, t);
		choosenItem = null;
		
	}

	//Sets item
	public void setItem (string name, int count, Color color, int cellId) {
		Cells [cellId].ChangeElement (name, count, color);
		Cells [cellId].UpdateCellInterface ();
		
	}

	//Loads inventory from string
	public void loadFromString (string s_Inventory) {
		string[] splitedInventory = s_Inventory.Split ("\n"[0]);
		for (int i = 0; i < Cells.Length; i++) {
			string[] splitedLine = splitedInventory [i].Split(" "[0]);
			setItem (splitedLine [0], int.Parse(splitedLine [1]), SimpleMethods.stringToColor(splitedLine [2]), i);
		}
	}

	//Returns inventory as string
	public string convertToString () {
		string s_Inventory = "";
		for (int i = 0; i < Cells.Length; i++) {
			s_Inventory += Cells[i].elementName+" ";
			s_Inventory += Cells [i].elementCount + " ";
			s_Inventory += SimpleMethods.colorToString (Cells[i].elementColor);
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
