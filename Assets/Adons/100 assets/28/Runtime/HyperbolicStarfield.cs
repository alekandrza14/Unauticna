using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FFS.Libraries.StaticEcs;
using UnityEngine;
using UnityEngine.Rendering;
using Unity.Profiling;

namespace Unauticna.HyperbolicSpace
{
    [DisallowMultipleComponent]
    public sealed class HyperbolicStarfield : MonoBehaviour
    {
        public HyperbolicCamera3D hyperbolicCamera;
        [Header("Generation (set before Play)")]
        [Range(.5f,3.2f)] public float visibleRadius=2.6f;
        [Range(0,1)] public float density=.8f;
        [Min(.01f)] public float sphereRadius=1.2f;
        [Range(64,8192)] public int maximumStars=2048;
        [Range(1,32)] public int maximumDetailedStars=12;
        [Range(1,60)] public int calculationsPerSecond=60;
        [Range(1,8)] public int workerThreads=4;
        [Header("Near stars")]
        [Min(.1f)] public float revealDistance=16f;
        [Range(1,4)] public int newModelsPerFrame=1;
        [Header("Shared model pool (set before Play)")]
        [Range(0,96)] public int extraPooledModels=12;
        [Range(0,4)] public int prewarmPerModel=1;
        [Range(1,64)] public int modelBuildStepsPerFrame=8;
        [Range(.1f,4f)] public float modelBuildMilliseconds=.75f;
        [Header("Object catalog cache")]
        public bool cacheObjectsToJson=true;
        [Range(1,32)] public int cachedCatalogsInMemory=8;
        [Range(1,128)] public int maximumJsonFiles=32;
        [Min(1)] public float jsonSaveInterval=5f;
        [Tooltip("Only static meshes/materials are copied. Scripts and colliders are not instantiated.")]
        public GameObject[] modelPrefabs=Array.Empty<GameObject>();
        [Header("Optional materials (use overrides for HDRP)")]
        public Material particleMaterial;
        public Material glassMaterial;
        public Material fallbackModelMaterial;

        public int VisibleStarCount { get; private set; }
        private static HyperbolicStarfield owner;
        private bool started,ready,worldCreated,systemsCreated,warnedCapacity;
        private StarGenerationSettings settings;
        private Task<StarFrame> job;
        private CancellationTokenSource cancellation;
        private StarFrame frame,pendingJson;
        private HyperbolicModelPool modelPool;
        private HyperbolicCatalogCache catalogCache;
        private Task jsonJob;
        private float nextJsonSave;
        public string ObjectCachePath=>catalogCache?.DirectoryPath;
        public int PooledModelCount=>modelPool==null?0:modelPool.Count;
        public int PoolCreatedGameObjects=>modelPool==null?0:modelPool.CreatedGameObjects;
        private MegaPoint lastRequestedPosition;
        private Vector3 lastRenderOrigin;
        private float lastRevealDistance,lastFov;
        private int lastPixelHeight;
        private bool renderDirty;
        private float nextCalculation;
        private GameObject generatedRoot;
        private ParticleSystem particles;
        private ParticleSystem.Particle[] particleBuffer;
        private Mesh sphere;
        private Mesh[] models;
        private SphereView[] views;
        private readonly List<Material> ownedMaterials=new List<Material>();
        private readonly Dictionary<StarKey,SphereView> byKey=new Dictionary<StarKey,SphereView>();
        private readonly List<NearStar> near=new List<NearStar>();
        private struct NearStar { public StarDescriptor Star; public ProjectedStar Projection; }
        private sealed class NearestFirst : IComparer<NearStar>
        {
            public int Compare(NearStar a,NearStar b)
            {
                int c=a.Projection.Distance.CompareTo(b.Projection.Distance);
                return c!=0?c:a.Star.Key.CompareTo(b.Star.Key);
            }
        }
        private static readonly NearestFirst NearComparer=new NearestFirst();
        private static readonly ProfilerMarker PoolBuildMarker=new ProfilerMarker("H3.ModelPool.Build");
        private static readonly ProfilerMarker VisualMarker=new ProfilerMarker("H3.Visuals.Apply");

