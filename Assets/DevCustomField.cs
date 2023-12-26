using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DevCustomField : MonoBehaviour
{

    [SerializeField] Transform point;
    [SerializeField] GameObject resource;
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null) if (hit.collider.gameObject == gameObject && Input.GetKeyDown(KeyCode.E))
            {

                GameObject obj = Instantiate(resource.gameObject, point.position, Quaternion.identity);

            }
    }
}
