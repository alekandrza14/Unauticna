using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using Unauticna.Mechanics;

public class PolygonSyncWriter : MonoBehaviour
{
    public Dictionary<Transform, Mesh> Apolygons = new Dictionary<Transform, Mesh>();
    public string savePath = "C:/data/frame";
    [Min(0.05f)] public float updateInterval = 0.1f;
    sealed class Geometry { public Vector3[] vertices, normals; public Vector2[] uv; public int[] triangles; }
    struct Part { public Geometry mesh; public Matrix4x4 matrix, normal; public int offset; public bool mirrored; }
    struct Seen { public Mesh mesh; public Matrix4x4 matrix; public bool active; }
    readonly Dictionary<Mesh, Geometry> geometry = new Dictionary<Mesh, Geometry>();
    readonly Dictionary<Transform, Seen> seen = new Dictionary<Transform, Seen>();
    readonly List<Transform> dead = new List<Transform>();
    readonly LatestFileWorker worker = new LatestFileWorker();
    bool dirty = true;
    float next;
    int revision = -1;
    string lastPath;
    void Awake() { PlayerMechanics.Register(this, MechanicId.PolygonSync); }
    void OnEnable() { dirty = true; next = 0; }
    void Update() { BuildMesh(); }
    public void MarkDirty() { dirty = true; geometry.Clear(); }
    public void AddPolygon(Transform transform, Mesh mesh)
    {
        if (transform == null || mesh == null) return;
        if (!Apolygons.TryGetValue(transform, out var old) || old != mesh) { Apolygons[transform] = mesh; dirty = true; }
    }
    public void RemovePolygon(Transform transform)
    {
        if (ReferenceEquals(transform, null)) return;
        if (Apolygons.Remove(transform)) { seen.Remove(transform); dirty = true; }
    }
    public void BuildMesh()
    {
        if (!isActiveAndEnabled || !PlayerMechanics.Active(MechanicId.PolygonSync) || Time.unscaledTime < next) return;
        next = Time.unscaledTime + Mathf.Max(0.05f, updateInterval);
        string error = worker.TakeError(); if (error != null) { dirty = true; Debug.LogWarning("Polygon sync: " + error, this); }
        bool changed = dirty || seen.Count != Apolygons.Count || revision != PlayerMechanics.RendererRevision || lastPath != savePath;
        dead.Clear();
        foreach (var pair in Apolygons)
        {
            if (pair.Key == null || pair.Value == null) { dead.Add(pair.Key); changed = true; continue; }
            var current = new Seen { mesh = pair.Value, matrix = pair.Key.localToWorldMatrix, active = pair.Key.gameObject.activeInHierarchy };
            if (!seen.TryGetValue(pair.Key, out var old) || old.mesh != current.mesh || old.matrix != current.matrix || old.active != current.active) changed = true;
        }
        foreach (var tr in dead) { Apolygons.Remove(tr); seen.Remove(tr); }
        if (!changed) return;
        var parts = new List<Part>(); int count = 0;
        seen.Clear();
        foreach (var pair in Apolygons)
        {
            Transform tr = pair.Key; Mesh mesh = pair.Value; Matrix4x4 matrix = tr.localToWorldMatrix;
            seen[tr] = new Seen { mesh = mesh, matrix = matrix, active = tr.gameObject.activeInHierarchy };
            if (!tr.gameObject.activeInHierarchy || !mesh.isReadable) continue;
            if (!geometry.TryGetValue(mesh, out var g))
            {
                g = new Geometry { vertices = mesh.vertices, triangles = mesh.triangles, uv = mesh.uv, normals = mesh.normals };
                geometry[mesh] = g;
            }
            parts.Add(new Part { mesh = g, matrix = matrix, normal = matrix.inverse.transpose, offset = count, mirrored = matrix.determinant < 0 });
            count += g.vertices.Length;
        }
        dirty = false; revision = PlayerMechanics.RendererRevision; lastPath = savePath;
        Part[] snapshot = parts.ToArray(); string path = savePath; int vertices = count;
        // Removed meshes are no longer retained indefinitely by the cache.
        var used = new HashSet<Mesh>(Apolygons.Values);
        var remove = new List<Mesh>(); foreach (var mesh in geometry.Keys) if (!used.Contains(mesh)) remove.Add(mesh);
        foreach (var mesh in remove) geometry.Remove(mesh);
        worker.Submit(publish => publish(path, Encode(snapshot, vertices)));
    }
    static byte[] Encode(Part[] parts, int vertexCount)
    {
        var vertices = new float[vertexCount * 3]; var uv = new float[vertexCount * 2]; var normals = new float[vertexCount * 3];
        int indexCount = 0; foreach (var part in parts) indexCount += part.mesh.triangles.Length;
        var triangles = new int[indexCount]; int cursor = 0;
        foreach (var part in parts)
        {
            var input = part.mesh.triangles;
            for (int i = 0; i < input.Length; i += 3)
            { triangles[cursor++] = part.offset + input[i]; triangles[cursor++] = part.offset + input[i + (part.mirrored ? 2 : 1)]; triangles[cursor++] = part.offset + input[i + (part.mirrored ? 1 : 2)]; }
        }
        Action<int> transform = index =>
        {
            Part p = parts[index]; var g = p.mesh; var m = p.matrix; var n = p.normal;
            for (int i = 0; i < g.vertices.Length; i++)
            {
                var v = g.vertices[i]; int o = (p.offset + i) * 3;
                vertices[o] = m.m00 * v.x + m.m01 * v.y + m.m02 * v.z + m.m03;
                vertices[o + 1] = m.m10 * v.x + m.m11 * v.y + m.m12 * v.z + m.m13;
                vertices[o + 2] = m.m20 * v.x + m.m21 * v.y + m.m22 * v.z + m.m23;
                if (i < g.uv.Length) { uv[(p.offset + i) * 2] = g.uv[i].x; uv[(p.offset + i) * 2 + 1] = g.uv[i].y; }
                if (i < g.normals.Length)
                {
                    var a = g.normals[i]; float x = n.m00 * a.x + n.m01 * a.y + n.m02 * a.z;
                    float y = n.m10 * a.x + n.m11 * a.y + n.m12 * a.z; float z = n.m20 * a.x + n.m21 * a.y + n.m22 * a.z;
                    float length = (float)Math.Sqrt(x * x + y * y + z * z);
                    if (length > 0) { normals[o] = x / length; normals[o + 1] = y / length; normals[o + 2] = z / length; }
                }
            }
            if (g.normals.Length != g.vertices.Length)
            {
                // Reconstruct smooth normals for meshes without authored normals.
                for (int k = 0; k < g.triangles.Length; k += 3)
                {
                    int a = (p.offset + g.triangles[k]) * 3, b = (p.offset + g.triangles[k + 1]) * 3, c = (p.offset + g.triangles[k + 2]) * 3;
                    float ux = vertices[b] - vertices[a], uy = vertices[b + 1] - vertices[a + 1], uz = vertices[b + 2] - vertices[a + 2];
                    float vx = vertices[c] - vertices[a], vy = vertices[c + 1] - vertices[a + 1], vz = vertices[c + 2] - vertices[a + 2];
                    float sign = p.mirrored ? -1f : 1f;
                    float nx = (uy * vz - uz * vy) * sign, ny = (uz * vx - ux * vz) * sign, nz = (ux * vy - uy * vx) * sign;
                    normals[a] += nx; normals[a + 1] += ny; normals[a + 2] += nz;
                    normals[b] += nx; normals[b + 1] += ny; normals[b + 2] += nz;
                    normals[c] += nx; normals[c + 1] += ny; normals[c + 2] += nz;
                }
                for (int i = p.offset * 3; i < (p.offset + g.vertices.Length) * 3; i += 3)
                {
                    float length = (float)Math.Sqrt(normals[i] * normals[i] + normals[i + 1] * normals[i + 1] + normals[i + 2] * normals[i + 2]);
                    if (length > 0) { normals[i] /= length; normals[i + 1] /= length; normals[i + 2] /= length; }
                }
            }
        };
        if (vertexCount > 4096 && parts.Length > 1)
            Parallel.For(0, parts.Length, new ParallelOptions { MaxDegreeOfParallelism = Math.Max(1, Environment.ProcessorCount - 1) }, transform);
        else for (int i = 0; i < parts.Length; i++) transform(i);
        return EncodeArrays(vertices, triangles, uv, normals);
    }
    static byte[] EncodeArrays(float[] vertices, int[] triangles, float[] uv, float[] normals)
    {
        using (var stream = new MemoryStream()) using (var writer = new BinaryWriter(stream))
        {
            writer.Write(vertices.Length); foreach (float v in vertices) writer.Write(v);
            writer.Write(triangles.Length); foreach (int v in triangles) writer.Write(v);
            writer.Write(uv.Length); foreach (float v in uv) writer.Write(v);
            writer.Write(normals.Length); foreach (float v in normals) writer.Write(v);
            return stream.ToArray();
        }
    }
    public float[] breackV3(Vector3[] values)
    {
        if (values == null) return new float[0]; var result = new float[values.Length * 3];
        for (int i = 0; i < values.Length; i++) { result[i * 3] = values[i].x; result[i * 3 + 1] = values[i].y; result[i * 3 + 2] = values[i].z; } return result;
    }
    public float[] breackV2(Vector2[] values)
    {
        if (values == null) return new float[0]; var result = new float[values.Length * 2];
        for (int i = 0; i < values.Length; i++) { result[i * 2] = values[i].x; result[i * 2 + 1] = values[i].y; } return result;
    }
    public void SaveMesh(string path, Vector3[] vertices, int[] triangles, Vector2[] uv, Vector3[] normals)
    {
        if (!isActiveAndEnabled || !PlayerMechanics.Active(MechanicId.PolygonSync) || vertices == null || triangles == null || uv == null || normals == null) return;
        float[] v = breackV3(vertices), u = breackV2(uv), n = breackV3(normals); int[] t = (int[])triangles.Clone();
        worker.Submit(publish => publish(path, EncodeArrays(v, t, u, n)));
    }
    void OnDisable() { worker.Cancel(); dirty = true; geometry.Clear(); seen.Clear(); }
    void OnDestroy() { worker.Cancel(); PlayerMechanics.Unregister(this); }
}
