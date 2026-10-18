using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

// Shared by all MobNeedsCode instances. No Inspector references or extra components.
public static class MobFoodSearch
{
    public const float SearchInterval = 0.5f, FoodRefreshInterval = 1f;
    public const int MaxMobsPerBatch = 1024, ApplyPerFrame = 64, MaxWorkers = 4;
    private const double CellSize = 10.0;
    private static readonly List<MobNeedsCode> mobs = new List<MobNeedsCode>();
    private static readonly List<GameObject> food = new List<GameObject>();
    private static readonly HashSet<int> foodIds = new HashSet<int>();
    private static int cursor;
    private static float nextSearch, nextRefresh;
    private static Batch pending;

    // Only numbers cross the thread boundary; no GameObject, Transform or ECS access.
    internal struct Point
    {
        public double X, Y, Z, Radius;
        public int Owner, Scene;
    }
    internal sealed class StopFlag { public volatile bool Value; }
    internal sealed class Result { public int[] Targets; public Exception Error; }
    private sealed class Batch
    {
        public MobNeedsCode[] Mobs;
        public uint[] Epochs;
        public GameObject[] Food;
        public StopFlag Stop;
        public Task<Result> Job;
        public int Next;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void Reset()
    {
        if (pending != null) pending.Stop.Value = true;
        pending = null;
        mobs.Clear(); food.Clear(); foodIds.Clear();
        cursor = 0;
        nextSearch = nextRefresh = 0f;
    }

    internal static void Register(MobNeedsCode mob)
    {
        if (mob.FoodSlot >= 0 && mob.FoodSlot < mobs.Count && mobs[mob.FoodSlot] == mob) return;
        mob.FoodSlot = mobs.Count;
        mobs.Add(mob);
    }

    internal static void Unregister(MobNeedsCode mob)
    {
        int index = mob.FoodSlot;
        mob.FoodSlot = -1;
        if (index < 0 || index >= mobs.Count || mobs[index] != mob) return;
        int last = mobs.Count - 1;
        if (index != last)
        {
            mobs[index] = mobs[last];
            mobs[index].FoodSlot = index;
        }
        mobs.RemoveAt(last);
        if (mobs.Count == 0) Reset();
    }

    // Called once per frame, outside any ECS query, by MobNeedsCode.Update.
    internal static void Tick()
    {
        if (Globalprefs.Pause || Time.deltaTime <= 0f || mobs.Count == 0) return;
        if (pending != null)
        {
            if (pending.Job.IsCompleted) Apply(); // Never wait for a worker on the main thread.
            return;
        }
        if (Time.time < nextSearch) return;
        nextSearch = Time.time + SearchInterval;

        int capacity = Math.Min(MaxMobsPerBatch, mobs.Count);
        var selected = new List<MobNeedsCode>(capacity);
        var requests = new List<Point>(capacity);
        var epochs = new List<uint>(capacity);
        for (int checkedCount = 0; checkedCount < mobs.Count && selected.Count < MaxMobsPerBatch; checkedCount++)
        {
            if (cursor >= mobs.Count) cursor = 0;
            var mob = mobs[cursor++];
            if (mob == null || !mob.WantsFood || !Valid(mob.transform.position)) continue;
            selected.Add(mob);
            epochs.Add(mob.FoodEpoch);
            requests.Add(Snapshot(mob.transform.position, mob.GetInstanceID(), mob.gameObject.scene.handle,
                Radius(mob.foodSearchRadius)));
        }
        if (selected.Count == 0) return;
        var inventory = ElementalInventory.main();
        if (inventory == null) return;
        if (Time.time >= nextRefresh)
        {
            nextRefresh = Time.time + FoodRefreshInterval;
            food.Clear(); foodIds.Clear();
            foreach (var item in UnityEngine.Object.FindObjectsByType<itemName>(FindObjectsSortMode.None))
                AddFood(item.gameObject, inventory);
            foreach (var co in UnityEngine.Object.FindObjectsByType<CustomObject>(FindObjectsSortMode.None))
                AddFood(co.gameObject, inventory);
        }

        var objects = new List<GameObject>(food.Count);
        var positions = new List<Point>(food.Count);
        foreach (var go in food)
        {
            if (go == null || !inventory.TryGetMobFood(go, out _) || !Valid(go.transform.position)) continue;
            var owner = go.GetComponentInParent<MobNeedsCode>();
            objects.Add(go);
            positions.Add(Snapshot(go.transform.position, owner != null ? owner.GetInstanceID() : 0, go.scene.handle));
        }
        if (objects.Count == 0) return;

        Point[] requestData = requests.ToArray(), foodData = positions.ToArray();
        var stop = new StopFlag();
        pending = new Batch { Mobs = selected.ToArray(), Epochs = epochs.ToArray(), Food = objects.ToArray(), Stop = stop,
            Job = Task.Run(() => Match(requestData, foodData, stop)) };
    }

