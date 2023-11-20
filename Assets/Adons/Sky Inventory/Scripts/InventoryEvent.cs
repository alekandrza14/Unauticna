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
        if (GetComponent<battery>()) GetComponent<battery>().Load1();
        if (GetComponent<GeneratorEnergy>()) GetComponent<GeneratorEnergy>().Load1();
        if (GetComponent<LightStick>()) GetComponent<LightStick>().Load1();
        if (GetComponent<ColdGenerator>()) GetComponent<ColdGenerator>().Load1();
        if (GetComponent<RayGun>()) GetComponent<RayGun>().Load1();
        if (GetComponent<accumulator>()) GetComponent<accumulator>().Load1();
        if (GetComponent<InfinityByteDisk>()) GetComponent<InfinityByteDisk>().Load1();
        // RandomMetabolismDNA
    }


}
