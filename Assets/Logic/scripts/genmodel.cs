using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class custommedelsave
{
    public string[] name;
    public Vector3[] v3;
}


public class genmodel : MonoBehaviour
{
   public MeshFilter mf;
    public Vector3[] verti;
    public int[] tria;
    public string s;
    // Start is called before the first frame update
    void Start()
    {
       mf.mesh = generate();
        GetComponent<MeshCollider>().sharedMesh = mf.mesh;
        GetComponent<MeshRenderer>().material = Resources.Load<Material>("mats/ost");
    }

    private Mesh generate()
    {
        ObjParser.Obj newobj = new ObjParser.Obj();
        newobj.LoadObj("res/"+s+".obj");
        var mesh = new Mesh();
        mesh.name = "cube";
        Vector3[] vertices = new Vector3[newobj.VertexList.Count];
        List<Vector2> uv = new List<Vector2>();
        List<int> triangles = new List<int>();
        for (int i = 0; i < newobj.VertexList.Count; i++)
        {
            vertices[i] = new Vector3((float)newobj.VertexList[i].X, (float)newobj.VertexList[i].Y, (float)newobj.VertexList[i].Z);

           


        }
        

        for (int f = 0; f < newobj.FaceList.Count; f++)
        {

            for (int i = 0; i < newobj.FaceList[f].VertexIndexList.Length; i++)
            {



                triangles.Add(newobj.FaceList[f].VertexIndexList[(i)] - 1);




            }
        }
        for (int f = 0; f < newobj.VertexList.Count; f++)
        {


                    uv.Add(new Vector2((float)newobj.TextureList[f].X, (float)newobj.TextureList[f].Y));
                    
               


        }


        tria = triangles.ToArray();
            verti = vertices;
        mesh.SetVertices(vertices);

        mesh.uv = uv.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals(UnityEngine.Rendering.MeshUpdateFlags.Default);
        return mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
