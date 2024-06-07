using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MainRay : MonoBehaviour
{
    public static RaycastHit MainHit;
    public static RaycastHit SecondHit;
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
           if(!hit.collider.isTrigger) MainHit = hit;
            else if (hit.collider.gameObject.layer == 3)
            {
                hit.point = hit.collider.gameObject.transform.position + new Vector3(Global.Random.Range(-3f, 3f), Global.Random.Range(-3f, 3f), Global.Random.Range(-3f, 3f));
                MainHit = hit;
            }
            else if (hit.collider.gameObject.layer != 3)
            {
               MainHit = hit;
            }
          
                SecondHit = hit;
           

            HitError = false;
        }
        else
        {
            HitError = true;
        }

        RayMarhHit = ry.GetMarchCast(r.origin, r.direction);

    }
}
