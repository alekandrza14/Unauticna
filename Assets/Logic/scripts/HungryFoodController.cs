using Unauticna.Mechanics;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Add to the player. Automatic actions use ElementalInventory's real pickup/eating methods.
[DefaultExecutionOrder(-100)]
[DisallowMultipleComponent]
public sealed class HungryFoodController : MonoBehaviour
{
    public StaticEcsNeeds needs;
    public mover playerMover;
    public ElementalInventory inventory;
    public Rigidbody playerBody;
    public Camera playerCamera;
    [Tooltip("Additional scripts that read movement/interaction input.")]
    public Behaviour[] additionalControls;

    [Range(0f, 100f)] public float hungerThreshold = 20f;
    [Min(0.1f)] public float searchRadius = 10f;
    [Min(0.1f)] public float pickupDistance = 2f;
    [Min(0.1f)] public float walkSpeed = 3f;
    [Min(1f)] public float turnSpeed = 240f;
    [Min(0.1f)] public float biteInterval = 0.65f;
    [Min(0.1f)] public float searchInterval = 0.75f;
    [Min(1f)] public float stuckTimeout = 5f;
    [Min(1f)] public float attemptTimeout = 25f;
    public bool useNavMeshIfAvailable = true;
    public LayerMask foodLayers = ~0;
    public bool drawCenterDot = true;

    public bool IsControlling { get; private set; }
    public string Status { get; private set; } = "Ожидание";
    public static bool AnyActive { get; private set; }
    private static HungryFoodController owner;
    private enum Step { Approach, Eat }
    private Step step;
    private Collider target;
    private int foodCell = -1, oldSelection;
    private float nextSearch, nextBite, startedAt, lastProgress;
    private Vector3 progressPosition, desiredVelocity, lastAim, cameraOffset;
    private Vector3 up;
    private Vector3[] corners;
    private int corner;
    private bool oldPaused, oldCursorVisible, oldGravity;
    private float oldDamping;
    private RigidbodyConstraints oldConstraints;
    private CursorLockMode oldCursorLock;
    private readonly List<Behaviour> disabled = new List<Behaviour>();
    private readonly Dictionary<int, float> rejected = new Dictionary<int, float>();

    private Collider[] foodCandidates = new Collider[128];
    private IComparer<Collider> foodComparer;
    private void Awake() { PlayerMechanics.Register(this, MechanicId.AutoEat); }
    private void Start() { ResolveReferences(); foodComparer = Comparer<Collider>.Create((a, b) => DistanceSquared(a).CompareTo(DistanceSquared(b))); }

    private void ResolveReferences()
    {
        if (needs == null) needs = GetComponent<StaticEcsNeeds>();
        if (needs == null) needs = FindFirstObjectByType<StaticEcsNeeds>();
        if (playerMover == null && needs != null) playerMover = needs.playerMover;
        if (playerMover == null) playerMover = GetComponent<mover>();
        if (inventory == null) inventory = ElementalInventory.main();
        if (playerBody == null && playerMover != null) playerBody = playerMover.GetComponent<Rigidbody>();
        if (playerCamera == null && playerMover != null && playerMover.PlayerCamera != null)
            playerCamera = playerMover.PlayerCamera.GetComponent<Camera>();
    }

    private void Update()
    {
        try { Tick(); }
        catch (Exception ex)
        {
            Debug.LogException(ex, this);
            RejectTarget();
            Release("Ошибка действия — управление возвращено");
        }
    }

