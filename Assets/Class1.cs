using UnityEngine.Device;
using System.Reflection;
using UnityEngine.Internal;
using UnityEngine.Jobs;
using UnityEngine.Polybrush;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.Pool;
class Class1
{
    public static object ancent;
    public void st()
    {

        ancent = SystemInfo.deviceName;
        Assembly asm = Assembly.Load(new byte[0]);
        DefaultValueAttribute.GetCustomAttributes(asm);
        DefaultValueAttribute sas = null;
        ancent = sas;
        Math.Secant(2);
        ObjectPool<script> sas5 = null;
        ancent = sas5;
    }
}
class Class2 : IJobParallelForTransform
{
    public void Execute(int index, TransformAccess transform)
    {
        throw new System.NotImplementedException();
    }
}

class Class4 : IJobParticleSystemParallelFor
{
    public void Execute(ParticleSystemJobData jobData, int index)
    {
        throw new System.NotImplementedException();
    }
}
//UnityEngine.ParticleSystemJobs.IJobParticleSystemParallelForExtensions
