﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace na1
{
    public class Planet : MonoBehaviour
    {

        [Range(2, 256)]
        public int resolution = 10;
        public bool autoUpdate = true;
        public enum FaceRenderMask { All, Top, Bottom, Left, Right, Front, Back };
        public FaceRenderMask faceRenderMask;

        public ShapeSettings shapeSettings;
        public ColourSettings colourSettings;

        [HideInInspector]
        public bool shapeSettingsFoldout;
        [HideInInspector]
        public bool colourSettingsFoldout;

        ShapeGenerator shapeGenerator = new ShapeGenerator();
        na1.ColourGenerator colourGenerator = new na1.ColourGenerator();

        [SerializeField, HideInInspector]
        MeshFilter[] meshFilters;
        TerrainFace[] terrainFaces;


        void Initialize()
        {
            shapeGenerator.UpdateSettings(shapeSettings);
            colourGenerator.UpdateSettings(colourSettings);

            if (meshFilters == null || meshFilters.Length == 0)
            {
                meshFilters = new MeshFilter[6];
            }
            terrainFaces = new TerrainFace[6];

            Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };

            for (int i = 0; i < 6; i++)
            {
                if (meshFilters[i] == null)
                {
                    GameObject meshObj = new GameObject("mesh");
                    meshObj.transform.parent = transform;

                    meshObj.AddComponent<MeshRenderer>();
                    meshFilters[i] = meshObj.AddComponent<MeshFilter>();
                    meshFilters[i].sharedMesh = new Mesh();
                }
                meshFilters[i].GetComponent<MeshRenderer>().sharedMaterial = colourSettings.planetMaterial;

                terrainFaces[i] = new TerrainFace(shapeGenerator, meshFilters[i].sharedMesh, resolution, directions[i]);
                bool renderFace = faceRenderMask == FaceRenderMask.All || (int)faceRenderMask - 1 == i;
                meshFilters[i].gameObject.SetActive(renderFace);
            }
        }

        public void GeneratePlanet()
        {
            Initialize();
            GenerateMesh();
            GenerateColours();
        }

        public void OnShapeSettingsUpdated()
        {
            if (autoUpdate)
            {
                Initialize();
                GenerateMesh();
            }
        }

        public void OnColourSettingsUpdated()
        {
            if (autoUpdate)
            {
                Initialize();
                GenerateColours();
            }
        }

        void GenerateMesh()
        {
            for (int i = 0; i < 6; i++)
            {
                if (meshFilters[i].gameObject.activeSelf)
                {
                    terrainFaces[i].ConstructMesh();
                }
            }

            colourGenerator.UpdateElevation(shapeGenerator.elevationMinMax);
        }

        void GenerateColours()
        {
            colourGenerator.UpdateColours();
            for (int i = 0; i < 6; i++)
            {
                if (meshFilters[i].gameObject.activeSelf)
                {
                    terrainFaces[i].UpdateUVs(colourGenerator);
                }
            }
        }
    }
}