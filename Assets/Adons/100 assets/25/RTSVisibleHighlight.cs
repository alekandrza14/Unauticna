using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSVisibleHighlight : MonoBehaviour
{
    [Header("Камера RTS")]
    public Camera rtsCamera;

    [Header("Зелёный материал")]
    public Material highlightMaterial;

    [Header("Какие объекты проверять")]
    public LayerMask objectLayers;

    [Header("Размер области проверки")]
    public float checkDistance = 500f;

    private Dictionary<Renderer, Material[]> originalMaterials =
        new Dictionary<Renderer, Material[]>();

    private HashSet<Renderer> visibleNow =
        new HashSet<Renderer>();

    private HashSet<Renderer> visibleLastFrame =
        new HashSet<Renderer>();
	public PolygonSyncWrite counter;

    void Update()
    {
        visibleNow.Clear();

        // Находим все Renderer на нужных слоях
        Renderer[] renderers = FindObjectsOfType<Renderer>();

        foreach (Renderer rend in renderers)
        {
            if (!IsInCamera(rend))
                continue;

            visibleNow.Add(rend);
            // Если объект появился в поле зрения
            if (!visibleLastFrame.Contains(rend))
            {
                Highlight(rend);
				counter.AddObject(rend.gameObject);
				counter.AddObject(rend.gameObject,true);
            }
        }

        // Объекты, которые вышли из камеры
        foreach (Renderer rend in visibleLastFrame)
        {
            if (!visibleNow.Contains(rend))
            {
                Restore(rend);
				counter.RemoveObject(rend.gameObject);
            }
        }

        // Переносим текущий список в предыдущий
        HashSet<Renderer> temp = visibleLastFrame;
        visibleLastFrame = visibleNow;
        visibleNow = temp;
    }

    bool IsInCamera(Renderer rend)
    {
        if (rtsCamera == null)
            return false;

        if (((1 << rend.gameObject.layer) & objectLayers) == 0)
            return false;

        Bounds bounds = rend.bounds;

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(rtsCamera);

        return GeometryUtility.TestPlanesAABB(planes, bounds);
    }

    void Highlight(Renderer rend)
    {
        //if (rend == null)
        //    return;
		//
        //if (!originalMaterials.ContainsKey(rend))
        //{
        //    originalMaterials.Add(
        //        rend,
        //        rend.sharedMaterials
        //    );
        //}
		//
        //Material[] materials = new Material[rend.sharedMaterials.Length];
		//
        //for (int i = 0; i < materials.Length; i++)
        //{
        //    materials[i] = highlightMaterial;
        //}
		//
        //rend.sharedMaterials = materials;
    }

    void Restore(Renderer rend)
    {
        //if (rend == null)
        //    return;
		//
        //if (!originalMaterials.TryGetValue(rend, out Material[] materials))
        //    return;
		//
        //rend.sharedMaterials = materials;
        //originalMaterials.Remove(rend);
    }

    void OnDisable()
    {
        foreach (var pair in originalMaterials)
        {
            if (pair.Key != null)
            {
                pair.Key.sharedMaterials = pair.Value;
            }
        }

        originalMaterials.Clear();
        visibleLastFrame.Clear();
    }
}