        void Start() { started=true; Initialize(); }
        void OnEnable() { if(started)Initialize(); }

        private void Initialize()
        {
            if(ready)return;
            if(owner!=null && owner!=this)
            { Debug.LogError("Use one HyperbolicStarfield per scene.",this); enabled=false; return; }
            if(hyperbolicCamera==null)
            { Debug.LogError("Assign Hyperbolic Camera before enabling the starfield.",this); enabled=false; return; }
            owner=this;
            try
            {
                float radius=Mathf.Max(.1f,hyperbolicCamera.curvatureRadius);
                settings=new StarGenerationSettings {
                    CurvatureRadius=(decimal)radius,VisibleRadius=(decimal)Mathf.Clamp(visibleRadius,.5f,3.2f),Density=(decimal)Mathf.Clamp01(density),
                    SphereRadius=(decimal)Mathf.Clamp(sphereRadius,.01f,radius*.15f),Capacity=Mathf.Clamp(maximumStars,64,8192),
                    WorkerCount=Math.Max(1,Math.Min(workerThreads,Environment.ProcessorCount-1)) };
                settings.Validate();
                var pipeline=GraphicsSettings.currentRenderPipeline;
                bool hdrp=pipeline!=null && pipeline.GetType().Name.IndexOf("HDRender",StringComparison.OrdinalIgnoreCase)>=0;
                if(hdrp && (particleMaterial==null||glassMaterial==null||fallbackModelMaterial==null))
                    throw new InvalidOperationException("HDRP: assign compatible particle, transparent glass and fallback model materials. Bundled shaders target Built-in/URP.");
                Material starMat=MaterialOrDefault(particleMaterial,"Star");
                Material glassMat=MaterialOrDefault(glassMaterial,"Glass");
                Material modelMat=MaterialOrDefault(fallbackModelMaterial,"Model");
                generatedRoot=new GameObject("H3 generated visuals");
                // Keep a unit-scale world root: unrelated scene scales must not alter the projection.
                generatedRoot.transform.position=Vector3.zero;
                sphere=HyperbolicMeshes.Sphere(); models=HyperbolicMeshes.Models();
                views=new SphereView[Mathf.Clamp(maximumDetailedStars,1,32)];
                near.Capacity=views.Length+1;
                modelPool=new HyperbolicModelPool(generatedRoot.transform,modelPrefabs,models,modelMat,
                    views.Length+Mathf.Clamp(extraPooledModels,0,96),Mathf.Clamp(prewarmPerModel,0,4));
                for(int i=0;i<views.Length;i++)views[i]=new SphereView(generatedRoot.transform,sphere,glassMat,modelPool);
                catalogCache=new HyperbolicCatalogCache(System.IO.Path.Combine(Application.persistentDataPath,"Unauticna","H3CatalogCache_v4"),
                    Mathf.Clamp(cachedCatalogsInMemory,1,32),Mathf.Clamp(maximumJsonFiles,1,128),new HyperbolicCatalogJson());

                CreateParticles(starMat);
                SpaceWorld.Create();worldCreated=true;
                SpaceWorld.Types().Component<StarState>();
                SpaceWorld.Initialize();
                for(int i=0;i<settings.Capacity;i++)SpaceWorld.NewEntity<Default>().Set(new StarState { Slot=i });
                SpaceSystems.Create();systemsCreated=true;
                SpaceSystems.Add(new ApplyStarFrameSystem(),order:0);
                SpaceSystems.Initialize();
                cancellation=new CancellationTokenSource();
                frame=null;pendingJson=null;jsonJob=null;nextJsonSave=0;nextCalculation=0;warnedCapacity=false;renderDirty=true;ready=true;
            }
            catch(Exception e)
            {
                Debug.LogException(e,this); Cleanup(); enabled=false;
            }
        }


