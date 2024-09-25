using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Generator_terrain : MonoBehaviour
{
    public Terrain ter;
    int width;
    int leng;
    int leng1;
    readonly float conf = 1;

    readonly List<Vector2> vectorsis = new();
    readonly List<float> fs = new();
    readonly List<float> fn = new();
    int i7 = 0; int i8 = 0;
    public void Start()
    {
        LoadTerraform();

    }
    private void Update()
    {
        i7 = FindObjectsByType<tearaformer>(sortmode.main).Length;
        if (i7 != i8)
        {
            Terrafrom();
            i8 = i7;

        }

    }

    float[,] lenghs; 
    float[,] slenghs;
    private void OnDestroy()
    {
        if (slenghs != null)
        {
            if (slenghs.Length != 0)
            {


                ter.terrainData.size = new Vector3(leng1, leng, leng1);
                ter.terrainData.heightmapResolution = ter.terrainData.heightmapResolution;
                ter.terrainData.SetHeights(0, 0, slenghs);
            }
        }
        }
        public void LoadTerraform()
    {

        width = ter.terrainData.heightmapResolution;
        leng = (int)ter.terrainData.size.y;
        leng1 = (int)ter.terrainData.size.x;


        float r = (float)width / (float)leng1;
        float r2 = (float)leng1 / (float)width;
        Debug.Log((r,r2));
        for (int i = 0; i < FindObjectsByType<tearaformer>(sortmode.main).Length; i++)
        {
            Vector2 v2i = new(FindObjectsByType<tearaformer>(sortmode.main)[i].transform.position.x,

        FindObjectsByType<tearaformer>(sortmode.main)[i].transform.position.z);

            float f2s = FindObjectsByType<tearaformer>(sortmode.main)[i].transform.position.y;
            fs.Add(f2s);
            float f2n = FindObjectsByType<tearaformer>(sortmode.main)[i].value;
            fn.Add(f2n);
            vectorsis.Add(v2i);
        }

        Vector2[] v2is = vectorsis.ToArray();
        float[] f = fn.ToArray();
        float[] f2 = fs.ToArray();
        Vector3 pr = new(transform.position.x, transform.position.y, transform.position.z);
        lenghs = new float[width, width];
        slenghs = new float[width, width];
        for (int i = 0; i < width - 1; i++)
        {

            for (int j = 0; j < width - 1; j++)
            {
                lenghs[i, j] = ter.terrainData.GetHeight(j, i) / leng;
                slenghs[i, j] = ter.terrainData.GetHeight(j, i) / leng;
                //  FindObjectOfType<tearaformer>().value;



            }
        }
        for (int i2 = 0; i2 < v2is.Length; i2++)
        {
            for (int i = 0; i < width; i++)
            {

            }
        }
        /*
        for (int i2 = 0; i2 < v2is.Length; i2++)
        {
            for (int i = 0; i < width; i++)
            {

                for (int j = 0; j < width; j++)
                {

                    //  FindObjectOfType<tearaformer>().value;
                    Vector2 v2 = new Vector2(j, i);
                    //   float f =  Vector2.Distance(v2,

                    //    v2i);

                    if ((v2is[i2].x - pr.x)*r > (v2.x)-fn[i2]&& (v2is[i2].x - pr.x) * r < (v2.x) + fn[i2]
                        && (v2is[i2].y - pr.z) * r > (v2.y) - fn[i2] && (v2is[i2].y - pr.z) * r < (v2.y) + fn[i2])
                    {
                        if (lenghs[i, j] > Random.Range(0f, 1f / (leng / conf)) + ((1f / leng) * ((f2[i2] - f[i2]) - pr.y)))
                        {


                            lenghs[i, j] = Random.Range(0f, 1f / (leng / conf)) + ((1f / leng) * ((f2[i2] - f[i2]) - pr.y));
                        }
                    }



                }

            }



    }
     */
        for (int i2 = 0; i2 < v2is.Length; i2++)
        {
            for (int i = (int)(((v2is[i2].x - pr.x) * r) - fn[i2]); i < ((v2is[i2].x - pr.x) * r) + fn[i2]; i++)
            {

                for (int j = (int)(((v2is[i2].y - pr.z) * r) - fn[i2]); j < ((v2is[i2].y - pr.z) * r) + fn[i2]; j++)
                {
                   
                    //   float f =  Vector2.Distance(v2,

                    //    v2i);

                    if (lenghs[j, i] > Random.Range(0f, 1f / (leng / conf)) + ((1f / leng) * ((f2[i2] - f[i2]) - pr.y)))
                    {


                        lenghs[j, i] = Random.Range(0f, 1f / (leng / conf)) + ((1f / leng) * ((f2[i2] - f[i2]) - pr.y));
                    }

                }
            }
        }

        ter.terrainData.size = new Vector3(leng1, leng, leng1);
        ter.terrainData.heightmapResolution = ter.terrainData.heightmapResolution;
        ter.terrainData.SetHeights(0, 0, lenghs);
    }
    public void Terrafrom()
    {

        float r = (float)width / (float)leng1;
        for (int i = 0; i < FindObjectsByType<tearaformer>(sortmode.main).Length; i++)
        {
            Vector2 v2i = new(FindObjectsByType<tearaformer>(sortmode.main)[i].transform.position.x,

        FindObjectsByType<tearaformer>(sortmode.main)[i].transform.position.z);

            float f2s = FindObjectsByType<tearaformer>(sortmode.main)[i].transform.position.y;
            fs.Add(f2s);
            float f2n = FindObjectsByType<tearaformer>(sortmode.main)[i].value;
            fn.Add(f2n);
            vectorsis.Add(v2i);
        }

        Vector2[] v2is = vectorsis.ToArray();
        float[] f = fn.ToArray();
        float[] f2 = fs.ToArray();
        Vector3 pr = new(transform.position.x, transform.position.y, transform.position.z);

        /*

        for (int i2 = 0; i2 < v2is.Length; i2++)
        {
            for (int i = 0; i <width; i++)
            {

                for (int j = 0; j < width; j++)
                {

                    //  FindObjectOfType<tearaformer>().value;
                    Vector2 v2 = new Vector2(j, i);
                    //   float f =  Vector2.Distance(v2,

                    //    v2i);
                    if ((v2is[i2].x - pr.x) * r > (v2.x) - fn[i2] && (v2is[i2].x - pr.x) * r < (v2.x) + fn[i2]
                       && (v2is[i2].y - pr.z) * r > (v2.y) - fn[i2] && (v2is[i2].y - pr.z) * r < (v2.y) + fn[i2])
                    {
                        if (lenghs[i, j] > Random.Range(0f, 1f / (leng / conf)) + ((1f / leng) * ((f2[i2] - f[i2]) - pr.y)))
                        {


                            lenghs[i, j] = Random.Range(0f, 1f / (leng / conf)) + ((1f / leng) * ((f2[i2] - f[i2]) - pr.y));
                        }
                    }


                }
            }
        

        */
        for (int i2 = 0; i2 < v2is.Length; i2++)
        {
            for (int i = (int)(((v2is[i2].x - pr.x) * r) - fn[i2]); i < ((v2is[i2].x - pr.x) * r) + fn[i2]; i++)
            {

                for (int j = (int)(((v2is[i2].y - pr.z) * r) - fn[i2]); j < ((v2is[i2].y - pr.z) * r) + fn[i2]; j++)
                {
                   
                    //   float f =  Vector2.Distance(v2,

                    //    v2i);

                    if (lenghs[j, i] > Random.Range(0f, 1f / (leng / conf)) + ((1f / leng) * ((f2[i2] - f[i2]) - pr.y)))
                    {


                        lenghs[j, i] = Random.Range(0f, 1f / (leng / conf)) + ((1f / leng) * ((f2[i2] - f[i2]) - pr.y));
                    }

                }
            }
        }
        ter.terrainData.size = new Vector3(leng1, leng, leng1);
        ter.terrainData.heightmapResolution = ter.terrainData.heightmapResolution;
        ter.terrainData.SetHeights(0, 0, lenghs);
    }
}
