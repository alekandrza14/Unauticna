using UnityEngine;
using System.IO;
using System.Diagnostics;
using System;

public class ProxyPyton : MonoBehaviour
{
    private static bool init; 
    private Vector3 targetPosition;
    private static Process PytonCode;
    public float speed = 3f;
    private void Start()
    {

       if(Directory.Exists("debug")) File.WriteAllText("debug/debug.log", "Insrution.ini " + File.Exists("res/cmd/Insrution.ini") + "\n"+
            "/res/proxys/ProxyPyton.exe = " + System.IO.Path.GetDirectoryName(UnityEngine.Application.dataPath) + "/res/proxys/ProxyPyton.exe");
        if (!init) 
        {
            Process poc = new Process();
#if UNITY_EDITOR
            poc.StartInfo.FileName = Environment.CurrentDirectory + "/res/proxys/ProxyPyton.exe";
#elif PLATFORM_STANDALONE_WIN
            poc.StartInfo.FileName = Path.GetDirectoryName(Path.GetDirectoryName(UnityEngine.Application.dataPath)) + "/res/proxys/ProxyPyton.exe";
#endif
          
            PytonCode = poc;
            Process poc2 = new Process();
            poc2.StartInfo.FileName = @"C:\Windows\System32\cmd.exe";
#if UNITY_EDITOR
            poc.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
#elif PLATFORM_STANDALONE_WIN
               poc.StartInfo.WorkingDirectory = Path.GetDirectoryName(Path.GetDirectoryName(UnityEngine.Application.dataPath)) + "";
#endif
#if !UNITY_EDITOR
            string file = File.ReadAllText("res/cmd/Insrution.ini");
            poc2.StartInfo.ArgumentList.Add(file.Split('+')[0].Replace("+", ""));
            poc2.StartInfo.ArgumentList.Add(file.Split('+')[1].Replace("+", ""));
            init = true;
            poc2.Start(); 
            //Bulid
#endif
            poc.Start();
        }
    }
    private void OnApplicationQuit()
    {
        PytonCode.Kill();
    }
    private void Update()
    {
        move();
        transform.position = Vector3.MoveTowards(
       transform.position,
       targetPosition,
       speed * Time.deltaTime
   );
    }
    private string Root()
    {
        return gameObject.name;
    }
    private Vector3 move()
    {
        if (!File.Exists("res/temp/Input/" + Root()+"_pos.uns"))
        {
            Directory.CreateDirectory("res/temp/Input/");
            File.WriteAllText("res/temp/Input/" + Root() + "_pos.uns",( gameObject.transform.position.x+"+"+ gameObject.transform.position.y+"+" + gameObject.transform.position.z).Replace(",", "."));
        }
        else
        {
            File.WriteAllText("res/temp/Input/" + Root() + "_pos.uns", (gameObject.transform.position.x + "+" + gameObject.transform.position.y + "+" + gameObject.transform.position.z).Replace(",","."));

        }
        if(File.Exists("res/temp/Output/" + Root() + "_pos.uns"))
        {
            string file = File.ReadAllText("res/temp/Output/" + Root() + "_pos.uns").Replace(".", ",");
            if (file.Contains("+"))
            {
                float x; x = float.Parse(file.Split('+')[0].Replace("+", ""));
                float y; y = float.Parse(file.Split('+')[1].Replace("+", ""));
                float z; z = float.Parse(file.Split('+')[2].Replace("+", ""));
                targetPosition = new Vector3(x,y,z);
            }
        }
        return transform.position;
    }
}
