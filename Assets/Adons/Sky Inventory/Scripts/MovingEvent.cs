using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MovingEvent : MonoBehaviour {

	public ElementalInventory inventory;
    public Cell cell;

	void Start () {
		if (transform.tag == "Cell") {
           
            GetComponent<Button> ().onClick.AddListener (delegate{moveHere();});
		} else {
            
            GetComponent<Button> ().onClick.AddListener (delegate{moveItem();});
		}
	}

    public void moveItem()
    {
        if (inventory == null)
        {
            inventory = FindObjectOfType(typeof(ElementalInventory)) as ElementalInventory;
        }

        inventory.activeItem = cell;
        inventory.moveItemLinkFirst(transform);
    }

    
    public void moveHere () {
		if (inventory == null) {
			inventory = FindObjectOfType (typeof(ElementalInventory)) as ElementalInventory;
        }
        inventory.activeItem = GetComponent<Cell>();
        inventory.moveItemLinkSecond (transform);
	}

}
