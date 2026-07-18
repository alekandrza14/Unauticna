using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System;

public class GitInit : MonoBehaviour
{
    public static class Crypto
    {
        const string Key = "123456789...";
        public static string Encrypt(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);

            byte[] encrypted = data;
      //      System.Security.Cryptography.
        //    byte[] encrypted = System.Security.Cryptography..Protect(
           //     data,
          //      null,
             //   DataProtectionScope.CurrentUser
          //  );

            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string text)
        {
            byte[] encrypted = Convert.FromBase64String(text);
            byte[] data = encrypted;
        //   byte[] data = ProtectedData.Unprotect(
        //     encrypted,
        //      null,
        //     DataProtectionScope.CurrentUser
        //   );

            return Encoding.UTF8.GetString(data);
        }
    }
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
    //alek and rza 14
    public InputField log;
    public InputField mal;
    public InputField toc;
    static public string githubLogin = "";
	static public string githubMail = "";
    static public string githubToken = "";
    public void Button(bool los)
    {
        loadDate(los,new InputField[] {log,toc,mal });
    }
   
    public static void loadDate(bool los, InputField[] ifds)
    {
        githubLogin = ifds[0].text;
        githubToken = ifds[1].text;
        githubMail = ifds[2].text;
        Date(los);//true save / false load
    }
    public static void Date(bool load_or_save)
    {
        //  githubLogin = PlayerPrefs.GetString("log");- не сохран€ю беру сразу из инпут филда
        //   githubToken = PlayerPrefs.GetString("toc");- не сохран€ю беру сразу из инпут филда
        string appDir =
            Directory.GetParent(Application.dataPath).FullName;

        string rootDir =
            Directory.GetParent(appDir).FullName;

        string saveDir =
            Path.Combine(rootDir, "unsave");
        string saveDir2 =
                  Path.Combine(appDir, "unsave");

        string gitExe = "C:\\Program Files\\Git\\bin\\git.exe";

        Directory.CreateDirectory(saveDir);
        UnityEngine.Debug.Log(saveDir); 
        UnityEngine.Debug.Log(saveDir2);
        string gitFolder =
            Path.Combine(saveDir, ".git"); 
        string gitFolder2 =
            Path.Combine(saveDir2, ".git");
        if (load_or_save) {
            if (!Directory.Exists(gitFolder))
            {
                RunGit(gitExe, saveDir, "init");

                RunGit(gitExe, saveDir, "config user.name \"" + githubLogin + "\"");
                RunGit(gitExe, saveDir, "config user.email \"" + githubMail + "\"");

                // безопасно: удал€ем если есть
                RunGit(gitExe, saveDir, "remote remove origin");

                RunGit(
                    gitExe,
                    saveDir,
                    "remote add origin https://" +
                    githubLogin + ":" +
                    githubToken +
                    "@github.com/" +
                    githubLogin +
                    "/YourAcount.git"
                );

                RunGit(gitExe, saveDir, "fetch origin");

                // если ветка есть Ч переключаемс€, если нет Ч создаЄм
                RunGit(gitExe, saveDir, "checkout -B unsave origin/unsave");

                RunGit(gitExe, saveDir, "add .");
                RunGit(gitExe, saveDir, "commit -m \"First Save\"");
                RunGit(gitExe, saveDir, "push -u origin unsave");
            }
            else
            {
                RunGit(gitExe, saveDir, "fetch origin");
                RunGit(gitExe, saveDir, "checkout unsave");
                RunGit(gitExe, saveDir, "commit -m \"Autosave\"");
                RunGit(gitExe, saveDir, "pull origin unsave");
            }
        }
        else
        {
            RunGit(gitExe, saveDir, "fetch origin");
            RunGit(gitExe, saveDir, "checkout unsave");
            RunGit(gitExe, saveDir, "pull origin unsave");
        }
        /*  if (!Directory.Exists(gitFolder2))
          {
              RunGit(gitExe, saveDir2, "init");
              RunGit(gitExe, saveDir2, "branch -M main");

              File.WriteAllText(
                  Path.Combine(saveDir2, ".gitignore"),
                  "*.tmp\ncache/\n"
              );

                RunGit(gitExe, saveDir2, "add .");
                RunGit(gitExe, saveDir2, "commit -m \"First Save\"");
          }*/
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