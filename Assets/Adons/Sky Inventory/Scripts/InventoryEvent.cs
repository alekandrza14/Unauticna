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
        if (GetComponent<Yourjuise>()) GetComponent<Yourjuise>().Load1();
        if (GetComponent<RandomColourDNA>()) GetComponent<RandomColourDNA>().Load1();
        if (GetComponent<RandomMetabolismDNA>()) GetComponent<RandomMetabolismDNA>().Load1();
        if (GetComponent<RandomBioDNA>()) GetComponent<RandomBioDNA>().Load1();
        // RandomMetabolismDNA
    }


}
