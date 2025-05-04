using UnityEngine;

public class ItemnameFind : MonoBehaviour
{
    public string itemFind;
    public GameObject metka;
    public void Find()
    {
        itemName[] items = FindObjectsByType<itemName>(sortmode.main);
        foreach (itemName item in items)
        {
            if (item._Name == itemFind)
            {
                Instantiate(metka, item.transform);
            }
        }
    }
}
