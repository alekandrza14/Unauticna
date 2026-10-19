using Unauticna.Mechanics;
using System.Collections.Generic;
//```csharp
using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TerrainSyncWriter : MonoBehaviour
{

    readonly LatestFileWorker syncWorker = new LatestFileWorker();
    bool syncDirty = true;
    int syncRevision = -1;
    float nextTopologyCheck;
    string capturedPath, capturedScene;
    struct TerrainStamp
    {
        public Matrix4x4 matrix;
        public TerrainData data;
        public Vector3 size;
        public int heightResolution, holesResolution, index;
        public string name;
    }
    readonly Dictionary<Terrain, TerrainStamp> terrainTransforms = new Dictionary<Terrain, TerrainStamp>();
    static TerrainStamp Stamp(Terrain terrain, int index)
    {
        var data = terrain.terrainData;
        return new TerrainStamp { matrix = terrain.transform.localToWorldMatrix, data = data,
            size = data != null ? data.size : Vector3.zero,
            heightResolution = data != null ? data.heightmapResolution : 0,
            holesResolution = data != null ? data.holesResolution : 0,
            index = index, name = terrain.name };
    }
    public void MarkDirty() { syncDirty = true; }
    void Awake() { PlayerMechanics.Register(this, MechanicId.TerrainSync); }
    void OnEnable()
    {
        syncDirty = true; nextTopologyCheck = 0;
        TerrainCallbacks.heightmapChanged += HeightsChanged;
        TerrainCallbacks.textureChanged += TextureChanged;
    }
    void HeightsChanged(Terrain terrain, RectInt region, bool synced) { syncDirty = true; }
    void TextureChanged(Terrain terrain, string texture, RectInt region, bool synced) { syncDirty = true; }
    void OnDisable()
    {
        TerrainCallbacks.heightmapChanged -= HeightsChanged;
        TerrainCallbacks.textureChanged -= TextureChanged;
        syncWorker.Cancel(); syncDirty = true;
    }
    void OnDestroy() { syncWorker.Cancel(); PlayerMechanics.Unregister(this); }
    void Update()
    {
        if (!PlayerMechanics.Active(MechanicId.TerrainSync)) return;
        string error = syncWorker.TakeError();
        if (error != null) { syncDirty = true; Debug.LogWarning("Terrain sync: " + error, this); }
        if (syncRevision != PlayerMechanics.RendererRevision) syncDirty = true;
        if (capturedPath != savePath || capturedScene != SceneManager.GetActiveScene().name) syncDirty = true;
        if (Time.unscaledTime >= nextTopologyCheck)
        {
            nextTopologyCheck = Time.unscaledTime + 1f;
            terrains = Terrain.activeTerrains;
            if (terrains.Length != terrainTransforms.Count) syncDirty = true;
            for (int i = 0; i < terrains.Length; i++)
            {
                var terrain = terrains[i]; if (terrain == null) continue;
                var current = Stamp(terrain, i);
                if (!terrainTransforms.TryGetValue(terrain, out var old) || old.matrix != current.matrix
                    || old.data != current.data || old.size != current.size || old.heightResolution != current.heightResolution
                    || old.holesResolution != current.holesResolution || old.index != current.index || old.name != current.name)
                    syncDirty = true;
            }
        }
        if (syncDirty && !syncWorker.Busy) SaveAllTerrains();
    }
    sealed class TerrainSnapshot
    {
        public string path; public Vector3 position, size;
        public int heightResolution, holesResolution;
        public float[,] heights; public bool[,] holes;
    }

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
        // Captured lazily only after an external renderer is detected.
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
        syncDirty = true;
        if (!isActiveAndEnabled || !PlayerMechanics.Active(MechanicId.TerrainSync) || syncWorker.Busy) return;
        terrains = Terrain.activeTerrains;
        var snapshots = new List<TerrainSnapshot>(); terrainTransforms.Clear();
        for (int i = 0; i < terrains.Length; i++)
        {
            var terrain = terrains[i]; if (terrain == null) continue;
            terrainTransforms[terrain] = Stamp(terrain, i);
            if (terrain.terrainData == null) continue;
            var data = terrain.terrainData;
            snapshots.Add(new TerrainSnapshot { path = GetTerrainPath(terrain, i), position = terrain.transform.position,
                size = data.size, heightResolution = data.heightmapResolution, holesResolution = data.holesResolution,
                heights = data.GetHeights(0, 0, data.heightmapResolution, data.heightmapResolution),
                holes = data.GetHoles(0, 0, data.holesResolution, data.holesResolution) });
        }
        string pathsFile = Path.Combine(savePath, PathsFileName);
        capturedPath = savePath; capturedScene = SceneManager.GetActiveScene().name;
        syncRevision = PlayerMechanics.RendererRevision; syncDirty = false;
        syncWorker.Submit(publish =>
        {
            var paths = new StringBuilder();
            foreach (var item in snapshots)
            {
                using (var stream = new MemoryStream()) using (var writer = new BinaryWriter(stream))
                {
                    writer.Write(FileVersion);
                    writer.Write(item.position.x); writer.Write(item.position.y); writer.Write(item.position.z);
                    writer.Write(item.size.x); writer.Write(item.size.y); writer.Write(item.size.z);
                    writer.Write(item.heightResolution); writer.Write(item.holesResolution);
                    writer.Write(item.heights.Length); foreach (float v in item.heights) writer.Write(v);
                    writer.Write(item.holes.Length); foreach (bool v in item.holes) writer.Write(v ? 1f : 0f);
                    publish(item.path, stream.ToArray());
                }
                paths.AppendLine(item.path);
            }
            // Manifest published last; an empty scene clears the previous list.
            publish(pathsFile, new UTF8Encoding(false).GetBytes(paths.ToString()));
        });
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
