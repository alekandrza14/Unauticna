using System;
using System.Collections.Generic;
using UnityEngine;
using Clock=System.Diagnostics.Stopwatch;

namespace Unauticna.HyperbolicSpace
{
    // Main-thread visual pool. No Instantiate/Destroy in star binding or release.
    // Preparing a prefab, resetting a lease and building it are all incremental.
    internal sealed class HyperbolicModelPool
    {
        internal sealed class Lease
        {
            public readonly GameObject Root;
            public readonly List<NodeInstance> Nodes=new List<NodeInstance>();
            public int Type=-1;
            public bool Free;
            public Vector3 Offset;
            public float Scale;
            public long LastUse;
            public Lease(GameObject root){Root=root;}
        }
        internal sealed class NodeInstance
        {
            public GameObject Object;
            public MeshFilter Filter;
            public MeshRenderer Renderer;
        }
        private struct NodeDescription
        {
            public int Parent;
            public Vector3 Position,Scale;
            public Quaternion Rotation;
            public Mesh Mesh;
            public Material[] Materials;
        }
        private sealed class Visit
        {
            public Transform Source;
            public int Parent;
            public Matrix4x4 Matrix;
            public bool IsRoot,Expanded;
            public int NodeIndex,ChildIndex;
        }
        private sealed class ModelType
        {
            public GameObject Source;
            public bool Fallback,Started,Ready,HasBounds;
            public Bounds Bounds;
            public int Meshes,Demand,Warm;
            public readonly List<NodeDescription> Nodes=new List<NodeDescription>();
            public readonly Stack<Visit> Visits=new Stack<Visit>();
            public Vector3 Offset;
            public float Scale;
        }
        private readonly Transform parking;
        private readonly ModelType[] types;
        private readonly List<Lease> leases;
        private readonly int prefabCount,maximum;
        private Lease building;
        private int buildType,resetIndex,resetLimit,buildIndex;
        private long tick;
        public int CreatedGameObjects {get;private set;}
        public int ReusedLeases {get;private set;}
        public int Count=>leases.Count;

