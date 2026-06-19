using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class FileControll : EditorWindow
{
    // Start is called before the first frame update

    [MenuItem("Window/File Controle/Parse")]
    public static void ShowWindow()
    {
        GetWindow<FileControll>("render 1");
    }

    private void OnGUI()
    {

        if (GUILayout.Button(".exe to .bc"))
        {
            string path1 = EditorUtility.SaveFilePanel("Choose Location of Save Asset Program", "", "", "exe");
            byte[] file = File.ReadAllBytes(path1);
            StringBuilder bytecode = new StringBuilder();

            foreach (byte b in file)
            {
                bytecode.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
                bytecode.Append(' ');
            }

            string path2 = EditorUtility.SaveFilePanel("Choose Location of Save Asset Byte Code", "", "script", "bc");
            File.WriteAllText(path2, bytecode.ToString().Remove(bytecode.Length-1));
        }
        if (GUILayout.Button(".exe to .asm"))
        {
            string root =
            Path.GetDirectoryName(
                Path.GetDirectoryName(Application.dataPath)
            );
           
            DirectoryInfo dif4 = new DirectoryInfo(@"C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC");
            UnityEngine.Debug.Log(dif4.GetDirectories()[0]);
            string dumpbin = dif4.GetDirectories()[0] + "\\bin\\Hostx64\\x64\\dumpbin.exe";
            //C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC\14.38.33130\bin\Hostx64\x64\dumpbin.exe
            UnityEngine.Debug.Log(dif4.GetDirectories()[0] + "\\bin\\Hostx64\\x64\\dumpbin.exe");
            UnityEngine.Debug.Log(@"C:\Program Files\Microsoft Visual Studio\2022\Community\VC\Tools\MSVC\14.38.33130\bin\Hostx64\x64\dumpbin.exe");
            string path1 = EditorUtility.SaveFilePanel("Choose Location of Save Asset Program", "", "", "exe");
            var proc = Process.Start(new ProcessStartInfo
            {
                FileName = dumpbin,
                Arguments = $"/DISASM \"{path1}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });

            string output = proc.StandardOutput.ReadToEnd();
            string error = proc.StandardError.ReadToEnd();

            proc.WaitForExit(); string savePath = EditorUtility.SaveFilePanel(
    "Save ASM",
    "",
    Path.GetFileNameWithoutExtension(path1),
    "asm");

            if (!string.IsNullOrEmpty(savePath))
            {
                File.WriteAllText(savePath, output);
            }
        }
        if (GUILayout.Button(".bc to.exe"))
        {
            string path1 = EditorUtility.SaveFilePanel("Choose Location of Save Asset Byte Code", "", "", "bc");
            string file = File.ReadAllText(path1);
            string[] bytecode = file.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<byte> bytes = new List<byte>();

            foreach (string s in bytecode)
            {
                bytes.Add(Convert.ToByte(s, 2));
            }
            string path2 = EditorUtility.SaveFilePanel("Choose Location of Save Asset Byte Code", "", "script", "exe");
            File.WriteAllBytes(path2, bytes.ToArray());
        }
        if (GUILayout.Button(".asm to .exe"))
        {
         //   string path1 = EditorUtility.SaveFilePanel("Choose Location of Save Asset Assembler", "", "", "asm");
            string asm = EditorUtility.SaveFilePanel("Choose Location of Save Asset Assembler", "", "", "asm").Replace(".asm","");
            UnityEngine.Debug.Log(asm);
            if (!File.Exists($"{asm}.asm"))
            {
                UnityEngine.Debug.LogError("ASM file not found");
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
                WorkingDirectory = Path.GetDirectoryName( asm)
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
                    "\"" + dif5.GetDirectories()[0] + "\\um\\x64\\user32.lib\" " +
    "\"" + dif5.GetDirectories()[0] + "\\um\\x64\\kernel32.lib\" " +
    "\"" + dif5.GetDirectories()[0] + "\\um\\x64\\winmm.lib\" " +
    "/ENTRY:main /SUBSYSTEM:WINDOWS",

                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WorkingDirectory = Path.GetDirectoryName(asm)
            };
            var p2proc = Process.Start(p2);

            string o2 = p2proc.StandardOutput.ReadToEnd();
            string e2 = p2proc.StandardError.ReadToEnd();
            UnityEngine.Debug.Log(p2.Arguments);
            p2proc.WaitForExit();

            UnityEngine.Debug.Log(o2);
            if (!string.IsNullOrWhiteSpace(e2))
                UnityEngine.Debug.LogError(e2);

            //  string path2 = EditorUtility.SaveFilePanel("Choose Location of Save Asset Byte Code", "", "script", "exe");
        }


    }












    }
/*using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorHyperRenderer : EditorWindow
{
    // Start is called before the first frame update
    public static bool hyperrenderer = false;

    [MenuItem("Window/Rendering/HyperRender")]
    public static void ShowWindow()
    {
        GetWindow<EditorHyperRenderer>("render");
    }

    private void OnGUI()
    {
        hyperrenderer = EditorGUILayout.Toggle("hyperrenderer", hyperrenderer);
        if (EditorGUILayout.LinkButton("HyperRenderstop"))
        {
            hyperrenderer = false;
            for (int i = 0; i < GameObject.FindObjectsOfType<HyperObject2D>().Length; i++)
            {
                if (GameObject.FindObjectsOfType<HyperObject2D>().Length != 0)
                {




                    HyperObject2D.stoprender(GameObject.FindObjectsOfType<HyperObject2D>()[i].transform, GameObject.FindObjectsOfType<HyperObject2D>()[i], SceneView.lastActiveSceneView.HB_Camera.transform.position);

                }

            }
            for (int i = 0; i < GameObject.FindObjectsOfType<LevelsDetermination>().Length; i++)
            {

                if (GameObject.FindObjectsOfType<LevelsDetermination>().Length != 0)
                {



                    LevelsDetermination.Stoprenderdetermination(GameObject.FindObjectsOfType<LevelsDetermination>()[i]);


                }

            }

        }
    }
    private void OnInspectorUpdate()
    {
        if (hyperrenderer)
        {
            for (int i = 0; i < GameObject.FindObjectsOfType<HyperObject2D>().Length; i++)
            {

                if (GameObject.FindObjectsOfType<HyperObject2D>().Length != 0)
                {



                    HyperObject2D.startrender(GameObject.FindObjectsOfType<HyperObject2D>()[i].transform, GameObject.FindObjectsOfType<HyperObject2D>()[i], SceneView.lastActiveSceneView.HB_Camera.transform.position);


                }

            }
            for (int i = 0; i < GameObject.FindObjectsOfType<LevelsDetermination>().Length; i++)
            {

                if (GameObject.FindObjectsOfType<LevelsDetermination>().Length != 0)
                {



                    LevelsDetermination.renderdetermination(GameObject.FindObjectsOfType<LevelsDetermination>()[i]);


                }

            }

        }


    }
        

        
        







}*/