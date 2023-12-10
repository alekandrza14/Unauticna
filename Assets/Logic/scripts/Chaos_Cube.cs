using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaos_cube : MonoBehaviour
{

    int u = 4;
    int class_obj;
    GameObject[] items;
    GameObject[] Obj;
    [SerializeField] bool ultra;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) )
        {
            
            Ray r = GameManager.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                  
                    if (hit.collider.gameObject == gameObject)
                    {
                        u--;
                    }
                    if (hit.collider.gameObject == gameObject && u < 0)
                    {
                        if (UnityEngine.Random.Range(0, 30) == 1)
                        {
                            GameObject[] res = Resources.LoadAll<GameObject>("events");
                            Instantiate(res[Random.Range(0, res.Length)], transform.position, Quaternion.identity);
                        }
                        Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                        Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                        Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                        Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                        Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                        Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                        Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                        Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                        Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);
                        if (!ultra) Rand();
                        if (ultra)
                        {
                            for (int i = 0; i < 20; i++)
                            {
                                Rand();
                            }
                        }

                        Destroy(gameObject);
                    }
                }

            }
        }
    }
    void Rand()
    {

        items = Resources.LoadAll<GameObject>("items");
        Obj = Resources.LoadAll<GameObject>("Primetives");
        class_obj = Random.Range(0, 2);
        if (class_obj == 0)
        {
            Instantiate(items[Random.Range(0, items.Length)], gameObject.transform.position, Quaternion.identity);
        }
        if (class_obj == 1)
        {
            Instantiate(Obj[Random.Range(0, Obj.Length)], gameObject.transform.position, Quaternion.identity);
        }
        GameManager.saveandhill();
    }
}
