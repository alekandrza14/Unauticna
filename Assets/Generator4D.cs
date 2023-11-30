using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator4D : MonoBehaviour
{
   
        [SerializeField] GameObject[] objs;
    [SerializeField] int count;
    [SerializeField] int Woffset;
    // Start is called before the first frame update
    void Start()
    {
        System.Random r = new System.Random((int)Globalprefs.GetIdPlanet()+ Woffset);
        for (int i2 = 0; i2 < objs.Length; i2++)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject g = Instantiate(objs[i2],
                         new Vector3(
                         r.Next(-24, 24),
                         r.Next(-1, 1),
                         r.Next(-24, 24)),
                         Quaternion.identity);

                g.transform.localScale = new Vector3(
                        r.Next(1, 2),
                        r.Next(1, 2),
                        r.Next(1, 2));
                g.GetComponent<MultyObject>().W_Position = r.Next(-2+Woffset, 2 + Woffset);


            }
        }
    }

 

}
