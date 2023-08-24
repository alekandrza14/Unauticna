using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MainRay : MonoBehaviour
{
    public static RaycastHit MainHit;
    public static bool HitError;
    public static RaycastHit RayMarhHit;
    public static Ray Ray;

    private void Awake()
    {
        MainHit = new RaycastHit();
        Ray = new Ray();
    }

    void Update()
    {
        Ray r = GameManager.pprey();
        Ray = r;
        RaycastHit hit;
        HitError = false;
        if (Physics.Raycast(r, out hit))
        {
            MainHit = hit;
        }
        else
        {
            HitError = true;
        }
        
        PlayerRayMarchCollider ry = FindFirstObjectByType<PlayerRayMarchCollider>();
        RayMarhHit = ry.GetMarchCast(r.origin, r.direction);
    }
}
