using System;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

// Attach to the camera, not to WALL. Prefab pivot must be at the rear bottom edge.
[DisallowMultipleComponent]
[RequireComponent(typeof(Camera))]
public class RaycastCubeBuilder : MonoBehaviour
{
    public Camera rayCamera;
    public GameObject wallPrefab;
    public LayerMask surfaceMask = ~0;
    public float maxDistance = 1000f;
    [Min(0.01f)] public float thickness = 1f;
    [Min(0.01f)] public float height = 1f;
    [Min(0f)] public float growSpeed = 1f;
    [Min(0.001f)] public float minLength = 0.05f;
    [Tooltip("Local length axis of the imported prefab. Usually Z.")]
    public LengthAxis lengthAxis = LengthAxis.Z;
    public enum LengthAxis { X, Z }

    // Includes the active preview. Ctrl removes only that unfinished preview.
    public GameObject[] cubes = new GameObject[0];
    public bool IsBuilding => active != null;

    private GameObject active;
    private Vector3 pointA, pointB, modelSize;
    private float forwardSign;
    private Collider[] activeColliders;
    private bool[] colliderStates;
    private Renderer[] activeRenderers;
    private bool[] rendererStates;
    private bool validB;
    private readonly HashSet<Collider> ownColliders = new HashSet<Collider>();

    void Awake()
    {
        if (rayCamera == null) rayCamera = GetComponent<Camera>();
    }

    void Update()
    {
        Vector2 cursor;
        bool click, stop, grow;
#if ENABLE_INPUT_SYSTEM
        var mouse = Mouse.current;
        var keyboard = Keyboard.current;
        stop = keyboard != null && (keyboard.leftCtrlKey.isPressed || keyboard.rightCtrlKey.isPressed);
        if (stop) { FinishChain(); return; }
        if (mouse == null) return;
        cursor = mouse.position.ReadValue();
        click = mouse.leftButton.wasPressedThisFrame;
        grow = keyboard != null && (keyboard.numpadPlusKey.isPressed ||
            (keyboard.equalsKey.isPressed && (keyboard.leftShiftKey.isPressed || keyboard.rightShiftKey.isPressed)));
#elif ENABLE_LEGACY_INPUT_MANAGER
        stop = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        if (stop) { FinishChain(); return; }
        cursor = Input.mousePosition;
        click = Input.GetMouseButtonDown(0);
        grow = Input.GetKey(KeyCode.KeypadPlus) || Input.GetKey(KeyCode.Plus) ||
            (Input.GetKey(KeyCode.Equals) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)));
#else
        return;
#endif
#if ENABLE_INPUT_SYSTEM || ENABLE_LEGACY_INPUT_MANAGER
        if (rayCamera == null || wallPrefab == null) return;
        // '+' grows UP from the bottom pivot; width has its own inspector setting.
        if (grow) height = Mathf.Max(0.01f, height + growSpeed * Time.deltaTime);
        bool hit = TryHit(cursor, out Vector3 target);
        if (active == null)
        {
            if (click && hit) BeginSegment(target);
            return;
        }
        validB = hit && (target - pointA).sqrMagnitude >= minLength * minLength;
        SetPreviewVisible(validB);
        if (!validB) return;
        pointB = target;
        ApplyShape();
        if (click)
        {
            Vector3 nextA = pointB;
            CommitSegment();
            BeginSegment(nextA);
        }
		if(Input.GetKeyDown(KeyCode.LeftAlt))
		{
			mover.main().BuildRejimeDeactive();
		}
