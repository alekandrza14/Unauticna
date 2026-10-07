using ObjParser;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class CunkGenerator : InventoryEvent
{
    public GameObject[] res;

    private const int ObjectCount = 100;
    private const float ChunkSize = 100f;

    private readonly List<GameObject> pul =
        new List<GameObject>(0);
	public List<GameObject> pulyea = new List<GameObject>();
    private TransformAccessArray transforms;

    private NativeArray<RaycastCommand> rayCommands;
    private NativeArray<RaycastHit> rayHits;

    private JobHandle raycastHandle;
    private JobHandle transformHandle;

    private bool jobsRunning;

    public Vector4 Cancord3;
    public Vector4 Cancord3_3;
    public Vector4Int Cancord3_2;

    public Vector4Int Cancord3_old = Vector4Int.up_max;

    public int id;

    private mover player;

    private void Load1()
	{
		player = mover.main();
	
		rayCommands = new NativeArray<RaycastCommand>(
			ObjectCount,
			Allocator.Persistent);
	
		rayHits = new NativeArray<RaycastHit>(
			ObjectCount,
			Allocator.Persistent);
	
		CreateObjects();
	
		// СРАЗУ создать TransformAccessArray
		for (int i = 0; i < pul.Count; i++)
		{
			pul[i].transform.position =
				new Vector3(
					i * 2f,
					0f,
					0f
				);
		}
	}
    private void Update()
    {
        if (player == null)
        {
            player = mover.main();

            if (player == null)
                return;
        }

        Vector3 pos = player.transform.position;

        int chunkX = Mathf.FloorToInt(pos.x / ChunkSize) * 100;
        int chunkY = Mathf.FloorToInt(pos.y / ChunkSize) * 100;
        int chunkZ = Mathf.FloorToInt(pos.z / ChunkSize) * 100;
        int chunkW = Mathf.FloorToInt(player.W_position / ChunkSize) * 100;

        Cancord3_2 = new Vector4Int(
            chunkX,
            chunkY,
            chunkZ,
            chunkW
        );

       

        StartChunkJob();
    }
    private void CreateObjects()
	{
		if (res == null || res.Length == 0)
		{
			Debug.LogError("CunkGenerator: res пуст!");
			return;
		}
	
		System.Random random = new System.Random(
			Cancord3_2.x +
			Cancord3_2.y * 566 +
			Cancord3_2.z * 906 -
			Cancord3_2.w * 453 +
			id
		);
	
		for (int i = 0; i < ObjectCount/2; i++)
		{   
			int index = random.Next(0, res.Length);
			GameObject obj = Instantiate(
				res[index],
				Vector3.zero,
				Quaternion.identity
			);
	
			pul.Add(obj);
			pulyea.Add(obj);
		}
	
		Debug.Log("CunkGenerator: created " + pul.Count);
	
		CreateTransformArray();
	}
    private void CreateTransformArray()
    {
        if (transforms.isCreated)
            transforms.Dispose();

        Transform[] array =
            new Transform[pul.Count];

        for (int i = 0; i < pul.Count; i++)
            array[i] = pul[i].transform;

        transforms =
            new TransformAccessArray(array);
    }
    private void StartChunkJob()
	{	
	    if (""+Cancord3_2.x+Cancord3_2.y+Cancord3_2.z+Cancord3_2.w != ""+Cancord3_old.x+Cancord3_old.y+Cancord3_old.z+Cancord3_old.w)
        {
			
			System.Random random = new System.Random(
				Cancord3_2.x +
				Cancord3_2.y * 566 +
				Cancord3_2.z * 906 -
				Cancord3_2.w * 453 +
				id
			);
			for (int i = 0; i < ObjectCount; i++)
			{
				rayCommands[i] = new RaycastCommand(
					new Vector3(
						Cancord3_2.x+random.Next(-150,150),
						Cancord3_2.y + 100+random.Next(-150,150),
						Cancord3_2.z+random.Next(-150,150)
					),
					Vector3.down,
					1000f,
					~0
				);
			}
		
			raycastHandle =
				RaycastCommand.ScheduleBatch(
					rayCommands,
					rayHits,
					16
				);
		
			transformHandle =
				new ApplyChunkTransformsJob
				{
					Hits = rayHits
				}.Schedule(
					transforms,
					raycastHandle
				);
		
			jobsRunning = true;
		
			Cancord3_old = Cancord3_2;
		}
	}
    private void CompleteJobs()
	{   if (""+Cancord3_2.x+Cancord3_2.y+Cancord3_2.z+Cancord3_2.w != ""+Cancord3_old.x+Cancord3_old.y+Cancord3_old.z+Cancord3_old.w)
        {
				
			if (!jobsRunning)
				return;
		
			transformHandle.Complete();
		
			int hits = 0;
		
			for (int i = 0; i < ObjectCount; i++)
			{
				if (rayHits[i].distance > 0)
					hits++;
			}
		
			Debug.Log("Chunk hits: " + hits + "/" + ObjectCount);
		
			jobsRunning = false;
			
		}
	}
    private void LateUpdate()
    {
        if (jobsRunning)
            CompleteJobs();
    }
    private void OnDestroy()
    {
        CompleteJobs();

        if (transforms.isCreated)
            transforms.Dispose();

        if (rayCommands.IsCreated)
            rayCommands.Dispose();

        if (rayHits.IsCreated)
            rayHits.Dispose();
    }
	private struct ApplyChunkTransformsJob :
    IJobParallelForTransform
	{
		[ReadOnly]
		public NativeArray<RaycastHit> Hits;
	
			public void Execute(
		int index,
		TransformAccess transform)
		{
			if(index< Hits.Length)
			{	RaycastHit hit = Hits[index];
			
				if (hit.distance <= 0f)
					hit.point = Vector3.zero;
			
				transform.position =
					hit.point + hit.normal * 0.01f;
			
				Quaternion rotation =
					Quaternion.FromToRotation(
						Vector3.forward,
						-hit.normal
					);
			
				if (rotation.x > 0.2f)
					rotation *= Quaternion.Euler(0, 0, 180);
			
				transform.rotation = rotation;
			}
		}
	}

}