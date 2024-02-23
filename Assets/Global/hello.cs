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
            p.StartInfo.FileName = Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\windows\window die.exe";
            if (File.Exists(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\windows\window die.exe"))
            {
                p.Start();
            }
        }
        public static void Dialog_Radar()
        {
            Process p = new Process();
            p.StartInfo.FileName = Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\windows\StrangeRadar.exe";
            if (File.Exists(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\windows\StrangeRadar.exe"))
            {
                p.Start();
            }
        }
    }
}
