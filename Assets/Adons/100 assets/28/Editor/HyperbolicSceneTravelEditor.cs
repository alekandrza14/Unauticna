#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Unauticna.HyperbolicSpace.Editor
{
    [CustomEditor(typeof(HyperbolicSceneTravel))]
    public sealed class HyperbolicSceneTravelEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            var path = serializedObject.FindProperty("planetScene");
            var scene = AssetDatabase.LoadAssetAtPath<SceneAsset>(path.stringValue);
            EditorGUI.BeginChangeCheck();
            scene = (SceneAsset)EditorGUILayout.ObjectField("Planet Scene", scene, typeof(SceneAsset), false);
            if (EditorGUI.EndChangeCheck()) path.stringValue = scene != null ? AssetDatabase.GetAssetPath(scene) : "";
            DrawPropertiesExcluding(serializedObject, "m_Script", "planetScene");
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.HelpBox("Выбери существующую сцену с playerhyperbolic. На планете автоматически появится кнопка возврата; Backspace тоже возвращает. Скрипты игрока не меняются.", MessageType.Info);
            if (GUILayout.Button("Добавить обе сцены в общий список сборки")) AddScenes((HyperbolicSceneTravel)target);
            EditorGUILayout.HelpBox("Если Build Profile переопределяет Scene List, включи обе сцены и в его списке.", MessageType.Info);
        }

        [MenuItem("Tools/Unauticna/Hyperbolic Space/Add scene travel")]
        public static void AddTravel()
        {
            if (EditorApplication.isPlaying) return;
            var field = Selection.activeGameObject != null ? Selection.activeGameObject.GetComponent<HyperbolicStarfield>() : null;
            if (field == null)
            {
                var fields = UnityEngine.Object.FindObjectsByType<HyperbolicStarfield>(FindObjectsSortMode.None);
                if (fields.Length == 1) field = fields[0];
            }
            if (field == null) { Debug.LogError("Select the Hyperbolic Starfield in the space scene."); return; }
            var travel = field.GetComponent<HyperbolicSceneTravel>();
            if (travel == null) travel = Undo.AddComponent<HyperbolicSceneTravel>(field.gameObject);
            Undo.RecordObject(travel, "Configure scene travel");
            travel.starfield = field;
            if (travel.playerTransforms == null || travel.playerTransforms.Length == 0)
                travel.playerTransforms = FindPlayerTransforms();
            EditorUtility.SetDirty(travel);
            EditorSceneManager.MarkSceneDirty(field.gameObject.scene);
            Selection.activeGameObject = field.gameObject;
        }

        // Read public prefab references once in the editor. No runtime reflection or mover patch.
        static Transform[] FindPlayerTransforms()
        {
            MonoBehaviour player = null;
            foreach (var behaviour in UnityEngine.Object.FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None))
            {
                if (behaviour.GetType().Name != "mover") continue;
                if (player != null) return Array.Empty<Transform>();
                player = behaviour;
            }
            if (player == null) return Array.Empty<Transform>();
            var result = new List<Transform> { player.transform };
            foreach (string name in new[] { "PlayerBody", "HeadCameraSetup", "PlayerCamera" })
            {
                var go = player.GetType().GetField(name)?.GetValue(player) as GameObject;
                if (go != null && !result.Contains(go.transform)) result.Add(go.transform);
            }
            result.Sort((a, b) => Depth(a).CompareTo(Depth(b)));
            return result.ToArray();
        }
        static int Depth(Transform t) { int depth = 0; while (t.parent != null) { depth++; t = t.parent; } return depth; }

        static void AddScenes(HyperbolicSceneTravel travel)
        {
            if (EditorApplication.isPlaying) return;
            string origin = travel.gameObject.scene.path;
            if (string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(travel.planetScene))
            { Debug.LogError("Save the space scene and select Planet Scene first."); return; }
            var scenes = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);
            foreach (string path in new[] { origin, travel.planetScene })
            {
                int index = scenes.FindIndex(s => s.path == path);
                if (index < 0) scenes.Add(new EditorBuildSettingsScene(path, true));
                else scenes[index] = new EditorBuildSettingsScene(path, true);
            }
            EditorBuildSettings.scenes = scenes.ToArray();
        }
    }
}
#endif
