using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
		GameObject g1 = GameObject.FindObjectsOfType<GameObject>()[0];
		for (int i = 0; i < nunames.Length; i++)
		{
			if (i < nunames.Length)
			{


				if (nunames[i] != name)
				{


					g1 = Resources.Load<GameObject>("items/" + name);
					i = nunames.Length;
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
			g1 = Resources.Load<GameObject>("items/" + name);
		}

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
	public bool tag2(GameObject name)
	{

		bool s2 = true;


		

			if ("enemies" == LayerMask.LayerToName(name.layer))
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
				i = Cells.Length;
			}
			if (Cells[i].elementName == name + "x")
			{
				Cells[i].elementName = name + "xx";
				Cells[i].elementCount = 1;
				Cells[i].UpdateCellInterface();
				i = Cells.Length;
			}
			if (Cells[i].elementName == name + "xx")
			{
				Cells[i].elementName = name + "xxx";
				Cells[i].elementCount = 1;
				Cells[i].UpdateCellInterface();
				i = Cells.Length;
			}

			if (Cells[i].elementName == name + "xxx")
			{
				Cells[i].elementName = name + "xxxx";
				Cells[i].elementCount = 1;
				Cells[i].UpdateCellInterface();
				i = Cells.Length;
			}
			if (Cells[i].elementName == name + "xxxx")
			{
				Cells[i].elementName = name + "xxxxx";
				Cells[i].elementCount = 1;
				Cells[i].UpdateCellInterface();
				i = Cells.Length;
			}
			if (Cells[i].elementName == name + "xxxxx")
			{
				Cells[i].elementName = "";
				Cells[i].elementCount = 0;
				Cells[i].UpdateCellInterface();
				i = Cells.Length;
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


            setItem("", 0, Color.red, Cells.Length - 1);
            Cells[Cells.Length - 1].UpdateCellInterface();

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
        if (Input.GetKeyDown(KeyCode.Mouse0) && Getitem("pistol") && priaritet("gold") != 0 && Cells[select].elementName == "pistol" && boxItem.getInventory("i3").inventory == this)
        {

            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    Instantiate(inv2("box").gameObject, hit.point + Vector3.up * inv2("box").gameObject.transform.localScale.y / 2, Quaternion.identity);
                    Instantiate(inv2("box").gameObject, hit.point + Vector3.up * inv2("box").gameObject.transform.localScale.y / 2, Quaternion.identity);
                    Instantiate(inv2("box").gameObject, hit.point + Vector3.up * inv2("box").gameObject.transform.localScale.y / 2, Quaternion.identity);
                    Instantiate(inv2("box").gameObject, hit.point + Vector3.up * inv2("box").gameObject.transform.localScale.y / 2, Quaternion.identity);
                    Instantiate(inv2("box").gameObject, hit.point + Vector3.up * inv2("box").gameObject.transform.localScale.y / 2, Quaternion.identity);
                    Instantiate(inv2("box").gameObject, hit.point + Vector3.up * inv2("box").gameObject.transform.localScale.y / 2, Quaternion.identity);

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

        if (Input.GetKeyDown(KeyCode.Tab) && select == 0 && boxItem.getInventory("i3").inventory == this && !nosell)
        {

            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider && Cells[0].elementCount == 0 && tag1(hit.collider.tag) && tag2(hit.collider.gameObject))
                {


                    setItem(toname(hit.collider.tag), 1, Color.red, 0);
                    Destroy(hit.collider.gameObject);
                    sh = true;
                }

            }



        }
        if (Input.GetKeyDown(KeyCode.Tab) && select == 1 && boxItem.getInventory("i3").inventory == this && !nosell)
        {
            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider && Cells[1].elementCount == 0 && tag1(hit.collider.tag) && tag2(hit.collider.gameObject))
                {


                    setItem(toname(hit.collider.tag), 1, Color.red, 1);
                    Destroy(hit.collider.gameObject);
                    sh = true;
                }

            }




        }
        if (Input.GetKeyDown(KeyCode.Tab) && select == 2 && boxItem.getInventory("i3").inventory == this && !nosell)
        {
            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider && Cells[2].elementCount == 0 && tag1(hit.collider.tag) && tag2(hit.collider.gameObject))
                {


                    setItem(toname(hit.collider.tag), 1, Color.red, 2);
                    Destroy(hit.collider.gameObject);
                    sh = true;
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
		if (Input.GetKeyDown(KeyCode.Tab) && select == 0 && !sh && boxItem.getInventory("i3").inventory == this && !nosell)
		{

			Ray r = musave.pprey();
			RaycastHit hit;
			if (Physics.Raycast(r, out hit))
			{
				if (hit.collider && Cells[0].elementCount != 0)
				{
					Instantiate(inv2(Cells[0].elementName).gameObject, hit.point + Vector3.up * inv2(Cells[0].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity);
					setItem("", 0, Color.red, 0);
					Cells[0].UpdateCellInterface();
				}

			}



		}
		if (Input.GetKeyDown(KeyCode.Tab) && select == 1 && !sh && boxItem.getInventory("i3").inventory == this && !nosell)
		{
			Ray r = musave.pprey();
			RaycastHit hit;
			if (Physics.Raycast(r, out hit))
			{
				if (hit.collider && Cells[1].elementCount != 0)
				{
					Instantiate(inv2(Cells[1].elementName).gameObject, hit.point + Vector3.up * inv2(Cells[1].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity);
					setItem("", 0, Color.red, 1);
					Cells[1].UpdateCellInterface();
				}

			}



		}
		if (Input.GetKeyDown(KeyCode.Tab) && select == 2 && !sh && boxItem.getInventory("i3").inventory == this && !nosell)
		{
			Ray r = musave.pprey();
			RaycastHit hit;
			if (Physics.Raycast(r, out hit))
			{
				if (hit.collider && Cells[2].elementCount != 0)
				{
					Instantiate(inv2(Cells[2].elementName).gameObject, hit.point + Vector3.up * inv2(Cells[2].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity);
					setItem("", 0, Color.red, 2);
					Cells[2].UpdateCellInterface();
				}

			}



		}
	}
	private void hyperbolicray()
	{
		if (Input.GetKeyDown(KeyCode.Tab) && select == 0 && !sh && boxItem.getInventory("i3").inventory == this && !nosell)
		{

			Ray r = musave.pprey();
			RaycastHit hit;
			if (Physics.Raycast(r, out hit))
			{
				if (hit.collider && Cells[0].elementCount != 0)
				{
					Vector3 v3;
					v3 = hit.point - musave.isplayer().position;
					v3 /= 20;
					Camd c = Camd.Main();
					
					
					Transform t = Instantiate(inv2(Cells[0].elementName).gameObject, Vector3.up * inv2(Cells[0].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity).transform;
					t.Translate(0,v3.y,0);
					t.gameObject.AddComponent<Sphere>().p2 = c.polarTransform.inverse();
					t.gameObject.GetComponent<Sphere>().v1 = c.transform.position.y;
					t.gameObject.GetComponent<Sphere>().p2.applyTranslationY(-v3.z);
					t.gameObject.GetComponent<Sphere>().p2.applyTranslationZ(-v3.x);
					t.gameObject.GetComponent<Sphere>().ls = inv2(Cells[0].elementName).gameObject.transform.localScale;

					Destroy(t.gameObject.GetComponent<Rigidbody>());
					setItem("", 0, Color.red, 0);
					Cells[0].UpdateCellInterface();
				}

			}



		}
		if (Input.GetKeyDown(KeyCode.Tab) && select == 1 && !sh && boxItem.getInventory("i3").inventory == this && !nosell)
		{
			Ray r = musave.pprey();
			RaycastHit hit;
			if (Physics.Raycast(r, out hit))
			{
				if (hit.collider && Cells[1].elementCount != 0)
				{
					Vector3 v3;
					v3 = hit.point - musave.isplayer().position;
					v3 /= 20;
					Camd c = Camd.Main();


					Transform t = Instantiate(inv2(Cells[1].elementName).gameObject, Vector3.up * inv2(Cells[1].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity).transform;
					t.Translate(0, v3.y, 0);
					t.gameObject.AddComponent<Sphere>().p2 = c.polarTransform.inverse();
					t.gameObject.GetComponent<Sphere>().v1 = c.transform.position.y;
					t.gameObject.GetComponent<Sphere>().p2.applyTranslationY(-v3.z);
					t.gameObject.GetComponent<Sphere>().p2.applyTranslationZ(-v3.x);
					t.gameObject.GetComponent<Sphere>().ls = inv2(Cells[1].elementName).gameObject.transform.localScale;
					Destroy(t.gameObject.GetComponent<Rigidbody>());
					setItem("", 0, Color.red, 1);
					Cells[1].UpdateCellInterface();
				}

			}



		}
		if (Input.GetKeyDown(KeyCode.Tab) && select == 2 && !sh && boxItem.getInventory("i3").inventory == this && !nosell)
		{
			Ray r = musave.pprey();
			RaycastHit hit;
			if (Physics.Raycast(r, out hit))
			{
				if (hit.collider && Cells[2].elementCount != 0)
				{
					Vector3 v3;
					v3 = hit.point - musave.isplayer().position;
					v3 /= 20;
					Camd c = Camd.Main();


					Transform t = Instantiate(inv2(Cells[2].elementName).gameObject, Vector3.up * inv2(Cells[2].elementName).gameObject.transform.localScale.y / 2, Quaternion.identity).transform;
					t.Translate(0, v3.y, 0);
					t.gameObject.AddComponent<Sphere>().p2 = c.polarTransform.inverse();
					t.gameObject.GetComponent<Sphere>().v1 = c.transform.position.y;
					t.gameObject.GetComponent<Sphere>().p2.applyTranslationY(-v3.z);
					t.gameObject.GetComponent<Sphere>().p2.applyTranslationZ(-v3.x); 
					t.gameObject.GetComponent<Sphere>().ls = inv2(Cells[2].elementName).gameObject.transform.localScale;
					Destroy(t.gameObject.GetComponent<Rigidbody>());
					setItem("", 0, Color.red, 2);
					Cells[2].UpdateCellInterface();
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
