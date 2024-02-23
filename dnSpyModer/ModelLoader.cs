using ObjParser;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace dnSpyModer
{
    public class Model
    {
        public static GameObject Create(string name,Vector4 pos,Material m)
        {
            if (SceneManager.GetActiveScene().buildIndex == pos.w)
            {
                GameObject obj = new GameObject(name+UnityEngine.Random.Range(0,9999999));
                obj.transform.position = new Vector3(pos.x, pos.y, pos.z);
                obj.AddComponent<MeshFilter>();
                obj.AddComponent<MeshRenderer>();
                ModelLoader.mf = obj.GetComponent<MeshFilter>();
                ModelLoader.s = name;
                ModelLoader.g = obj;
                obj.AddComponent<MeshCollider>().sharedMesh = obj.GetComponent<MeshFilter>().sharedMesh;
                ModelLoader.Create(m);

                return obj;
            }
            return null;
        }
    }
    public class ModelLoader
    {
        public static MeshFilter mf;
        public Vector3[] verti;
        public int[] tria;
        public Vector2[] uvs;
        public static string s;
        public static GameObject g;

        // Start is called before the first frame update
        public static void Create(Material m)
        {
          
            mf.mesh = generate();
            g.GetComponent<MeshCollider>().sharedMesh = mf.mesh;
          if(!m) g. GetComponent<MeshRenderer>().material = Resources.Load<Material>("mats/ost"); 
            else{
               g. GetComponent<MeshRenderer>().material = m;
            }
        }
        public static Mesh generate()
        {
            Obj newobj = new Obj();
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
                uv[i] = (new Vector2((float)newobj.VertexList[i].X - (float)newobj.VertexList[i].Y, (float)newobj.VertexList[i].Z - (float)newobj.VertexList[i].Y));
            }
            mesh.vertices = vertices;
            mesh.triangles = triangles.ToArray();
            mesh.uv = uv;
            mesh.RecalculateNormals(UnityEngine.Rendering.MeshUpdateFlags.Default);
            return mesh;
        }
    }
}