        // Click testing runs only on demand; pooled spheres need no Collider or extra MonoBehaviour.
        public bool TryPickPlanet(Ray ray,float maximumDistance,out StarDescriptor star)
        {
            star=default;
            if(!ready||views==null||maximumDistance<=0||ray.direction.sqrMagnitude<.000001f)return false;
            Vector3 direction=ray.direction.normalized;
            float nearest=maximumDistance;bool found=false;
            foreach(var view in views)
            {
                if(!view.Bound||!view.Root.activeInHierarchy)continue;
                Vector3 offset=ray.origin-view.Root.transform.position;
                float radius=Mathf.Abs(view.Root.transform.localScale.x);
                if(radius<=.00001f)continue;
                float b=Vector3.Dot(offset,direction),c=offset.sqrMagnitude-radius*radius;
                float discriminant=b*b-c;
                if(discriminant<0)continue;
                float distance=-b-Mathf.Sqrt(discriminant);
                if(distance<0)distance=-b+Mathf.Sqrt(discriminant);
                if(distance<0||distance>nearest)continue;
                nearest=distance;star=view.Star;found=true;
            }
            return found;
        }

        private Material MaterialOrDefault(Material supplied,string name)
        {
            if(supplied!=null)return supplied;
            Shader shader=Resources.Load<Shader>("UnauticnaHyperbolicSpace/Hyperbolic"+name);
            if(shader==null || !shader.isSupported)throw new InvalidOperationException("Missing/unsupported H3 "+name+" shader.");
            var material=new Material(shader) {name="H3 shared "+name};ownedMaterials.Add(material);return material;
        }

        private void CreateParticles(Material material)
        {
            var go=new GameObject("Distant stars (one particle system)");
            go.transform.SetParent(generatedRoot.transform,false);
            particles=go.AddComponent<ParticleSystem>();
            particles.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);
            var main=particles.main;main.playOnAwake=false;main.loop=false;main.maxParticles=settings.Capacity;
            main.simulationSpace=ParticleSystemSimulationSpace.World;main.simulationSpeed=0;
            main.startLifetime=10000;main.startSpeed=0;main.startSize=.1f;
            var emission=particles.emission;emission.enabled=false;
            var shape=particles.shape;shape.enabled=false;
            var renderer=particles.GetComponent<ParticleSystemRenderer>();
            renderer.sharedMaterial=material;renderer.renderMode=ParticleSystemRenderMode.Billboard;
            renderer.shadowCastingMode=ShadowCastingMode.Off;renderer.receiveShadows=false;
            renderer.maxParticleSize=.1f;
            float extent=(float)(settings.CurvatureRadius*(settings.VisibleRadius+.5m));
            renderer.localBounds=new Bounds(Vector3.zero,Vector3.one*(extent*2));
            particleBuffer=new ParticleSystem.Particle[settings.Capacity];
            particles.Play();
        }

