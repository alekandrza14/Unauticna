using MoonSharp.Interpreter;
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
    leftmouse, E, Q, leftshift, notrequired
}
public enum CustomObjectType
{
    Object,PlayerScin
}

public class CustomObjectData
{
    public string NameModel;
    public string[] Models = new string[] { };
    public Color _Color;
    public Color[] m_Colors = new Color[] { };
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
    public string AppOpen;
    public string LuaBuilding;
    public string ConvertTo;
    public string LoadingMaterial;
    public string[] LoadingMaterials;
    public int RegenerateHp;
    public double Recycler;
    public double Redecycler;
    public double InfinityRecycler;
    public float speed = 1;
    public double ItemPrice = 157d;
    public Vector3 playerRotate;
    public Vector3 playerMove;
    public string ItemDangerLiberty = "";
    public string ItemDangerLiberty2 = "";
    public string ItemDangerLiberty3 = "";
    public string ItemDangerLiberty4 = "";
    public string ItemDangerLiberty5 = "";
    public string ItemDangerLiberty6 = "";
    public string ItemDangerLiberty7 = "";
    public string ItemDangerLiberty8 = "";
    public string ItemDangerLiberty9 = "";
    public Vector3[] VM_Pos = new Vector3[] { };
    public Vector3[] VM_Scale = new Vector3[] { };
    public string[] VoxelModels = new string[] { };
    public Vector3[] LeftLeg = new Vector3[] { };
    public Vector3[] RightLeg = new Vector3[] { };
    public Vector3[] LeftPovid = new[]
    {new Vector3(0,0,0),
    new Vector3(0,0,0),
    new Vector3(0,0.5f,0.5f),
    new Vector3(0,0.5f,0.5f)};
    public Vector3[] RightPovid = new[]
    {
    new Vector3(0,0.5f,0.5f),
    new Vector3(0,0.5f,0.5f),
    new Vector3(0,0,0),
    new Vector3(0,0,0)
    };
    public Vector3[] TelevizorPos = new Vector3[0];
    public Vector3[] TelevizorScale = new Vector3[1];
    public Quaternion[] TelevizorRot = new Quaternion[1];
    public Vector2 playerWHMove;
    public StandartKey standartKey;
    public bool ClearEffect,FreezeEffect,AnigilateItem,Dublicate,Meat,RunToPlayer,Transport,NoCollect,car,social,home,PlayerPosPrivzka, PlayerPosXZPrivzka;
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
    public bool Imsaveble;
    public LayerMask Mashime;
    public CustomObjectData Model = new CustomObjectData();
    // Start is called before the first frame update
    void Start()
    {
        
        if (VarSave.GetString("Scin") != "" && Imsaveble) s = VarSave.GetString("Scin");
        if (GameObject.FindFirstObjectByType<PlanetGravity>() != null)
        {
            Transform body;
            body = transform;
            Vector3 gravityUp = (body.position - Vector3.zero).normalized;
            Vector3 bodyup = body.up;
            Quaternion targetrotation = Quaternion.FromToRotation(bodyup, gravityUp) * body.rotation;
            body.rotation = Quaternion.Slerp(body.rotation, targetrotation, 5000000 * Time.deltaTime);
        }
        rcs();
    }
    public void resetCurrentSettings()
    {
        
        mf.mesh = generate();
        for(int i = 0; i < Model.Models.Length; i++)
        {
            Mesh newMesh = generateAdd(i);
            GameObject obj = new GameObject("dopmodels");
            obj.transform.SetParent(transform.GetChild(0));
            obj.transform.position = transform.position;
            obj.transform.localScale = transform.localScale;
            obj.transform.rotation = transform.rotation;
            obj.AddComponent<MeshFilter>().sharedMesh = newMesh;
            obj.AddComponent<MeshCollider>().sharedMesh = newMesh;
            obj.GetComponent<MeshCollider>().cookingOptions = MeshColliderCookingOptions.None;
            if (obj.GetComponent<MeshRenderer>()) if(Model.LoadingMaterials!=null)  if (Model.LoadingMaterials.Length > 0) 
            {
                Material newMaterial2 = Resources.Load<Material>("CO_MainMaterials/" + Model.LoadingMaterials[i]);
                obj.GetComponent<MeshRenderer>().material = newMaterial2;
            }
            obj.AddComponent<MeshRenderer>().material.color = Model.m_Colors[i];
        }
        for (int i = 0; i < Model.VoxelModels.Length; i++)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>("CO_VoxelModel"),transform);
            obj.transform.position = transform.position + Model.VM_Pos[i];
            obj.transform.localScale = Model.VM_Scale[i];
            obj.GetComponent<Yourjuise>().CO_VoxelModel = Model.VoxelModels[i];
        }
        GetComponent<MeshCollider>().sharedMesh = mf.mesh;
        GetComponent<MeshCollider>().cookingOptions = MeshColliderCookingOptions.None;
        transform.localScale = Model.scale;
        Material newMaterial = Resources.Load<Material>("CO_MainMaterials/" + Model.LoadingMaterial);
        if (!newMaterial) 
        {
            GetComponent<MeshRenderer>().material = Resources.Load<Material>("Default");
        }
        else
        {
            GetComponent<MeshRenderer>().material = newMaterial;
        }
        GetComponent<MeshRenderer>().material.color = Model._Color;
        name = s + "(Clone)";
    }
    public void rcs()
    {
        resetCurrentSettings();
    }
    private Mesh generateAdd(int model)
    {
        ObjParser.Obj newobj = new ObjParser.Obj();


       
        newobj.LoadObj("res/" + Model.Models[model] + ".obj");
        var mesh = new Mesh();
        mesh.name = Model.Models[model];
        Vector3[] vertices = new Vector3[newobj.VertexList.Count];
        Vector2[] uv = new Vector2[newobj.VertexList.Count]; // ������� ������ UV-��������� ������ �� �������, ��� � �������
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
            if (!GetComponent<MultyObject>()) { gameObject.AddComponent<MultyObject>().shape = Shape.cube5D; }
            else
            {
                gameObject.GetComponent<MultyObject>().shape = Shape.cube5D;
            }
            mover m = mover.main();
            if (!saved)
            {
                // GetComponent<MultyObject>().startPosition = new Vector6(transform.position.x, transform.position.y, transform.position.z, m.W_position, m.H_position, 0);
                GetComponent<MultyObject>().saved = true;
                 GetComponent<MultyObject>().startScale = new Vector6(Model.scale.x, Model.scale.y, Model.scale.z, 1, 1, 0);
                GetComponent<MultyObject>().scale3D = Model.scale;
               GetComponent<MultyObject>().W_Position = m.W_position;
                GetComponent<MultyObject>().H_Position = m.H_position;
            }
            else
            {
                //  GetComponent<MultyObject>().startPosition = new Vector6(transform.position.x, transform.position.y, transform.position.z, WHPos.x, WHPos.y, 0);
                GetComponent<MultyObject>().saved = true;
                GetComponent<MultyObject>().startScale = new Vector6(Model.scale.x, Model.scale.y, Model.scale.z, 1, 1, 0);
                GetComponent<MultyObject>().scale3D = Model.scale;
                GetComponent<MultyObject>().W_Position = WHPos.x;
                GetComponent<MultyObject>().H_Position = WHPos.y;
            }
        }
        if (Model.nDemention == NDemention._ND)
        {
            if (!GetComponent<MultyObject>()) { gameObject.AddComponent<MultyObject>().shape = Shape.cubeND; } else
            {
                gameObject.GetComponent<MultyObject>().shape = Shape.cubeND;
            }
            mover m = mover.main();
            if (!saved)
            {
                //  GetComponent<MultyObject>().startPosition = new Vector6(transform.position.x, transform.position.y, transform.position.z, m.W_position, m.H_position, 0);
                GetComponent<MultyObject>().saved = true;
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
                //   GetComponent<MultyObject>().startPosition = new Vector6(transform.position.x, transform.position.y, transform.position.z, WHPos.x, WHPos.y, 0);
                GetComponent<MultyObject>().saved = true;
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
        if (Model.Meat)
        {
            if (!GetComponent<����>()) gameObject.AddComponent<����>();
        }
        if (Model.PlayerPosPrivzka)
        {
            if (!GetComponent<NoscaleParent>()) gameObject.AddComponent<NoscaleParent>().settings = NoscaleParentSettings.PlayerPos;
        }
        if (Model.PlayerPosXZPrivzka)
        {
            if (!GetComponent<NoscaleParent>()) gameObject.AddComponent<NoscaleParent>().settings = NoscaleParentSettings.palyerXZ;
        }
        if (Model.RunToPlayer)
        {
            if (!GetComponent<RunToPlayer>())
            {
                gameObject.AddComponent<RunToPlayer>();
                GetComponent<RunToPlayer>().speed = Model.speed;
            }
          
        }
       
        if (Model.NoCollect)
        {
            gameObject.layer = 3;
        }

        if (Model.social)
        {
            gameObject.AddComponent<SocialObject>();
        }
        for (int i = 0;i< Model.TelevizorPos.LongLength;i++)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>("WindowSocialismAd"), transform.position+ Model.TelevizorPos[i], Model.TelevizorRot[i]);
            obj.transform.localScale = Model.TelevizorScale[i];
            Instantiate(Resources.Load<GameObject>("AdSocialism"), transform);
        }

        foreach (Vector3 v3 in Model.LeftLeg)
        {
            Vector3 x = transform.right;
            Vector3 y = transform.up;
            Vector3 z = transform.forward;
            Vector3 xyz = (x * v3.x) + (y * v3.y) + (z * v3.z);
            GameObject obj = Instantiate(Resources.Load<GameObject>("CO_Parts/Left leg"), transform);
            obj.transform.position = xyz + transform.position;
            Nerv nerv = obj.GetComponent<Nerv>();
            nerv.Leg.Shag = Model.LeftPovid;
            nerv.Brain = gameObject;
        } 
        
        foreach (Vector3 v3 in Model.RightLeg)
        {
            Vector3 x = transform.right;
            Vector3 y = transform.up;
            Vector3 z = transform.forward;
            Vector3 xyz = (x * v3.x) + (y * v3.y) + (z * v3.z);
            GameObject obj = Instantiate(Resources.Load<GameObject>("CO_Parts/Right leg"), transform);
            obj.transform.position = xyz + transform.position;
            Nerv nerv = obj.GetComponent<Nerv>();
            nerv.Leg.Shag = Model.RightPovid;
            nerv.Brain = gameObject;
        }
        if (Model.home)
        {
            Instantiate(Resources.Load<GameObject>("HomeTag"), gameObject.transform);
        }
        if (Model.Transport)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>("CustomTransport"), transform.position, Quaternion.identity);
            obj.GetComponent<CustomTransport>().item = transform;
            obj.GetComponent<CustomTransport>().TransportNmae.text = s;
            if (GetComponent<BoxCollider>())
            {
                GetComponent<BoxCollider>().includeLayers = Mashime;
                GetComponent<BoxCollider>().excludeLayers = Mashime;
            }
            if (GetComponent<MeshCollider>())
            {
                GetComponent<MeshCollider> ().includeLayers = Mashime;
                GetComponent<MeshCollider> ().excludeLayers = Mashime;
            }
        }
        if (Model.car)
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>("CustomCar"), transform.position, Quaternion.identity);
            obj.GetComponent<CustomTransport>().item = transform;
            obj.GetComponent<CustomTransport>().TransportNmae.text = s; 
            if (GetComponent<BoxCollider>())
            {
                GetComponent<BoxCollider>().includeLayers = Mashime;
                GetComponent<BoxCollider>().excludeLayers = Mashime;
            }
            if (GetComponent<MeshCollider>())
            {
                GetComponent<MeshCollider>().includeLayers = Mashime;
                GetComponent<MeshCollider>().excludeLayers = Mashime;
            }
        }
        if (Model.nDemention == NDemention._4D)
        {
            if (!GetComponent<MultyObject>()) { gameObject.AddComponent<MultyObject>().shape = Shape.cube5D; }
            else
            {
                gameObject.GetComponent<MultyObject>().shape = Shape.cube5D;
            }
            mover m = mover.main();
            GetComponent<MultyObject>().H_Scale = 500000;
            if (!saved)
            {
                //  GetComponent<MultyObject>().startPosition = new Vector6(transform.position.x, transform.position.y, transform.position.z, m.W_position, m.H_position, 0);
                GetComponent<MultyObject>().saved = true;
                GetComponent<MultyObject>().startScale = new Vector6(Model.scale.x, Model.scale.y, Model.scale.z, 1, 500000, 0);
               // GetComponent<MultyObject>().W_Position = m.W_position;
            }
            else
            {

                //  GetComponent<MultyObject>().startPosition = new Vector6(transform.position.x, transform.position.y, transform.position.z, WHPos.x, WHPos.y, 0);

                GetComponent<MultyObject>().saved = true;
                GetComponent<MultyObject>().startScale = new Vector6(Model.scale.x, Model.scale.y, Model.scale.z, 1, 500000, 0);
                GetComponent<MultyObject>().W_Position = WHPos.x;
            }
        }
        newobj.LoadObj("res/" + Model.NameModel + ".obj");
        var mesh = new Mesh();
        mesh.name = Model.NameModel;
        Vector3[] vertices = new Vector3[newobj.VertexList.Count];
        Vector2[] uv = new Vector2[newobj.VertexList.Count]; // ������� ������ UV-��������� ������ �� �������, ��� � �������
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
    List<float> v3 = new List<float>();
    public List<Vector3> BuildPosition(List<float> vec)
    {
        List<Vector3> vec3 = new List<Vector3>();
        for (int i = 0; i < vec.Count; i += 3)
        {

            vec3.Add(new(vec[i], vec[i + 1], vec[i + 2]));


        }
        return vec3;
    }
    public List<Vector3> Pos = new List<Vector3>();
    public List<string> data = new List<string>();
    int patrn = 0;
    public void LuaLogic(string loadedCode)
    {
        v3 = new();
        data = new();
        Pos = new();
        //   string scriptCode = @"    
        //	-- defines a Jump function
        //	function Jump (time)
        //		if (time>= 1) then
        //			return 1
        //       else
        //           return 0
        //		end
        //	end";
        UserData.RegisterType<Vector3>();
        UserData.RegisterType<List<float>>();
        UserData.RegisterType<List<string>>();
        Script script = new Script();
        script.Globals["vec3"] = v3;
        script.Globals["ditem"] = data;
        script.DoString(loadedCode);


        DynValue luaFactFunction = script.Globals.Get("Build");

        DynValue res = script.Call(luaFactFunction, new object[]
        {
            ((double)patrn)
        }
        );
        DynValue luaFactFunction2 = script.Globals.Get("Item");

        DynValue res2 = script.Call(luaFactFunction2, new object[]
        {
            ((double)patrn)
        }
        );



        if (res.UserData.Object != null)
        {
            v3 = (List<float>)res.UserData.Object;
        }
        Pos = BuildPosition(v3);
        if (res2.UserData.Object != null)
        {
            data = (List<string>)res2.UserData.Object;
        }
        patrn++;

        for (int i = 0; i < Pos.Count; i++)
        {
            Instantiate(Resources.Load<GameObject>("items/" + data[i]), new Vector3(Pos[i].x, Pos[i].y, Pos[i].z) + transform.position, Quaternion.identity);
        }


    }

    public void OnInteractive()
    {
        if (File.Exists(Model.LuaBuilding))
        {
            LuaLogic(File.ReadAllText(Model.LuaBuilding));
        }
        if (!string.IsNullOrEmpty(Model.ConvertTo))
        {
            if (File.Exists("res/UserWorckspace/Items/" + Model.ConvertTo + ".txt"))
            {
                GameObject obj = Instantiate(Resources.Load<GameObject>("CustomObject"), transform.position, Quaternion.identity);
                obj.GetComponent<CustomObject>().s = Model.ConvertTo;
                gameObject.AddComponent<DELETE>();
            }
        }
    }
}
