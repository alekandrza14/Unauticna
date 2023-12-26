using System.IO;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class ExampleEditorScript : Editor
{
    [MenuItem("CreateExamples/3DTexture")]
    static void CreateTexture3D()
    {
        // Configure the texture
        int size = 32;
        TextureFormat format = TextureFormat.RGBA32;
        TextureWrapMode wrapMode =  TextureWrapMode.Clamp;

        // Create the texture and apply the configuration
        Texture3D texture = new Texture3D(size, size, size, format, false);
        texture.wrapMode = wrapMode;

        // Create a 3-dimensional array to store color data
        Color[] colors = new Color[size * size * size];

        // Populate the array so that the x, y, and z values of the texture will map to red, blue, and green colors
        float inverseResolution = 1.0f / (size - 1.0f);
        for (int z = 0; z < size; z++)
        {
            int zOffset = z * size * size;
            for (int y = 0; y < size; y++)
            {
                int yOffset = y * size;
                for (int x = 0; x < size; x++)
                {
                    System.Random r = new System.Random();
                    colors[x + yOffset + zOffset] = new Color(x * inverseResolution,
                        y * inverseResolution, z * inverseResolution, 1);
                    if (y == 0 || y == size - 1)
                    {
                        colors[x + yOffset + zOffset] = new Color(x * inverseResolution,
                        y * inverseResolution, z * inverseResolution, 0);
                    }
                    if (z == 0 || z == size - 1)
                    {
                        colors[x + yOffset + zOffset] = new Color(x * inverseResolution,
                        y * inverseResolution, z * inverseResolution, 0);
                    }
                    if (x == 0 || x == size - 1)
                    {
                        colors[x + yOffset + zOffset] = new Color(x * inverseResolution,
                        y * inverseResolution, z * inverseResolution, 0);
                    }
                }
            }
        }

        // Copy the color values to the texture
        texture.SetPixels(colors);

        // Apply the changes to the texture and upload the updated texture to the GPU
        texture.Apply();

        // Save the texture to your Unity Project

      //  AssetDatabase.CreateAsset(texture, "Assets/Example3DTexture.asset");
        string path1 = Application.dataPath;
        path1 = path1.Remove(path1.Length - 6, 6);
        string path2 = EditorUtility.SaveFilePanel("Choose Location of Save Asset 3DTexture", "Assets/", "Texture3D", "asset");
        //  AssetDatabase.CreateAsset(texture, EditorUtility.SaveFolderPanel("Choose Location of Save Asset 3DTexture", "Assets/","")+ "/Example3DTexture.asset");
        path2 = path2.Remove( 0, path1.Length);
        Debug.Log(path2);
        AssetDatabase.CreateAsset(texture, path2);
    }
}