        void LateUpdate()
        {
            if(!ready)return;
            if(hyperbolicCamera==null) { enabled=false; return; }
            if(job!=null && job.IsCompleted)
            {
                try
                {
                    StarFrame completed=job.GetAwaiter().GetResult();job=null;
                    if(frame==null||!ReferenceEquals(frame.Stars,completed.Stars))pendingJson=HyperbolicCatalogCache.Snapshot(completed);
                    frame=completed;
                    ApplyStarFrameSystem.Pending=frame;SpaceSystems.Update();SpaceWorld.Tick();renderDirty=true;
                    if(frame.CapacityLimited&&!warnedCapacity)
                    { warnedCapacity=true;Debug.LogWarning("H3 star limit reached: only nearest stars retained. Raise Maximum Stars or reduce Visible Radius.",this); }
                }
                catch(Exception e) { Debug.LogException(e,this);job=null;enabled=false;return; }
            }
            PollJsonCache();
            using(PoolBuildMarker.Auto())
                if(modelPool.Pump(Mathf.Clamp(modelBuildStepsPerFrame,1,64),Mathf.Clamp(modelBuildMilliseconds,.1f,4f)))renderDirty=true;
            Camera viewCamera=hyperbolicCamera.ViewCamera;
            if(frame!=null && (renderDirty || lastRenderOrigin!=hyperbolicCamera.transform.position ||
                lastRevealDistance!=revealDistance || (viewCamera!=null && (lastFov!=viewCamera.fieldOfView||lastPixelHeight!=viewCamera.pixelHeight))))
                using(VisualMarker.Auto())RenderFrame();
            MegaPoint position=hyperbolicCamera.Position;
            bool moved=frame==null||!position.Equals(lastRequestedPosition);
            if(job==null && moved && Time.unscaledTime>=nextCalculation && Time.timeScale>0)
            {
                nextCalculation=Time.unscaledTime+1f/Mathf.Clamp(calculationsPerSecond,1,60);
                MegaPoint camera=hyperbolicCamera.Position;
                lastRequestedPosition=camera;
                StarGenerationSettings snapshot=settings;
                StarFrame previous=frame;
                CancellationToken token=cancellation.Token;
                // ECS already owns a copy of the last projection. Rendering never reads this buffer.
                ProjectedStar[] reusable=previous?.Projection;
                HyperbolicCatalogCache cache=catalogCache;bool readDisk=cacheObjectsToJson;
                job=Task.Run(()=>
                {
                    StarFrame catalog=HyperbolicStars.CanReuse(camera,snapshot,previous)?previous:cache.Find(camera,snapshot,readDisk,token);
                    StarFrame result=HyperbolicStars.Build(camera,snapshot,catalog,token,reusable);
                    cache.Remember(result);return result;
                },token);
            }
        }

        private void RenderFrame()
        {
            renderDirty=false;
            Vector3 origin=hyperbolicCamera.transform.position;
            lastRenderOrigin=origin;lastRevealDistance=revealDistance;
            particles.transform.position=origin;
            float distance=Mathf.Max(.1f,revealDistance);
            near.Clear();modelPool.BeginRequests();
            foreach(var entity in SpaceWorld.Query<All<StarState>>().Entities())
            {
                ref readonly var s=ref entity.Read<StarState>();
                if(s.Active && s.Projection.Visibility>0 && s.Projection.Distance<distance*1.15f)
                {
                    var candidate=new NearStar {Star=s.Star,Projection=s.Projection};
                    int index=near.Count;
                    while(index>0&&NearComparer.Compare(candidate,near[index-1])<0)index--;
                    if(index<views.Length)
                    {
                        near.Insert(index,candidate);
                        if(near.Count>views.Length)near.RemoveAt(views.Length);
                    }
                }
            }
            int nearCount=Math.Min(near.Count,views.Length);
            foreach(var view in views)view.Wanted=false;
            for(int i=0;i<nearCount;i++)if(byKey.TryGetValue(near[i].Star.Key,out SphereView existing))existing.Wanted=true;
            foreach(var view in views)
            {
                if(view.Bound&&!view.Wanted) { byKey.Remove(view.Key);view.Release(); }
            }
            int spawned=0;
            for(int i=0;i<nearCount;i++)
            {
                NearStar s=near[i];
                if(!byKey.TryGetValue(s.Star.Key,out SphereView view))
                {
                    if(spawned>=Mathf.Max(1,newModelsPerFrame)) { renderDirty=true;continue; }
                    foreach(var candidate in views)if(!candidate.Bound) { view=candidate;break; }
                    if(view==null)continue;
                    if(!view.TryBind(s.Star))continue;
                    view.Wanted=true;
                    byKey.Add(s.Star.Key,view);spawned++;
                }
                view.Show(origin,s.Projection,Reveal(s.Projection.Distance,distance));
            }
            Camera cam=hyperbolicCamera.ViewCamera;
            if(cam!=null) { lastFov=cam.fieldOfView;lastPixelHeight=cam.pixelHeight; }
            float pixelsToWorld=cam!=null ? 2*Mathf.Tan(cam.fieldOfView*Mathf.Deg2Rad*.5f)/Mathf.Max(1,cam.pixelHeight) : .001f;
            int count=0;
            foreach(var entity in SpaceWorld.Query<All<StarState>>().Entities())
            {
                ref readonly var state=ref entity.Read<StarState>();
                if(!state.Active)continue;
                ProjectedStar p=state.Projection;ref readonly var s=ref state.Star;
                float reveal=byKey.ContainsKey(s.Key)?Reveal(p.Distance,distance):0;
                float alpha=p.Visibility*(1-reveal);
                if(alpha<=.001f)continue;
                particleBuffer[count++]=new ParticleSystem.Particle {
                    position=origin+new Vector3(p.X,p.Y,p.Z),
                    startSize=Mathf.Max(p.Radius*.12f,p.Distance*pixelsToWorld*1.7f),
                    startColor=new Color(s.Red,s.Green,s.Blue,alpha),startLifetime=10000,remainingLifetime=10000 };
            }
            VisibleStarCount=frame.Stars.Length;
            particles.SetParticles(particleBuffer,count);
        }
        private void PollJsonCache()
        {
            string warning=catalogCache.TakeWarning();if(warning!=null)Debug.LogWarning(warning,this);
            if(jsonJob!=null&&jsonJob.IsCompleted)
            {
                try{jsonJob.GetAwaiter().GetResult();}
                catch(Exception e){Debug.LogWarning("H3 JSON cache write failed: "+e.Message,this);}
                jsonJob=null;
            }
            if(cacheObjectsToJson&&jsonJob==null&&pendingJson!=null&&Time.unscaledTime>=nextJsonSave)
            {
                var snapshot=pendingJson;pendingJson=null;
                nextJsonSave=Time.unscaledTime+Mathf.Max(1,jsonSaveInterval);
                jsonJob=catalogCache.SaveAsync(snapshot);
            }
        }
        // Call on Unity's main thread; await before an explicit quit/save flow.
        // Saves object descriptors, not GameObjects, meshes or arbitrary gameplay components.
        public Task SaveObjectsAsync()
        {
            if(!ready||frame==null)throw new InvalidOperationException("Wait for the first star catalog before saving.");
            pendingJson=null;nextJsonSave=Time.unscaledTime+Mathf.Max(1,jsonSaveInterval);
            return catalogCache.SaveAsync(frame);
        }

