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
        PlayerRayMarchCollider ry = FindFirstObjectByType<PlayerRayMarchCollider>();
        Ray r = GameManager.pprey();
        Ray = r;
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            MainHit = hit;

            HitError = false;
        }
        else
        {
            RayMarhHit = ry.GetMarchCast(r.origin, r.direction);
            HitError = true;
        }
        
    }
}
