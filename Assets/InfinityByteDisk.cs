using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsInfo
{
    public List<string> namesitem = new List<string>() { "1infinityByteDisk" };
    public List<string> datasitem = new List<string>() { "" };
}

public class InfinityByteDisk : InventoryEvent
{
    public ItemsInfo itemsinfo;
    [SerializeField] Text EnergyCounter;
    string data;
    private void Start()
    {
        data = GetComponent<itemName>().ItemData;

        if (string.IsNullOrEmpty(data))
        {
            if (complsave.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
                itemsinfo = new ItemsInfo();
                data = JsonUtility.ToJson(itemsinfo);
                GetComponent<itemName>().ItemData = data;
            }
        }
        itemsinfo = JsonUtility.FromJson<ItemsInfo>(data);
      //  EnergyCounter.text = "Energy : " + data;
    }
    public void Load1()
    {
        if (GetComponent<itemName>())
        {

            data = GetComponent<itemName>().ItemData;

            if (string.IsNullOrEmpty(data))
            {

                // time = JsonUtility.ToJson(Random.ColorHSV());
                itemsinfo = new ItemsInfo();
                data = JsonUtility.ToJson(itemsinfo);
                GetComponent<itemName>().ItemData = data;


            }
            itemsinfo = JsonUtility.FromJson<ItemsInfo>(data);
            //  EnergyCounter.text = "Energy : " + energy;
        }
    }
    private void Update()
    {
        if (itemsinfo.namesitem.Count > 0) EnergyCounter.text = "Late Object : " + itemsinfo.namesitem[itemsinfo.namesitem.Count - 1];
        if (itemsinfo.namesitem.Count <= 0) EnergyCounter.text = "Late Object : None";
    }
}
