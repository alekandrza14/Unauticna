using System.Diagnostics;
using System.IO;
using UnityEngine;

[AddComponentMenu("C Хрест Хрест Behaviour")]
public class CCrossCrossBehaviour : MonoBehaviour
{
    public string cmm_File;

    public string cmm_Patch = @"\res\scripts\";
    public void deStart(string n1, string n2)
    {
        cmm_File = n1;
        cmm_Patch = n2;
    }
    void Start()
    {
        string root =
            Path.GetDirectoryName(
                Path.GetDirectoryName(Application.dataPath)
            ); 
        string halfroot =
            Path.GetDirectoryName(Application.dataPath
            );

        string cmmCompiler =
            root + @"\windows\plc - ProgramLenguageCompilators\plc(C††)\RarserRuner.exe";
        string cmmFile =
                   root + $@"{cmm_Patch}{cmm_File}.C††";
        string halfcmmFile =
                   halfroot + $@"{cmm_Patch}{cmm_File}.C††"; 
        string cmmFileOut =
                   root + $@"{cmm_Patch}{cmm_File}.exe";
        string halfcmmFileOut =
                   halfroot + $@"{cmm_Patch}{cmm_File}.exe";
        string wokingDir =
            Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\";
        string wokingDirUnity =
         Path.GetDirectoryName(Application.dataPath) + @"\";
        UnityEngine.Debug.LogError(cmmFile);
        UnityEngine.Debug.LogError($"{cmmCompiler} "+ $"\"{cmmFile}\"");
        if (File.Exists($"{cmmFile}")) File.WriteAllText(root + @"\windows\plc - ProgramLenguageCompilators\plc(C††)\obj.C††", File.ReadAllText($"{cmmFile}"));
        RunCommand($"{ cmmCompiler}", $"\"{cmmFile}\"");
    if(File.Exists(root + @"\windows\plc - ProgramLenguageCompilators\plc(C††)\C_consle.exe"))  File.WriteAllBytes($@"{cmmFileOut}" ,File.ReadAllBytes(root + @"\windows\plc - ProgramLenguageCompilators\plc(C††)\C_consle.exe"));
        Process p = new Process();
        p.StartInfo.FileName = cmmFileOut;
        p.StartInfo.WorkingDirectory = wokingDir;
        if (File.Exists(cmmFileOut))
        {
            p.Start();
        }
        else
        {
            UnityEngine.Debug.LogError(cmmFileOut);
            UnityEngine.Debug.LogError("              ");
        }
        Process p2 = new Process();
        p2.StartInfo.FileName = halfcmmFileOut;
        p2.StartInfo.WorkingDirectory = wokingDirUnity;
        if (File.Exists(halfcmmFileOut))
        {
            p2.Start();
        }
        else
        {
            UnityEngine.Debug.LogError(halfcmmFileOut);
            UnityEngine.Debug.LogError("              ");
        }

    }
    static void RunCommand(string fileName, string arguments)
    {
        string root =
            Path.GetDirectoryName(
                Path.GetDirectoryName(Application.dataPath)
            );
        string cmmCompiler =
          root + @"\windows\plc - ProgramLenguageCompilators\plc(C††)";
        Process process = new Process();

        process.StartInfo.FileName = fileName;
        process.StartInfo.Arguments = arguments;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.WorkingDirectory = cmmCompiler;

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
