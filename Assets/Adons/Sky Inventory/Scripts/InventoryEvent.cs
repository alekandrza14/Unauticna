using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public void Load()
    {
        if (GetComponent<boxItem>()) GetComponent<boxItem>().Load1();
        if (GetComponent<Farm>()) GetComponent<Farm>().Load1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
