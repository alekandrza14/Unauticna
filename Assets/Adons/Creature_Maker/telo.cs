using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Creature
{
    public List<Vector3> positions = new List<Vector3>();
}

public class telo : MonoBehaviour
{
    public List<GameObject> objs = new List<GameObject>();
    public GameObject obj;
    public Toggle tg;
    public InputField ifd;
    public string nameCreature;

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
        Directory.CreateDirectory("C:/Unauticna Multiverse/Creatures");
        File.WriteAllText("C:/Unauticna Multiverse/Creatures/" + ifd.text + ".creature", JsonUtility.ToJson(c));
    }
    public void load()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        objs = new List<GameObject>();
        for (int i = 0; i < FindObjectsOfType<Mainscript>().Length; i++)
        {
            FindObjectsOfType<Mainscript>()[i].selfLeft();
        }

        if (File.Exists("C:/Unauticna Multiverse/Creatures/"+ifd.text+".creature"))
        {
            Creature c = JsonUtility.FromJson<Creature>(File.ReadAllText("C:/Unauticna Multiverse/Creatures/" + ifd.text + ".creature"));
            for (int i = 0; i < c.positions.Count; i++)
            {
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
        for (int i = 0; i < FindObjectsOfType<Mainscript>().Length; i++)
        {
            FindObjectsOfType<Mainscript>()[i].selfLeft();
        }
      
    }
    private void Start()
    {
        if (nameCreature != "")
        {



            if (File.Exists("C:/Unauticna Multiverse/Creatures/" + nameCreature + ".creature"))
            {
                Creature c = JsonUtility.FromJson<Creature>(File.ReadAllText("C:/Unauticna Multiverse/Creatures/" + nameCreature + ".creature"));
                for (int i = 0; i < c.positions.Count; i++)
                {
                    GameObject g = Instantiate(obj, transform);
                    g.transform.position = c.positions[i] + transform.position;
                    g.GetComponent<Mainscript>().telo = gameObject;
                    objs.Add(g);
                }
            }
        }
        else
        {

        }
    }

    public void FixedUpdate()
    {
        if (nameCreature != "")
        {

        }
        else
        {


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
    private void LateUpdate()
    {
        if (nameCreature != "")
        {

        }
        else
        {

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
