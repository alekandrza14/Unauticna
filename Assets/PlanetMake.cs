using Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMake : InventoryEvent
{
    public GameObject Planet;
    public NintResourse resourse;
    public GameObject safeMesh;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<itemName>())
        {
            if (collision.collider.GetComponent<itemName>()._Name == "LicenseForMakePlanet")
            {
                resourse.Eatlicense();
                Destroy(collision.collider.gameObject);
            }
            if (collision.collider.GetComponent<itemName>()._Name == "Печать")
            {
                resourse.EndMake();
                Destroy(collision.collider.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Planet.transform.localScale =( Vector3.one*2*resourse.res.bytes.Length)+(Vector3.one*9);
        if (resourse.res.bytes.Length > 3)
        {

            safeMesh.SetActive(false);
        }
    }
}
