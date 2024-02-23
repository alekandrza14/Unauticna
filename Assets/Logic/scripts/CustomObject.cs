using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;

public enum NDemention
{
    _3D, _4D, _5D, _ND
}
public enum Functional
{
    none, spawner, user, mgickStick, steyk, trash
}
public enum StandartKey
{
    leftmouse,E,Q,leftshift,notrequired
}

public class CustomObjectData
{
    public string NameModel;
    public Color _Color;
    public Vector3 scale;
    public NDemention nDemention;
    public Functional functional;
    public List<useeffect> effect_no_use = new List<useeffect>()
    {
        new useeffect("",0)
    };
  //  public float[] VectorN = new float[10];
    public float[] ScaleN = new float[1] { 1};
    public string itemSpawn;
    public string CoSpawn;
    public string ObjSpawn;
    public string EventSpawn;
    public int RegenerateHp;
    public double Recycler;
    public double Redecycler;
    public double InfinityRecycler;
    public Vector3 playerRotate;
    public Vector3 playerMove;
    public Vector2 playerWHMove;
    public StandartKey standartKey;
    public bool ClearEffect,FreezeEffect,AnigilateItem,Dublicate;
    public string DefultInfo = "Hi This is item has Used a Json file format";

}

public class CustomObject : CustomSaveObject
{
    public MeshFilter mf;
    public Vector3[] verti;
    public int[] tria;
    public Vector2 WHPos;
    public Vector2[] uvs;
    public string s;
    public bool saved;
    public CustomObjectData Model = new CustomObjectData();
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
        transform.localScale = Model.scale;
        GetComponent<MeshRenderer>().material = Resources.Load<Material>("Default");
        GetComponent<MeshRenderer>().material.color = Model._Color;
        name = s + "(Clone)";
    }
    public void resetCurrentSettings()
    {
        mf.mesh = generate();
        GetComponent<MeshCollider>().sharedMesh = mf.mesh;
        transform.localScale = Model.scale;
        GetComponent<MeshRenderer>().material = Resources.Load<Material>("Default");
        GetComponent<MeshRenderer>().material.color = Model._Color;
        name = s + "(Clone)";
    }
    public void rcs()
    {
        resetCurrentSettings();
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
            File.WriteAllText("res/UserWorckspace/Items/" + s + ".txt", JsonUtility.ToJson(Model));
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
        if (Model.nDemention == NDemention._ND)
        {
            gameObject.AddComponent<MultyObject>().shape = Shape.cubeND;
            mover m = mover.main();
            if (!saved)
            {
                GetComponent<MultyObject>().startPosition = new Vector6(transform.position.x, transform.position.y, transform.position.z, m.W_position, m.H_position, 0);
                GetComponent<MultyObject>().startScale = new Vector6(Model.scale.x, Model.scale.y, Model.scale.z, 1, 1, 0);
                GetComponent<MultyObject>().scale3D = Model.scale;
                GetComponent<MultyObject>().W_Position = m.W_position;
                GetComponent<MultyObject>().H_Position = m.H_position;

                MultyObject mo = GetComponent<MultyObject>();
                mo.N_Positions = new float[m.N_position.Count];
                mo.N_Scales = new float[m.N_position.Count];
                for (int i = 0; i < m.N_position.Count; i++)
                {
                    mo.N_Positions[i] = m.N_position[i];
                    if (Model.ScaleN.Length - 1 > i) mo.N_Scales[i] = Model.ScaleN[i]; else { mo.N_Scales[i] = 1; }

                }

            }
            else
            {
                GetComponent<MultyObject>().startPosition = new Vector6(transform.position.x, transform.position.y, transform.position.z, WHPos.x, WHPos.y, 0);
                GetComponent<MultyObject>().startScale = new Vector6(Model.scale.x, Model.scale.y, Model.scale.z, 1, 1, 0);
                GetComponent<MultyObject>().scale3D = Model.scale;
                GetComponent<MultyObject>().W_Position = WHPos.x;
                GetComponent<MultyObject>().H_Position = WHPos.y;
                MultyObject mo = GetComponent<MultyObject>();

                mo.N_Positions = new float[m.N_position.Count];
                mo.N_Scales = new float[m.N_position.Count];
                for (int i = 0; i < m.N_position.Count; i++)
                {
                    mo.N_Positions[i] = m.N_position[i];
                    if (Model.ScaleN.Length - 1 > i) mo.N_Scales[i] = Model.ScaleN[i]; else { mo.N_Scales[i] = 1; }
                }
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
            uv[i] = (new Vector2((float)newobj.VertexList[i].X - (float)newobj.VertexList[i].Y, (float)newobj.VertexList[i].Z - (float)newobj.VertexList[i].Y));
        }
        mesh.vertices = vertices;
        mesh.triangles = triangles.ToArray();
        mesh.uv = uv;
        mesh.RecalculateNormals(UnityEngine.Rendering.MeshUpdateFlags.Default);
        return mesh;
    }
}
