using System.Collections.Generic;
using UnityEngine;
using Unauticna.Mechanics;

public class RTSVisibleHighlight : MonoBehaviour
{
    public Camera rtsCamera;
    public Material highlightMaterial;
    public LayerMask objectLayers;
    public float checkDistance = 500f;
    public PolygonSyncWrite counter;
    [Min(0.05f)] public float checkInterval = 0.1f;
    [Min(0.2f)] public float discoveryInterval = 1f;
    Renderer[] candidates = new Renderer[0];
    readonly Plane[] planes = new Plane[6];
    HashSet<Renderer> visible = new HashSet<Renderer>(), previous = new HashSet<Renderer>();
    float next, discoverAt;
    void Awake() { PlayerMechanics.Register(this, MechanicId.PolygonSync); }
    void OnEnable() { next = discoverAt = 0; }
    void Update()
    {
        if (Time.unscaledTime < next || rtsCamera == null || counter == null) return;
        next = Time.unscaledTime + Mathf.Max(0.05f, checkInterval);
        if (Time.unscaledTime >= discoverAt)
        { discoverAt = Time.unscaledTime + Mathf.Max(0.2f, discoveryInterval); candidates = FindObjectsByType<Renderer>(FindObjectsSortMode.None); }
        GeometryUtility.CalculateFrustumPlanes(rtsCamera, planes); // Once per scan, not once per object.
        visible.Clear(); Vector3 position = rtsCamera.transform.position; float distance2 = checkDistance * checkDistance;
        foreach (var rend in candidates)
        {
            if (rend == null || !rend.enabled || !rend.gameObject.activeInHierarchy || ((1 << rend.gameObject.layer) & objectLayers.value) == 0) continue;
            if (rend.bounds.SqrDistance(position) > distance2 || !GeometryUtility.TestPlanesAABB(planes, rend.bounds)) continue;
            visible.Add(rend);
            if (!previous.Contains(rend)) { counter.AddObject(rend.gameObject); counter.AddObject(rend.gameObject, true); }
        }
        foreach (var rend in previous) if (rend != null && !visible.Contains(rend))
        { counter.RemoveObject(rend.gameObject); counter.RemoveObject(rend.gameObject, true); }
        var swap = previous; previous = visible; visible = swap;
    }
    void OnDisable()
    {
        if (counter != null) foreach (var rend in previous) if (rend != null)
        { counter.RemoveObject(rend.gameObject); counter.RemoveObject(rend.gameObject, true); }
        previous.Clear(); visible.Clear(); candidates = new Renderer[0];
    }
    void OnDestroy() { PlayerMechanics.Unregister(this); }
}
