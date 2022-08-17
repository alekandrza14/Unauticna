using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class RandomItem : MonoBehaviour {

	private ElementalInventory inventory;
	public gsave g = new gsave();
	public InputField ifd;
	[SerializeField] string inventoryname;
	[SerializeField] bool deleted;

	private void Start()
    {
		Directory.CreateDirectory("unsave");
		if (inventory == null)
		{
			inventory = FindObjectOfType(typeof(ElementalInventory)) as ElementalInventory;
		}
		
		if (File.Exists("unsave/s"))
		{
			ifd.text = File.ReadAllText("unsave/s");
		}
		if (File.Exists("unsave/capterg/" + ifd.text))
		{
			g = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + ifd.text));

			for (int i = 0; i < g.inventoryname.Count; i++)
			{
				if (
				g.inventoryname[i] == inventoryname
					)
				{

					inventory.loadFromString(g.inventory[i]);

				}
			}
        }

    }

	void Update () {
		if (inventory == null) {
			inventory = FindObjectOfType (typeof(ElementalInventory)) as ElementalInventory;
		}
		
		if (Input.GetKeyDown (KeyCode.C) && !deleted) {
			inventory.clear ();
		}
		
			bool stat = false;
			for (int i = 0; i < g.inventoryname.Count; i++)
			{
				if (
				g.inventoryname[i] == inventoryname
					)
				{
					stat = true;
					g.inventory[i] = inventory.convertToString();

				}
				if (
			   g.inventoryname[i] != inventoryname
				   )
				{
					stat = false;
					

				}

			}

            if (!stat)
            {
				g.inventory.Add(inventory.convertToString());
				g.inventoryname.Add(inventoryname);
			}

			GameObject.FindObjectOfType<mover>().gsave = g;

        if (Input.GetKeyDown(KeyCode.F2) && Directory.Exists("debug"))
        {
			inventory.addItem("учбнк_кф", 1, Color.black);
        }
		if (Input.GetKeyDown (KeyCode.Escape)) {
			inventory.gameObject.SetActive (false);
		}
		if (Input.GetKeyDown (KeyCode.Tab)) {
			inventory.gameObject.SetActive (true);
		}
	}

}
