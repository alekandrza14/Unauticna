using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HDRP3DModelSyncWriter : MonoBehaviour
{
    [Header("Папка сохранения")]
    public string saveDirectory = "C:/data/HDRP3DModels";

    [Header("Имя JSON")]
    public string jsonFileName = "HDRP3DModels.json";


    // =========================================================
    // JSON DATA
    // =========================================================

    [Serializable]
    public class Vector3Data
    {
        public float x;
        public float y;
        public float z;

        public Vector3Data(Vector3 vector)
        {
            x = vector.x;
            y = vector.y;
            z = vector.z;
        }
    }


    [Serializable]
    public class ModelData
    {
        public string HDRPMODEL;

        public string objectName;

        public Vector3Data position;
        public Vector3Data rotation;
        public Vector3Data scale;
    }


    [Serializable]
    public class SceneData
    {
        public string sceneName;

        public List<ModelData> objects =
            new List<ModelData>();
    }


    // =========================================================
    // START
    // =========================================================

    private void Start()
    {
        SaveScene();
    }
	int oldpach = -1;
	public float checkInterval =
        0.2f;  private float timer;
	void Update()
	{
		timer += Time.deltaTime;

        if (timer < checkInterval)
            return;

		SaveScene();
		//oldpach = loaders.Length;
		
        timer = 0f;
	}


    // =========================================================
    // SAVE SCENE
    // =========================================================

    public void SaveScene()
    {
        HDRP3DModelLoader[] loaders =
            FindObjectsOfType<HDRP3DModelLoader>(
                true
            );


        if (loaders == null ||
            loaders.Length == 0)
        {
            Debug.LogWarning(
                "HDRP3DModelSyncWriter: " +
                "объекты с HDRP3DModelLoader не найдены."
            );

            return;
        }


        SceneData sceneData =
            new SceneData();


        sceneData.sceneName =
            SceneManager
                .GetActiveScene()
                .name;


        // =====================================================
        // ОБХОД ОБЪЕКТОВ
        // =====================================================

        foreach (
            HDRP3DModelLoader loader
            in loaders)
        {
            if (loader == null)
                continue;


            // -------------------------------------------------
            // Проверяем HDRPMODEL
            // -------------------------------------------------

            if (string.IsNullOrWhiteSpace(
                loader.HDRPMODEL))
            {
                Debug.LogWarning(
                    "HDRP3DModelSyncWriter: " +
                    "у объекта '" +
                    loader.gameObject.name +
                    "' не задан HDRPMODEL."
                );

                continue;
            }


            // -------------------------------------------------
            // Создаём запись
            // -------------------------------------------------

            ModelData model =
                new ModelData();


            model.HDRPMODEL =
                loader.HDRPMODEL;


            model.objectName =
                loader.gameObject.name;


            // -------------------------------------------------
            // Position
            // -------------------------------------------------

            model.position =
                new Vector3Data(
                    loader.transform.position
                );


            // -------------------------------------------------
            // Rotation
            // -------------------------------------------------

            model.rotation =
                new Vector3Data(
                    loader.transform.eulerAngles
                );


            // -------------------------------------------------
            // Scale
            // -------------------------------------------------

            model.scale =
                new Vector3Data(
                    loader.transform.localScale
                );


            sceneData.objects.Add(
                model
            );
        }


        // =====================================================
        // JSON
        // =====================================================

        string json =
            JsonUtility.ToJson(
                sceneData,
                true
            );


        // =====================================================
        // ПАПКА
        // =====================================================

        Directory.CreateDirectory(
            saveDirectory
        );


        // =====================================================
        // ФАЙЛ
        // =====================================================

        string path =
            Path.Combine(
                saveDirectory,
                jsonFileName
            );


        File.WriteAllText(
            path,
            json
        );


        Debug.Log(
            "HDRP3DModelSyncWriter: JSON сохранён.\n" +
            "Файл: " +
            path +
            "\n" +
            "Объектов: " +
            sceneData.objects.Count
        );
    }
}