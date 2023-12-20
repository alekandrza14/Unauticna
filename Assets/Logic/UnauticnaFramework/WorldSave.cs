using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveobj6d
{
    public Vector4 v4;
    public Vector3 v3; 
    public Quaternion q;
    public float[] timesoundtrak;
    public Vector3 modulyogir;
}

public class WorldSave1
{
    public Vector4[] v4;
    public Vector4[] sv3;
    public string[] mats;
    public Vector4 pv4;
    public Quaternion w, w2, w3, i, i2;
    public Quaternion[] qs4;
}

public class WorldSave : MonoBehaviour
{
        public Vector4[] v4;
        public Vector4[] sv3;
        public string[] mats;
        public Vector4 pv4;
        public Quaternion w, w2, w3, i, i2;
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
    public static void RemoveVector3()
    {
        for (int i = 0; i < GameObject.FindObjectsOfType<complsave>().Length; i++)
        {
            GameObject.FindObjectsOfType<complsave>()[i].ResetItem();
        }
    }

    public static void SetVector3(string key)
    {
        for (int i = 0; i < GameObject.FindObjectsOfType<RandomItem>().Length; i++)
        {
            GameObject.FindObjectsOfType<RandomItem>()[i].inv();
        }
        for (int i = 0; i < GameObject.FindObjectsByType<complsave>(sortmode.main).Length; i++)
        {
            GameObject.FindObjectsByType<complsave>(sortmode.main)[i].save();
        }
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
        for (int i = 0; i < GameObject.FindObjectsOfType<transport4>().Length; i++)
        {


            saveobj6d obj = new saveobj6d();
            obj.v3 = GameObject.FindObjectsOfType<transport4>()[i].transform.position;
            obj.q = GameObject.FindObjectsOfType<transport4>()[i].transform.rotation;

            File.WriteAllText(path + "/" + key + "-transport-" + i + "-" + SceneManager.GetActiveScene().buildIndex, JsonUtility.ToJson(obj));
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
        File.WriteAllText(path + "/" + key + "-2-" + "modulyogir2" + "-" + SceneManager.GetActiveScene().buildIndex, GameObject.FindObjectsOfType<modulyogir2>().Length.ToString());
    }
    public static void SetMusic(string key)
    {
        Directory.CreateDirectory(path);
        saveobj6d obj = new saveobj6d();
        obj.timesoundtrak = new float[GameObject.FindGameObjectsWithTag("game musig").Length];
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("game musig").Length; i++)
        {
            
            obj.timesoundtrak[i] = GameObject.FindGameObjectsWithTag("game musig")[i].GetComponent<AudioSource>().time;
            

        }
        File.WriteAllText(path + "/" + key + "-music" + "-" + SceneManager.GetActiveScene().buildIndex, JsonUtility.ToJson(obj));

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
        for (int i = 0; i < GameObject.FindObjectsOfType<transport4>().Length; i++)
        {
            if (File.Exists(path + "/" + key + "-transport-" + i + "-" + SceneManager.GetActiveScene().buildIndex))
            {
                saveobj6d obj = new saveobj6d();


                obj = JsonUtility.FromJson<saveobj6d>(File.ReadAllText(path + "/" + key + "-transport-" + i + "-" + SceneManager.GetActiveScene().buildIndex));
                GameObject.FindObjectsOfType<transport4>()[i].transform.position = obj.v3;
                GameObject.FindObjectsOfType<transport4>()[i].transform.rotation = obj.q;

                varout = obj.v3;
            }
        }

        for (int i = 0; i < GameObject.FindObjectsOfType<modulyogir2>().Length; i++)
        {


            GameObject.FindObjectsOfType<modulyogir2>()[i].delete();

        }
        if (File.Exists(path + "/" + key + "-2-" + "modulyogir2" + "-" + SceneManager.GetActiveScene().buildIndex))
        {
            for (int i = 0; i < int.Parse(File.ReadAllText(path + "/" + key + "-2-" + "modulyogir2" + "-" + SceneManager.GetActiveScene().buildIndex)); i++)
            {
                if (File.Exists(path + "/" + key + "-2-" + i + "-" + SceneManager.GetActiveScene().buildIndex))
                {

                    saveobj6d obj2 = new saveobj6d();
                    obj2 = JsonUtility.FromJson<saveobj6d>(File.ReadAllText(path + "/" + key + "-2-" + i + "-" + SceneManager.GetActiveScene().buildIndex));
                    modulyogir2 my2 = Instantiate(Resources.Load<GameObject>("tho"), obj2.v3, Quaternion.identity).GetComponent<modulyogir2>();
                    my2.rot = obj2.modulyogir.z;
                    my2.povedenie = Mathf.FloorToInt(obj2.modulyogir.y);
                    my2.tic = Mathf.FloorToInt(obj2.modulyogir.x);


                }
            }
        }

        return varout;
    }
    public static float[] GetMusic(string key)
    {
        float[] varout = new float[0];
        saveobj6d obj = new saveobj6d(); if (File.Exists(path + "/" + key + "-music" + "-" + SceneManager.GetActiveScene().buildIndex))
        {

            obj = JsonUtility.FromJson<saveobj6d>(File.ReadAllText(path + "/" + key +
            "-music" + "-" + SceneManager.GetActiveScene().buildIndex));
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("game musig").Length
            && obj.timesoundtrak.Length == GameObject.FindGameObjectsWithTag("game musig").Length; i++)
            {





                GameObject.FindGameObjectsWithTag("game musig")[i].GetComponent<AudioSource>().time =
                    obj.timesoundtrak[i];
                varout = obj.timesoundtrak;
            
            }

        }

        return varout;
    }

}

