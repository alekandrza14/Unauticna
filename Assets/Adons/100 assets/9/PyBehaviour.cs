using UnityEngine;
using System.Diagnostics;
using System.IO;

[AddComponentMenu("Pyton Behaviour")]
public class PyBehaviour : MonoBehaviour
{
    public string py_File;
    public string py_Patch = @"res\scripts\";
    public void deStart(string n1, string n2)
    {
        py_File = n1;
        py_Patch = n2;
    }
    void Start()
    {
       


            string py = py_File;
            string pythonExe =
               @"C:\Users\User\AppData\Local\Programs\Python\Python313\python.exe";
            string pythonFile =
               Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + "\\" + py_Patch + py_File + ".py";
            string outputDir =
             Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + "\\" + py_Patch + "BuildPython";
            string wokingDir =
             Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\unsave\var";
            string wokingDirUnity =
             Path.GetDirectoryName(Application.dataPath) + @"\unsave\var";
            string args =
                $"-m PyInstaller --onefile --distpath \"{outputDir}\" \"{pythonFile}\"";
            RunCommand(pythonExe, "-m pip install pyinstaller");
            RunCommand(pythonExe, args);
            UnityEngine.Debug.Log(pythonFile);
            UnityEngine.Debug.Log(outputDir);
            UnityEngine.Debug.Log(wokingDir);
            UnityEngine.Debug.Log("Готово!");
            UnityEngine.Debug.Log("EXE файл будет в папке dist");
        Process[] processes = Process.GetProcessesByName($"{py_File}.exe");
        if (processes.Length > 0)
        {

        }
        else
        {
            Process p = new Process();
            p.StartInfo.FileName = Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + "\\" + py_Patch + @"BuildPython\" + $"{py}.exe";
            p.StartInfo.WorkingDirectory = wokingDir;
            if (File.Exists(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + "\\" + py_Patch + @"BuildPython\" + $"{py}.exe"))
            {
                p.Start();
            }
            else
            {
                UnityEngine.Debug.LogError(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + "\\" + py_Patch + @"BuildPython\" + $"{py}.exe");
                UnityEngine.Debug.LogError("файл не найден");
            }
            Process p2 = new Process();
            p2.StartInfo.FileName = Path.GetDirectoryName(Application.dataPath) + "\\" + py_Patch + @"BuildPython\" + $"{py}.exe";
            p2.StartInfo.WorkingDirectory = wokingDirUnity;
            if (File.Exists(Path.GetDirectoryName(Application.dataPath) + "\\" + py_Patch + @"BuildPython\" + $"{py}.exe"))
            {
                p2.Start();
            }
            else
            {
                UnityEngine.Debug.LogError(Path.GetDirectoryName(Application.dataPath) + "\\" + py_Patch + @"BuildPython\" + $"{py}.exe");
                UnityEngine.Debug.LogError("файл не найден");
            }
        }
    }
    static void RunCommand(string fileName, string arguments)
    {
        Process process = new Process();

        process.StartInfo.FileName = fileName;
        process.StartInfo.Arguments = arguments;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;

        process.OutputDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
                UnityEngine.Debug.Log(e.Data);
        };

        process.ErrorDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrEmpty(e.Data))
                UnityEngine.Debug.Log(e.Data);
        };

        process.Start();

        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        process.WaitForExit();
    }
}
