using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class generator_terrain : MonoBehaviour
{
    public Terrain ter;
    int width;
    int leng;
    int leng1;
    float hend = 0.2f;
    float conf = 1;
    
    List<Vector2> vectorsis = new List<Vector2>();
    List<float> fs = new List<float>();
    List<float> fn = new List<float>();
    int i7 = 0; int i8 = 0;
    void Start()
    {
        generate();

    }
    private void Update()
    {
        i7 = FindObjectsOfType<tearaformer>().Length;
        if (i7 != i8)
        {
            regenerate();
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
        public void generate()
    {

        width = ter.terrainData.heightmapResolution;
        leng = (int)ter.terrainData.size.y;
        leng1 = (int)ter.terrainData.size.x;


        float r = (float)width / (float)leng1;
        float r2 = (float)leng1 / (float)width;
        Debug.Log((r,r2));
        for (int i = 0; i < FindObjectsOfType<tearaformer>().Length; i++)
        {
            Vector2 v2i = new Vector2(FindObjectsOfType<tearaformer>()[i].transform.position.x,

        FindObjectsOfType<tearaformer>()[i].transform.position.z);

            float f2s = FindObjectsOfType<tearaformer>()[i].transform.position.y;
            fs.Add(f2s);
            float f2n = FindObjectsOfType<tearaformer>()[i].value;
            fn.Add(f2n);
            vectorsis.Add(v2i);
        }

        Vector2[] v2is = vectorsis.ToArray();
        float[] f = fn.ToArray();
        float[] f2 = fs.ToArray();
        Vector3 pr = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        lenghs = new float[(int)((float)width), (int)((float)width)];
        slenghs = new float[(int)((float)width), (int)((float)width)];
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

                for (int j = 0; j < width; j++)
                {

                    //  FindObjectOfType<tearaformer>().value;
                    Vector2 v2 = new Vector2(j, i);
                    //   float f =  Vector2.Distance(v2,

                    //    v2i);
                    /*
                    if (v2is[i2].x - pr.x < (v2.x*r) + f[i2] && v2is[i2].x - pr.x > f[i2] &&  v2is[i2].y - pr.z < (v2.y * r) + f[i2] &&v2is[i2].y - pr.z > (v2.y * r) - f[i2])
                    {
                        if (lenghs[i, j] > Random.Range(0f, 1f / (leng / conf)) + ((1f / leng) * ((f2[i2] - f[i2]) - pr.y)))
                        {


                            lenghs[i, j] = Random.Range(0f, 1f / (leng / conf)) + ((1f / leng) * ((f2[i2] - f[i2]) - pr.y));
                        }
                    }
                    */
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


        ter.terrainData.size = new Vector3(leng1, leng, leng1);
        ter.terrainData.heightmapResolution = ter.terrainData.heightmapResolution;
        ter.terrainData.SetHeights(0, 0, lenghs);
    }
    public void regenerate()
    {

        float r = (float)width / (float)leng1;
        float r2 = (float)leng1 / (float)width;
        for (int i = 0; i < FindObjectsOfType<tearaformer>().Length; i++)
        {
            Vector2 v2i = new Vector2(FindObjectsOfType<tearaformer>()[i].transform.position.x,

        FindObjectsOfType<tearaformer>()[i].transform.position.z);

            float f2s = FindObjectsOfType<tearaformer>()[i].transform.position.y;
            fs.Add(f2s);
            float f2n = FindObjectsOfType<tearaformer>()[i].value;
            fn.Add(f2n);
            vectorsis.Add(v2i);
        }

        Vector2[] v2is = vectorsis.ToArray();
        float[] f = fn.ToArray();
        float[] f2 = fs.ToArray();
        Vector3 pr = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        

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
        }


        ter.terrainData.size = new Vector3(leng1, leng, leng1);
        ter.terrainData.heightmapResolution = ter.terrainData.heightmapResolution;
        ter.terrainData.SetHeights(0, 0, lenghs);
    }
}
