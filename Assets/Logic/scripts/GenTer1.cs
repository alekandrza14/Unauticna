using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenTer1 : MonoBehaviour
{
    public Terrain ter;
    float[,] lenghs = new float[513, 513];
    void Start()
    {
        for (int i = 0; i < 513; i++)
        {

            for (int j = 0; j < 513; j++)
            {
                lenghs[i, j] = Mathf.PerlinNoise(0.6642f, j + 0.1242f) / 600f;
                lenghs[i, j] += Mathf.PerlinNoise(0.6642f, (j / 4) + 0.1242f) / 300f;
                lenghs[i, j] += Mathf.PerlinNoise(0.6642f, (j / 8) + 0.1242f) / 100f;
                //  FindObjectOfType<tearaformer>().value;
                lenghs[0, j] = 0;
                lenghs[512, j] = 0;
                lenghs[i, 0] = 0;
                lenghs[i, 512] = 0;


            }
        }
        ter.terrainData.SetHeights(0,0,lenghs);
    }
}
