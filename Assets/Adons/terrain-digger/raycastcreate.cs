using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastcreate : MonoBehaviour
{
    public GameObject pref;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {


            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.GetComponent<Terrain>() && Globalprefs.item == "showel")
                    {
                        Instantiate(pref, hit.point, Quaternion.identity);
                        if (!hit.collider.GetComponent<generator_terrain>())
                        {
                            // hit.collider.gameObject.AddComponent<generator_terrain>().ter = hit.collider.GetComponent<Terrain>();

                            // hit.collider.gameObject.GetComponent<generator_terrain>().generate();
                        }
                        if (hit.collider.GetComponent<generator_terrain>())
                        {
                            // hit.collider.gameObject.GetComponent<generator_terrain>().regenerate();
                        }
                    }
                    else if (hit.collider.GetComponent<Terrain>() && playerdata.Geteffect("Right_to_dig") != null)
                    {
                        Instantiate(pref, hit.point, Quaternion.identity);
                        if (!hit.collider.GetComponent<generator_terrain>())
                        {
                            // hit.collider.gameObject.AddComponent<generator_terrain>().ter = hit.collider.GetComponent<Terrain>();

                            // hit.collider.gameObject.GetComponent<generator_terrain>().generate();
                        }
                        if (hit.collider.GetComponent<generator_terrain>())
                        {
                            // hit.collider.gameObject.GetComponent<generator_terrain>().regenerate();
                        }
                    }
                }
            }
        }
    }
}
