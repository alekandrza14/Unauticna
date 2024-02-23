using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boxItem : InventoryEvent
{
    bool enter;
    public GameObject interfase1;
    public ElementalInventory inventory;
    public RandomItem invent;
    string seed;
   [SerializeField] Text textSeed;

   public IEnumerator AutoLoad()
    {
        yield return new WaitForSeconds(1f);
        Load1();
    }

    private void Start()
    {
        StartCoroutine(AutoLoad());
    }
    // Start is called before the first frame update
    public void Load1()
    {
        if (GetComponent<itemName>()) 
        {

            seed = GetComponent<itemName>().ItemData;

            if (seed == "")
            {
                seed = Random.Range(0, 999999).ToString();
                GetComponent<itemName>().ItemData = seed;
            }
            

                invent.inventoryname = seed;
                invent.Load(); 
            
          if(textSeed) textSeed.text = "Seed : " + seed;
        }
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
        GameObject s1 = GameObject.FindObjectsByType<Transform>(sortmode.main)[0].gameObject;
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
        GameObject s1 = GameObject.FindObjectsByType<Transform>(sortmode.main)[0].gameObject;
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
            GameManager.save();

        }
    }
}
