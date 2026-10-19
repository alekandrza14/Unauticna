using System;
using System.Reflection;
using UnityEngine;
using Unauticna.Mechanics;

[DefaultExecutionOrder(-500)]
public class MainRay : MonoBehaviour
{
    public static RaycastHit MainHit, SecondHit, RayMarhHit;
    public static bool HitError;
    public static Ray Ray;
    public static MainRay Instance { get; private set; }
    [Min(1f)] public float maxDistance = 1000f;
    public LayerMask layers = Physics.DefaultRaycastLayers;
    [Min(0.02f)] public float raymarchInterval = 0.1f;
    [Tooltip("Optional component with RaycastHit GetMarchCast(Vector3, Vector3). Leave empty for automatic lookup.")]
    public MonoBehaviour marchCollider;
    delegate RaycastHit MarchCast(Vector3 origin, Vector3 direction);
    MonoBehaviour boundCollider;
    MarchCast marchCast;
    static bool providerTypeResolved;
    static Type providerType;
    float nextMarch, nextResolve;
    int physicsFrame = -1, marchFrame = -1;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetProviderCache() { providerTypeResolved = false; providerType = null; Instance = null; }
    void Awake() { Instance = this; Clear(); }
    void OnEnable() { nextResolve = 0f; }
    void Update()
    {
        if (PlayerMechanics.GameplayBlocked) { Clear(); return; }
        Refresh(false);
        if (Input.GetKeyDown(KeyCode.E) && SecondHit.collider != null)
            SecondHit.collider.gameObject.SendMessage("OnInteractive", SendMessageOptions.DontRequireReceiver);
    }
    public static void RefreshNow(bool includeMarch = false)
    {
        if (Instance == null || !Instance.isActiveAndEnabled || PlayerMechanics.GameplayBlocked) return;
        // A mover may have rotated the camera after this component's Update.
        Instance.physicsFrame = -1;
        if (includeMarch) Instance.marchFrame = -1;
        Instance.Refresh(includeMarch);
    }
    void Refresh(bool forceMarch)
    {
        if (physicsFrame != Time.frameCount)
        {
            physicsFrame = Time.frameCount;
            Ray = GameManager.pprey();
            MainHit = SecondHit = default; HitError = true;
            if (Physics.Raycast(Ray, out var hit, maxDistance, layers, QueryTriggerInteraction.UseGlobal))
            {
                SecondHit = hit;
                // The first surface still receives E. Layer 8 is transparent only for the main selection ray.
                if (hit.collider.gameObject.layer == 8)
                {
                    if (Physics.Raycast(Ray, out var behind, maxDistance, layers.value & ~(1 << 8), QueryTriggerInteraction.UseGlobal))
                        MainHit = behind;
                }
                else
                {
                    if (hit.collider.isTrigger && hit.collider.gameObject.layer == 3)
                        hit.point = hit.collider.transform.position + new Vector3(Global.Random.Range(-3f, 3f), Global.Random.Range(-3f, 3f), Global.Random.Range(-3f, 3f));
                    MainHit = hit;
                }
                HitError = MainHit.collider == null;
            }
        }
        if (!PlayerMechanics.Active(MechanicId.RaymarchPick)) { ClearMarch(); return; }
        if (marchFrame == Time.frameCount || (!forceMarch && Time.unscaledTime < nextMarch)) return;
        nextMarch = Time.unscaledTime + Mathf.Max(0.02f, raymarchInterval); marchFrame = Time.frameCount;
        if (marchCollider == null && Time.unscaledTime >= nextResolve)
        {
            nextResolve = Time.unscaledTime + 1f;
            Type type = ResolveProviderType();
            if (type != null)
            {
                marchCollider = GetComponentInParent(type) as MonoBehaviour;
                if (marchCollider == null) marchCollider = UnityEngine.Object.FindFirstObjectByType(type) as MonoBehaviour;
            }
        }
        BindProvider();
        if (marchCollider != null && marchCollider.isActiveAndEnabled && marchCast != null)
        {
            // A cached delegate: no reflection, argument arrays or boxing for each cast.
            RayMarhHit = marchCast(Ray.origin, Ray.direction);
            if (Globalprefs.RaymarchHitError) RayMarhHit = new RaycastHit { distance = float.PositiveInfinity };
        }
        else ClearMarch();
    }
    void BindProvider()
    {
        if (ReferenceEquals(boundCollider, marchCollider)) return;
        boundCollider = marchCollider; marchCast = null;
        if (marchCollider == null) return;
        MethodInfo method = MarchMethod(marchCollider.GetType());
        if (method != null)
            marchCast = Delegate.CreateDelegate(typeof(MarchCast), marchCollider, method, false) as MarchCast;
        if (marchCast == null)
            Debug.LogWarning("MainRay: optional raymarch component must expose public RaycastHit GetMarchCast(Vector3, Vector3).", marchCollider);
    }
    static MethodInfo MarchMethod(Type type)
    {
        MethodInfo method = type.GetMethod("GetMarchCast", BindingFlags.Instance | BindingFlags.Public,
            null, new[] { typeof(Vector3), typeof(Vector3) }, null);
        return method != null && method.ReturnType == typeof(RaycastHit) && !method.ContainsGenericParameters ? method : null;
    }
    static Type ResolveProviderType()
    {
        if (providerTypeResolved) return providerType;
        providerTypeResolved = true;
        // Optional plugin: resolve once, only when raymarch.pick is actually enabled.
        // Matching the short name also supports a plugin located in its own namespace/assembly.
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            if (assembly.IsDynamic) continue;
            Type[] types;
            try { types = assembly.GetTypes(); }
            catch (ReflectionTypeLoadException ex) { types = ex.Types; }
            foreach (Type type in types)
                if (type != null && type.Name == "PlayerRayMarchCollider" && !type.IsAbstract
                    && !type.ContainsGenericParameters && typeof(MonoBehaviour).IsAssignableFrom(type) && MarchMethod(type) != null)
                    return providerType = type;
        }
        return null;
    }
    static void ClearMarch()
    { RayMarhHit = new RaycastHit { distance = float.PositiveInfinity }; Globalprefs.RaymarchHitError = true; }
    static void Clear() { MainHit = SecondHit = default; HitError = true; ClearMarch(); }
    void OnDisable() { boundCollider = null; marchCast = null; if (Instance == this) Clear(); }
    void OnDestroy() { boundCollider = null; marchCast = null; if (Instance == this) { Clear(); Instance = null; } }
}
