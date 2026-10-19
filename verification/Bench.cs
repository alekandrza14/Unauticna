using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.IO;
using Unauticna.HyperbolicSpace;
using BigInteger=System.Numerics.BigInteger;
class Bench
{
    static void Measure(string name,Action work,int repetitions)
    {
        for(int i=0;i<12;i++)work();
        var times=new double[5];long bytes=0;
        for(int round=0;round<5;round++)
        {
            GC.Collect();GC.WaitForPendingFinalizers();
            long before=GC.GetTotalAllocatedBytes(true);var sw=Stopwatch.StartNew();
            for(int i=0;i<repetitions;i++)work();
            sw.Stop();bytes+=GC.GetTotalAllocatedBytes(true)-before;
            times[round]=sw.Elapsed.TotalMilliseconds/repetitions;
        }
        Array.Sort(times);
        Console.WriteLine(name+": median_ms="+times[2].ToString("F4",System.Globalization.CultureInfo.InvariantCulture)+" bytes_per_call="+(bytes/(5*repetitions)));
    }
    static StarGenerationSettings S(int workers)=>new StarGenerationSettings {CurvatureRadius=20,VisibleRadius=2.6m,Density=.8m,SphereRadius=1.2m,Capacity=2048,WorkerCount=workers};
    static void Main(string[] args)
    {
        var origin=MegaPoint.Origin;var far=MegaPoint.FromChart(BigInteger.Pow(10,80),(BigInteger.One<<400)+123,-(BigInteger.One<<350)-17,.125m,1.5m,.875m);
        foreach(var pair in new[]{("origin",origin),("mega",far)})
        {
            var settings=S(1);var frame=HyperbolicStars.Build(pair.Item2,settings,null,CancellationToken.None);
            Console.WriteLine(pair.Item1+" stars="+frame.Stars.Length);
            if(args.Length>0)
            {
                using(var w=new StreamWriter(args[0]+"_"+pair.Item1+".txt"))
                for(int i=0;i<frame.Stars.Length;i++)
                {
                    var s=frame.Stars[i];var p=frame.Projection[i];
                    w.WriteLine(s.Key+"|"+s.Position+"|"+s.PhysicalRadius+"|"+s.Red+","+s.Green+","+s.Blue+"|"+p.X+","+p.Y+","+p.Z+","+p.Distance+","+p.Radius+","+p.Visibility);
                }
            }
            Measure(pair.Item1+" generate",()=>HyperbolicStars.Generate(pair.Item2,settings,CancellationToken.None,out _),8);
            int tick=0;
            Measure(pair.Item1+" project_1",()=>{var pos=pair.Item2.Compose(new H3Point((tick++%100)*.0001m,1.0001m,.0001m));frame=HyperbolicStars.Build(pos,settings,frame,CancellationToken.None,frame.Projection);},40);
            settings.WorkerCount=4;
            Measure(pair.Item1+" project_4",()=>{var pos=pair.Item2.Compose(new H3Point((tick++%100)*.0001m,1.0001m,.0001m));frame=HyperbolicStars.Build(pos,settings,frame,CancellationToken.None,frame.Projection);},40);
        }
        decimal d=.1234567890123456789012345678m;Decimal256 result=default;
        Measure("decimal256 convert",()=>{for(int i=0;i<1000;i++)result=Decimal256.FromDecimal(d+i%2);},10);
        if(result.ToDecimal()<0)throw new Exception();
    }
}
