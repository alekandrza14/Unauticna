using System;
using UnityEngine;
using UnityEngine.SceneManagement;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace Unauticna.HyperbolicSpace
{
    // Only this small return ticket survives LoadSceneMode.Single. Players/scenes do not.
    [AddComponentMenu("")]
    public sealed class HyperbolicSceneSession : MonoBehaviour
    {
        static HyperbolicSceneSession instance;
        ReturnTicket ticket;
        AsyncOperation loading;
        bool returning, restoreFailed;
        bool restoreWarned;
        float restoreDeadline;
        HyperbolicSceneTravel arrival;
        HyperbolicCamera3D departingCamera;

        internal static bool IsBusy => instance != null && (instance.loading != null || instance.returning);
        internal static bool CanReturn => instance != null && instance.ticket != null && !IsBusy;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void ResetSession() { instance = null; }

        void Awake()
        {
            if (instance != null && instance != this) { Destroy(gameObject); return; }
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        internal static bool TryGetPlanet(out StarDescriptor planet)
        {
            if (instance != null && instance.ticket != null && !instance.returning)
            { planet = instance.ticket.Planet; return true; }
            planet = default; return false;
        }

        internal static void Visit(HyperbolicSceneTravel source, StarDescriptor planet)
        {
            if (IsBusy || (instance != null && instance.ticket != null)) return;
            var camera = source.SpaceCamera;
            if (camera == null || camera.ViewCamera == null)
                throw new InvalidOperationException("Assign the initialized Hyperbolic Starfield / Camera.");
            string destination = (source.planetScene ?? "").Trim();
            string origin = source.gameObject.scene.path;
            CheckScene(origin);
            CheckScene(destination);
            if (SceneUtility.GetBuildIndexByScenePath(destination) == source.gameObject.scene.buildIndex ||
                destination == origin || destination == source.gameObject.scene.name)
                throw new InvalidOperationException("Select a separate existing planet scene.");
            if (string.IsNullOrWhiteSpace(source.travelId)) throw new InvalidOperationException("Travel ID is empty.");
            var saved = ReturnTicket.Capture(source, planet);
            if (instance == null) new GameObject("Hyperbolic scene return ticket").AddComponent<HyperbolicSceneSession>();
            var session = instance;
            session.ticket = saved;
            session.restoreFailed = false;
            session.departingCamera = camera;
            camera.inputEnabled = false;
            try
            {
                session.loading = SceneManager.LoadSceneAsync(destination, LoadSceneMode.Single);
                if (session.loading == null) throw new InvalidOperationException("Unity could not start loading the planet scene.");
            }
            catch
            {
                camera.inputEnabled = saved.InputEnabled;
                session.ticket = null; session.loading = null; session.departingCamera = null;
                throw;
            }
        }

        static void CheckScene(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !Application.CanStreamedLevelBeLoaded(path))
                throw new InvalidOperationException("Save and enable this scene in the active Build Profile Scene List: " + path);
        }

        public static void ReturnToSpace()
        {
            if (!CanReturn) return;
            var session = instance;
            try
            {
                CheckScene(session.ticket.ScenePath);
                session.returning = true; session.restoreFailed = false;
                session.restoreWarned = false; session.restoreDeadline = Time.unscaledTime + 15f;
                session.loading = SceneManager.LoadSceneAsync(session.ticket.ScenePath, LoadSceneMode.Single);
                if (session.loading == null) throw new InvalidOperationException("Unity could not start loading the space scene.");
            }
            catch (Exception error)
            {
                session.returning = false; session.loading = null;
                Debug.LogException(error, session); // Keep the ticket so the player can retry.
            }
        }

        bool Matches(HyperbolicSceneTravel target) => ticket != null &&
            target.gameObject.scene.path == ticket.ScenePath && target.travelId == ticket.TravelId &&
            target.gameObject.scene.handle != ticket.DepartureHandle;

        internal static void PrepareRestore(HyperbolicSceneTravel target)
        {
            var session = instance;
            if (session == null || session.restoreFailed || !session.Matches(target)) return;
            if (target.SpaceCamera == null || target.SpaceCamera.ViewCamera == null) return;
            try
            {
                if (session.arrival != null && session.arrival != target)
                    throw new InvalidOperationException("Duplicate Travel ID in the space scene: " + target.travelId);
                session.arrival = target; session.returning = true;
                session.ticket.Apply(target);
                target.SpaceCamera.inputEnabled = false;
            }
            catch (Exception error) { session.RestoreError(error, target); }
        }

        internal static void FinishRestore(HyperbolicSceneTravel target)
        {
            var session = instance;
            if (session == null || session.restoreFailed || !session.Matches(target)) return;
            if (session.arrival == null) PrepareRestore(target); // Also handles a player spawned later.
            if (session.restoreFailed || session.arrival != target) return;
            if (session.loading != null && !session.loading.isDone) return;
            try
            {
                session.ticket.Apply(target); // Existing mover.Start/Update have now run.
                target.SpaceCamera.inputEnabled = session.ticket.InputEnabled;
                session.ticket = null; session.loading = null; session.returning = false;
                session.arrival = null; session.departingCamera = null;
            }
            catch (Exception error) { session.RestoreError(error, target); }
        }

        void RestoreError(Exception error, HyperbolicSceneTravel target)
        {
            restoreFailed = true; returning = false; loading = null;
            if (target.SpaceCamera != null) target.SpaceCamera.inputEnabled = ticket.InputEnabled;
            Debug.LogException(error, target);
        }

        void Update()
        {
            if (loading != null && loading.isDone)
            { loading = null; departingCamera = null; restoreDeadline = Time.unscaledTime + 15f; }
            if (returning && loading == null && !restoreWarned && Time.unscaledTime > restoreDeadline)
            {
                restoreWarned = true;
                Debug.LogError("Waiting for HyperbolicSceneTravel / initialized camera in the space scene. Check Travel ID: " + ticket.TravelId, this);
            }
            if (!CanReturn || !ticket.ReturnOnBackspace || !Application.isFocused) return;
#if ENABLE_INPUT_SYSTEM
            bool pressed = Keyboard.current != null && Keyboard.current.backspaceKey.wasPressedThisFrame;
#else
            bool pressed = Input.GetKeyDown(KeyCode.Backspace);
#endif
            if (pressed) ReturnToSpace();
        }

        void OnGUI()
        {
            if (ticket == null) return;
            if (loading != null) GUI.Box(new Rect(12, 12, 250, 32), "Загрузка сцены…");
            else if (CanReturn && ticket.ShowReturnButton &&
                GUI.Button(new Rect(Screen.width - 202, 12, 190, 32), "Вернуться в космос")) ReturnToSpace();
        }

        void OnDestroy()
        {
            if (instance != this) return;
            if (departingCamera != null && ticket != null) departingCamera.inputEnabled = ticket.InputEnabled;
            instance = null;
        }

        sealed class ReturnTicket
        {
            public string ScenePath, TravelId, CameraJson;
            public int DepartureHandle;
            public float Curvature;
            public bool InputEnabled, ShowReturnButton, ReturnOnBackspace;
            public Vector3 CameraPosition;
            public StarDescriptor Planet;
            public Pose[] PlayerPoses;

            public static ReturnTicket Capture(HyperbolicSceneTravel source, StarDescriptor planet)
            {
                var targets = source.playerTransforms ?? Array.Empty<Transform>();
                var poses = new Pose[targets.Length];
                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] == null) throw new InvalidOperationException("Player Transforms contains an empty slot.");
                    poses[i] = new Pose(targets[i]);
                }
                var camera = source.SpaceCamera;
                return new ReturnTicket {
                    ScenePath = source.gameObject.scene.path, DepartureHandle = source.gameObject.scene.handle,
                    TravelId = source.travelId, CameraJson = camera.SaveStateJson(), Curvature = camera.curvatureRadius,
                    CameraPosition = camera.transform.position, InputEnabled = camera.inputEnabled,
                    ShowReturnButton = source.showReturnButton, ReturnOnBackspace = source.returnOnBackspace,
                    Planet = planet, PlayerPoses = poses
                };
            }

            public void Apply(HyperbolicSceneTravel target)
            {
                var transforms = target.playerTransforms ?? Array.Empty<Transform>();
                if (transforms.Length != PlayerPoses.Length)
                    throw new InvalidOperationException("Player Transforms changed: keep the saved space scene configuration.");
                for (int i = 0; i < transforms.Length; i++)
                    if (transforms[i] == null) throw new InvalidOperationException("Assign the missing Player Transform before restoring.");
                for (int i = 0; i < transforms.Length; i++) PlayerPoses[i].Apply(transforms[i]);
                var camera = target.SpaceCamera;
                camera.curvatureRadius = Curvature;
                camera.transform.position = CameraPosition;
                camera.LoadStateJson(CameraJson);
            }
        }

        struct Pose
        {
            Vector3 position, velocity, angularVelocity;
            Quaternion rotation;
            bool hasVelocity;
            public Pose(Transform target)
            {
                position = target.localPosition; rotation = target.localRotation;
                var body = target.GetComponent<Rigidbody>();
                hasVelocity = body != null && !body.isKinematic;
                velocity = hasVelocity ? body.linearVelocity : Vector3.zero;
                angularVelocity = hasVelocity ? body.angularVelocity : Vector3.zero;
            }
            public void Apply(Transform target)
            {
                var controller = target.GetComponent<CharacterController>();
                bool active = controller != null && controller.enabled;
                if (active) controller.enabled = false;
                try
                {
                    target.localPosition = position; target.localRotation = rotation;
                    var body = target.GetComponent<Rigidbody>();
                    if (body != null)
                    {
                        body.position = target.position; body.rotation = target.rotation;
                        if (hasVelocity && !body.isKinematic)
                        { body.linearVelocity = velocity; body.angularVelocity = angularVelocity; }
                    }
                }
                finally { if (active) controller.enabled = true; }
            }
        }
    }
}
