using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

[BurstCompile]
public struct MoveJob : IJobParallelFor
{
     public NativeArray<float3> positions;

    [ReadOnly]
    public NativeArray<float3> targets;

    public float speed;
    public float deltaTime;

    public void Execute(int index)
    {
       float3 current = positions[index];
        float3 target = targets[index];

        float3 dir = target - current;
        float dist = math.length(dir);

        float step = speed * deltaTime;

if (dist > 0.001f)
{
    positions[index] += math.normalize(dir) * math.min(step, dist);
}
    }
}