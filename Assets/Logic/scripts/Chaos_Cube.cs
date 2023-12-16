using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Chaos_cube : MonoBehaviour
{

    int u = 4;
    int class_obj;
    GameObject[] items;
    GameObject[] Obj;
    [SerializeField] bool ultra;
    bool omega;
    bool init;
    private void Start()
    {
        float Chance = 100 / (VarSave.GetFloat("ChanceChaosCubeDeath" + "_gameSettings", SaveType.global) * 100f);
        if (UnityEngine.Random.Range(0, (int)Chance + 1) == 0 && !init)
        {
            ultra = true;
            init = true;
        }
        if (UnityEngine.Random.Range(0, (int)Chance + 1) == 0 && ultra && !init)
        {
            omega = true;
            init = true;
        }
    }
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
                        if (ultra&& omega)
                        {
                            for (int i = 0; i < 50; i++)
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
        class_obj = Random.Range(0, 3);
        if (class_obj == 0)
        {
            Instantiate(items[Random.Range(0, items.Length)], gameObject.transform.position, Quaternion.identity);
        }
        if (class_obj == 1)
        {
            Instantiate(Obj[Random.Range(0, Obj.Length)], gameObject.transform.position, Quaternion.identity);
        }
        if (class_obj == 2)
        {
          if(Random.Range(0, 2) == 0)  Instantiate(items[Random.Range(0, items.Length)], gameObject.transform.position, Quaternion.identity);
          else
            {
                DirectoryInfo dif = new DirectoryInfo("res/UserWorckspace/Items");

              
                GameObject g = Instantiate(Resources.Load<GameObject>("CustomObject"), gameObject.transform.position, Quaternion.identity);
                g.GetComponent<CustomObject>().s = dif.GetFiles()[Random.Range(0, dif.GetFiles().Length)].Name.Replace(".txt", "");

            }
        }
        GameManager.saveandhill();
    }
}