#endif
    }

    void BeginSegment(Vector3 start)
    {
        // The anchor position is assigned ONCE. It is never moved to the midpoint.
        active = Instantiate(wallPrefab, start, Quaternion.identity);
       // active.transform.position = start;
        //GameObject model = Instantiate(wallPrefab, active.transform.position,Quaternion.indentity);
      //  model.transform.localPosition = Vector3.zero;
        // Keep FBX root rotation and scale to preserve its axis/unit conversion.
       // model.transform.localRotation = wallPrefab.transform.localRotation;
      //  model.transform.localScale = wallPrefab.transform.localScale;
        pointA = pointB = start;
        if (!GetModelBounds(active.transform, out Bounds bounds))
        {
            Debug.LogError("Wall prefab must contain a MeshFilter with a mesh.", this);
            Destroy(active); active = null; return;
        }
        modelSize = bounds.size;
        if (modelSize.x < 0.00001f || modelSize.y < 0.00001f || modelSize.z < 0.00001f)
        {
            Debug.LogError("Wall mesh must have nonzero width, height and length.", this);
            Destroy(active); active = null; return;
        }
        float center = lengthAxis == LengthAxis.Z ? bounds.center.z : bounds.center.x;
        forwardSign = center < 0 ? -1f : 1f;
        float startEdge = lengthAxis == LengthAxis.Z
            ? (forwardSign > 0 ? bounds.min.z : bounds.max.z)
            : (forwardSign > 0 ? bounds.min.x : bounds.max.x);
        if (Mathf.Abs(startEdge) > 0.001f || Mathf.Abs(bounds.min.y) > 0.001f)
            Debug.LogWarning("Prefab pivot is not on the rear bottom edge for this Length Axis. Check prefab root and axis; pivot is not auto-recentered.", this);
        activeColliders = active.GetComponentsInChildren<Collider>(true);
        colliderStates = new bool[activeColliders.Length];
        for (int i = 0; i < activeColliders.Length; i++)
        {
            ownColliders.Add(activeColliders[i]);
            colliderStates[i] = activeColliders[i].enabled;
            activeColliders[i].enabled = false;
        }
        activeRenderers = active.GetComponentsInChildren<Renderer>(true);
        rendererStates = new bool[activeRenderers.Length];
        for (int i = 0; i < activeRenderers.Length; i++) rendererStates[i] = activeRenderers[i].enabled;
        if (cubes == null) cubes = new GameObject[0];
        Array.Resize(ref cubes, cubes.Length + 1);
        cubes[cubes.Length - 1] = active;
        validB = false;
        SetPreviewVisible(false);
    }

    void ApplyShape()
    {
        Vector3 direction = pointB - pointA;
        float length = direction.magnitude;
        Vector3 forward = direction / length;
        Vector3 up = Mathf.Abs(Vector3.Dot(forward, Vector3.up)) > 0.999f ? Vector3.forward : Vector3.up;
        Vector3 localForward = (lengthAxis == LengthAxis.Z ? Vector3.forward : Vector3.right) * forwardSign;
        active.transform.rotation = Quaternion.LookRotation(forward, up)
            * Quaternion.Inverse(Quaternion.LookRotation(localForward, Vector3.up));
        float w = Mathf.Max(0.01f, thickness), h = Mathf.Max(0.01f, height);
        active.transform.localScale = lengthAxis == LengthAxis.Z
            ? new Vector3(w / modelSize.x, h / modelSize.y, length / modelSize.z)
            : new Vector3(length / modelSize.x, h / modelSize.y, w / modelSize.z);
    }

    void CommitSegment()
    {
        SetPreviewVisible(true);
        for (int i = 0; i < activeColliders.Length; i++)
            if (activeColliders[i] != null) activeColliders[i].enabled = colliderStates[i];
        active = null;
        validB = false;
    }

    public void FinishChain()
    {
        if (active == null) return;
        for (int i = 0; i < activeColliders.Length; i++) ownColliders.Remove(activeColliders[i]);
        var kept = new List<GameObject>();
        foreach (GameObject cube in cubes) if (cube != null && cube != active) kept.Add(cube);
        cubes = kept.ToArray();
        Destroy(active);
        active = null;
        validB = false;
    }

    void OnDisable() { FinishChain(); }

    void SetPreviewVisible(bool visible)
    {
        for (int i = 0; i < activeRenderers.Length; i++)
            if (activeRenderers[i] != null) activeRenderers[i].enabled = visible && rendererStates[i];
    }

    bool TryHit(Vector2 cursor, out Vector3 point)
    {
        Ray ray = Cursor.lockState == CursorLockMode.Locked
            ? rayCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0))
            : rayCamera.ScreenPointToRay(cursor);
        float nearest = float.PositiveInfinity;
        point = default;
        bool found = false;
        foreach (RaycastHit hit in Physics.RaycastAll(ray, maxDistance, surfaceMask, QueryTriggerInteraction.Ignore))
        {
            if (ownColliders.Contains(hit.collider) || hit.distance >= nearest) continue;
            nearest = hit.distance; point = hit.point; found = true;
        }
        return found;
    }

    static bool GetModelBounds(Transform root, out Bounds result)
    {
        result = default;
        bool found = false;
        foreach (MeshFilter filter in root.GetComponentsInChildren<MeshFilter>(true))
        {
            if (filter.sharedMesh == null) continue;
            Bounds b = filter.sharedMesh.bounds;
            Matrix4x4 matrix = root.worldToLocalMatrix * filter.transform.localToWorldMatrix;
            for (int i = 0; i < 8; i++)
            {
                Vector3 corner = b.center + Vector3.Scale(b.extents,
                    new Vector3((i & 1) == 0 ? -1 : 1, (i & 2) == 0 ? -1 : 1, (i & 4) == 0 ? -1 : 1));
                Vector3 p = matrix.MultiplyPoint3x4(corner);
                if (!found) { result = new Bounds(p, Vector3.zero); found = true; }
                else result.Encapsulate(p);
            }
        }
        return found;
    }
}
