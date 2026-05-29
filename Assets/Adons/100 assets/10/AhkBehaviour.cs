using UnityEngine;
using System.Diagnostics;
using System.IO;

[AddComponentMenu("AutoHotkey Behaviour")]
public class AhkBehaviour : MonoBehaviour
{
    public string ahkFile;

    public string ahk_Patch = @"\res\scripts\";
    public void deStart(string n1, string n2)
    {
        ahkFile = n1;
        ahk_Patch = n2;
    }
    void Start()
    {
        string root =
            Path.GetDirectoryName(
                Path.GetDirectoryName(Application.dataPath)
            );

        string ahkCompiler =
            @"C:\Program Files\AutoHotkey\Compiler\Ahk2Exe.exe";

        string script =
            root + ahk_Patch + ahkFile + ".ahk";

        string output =
            root + ahk_Patch + ahkFile + ".exe";

        UnityEngine.Debug.Log(script);
        if (!File.Exists(script))
        {
            UnityEngine.Debug.LogError("AHK script not found");
            return;
        }
        UnityEngine.Debug.Log(script);
        string args =
            $"/in \"{script}\" /out \"{output}\"";

        RunCommand(ahkCompiler, args);

        UnityEngine.Debug.Log("Compile Complete");
        Process[] processes = Process.GetProcessesByName($"{ahkFile}.exe");
        if (processes.Length > 0)
        {

        }
        else
        {
            if (File.Exists(output))
            {
                Process.Start(output);
            }
        }
    }

    static void RunCommand(string fileName, string arguments)
    {
        using (Process process = new Process())
        {
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
                    UnityEngine.Debug.LogError(e.Data);
            };

            process.Start();

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.WaitForExit();
        }
    }
}
