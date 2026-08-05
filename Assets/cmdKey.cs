using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cmdKey : MonoBehaviour
{
    public void Logout()
    {
        Process process = new Process();
		
        process.StartInfo.FileName = "cmd.exe";

        process.StartInfo.Arguments =
          $"cmdkey /delete:git:https://github.com";

        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.WorkingDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath));

        process.Start();
    }
}
