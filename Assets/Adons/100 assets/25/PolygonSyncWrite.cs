using System.Collections.Generic;
using UnityEngine;

public class PolygonSyncWrite : MonoBehaviour
{
    readonly HashSet<Transform> counted = new HashSet<Transform>();
    public int objectsWishPolygons;
    public PolygonSyncWriter writer;
    public int maxPolygonsPerObject = 400;
    public void AddObject(GameObject obj, bool forWriter = false)
    {
        if (obj == null || !obj.TryGetComponent<MeshFilter>(out var filter) || filter.sharedMesh == null) return;
        if (!forWriter) { counted.Add(obj.transform); counted.RemoveWhere(t => t == null); objectsWishPolygons = counted.Count; return; }
        Mesh mesh = filter.sharedMesh; long indices = 0;
        for (int i = 0; i < mesh.subMeshCount; i++) indices += mesh.GetIndexCount(i);
        if (writer != null && indices / 3 < maxPolygonsPerObject) writer.AddPolygon(obj.transform, mesh);
    }
    public void RemoveObject(GameObject obj, bool forWriter = false)
    {
        if (obj == null) return;
        if (forWriter) { if (writer != null) writer.RemovePolygon(obj.transform); }
        else { counted.Remove(obj.transform); objectsWishPolygons = counted.Count; }
    }
    // No per-frame Update here. PolygonSyncWriter owns its schedule.
    public void SaveAllPolygons() { if (writer != null) writer.BuildMesh(); }
}
