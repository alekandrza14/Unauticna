using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GeneratorH2 : MonoBehaviour
{

    [SerializeField] GameObject[] objs;
    [SerializeField] int count;
    [SerializeField] int H1offset;
    [SerializeField] int H2offset;
    // Start is called before the first frame update
    void Start()
    {
        System.Random r = new System.Random((int)Globalprefs.GetIdPlanet() + H2offset);
        for (int i2 = 0; i2 < objs.Length; i2++)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject g = Instantiate(objs[i2],
                         new Vector3(
                         0,
                         0,
                         0),
                         Quaternion.identity);

                g.transform.localScale = new Vector3(
                        0.1f,
                        0.1f,
                        0.1f);
                g.GetComponent<KomplexPosition>().ImVector3[0] = (double)r.Next(-2 - H1offset, 2 + H1offset);
                g.GetComponent<KomplexPosition>().ImVector3[1] = (double)r.Next(-2 + 0, 2 + H2offset*500)/500;


            }
        }
    }
}
