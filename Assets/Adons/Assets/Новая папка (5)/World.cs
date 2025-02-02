﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World : MonoBehaviour {

    public int seed;
    public BiomeAttributes biome;

    public Transform player;
    public Transform editorcamera;
    public Vector3 spawnPosition;

    public Material material;
    public BlockType[] blocktypes;

    Chunkd[,] chunks = new Chunkd[VoxelData.WorldSizeInChunks, VoxelData.WorldSizeInChunks];

    List<ChunkCoord> activeChunks = new List<ChunkCoord>();
    ChunkCoord playerChunkCoord;
    ChunkCoord playerLastChunkCoord;
    public bool playernottransform;
    public void editorhrst()
    {
        if (editorcamera != null)
        {
            UnityEngine.Random.InitState(seed);

        spawnPosition = new Vector3(160f, 66f, 160f);
        GenerateWorld();


        
            playerLastChunkCoord = GetChunkCoordFromVector3(editorcamera.position);
        }
    }
    public void editorhrup()
    {

        if (editorcamera != null)
        {
            playerChunkCoord = GetChunkCoordFromVector3(editorcamera.position);

            // Only update the chunks if the player has moved from the chunk they were previously on.
            if (!playerChunkCoord.Equals(playerLastChunkCoord))
            {
                CheckViewDistance();
            }






        }
    }

    private void Start() 
    {
        var ObjectBonus1 = GameObject.FindGameObjectsWithTag("c");
        
        for (int i = 0; i < ObjectBonus1.Length; i++)
        {

            DestroyImmediate(ObjectBonus1[i]);
        }

        UnityEngine.Random.InitState(seed);

        spawnPosition = new Vector3(160f, 66f, 160f);
        GenerateWorld();
        playerLastChunkCoord = GetChunkCoordFromVector3(player.position);

        
    }

    private void Update() 
    {

        playerChunkCoord = GetChunkCoordFromVector3(player.position);
        
        // Only update the chunks if the player has moved from the chunk they were previously on.
        if (!playerChunkCoord.Equals(playerLastChunkCoord))
            CheckViewDistance();
        if (Input.GetKeyDown(KeyCode.F2))
        {
            CheckViewDistance();
        }

    }

    void GenerateWorld () {

        for (int x = (20 / 2) - VoxelData.ViewDistanceInChunks; x < (20 / 2) + VoxelData.ViewDistanceInChunks; x++) {
            for (int z = (20 / 2) - VoxelData.ViewDistanceInChunks; z < (20 / 2) + VoxelData.ViewDistanceInChunks; z++) {

                CreateNewChunk(x, z);

            }
        }
        if (File.Exists("unsave/s") && !playernottransform)
        {
            if (!File.Exists("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + File.ReadAllText("unsave/s")))
            {
                player.position = spawnPosition;
            }

        }
        if (!File.Exists("unsave/s") && !playernottransform)
        {
            
                player.position = spawnPosition;
            

        }
        if (File.Exists("unsave/s"))
        {
            if (File.Exists("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + File.ReadAllText("unsave/s")))
            {
                PlayerData gs = new PlayerData();
                gs = JsonUtility.FromJson<PlayerData>(File.ReadAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + File.ReadAllText("unsave/s")));
                player.position = gs.pos;
                

                CheckViewDistance();
            }
        }
    }

    ChunkCoord GetChunkCoordFromVector3 (Vector3 pos)
    {

        int x = Mathf.FloorToInt(pos.x / VoxelData.ChunkWidth);
        int z = Mathf.FloorToInt(pos.z / VoxelData.ChunkWidth);
        return new ChunkCoord(x, z);

    }

    void CheckViewDistance () {

        ChunkCoord coord = GetChunkCoordFromVector3(player.position);
        if (editorcamera)
        {


            coord = GetChunkCoordFromVector3(editorcamera.position);


        }
        List<ChunkCoord> previouslyActiveChunks = new List<ChunkCoord>(activeChunks);

        // Loop through all chunks currently within view distance of the player.
        for (int x = coord.x - VoxelData.ViewDistanceInChunks; x < coord.x + VoxelData.ViewDistanceInChunks; x++) {
            for (int z = coord.z - VoxelData.ViewDistanceInChunks; z < coord.z + VoxelData.ViewDistanceInChunks; z++) {

                // If the current chunk is in the world...
                if (IsChunkInWorld (new ChunkCoord (x, z))) {

                    // Check if it active, if not, activate it.
                    if (chunks[x, z] == null)
                        CreateNewChunk(x, z);
                    else if (!chunks[x, z].isActive) {
                        chunks[x, z].isActive = true;
                        activeChunks.Add(new ChunkCoord(x, z));
                    }

                }

                // Check through previously active chunks to see if this chunk is there. If it is, remove it from the list.
                for (int i = 0; i < previouslyActiveChunks.Count; i++) {

                    if (previouslyActiveChunks[i].Equals(new ChunkCoord(x, z)))
                        previouslyActiveChunks.RemoveAt(i);
                       
                }

            }
        }
        if (editorcamera == null)
        {
            // Any chunks left in the previousActiveChunks list are no longer in the player's view distance, so loop through and disable them.
            foreach (ChunkCoord c in previouslyActiveChunks)
            {


                chunks[c.x, c.z].isActive = false;


            }
        }
    }
    float fmod2(float a, float b)
    {
        float c = math.frac(math.abs(a / b)) * math.abs(b);
        if (a < 0)
        {
            c = -c + b;
        }
        return c;
    }
    public byte GetVoxel (Vector3 pos)
    {

        int yPos = Mathf.FloorToInt(pos.y);

        /* IMMUTABLE PASS */

        // If outside world, return air.
        if (!IsVoxelInWorld(pos))
            return 0;

        // If bottom block of chunk, return bedrock.
        if (yPos == 0)
            return 1;
        int cX = 10;
        int cY = 10;
        int c = 60;
       // Vector3 posX = new Vector3(fmod2(pos.x + 1f * cX, cX) - 5, 0, fmod2(pos.z + 1f * cY, cY) - 5);
        Vector3 posn = new Vector3(fmod2(pos.x + 1f * c, c) - 20, 0, fmod2(pos.z + 1f * c, c) - 20);
        /* BASIC TERRAIN PASS */

        int terrainHeight = Mathf.FloorToInt(biome.terrainHeight * Noise.Get2DPerlin(new Vector2(pos.x, pos.z), 0, biome.terrainScale)) + biome.solidGroundHeight;
        byte voxelValue = 0;

        if (yPos == terrainHeight)
            voxelValue = 3;
        else if (yPos < terrainHeight && yPos > terrainHeight - 4)
            voxelValue = 5;
        else if (biome.func == CubeMarchFunctions.RepeatCilindr) 
        {
            if (math.length(posn) < 18)
                voxelValue = 6;
            //    else if (math.length(posX) < 5)
            //     return 0;
        }
        else if (yPos > terrainHeight)
            return 0;
        else
            voxelValue = 2;

        /* SECOND PASS */

        if (voxelValue == 2) {

            foreach (Lode lode in biome.lodes) {

                if (yPos > lode.minHeight && yPos < lode.maxHeight)
                    if (Noise.Get3DPerlin(pos, lode.noiseOffset, lode.scale, lode.threshold))
                        voxelValue = lode.blockID;

            }

        }

        return voxelValue;


    }

    void CreateNewChunk (int x, int z) {

        chunks[x, z] = new Chunkd(new ChunkCoord(x, z), this);
        activeChunks.Add(new ChunkCoord(x, z));

    }

    bool IsChunkInWorld (ChunkCoord coord) {

        if (coord.x > 0 && coord.x < VoxelData.WorldSizeInChunks - 1 && coord.z > 0 && coord.z < VoxelData.WorldSizeInChunks - 1)
            return true;
        else
            return
                false;

    }

    bool IsVoxelInWorld (Vector3 pos) {

        if (pos.x >= 0 && pos.x < VoxelData.WorldSizeInVoxels && pos.y >= 0 && pos.y < VoxelData.ChunkHeight && pos.z >= 0 && pos.z < VoxelData.WorldSizeInVoxels)
            return true;
        else
            return false;

    }

}

[System.Serializable]
public class BlockType {

    public string blockName;
    public bool isSolid;

    [Header("Texture Values")]
    public int backFaceTexture;
    public int frontFaceTexture;
    public int topFaceTexture;
    public int bottomFaceTexture;
    public int leftFaceTexture;
    public int rightFaceTexture;

    // Back, Front, Top, Bottom, Left, Right

    public int GetTextureID (int faceIndex) {

        switch (faceIndex) {

            case 0:
                return backFaceTexture;
            case 1:
                return frontFaceTexture;
            case 2:
                return topFaceTexture;
            case 3:
                return bottomFaceTexture;
            case 4:
                return leftFaceTexture;
            case 5:
                return rightFaceTexture;
            default:
                Debug.Log("Error in GetTextureID; invalid face index");
                return 0;


        }

    }

}
