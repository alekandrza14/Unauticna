using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Crafter : MonoBehaviour
{
    public ColliderContainer container;
    public Text ItemLabel;
    public Transform pointSpawn;

    int curItem;
    void Start()
    {
        ViewItem();
        InvokeRepeating("ViewItem",0.05f, 0.05f);
    }
    public void NextItem()
    {
        if (Map_saver.t3.Length - 1 > curItem)
        {
            curItem++;
        }
        else
        {
            curItem = 0;
        }
    }
    public void BackItem()
    {
        if (0 < curItem)
        {
            curItem--;
        }
        else
        {
            curItem = Map_saver.t3.Length - 1;
        }
    }
    public void ViewItem()
    {
        ItemLabel.text = Map_saver.t3[curItem].name + " : (" + Map_saver.t3[curItem].GetComponent<itemName>().titan + "/" + GetResourse()[4] + " титан)"+ " (" + Map_saver.t3[curItem].GetComponent<itemName>().aurum + "/" + GetResourse()[0] + " золото)";
    }
    public void UtilizateItem()
    {
        GameObject itemobj = GetItem();
        itemName item = itemobj.GetComponent<itemName>();
        for (int i = 0; i < item.titan*2; i++)
        {

            Instantiate(Resources.Load<GameObject>("items/ti"), pointSpawn.position + new Vector3(0, (i / 5f), 0), Quaternion.identity);
        }
        for (int i = 0; i < item.aurum*2; i++)
        {

            Instantiate(Resources.Load<GameObject>("items/au"), pointSpawn.position + new Vector3(0, (i / 5f), 0), Quaternion.identity);
        }
        itemobj.AddComponent<DELETE>();
    }
    public void CraftItem()
    {
        if (Map_saver.t3[curItem].GetComponent<itemName>().titan <= GetResourse()[4])
        {
            if (Map_saver.t3[curItem].GetComponent<itemName>().aurum <= GetResourse()[0])
            {
                ClearResourse();
                Instantiate(Map_saver.t3[curItem], pointSpawn.position + new Vector3(0, 0, 0), Quaternion.identity);

            }
        }
    }
    public int[] GetResourse()
    {
        int[] newres = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        foreach (GameObject item in container.obj)
        {
            if(item!=null)  if (item.GetComponent<itemName>())
            {
                if (item.GetComponent<itemName>()._Name == "au")
                {
                    newres[0] += 1;
                }
                if (item.GetComponent<itemName>()._Name == "c")
                {
                    newres[1] += 1;
                }
                if (item.GetComponent<itemName>()._Name == "cr")
                {
                    newres[2] += 1;
                }
                if (item.GetComponent<itemName>()._Name == "fr")
                {
                    newres[3] += 1;
                }
                //
                if (item.GetComponent<itemName>()._Name == "ti")
                {
                    newres[4] += 1;
                }
                if (item.GetComponent<itemName>()._Name == "u")
                {
                    newres[5] += 1;
                }
                if (item.GetComponent<itemName>()._Name == "he")
                {
                    newres[6] += 1;
                }
                if (item.GetComponent<itemName>()._Name == "si")
                {
                    newres[7] += 1;
                }
                //
                if (item.GetComponent<itemName>()._Name == "ca")
                {
                    newres[8] += 1;
                }
                if (item.GetComponent<itemName>()._Name == "Uoxil")
                {
                    newres[9] += 1;
                }
            }
        }
        return newres;
    }
    public GameObject GetItem()
    {
        GameObject other = new GameObject();
        foreach (GameObject item in container.obj)
        {
            if (item != null) if (item.GetComponent<itemName>())
            {
                if (item.GetComponent<itemName>()._Name == "au")
                {
                    
                }
                else if (item.GetComponent<itemName>()._Name == "c")
                {
                    
                }
                else if (item.GetComponent<itemName>()._Name == "cr")
                {
                    
                }
                else if (item.GetComponent<itemName>()._Name == "fr")
                {
                    
                }
                else if (item.GetComponent<itemName>()._Name == "ti")
                {
                    
                }
                else if (item.GetComponent<itemName>()._Name == "u")
                {
                    
                }
                else if (item.GetComponent<itemName>()._Name == "he")
                {
                    
                }
                else if (item.GetComponent<itemName>()._Name == "si")
                {
                    
                }
                else if (item.GetComponent<itemName>()._Name == "ca")
                {
                    
                }
                else if (item.GetComponent<itemName>()._Name == "Uoxil")
                {

                }
                else if (item.gameObject == gameObject)
                {

                }
                else
                {
                    other = item.gameObject;
                }
            }
        }
        return other;
    }
    public void ClearResourse()
    {
        foreach (GameObject item in container.obj)
        {
            if (item != null) if (item.GetComponent<itemName>())
            {
                if (item.GetComponent<itemName>()._Name == "au")
                {
                    item.gameObject.AddComponent<DELETE>();
                }
                if (item.GetComponent<itemName>()._Name == "c")
                {
                    item.gameObject.AddComponent<DELETE>();
                }
                if (item.GetComponent<itemName>()._Name == "cr")
                {
                    item.gameObject.AddComponent<DELETE>();
                }
                if (item.GetComponent<itemName>()._Name == "fr")
                {
                    item.gameObject.AddComponent<DELETE>();
                }
                //
                if (item.GetComponent<itemName>()._Name == "ti")
                {
                    item.gameObject.AddComponent<DELETE>();
                }
                if (item.GetComponent<itemName>()._Name == "u")
                {
                    item.gameObject.AddComponent<DELETE>();
                }
                if (item.GetComponent<itemName>()._Name == "he")
                {
                    item.gameObject.AddComponent<DELETE>();
                }
                if (item.GetComponent<itemName>()._Name == "si")
                {
                    item.gameObject.AddComponent<DELETE>();
                }
                //
                if (item.GetComponent<itemName>()._Name == "ca")
                {
                    item.gameObject.AddComponent<DELETE>();
                }
                if (item.GetComponent<itemName>()._Name == "Uoxil")
                {
                    item.gameObject.AddComponent<DELETE>();
                }
            }
        }
    }
}
