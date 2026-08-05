using System.Runtime.InteropServices;
using UnityEngine;
using System.Diagnostics;
using System;
using System.IO;


public class CppRealtime : MonoBehaviour
{
    [DllImport("AssemblyCPP")]
    public static extern long my_cpp_pluss(long a, long b);
	public string CppExe = "Main.exe";
    Process p = new Process();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p.StartInfo.FileName =  Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath))+@"\res\ExeRealtime\"+CppExe;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.CreateNoWindow = true;

        p.Start();
        string line = p.StandardOutput.ReadLine();
        UnityEngine.Debug.Log(line);
    }
	float timer;
	string line;
    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;
		if(timer > 0.2f)
		{
			if (Input.GetKey(KeyCode.W))
			{
				p.StandardInput.WriteLine("INPUT W=1");
				flush();
			}
			if (Input.GetKey(KeyCode.A))
			{
				p.StandardInput.WriteLine("INPUT A=1");
				flush();
			}
			if (Input.GetKey(KeyCode.S))
			{
				p.StandardInput.WriteLine("INPUT S=1");
				flush();
			}
			if (Input.GetKey(KeyCode.D))
			{
				p.StandardInput.WriteLine("INPUT D=1");
				flush();
			}
			if (Input.GetKey(KeyCode.Space))
			{
				p.StandardInput.WriteLine("INPUT SPACE=1");
				flush();
			}
			//FRAME
			if(true)
			{
				p.StandardInput.WriteLine("FRAME");
				flush();
			}
        }
		if (Input.GetKeyDown(KeyCode.W))
		{
			p.StandardInput.WriteLine("INPUT Wdw=1");
			flush();
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			p.StandardInput.WriteLine("INPUT Adw=1");
			flush();
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			p.StandardInput.WriteLine("INPUT Sdw=1");
			flush();
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			p.StandardInput.WriteLine("INPUT Ddw=1");
			flush();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			p.StandardInput.WriteLine("INPUT SPACEdw=1");
			flush();
		}
		
		if (Input.GetKeyUp(KeyCode.W))
		{
			p.StandardInput.WriteLine("INPUT Wup=1");
			flush();
		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			p.StandardInput.WriteLine("INPUT Aup=1");
			flush();
		}
		if (Input.GetKeyUp(KeyCode.S))
		{
			p.StandardInput.WriteLine("INPUT Sup=1");
			flush();
		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			p.StandardInput.WriteLine("INPUT Dup=1");
			flush();
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			p.StandardInput.WriteLine("INPUT  SPACEup=1");
			flush();
		}
		
		
		
       
    }
	void flush()
	{
		p.StandardInput.Flush();
		line = p.StandardOutput.ReadLine();
		//UnityEngine.Debug.Log(line);
		string[] splitedLine = line.Split(" "[0]);
		if(splitedLine[0]=="SPAWN")
		{
			GameObject obj = Resources.Load<GameObject>("items/"+splitedLine[1]);
			Instantiate(obj, transform.position+new Vector3(float.Parse( splitedLine[2].Replace(" ","")),float.Parse(splitedLine[3].Replace(" ","")),float.Parse(splitedLine[4].Replace(" ",""))), Quaternion.identity);
		}
		if(splitedLine[0]=="MOVE")
		{
			
			transform.Translate(new Vector3(float.Parse(splitedLine[2].Replace(" ","")),float.Parse(splitedLine[3].Replace(" ","")),float.Parse(splitedLine[4].Replace(" ",""))));
		}
		if(splitedLine[0]=="ROT")
		{
			
			transform.Rotate(new Vector3(float.Parse(splitedLine[2].Replace(" ","")),float.Parse(splitedLine[3].Replace(" ","")),float.Parse(splitedLine[4].Replace(" ",""))));
		}
	}
}
