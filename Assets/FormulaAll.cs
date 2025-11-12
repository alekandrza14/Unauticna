using UnityEngine;

public class FormulaAll : InventoryEvent
{
    public static string id1,id2,id3;
    public int capsule;
    public Transform sas;

    private void OnCollisionEnter(Collision col)
    {
        Collider other = col.collider;
        if (other.GetComponent<itemName>())
        {
            int i = 0;
            foreach (GameObject item in Map_saver.t3) 
            {
                if (other.GetComponent<itemName>()._Name == item.GetComponent<itemName>()._Name)
                {
                    Debug.Log(other.GetComponent<itemName>()._Name);
                    if (capsule == 1) Debug.Log(other.GetComponent<itemName>()._Name);
                    if (capsule == 1) Debug.Log(i.ToString());
                    if (capsule == 1) id1 = i.ToString();
                    if (capsule == 2) id2 = i.ToString();
                        if (capsule == 3) id3 = i.ToString();
                   
                }
                i++;
            }
        }
    }
    public void OnInteractive()
    {

        System.Random r = new System.Random((int)(int.Parse(id1) + int.Parse(id2) + int.Parse(id3)));
        int i = 0;
        Debug.Log("seed" + (int)(int.Parse(id1) + int.Parse(id2) + int.Parse(id3)));
        int item1 = r.Next(0, Map_saver.t3.Length);
        Debug.Log("item" + item1);
        foreach (GameObject item in Map_saver.t3)
        {
            if (i== item1)
            {
                Instantiate(Map_saver.t3[i], sas.position,Quaternion.identity);
            }
            i++;
        }
    }
}