    private static void AddFood(GameObject go, ElementalInventory inventory)
    {
        // A CO can also have itemName: keep exactly one food entry for that object.
        if (inventory.TryGetMobFood(go, out _) && foodIds.Add(go.GetInstanceID())) food.Add(go);
    }

    private static void Apply()
    {
        Batch batch = pending;
        if (batch.Job.IsFaulted || batch.Job.IsCanceled)
        {
            Debug.LogWarning("Mob food search failed: " + batch.Job.Exception);
            pending = null;
            return;
        }
        Result result = batch.Job.Result; // IsCompleted was checked in Tick.
        if (result.Error != null)
        {
            Debug.LogWarning("Mob food search failed: " + result.Error.Message);
            pending = null;
            return;
        }
        var inventory = ElementalInventory.main();
        if (inventory == null) { pending = null; return; }
        int end = Math.Min(batch.Next + ApplyPerFrame, batch.Mobs.Length);
        while (batch.Next < end)
        {
            int index = batch.Next++;
            int target = result.Targets[index];
            var mob = batch.Mobs[index];
            if (target < 0 || mob == null || mob.FoodEpoch != batch.Epochs[index] || !mob.WantsFood) continue;
            var go = batch.Food[target];
            if (go == null || go.scene != mob.gameObject.scene || !inventory.TryGetMobFood(go, out float amount)) continue;
            Transform mt = mob.transform, ft = go.transform;
            if (ft.IsChildOf(mt) || mt.IsChildOf(ft)) continue; // Never consume self or one's own hierarchy.
            Vector3 destination = ft.position, position = mt.position;
            double radius = Radius(mob.foodSearchRadius);
            if (!Valid(destination) || !Valid(position) || Distance(position, destination) > radius * radius) continue;

            // Disable before deferred Destroy, so another consumer cannot use this object this frame.
            go.SetActive(false);
            UnityEngine.Object.Destroy(go);
            if (mob == null || !mob.WantsFood) continue;
            var body = mob.GetComponent<Rigidbody>();
            var controller = mob.GetComponent<CharacterController>();
            bool controllerEnabled = controller != null && controller.enabled;
            if (controllerEnabled) controller.enabled = false;
            mt.position = destination;
            if (body != null)
            {
                body.position = destination;
                if (!body.isKinematic) { body.linearVelocity = Vector3.zero; body.angularVelocity = Vector3.zero; }
            }
            if (controllerEnabled) controller.enabled = true;
            var n = mob.GetNeeds();
            mob.SetNeeds(n.food + amount, n.sleep, n.water, n.hygiene, n.social, n.comfort);
        }
        if (batch.Next == batch.Mobs.Length) pending = null;
    }

