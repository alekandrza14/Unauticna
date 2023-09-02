using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public void Load()
    {
        GetComponent<boxItem>().Load1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