    private void Tick()
    {
        if (PlayerMechanics.GameplayBlocked) { if (IsControlling) Release("Автоеда приостановлена"); return; }

        if (!IsControlling)
        {
            if (Time.unscaledTime < nextSearch || owner != null) return;
            nextSearch = Time.unscaledTime + Mathf.Max(0.1f, searchInterval);
            ResolveReferences();
            if (!CanStart()) return;
            if (needs.GetValues().Food >= hungerThreshold) { Status = "Сытость в норме"; return; }
            foodCell = inventory.FindEmptyFoodCell();
            if (foodCell < 0) { Status = "Нет свободной ячейки"; return; }
            if (!FindNearestFood()) { Status = "Рядом нет доступной еды"; return; }
            TakeControl();
        }
        if (needs == null || !needs.isActiveAndEnabled || playerMover == null
            || playerBody == null || playerCamera == null || inventory == null)
        { Release("Игрок недоступен"); return; }
        if (!Application.isFocused || Globalprefs.Pause || Time.timeScale <= 0f || playerMover.NeedsRest)
        { Release("Автоеда прервана"); return; }
        if (needs.GetValues().Food >= hungerThreshold)
        { Release("Поел — управление возвращено"); return; }
        if (Time.unscaledTime - startedAt > Mathf.Max(1f, attemptTimeout))
        { RejectTarget(); Release("Не удалось добраться до еды"); return; }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GlobalInputMenager.KeyCode_eat = 0;
        if (step == Step.Eat)
        {
            desiredVelocity = Vector3.zero;
            if (Time.unscaledTime < nextBite) return;
            nextBite = Time.unscaledTime + Mathf.Max(0.1f, biteInterval);
            if (!inventory.CanAutoEatCell(foodCell) || !inventory.TryAutoEatCell(foodCell))
            { Release("Еда закончилась"); return; }
            if (needs.GetValues().Food >= hungerThreshold) Release("Поел — управление возвращено");
            return;
        }
        if (target == null || !target.enabled || !target.gameObject.activeInHierarchy)
        { Release("Еда исчезла"); return; }
        if ((target.ClosestPoint(playerBody.position) - playerBody.position).sqrMagnitude > searchRadius * searchRadius)
        { RejectTarget(); Release("Еда вышла из радиуса поиска"); return; }
        lastAim = target.bounds.center;
        Vector3 destination = NextDestination();
        Vector3 horizontal = Vector3.ProjectOnPlane(destination - playerBody.position, up);
        desiredVelocity = horizontal.sqrMagnitude > 0.0025f ? horizontal.normalized * Mathf.Max(0.1f, walkSpeed) : Vector3.zero;
        if ((playerBody.position - progressPosition).sqrMagnitude > 0.04f)
        { progressPosition = playerBody.position; lastProgress = Time.unscaledTime; }
        if (Time.unscaledTime - lastProgress > Mathf.Max(1f, stuckTimeout))
        { RejectTarget(); Release("Путь к еде заблокирован"); }
    }

    private bool CanStart()
    {
        return Application.isFocused && !Globalprefs.Pause && Time.timeScale > 0f
            && needs != null && needs.isActiveAndEnabled && !needs.paused
            && playerMover != null && playerMover.isActiveAndEnabled && !playerMover.NeedsRest
            && inventory != null && inventory.isActiveAndEnabled && !inventory.nosell
            && playerBody != null && !playerBody.isKinematic && playerCamera != null;
    }

    private bool FindNearestFood()
    {
        target = null;
        int count = Physics.OverlapSphereNonAlloc(playerBody.position, searchRadius, foodCandidates, foodLayers, QueryTriggerInteraction.Collide);
        Collider[] candidates = foodCandidates;
        if (count == foodCandidates.Length)
        {
            // A full NonAlloc buffer is not guaranteed to contain the nearest colliders.
            candidates = Physics.OverlapSphere(playerBody.position, searchRadius, foodLayers, QueryTriggerInteraction.Collide);
            count = candidates.Length;
            if (count <= 4096) foodCandidates = new Collider[Mathf.NextPowerOfTwo(count + 1)];
        }
        Array.Sort(candidates, 0, count, foodComparer);
        for (int candidateIndex = 0; candidateIndex < count; candidateIndex++)
        {
            var candidate = candidates[candidateIndex];
            if (candidate == null || IsPlayer(candidate)) continue;
            if (rejected.TryGetValue(candidate.GetInstanceID(), out float until) && until > Time.unscaledTime) continue;
            if (!inventory.TryDescribeAutoFood(candidate, out _)) continue;
            if (!BuildPath(candidate)) continue;
            target = candidate;
            return true;
        }
        return false;
    }

    private float DistanceSquared(Collider candidate)
    {
        return candidate == null ? float.PositiveInfinity
            : (candidate.ClosestPoint(playerBody.position) - playerBody.position).sqrMagnitude;
    }

    private bool IsPlayer(Collider candidate)
    {
        return candidate.attachedRigidbody == playerBody || candidate.transform.IsChildOf(playerMover.transform);
    }

