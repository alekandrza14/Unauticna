using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class PolygonSyncWriter : MonoBehaviour
{
    // =========================================================
    // POLYGONS
    // =========================================================

    public Dictionary<Transform, Mesh> Apolygons =
        new Dictionary<Transform, Mesh>();


    // =========================================================
    // НАСТРОЙКИ
    // =========================================================

    public string savePath =
        "C:/data/frame";


    // =========================================================
    // СОСТОЯНИЕ
    // =========================================================

    private int lastPolygonCount = -1;

    private int lastVertexCount = -1;

    private int lastTriangleCount = -1;


    // =========================================================
    // ADD
    // =========================================================

    public void AddPolygon(
        Transform transform,
        Mesh mesh)
    {
        if (transform == null)
            return;

        if (mesh == null)
            return;


        if (Apolygons.ContainsKey(transform))
        {
            Apolygons[transform] =
                mesh;

            return;
        }


        Apolygons.Add(
            transform,
            mesh
        );


        // Заставляем BuildMesh пересобрать данные

        lastPolygonCount = -1;
        lastVertexCount = -1;
        lastTriangleCount = -1;
    }


    // =========================================================
    // REMOVE
    // =========================================================

    public void RemovePolygon(
        Transform transform)
    {
        if (transform == null)
            return;


        Apolygons.Remove(
            transform
        );


        lastPolygonCount = -1;
        lastVertexCount = -1;
        lastTriangleCount = -1;
    }


    // =========================================================
    // CLEAN DESTROYED OBJECTS
    // =========================================================

    private void RemoveDestroyedPolygons()
    {
        if (Apolygons.Count == 0)
            return;


        List<Transform> remove =
            new List<Transform>();


        foreach (
            KeyValuePair<Transform, Mesh>
            polygon
            in Apolygons)
        {
            Transform tr =
                polygon.Key;

            Mesh mesh =
                polygon.Value;


            // -------------------------------------------------
            // Unity Object уже уничтожен
            // -------------------------------------------------

            if (tr == null)
            {
                remove.Add(tr);
                continue;
            }


            if (mesh == null)
            {
                remove.Add(tr);
                continue;
            }
        }


        // -----------------------------------------------------
        // Удаляем старые ссылки
        // -----------------------------------------------------

        if (remove.Count == 0)
            return;


        foreach (Transform tr in remove)
        {
            Apolygons.Remove(
                tr
            );
        }


        // -----------------------------------------------------
        // Требуем пересборку
        // -----------------------------------------------------

        lastPolygonCount = -1;
        lastVertexCount = -1;
        lastTriangleCount = -1;
    }


    // =========================================================
    // BUILD MESH
    // =========================================================

    public void BuildMesh()
    {
        // -----------------------------------------------------
        // Сначала чистим уничтоженные Transform
        // -----------------------------------------------------

        RemoveDestroyedPolygons();


        // -----------------------------------------------------
        // Нет объектов
        // -----------------------------------------------------

        if (Apolygons.Count == 0)
        {
            lastPolygonCount = 0;
            lastVertexCount = 0;
            lastTriangleCount = 0;

            return;
        }


        // -----------------------------------------------------
        // Если количество Polygon не изменилось,
        // пока ничего не делаем.
        // -----------------------------------------------------

        if (lastPolygonCount ==
            Apolygons.Count)
        {
            return;
        }


        List<Vector3> vertices =
            new List<Vector3>();


        List<int> triangles =
            new List<int>();


        List<Vector2> uv =
            new List<Vector2>();


        List<Vector3> normals =
            new List<Vector3>();


        // =====================================================
        // ОБХОД POLYGONS
        // =====================================================

        foreach (
            KeyValuePair<Transform, Mesh>
            polygon
            in Apolygons)
        {
            Transform tr =
                polygon.Key;


            Mesh mesh =
                polygon.Value;


            // -------------------------------------------------
            // Дополнительная защита
            // -------------------------------------------------

            if (tr == null)
                continue;


            if (mesh == null)
                continue;


            // -------------------------------------------------
            // Vertex offset
            // -------------------------------------------------

            int vertexOffset =
                vertices.Count;


            Vector3[] meshVertices =
                mesh.vertices;


            int[] meshTriangles =
                mesh.triangles;


            Vector2[] meshUV =
                mesh.uv;


            Vector3[] meshNormals =
                mesh.normals;


            // =================================================
            // VERTICES
            // =================================================

            foreach (
                Vector3 vertex
                in meshVertices)
            {
                // -------------------------------------------------
                // Transform может быть уничтожен во время работы
                // -------------------------------------------------

                if (tr == null)
                    break;


                vertices.Add(
                    tr.TransformPoint(
                        vertex
                    )
                );
            }


            // Если Transform уничтожился
            // пропускаем Polygon

            if (tr == null)
                continue;


            // =================================================
            // TRIANGLES
            // =================================================

            foreach (
                int triangle
                in meshTriangles)
            {
                triangles.Add(
                    vertexOffset +
                    triangle
                );
            }


            // =================================================
            // UV
            // =================================================

            if (meshUV != null)
            {
                foreach (
                    Vector2 coordinate
                    in meshUV)
                {
                    uv.Add(
                        coordinate
                    );
                }
            }


            // =================================================
            // NORMALS
            // =================================================

            if (meshNormals != null &&
                meshNormals.Length ==
                meshVertices.Length)
            {
                foreach (
                    Vector3 normal
                    in meshNormals)
                {
                    if (tr == null)
                        break;


                    normals.Add(
                        tr.TransformDirection(
                            normal
                        )
                    );
                }
            }
        }


        // =====================================================
        // ПОСЛЕ ОБХОДА
        // =====================================================

        if (vertices.Count == 0)
        {
            lastPolygonCount = 0;
            return;
        }


        // =====================================================
        // СОЗДАЁМ COMBINED MESH
        // =====================================================

        Mesh combinedMesh =
            new Mesh();


        combinedMesh.indexFormat =
            vertices.Count > 65535
                ? IndexFormat.UInt32
                : IndexFormat.UInt16;


        combinedMesh.SetVertices(
            vertices
        );


        combinedMesh.SetTriangles(
            triangles,
            0
        );


        if (uv.Count ==
            vertices.Count)
        {
            combinedMesh.SetUVs(
                0,
                uv
            );
        }


        if (normals.Count ==
            vertices.Count)
        {
            combinedMesh.SetNormals(
                normals
            );
        }
        else
        {
            combinedMesh.RecalculateNormals();
        }


        combinedMesh.RecalculateBounds();


        // =====================================================
        // СОХРАНЕНИЕ
        // =====================================================

        SaveMesh(
            savePath,
            vertices.ToArray(),
            triangles.ToArray(),
            uv.ToArray(),
            normals.ToArray()
        );


        // =====================================================
        // СОХРАНЯЕМ СОСТОЯНИЕ
        // =====================================================

        lastPolygonCount =
            Apolygons.Count;


        lastVertexCount =
            vertices.Count;


        lastTriangleCount =
            triangles.Count;


        // -----------------------------------------------------
        // Удаляем временный Mesh
        // -----------------------------------------------------

        Destroy(
            combinedMesh
        );
    }


    // =========================================================
    // VECTOR3 -> FLOAT[]
    // =========================================================

    public float[] breackV3(
        Vector3[] data)
    {
        if (data == null)
            return new float[0];


        float[] result =
            new float[
                data.Length * 3
            ];


        int index = 0;


        foreach (Vector3 v in data)
        {
            result[index++] =
                v.x;

            result[index++] =
                v.y;

            result[index++] =
                v.z;
        }


        return result;
    }


    // =========================================================
    // VECTOR2 -> FLOAT[]
    // =========================================================

    public float[] breackV2(
        Vector2[] data)
    {
        if (data == null)
            return new float[0];


        float[] result =
            new float[
                data.Length * 2
            ];


        int index = 0;


        foreach (Vector2 v in data)
        {
            result[index++] =
                v.x;

            result[index++] =
                v.y;
        }


        return result;
    }


    // =========================================================
    // FLOAT[] -> VECTOR3[]
    // =========================================================

    public Vector3[] RestoreV3(
        float[] data)
    {
        if (data == null ||
            data.Length % 3 != 0)
        {
            return new Vector3[0];
        }


        Vector3[] result =
            new Vector3[
                data.Length / 3
            ];


        int index = 0;


        for (int i = 0;
            i < result.Length;
            i++)
        {
            result[i] =
                new Vector3(
                    data[index++],
                    data[index++],
                    data[index++]
                );
        }


        return result;
    }


    // =========================================================
    // FLOAT[] -> VECTOR2[]
    // =========================================================

    public Vector2[] RestoreV2(
        float[] data)
    {
        if (data == null ||
            data.Length % 2 != 0)
        {
            return new Vector2[0];
        }


        Vector2[] result =
            new Vector2[
                data.Length / 2
            ];


        int index = 0;


        for (int i = 0;
            i < result.Length;
            i++)
        {
            result[i] =
                new Vector2(
                    data[index++],
                    data[index++]
                );
        }


        return result;
    }


    // =========================================================
    // SAVE MESH
    // =========================================================

    public void SaveMesh(
        string path,
        Vector3[] vertices,
        int[] triangles,
        Vector2[] uv,
        Vector3[] normals)
    {
        if (vertices == null)
            return;


        if (triangles == null)
            return;


        if (uv == null)
            return;


        if (normals == null)
            return;


        // -----------------------------------------------------
        // Если вообще ничего не изменилось
        // -----------------------------------------------------

        if (lastVertexCount ==
                vertices.Length &&
            lastTriangleCount ==
                triangles.Length)
        {
            return;
        }


        lastVertexCount =
            vertices.Length;


        lastTriangleCount =
            triangles.Length;


        // =====================================================
        // DIRECTORY
        // =====================================================

        string directory =
            Path.GetDirectoryName(
                path
            );


        if (!string.IsNullOrEmpty(
            directory))
        {
            Directory.CreateDirectory(
                directory
            );
        }


        // =====================================================
        // WRITE
        // =====================================================

        using (
            BinaryWriter writer =
                new BinaryWriter(
                    File.Open(
                        path,
                        FileMode.Create,
                        FileAccess.Write,
                        FileShare.None
                    )
                )
        )
        {
            // =================================================
            // VERTICES
            // =================================================

            float[] v =
                breackV3(
                    vertices
                );


            writer.Write(
                v.Length
            );


            foreach (float value in v)
            {
                writer.Write(
                    value
                );
            }


            // =================================================
            // TRIANGLES
            // =================================================

            writer.Write(
                triangles.Length
            );


            foreach (int value in triangles)
            {
                writer.Write(
                    value
                );
            }


            // =================================================
            // UV
            // =================================================

            float[] u =
                breackV2(
                    uv
                );


            writer.Write(
                u.Length
            );


            foreach (float value in u)
            {
                writer.Write(
                    value
                );
            }


            // =================================================
            // NORMALS
            // =================================================

            float[] n =
                breackV3(
                    normals
                );


            writer.Write(
                n.Length
            );


            foreach (float value in n)
            {
                writer.Write(
                    value
                );
            }
        }


        Debug.Log(
            "Polygon Mesh сохранён: " +
            path +
            " | Vertices: " +
            vertices.Length +
            " | Triangles: " +
            triangles.Length
        );
    }
}