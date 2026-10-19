using System;
using UnityEngine;
using UnityEngine.EventSystems;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Unauticna.HyperbolicSpace
{
    // Restore once in Awake, then once after the existing player's Start/Update.
    [DefaultExecutionOrder(30000), DisallowMultipleComponent]
    public sealed class HyperbolicSceneTravel : MonoBehaviour
    {
        public HyperbolicStarfield starfield;
        [Tooltip("Existing planet scene, with your playerhyperbolic prefab already placed in it.")]
        public string planetScene = "";
        [Tooltip("Keep this ID unchanged in the saved space scene. Use unique IDs for multiple cameras.")]
        public string travelId = "Space";
        [Tooltip("Optional: player root/body/head transforms to restore, parents before children. Camera is always saved.")]
        public Transform[] playerTransforms = Array.Empty<Transform>();
        public bool interactionsEnabled = true;
        [Min(1)] public float clickDistance = 100f;
        public bool showReturnButton = true;
        public bool returnOnBackspace = true;

        public HyperbolicCamera3D SpaceCamera => starfield != null ? starfield.hyperbolicCamera : null;
        public static bool IsLoading => HyperbolicSceneSession.IsBusy;
        public static bool CanReturn => HyperbolicSceneSession.CanReturn;
        public static bool TryGetPlanet(out StarDescriptor planet) => HyperbolicSceneSession.TryGetPlanet(out planet);
        public static void ReturnToSpace() => HyperbolicSceneSession.ReturnToSpace();

        void Reset() { starfield = GetComponent<HyperbolicStarfield>(); }
        void Awake()
        {
            if (starfield == null) starfield = GetComponent<HyperbolicStarfield>();
            HyperbolicSceneSession.PrepareRestore(this);
        }
        void LateUpdate() => HyperbolicSceneSession.FinishRestore(this);

        void Update()
        {
            if (!interactionsEnabled || IsLoading || !Application.isFocused || Time.timeScale <= 0) return;
            var space = SpaceCamera;
            if (space == null || !space.enabled || !space.inputEnabled || space.ViewCamera == null) return;
#if ENABLE_INPUT_SYSTEM
            var mouse = Mouse.current;
            if (mouse == null || !mouse.leftButton.wasPressedThisFrame) return;
            global::UnityEngine.Vector2 pointer = mouse.position.ReadValue();
#else
            if (!Input.GetMouseButtonDown(0)) return;
            global::UnityEngine.Vector2 pointer = new global::UnityEngine.Vector2(Input.mousePosition.x, Input.mousePosition.y);
#endif
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;
            var camera = space.ViewCamera;
            if (!camera.enabled) return;
            if (Cursor.lockState == CursorLockMode.Locked) pointer = camera.pixelRect.center;
            if (!camera.pixelRect.Contains(pointer)) return;
            var ray = camera.ScreenPointToRay(new Vector3(pointer.x, pointer.y, 0));
            if (starfield.TryPickPlanet(ray, Mathf.Max(1, clickDistance), out var star)) Visit(star);
        }

        public void Visit(StarDescriptor planet)
        {
            try { HyperbolicSceneSession.Visit(this, planet); }
            catch (Exception error) { Debug.LogException(error, this); }
        }
    }
}