    private bool BuildPath(Collider candidate)
    {
        corners = null;
        corner = 0;
        if (!useNavMeshIfAvailable || !NavMesh.SamplePosition(playerBody.position, out var from, 2f, NavMesh.AllAreas))
            return true; // No baked NavMesh: walk directly, keeping Rigidbody collision detection.
        if (!NavMesh.SamplePosition(candidate.bounds.center, out var to, 2f, NavMesh.AllAreas)) return false;
        var path = new NavMeshPath();
        if (!NavMesh.CalculatePath(from.position, to.position, NavMesh.AllAreas, path)
            || path.status != NavMeshPathStatus.PathComplete) return false;
        corners = path.corners;
        corner = corners.Length > 1 ? 1 : 0;
        return true;
    }

    private Vector3 NextDestination()
    {
        if (corners == null || corners.Length == 0 || corner >= corners.Length) return lastAim;
        while (corner < corners.Length && Vector3.ProjectOnPlane(corners[corner] - playerBody.position, up).sqrMagnitude < 0.16f)
            corner++;
        return corner < corners.Length ? corners[corner] : lastAim;
    }

    private void TakeControl()
    {
        oldPaused = needs.paused;
        oldSelection = inventory.select;
        oldCursorLock = Cursor.lockState;
        oldCursorVisible = Cursor.visible;
        oldGravity = playerBody.useGravity;
        oldDamping = playerBody.linearDamping;
        oldConstraints = playerBody.constraints;
        up = playerMover.transform.up;
        cameraOffset = playerMover.transform.InverseTransformPoint(playerCamera.transform.position);
        IsControlling = true;
        owner = this;
        AnyActive = true;
        // Also prevents Russianfood from starting its zero-food movie during this action.
        needs.paused = true;
        inventory.playerNeeds = needs;
        DisableControl(playerMover);
        DisableControl(inventory);
        if (additionalControls != null)
            foreach (var control in additionalControls) DisableControl(control);
        playerBody.constraints |= RigidbodyConstraints.FreezeRotation;
        playerBody.useGravity = false;
        playerBody.linearDamping = 0f;
        playerBody.linearVelocity = Vector3.zero;
        playerBody.angularVelocity = Vector3.zero;
        inventory.select = foodCell;
        if (inventory.selectobject != null) inventory.selectobject.transform.position = inventory.Cells[foodCell].transform.position;
        startedAt = lastProgress = Time.unscaledTime;
        progressPosition = playerBody.position;
        step = Step.Approach;
        Status = "Идём к еде";
    }

    private void DisableControl(Behaviour control)
    {
        if (control == null || control == this || control == needs || control is Camera
            || control is AudioListener || !control.enabled) return;
        disabled.Add(control);
        control.enabled = false;
    }

    private void FixedUpdate()
    {
        if (!IsControlling || playerBody == null || playerBody.isKinematic) return;
        if (Globalprefs.Pause || !Application.isFocused || Time.timeScale <= 0f)
        { playerBody.linearVelocity = Vector3.zero; return; }
        Vector3 planar = desiredVelocity;
        if (planar.sqrMagnitude > 0.0001f)
        {
            // Stop before solid obstacles. This does not teleport through colliders.
            var hits = playerBody.SweepTestAll(planar.normalized, planar.magnitude * Time.fixedDeltaTime + 0.1f, QueryTriggerInteraction.Ignore);
            foreach (var hit in hits)
            {
                if (hit.collider == null || IsPlayer(hit.collider) || hit.collider == target) continue;
                if (Vector3.Dot(hit.normal, up) < 0.65f) { planar = Vector3.zero; break; }
            }
        }
        Vector3 vertical = Vector3.Project(playerBody.linearVelocity, up);
        playerBody.linearVelocity = planar + vertical;
        playerBody.AddForce(-up * Physics.gravity.magnitude, ForceMode.Acceleration);
    }

