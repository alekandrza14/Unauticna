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
    public void Button(string los)
    {
        loadDate(los,new InputField[] {log,toc,mal });
    }
   
    public static void loadDate(string los, InputField[] ifds)
    {
        Date(los,ifds);//true save / false load
    }
    public static void Date(string Atrib, InputField[] ifds)
    {
        //  githubLogin = PlayerPrefs.GetString("log");- не сохран€ю беру сразу из инпут филда
        //   githubToken = PlayerPrefs.GetString("toc");- не сохран€ю беру сразу из инпут филда
        string appDir =
            Directory.GetParent(Application.dataPath).FullName;

        string rootDir =
            Directory.GetParent(appDir).FullName;

        string saveDir =
            Path.Combine(rootDir, "unsave");
        string PubDir =
                  Path.Combine(rootDir, "OurWorkspace");

        string gitExe = "C:\\Program Files\\Git\\bin\\git.exe";

        Directory.CreateDirectory(saveDir);
        UnityEngine.Debug.Log(saveDir); 
        UnityEngine.Debug.Log(PubDir);
        string gitFolder =
            Path.Combine(saveDir, ".git"); 
        string gitFolder2 =
            Path.Combine(PubDir, ".git");
        if (Atrib == "Create") {
            if (!Directory.Exists(gitFolder))
            {
                RunGit(gitExe, saveDir, "init");
				RunGit(gitExe, saveDir, "add .");
				RunGit(gitExe, saveDir, "commit -m \"SaveComit\"");
				RunGit(gitExe, saveDir, $"remote add origin https://github.com/"+ifds[0].text+"/YourAcount.git");
			
                
            }
            else
            {
            }
        }
        else if (Atrib == "Save")
        {
			//RunGit(gitExe, saveDir, $"remote add origin https://github.com/"+ifds[0].text+"/UnauticnaSave.git");
			RunGit(gitExe, saveDir, "add .");
			RunGit(gitExe, saveDir, "commit -m \"SaveComit\"");
			RunGit(gitExe, saveDir, "push -u origin master");
			//git remote add origin https://github.com/ВашЛогин/ИмяРепозитория.git
			//git branch -M main
			//git push -u origin main
        } else if (Atrib == "Load")
        {
			//RunGit(gitExe, saveDir, $"remote add origin https://github.com/"+ifds[0].text+"/UnauticnaSave.git");
			RunGit(gitExe, saveDir, "fetch origin");
			RunGit(gitExe, saveDir, "add .");
			RunGit(gitExe, saveDir, "reset --hard origin/master");
			RunGit(gitExe, saveDir, "restore .");
			//git remote add origin https://github.com/ВашЛогин/ИмяРепозитория.git
			//git branch -M main
			//git push -u origin main
        } if (Atrib == "PubCreate") {
            if (!Directory.Exists(gitFolder2))
            {
                RunGit(gitExe, PubDir, "init");
				RunGit(gitExe, PubDir, "branch -M ModPblishing");
				RunGit(gitExe, PubDir, "add .");
				RunGit(gitExe, PubDir, "commit -m \"SaveComit\"");
				RunGit(gitExe, PubDir, $"remote add origin https://github.com/"+ifds[0].text+"/YourAcount.git");
			
                
            }
            else
            {
            }
        }
        else if (Atrib == "PubSave")
        {
			//RunGit(gitExe, saveDir, $"remote add origin https://github.com/"+ifds[0].text+"/UnauticnaSave.git");
			RunGit(gitExe, PubDir, "branch -M ModPblishing");
			RunGit(gitExe, PubDir, "add .");
			RunGit(gitExe, PubDir, "commit -m \"SaveComit\"");
			RunGit(gitExe, PubDir, "push -u origin ModPblishing");
			//git remote add origin https://github.com/ВашЛогин/ИмяРепозитория.git
			//git branch -M main
			//git push -u origin main
        } else if (Atrib == "PubLoad")
        {
			//RunGit(gitExe, saveDir, $"remote add origin https://github.com/"+ifds[0].text+"/UnauticnaSave.git");
			RunGit(gitExe, PubDir, "fetch origin");
			RunGit(gitExe, PubDir, "add .");
			RunGit(gitExe, PubDir, "reset --hard origin/ModPblishing");
			RunGit(gitExe, PubDir, "restore .");
			//git remote add origin https://github.com/ВашЛогин/ИмяРепозитория.git
			//git branch -M main
			//git push -u origin main
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