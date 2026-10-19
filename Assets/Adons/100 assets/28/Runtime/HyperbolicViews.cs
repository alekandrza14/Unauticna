using System.Collections.Generic;
using UnityEngine;

namespace Unauticna.HyperbolicSpace
{
    // No per-star MonoBehaviours. A small pool is managed by HyperbolicStarfield.
    internal sealed class SphereView
    {
        public StarKey Key;
        public StarDescriptor Star;
        public bool Bound, Wanted;
        public readonly GameObject Root;
        private readonly MeshRenderer shell;
        private readonly MaterialPropertyBlock properties=new MaterialPropertyBlock();
        private readonly HyperbolicModelPool pool;
        private HyperbolicModelPool.Lease model;
        private static readonly int ColorId=Shader.PropertyToID("_Color");

        public SphereView(Transform parent,Mesh sphere,Material glass,HyperbolicModelPool pool)
        {
            this.pool=pool;
            Root=new GameObject("Star sphere (pooled)");
            Root.transform.SetParent(parent,false);
            var surface=new GameObject("Glass");
            surface.transform.SetParent(Root.transform,false);
            surface.AddComponent<MeshFilter>().sharedMesh=sphere;
            shell=surface.AddComponent<MeshRenderer>(); shell.sharedMaterial=glass;
            shell.shadowCastingMode=UnityEngine.Rendering.ShadowCastingMode.Off;
            shell.receiveShadows=false;
            Root.SetActive(false);
        }

        public bool TryBind(StarDescriptor star)
        {
            if(!pool.TryRent(star.Key,out var lease))return false;
            Star=star;Key=star.Key;Bound=true;model=lease;
            Transform t=lease.Root.transform;t.SetParent(Root.transform,false);
            t.localScale=Vector3.one*lease.Scale;
            ulong h=Key.Hash;
            t.localRotation=Quaternion.Euler((float)(CoordinateRandom.Unit(h,10)*360),
                (float)(CoordinateRandom.Unit(h,11)*360),(float)(CoordinateRandom.Unit(h,12)*360));
            t.localPosition=t.localRotation*lease.Offset;
            if(pool.IsFallback(lease))
            {
                properties.SetColor(ColorId,new Color(star.Red,star.Green,star.Blue,1));
                lease.Nodes[0].Renderer.SetPropertyBlock(properties);
            }
            properties.SetColor(ColorId,new Color(star.Red,star.Green,star.Blue,.35f));shell.SetPropertyBlock(properties);
            lease.Root.SetActive(true);Root.SetActive(true);return true;
        }

        public void Show(Vector3 origin,ProjectedStar star,float reveal)
        {
            Root.transform.position=origin+new Vector3(star.X,star.Y,star.Z);
            Root.transform.localScale=Vector3.one*(star.Radius*Mathf.SmoothStep(0,1,reveal));
            Root.SetActive(reveal>.001f);
        }
        public void Release() { pool.Return(model);model=null;Bound=false;Wanted=false;Root.SetActive(false); }
    }

    internal static class HyperbolicMeshes
    {
        public static Mesh Sphere()
        {
            const int rings=16,segments=24;
            var vertices=new Vector3[(rings+1)*(segments+1)];
            var normals=new Vector3[vertices.Length]; var uv=new global::UnityEngine.Vector2[vertices.Length];
            var indices=new List<int>();
            for(int y=0;y<=rings;y++)for(int x=0;x<=segments;x++)
            {
                float theta=Mathf.PI*y/rings,phi=2*Mathf.PI*x/segments;
                int i=y*(segments+1)+x;
                vertices[i]=new Vector3(Mathf.Sin(theta)*Mathf.Cos(phi),Mathf.Cos(theta),Mathf.Sin(theta)*Mathf.Sin(phi));
                normals[i]=vertices[i]; uv[i]=new global::UnityEngine.Vector2((float)x/segments,(float)y/rings);
                if(y<rings && x<segments)
                {
                    int a=i,b=i+1,c=i+segments+1,d=c+1;
                    indices.Add(a);indices.Add(b);indices.Add(c);indices.Add(b);indices.Add(d);indices.Add(c);
                }
            }
            var mesh=new Mesh { name="H3 shared sphere" };
            mesh.vertices=vertices;mesh.normals=normals;mesh.uv=uv;mesh.triangles=indices.ToArray();mesh.RecalculateBounds();
            return mesh;
        }

        public static Mesh[] Models()
        {
            var cube=Flat("Cube",new[] { new Vector3(-1,-1,-1),new Vector3(1,-1,-1),new Vector3(1,1,-1),new Vector3(-1,1,-1),
                new Vector3(-1,-1,1),new Vector3(1,-1,1),new Vector3(1,1,1),new Vector3(-1,1,1) },
                new[] {0,2,1,0,3,2,4,5,6,4,6,7,0,4,7,0,7,3,1,2,6,1,6,5,0,1,5,0,5,4,3,7,6,3,6,2});
            var octa=Flat("Crystal",new[] {new Vector3(0,1.6f,0),new Vector3(0,-1.6f,0),Vector3.right,Vector3.forward,Vector3.left,Vector3.back},
                new[] {0,3,2,0,4,3,0,5,4,0,2,5,1,2,3,1,3,4,1,4,5,1,5,2});
            var pyramid=Flat("Pyramid",new[] {new Vector3(-1,-.7f,-1),new Vector3(1,-.7f,-1),new Vector3(1,-.7f,1),new Vector3(-1,-.7f,1),new Vector3(0,1.3f,0)},
                new[] {0,1,4,1,2,4,2,3,4,3,0,4,0,3,2,0,2,1});
            return new[] {cube,octa,pyramid};
        }

        private static Mesh Flat(string name,Vector3[] source,int[] indices)
        {
            var vertices=new Vector3[indices.Length];var triangles=new int[indices.Length];
            for(int i=0;i<indices.Length;i++) { vertices[i]=source[indices[i]]; triangles[i]=i; }
            var mesh=new Mesh {name="H3 "+name};mesh.vertices=vertices;mesh.triangles=triangles;
            mesh.RecalculateNormals();mesh.RecalculateBounds();return mesh;
        }
    }
}
