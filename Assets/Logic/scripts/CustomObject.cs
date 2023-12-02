using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public enum NDemention
{
    _3D,_4D,_5D
}

public class CustomObjectData
{
    public string NameModel;
    public Color _Color;
    public Vector3 scale;
    public NDemention nDemention;

}

public class CustomObject : MonoBehaviour
{
   public MeshFilter mf;
    public Vector3[] verti;
    public int[] tria;
    public Vector2 WHPos;
    public Vector2[] uvs;
    public string s;
    public bool saved;
    CustomObjectData Model = new CustomObjectData();
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
        GetComponent<MeshRenderer>().material = Resources.Load<Material>("Default");
        GetComponent<MeshRenderer>().material.color = Model._Color;
        name = s+"(Clone)";
    }
    private Mesh generate()
    {
        ObjParser.Obj newobj = new ObjParser.Obj();
        Directory.CreateDirectory("res/UserWorckspace/Items");
        
      
        if (!File.Exists("res/UserWorckspace/Items/" + s + ".txt"))
        {
            Model.nDemention = NDemention._3D;
            Model.scale = Vector3.one;
            Model._Color = Color.red;
            Model.NameModel = "cube";
            File.WriteAllText("res/UserWorckspace/Items/" + s + ".txt",JsonUtility.ToJson(Model));
        }
        if (File.Exists("res/UserWorckspace/Items/" + s + ".txt"))
        {
            Model = JsonUtility.FromJson<CustomObjectData>(File.ReadAllText("res/UserWorckspace/Items/" + s + ".txt"));
        }
        if (Model.nDemention == NDemention._5D)
        {
            gameObject.AddComponent<MultyObject>().shape = Shape.cube5D;
            mover m = mover.main();
            if (!saved)
            {
                GetComponent<MultyObject>().startPosition = new Vector6(transform.position.x, transform.position.y, transform.position.z, m.W_position, m.H_position, 0);
                GetComponent<MultyObject>().startScale = new Vector6(Model.scale.x, Model.scale.y, Model.scale.z, 1, 1, 0);
                GetComponent<MultyObject>().scale3D = Model.scale;
              GetComponent<MultyObject>().W_Position = m.W_position;
                GetComponent<MultyObject>().H_Position = m.H_position;
            }
            else
            {
                GetComponent<MultyObject>().startPosition = new Vector6(transform.position.x, transform.position.y, transform.position.z, WHPos.x, WHPos.y, 0);
                GetComponent<MultyObject>().startScale = new Vector6(Model.scale.x, Model.scale.y, Model.scale.z, 1, 1, 0);
                GetComponent<MultyObject>().scale3D = Model.scale;
                GetComponent<MultyObject>().W_Position = WHPos.x;
                GetComponent<MultyObject>().H_Position = WHPos.y;
            }
        }
        if (Model.nDemention == NDemention._4D)
        {
            gameObject.AddComponent<MultyObject>().shape = Shape.cube5D;
            mover m = mover.main();
            GetComponent<MultyObject>().H_Scale = 500000;
            if (!saved)
            {
                GetComponent<MultyObject>().startPosition = new Vector6(transform.position.x, transform.position.y, transform.position.z, m.W_position, m.H_position, 0);
                GetComponent<MultyObject>().startScale = new Vector6(Model.scale.x, Model.scale.y, Model.scale.z, 1, 500000, 0);
                GetComponent<MultyObject>().W_Position = m.W_position;
            }
            else
            {

                GetComponent<MultyObject>().startPosition = new Vector6(transform.position.x, transform.position.y, transform.position.z, WHPos.x, WHPos.y, 0);
                GetComponent<MultyObject>().startScale = new Vector6(Model.scale.x, Model.scale.y, Model.scale.z, 1, 500000, 0);
                GetComponent<MultyObject>().W_Position = WHPos.x;
            }
        }
        newobj.LoadObj("res/" + Model.NameModel + ".obj");
        var mesh = new Mesh();
        mesh.name = Model.NameModel;
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
