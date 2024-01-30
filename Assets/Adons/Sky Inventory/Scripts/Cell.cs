using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cell : MonoBehaviour {

    public string elementName; // Element Name
    public string elementData; // Element Data
    public int elementCount; // Element Count
	public Color elementColor; // Element Color
	public Transform elementTransform; //Transform Element
	private GameObject elementPrefab;

    //Method to update UI of this cell
    private void Start()
    {
		UpdateCellInterface();

	}
   
    public void UpdateCellInterface () {
		if (elementPrefab == null) {
			elementPrefab = (FindFirstObjectByType (typeof(ElementalInventory)) as ElementalInventory).elementPrefab;
		}
		if (elementCount == 0) {
			if (elementTransform != null) {
				Destroy (elementTransform.gameObject);
			}
			return;
		}
		else {
			if (elementTransform == null) {
				//spawn a new element prefab
				Transform newElement = Instantiate (elementPrefab).transform;
				newElement.parent = transform;
				newElement.localPosition = new Vector3 (0,0,0);
				newElement.localScale = new Vector3 (1f, 1f, 1f);
				elementTransform = newElement;
			}
			//init UI elements
			MovingEvent event1 = elementTransform.GetComponent<MovingEvent>();
			event1.cell = this;
            Image bgImage = SimpleMethods.getChildByTag (elementTransform, "backgroundImage").GetComponent<Image> ();
			Text elementText = SimpleMethods.getChildByTag (elementTransform, "elementText").GetComponent<Text> ();
			Text amountText = SimpleMethods.getChildByTag (elementTransform, "amountText").GetComponent<Text> ();
			//change UI options
			bgImage.color = elementColor;
			elementText.text = "";
			for (int i =0;i< elementName.Length;i++)
			{


				if (elementName[i] != '_')
				{


					elementText.text += elementName[i];

				}
				if (elementName[i] == '_')
				{


					elementText.text += " ";

				}
				

			}
			amountText.text = elementCount.ToString();
		}
    }

    //Change element options
    public void ChangeElement(string name, int count, Color color)
    {
        elementName = name;
        elementCount = count;
        elementColor = color;
        UpdateCellInterface();
    }
    public void ChangeElement(string name, int count, Color color,string data)
    {
        elementName = name;
        elementCount = count;
        elementColor = color;
        elementData = data;
        UpdateCellInterface();
    }

    //Clear element
    public void ClearElement () {
		elementCount = 0;
		UpdateCellInterface ();
	}

}
