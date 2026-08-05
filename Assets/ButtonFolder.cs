using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFolder : MonoBehaviour
{
    public string user;
    public Text txt;
    void Start()
    {
        txt.text = user;
    }
    public void DownloadOurMods()
    {
        string appDir =
           Directory.GetParent(Application.dataPath).FullName;

        string rootDir =
            Directory.GetParent(appDir).FullName;

        string PubDir =
            Path.Combine(rootDir, "res/OurWorkspace/"+ user.Replace("/", "").Replace("\\", ""));
        Directory.CreateDirectory(PubDir);
        string gitExe = "C:\\Program Files\\Git\\bin\\git.exe";
        //clone https://github.com/UnderTaleSub/YourAcount.git
        RunGit(gitExe, PubDir, "clone -b ModPblishing https://github.com/" + user + ".git OurMods");

    }
    static void RunGit(string gitExe, string workingDir, string args)
    {
        Process p = new Process();

        p.StartInfo.FileName = gitExe;
        p.StartInfo.Arguments = args;
        p.StartInfo.WorkingDirectory = workingDir;
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;

        p.Start();

        string output = p.StandardOutput.ReadToEnd();
        string error = p.StandardError.ReadToEnd();

        p.WaitForExit();

        UnityEngine.Debug.Log(output);

        if (!string.IsNullOrEmpty(error))
            UnityEngine.Debug.LogError(error);
    }
}
