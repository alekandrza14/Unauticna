using System.Diagnostics;
using System;
using System.IO;
using UnityEngine;

[AddComponentMenu("Assembler Behaviour")]
public class ASMBehaviour : InventoryEvent
{

    public string asm_File;
    public string asm_Patch = @"res\scripts\";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void deStart(string n1, string n2)
    {
        asm_File = n1;
        asm_Patch = n2;
    }
    public void Start()
    {
        string asm = asm_File;

        if (!File.Exists(asm_Patch + $"{asm}.asm"))
        {
            UnityEngine. Debug.LogError("ASM file not found");
            return;
        }
        DirectoryInfo dif4 = new DirectoryInfo(@"C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC");
        UnityEngine.Debug.Log(dif4.GetDirectories()[0]);
        string ml64 = dif4.GetDirectories()[0] + @"\bin\Hostx64\x64\ml64.exe";
        string link = dif4.GetDirectories()[0] + @"\bin\Hostx64\x64\link.exe";

        // 1. ASM -> OBJ
        var p1 = Process.Start(new ProcessStartInfo
        {
            FileName = ml64,
            Arguments = $"/c \"{asm}.asm\"",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
            WorkingDirectory = asm_Patch
        }); ;

        string o1 = p1.StandardOutput.ReadToEnd();
        string e1 = p1.StandardError.ReadToEnd();
        p1.WaitForExit();

        UnityEngine.Debug.Log(o1);
        if (!string.IsNullOrWhiteSpace(e1))
            UnityEngine.Debug.LogError(e1);

        if (p1.ExitCode != 0) return;
        DirectoryInfo dif5 = new DirectoryInfo("C:\\Program Files (x86)\\Windows Kits\\10\\Lib");
        UnityEngine.Debug.Log(dif5.GetDirectories()[0]);
        // 2. OBJ -> EXE
        var p2 = new ProcessStartInfo
        {
            FileName = link,
            Arguments =
                $"\"{asm}.obj\" " +
                "\""+dif5.GetDirectories()[0]+"\\um\\x64\\user32.lib\" " +
"\"" + dif5.GetDirectories()[0] + "\\um\\x64\\kernel32.lib\" " +
"\"" + dif5.GetDirectories()[0] + "\\um\\x64\\winmm.lib\" " +
"/ENTRY:main /SUBSYSTEM:WINDOWS",

            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true,
            WorkingDirectory = asm_Patch
        };

        var p2proc = Process.Start(p2);

        string o2 = p2proc.StandardOutput.ReadToEnd();
        string e2 = p2proc.StandardError.ReadToEnd();
        UnityEngine.Debug.Log(p2.Arguments);
        p2proc.WaitForExit();

        UnityEngine.Debug.Log(o2);
        if (!string.IsNullOrWhiteSpace(e2))
            UnityEngine.Debug.LogError(e2);
        //                   Process.Start("res/scripts/" + $"{asm}.exe");
        Process[] processes = Process.GetProcessesByName($"{asm}.exe");
        if (processes.Length > 0)
        {

        }
        else
        {
            Process p = new Process();
            p.StartInfo.FileName = Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\" + asm_Patch + $"{asm}.exe";
            if (File.Exists(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\" + asm_Patch + $"{asm}.exe"))
            {
                p.Start();
            }
            Process p11 = new Process();
            p11.StartInfo.FileName = Path.GetDirectoryName((Application.dataPath)) + @"\" + asm_Patch + $"{asm}.exe";
            if (File.Exists(Path.GetDirectoryName((Application.dataPath)) + @"\" + asm_Patch + $"{asm}.exe"))
            {
                p11.Start();
            }
        }
    }
}     