        public HyperbolicModelPool(Transform parent,GameObject[] prefabs,Mesh[] fallback,Material material,int capacity,int prewarm)
        {
            maximum=Math.Max(1,capacity);leases=new List<Lease>(maximum);
            var holder=new GameObject("H3 model pool");holder.transform.SetParent(parent,false);holder.SetActive(false);
            parking=holder.transform;CreatedGameObjects++;
            prefabCount=prefabs==null?0:prefabs.Length;
            types=new ModelType[prefabCount+fallback.Length];
            for(int i=0;i<prefabCount;i++)types[i]=new ModelType {Source=prefabs[i]};
            for(int i=0;i<fallback.Length;i++)
            {
                var type=new ModelType {Fallback=true,Started=true,Ready=true,Meshes=1,HasBounds=true,Bounds=fallback[i].bounds};
                type.Nodes.Add(new NodeDescription {Parent=-1,Position=Vector3.zero,Rotation=Quaternion.identity,Scale=Vector3.one,
                    Mesh=fallback[i],Materials=new[]{material}});
                FinishBounds(type);types[prefabCount+i]=type;
            }
            // Bounded warm-up. Do not cycle through more types than the pool can hold.
            int remaining=maximum;
            int start=prefabCount==0?prefabCount:0,end=prefabCount==0?types.Length:prefabCount;
            for(int i=start;i<end&&remaining>0;i++)
            {types[i].Warm=Math.Min(Math.Max(0,prewarm),remaining);remaining-=types[i].Warm;}
        }
        public void BeginRequests(){foreach(var type in types)type.Demand=0;}
        private int Resolve(StarKey key)
        {
            int fallback=prefabCount+CoordinateRandom.ModelIndex(key,types.Length-prefabCount);
            if(prefabCount==0)return fallback;
            int index=CoordinateRandom.ModelIndex(key,prefabCount);
            var type=types[index];
            if(type.Source==null||(type.Ready&&type.Meshes==0))return fallback;
            return index;
        }
        public bool TryRent(StarKey key,out Lease lease)
        {
            int type=Resolve(key);
            foreach(var entry in leases)
                if(entry.Free&&entry.Type==type)
                {entry.Free=false;entry.LastUse=++tick;ReusedLeases++;lease=entry;return true;}
            types[type].Demand++;
            lease=null;return false;
        }
        public void Return(Lease lease)
        {
            if(lease==null||lease.Free)return;
            lease.Root.SetActive(false);lease.Root.transform.SetParent(parking,false);
            lease.Free=true;lease.LastUse=++tick;
        }
        public bool IsFallback(Lease lease)=>types[lease.Type].Fallback;
        private int FreeCount(int type)
        {int n=0;foreach(var entry in leases)if(entry.Free&&entry.Type==type)n++;return n;}
        private int TotalCount(int type)
        {int n=0;foreach(var entry in leases)if(entry.Type==type)n++;return n;}
        private int NextType()
        {
            // Visible requests take priority over optional warm-up.
            for(int i=0;i<types.Length;i++)if(types[i].Demand>FreeCount(i))return i;
            for(int i=0;i<types.Length;i++)if(types[i].Warm>TotalCount(i)&&(!types[i].Ready||types[i].Meshes>0))return i;
            return -1;
        }
        public bool Pump(int maximumSteps,float milliseconds)
        {
            long start=Clock.GetTimestamp();double seconds=Math.Max(.05f,milliseconds)/1000.0;
            bool changed=false;
            for(int step=0;step<Math.Max(1,maximumSteps);step++)
            {
                if(step>0&&(Clock.GetTimestamp()-start)/(double)Clock.Frequency>=seconds)break;
                if(building!=null)
                {
                    if(resetIndex<resetLimit)
                    {
                        var node=building.Nodes[resetIndex++];node.Object.SetActive(false);
                        node.Object.transform.SetParent(building.Root.transform,false);
                        continue;
                    }
                    ModelType type=types[buildType];
                    if(buildIndex<type.Nodes.Count)
                    {ConfigureNode(building,type.Nodes[buildIndex],buildIndex++);continue;}
                    building.Type=buildType;building.Offset=type.Offset;building.Scale=type.Scale;
                    building.Free=true;building.LastUse=++tick;building=null;changed=true;
                    continue;
                }
                int requested=NextType();if(requested<0)break;
                var requestedType=types[requested];
                if(!requestedType.Ready)
                {
                    PrepareOne(requestedType);
                    // Invalid/empty prefabs fall back on the next render request.
                    if(requestedType.Ready&&requestedType.Meshes==0)
                    {requestedType.Demand=0;requestedType.Warm=0;changed=true;}
                    continue;
                }
                if(leases.Count<maximum)
                {
                    var go=new GameObject("H3 pooled model");CreatedGameObjects++;
                    go.SetActive(false);go.transform.SetParent(parking,false);
                    building=new Lease(go);leases.Add(building);
                }
                else
                {
                    // Reconfigure an unused lease node by node; never destroy it on a miss.
                    foreach(var entry in leases)
                        if(entry.Free&&entry.Type!=requested&&
                            (building==null||entry.LastUse<building.LastUse))building=entry;
                    if(building==null)break;
                    // Optional warm-up must not evict another warm type or a visible request.
                    if(requestedType.Demand==0){building=null;requestedType.Warm=0;continue;}
                }
                building.Free=false;building.Type=-1;buildType=requested;resetIndex=0;resetLimit=building.Nodes.Count;buildIndex=0;
            }
            return changed;
        }
        private void ConfigureNode(Lease lease,NodeDescription description,int index)
        {
            NodeInstance node;
            if(index==lease.Nodes.Count)
            {
                var go=new GameObject("Mesh node");CreatedGameObjects++;
                node=new NodeInstance {Object=go,Filter=go.AddComponent<MeshFilter>(),Renderer=go.AddComponent<MeshRenderer>()};
                node.Renderer.shadowCastingMode=UnityEngine.Rendering.ShadowCastingMode.Off;node.Renderer.receiveShadows=false;
                lease.Nodes.Add(node);
            }
            else node=lease.Nodes[index];
            node.Object.transform.SetParent(description.Parent<0?lease.Root.transform:lease.Nodes[description.Parent].Object.transform,false);
            node.Object.transform.localPosition=description.Position;node.Object.transform.localRotation=description.Rotation;
            node.Object.transform.localScale=description.Scale;node.Filter.sharedMesh=description.Mesh;
            node.Renderer.sharedMaterials=description.Materials??Array.Empty<Material>();node.Renderer.enabled=description.Mesh!=null;
            node.Renderer.SetPropertyBlock(null);node.Object.SetActive(true);
        }
        private static void PrepareOne(ModelType type)
        {
            if(!type.Started)
            {
                type.Started=true;
                if(type.Source==null){type.Ready=true;return;}
                type.Visits.Push(new Visit {Source=type.Source.transform,Parent=-1,Matrix=Matrix4x4.identity,IsRoot=true});
            }
            if(type.Visits.Count==0){type.Ready=true;FinishBounds(type);return;}
            Visit visit=type.Visits.Peek();Transform source=visit.Source;
            if(source==null){type.Visits.Pop();return;}
            if(visit.Expanded)
            {
                if(visit.ChildIndex>=source.childCount){type.Visits.Pop();return;}
                Transform child=source.GetChild(visit.ChildIndex++);
                if(child.gameObject.activeSelf)type.Visits.Push(new Visit {Source=child,Parent=visit.NodeIndex,Matrix=visit.Matrix});
                return;
            }
            var d=new NodeDescription {Parent=visit.Parent,Position=visit.IsRoot?Vector3.zero:source.localPosition,
                Rotation=visit.IsRoot?Quaternion.identity:source.localRotation,Scale=source.localScale};
            Matrix4x4 matrix=visit.Matrix*Matrix4x4.TRS(d.Position,d.Rotation,d.Scale);
            var filter=source.GetComponent<MeshFilter>();var renderer=source.GetComponent<MeshRenderer>();
            if(filter!=null&&filter.sharedMesh!=null&&renderer!=null&&renderer.enabled)
            {
                d.Mesh=filter.sharedMesh;d.Materials=renderer.sharedMaterials;type.Meshes++;
                Bounds b=d.Mesh.bounds;
                for(int corner=0;corner<8;corner++)
                {
                    Vector3 point=matrix.MultiplyPoint3x4(b.center+Vector3.Scale(b.extents,new Vector3(
                        (corner&1)==0?-1:1,(corner&2)==0?-1:1,(corner&4)==0?-1:1)));
                    if(!type.HasBounds){type.Bounds=new Bounds(point,Vector3.zero);type.HasBounds=true;}
                    else type.Bounds.Encapsulate(point);
                }
            }
            visit.NodeIndex=type.Nodes.Count;type.Nodes.Add(d);
            visit.Matrix=matrix;visit.Expanded=true;
        }
        private static void FinishBounds(ModelType type)
        {type.Scale=.65f/Mathf.Max(.0001f,type.Bounds.extents.magnitude);type.Offset=-type.Bounds.center*type.Scale;}
    }
}