    private void LateUpdate()
    {
		if(inventory==null) inventory = boxItem.getInventoryMenager("i3");
        if (!IsControlling || playerCamera == null || playerMover == null) return;
        try
        {
            playerCamera.transform.position = playerMover.transform.TransformPoint(cameraOffset);
            Vector3 direction = lastAim - playerCamera.transform.position;
            Quaternion aimRotation = playerCamera.transform.rotation;
            if (direction.sqrMagnitude > 0.001f)
                aimRotation = Quaternion.RotateTowards(aimRotation,
                    Quaternion.LookRotation(direction, up), Mathf.Max(1f, turnSpeed) * Time.unscaledDeltaTime);
            // Set the rig first: if it is the camera's parent, rotating it also rotates the camera.
            if (playerMover.HeadCameraSetup != null)
                playerMover.HeadCameraSetup.transform.rotation = aimRotation;
            playerCamera.transform.SetPositionAndRotation(
                playerMover.transform.TransformPoint(cameraOffset), aimRotation);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (step != Step.Approach || target == null) return;

            // Aim through the actual center of the game camera, then invoke the pickup action.
            Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            var hits = Physics.RaycastAll(ray, pickupDistance, ~0, QueryTriggerInteraction.Collide);
            Array.Sort(hits, (a, b) => a.distance.CompareTo(b.distance));
            foreach (var hit in hits)
            {
                if (IsPlayer(hit.collider)) continue;
                if (hit.collider.isTrigger && hit.collider != target) continue;
                if (hit.collider != target) break; // A wall or another object blocks pickup.
                desiredVelocity = Vector3.zero;
                if (!inventory.TryPickupIntoCell(hit, foodCell))
                { RejectTarget(); Release("Не удалось подобрать еду"); return; }
                target = null;
                step = Step.Eat;
                nextBite = Time.unscaledTime + Mathf.Max(0.1f, biteInterval);
                Status = "Едим";
                break;
            }
        }
        catch (Exception ex) { Debug.LogException(ex, this); RejectTarget(); Release("Ошибка подбора"); }
    }

    private void RejectTarget()
    {
        if (target != null) rejected[target.GetInstanceID()] = Time.unscaledTime + 10f;
    }

    private void Release(string reason)
    {
        Status = reason;
        nextSearch = Time.unscaledTime + Mathf.Max(0.1f, searchInterval);
        if (!IsControlling) return;
        IsControlling = false;
        desiredVelocity = Vector3.zero;
        if (playerBody != null)
        {
            if (!playerBody.isKinematic) { playerBody.linearVelocity = Vector3.zero; playerBody.angularVelocity = Vector3.zero; }
            playerBody.constraints = oldConstraints;
            playerBody.useGravity = oldGravity;
            playerBody.linearDamping = oldDamping;
        }
        if (needs != null) needs.paused = oldPaused;
        if (inventory != null)
        {
            inventory.select = oldSelection;
            if (inventory.selectobject != null && inventory.Cells != null && oldSelection >= 0
                && oldSelection < inventory.Cells.Length && inventory.Cells[oldSelection] != null)
                inventory.selectobject.transform.position = inventory.Cells[oldSelection].transform.position;
        }
        GlobalInputMenager.KeyCode_eat = 0;
        Cursor.lockState = oldCursorLock;
        Cursor.visible = oldCursorVisible;
        foreach (var control in disabled) if (control != null) control.enabled = true;
        disabled.Clear();
        target = null;
        foodCell = -1;
        corners = null;
        if (owner == this) { owner = null; AnyActive = false; }
    }

    [ContextMenu("Test / Set Food to 19")]
    private void TestHungry()
    {
        if (!Application.isPlaying) return;
        ResolveReferences();
        if (needs == null || !needs.isActiveAndEnabled) return;
        var values = needs.GetValues();
        values.Food = 19f;
        needs.SetValues(values);
        nextSearch = 0f;
    }

    private void OnDisable() { Release("Автоеда отключена"); }
    private void OnDestroy() { Release("Автоеда отключена"); PlayerMechanics.Unregister(this); }
    private void OnApplicationFocus(bool focused) { if (!focused) Release("Игра потеряла фокус"); }

    private void OnGUI()
    {
        if (!IsControlling || !drawCenterDot) return;
        var color = GUI.color;
        GUI.color = Color.white;
        GUI.DrawTexture(new Rect(Screen.width * 0.5f - 2f, Screen.height * 0.5f - 2f, 4f, 4f), Texture2D.whiteTexture);
        GUI.color = color;
    }
}
