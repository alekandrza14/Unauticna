using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HBGenerator : MonoBehaviour
{
    Hyperbolic2D cur_pos;
    System.Random rand;
    public GameObject point;
    public GameObject prise;
    public bool y;
    public float distance = 1;
    public int seed;
    private void Awake()
    {
        rand = new System.Random((int)Globalprefs.GetIdPlanet()+ seed);
        for (int i = 0; i < 15; i++)
        {
            GeneratePoint();
            if (i >= 14)
            {
                PostGen();
            }
        }

    }
  
    private void PostGen()
    {

        if (!y)
        {
            HyperbolicPoint hp = Instantiate(prise, this.transform).GetComponent<HyperbolicPoint>();
            cur_pos = cur_pos.copy();
            cur_pos.applyRotation(rand.Next(-30000, 30000) / 1000f);
            cur_pos.applyTranslationY((rand.Next(-1000, 1000) / 1000f) * distance);
            cur_pos.applyTranslationZ((rand.Next(-1000, 1000) / 1000f) * distance);
            hp.HyperboilcPoistion = cur_pos.copy();
            point = hp.gameObject;
        }
        if (y)
        {
            HyperbolicPoint hp = Instantiate(prise, this.transform).GetComponentInChildren<HyperbolicPoint>();
            cur_pos = cur_pos.copy();
            cur_pos.applyRotation(rand.Next(-30000, 30000) / 1000f);
            cur_pos.applyTranslationY((rand.Next(-1000, 1000) / 1000f) * distance);
            cur_pos.applyTranslationZ((rand.Next(-1000, 1000) / 1000f) * distance);
            hp.HyperboilcPoistion = cur_pos.copy();
            point = hp.gameObject;
        }
    }


    private void GeneratePoint()
    {
     
            HyperbolicPoint hp = Instantiate(point, this.transform).GetComponent<HyperbolicPoint>();
            cur_pos = hp.HyperboilcPoistion.copy();
            cur_pos.applyRotation(rand.Next(-30000, 30000) / 1000f);
            cur_pos.applyTranslationY((rand.Next(-1000, 1000) / 1000f) * distance);
            cur_pos.applyTranslationZ((rand.Next(-1000, 1000) / 1000f) * distance);
            hp.HyperboilcPoistion = cur_pos.copy();
            point = hp.gameObject;
     
    }
}
