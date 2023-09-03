using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
using UnityEditor.Build;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class ScriptBatch
{
    static int mainversion = 0; static int neoversion = 2; static int version = 0;
    [MenuItem("My Build Tools/Windows Build With Postprocess")]
    public static void BuildGame()
    {
        // Get filename.
        string path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", "C:/Data", "");

        List<string> levels = new List<string>();
        
        for (int i=0;i<SceneManager.sceneCountInBuildSettings;i++)
        {
            EditorBuildSettingsScene[] s = EditorBuildSettings.scenes;
            levels.Add(s[i].path);
        }
        Directory.CreateDirectory(path + "/Application");
        // Build player.
        BuildPipeline.BuildPlayer(levels.ToArray(), path + "/Application/Unauticna.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);
        //_" + mainversion + "." + neoversion + "." + version + "
        // Copy a file from the project folder to the build folder, alongside the built game.
        if (!File.Exists(path + "/Launcher Unauticna.exe")) {
            FileUtil.CopyFileOrDirectory("Assets/Editor/dop.app/Launcher Unauticna.exe", path + "/Launcher Unauticna.exe");
          //  FileUtil.CopyFileOrDirectory("Assets/Editor/dop.app/startup.ex.exe", path + "/Application/Unauticna_sig.exe");
          //  FileUtil.CopyFileOrDirectory("Assets/Editor/dop.app/startup.ex2.exe", path + "/Application/Unauticna.exe");
        }

        Directory.CreateDirectory(path + "/Application");
        Directory.Delete(path + "/windows",true);
        FileUtil.CopyFileOrDirectory("windows", path + "/windows");
        Directory.Delete(path + "/res", true);
        FileUtil.CopyFileOrDirectory("res", path + "/res");

        // Run the game (Process class from System.Diagnostics).
        /*
        Process proc = new Process();
        proc.StartInfo.FileName = path + "/Application/Unauticna.exe";
        proc.Start();*/
      
    }
}