using System.Diagnostics;
using UnityEngine;

public class ExitOSButton : MonoBehaviour
{
    public void Exit()
    {
        Process process = new Process();
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "shutdown";
        startInfo.Arguments = "/s /t 0";
        startInfo.UseShellExecute = true;
        startInfo.Verb = "runas";
        process.StartInfo = startInfo;
        process.Start();
    }
}
