using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxItem : MonoBehaviour
{
    bool enter;
    public GameObject interfase1;
    public ElementalInventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!enter)
        {
            enter = false;
            
            interfase1.SetActive(false);
            getInventory("i3").moweitem(null);
        }
    }
    static public RandomItem getInventory(string inv)
    {
        GameObject[] s = GameObject.FindGameObjectsWithTag(inv);
        GameObject s1 = GameObject.FindObjectsOfType<Transform>()[0].gameObject;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].GetComponent<RandomItem>())
            {
                s1 = s[i];
            }
        }
        return s1.GetComponent<RandomItem>();
    }
    static public ElementalInventory getInventoryMenager(string inv)
    {
        GameObject[] s = GameObject.FindGameObjectsWithTag(inv);
        GameObject s1 = GameObject.FindObjectsOfType<Transform>()[0].gameObject;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].GetComponent<ElementalInventory>())
            {
                s1 = s[i];
            }
        }
        return s1.GetComponent<ElementalInventory>();
    }
    public void startcol(Collider c)
    {
        enter = true;
        interfase1.SetActive(true);
        if (c.gameObject.tag == "Player")
        {

            getInventory("i3").moweitem(inventory);
        }
    }

        private void OnTriggerEnter(Collider s)
    {
        if (s.gameObject.tag == "Player")
        {

            startcol(s);



        }
    }
    private void OnTriggerExit(Collider s)
    {
        if (s.gameObject.tag == "Player")
        {

            enter = false;
            
            interfase1.SetActive(false);
            getInventory("i3").moweitem(null);

        }
    }
}
