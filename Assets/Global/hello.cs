using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Dynamic;
using System.Diagnostics;
using UnityEngine;

public class hello
{
    static public class windowmesenge
    {
        public static void Dialog_die()
        {
            Process p = new Process();
            p.StartInfo.Verb = "runas";
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\windows\window die.exe";
            if (File.Exists(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\windows\window die.exe"))
            {
                p.Start();
            }
        }
        public static void Dialog_Radar()
        {
            Process p = new Process();
            p.StartInfo.Verb = "runas";
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\windows\StrangeRadar.exe";
            if (File.Exists(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\windows\StrangeRadar.exe"))
            {
                p.Start();
            }
        }
        public static void LoadApplication(string app)
        {
            Process p = new Process();
            p.StartInfo.FileName = Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\windows\" + app + ".exe";
            p.StartInfo.Verb = "runas";
            p.StartInfo.UseShellExecute = true;
            if (File.Exists(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\windows\" + app + ".exe"))
            {
                p.Start();
            }
            List<string> ovewrite1 = Mod.win();
            foreach (string res in ovewrite1)
            {
                Process p3 = new Process();
                p3.StartInfo.Verb = "runas";
                p3.StartInfo.UseShellExecute = true;
                p3.StartInfo.FileName = Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + res + app + ".exe";
                if (File.Exists(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + res + app + ".exe"))
                {
                    p3.Start();
                }
            }
        }
        public static void LoadLink(string url)
        {
            Process.Start(url);
            
        }
        public static void LoadAHKMacros(string app)
        {
            Process p = new Process();
            p.StartInfo.FileName = Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\res\scripts\" + app + ".exe";
            p.StartInfo.Verb = "runas";
            p.StartInfo.UseShellExecute = true;
            if (File.Exists(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\res\scripts\" + app + ".exe"))
            {
                p.Start();
            }
            List<string> ovewrite1 = Mod.res();
            foreach (string res in ovewrite1)
            {
                Process p3 = new Process();
                p3.StartInfo.FileName = Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + res+@"scripts\" + app + ".exe";
                p3.StartInfo.Verb = "runas";
                p3.StartInfo.UseShellExecute = true;
                if (File.Exists(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + res + @"scripts\" + app + ".exe"))
                {
                    p3.Start();
                }
            }
        }
    }
}
