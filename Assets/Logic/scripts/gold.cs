using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold : MonoBehaviour
{

    int u = 4;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) )
        {
            
            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        u--;
                    }
                        if (hit.collider.gameObject == gameObject && u<0)
                    {
                        Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                        Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                        Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                        VarSave.SetInt("tevro", VarSave.GetInt("tevro") + 3);
                        Destroy(gameObject);
                    }
                }

            }
        }
    }
}
