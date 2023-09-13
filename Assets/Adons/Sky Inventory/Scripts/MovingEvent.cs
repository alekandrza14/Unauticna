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
            inventory = boxItem.getInventory("i3").inventory;
        }
        if (inventory != null)
        {
            if (inventory.tag == "i3")
            {

                inventory.activeItem = cell;
                inventory.moveItemLinkFirst(transform);
            }
        }
    }

    
    public void moveHere () {
		if (inventory == null) 
        {
			inventory = boxItem.getInventory("i3").inventory;
        }
        if (inventory != null)
        {
            if (inventory.tag == "i3")
            {
                inventory.activeItem = GetComponent<Cell>();
                inventory.moveItemLinkSecond(transform);
            }
        }
	}

}
