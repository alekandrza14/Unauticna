using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class custommedelsave
{
    public string[] name;
    public Vector3[] v3;
    public Vector3[] scale;
}


public class genmodel : CustomSaveObject
{
   public MeshFilter mf;
    public Vector3[] verti;
    public int[] tria;
    public Vector2[] uvs;
    public string s;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindFirstObjectByType<PlanetGravity>() != null)
        {
            Transform body;
            body = transform;
            Vector3 gravityUp = (body.position - Vector3.zero).normalized;
            Vector3 bodyup = body.up;
            Quaternion targetrotation = Quaternion.FromToRotation(bodyup, gravityUp) * body.rotation;
            body.rotation = Quaternion.Slerp(body.rotation, targetrotation, 5000000 * Time.deltaTime);
        }
            mf.mesh = generate();
        GetComponent<MeshCollider>().sharedMesh = mf.mesh;
        GetComponent<MeshRenderer>().material = Resources.Load<Material>("mats/ost");
    }
    private Mesh generate()
    {
        ObjParser.Obj newobj = new ObjParser.Obj();
        newobj.LoadObj("res/" + s + ".obj");
        var mesh = new Mesh();
        mesh.name = "cube";
        Vector3[] vertices = new Vector3[newobj.VertexList.Count];
        Vector2[] uv = new Vector2[newobj.VertexList.Count]; // Создаем массив UV-координат такого же размера, как и вершины
        List<int> triangles = new List<int>();

        for (int i = 0; i < newobj.VertexList.Count; i++)
        {
            vertices[i] = new Vector3((float)newobj.VertexList[i].X, (float)newobj.VertexList[i].Y, (float)newobj.VertexList[i].Z);
        }

        for (int f = 0; f < newobj.FaceList.Count; f++)
        {
            for (int i = 0; i < newobj.FaceList[f].VertexIndexList.Length; i++)
            {
                int vertexIndex = newobj.FaceList[f].VertexIndexList[i] - 1;
                triangles.Add(vertexIndex);
            }
        }

        
        for (int i = 0; i < newobj.VertexList.Count; i++)
        {
            uv[i] = (new Vector2((float)newobj.VertexList[i].X-(float)newobj.VertexList[i].Y, (float)newobj.VertexList[i].Z - (float)newobj.VertexList[i].Y));
        }
        mesh.vertices = vertices;
        mesh.triangles = triangles.ToArray();
        mesh.uv = uv;
        mesh.RecalculateNormals(UnityEngine.Rendering.MeshUpdateFlags.Default);
        return mesh;
    }
   
}
