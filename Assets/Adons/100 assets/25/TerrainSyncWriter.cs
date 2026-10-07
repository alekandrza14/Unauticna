//```csharp
using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerrainSyncWriter : MonoBehaviour
{
    private Terrain[] terrains;

    // =========================================================
    // Настройки
    // =========================================================

    public string savePath = "C:/data/terrain";

    private const string PathsFileName = "terrains.paths";

    // Версия формата бинарного файла
    private const int FileVersion = 1;


    // =========================================================
    // Unity
    // =========================================================

    private void Start()
    {
        FindTerrains();

        if (terrains == null || terrains.Length == 0)
            return;

        SaveAllTerrains();
    }


    // =========================================================
    // Поиск Terrain
    // =========================================================

    private void FindTerrains()
    {
        terrains = Terrain.activeTerrains;

        if (terrains == null || terrains.Length == 0)
        {
            Debug.LogWarning(
                "TerrainSyncWriter: в сцене нет Terrain."
            );

            return;
        }

        Debug.Log(
            "Найдено Terrain: " +
            terrains.Length
        );
    }


    // =========================================================
    // Сохранить все Terrain
    // =========================================================

    public void SaveAllTerrains()
    {
        if (terrains == null || terrains.Length == 0)
        {
            FindTerrains();

            if (terrains == null || terrains.Length == 0)
                return;
        }

        Directory.CreateDirectory(savePath);

        string pathsFile =
            Path.Combine(
                savePath,
                PathsFileName
            );

        // -----------------------------------------------------
        // Файл со всеми путями
        // -----------------------------------------------------

        using (StreamWriter pathsWriter =
            new StreamWriter(
                pathsFile,
                false,
                Encoding.UTF8))
        {
            for (int i = 0; i < terrains.Length; i++)
            {
                Terrain terrain = terrains[i];

                if (terrain == null)
                    continue;

                string path =
                    SaveTerrain(
                        terrain,
                        i
                    );

                if (!string.IsNullOrEmpty(path))
                {
                    pathsWriter.WriteLine(path);
                }
            }
        }

        Debug.Log(
            "Файл путей Terrain сохранён: " +
            pathsFile
        );
    }


    // =========================================================
    // Сохранение одного Terrain
    // =========================================================

    private string SaveTerrain(
        Terrain terrain,
        int index)
    {
        if (terrain == null)
            return null;

        TerrainData data =
            terrain.terrainData;

        if (data == null)
            return null;


        // -----------------------------------------------------
        // Heightmap
        // -----------------------------------------------------

        int heightmapResolution =
            data.heightmapResolution;

        float[,] mapHeights =
            data.GetHeights(
                0,
                0,
                heightmapResolution,
                heightmapResolution
            );


        // -----------------------------------------------------
        // Holes
        // -----------------------------------------------------

        int holesResolution =
            data.holesResolution;

        bool[,] mapHoles =
            data.GetHoles(
                0,
                0,
                holesResolution,
                holesResolution
            );


        // -----------------------------------------------------
        // Преобразование массивов
        // -----------------------------------------------------

        float[] bracked2dmapheints =
            Break2D(mapHeights);

        float[] bracked2dmaphole =
            BreakHoles(mapHoles);


        // -----------------------------------------------------
        // Путь
        // -----------------------------------------------------

        string path =
            GetTerrainPath(
                terrain,
                index
            );


        // -----------------------------------------------------
        // Сохраняем
        // -----------------------------------------------------

        SaveTerrainData(
            path,
            terrain.transform.position,
            data.size,
            heightmapResolution,
            holesResolution,
            bracked2dmapheints,
            bracked2dmaphole
        );


        Debug.Log(
            "Terrain сохранён: " +
            terrain.name +
            " | " +
            path
        );

        return path;
    }


    // =========================================================
    // Получить путь Terrain
    // =========================================================

    private string GetTerrainPath(
        Terrain terrain,
        int index)
    {
        string sceneName =
            SceneManager.GetActiveScene().name;

        string terrainName =
            terrain.name;


        // -----------------------------------------------------
        // Убираем запрещённые символы
        // -----------------------------------------------------

        foreach (char c in Path.GetInvalidFileNameChars())
        {
            terrainName =
                terrainName.Replace(
                    c,
                    '_'
                );

            sceneName =
                sceneName.Replace(
                    c,
                    '_'
                );
        }


        return Path.Combine(
            savePath,
            sceneName +
            "_" +
            index +
            "_" +
            terrainName +
            ".terrain"
        );
    }


    // =========================================================
    // Сохранение бинарного Terrain
    // =========================================================

    private void SaveTerrainData(
        string path,
        Vector3 position,
        Vector3 size,
        int heightmapResolution,
        int holesResolution,
        float[] heights,
        float[] holes)
    {
        if (string.IsNullOrEmpty(path))
            return;

        if (heights == null)
            return;

        if (holes == null)
            return;


        string directory =
            Path.GetDirectoryName(path);

        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(
                directory
            );
        }


        using (BinaryWriter writer =
            new BinaryWriter(
                File.Open(
                    path,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None)))
        {
            // -------------------------------------------------
            // Версия
            // -------------------------------------------------

            writer.Write(
                FileVersion
            );


            // -------------------------------------------------
            // Position
            // -------------------------------------------------

            writer.Write(position.x);
            writer.Write(position.y);
            writer.Write(position.z);


            // -------------------------------------------------
            // Size
            // -------------------------------------------------

            writer.Write(size.x);
            writer.Write(size.y);
            writer.Write(size.z);


            // -------------------------------------------------
            // Heightmap Resolution
            // -------------------------------------------------

            writer.Write(
                heightmapResolution
            );


            // -------------------------------------------------
            // Holes Resolution
            // -------------------------------------------------

            writer.Write(
                holesResolution
            );


            // -------------------------------------------------
            // Heightmap
            // -------------------------------------------------

            writer.Write(
                heights.Length
            );

            foreach (float value in heights)
            {
                writer.Write(value);
            }


            // -------------------------------------------------
            // Holes
            // -------------------------------------------------

            writer.Write(
                holes.Length
            );

            foreach (float value in holes)
            {
                writer.Write(value);
            }
        }
    }


    // =========================================================
    // float[,] -> float[]
    // =========================================================

    public float[] Break2D(float[,] data)
    {
        if (data == null)
            return new float[0];


        int height =
            data.GetLength(0);

        int width =
            data.GetLength(1);


        float[] result =
            new float[
                height * width
            ];


        int index = 0;


        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                result[index++] =
                    data[y, x];
            }
        }


        return result;
    }


    // =========================================================
    // bool[,] -> float[]
    // =========================================================

    public float[] BreakHoles(bool[,] data)
    {
        if (data == null)
            return new float[0];


        int height =
            data.GetLength(0);

        int width =
            data.GetLength(1);


        float[] result =
            new float[
                height * width
            ];


        int index = 0;


        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                result[index++] =
                    data[y, x]
                        ? 1.0f
                        : 0.0f;
            }
        }


        return result;
    }


    // =========================================================
    // float[] -> float[,]
    // =========================================================

    public float[,] Restore2D(
        float[] data,
        int height,
        int width)
    {
        if (data == null ||
            data.Length == 0)
        {
            return new float[0, 0];
        }


        if (height <= 0 ||
            width <= 0)
        {
            return new float[0, 0];
        }


        if (data.Length != height * width)
        {
            Debug.LogError(
                "Restore2D: неправильный размер массива. " +
                "Ожидалось: " +
                (height * width) +
                ", получено: " +
                data.Length
            );

            return new float[0, 0];
        }


        float[,] result =
            new float[
                height,
                width
            ];


        int index = 0;


        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                result[y, x] =
                    data[index++];
            }
        }


        return result;
    }


    // =========================================================
    // Загрузить все Terrain
    // =========================================================

    public void LoadAllTerrains()
    {
        FindTerrains();

        if (terrains == null || terrains.Length == 0)
            return;


        string pathsFile =
            Path.Combine(
                savePath,
                PathsFileName
            );


        if (!File.Exists(pathsFile))
        {
            Debug.LogWarning(
                "Файл terrains.paths не найден: " +
                pathsFile
            );

            return;
        }


        string[] paths =
            File.ReadAllLines(
                pathsFile,
                Encoding.UTF8
            );


        int count =
            Mathf.Min(
                terrains.Length,
                paths.Length
            );


        for (int i = 0; i < count; i++)
        {
            string path =
                paths[i];


            if (string.IsNullOrWhiteSpace(path))
                continue;


            LoadTerrain(
                terrains[i],
                path
            );
        }


        Debug.Log(
            "Загрузка Terrain завершена."
        );
    }


    // =========================================================
    // Загрузка одного Terrain
    // =========================================================

    private void LoadTerrain(
        Terrain terrain,
        string path)
    {
        if (terrain == null)
            return;


        if (string.IsNullOrEmpty(path))
            return;


        if (!File.Exists(path))
        {
            Debug.LogWarning(
                "Файл Terrain не найден: " +
                path
            );

            return;
        }


        Vector3 position;
        Vector3 size;

        int heightmapResolution;
        int holesResolution;

        float[] heights;
        float[] holes;


        // -----------------------------------------------------
        // Читаем файл
        // -----------------------------------------------------

        bool loaded =
            LoadTerrainData(
                path,
                out position,
                out size,
                out heightmapResolution,
                out holesResolution,
                out heights,
                out holes
            );


        if (!loaded)
            return;


        TerrainData data =
            terrain.terrainData;


        if (data == null)
            return;


        // -----------------------------------------------------
        // Проверяем Resolution
        // -----------------------------------------------------

        if (heightmapResolution !=
            data.heightmapResolution)
        {
            Debug.LogError(
                "Размер heightmap не совпадает: " +
                terrain.name +
                " | файл: " +
                heightmapResolution +
                " | Terrain: " +
                data.heightmapResolution
            );

            return;
        }


        if (holesResolution !=
            data.holesResolution)
        {
            Debug.LogError(
                "Размер holes не совпадает: " +
                terrain.name +
                " | файл: " +
                holesResolution +
                " | Terrain: " +
                data.holesResolution
            );

            return;
        }


        // -----------------------------------------------------
        // Восстанавливаем Position
        // -----------------------------------------------------

        terrain.transform.position =
            position;


        // -----------------------------------------------------
        // Восстанавливаем Size
        // -----------------------------------------------------

        data.size =
            size;


        // -----------------------------------------------------
        // Восстанавливаем Heightmap
        // -----------------------------------------------------

        float[,] restoredHeights =
            Restore2D(
                heights,
                heightmapResolution,
                heightmapResolution
            );


        if (restoredHeights.Length == 0)
            return;


        data.SetHeights(
            0,
            0,
            restoredHeights
        );


        // -----------------------------------------------------
        // Восстанавливаем Holes
        // -----------------------------------------------------

        if (holes != null &&
            holes.Length > 0)
        {
            float[,] restoredHolesFloat =
                Restore2D(
                    holes,
                    holesResolution,
                    holesResolution
                );


            bool[,] restoredHoles =
                new bool[
                    holesResolution,
                    holesResolution
                ];


            for (int y = 0;
                y < holesResolution;
                y++)
            {
                for (int x = 0;
                    x < holesResolution;
                    x++)
                {
                    restoredHoles[y, x] =
                        restoredHolesFloat[y, x] > 0.5f;
                }
            }


            data.SetHoles(
                0,
                0,
                restoredHoles
            );
        }


        // -----------------------------------------------------
        // Обновляем Terrain
        // -----------------------------------------------------

        terrain.Flush();


        Debug.Log(
            "Terrain загружен: " +
            terrain.name +
            " | Position: " +
            position +
            " | Size: " +
            size
        );
    }


    // =========================================================
    // Загрузка бинарного Terrain
    // =========================================================

    private bool LoadTerrainData(
        string path,
        out Vector3 position,
        out Vector3 size,
        out int heightmapResolution,
        out int holesResolution,
        out float[] heights,
        out float[] holes)
    {
        position = Vector3.zero;
        size = Vector3.zero;

        heightmapResolution = 0;
        holesResolution = 0;

        heights = null;
        holes = null;


        try
        {
            using (BinaryReader reader =
                new BinaryReader(
                    File.Open(
                        path,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.Read)))
            {
                // -------------------------------------------------
                // Версия
                // -------------------------------------------------

                int version =
                    reader.ReadInt32();


                if (version != FileVersion)
                {
                    Debug.LogError(
                        "Неподдерживаемая версия Terrain: " +
                        version +
                        " | файл: " +
                        path
                    );

                    return false;
                }


                // -------------------------------------------------
                // Position
                // -------------------------------------------------

                position.x =
                    reader.ReadSingle();

                position.y =
                    reader.ReadSingle();

                position.z =
                    reader.ReadSingle();


                // -------------------------------------------------
                // Size
                // -------------------------------------------------

                size.x =
                    reader.ReadSingle();

                size.y =
                    reader.ReadSingle();

                size.z =
                    reader.ReadSingle();


                // -------------------------------------------------
                // Resolution
                // -------------------------------------------------

                heightmapResolution =
                    reader.ReadInt32();

                holesResolution =
                    reader.ReadInt32();


                // -------------------------------------------------
                // Heightmap
                // -------------------------------------------------

                int heightsLength =
                    reader.ReadInt32();


                if (heightsLength < 0)
                {
                    Debug.LogError(
                        "Некорректный размер heightmap."
                    );

                    return false;
                }


                heights =
                    new float[
                        heightsLength
                    ];


                for (int i = 0;
                    i < heightsLength;
                    i++)
                {
                    heights[i] =
                        reader.ReadSingle();
                }


                // -------------------------------------------------
                // Holes
                // -------------------------------------------------

                int holesLength =
                    reader.ReadInt32();


                if (holesLength < 0)
                {
                    Debug.LogError(
                        "Некорректный размер holes."
                    );

                    return false;
                }


                holes =
                    new float[
                        holesLength
                    ];


                for (int i = 0;
                    i < holesLength;
                    i++)
                {
                    holes[i] =
                        reader.ReadSingle();
                }
            }
        }
        catch (Exception exception)
        {
            Debug.LogError(
                "Ошибка загрузки Terrain: " +
                path +
                "\n" +
                exception
            );

            return false;
        }


        return true;
    }
}
//```
