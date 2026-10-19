using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unauticna.Mechanics;

public class HDRP3DModelSyncWriter : MonoBehaviour
{
    public string saveDirectory = "C:/data/HDRP3DModels";
    public string jsonFileName = "HDRP3DModels.json";
    [Min(0.05f)] public float checkInterval = 0.2f;
    [Serializable] public class Vector3Data { public float x, y, z; public Vector3Data(Vector3 v) { x = v.x; y = v.y; z = v.z; } }
    [Serializable] public class ModelData { public string HDRPMODEL, objectName; public Vector3Data position, rotation, scale; }
    [Serializable] public class SceneData { public string sceneName; public List<ModelData> objects = new List<ModelData>(); }
    readonly LatestFileWorker worker = new LatestFileWorker();
    readonly List<HDRP3DModelLoader> sorted = new List<HDRP3DModelLoader>();
    struct Stamp { public string model, name; public Vector3 position, rotation, scale; }
    readonly Dictionary<int, Stamp> previous = new Dictionary<int, Stamp>();
    string previousScene;
    float next;
    string lastJson, lastPath;
    int revision = -1;
    void Awake() { PlayerMechanics.Register(this, MechanicId.HdrpSync); }
    void OnEnable() { next = 0; lastJson = null; }
    void Update()
    {
        string error = worker.TakeError(); if (error != null) { lastJson = null; Debug.LogWarning("HDRP sync: " + error, this); }
        if (Time.unscaledTime < next) return;
        next = Time.unscaledTime + Mathf.Max(0.05f, checkInterval); SaveScene();
    }
    public void SaveScene()
    {
        if (!isActiveAndEnabled || !PlayerMechanics.Active(MechanicId.HdrpSync)) return;
        sorted.Clear(); foreach (var loader in HDRP3DModelLoader.Live) if (loader != null && loader.isActiveAndEnabled) sorted.Add(loader);
        string path = Path.Combine(saveDirectory, jsonFileName);
        string scene = SceneManager.GetActiveScene().name;
        bool changed = lastJson == null || previous.Count != sorted.Count || previousScene != scene
            || lastPath != path || revision != PlayerMechanics.RendererRevision;
        foreach (var loader in sorted)
        {
            var tr = loader.transform;
            if (!previous.TryGetValue(loader.GetInstanceID(), out var stamp) || stamp.model != loader.HDRPMODEL
                || stamp.name != loader.gameObject.name || !stamp.position.Equals(tr.position)
                || !stamp.rotation.Equals(tr.eulerAngles) || !stamp.scale.Equals(tr.localScale)) { changed = true; break; }
        }
        if (!changed) return;
        sorted.Sort((a, b) => a.GetInstanceID().CompareTo(b.GetInstanceID()));
        var data = new SceneData { sceneName = scene }; previous.Clear(); previousScene = scene;
        foreach (var loader in sorted)
        {
            var tr = loader.transform;
            previous[loader.GetInstanceID()] = new Stamp { model = loader.HDRPMODEL, name = loader.gameObject.name,
                position = tr.position, rotation = tr.eulerAngles, scale = tr.localScale };
            if (string.IsNullOrWhiteSpace(loader.HDRPMODEL)) continue;
            data.objects.Add(new ModelData { HDRPMODEL = loader.HDRPMODEL, objectName = loader.gameObject.name,
                position = new Vector3Data(tr.position), rotation = new Vector3Data(tr.eulerAngles), scale = new Vector3Data(tr.localScale) });
        }
        string json = JsonUtility.ToJson(data);
        if (lastJson == json && path == lastPath && revision == PlayerMechanics.RendererRevision) return;
        // Empty list is also published: removed objects must disappear in the reader.
        lastJson = json; lastPath = path; revision = PlayerMechanics.RendererRevision;
        worker.SubmitText(path, json);
    }
    void OnDisable() { worker.Cancel(); lastJson = null; }
    void OnDestroy() { worker.Cancel(); PlayerMechanics.Unregister(this); }
}
