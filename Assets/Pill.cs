using System.IO;
using UnityEngine;

public class Pill : MonoBehaviour
{
    public static float femaliting;
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider.gameObject == gameObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                femaliting += 2;
                Destroy(gameObject);
            }
            if (Input.GetKeyDown(KeyCode.Q)&&Directory.Exists("debug"))
            {
                femaliting += 80;
                Destroy(gameObject);
            }
        }
    }
}
