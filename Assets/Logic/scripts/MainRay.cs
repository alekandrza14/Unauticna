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
            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach (MonoBehaviour item in hit.collider.GetComponents<MonoBehaviour>())
                {
                    item.Invoke("OnInteractive", 0);
                }
            }
            if (!hit.collider.isTrigger)
            {
                RaycastHit hit2;

                Ray r2 = new Ray(hit.point + (r.direction / 10f), r.direction);
                if (hit.collider.gameObject.layer == 8)
                {
                    while (Physics.Raycast(r2, out hit2))
                    {
                        if (hit2.collider.gameObject.layer != 8)
                        {

                            MainHit = hit2;
                            break;
                        }
                        else
                        {
                            MainHit = new RaycastHit();
                            break;
                        }
                    }
                }
                else
                {
                    MainHit = hit;
                }
            }
            else if (hit.collider.gameObject.layer == 3)
            {
                hit.point = hit.collider.gameObject.transform.position + new Vector3(Global.Random.Range(-3f, 3f), Global.Random.Range(-3f, 3f), Global.Random.Range(-3f, 3f));
                RaycastHit hit2;

                Ray r2 = new Ray(hit.point + (r.direction / 10f), r.direction);
                if (hit.collider.gameObject.layer == 8)
                {
                    while (Physics.Raycast(r2, out hit2))
                    {
                        if (hit2.collider.gameObject.layer != 8)
                        {

                            MainHit = hit2;
                            break;
                        }
                        else
                        {
                            MainHit = new RaycastHit();
                            break;
                        }
                    }
                }
                else
                {
                    MainHit = hit;
                }
            }
            else if (hit.collider.gameObject.layer != 3)
            {

                RaycastHit hit2;

                Ray r2 = new Ray(hit.point + (r.direction / 10f), r.direction);
                if (hit.collider.gameObject.layer == 8)
                {
                    while (Physics.Raycast(r2, out hit2))
                    {
                        if (hit2.collider.gameObject.layer != 8)
                        {

                            MainHit = hit2;
                            break;
                        }
                        else
                        {
                            MainHit = new RaycastHit();
                            break;
                        }
                    }
                }
                else
                {
                    MainHit = hit;
                }
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
