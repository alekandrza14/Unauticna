using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vectorss
{
    public Vector3[] v3;
    public string[] names;
}

public class getind : MonoBehaviour
{
    GameObject[] g;
    void Start()
    {
        g = new GameObject[FindObjectsOfType<ind>().Length];
        for (int i = 0;i< FindObjectsOfType<ind>().Length;i++)
        {
            g[i] = FindObjectsOfType<ind>()[i].gameObject;
        }
        load();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            save();
        }
    }
    public void load()
    {
        if (File.Exists("unsave/var/log" + SceneManager.GetActiveScene().buildIndex + ".txt"))
        {
            vectorss vs = JsonUtility.FromJson<vectorss>(File.ReadAllText("unsave/var/log" + SceneManager.GetActiveScene().buildIndex + ".txt"));
            for (int i = 0; i < g.Length; i++)
            {
                for (int i2 = 0; i2 < vs.names.Length; i2++)
                {
                    if (vs.names[i2] == g[i].name + g[i].GetComponent<ind>().getind && !g[i].GetComponent<mover>() && !g[i].GetComponent<Logic_tag_2>())
                    {
                        g[i].transform.position = vs.v3[i2];
                    }
                }
            }
        }
    }
    public void save()
    {
        vectorss vs = new vectorss();
        if (FindObjectsOfType<ind>().Length != 0) {
            vs.names = new string[FindObjectsOfType<ind>().Length];
            vs.v3 = new Vector3[FindObjectsOfType<ind>().Length];
            for (int i = 0; i < FindObjectsOfType<ind>().Length; i++)
            {
                if (FindObjectsOfType<ind>()[i].gameObject) {
                    vs.names[i] += FindObjectsOfType<ind>()[i].name + FindObjectsOfType<ind>()[i].GetComponent<ind>().getind;
                    vs.v3[i] = FindObjectsOfType<ind>()[i].transform.position;
                }
            }
            File.WriteAllText("unsave/var/log" + SceneManager.GetActiveScene().buildIndex + ".txt", JsonUtility.ToJson(vs));
        }
    }
}
