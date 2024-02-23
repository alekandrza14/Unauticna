using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator3DSpace : MonoBehaviour
{
    [SerializeField] GameObject[] objs;
    [SerializeField] int count;
    // Start is called before the first frame update
    void Start()
    {
        System.Random r = new System.Random((int)Globalprefs.GetIdPlanet());
        for (int i2 = 0; i2 < objs.Length; i2++)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject g = Instantiate(objs[i2],
                         new Vector3(
                         r.Next(-2000, 2000),
                         r.Next(-2000, 2000),
                         r.Next(-2000, 2000)),
                         Quaternion.identity);

                g.transform.localScale = new Vector3(
                        r.Next(-100, 100),
                        r.Next(-100, 100),
                        r.Next(-100, 100));

            

            }
        }
    }

  
}
