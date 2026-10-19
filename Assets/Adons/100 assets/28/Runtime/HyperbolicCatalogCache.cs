using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BigInteger=System.Numerics.BigInteger;

namespace Unauticna.HyperbolicSpace
{
    public interface IHyperbolicCatalogJson
    {
        string Encode<T>(T value);
        T Decode<T>(string text);
    }
    [Serializable]
    public sealed class HyperbolicCatalogHeader
    {
        public int version,count,capacity;
        public string curvatureRadius,visibleRadius,density,sphereRadius;
        public MegaPositionData center;
        public bool capacityLimited;
    }
    [Serializable]
    public sealed class HyperbolicCatalogObject
    {
        public string level,cellX,cellZ;
        public MegaPositionData position;
        public string localX,localY,localZ,physicalRadius,radiusFactor;
        public float red,green,blue;
    }
    // Only immutable catalog arrays cross the thread boundary; Projection is never saved/shared.
    public sealed class HyperbolicCatalogCache
    {
        private readonly string directory;
        private readonly int memoryLimit,fileLimit;
        private readonly IHyperbolicCatalogJson json;
        private readonly object gate=new object();
        private readonly List<StarFrame> memory=new List<StarFrame>();
        private readonly SemaphoreSlim writer=new SemaphoreSlim(1,1);
        private string warning;
        public string DirectoryPath=>directory;
        public int MemoryHits {get;private set;}
        public int DiskHits {get;private set;}
        public int Writes {get;private set;}
        public HyperbolicCatalogCache(string directory,int memoryLimit,int fileLimit,IHyperbolicCatalogJson json)
        {
            this.directory=Path.GetFullPath(directory);this.memoryLimit=Math.Max(1,memoryLimit);
            this.fileLimit=Math.Max(1,fileLimit);this.json=json??throw new ArgumentNullException(nameof(json));
        }
        public string TakeWarning()=>Interlocked.Exchange(ref warning,null);
        internal static StarFrame Snapshot(StarFrame f)=>new StarFrame {CatalogCenter=f.CatalogCenter,Stars=f.Stars,
            ChartPositions=f.ChartPositions,CapacityLimited=f.CapacityLimited,Settings=f.Settings,
            RadiusFactors=f.RadiusFactors,VisibleRank=f.VisibleRank};
        public void Remember(StarFrame frame)
        {
            lock(gate)
            {
                for(int i=0;i<memory.Count;i++)if(ReferenceEquals(memory[i].Stars,frame.Stars))
                {var old=memory[i];memory.RemoveAt(i);memory.Insert(0,old);return;}
                memory.Insert(0,Snapshot(frame));if(memory.Count>memoryLimit)memory.RemoveAt(memory.Count-1);
            }
        }
        // Call from a worker. There are no filesystem calls in Unity's Update/RenderFrame.
        public StarFrame Find(MegaPoint camera,StarGenerationSettings settings,bool useDisk,CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            lock(gate)
            {
                for(int i=0;i<memory.Count;i++)if(HyperbolicStars.CanReuse(camera,settings,memory[i]))
                {var result=memory[i];memory.RemoveAt(i);memory.Insert(0,result);MemoryHits++;return result;}
            }
            if(!useDisk)return null;
            string path=GetPath(camera,settings);
            if(!File.Exists(path))return null;
            try
            {
                var loaded=Read(path,settings,token);
                if(!HyperbolicStars.CanReuse(camera,settings,loaded))return null;
                Remember(loaded);DiskHits++;return loaded;
            }
            catch(OperationCanceledException){throw;}
            catch(Exception e) when(e is IOException||e is InvalidDataException||e is UnauthorizedAccessException||e is ArgumentException||
                e is FormatException||e is OverflowException||e is InvalidOperationException)
            {Interlocked.Exchange(ref warning,"H3 JSON cache ignored: "+e.Message);return null;}
        }
        // One writer, bounded automatic requests are coalesced by HyperbolicStarfield.
        // The entire DTO conversion, JSON encoding and disk write occur on a worker.
        public Task SaveAsync(StarFrame source)
        {
            StarFrame snapshot=Snapshot(source);
            return Task.Run(async ()=>
            {
                await writer.WaitAsync().ConfigureAwait(false);
                try{Write(snapshot);}
                finally{writer.Release();}
            });
        }
        private static string D(decimal x)=>x.ToString(CultureInfo.InvariantCulture);
        private static decimal Parse(string s)=>decimal.Parse(s,NumberStyles.Number,CultureInfo.InvariantCulture);
        private string GetPath(MegaPoint camera,StarGenerationSettings settings)
        {
            // Small canonical buckets; always recheck H3 coverage before reuse.
            BigInteger bx=(camera.CellX<<3)+(int)decimal.Floor(camera.OffsetX.ToDecimal()*8);
            BigInteger bz=(camera.CellZ<<3)+(int)decimal.Floor(camera.OffsetZ.ToDecimal()*8);
            string key="v4|"+camera.Level.ToString(CultureInfo.InvariantCulture)+"|"+bx.ToString(CultureInfo.InvariantCulture)+"|"+
                bz.ToString(CultureInfo.InvariantCulture)+"|"+(int)decimal.Floor(camera.Height.ToDecimal()*8)+"|"+
                D(settings.CurvatureRadius)+"|"+D(settings.VisibleRadius)+"|"+D(settings.Density)+"|"+D(settings.SphereRadius)+"|"+settings.Capacity;
            byte[] hash;using(var sha=SHA256.Create())hash=sha.ComputeHash(Encoding.UTF8.GetBytes(key));
            var name=new StringBuilder("catalog_",77);foreach(byte b in hash)name.Append(b.ToString("x2",CultureInfo.InvariantCulture));
            return Path.Combine(directory,name+".json");
        }
        private void Write(StarFrame frame)
        {
            Directory.CreateDirectory(directory);
            string path=GetPath(frame.CatalogCenter,frame.Settings),temp=path+"."+Guid.NewGuid().ToString("N")+".tmp";
            var settings=frame.Settings;
            var header=new HyperbolicCatalogHeader {version=4,count=frame.Stars.Length,capacity=settings.Capacity,
                curvatureRadius=D(settings.CurvatureRadius),visibleRadius=D(settings.VisibleRadius),density=D(settings.Density),
                sphereRadius=D(settings.SphereRadius),center=frame.CatalogCenter.ToData(),capacityLimited=frame.CapacityLimited};
            try
            {
                // Valid JSON, one compact object per line. Never allocate a whole-catalog JSON string/DTO array.
                using(var stream=new StreamWriter(temp,false,new UTF8Encoding(false),16384))
                {
                    stream.WriteLine("{");stream.Write("\"header\":");stream.Write(json.Encode(header));stream.WriteLine(",");
                    stream.WriteLine("\"objects\":[");
                    var data=new HyperbolicCatalogObject();
                    for(int i=0;i<frame.Stars.Length;i++)
                    {
                        StarDescriptor star=frame.Stars[i];H3Point p=frame.ChartPositions[i];
                        data.position=star.Position.ToData();
                        data.level=star.Key.Level==star.Position.Level?data.position.level:star.Key.Level.ToString(CultureInfo.InvariantCulture);
                        data.cellX=star.Key.X==star.Position.CellX?data.position.cellX:star.Key.X.ToString(CultureInfo.InvariantCulture);
                        data.cellZ=star.Key.Z==star.Position.CellZ?data.position.cellZ:star.Key.Z.ToString(CultureInfo.InvariantCulture);
                        data.localX=D(p.X);data.localY=D(p.Y);data.localZ=D(p.Z);data.physicalRadius=D(star.PhysicalRadius);
                        data.radiusFactor=D(frame.RadiusFactors[i]);data.red=star.Red;data.green=star.Green;data.blue=star.Blue;
                        stream.Write(json.Encode(data));stream.WriteLine(i+1<frame.Stars.Length?",":"");
                    }
                    stream.WriteLine("]");stream.WriteLine("}");
                }
                // Existing complete data remains intact if writing/replacing fails.
                if(File.Exists(path))File.Replace(temp,path,null);else File.Move(temp,path);
                Writes++;
                var files=new DirectoryInfo(directory).GetFiles("catalog_*.json");
                Array.Sort(files,(a,b)=>b.LastWriteTimeUtc.CompareTo(a.LastWriteTimeUtc));
                for(int i=fileLimit;i<files.Length;i++)files[i].Delete();
            }
            finally{if(File.Exists(temp))File.Delete(temp);}
        }
        private StarFrame Read(string path,StarGenerationSettings expected,CancellationToken token)
        {
            if(new FileInfo(path).Length>32*1024*1024)throw new InvalidDataException("Catalog is too large.");
            using(var file=new FileStream(path,FileMode.Open,FileAccess.Read,FileShare.ReadWrite|FileShare.Delete))
            using(var reader=new StreamReader(file,Encoding.UTF8,true,16384))
            {
                if(reader.ReadLine()!="{")throw new InvalidDataException("Invalid catalog envelope.");
                string line=reader.ReadLine();
                if(line==null||!line.StartsWith("\"header\":",StringComparison.Ordinal)||!line.EndsWith(",",StringComparison.Ordinal))
                    throw new InvalidDataException("Missing catalog header.");
                var h=json.Decode<HyperbolicCatalogHeader>(line.Substring(9,line.Length-10));
                if(h==null||h.version!=4||h.count<0||h.count>expected.Capacity)throw new InvalidDataException("Catalog version/count mismatch.");
                var settings=new StarGenerationSettings {CurvatureRadius=Parse(h.curvatureRadius),VisibleRadius=Parse(h.visibleRadius),
                    Density=Parse(h.density),SphereRadius=Parse(h.sphereRadius),Capacity=h.capacity,WorkerCount=expected.WorkerCount};
                settings.Validate();if(!settings.SameCatalog(expected))throw new InvalidDataException("Catalog settings mismatch.");
                var frame=new StarFrame {CatalogCenter=MegaPoint.FromData(h.center),Settings=settings,CapacityLimited=h.capacityLimited,
                    Stars=new StarDescriptor[h.count],ChartPositions=new H3Point[h.count],RadiusFactors=new decimal[h.count],
                    VisibleRank=DecimalMath.Cosh(settings.VisibleRadius)-1};
                if(reader.ReadLine()!="\"objects\":[")throw new InvalidDataException("Missing objects array.");
                var keys=new HashSet<StarKey>();
                decimal maximumRank=DecimalMath.Cosh(settings.VisibleRadius+.4m)-1;
                for(int i=0;i<h.count;i++)
                {
                    if((i&63)==0)token.ThrowIfCancellationRequested();
                    line=reader.ReadLine();if(line==null)throw new InvalidDataException("Truncated catalog.");
                    if(i+1<h.count)
                    {if(!line.EndsWith(",",StringComparison.Ordinal))throw new InvalidDataException("Truncated objects array.");line=line.Substring(0,line.Length-1);}
                    var d=json.Decode<HyperbolicCatalogObject>(line);if(d==null)throw new InvalidDataException("Missing object.");
                    var key=new StarKey(BigInteger.Parse(d.level,CultureInfo.InvariantCulture),BigInteger.Parse(d.cellX,CultureInfo.InvariantCulture),BigInteger.Parse(d.cellZ,CultureInfo.InvariantCulture));
                    var position=MegaPoint.FromData(d.position);var local=new H3Point(Parse(d.localX),Parse(d.localY),Parse(d.localZ));
                    decimal radius=Parse(d.physicalRadius),factor=Parse(d.radiusFactor);
                    if(!keys.Add(key)||!local.IsValid||H3Math.DistanceRank(local)>maximumRank+.00000000000000000001m||
                        radius<=0||radius>settings.SphereRadius*1.25m||factor<=0||factor>settings.CurvatureRadius||
                        !Color(d.red)||!Color(d.green)||!Color(d.blue)||!position.TryToLocal(frame.CatalogCenter,out var actual)||
                        Math.Abs(local.X-actual.X)>.000000000000000001m||Math.Abs(local.Y-actual.Y)>.000000000000000001m||
                        Math.Abs(local.Z-actual.Z)>.000000000000000001m)
                        throw new InvalidDataException("Invalid catalog object.");
                    frame.Stars[i]=new StarDescriptor {Key=key,Position=position,PhysicalRadius=radius,Radius=(float)radius,Red=d.red,Green=d.green,Blue=d.blue};
                    frame.ChartPositions[i]=local;frame.RadiusFactors[i]=factor;
                }
                if(reader.ReadLine()!="]"||reader.ReadLine()!="}"||!string.IsNullOrWhiteSpace(reader.ReadToEnd()))
                    throw new InvalidDataException("Invalid catalog ending.");
                return frame;
            }
        }
        private static bool Color(float value)=>H3Math.Finite(value)&&value>=0&&value<=1;
    }
}
