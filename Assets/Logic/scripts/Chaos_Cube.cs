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
    [SerializeField] bool _double;
    [SerializeField] bool _quadle;
    bool omega;
    bool init;
    [SerializeField] bool Recurse;
    private void Start()
    {
        float Chance = 100 / (VarSave.GetFloat("ChanceChaosCubeDeath" + "_gameSettings", SaveType.global) * 100f);
        if (!init && VarSave.LoadFloat("luck", 0f) > 2)
        {
            _double = true;
        }
        if (!init && VarSave.LoadFloat("luck", 0f) > 6)
        {
            _quadle = true;
        }
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
                        ChaosFunction(this);
                    }
                }

            }
        }
    }

    public static void ChaosFunction(Chaos_cube self)
    {
        VarSave.LoadFloat("luck",0.1f);
        if (UnityEngine.Random.Range(0, 30) == 1)
        {
            GameObject[] res = Resources.LoadAll<GameObject>("events");
            Instantiate(res[Random.Range(0, res.Length)], self.transform.position, Quaternion.identity);
        }
        Instantiate(Resources.Load<GameObject>("deathparticles"), self.gameObject.transform.position, Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("deathparticles"), self.gameObject.transform.position, Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("deathparticles"), self.gameObject.transform.position, Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("deathparticles"), self.gameObject.transform.position, Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("deathparticles"), self.gameObject.transform.position, Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("deathparticles"), self.gameObject.transform.position, Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("deathparticles"), self.gameObject.transform.position, Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("deathparticles"), self.gameObject.transform.position, Quaternion.identity);
        Instantiate(Resources.Load<GameObject>("deathparticles"), self.gameObject.transform.position, Quaternion.identity);
        if (!self.ultra) Rand(self);
        if (self.ultra)
        {
            for (int i = 0; i < 20; i++)
            {
                Rand(self);
            }
        }
        if (self._quadle)
        {
            for (int i = 0; i < 2; i++)
            {
                Rand(self);
            }
        }
        if (self._double)
        {
            
                Rand(self);
            
        }
        if (self.ultra && self.omega)
        {
            for (int i = 0; i < 50; i++)
            {
                Rand(self);
            }
        }

        if (!self.Recurse) Destroy(self.gameObject);
    }
    public void OnSignal()
    {
        ChaosFunction(this);
    }
        public static void Rand(Chaos_cube self)
    {

        self.items = Resources.LoadAll<GameObject>("items");
        self.Obj = Resources.LoadAll<GameObject>("Primetives");
        self.class_obj = Random.Range(0, 3);
        if (self.class_obj == 0)
        {
            int rand1 = Random.Range(0, self.items.Length);
            if (!self.items[rand1].GetComponent<Запрещён>()) Instantiate(self.items[rand1], self.gameObject.transform.position, Quaternion.identity);
        }
        if (self.class_obj == 1)
        {
            Instantiate(self.Obj[Random.Range(0, self.Obj.Length)], self.gameObject.transform.position, Quaternion.identity);
        }
        if (self.class_obj == 2)
        {
            int rand1 = Random.Range(0, self.items.Length);
            if (Random.Range(0, 2) == 0) { if (!self.items[rand1].GetComponent<Запрещён>()) Instantiate(self.items[rand1], self.gameObject.transform.position, Quaternion.identity); }
            else
            {
                DirectoryInfo dif = new DirectoryInfo("res/UserWorckspace/Items");
                bool moneta= false;
                while (!moneta) {

                    string t = dif.GetFiles()[Random.Range(0, dif.GetFiles().Length)].Name.Replace(".txt", "");
                    if (t.Remove(10,t.Length-1-9) != "Chaos_Item")
                    {
                        GameObject g = Instantiate(Resources.Load<GameObject>("CustomObject"), self.gameObject.transform.position, Quaternion.identity);
                        g.GetComponent<CustomObject>().s = t;

                        Debug.Log("Chaos_NotImmunity");
                        Debug.Log(t.Remove(10, t.Length - 1 - 9));
                        Debug.Log(t);
                        moneta = true;
                    }
                    else
                    {
                        Debug.Log("Chaos_Immunity");
                        moneta = false;
                    }
                }
            }
        }
        GameManager.saveandhill();
    }
}
