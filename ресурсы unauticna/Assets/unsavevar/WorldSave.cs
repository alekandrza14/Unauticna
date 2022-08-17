using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveobj6d
{
    public Vector4 v4;
    public Vector3 v3;
    public Vector3 modulyogir;
}

public class WorldSave : MonoBehaviour
{
    public static string path = "world";
    public static void DeleteAll()
    {
        Directory.Delete(path,true);
        
    }


    public static void SetVector4(string key)
    {
        Directory.CreateDirectory(path);
        for (int i = 0; i < GameObject.FindObjectsOfType<scrollbareditWpos>().Length; i++)
        {


            saveobj6d obj = new saveobj6d();
            obj.v4.w = GameObject.FindObjectsOfType<scrollbareditWpos>()[i].Wpos.value;
            File.WriteAllText(path + "/" + key + "-" + i + "-" + SceneManager.GetActiveScene().buildIndex, JsonUtility.ToJson(obj));
        }
    }
    public static Vector4 GetVector4(string key)
    {
        Vector4 varout = new Vector4();
        for (int i = 0; i < GameObject.FindObjectsOfType<scrollbareditWpos>().Length; i++)
        {
            if (File.Exists(path + "/" + key + "-" + i + "-" + SceneManager.GetActiveScene().buildIndex))
            {
                saveobj6d obj = new saveobj6d();


                obj = JsonUtility.FromJson<saveobj6d>(File.ReadAllText(path + "/" + key + "-" + i + "-" + SceneManager.GetActiveScene().buildIndex));
                GameObject.FindObjectsOfType<scrollbareditWpos>()[i].Wpos.value = obj.v4.w;
                varout = obj.v4;
            }
        }
        return varout;
    }
    public static void SetVector3(string key)
    {
        Directory.CreateDirectory(path);
        for (int i = 0; i < GameObject.FindObjectsOfType<modulyogir>().Length; i++)
        {


            saveobj6d obj = new saveobj6d();
            obj.v3 = GameObject.FindObjectsOfType<modulyogir>()[i].transform.position;
            obj.modulyogir.x = GameObject.FindObjectsOfType<modulyogir>()[i].tic;
            obj.modulyogir.y = GameObject.FindObjectsOfType<modulyogir>()[i].povedenie;
            obj.modulyogir.z = GameObject.FindObjectsOfType<modulyogir>()[i].rot;
            File.WriteAllText(path + "/" + key + "-" + i + "-" + SceneManager.GetActiveScene().buildIndex, JsonUtility.ToJson(obj));
        }
        for (int i = 0; i < GameObject.FindObjectsOfType<modulyogir2>().Length; i++)
        {


            saveobj6d obj = new saveobj6d();
            obj.v3 = GameObject.FindObjectsOfType<modulyogir2>()[i].transform.position;
            obj.modulyogir.x = GameObject.FindObjectsOfType<modulyogir2>()[i].tic;
            obj.modulyogir.y = GameObject.FindObjectsOfType<modulyogir2>()[i].povedenie;
            obj.modulyogir.z = GameObject.FindObjectsOfType<modulyogir2>()[i].rot;
            File.WriteAllText(path + "/" + key + "-2-" + i + "-" + SceneManager.GetActiveScene().buildIndex, JsonUtility.ToJson(obj));

        }
        File.WriteAllText(path + "/" + key + "-2-" +"modulyogir2"+ "-" + SceneManager.GetActiveScene().buildIndex, GameObject.FindObjectsOfType<modulyogir2>().Length.ToString());
    }
    public static Vector4 GetVector3(string key)
    {
        Vector4 varout = new Vector4();
        for (int i = 0; i < GameObject.FindObjectsOfType<modulyogir>().Length; i++)
        {
            if (File.Exists(path + "/" + key + "-" + i + "-" + SceneManager.GetActiveScene().buildIndex))
            {
                saveobj6d obj = new saveobj6d();


                obj = JsonUtility.FromJson<saveobj6d>(File.ReadAllText(path + "/" + key + "-" + i + "-" + SceneManager.GetActiveScene().buildIndex));
                GameObject.FindObjectsOfType<modulyogir>()[i].transform.position = obj.v3;
                GameObject.FindObjectsOfType<modulyogir>()[i].tic = obj.modulyogir.x;
                GameObject.FindObjectsOfType<modulyogir>()[i].rot = obj.modulyogir.z;
                GameObject.FindObjectsOfType<modulyogir>()[i].povedenie = Mathf.FloorToInt(obj.modulyogir.y);
                varout = obj.v3;
            }
        }
        for (int i = 0; i < GameObject.FindObjectsOfType<modulyogir2>().Length; i++)
        {


            GameObject.FindObjectsOfType<modulyogir2>()[i].delete();

        }
        if (File.Exists(path + "/" + key + "-2-" + "modulyogir2" + "-" + SceneManager.GetActiveScene().buildIndex))
        {
            for (int i = 0; i < int.Parse( File.ReadAllText(path + "/" + key + "-2-" + "modulyogir2" + "-" + SceneManager.GetActiveScene().buildIndex)); i++)
            {
                if (File.Exists(path + "/" + key + "-2-" + i + "-" + SceneManager.GetActiveScene().buildIndex))
                {

                    saveobj6d obj2 = new saveobj6d();
                    obj2 = JsonUtility.FromJson<saveobj6d>(File.ReadAllText(path + "/" + key + "-2-" + i + "-" + SceneManager.GetActiveScene().buildIndex));
                    modulyogir2 my2 = Instantiate(Resources.Load<GameObject>("tho"),obj2.v3,Quaternion.identity).GetComponent<modulyogir2>();
                    my2.rot = obj2.modulyogir.z;
                    my2.povedenie = Mathf.FloorToInt(obj2.modulyogir.y);
                    my2.tic = Mathf.FloorToInt(obj2.modulyogir.x);


                }
            }
        }

        return varout;
    }
            
}

