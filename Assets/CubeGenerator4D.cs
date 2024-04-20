using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator4D : MonoBehaviour
{

    [SerializeField] GameObject[] objs;
    [SerializeField] MultyObject mp;
    [SerializeField] int count;
    [SerializeField] int Woffset;
    // Start is called before the first frame update
    void Start()
    {
        System.Random r = new System.Random((int)Globalprefs.GetIdPlanet() + (int)mp.W_Position);
        for (int i2 = 0; i2 < objs.Length; i2++)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject g = Instantiate(objs[i2],
                         new Vector3(
                         r.Next(-Woffset, Woffset),
                         r.Next(-Woffset, Woffset),
                         r.Next(-Woffset, Woffset))+transform.position,
                         Quaternion.identity);


                g.GetComponent<MultyObject>().W_Position = r.Next(-Woffset + (int)mp.W_Position, Woffset + (int)mp.W_Position);


            }
        }
    }
}