        private static float Reveal(float d,float threshold)=>Mathf.SmoothStep(0,1,Mathf.InverseLerp(threshold,threshold*.55f,d));

        void OnDisable()=>Cleanup();
        void OnDestroy()=>Cleanup();

        private void Cleanup()
        {
            ready=false;
            var source=cancellation;cancellation=null;
            if(source!=null)
            {
                source.Cancel();
                if(job!=null)job.ContinueWith(t=> { if(t.IsFaulted) { var ignored=t.Exception; } source.Dispose(); },TaskScheduler.Default);
                else source.Dispose();
            }
            job=null;frame=null;pendingJson=null;
            // Already-started writes may finish; they hold plain immutable data, no scene objects.
            if(jsonJob!=null)jsonJob.ContinueWith(t=>{if(t.IsFaulted){var ignored=t.Exception;}},TaskScheduler.Default);
            jsonJob=null;catalogCache=null;modelPool=null;
            if(owner==this)ApplyStarFrameSystem.Pending=null;
            try { if(systemsCreated)SpaceSystems.Destroy(); }
            finally
            {
                systemsCreated=false;
                try { if(worldCreated)SpaceWorld.Destroy(); }
                finally { worldCreated=false;if(owner==this)owner=null; }
            }
            if(generatedRoot!=null) { generatedRoot.SetActive(false);Destroy(generatedRoot); }
            if(sphere!=null)Destroy(sphere);
            if(models!=null)foreach(var mesh in models)if(mesh!=null)Destroy(mesh);
            foreach(var material in ownedMaterials)if(material!=null)Destroy(material);
            ownedMaterials.Clear();byKey.Clear();near.Clear();views=null;models=null;sphere=null;
            generatedRoot=null;particles=null;particleBuffer=null;VisibleStarCount=0;
        }
    }
}
