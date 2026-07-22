using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
public class UnitManager : MonoBehaviour
{
    public List<SelectObjectTag> units = new List<SelectObjectTag>();

    NativeArray<float3> positions;
    NativeArray<float3> targets;

    void Start()
    {
        positions = new NativeArray<float3>(10000, Allocator.Persistent);
        targets   = new NativeArray<float3>(10000, Allocator.Persistent);
    }

    void Update()
    {
        // 1. Копируем данные из Transform
        for (int i = 0; i < units.Count; i++)
        {
            positions[i] = units[i].transform.position;
            targets[i] = units[i].Target;
        }

        // 2. Запускаем Job
        MoveJob job = new MoveJob
        {
            positions = positions,
            targets = targets,
            speed = 5,
            deltaTime = Time.deltaTime
        };

        JobHandle handle = job.Schedule(units.Count, 64);
        handle.Complete();

        // 3. Записываем результат обратно
        for (int i = 0; i < units.Count; i++)
        {
            units[i].transform.position = positions[i];
        }
    }

    void OnDestroy()
    {
        positions.Dispose();
        targets.Dispose();
    }
}