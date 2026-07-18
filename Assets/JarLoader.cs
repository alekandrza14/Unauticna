using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using System.Text.RegularExpressions;

public class JarLoader : MonoBehaviour
{
    public InputField console;
    public VideoPlayer videos;
    void Start()
    {
        string path = Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\javaMods";
        DirectoryInfo dir = new DirectoryInfo(path);
        string log = "";
        foreach (FileInfo file in dir.GetFiles())
        {
            if (file.Name.Contains(".jar"))
            {
                string modname = file.Name.Replace(".jar", "");
                Process process = new Process();


                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments =
                    $"chcp 65001 && /C cd /d \"{Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath))}\" && java -jar \"javaMods\\{modname}.jar\" ReInstaill";

                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
             if(!output.Contains("https")) 
			 {  if(output.Contains(".mp4"))
                {
                    videos.url = Regex.Replace($"file://C:/data/{output}", @"\r\n?|\n", "");
                    videos.Play();
				}
			}
			else
			{	 
				if(output.Contains(".mp4"))
                {
                    videos.url = Regex.Replace($"{output}", @"\r\n?|\n", "");
                    videos.Play();
                }
			}
                process.WaitForExit();
                UnityEngine.Debug.Log($"- {modname}.jar : "+output+"\n");
                log += $"- {modname}.jar : " + output + "\n";
            }
        }
        console.text = log;
    }
	//file://C:/data/video.mp4
	//file://C:/data/video.mp4
}
