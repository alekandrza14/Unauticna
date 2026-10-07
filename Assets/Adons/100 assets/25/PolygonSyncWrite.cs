using System.Collections.Generic;
using UnityEngine;

public class PolygonSyncWrite : MonoBehaviour
{
    private Dictionary<Transform, Mesh> Polygons =
        new Dictionary<Transform, Mesh>();
	private Dictionary<Transform, Mesh> APolygons =
        new Dictionary<Transform, Mesh>();

    public int objectsWishPolygons;

    public PolygonSyncWriter writer;

    public int maxPolygonsPerObject = 400;
	
    public void AddObject(GameObject obj,bool forWriter = false)
    {
		if(forWriter)
		{
			if (obj == null)
				return;
	
			MeshFilter meshFilter = obj.GetComponent<MeshFilter>();
	
			if (meshFilter == null)
				return;
	
			Mesh mesh = meshFilter.sharedMesh;
	
			if (mesh == null)
				return;
	
			// Проверяем количество треугольников
			int polygonCount = mesh.triangles.Length / 3;
	
			// Слишком сложный объект не сохраняем
			if (polygonCount >= maxPolygonsPerObject)
				return;
	
			Transform tr = obj.transform;
	
			if (Polygons.ContainsKey(tr))
				return;
	
			Polygons.Add(tr, mesh);
	
	
			
				writer.AddPolygon(
				tr,
				mesh);
			
		}
		else
		{
			if (obj == null)
				return;
	
			MeshFilter meshFilter = obj.GetComponent<MeshFilter>();
	
			Mesh mesh = meshFilter.sharedMesh;
			Transform tr = obj.transform;
	
			if (APolygons.ContainsKey(tr))
				return;
	
			APolygons.Add(tr, mesh);
			objectsWishPolygons++;
		}
    }

    public void RemoveObject(GameObject obj,bool forWriter = false)
    {	
		if(forWriter)
		{
			
		}
		else
		{
			if (obj == null)
				return;
	
			Transform tr = obj.transform;
	
			if (!APolygons.ContainsKey(tr))
				return;
	
			APolygons.Remove(tr);
			objectsWishPolygons--;
		}
    }

    private void Update()
    {
        SaveAllPolygons();
    }

    public void SaveAllPolygons()
    {
        writer.BuildMesh();
    }
}