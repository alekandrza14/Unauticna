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
        for (int i = 0; i < GameObject.FindObjectsByType<scrollbareditWpos>(sortmode.main).Length; i++)
        {


            saveobj6d obj = new saveobj6d();
            obj.v4.w = GameObject.FindObjectsByType<scrollbareditWpos>(sortmode.main)[i].Wpos.value;
            File.WriteAllText(path + "/" + key + "-" + i + "-" + SceneManager.GetActiveScene().buildIndex, JsonUtility.ToJson(obj));
        }
    }
    public static Vector4 GetVector4(string key)
    {
        Vector4 varout = new Vector4();
        for (int i = 0; i < GameObject.FindObjectsByType<scrollbareditWpos>(sortmode.main).Length; i++)
        {
            if (File.Exists(path + "/" + key + "-" + i + "-" + SceneManager.GetActiveScene().buildIndex))
            {
                saveobj6d obj = new saveobj6d();


                obj = JsonUtility.FromJson<saveobj6d>(File.ReadAllText(path + "/" + key + "-" + i + "-" + SceneManager.GetActiveScene().buildIndex));
                GameObject.FindObjectsByType<scrollbareditWpos>(sortmode.main)[i].Wpos.value = obj.v4.w;
                varout = obj.v4;
            }
        }
        return varout;
    }
    public static void RemoveVector3()
    {
        for (int i = 0; i < GameObject.FindObjectsByType<complsave>(sortmode.main).Length; i++)
        {
            GameObject.FindObjectsByType<complsave>(sortmode.main)[i].ResetItem();
        }
    }

    public static void SetVector3(string key)
    {
        for (int i = 0; i < GameObject.FindObjectsByType<RandomItem>(sortmode.main).Length; i++)
        {
            GameObject.FindObjectsByType<RandomItem>(sortmode.main)[i].inv();
        }
        for (int i = 0; i < GameObject.FindObjectsByType<complsave>(sortmode.main).Length; i++)
        {
            GameObject.FindObjectsByType<complsave>(sortmode.main)[i].save();
        }
        Directory.CreateDirectory(path);
        for (int i = 0; i < GameObject.FindObjectsByType<modulyogir>(sortmode.main).Length; i++)
        {


            saveobj6d obj = new saveobj6d();
            obj.v3 = GameObject.FindObjectsByType<modulyogir>(sortmode.main)[i].transform.position;
            obj.modulyogir.x = GameObject.FindObjectsByType<modulyogir>(sortmode.main)[i].tic;
            obj.modulyogir.y = GameObject.FindObjectsByType<modulyogir>(sortmode.main)[i].povedenie;
            obj.modulyogir.z = GameObject.FindObjectsByType<modulyogir>(sortmode.main)[i].rot;
            File.WriteAllText(path + "/" + key + "-" + i + "-" + SceneManager.GetActiveScene().buildIndex, JsonUtility.ToJson(obj));
        }
        for (int i = 0; i < GameObject.FindObjectsByType<transport4>(sortmode.main).Length; i++)
        {


            saveobj6d obj = new saveobj6d();
            obj.v3 = GameObject.FindObjectsByType<transport4>(sortmode.main)[i].transform.position;
            obj.q = GameObject.FindObjectsByType<transport4>(sortmode.main)[i].transform.rotation;

            File.WriteAllText(path + "/" + key + "-transport-" + i + "-" + SceneManager.GetActiveScene().buildIndex, JsonUtility.ToJson(obj));
        }
        for (int i = 0; i < GameObject.FindObjectsByType<modulyogir2>(sortmode.main).Length; i++)
        {


            saveobj6d obj = new saveobj6d();
            obj.v3 = GameObject.FindObjectsByType<modulyogir2>(sortmode.main)[i].transform.position;
            obj.modulyogir.x = GameObject.FindObjectsByType<modulyogir2>(sortmode.main)[i].tic;
            obj.modulyogir.y = GameObject.FindObjectsByType<modulyogir2>(sortmode.main)[i].povedenie;
            obj.modulyogir.z = GameObject.FindObjectsByType<modulyogir2>(sortmode.main)[i].rot;
            File.WriteAllText(path + "/" + key + "-2-" + i + "-" + SceneManager.GetActiveScene().buildIndex, JsonUtility.ToJson(obj));

        }
        File.WriteAllText(path + "/" + key + "-2-" + "modulyogir2" + "-" + SceneManager.GetActiveScene().buildIndex, GameObject.FindObjectsByType<modulyogir2>(sortmode.main).Length.ToString());
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
        for (int i = 0; i < GameObject.FindObjectsByType<modulyogir>(sortmode.main).Length; i++)
        {
            if (File.Exists(path + "/" + key + "-" + i + "-" + SceneManager.GetActiveScene().buildIndex))
            {
                saveobj6d obj = new saveobj6d();


                obj = JsonUtility.FromJson<saveobj6d>(File.ReadAllText(path + "/" + key + "-" + i + "-" + SceneManager.GetActiveScene().buildIndex));
                GameObject.FindObjectsByType<modulyogir>(sortmode.main)[i].transform.position = obj.v3;
                GameObject.FindObjectsByType<modulyogir>(sortmode.main)[i].tic = obj.modulyogir.x;
                GameObject.FindObjectsByType<modulyogir>(sortmode.main)[i].rot = obj.modulyogir.z;
                GameObject.FindObjectsByType<modulyogir>(sortmode.main)[i].povedenie = Mathf.FloorToInt(obj.modulyogir.y);
                varout = obj.v3;
            }
        }
        for (int i = 0; i < GameObject.FindObjectsByType<transport4>(sortmode.main).Length; i++)
        {
            if (File.Exists(path + "/" + key + "-transport-" + i + "-" + SceneManager.GetActiveScene().buildIndex))
            {
                saveobj6d obj = new saveobj6d();


                obj = JsonUtility.FromJson<saveobj6d>(File.ReadAllText(path + "/" + key + "-transport-" + i + "-" + SceneManager.GetActiveScene().buildIndex));
                GameObject.FindObjectsByType<transport4>(sortmode.main)[i].transform.position = obj.v3;
                GameObject.FindObjectsByType<transport4>(sortmode.main)[i].transform.rotation = obj.q;

                varout = obj.v3;
            }
        }

        for (int i = 0; i < GameObject.FindObjectsByType<modulyogir2>(sortmode.main).Length; i++)
        {


            GameObject.FindObjectsByType<modulyogir2>(sortmode.main)[i].delete();

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