    private static bool Valid(Vector3 p) => Finite(p.x) && Finite(p.y) && Finite(p.z);
    private static bool Finite(float n) => !float.IsNaN(n) && !float.IsInfinity(n);
    private static double Radius(float r) => Finite(r) ? Math.Max(0.0, Math.Min(1000.0, r)) : 0.0;
    private static Point Snapshot(Vector3 p, int owner, int scene, double radius = 0.0)
        => new Point { X = p.x, Y = p.y, Z = p.z, Owner = owner, Scene = scene, Radius = radius };
    private static double Distance(Vector3 a, Vector3 b)
    {
        double x = (double)a.x - b.x, y = (double)a.y - b.y, z = (double)a.z - b.z;
        return x * x + y * y + z * z;
    }

    // Worker-only section. The grid is built once, then read concurrently without writes.
    internal static Result Match(Point[] requests, Point[] foods, StopFlag stop)
    {
        var result = new Result { Targets = new int[requests.Length] };
        for (int i = 0; i < result.Targets.Length; i++) result.Targets[i] = -1;
        try
        {
            var grid = new Dictionary<(double, double, double, int), List<int>>();
            for (int i = 0; i < foods.Length; i++)
            {
                if (stop.Value) return result;
                var f = foods[i];
                var key = (Math.Floor(f.X / CellSize), Math.Floor(f.Y / CellSize), Math.Floor(f.Z / CellSize), f.Scene);
                if (!grid.TryGetValue(key, out var cell)) grid[key] = cell = new List<int>();
                cell.Add(i);
            }
            var claimed = new int[foods.Length];
            var options = new ParallelOptions { MaxDegreeOfParallelism = Math.Max(1, Math.Min(MaxWorkers, Environment.ProcessorCount - 1)) };
            Parallel.For(0, requests.Length, options, (i, loop) =>
            {
                var m = requests[i];
                double x0 = Math.Floor((m.X - m.Radius) / CellSize), x1 = Math.Floor((m.X + m.Radius) / CellSize);
                double y0 = Math.Floor((m.Y - m.Radius) / CellSize), y1 = Math.Floor((m.Y + m.Radius) / CellSize);
                double z0 = Math.Floor((m.Z - m.Radius) / CellSize), z1 = Math.Floor((m.Z + m.Radius) / CellSize);
                int nx = (int)(x1 - x0) + 1, ny = (int)(y1 - y0) + 1, nz = (int)(z1 - z0) + 1;
                while (!stop.Value)
                {
                    int best = -1;
                    double bestDistance = m.Radius * m.Radius;
                    // A very large radius with few foods is cheaper to scan directly.
                    if ((double)nx * ny * nz > foods.Length)
                    {
                        for (int j = 0; j < foods.Length; j++) Consider(j, m, foods, claimed, ref best, ref bestDistance);
                    }
                    else
                    {
                        for (int x = 0; x < nx; x++)
                            for (int y = 0; y < ny; y++)
                                for (int z = 0; z < nz; z++)
                                    if (grid.TryGetValue((x0 + x, y0 + y, z0 + z, m.Scene), out var cell))
                                        foreach (int j in cell) Consider(j, m, foods, claimed, ref best, ref bestDistance);
                    }
                    if (best < 0) return;
                    if (Interlocked.CompareExchange(ref claimed[best], 1, 0) == 0)
                    {
                        result.Targets[i] = best;
                        return;
                    }
                    // Another mob claimed this food: find the nearest remaining one.
                }
                loop.Stop();
            });
        }
        catch (Exception ex) { result.Error = ex; }
        return result;
    }

    private static void Consider(int index, Point m, Point[] foods, int[] claimed, ref int best, ref double distance)
    {
        var f = foods[index];
        if (f.Scene != m.Scene || (f.Owner != 0 && f.Owner == m.Owner) || Volatile.Read(ref claimed[index]) != 0) return;
        double x = f.X - m.X, y = f.Y - m.Y, z = f.Z - m.Z;
        double d = x * x + y * y + z * z;
        if (d < distance || (d == distance && (best < 0 || index < best))) { best = index; distance = d; }
    }
}
