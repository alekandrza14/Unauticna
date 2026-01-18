using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SizeCreachure
{
    nope, ant, small, medium, big, giga, titan, planet
}

public class Creature
{
    public List<Vector3> positions = new List<Vector3>();
    public SizeCreachure sc;
}

public class telo : CustomSaveObject
{
    public List<GameObject> objs = new List<GameObject>();
    public SizeCreachure sc;
    public Dropdown sizesCreachure;
    public GameObject obj;
    public Toggle tg;
    public InputField ifd;
    public string nameCreature;
    public bool cellRandom;
    public bool cellPlayer;
    public bool creatureRandom;
    public bool creaturePlayer;
    public int food;
    public int grass;
    public int meat;
    public int love;
    public int agry;
    public int social;
    public int scene;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<telo>() && cellPlayer)
        {
            if (!collision.collider.GetComponent<telo>().cellPlayer)
            {
                food++;
                meat++;
                Destroy(collision.collider.gameObject);
            }
        }
        if (collision.collider.GetComponent<telo>() && creaturePlayer)
        {
            if (!collision.collider.GetComponent<telo>().creaturePlayer && grass > 0)
            {
                GameObject obj = Instantiate(collision.collider.gameObject);
                obj.GetComponent<telo>().creatureRandom = false;
                love++;
                social++; grass--;
            }
            if (!collision.collider.GetComponent<telo>().creaturePlayer && grass <= 0)
            {
                meat++;
                Destroy(collision.collider.gameObject);
                agry++;
                social++; grass--;
            }
        }
        if (collision.collider.GetComponent<Grass>())
        {
            food++;
            grass++;
            Destroy(collision.collider.gameObject);
        }
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void save()
    {
        Creature c = new Creature();
        foreach (GameObject obj in objs)
        {
            c.positions.Add(obj.transform.position);
        }
        c.sc = sc;
        Directory.CreateDirectory("res/Creatures");
        File.WriteAllText("res/Creatures/" + ifd.text + ".creature", JsonUtility.ToJson(c));

    }
    public void load()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        objs = new List<GameObject>();
        for (int i = 0; i < FindObjectsByType<Mainscript>(sortmode.main).Length; i++)
        {
            FindObjectsByType<Mainscript>(sortmode.main)[i].selfLeft();
        }

        if (File.Exists("res/Creatures/" + ifd.text + ".creature"))
        {
            Creature c = JsonUtility.FromJson<Creature>(File.ReadAllText("res/Creatures/" + ifd.text + ".creature"));
            for (int i = 0; i < c.positions.Count; i++)
            {
                sc = c.sc;
                sizesCreachure.value = (int)sc;
                GameObject g = Instantiate(obj, transform);
                g.transform.position = c.positions[i];
                g.GetComponent<Mainscript>().telo = gameObject;
                objs.Add(g);
            }
        }
    }
    public void clear()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        objs = new List<GameObject>();
        for (int i = 0; i < FindObjectsByType<Mainscript>(sortmode.main).Length; i++)
        {
            FindObjectsByType<Mainscript>(sortmode.main)[i].selfLeft();
        }

    }
    bool Nondfaultcreutere()
    {
        if (!cellRandom)
        {
            if (!creatureRandom)
            {
                return true;
            }
        }
        return false;
    }

    private void Start()
    {
        if (cellRandom||creatureRandom)
        {
            DirectoryInfo DaySutzhestv = new DirectoryInfo("res/Creatures");
            FileInfo[] fileInfos = DaySutzhestv.GetFiles();

            string Filename = fileInfos[Random.Range(0, fileInfos.Length)].Name;
            nameCreature = Filename.Replace(".creature", "");
               
        }

        if (nameCreature != "")
        {



            if (File.Exists("res/Creatures/" + nameCreature + ".creature"))
            {
                Creature c = JsonUtility.FromJson<Creature>(File.ReadAllText("res/Creatures/" + nameCreature + ".creature"));
                for (int i = 0; i < c.positions.Count; i++)
                {
                    GameObject g = Instantiate(obj, transform);
                    sc = c.sc;
                    g.transform.position = c.positions[i] + transform.position;
                    g.GetComponent<Mainscript>().telo = gameObject;
                    objs.Add(g);
                }
            }
            if (sc == SizeCreachure.nope)
            {
                transform.localScale *= 1;
                GetComponent<Rigidbody>().linearDamping = 1;
                GetComponent<Rigidbody>().mass = 10;
                GetComponent<PlanetPhysics>().gravity *= 1;
            }
            if (sc == SizeCreachure.ant)
            {
                transform.localScale *= 0.1f;
                GetComponent<Rigidbody>().mass = 1f;
                GetComponent<Rigidbody>().linearDamping = 10;
                GetComponent<PlanetPhysics>().gravity *= 0.1f;
            }
            if (sc == SizeCreachure.small)
            {
                transform.localScale *= 0.3f;
                GetComponent<Rigidbody>().mass = 3f;
                GetComponent<Rigidbody>().linearDamping = 2;
                GetComponent<PlanetPhysics>().gravity *= 0.3f;
            }
            if (sc == SizeCreachure.medium)
            {
                transform.localScale *= 1;
                GetComponent<Rigidbody>().mass = 10f;
                GetComponent<Rigidbody>().linearDamping =1;
                GetComponent<PlanetPhysics>().gravity *=1f;
            }
            if (sc == SizeCreachure.big)
            {
                transform.localScale *= 2;
                GetComponent<Rigidbody>().mass = 40f;
                GetComponent<Rigidbody>().linearDamping = 1;
                GetComponent<PlanetPhysics>().gravity *= 4f;
            }
           if(Nondfaultcreutere()) if (sc == SizeCreachure.giga)
            {
                transform.localScale *= 10;
                GetComponent<Rigidbody>().mass = 10000f;
                GetComponent<Rigidbody>().linearDamping = 1;
                GetComponent<PlanetPhysics>().gravity *= 30f;
            }
            if (Nondfaultcreutere()) if (sc == SizeCreachure.titan)
            {
                transform.localScale *= 50;
                GetComponent<Rigidbody>().mass = 200000f;
                GetComponent<Rigidbody>().linearDamping = 1;
                GetComponent<PlanetPhysics>().gravity *= 100f;
            }
            if (Nondfaultcreutere()) if (sc == SizeCreachure.planet)
            {
                transform.localScale *= 400;
                GetComponent<Rigidbody>().mass = 16000000f;
                GetComponent<Rigidbody>().linearDamping = 1;
                GetComponent<PlanetPhysics>().gravity *= 500f;
            }
        }
        else
        {
          //  InvokeRepeating("EditorUpdate", 0f + Random.Range(0f, 1f), 0.05f);
        }
    }

  
    public void RotateCreature()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
    }
    public void InverseCreature()
    {
        foreach(GameObject obj in objs)
        {
            if (obj != null)
            {
                obj.transform.position = new Vector3(obj.transform.position.x,
                    obj.transform.position.y, -obj.transform.position.z);
            }
        }
    }
    private void Update()
    {
        if (cellPlayer)
        {
            if (food >= 20)
            {
                float carma = (float)meat / (float)food;
                Debug.Log("carma "+ carma);
                if (carma >= 0.66)
                {
                    VarSave.SetInt("Еда", 1);
                    SceneLoad.loadbar(scene);
                }
                else if (carma <= 0.33)
                {
                    VarSave.SetInt("Еда", 3);

                    SceneLoad.loadbar(scene);
                }
                else
                {
                    VarSave.SetInt("Еда", 2);
                    SceneLoad.loadbar(scene);
                }
            }
        }
        if (creaturePlayer)
        {
            if (social >= 20)
            {
                float carma = agry / social;
                if (carma >= 0.66)
                {
                    VarSave.SetInt("Соц", 1);
                    SceneLoad.loadbar(scene);
                }
                else if (carma <= 0.33)
                {
                    VarSave.SetInt("Соц", 3);

                    SceneLoad.loadbar(scene);
                }
                else
                {
                    VarSave.SetInt("Соц", 2);
                    SceneLoad.loadbar(scene);
                }
            }
        }
        if (nameCreature != "")
        {

        }
        else
        {
            if (Nondfaultcreutere())
            {
                sc = (SizeCreachure)sizesCreachure.value;
                if (VarSave.GetFloat(
               "Freedomfil" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
                if (tg.isOn && !gameObject.GetComponent<Rigidbody>())
                {
                    gameObject.AddComponent<Rigidbody>();
                }
                if (!tg.isOn && gameObject.GetComponent<Rigidbody>())
                {
                    Destroy(gameObject.GetComponent<Rigidbody>());
                    transform.position = Vector3.zero;
                    transform.rotation = Quaternion.identity;
                }
            }
        }
        if (nameCreature != "")
        {

        }
        else
        {
            if (Nondfaultcreutere())
            {
                if (VarSave.GetFloat(
           "Freedomfil" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
                Ray r = ViewC.getMainView().ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider.GetComponent<telo>() && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        GameObject g = Instantiate(obj, transform);
                        g.transform.position = hit.point;
                        g.GetComponent<Mainscript>().telo = gameObject;
                        objs.Add(g);
                    }
                    if (hit.collider.GetComponent<Mainscript>() && Input.GetKeyDown(KeyCode.Delete))
                    {
                        GameObject g = hit.collider.gameObject;
                        objs.Remove(hit.collider.gameObject);
                        Destroy(g);
                    }
                    else if (hit.collider.GetComponent<Mainscript>() && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        GameObject g = Instantiate(obj, transform);
                        g.transform.position = hit.point;
                        g.GetComponent<Mainscript>().telo = gameObject;
                        objs.Add(g);
                    }
                }
            }
        }
    }
    
}
