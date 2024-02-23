using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator3Dpoints : InventoryEvent
{

    [SerializeField] GameObject[] objs;
    [SerializeField] int count;
    // Start is called before the first frame update
    public void Load2()
    {
        System.Random r = new System.Random((int)Globalprefs.GetIdPlanet());
        for (int i2 = 0; i2 < objs.Length; i2++)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject g = Instantiate(objs[i2],
                         new Vector3(
                         r.Next(-5000, 5000),
                         r.Next((int)transform.position.y, (int)transform.position.y),
                         r.Next(-5000, 5000)),
                         Quaternion.identity);

                g.transform.localScale = new Vector3(
                        1,1,1);



            }
        }
    }

}
