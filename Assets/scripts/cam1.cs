using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void startFunctions()
    {
        for (int i = 0; i < GameObject.FindObjectsOfType<Salut>().Length; i++)
        {
            GameObject.FindObjectsOfType<Salut>()[i].function1();
        }
        for (int i = 0; i < GameObject.FindObjectsOfType<door>().Length; i++)
        {
            GameObject.FindObjectsOfType<door>()[i].function1();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray r1 = new Ray(GameObject.FindObjectOfType<mover>().g2.transform.position, GameObject.FindObjectOfType<mover>().g2.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(r1, out hit))
        {
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<cam1>())
                {
                    startFunctions();
                    Destroy(gameObject);
                }

            }

        }
    }
}
