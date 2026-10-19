using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BigInteger = System.Numerics.BigInteger;

namespace Unauticna.HyperbolicSpace
{
    public struct StarDescriptor
    {
        public StarKey Key;
        public MegaPoint Position;
        public float Radius,Red,Green,Blue;
        public decimal PhysicalRadius;
    }
    public struct ProjectedStar {public float X,Y,Z,Distance,Radius,Visibility;}
    public struct StarGenerationSettings
    {
        public decimal CurvatureRadius,VisibleRadius,Density,SphereRadius;
        public int Capacity,WorkerCount;
        public void Validate()
        {
            if(CurvatureRadius<=0||VisibleRadius<.5m||VisibleRadius>3.2m||Density<0||Density>1||
                SphereRadius<=0||SphereRadius>CurvatureRadius*.15m||Capacity<1||Capacity>8192||WorkerCount<1)
                throw new ArgumentException("Invalid star generation settings.");
        }
        internal bool SameCatalog(StarGenerationSettings b)=>CurvatureRadius==b.CurvatureRadius&&
            VisibleRadius==b.VisibleRadius&&Density==b.Density&&SphereRadius==b.SphereRadius&&Capacity==b.Capacity;
    }
    public sealed class StarFrame
    {
        public MegaPoint CatalogCenter;
        public StarDescriptor[] Stars;
        public H3Point[] ChartPositions;
        public ProjectedStar[] Projection;
        public bool CapacityLimited;
        internal StarGenerationSettings Settings;
        internal decimal[] RadiusFactors;
        internal decimal VisibleRank;
    }
    public static class HyperbolicStars
    {
        private static readonly decimal ReuseRank=DecimalMath.Cosh(.18m)-1;
        internal static bool CanReuse(MegaPoint camera,StarGenerationSettings settings,StarFrame frame)=>
            frame!=null&&settings.SameCatalog(frame.Settings)&&frame.RadiusFactors!=null&&
            camera.TryToLocal(frame.CatalogCenter,out var p)&&H3Math.DistanceRank(p)<ReuseRank;
        public static StarDescriptor Describe(StarKey key,decimal sphereRadius)
        {
            ulong h=key.Hash;
            return Describe(key,sphereRadius,CoordinateRandom.Unit(h,1),
                1/DecimalMath.Sqrt(1-.75m*CoordinateRandom.Unit(h,2)),CoordinateRandom.Unit(h,3));
        }
        private static StarDescriptor Describe(StarKey key,decimal sphereRadius,decimal x,decimal y,decimal z)
        {
            ulong h=key.Hash;
            decimal physicalRadius=sphereRadius*(.75m+.5m*CoordinateRandom.Unit(h,4));
            return new StarDescriptor {
                Key=key,Position=MegaPoint.FromChart(key.Level,key.X,key.Z,x,y,z),
                Radius=(float)physicalRadius,PhysicalRadius=physicalRadius,
                Red=(float)(.55m+.45m*CoordinateRandom.Unit(h,5)),Green=(float)(.65m+.35m*CoordinateRandom.Unit(h,6)),
                Blue=(float)(.75m+.25m*CoordinateRandom.Unit(h,7)) };
        }
        public static StarFrame Build(H3Point camera,StarGenerationSettings settings,StarFrame previous,CancellationToken cancel,
            ProjectedStar[] reuseProjection=null)=>Build(MegaPoint.FromLocal(camera),settings,previous,cancel,reuseProjection);
        // reuseProjection must be exclusively owned by this worker until completion.
        // Catalog arrays are immutable; only Projection is writable.
        public static StarFrame Build(MegaPoint camera,StarGenerationSettings settings,StarFrame previous,CancellationToken cancel,
            ProjectedStar[] reuseProjection=null)
        {
            settings.Validate();if(!camera.IsValid)throw new ArgumentException("Invalid mega camera position.");
            cancel.ThrowIfCancellationRequested();
            StarDescriptor[] stars;H3Point[] chart;MegaPoint center;bool limited;
            decimal[] radiusFactors;decimal visibleRank;
            H3Point cameraLocal=H3Point.Origin;
            if(previous!=null&&settings.SameCatalog(previous.Settings)&&previous.RadiusFactors!=null&&
                camera.TryToLocal(previous.CatalogCenter,out cameraLocal)&&H3Math.DistanceRank(cameraLocal)<ReuseRank)
            {
                stars=previous.Stars;chart=previous.ChartPositions;center=previous.CatalogCenter;limited=previous.CapacityLimited;
                radiusFactors=previous.RadiusFactors;visibleRank=previous.VisibleRank;
            }
            else
            {
                stars=GenerateCore(camera,settings,cancel,out limited,out chart);center=camera;cameraLocal=H3Point.Origin;
                radiusFactors=new decimal[stars.Length];
                for(int i=0;i<stars.Length;i++)
                {
                    if((i&63)==0)cancel.ThrowIfCancellationRequested();
                    radiusFactors[i]=settings.CurvatureRadius*DecimalMath.Sinh(stars[i].PhysicalRadius/settings.CurvatureRadius);
                }
                visibleRank=DecimalMath.Cosh(settings.VisibleRadius)-1;
            }
            var projection=reuseProjection!=null&&reuseProjection.Length==stars.Length?reuseProjection:new ProjectedStar[stars.Length];
            H3Point localCamera=cameraLocal;
            // Chunking avoids a Parallel.For scheduler callback per individual star.
            const int chunkSize=64;
            Action<int> projectChunk=chunk=> {
                cancel.ThrowIfCancellationRequested();
                int end=Math.Min(stars.Length,(chunk+1)*chunkSize);
                for(int i=chunk*chunkSize;i<end;i++)
                    projection[i]=H3Math.Project(localCamera,chart[i],settings.CurvatureRadius,settings.VisibleRadius,visibleRank,radiusFactors[i]);
            };
            int chunks=(stars.Length+chunkSize-1)/chunkSize;
            if(stars.Length>=256&&settings.WorkerCount>1)
                Parallel.For(0,chunks,new ParallelOptions {CancellationToken=cancel,MaxDegreeOfParallelism=settings.WorkerCount},projectChunk);
            else for(int i=0;i<chunks;i++)projectChunk(i);
            return new StarFrame {Stars=stars,ChartPositions=chart,Projection=projection,CatalogCenter=center,CapacityLimited=limited,
                RadiusFactors=radiusFactors,VisibleRank=visibleRank,Settings=settings};
        }
        private struct Candidate
        {
            public StarKey Key;
            public H3Point Chart;
            public decimal X,Y,Z,Rank;
        }
        public static StarDescriptor[] Generate(H3Point camera,StarGenerationSettings settings,CancellationToken cancel,out bool limited)=>
            Generate(MegaPoint.FromLocal(camera),settings,cancel,out limited);
        public static StarDescriptor[] Generate(MegaPoint camera,StarGenerationSettings settings,CancellationToken cancel,out bool limited)=>
            GenerateCore(camera,settings,cancel,out limited,out _);
        private static StarDescriptor[] GenerateCore(MegaPoint camera,StarGenerationSettings settings,CancellationToken cancel,
            out bool limited,out H3Point[] chart)
        {
            settings.Validate();if(!camera.IsValid)throw new ArgumentException("Invalid mega camera position.");
            cancel.ThrowIfCancellationRequested();
            decimal range=settings.VisibleRadius+.4m,y=camera.Height.ToDecimal();
            DecimalMath.SinhCosh(range,out decimal sh,out decimal ch);
            decimal centerY=y*ch,radius=y*sh,limitRank=ch-1;
            int first=DecimalMath.FloorLog2(y*DecimalMath.Exp(-range)),last=DecimalMath.FloorLog2(y*DecimalMath.Exp(range));
            var candidates=new List<Candidate>(settings.Capacity);int visited=0;
            for(int layer=first;layer<=last;layer++)
            {
                decimal a=DecimalMath.Pow2(layer),closestY=Math.Max(a,Math.Min(2*a,centerY));
                decimal horizontal=DecimalMath.Sqrt(Math.Max(0,radius*radius-(closestY-centerY)*(closestY-centerY)));
                camera.CellAt(layer,out BigInteger baseX,out decimal fx,out BigInteger baseZ,out decimal fz);
                BigInteger globalLayer=camera.Level+layer;
                decimal horizontalCells=horizontal/a;
                int x0=(int)decimal.Floor(fx-horizontalCells),x1=(int)decimal.Floor(fx+horizontalCells);
                int z0=(int)decimal.Floor(fz-horizontalCells),z1=(int)decimal.Floor(fz+horizontalCells);
                // Huge integer addresses repeat across rows/columns. Hash each axis once.
                ulong layerHash=CoordinateRandom.IntegerHash(globalLayer);
                var zAddresses=new BigInteger[z1-z0+1];var zHashes=new ulong[zAddresses.Length];
                for(int z=z0;z<=z1;z++)
                {zAddresses[z-z0]=baseZ+z;zHashes[z-z0]=CoordinateRandom.IntegerHash(zAddresses[z-z0]);}
                for(int x=x0;x<=x1;x++)
                {
                    BigInteger globalX=baseX+x;ulong xHash=CoordinateRandom.IntegerHash(globalX);
                    for(int z=z0;z<=z1;z++)
                    {
                    if((visited++&127)==0)cancel.ThrowIfCancellationRequested();
                    if(visited>150000)throw new InvalidOperationException("Cell budget exceeded: reduce visibleRadius.");
                    ulong h=StarKey.CombineHash(layerHash,xHash,zHashes[z-z0]);
                    if(CoordinateRandom.Unit(h,0)>=settings.Density)continue;
                    decimal sx=CoordinateRandom.Unit(h,1),sy=1/DecimalMath.Sqrt(1-.75m*CoordinateRandom.Unit(h,2)),sz=CoordinateRandom.Unit(h,3);
                    H3Point relative=new H3Point((x+sx-fx)*a/y,sy*a/y,(z+sz-fz)*a/y);
                    decimal rank=H3Math.DistanceRank(relative);
                    if(rank<=limitRank)candidates.Add(new Candidate {
                        Key=new StarKey(globalLayer,globalX,zAddresses[z-z0],h),Chart=relative,X=sx,Y=sy,Z=sz,Rank=rank});
                    }
                }
            }
            candidates.Sort((a,b)=> {int c=a.Rank.CompareTo(b.Rank);return c!=0?c:a.Key.CompareTo(b.Key);});
            limited=candidates.Count>settings.Capacity;
            int count=Math.Min(candidates.Count,settings.Capacity);var result=new StarDescriptor[count];chart=new H3Point[count];
            // Create full global addresses, colors and radii only for retained stars.
            for(int i=0;i<count;i++)
            {
                if((i&63)==0)cancel.ThrowIfCancellationRequested();
                Candidate c=candidates[i];result[i]=Describe(c.Key,settings.SphereRadius,c.X,c.Y,c.Z);chart[i]=c.Chart;
            }
            return result;
        }
    }
}
