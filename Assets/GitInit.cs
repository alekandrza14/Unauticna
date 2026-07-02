using UnityEngine;
using System.IO;
using System.Diagnostics;

public class GitInit : MonoBehaviour
{
	public static string FindGit()
	{
		Process p = new Process();
	
		p.StartInfo.FileName = "where";
		p.StartInfo.Arguments = "git";
		p.StartInfo.UseShellExecute = false;
		p.StartInfo.CreateNoWindow = true;
		p.StartInfo.RedirectStandardOutput = true;
	
		p.Start();
	
		string path = p.StandardOutput.ReadLine();
	
		p.WaitForExit();
	
		return path;
	}
    void Start()
    {
        string appDir =
            Directory.GetParent(Application.dataPath).FullName;

        string rootDir =
            Directory.GetParent(appDir).FullName;

        string saveDir =
            Path.Combine(rootDir, "unsave");
        string saveDir2 =
                  Path.Combine(appDir, "unsave");

        string gitExe = FindGit();

        Directory.CreateDirectory(saveDir);
        UnityEngine.Debug.Log(saveDir); 
        UnityEngine.Debug.Log(saveDir2);
        string gitFolder =
            Path.Combine(saveDir, ".git"); 
        string gitFolder2 =
            Path.Combine(saveDir2, ".git");

        if (!Directory.Exists(gitFolder))
        {
            RunGit(gitExe, saveDir, "init");
            RunGit(gitExe, saveDir, "branch -M main");

            File.WriteAllText(
                Path.Combine(saveDir, ".gitignore"),
                "*.tmp\ncache/\n"
            );

               RunGit(gitExe, saveDir, "add .");
               RunGit(gitExe, saveDir, "commit -m \"First Save\"");
        }
        if (!Directory.Exists(gitFolder2))
        {
            RunGit(gitExe, saveDir2, "init");
            RunGit(gitExe, saveDir2, "branch -M main");

            File.WriteAllText(
                Path.Combine(saveDir2, ".gitignore"),
                "*.tmp\ncache/\n"
            );

              RunGit(gitExe, saveDir2, "add .");
              RunGit(gitExe, saveDir2, "commit -m \"First Save\"");
        }
    }

    static void RunGit(
        string gitExe,
        string workingDir,
        string args)
    {
        Process p = new Process();

        p.StartInfo.FileName = gitExe;
        p.StartInfo.Arguments = args;
        p.StartInfo.WorkingDirectory = workingDir;
        p.StartInfo.CreateNoWindow = true;
        p.StartInfo.UseShellExecute = false;

        p.Start();
        p.WaitForExit();
    }
}