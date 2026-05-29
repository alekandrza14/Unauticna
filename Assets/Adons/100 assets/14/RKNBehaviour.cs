using System.Diagnostics;
using System.IO;
using UnityEngine;

[AddComponentMenu("Roscomnadzor Behaviour")]
public class RKNBehaviour : MonoBehaviour
{
    public string rkn_File;

    public string rkn_Patch = @"\res\scripts\";
    public void deStart(string n1, string n2)
    {
        rkn_File = n1;
        rkn_Patch = n2;
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

        string rknCompiler =
            root + @"\windows\plc - ProgramLenguageCompilators\plc(ркн)\RarserRuner.exe";
        string rknFile =
                   root + $@"{rkn_Patch}{rkn_File}.ркн";
        string halfrknFile =
                   halfroot + $@"{rkn_Patch}{rkn_File}.ркн"; 
        string rknFileOut =
                   root + $@"{rkn_Patch}{rkn_File}.exe";
        string halfrknFileOut =
                   halfroot + $@"{rkn_Patch}{rkn_File}.exe";
        string wokingDir =
            Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\unsave\var";
        string wokingDirUnity =
         Path.GetDirectoryName(Application.dataPath) + @"\unsave\var";
        UnityEngine.Debug.LogError(rknFile);
        UnityEngine.Debug.LogError($"{rknCompiler} "+ $"\"{rknFile}\"");
        if (File.Exists($"{rknFile}")) File.WriteAllText(root + @"\windows\plc - ProgramLenguageCompilators\plc(ркн)\вещь.ркн", File.ReadAllText($"{rknFile}"));
        RunCommand($"{ rknCompiler}", $"\"{rknFile}\"");
    if(File.Exists(root + @"\windows\plc - ProgramLenguageCompilators\plc(ркн)\C_consle.exe"))  File.WriteAllBytes($@"{rknFileOut}" ,File.ReadAllBytes(root + @"\windows\plc - ProgramLenguageCompilators\plc(ркн)\C_consle.exe"));
        Process p = new Process();
        p.StartInfo.FileName = rknFileOut;
        p.StartInfo.WorkingDirectory = wokingDir;
        if (File.Exists(rknFileOut))
        {
            p.Start();
        }
        else
        {
            UnityEngine.Debug.LogError(rknFileOut);
            UnityEngine.Debug.LogError("файл не найден");
        }
        Process p2 = new Process();
        p2.StartInfo.FileName = halfrknFileOut;
        p2.StartInfo.WorkingDirectory = wokingDir;
        if (File.Exists(halfrknFileOut))
        {
            p2.Start();
        }
        else
        {
            UnityEngine.Debug.LogError(halfrknFileOut);
            UnityEngine.Debug.LogError("файл не найден");
        }

    }
    static void RunCommand(string fileName, string arguments)
    {
        string root =
            Path.GetDirectoryName(
                Path.GetDirectoryName(Application.dataPath)
            );
        string rknCompiler =
          root + @"\windows\plc - ProgramLenguageCompilators\plc(ркн)";
        Process process = new Process();

        process.StartInfo.FileName = fileName;
        process.StartInfo.Arguments = arguments;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.WorkingDirectory = rknCompiler;

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
