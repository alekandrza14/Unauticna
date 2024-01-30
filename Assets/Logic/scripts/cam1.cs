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
        for (int i = 0; i < GameObject.FindObjectsByType<Salut>(sortmode.main).Length; i++)
        {
            GameObject.FindObjectsByType<Salut>(sortmode.main)[i].function1();
        }
        for (int i = 0; i < GameObject.FindObjectsByType<door>(sortmode.main).Length; i++)
        {
            GameObject.FindObjectsByType<door>(sortmode.main)[i].function1();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray r1 = new Ray(GameObject.FindFirstObjectByType<mover>().PlayerCamera.transform.position, GameObject.FindFirstObjectByType<mover>().PlayerCamera.transform.forward);
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
