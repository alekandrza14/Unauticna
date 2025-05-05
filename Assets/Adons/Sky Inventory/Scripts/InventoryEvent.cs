using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEvent : MonoBehaviour
{
    public void Load()
    {
        foreach (InventoryEvent item in GetComponents<InventoryEvent>())
        {
            item.Invoke("Load1", 0.01f);
        }
    }
    public void init()
    {
        foreach (InventoryEvent item in GetComponents<InventoryEvent>())
        {
            item.Invoke("Load2", 0.01f);
        }
    }
}
