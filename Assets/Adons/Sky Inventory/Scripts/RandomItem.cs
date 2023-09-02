using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class RandomItem : MonoBehaviour {

	public ElementalInventory inventory;
	public ElementalInventory inventory2;
	public gsave g = new gsave();
	public InputField ifd;
	[SerializeField] public string inventoryname;
	[SerializeField] bool deleted;

    private void Start()
    {
        Directory.CreateDirectory("unsave");
        if (inventory == null)
        {
            inventory = boxItem.getInventoryMenager(gameObject.tag);
        }


        inventory.loadFromString(VarSave.GetString(inventoryname + "inv"));


    }
    public void Load()
    {
        Directory.CreateDirectory("unsave");
        if (inventory == null)
        {
            inventory = boxItem.getInventoryMenager(gameObject.tag);
        }


        inventory.loadFromString(VarSave.GetString(inventoryname + "inv"));


    }

    public void moweitem(ElementalInventory inventory1)
	{
		inventory2 = inventory1;
		if (inventory2 == null)
		{
			
		}
		if (inventory2 != null)
		{
				inventory.nosell = true;

			if (Input.GetKeyDown(KeyCode.Tab) && !Input.GetKey(KeyCode.Mouse0) && inventory.Cells[inventory.select].elementCount == 0)
			{

				inventory.Cells[inventory.select].elementCount = inventory2.Cells[inventory2.select].elementCount;
				inventory.Cells[inventory.select].elementName = inventory2.Cells[inventory2.select].elementName;
				inventory.Cells[inventory.select].elementColor = inventory2.Cells[inventory2.select].elementColor;
				inventory.Cells[inventory.select].UpdateCellInterface();
				inventory2.Cells[inventory2.select].elementCount = 0;
				inventory2.Cells[inventory2.select].elementName = ""; 
				inventory2.Cells[inventory2.select].elementColor = new Color(0,0,0,0);
				inventory2.Cells[inventory2.select].UpdateCellInterface();
			}
			if (Input.GetKeyDown(KeyCode.Tab)&& Input.GetKey(KeyCode.Mouse0) && inventory2.Cells[inventory2.select].elementCount == 0)
			{

				inventory2.Cells[inventory2.select].elementCount = inventory.Cells[inventory.select].elementCount;
				inventory2.Cells[inventory2.select].elementName = inventory.Cells[inventory.select].elementName;
				inventory2.Cells[inventory2.select].elementColor = inventory.Cells[inventory.select].elementColor;
				inventory2.Cells[inventory2.select].UpdateCellInterface();
				inventory.Cells[inventory.select].elementCount = 0;
				inventory.Cells[inventory.select].elementName = "";
				inventory.Cells[inventory.select].elementColor = new Color(0, 0, 0, 0);
				inventory.Cells[inventory.select].UpdateCellInterface();
			}
		}
    }
    public void inv()
    {
		if (inventory == null)
		{
			inventory = boxItem.getInventoryMenager(gameObject.tag);
		}
		if (inventory != null)
		{
			VarSave.SetString(inventoryname + "inv", inventory.convertToString());
		}
	}
    void Update () {

		if (inventory2 == null)
		{
			inventory.nosell = false;
		}
		if (inventory == null) {
			inventory = boxItem.getInventoryMenager(gameObject.tag);
		}

        if (inventory2 != null)
        {
			moweitem(inventory2);
        }

		if (Input.GetKeyDown(KeyCode.F1))
		{


			VarSave.SetString(inventoryname + "inv", inventory.convertToString());


		}
		if (Input.GetKeyDown(KeyCode.F2))
		{


			inventory.loadFromString(VarSave.GetString(inventoryname + "inv"));


		}




		
	}

}
