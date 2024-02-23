using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum SaveType
{
    local,global,world,computer
}

public class VarSave
{
    public static string path = "unsave/var";
    public static string Worldpath = "world/var";
    public static string Computerpath = "C:/data";
    public static string Globalpath = Application.persistentDataPath;

    public static bool isboolean(string s)
    {
        if (s.Length > 0)
        {
            if (
              s[0] == 'F' ||
              s[0] == 'T')
            {

                return true;
            }
        }
        return false;
    }
    public static bool isNumber(string s)
    {
        if (s.Length > 0)
        {
            if (
              s[0] == '0' ||
              s[0] == '1' ||
              s[0] == '2' ||
              s[0] == '3' ||
              s[0] == '4' ||
              s[0] == '5' ||
              s[0] == '6' ||
              s[0] == '7' ||
              s[0] == '8' ||
              s[0] == '9' ||
              s[0] == '-')
            {

                return true;
            }
        }
        return false;
    }

    public static string GetPath(SaveType saveType)
    {
        string value = "";
        switch (saveType)
        {
            case SaveType.local:
                value = path;
                break;
            case SaveType.global:
                value = Globalpath;
                break;
            case SaveType.world:
                value = Worldpath;
                break;
            case SaveType.computer:
                value = Computerpath;
                break;
        }
        return value;
    }
    
    public static void InitAllPaths()
    {
        Directory.CreateDirectory(path);
        Directory.CreateDirectory(Globalpath);
        Directory.CreateDirectory(Worldpath);

        Directory.CreateDirectory(Computerpath);

    }

    public static void DeleteAll()
    {
        Directory.Delete(path, true);

    }
    public static void DeleteAll(SaveType saveType)
    {
        Directory.Delete(GetPath(saveType), true);

    }
    public static void DeleteKey(string key)
    {
        File.Delete(path + "/" + key);

    }
    public static void DeleteKey(string key, SaveType saveType)
    {
        File.Delete(GetPath(saveType) + "/" + key);

    }
    public static void SetInt(string key, int var)
    {
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/" + key, var.ToString());
    }
    public static void SetInt(string key, int var, SaveType saveType)
    {
        Directory.CreateDirectory(GetPath(saveType) + "/Events");
        File.WriteAllText(GetPath(saveType) + "/" + key, var.ToString());
    }
    public static bool CreateEvent(string key)
    {
        bool Done = false;
        Directory.CreateDirectory(path + "/Events");
        if (!File.Exists(path + "/Events/" + key)) { File.WriteAllText(path + "/Events/" + key, "Done"); Done = true; }
        return Done;
    }
    public static bool CreateEvent(string key, SaveType saveType)
    {
        bool Done = false;
        Directory.CreateDirectory(GetPath(saveType));
        if (!File.Exists(GetPath(saveType) + "/Events/" + key)) { File.WriteAllText(GetPath(saveType) + "/Events/" + key, "Done"); Done = true; }
        return Done;
    }
    public static void DestroyEvent(string key)
    {
        Directory.CreateDirectory(path + "/Events");
        if (!File.Exists(path + "/Events/" + key)) { File.Delete(path + "/Events/" + key);  }
   
    }
    public static void DestroyEvent(string key, SaveType saveType)
    {
        Directory.CreateDirectory(GetPath(saveType));
        if (!File.Exists(GetPath(saveType) + "/Events/" + key)) { File.Delete(GetPath(saveType) + "/Events/" + key); }
     
    }
    public static int GetInt(string key)
    {
        int varout = 0;
        if (File.Exists(path + "/" + key))
        {
            if (isNumber(File.ReadAllText(path + "/" + key))) varout = int.Parse(File.ReadAllText(path + "/" + key));
        }
        return varout;
    }
    public static int GetInt(string key, SaveType saveType)
    {
        int varout = 0;
        if (File.Exists(GetPath(saveType) + "/" + key))
        {
            if (isNumber(File.ReadAllText(GetPath(saveType) + "/" + key))) varout = int.Parse(File.ReadAllText(GetPath(saveType) + "/" + key));
        }
        return varout;
    }
    public static void SetBool(string key, bool var)
    {
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/" + key, var.ToString());
    }
    public static void SetBool(string key, bool var, SaveType saveType)
    {
        Directory.CreateDirectory(GetPath(saveType));
        File.WriteAllText(GetPath(saveType) + "/" + key, var.ToString());
    }
    public static bool GetBool(string key)
    {
        bool varout = false;
        if (File.Exists(path + "/" + key))
        {
            if (isboolean(File.ReadAllText(path + "/" + key))) varout = bool.Parse(File.ReadAllText(path + "/" + key));
        }
        return varout;
    }
    public static bool GetBool(string key, SaveType saveType)
    {
        bool varout = false;
        if (File.Exists(GetPath(saveType) + "/" + key))
        {
            if (isboolean(File.ReadAllText(GetPath(saveType) + "/" + key))) varout = bool.Parse(File.ReadAllText(GetPath(saveType) + "/" + key));
        }
        return varout;
    }
    public static void SetString(string key, string var)
    {
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/" + key, var.ToString());
    }
    public static void SetString(string key, string var, SaveType saveType)
    {
        Directory.CreateDirectory(GetPath(saveType));
        File.WriteAllText(GetPath(saveType) + "/" + key, var.ToString());
    }
    public static string GetString(string key)
    {
        string varout = "";
        if (File.Exists(path + "/" + key))
        {
            varout = File.ReadAllText(path + "/" + key);
        }
        return varout;
    }
    public static string GetString(string key, SaveType saveType)
    {
        string varout = "";
        if (File.Exists(GetPath(saveType) + "/" + key))
        {
            varout = File.ReadAllText(GetPath(saveType) + "/" + key);
        }
        return varout;
    }

    public static void SetFloat(string key, float var)
    {
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/" + key, var.ToString());
    }
    public static void SetFloat(string key, float var, SaveType saveType)
    {
        Directory.CreateDirectory(GetPath(saveType));
        File.WriteAllText(GetPath(saveType) + "/" + key, var.ToString());
    }
    public static float GetFloat(string key)
    {
        float varout = 0.0f;
        if (File.Exists(path + "/" + key))
        {
            if (isNumber(File.ReadAllText(path + "/" + key))) varout = float.Parse(File.ReadAllText(path + "/" + key));
        }
        return varout;
    }
    public static float GetFloat(string key, SaveType saveType)
    {
        float varout = 0.0f;
        if (File.Exists(GetPath(saveType) + "/" + key))
        {
            if (isNumber(File.ReadAllText(GetPath(saveType) + "/" + key))) varout = float.Parse(File.ReadAllText(GetPath(saveType) + "/" + key));
        }
        return varout;
    }
    public static void SetMoney(string key, decimal var)
    {
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/" + key, var.ToString());
    }
    public static void SetMoney(string key, decimal var, SaveType saveType)
    {
        Directory.CreateDirectory(GetPath(saveType));
        File.WriteAllText(GetPath(saveType) + "/" + key, var.ToString());
    }
    public static decimal LoadMoney(string key, decimal var, SaveType saveType)
    {
        decimal varout = 0.0m;
        if (File.Exists(GetPath(saveType) + "/" + key))
        {
            if (isNumber(File.ReadAllText(GetPath(saveType) + "/" + key))) varout = decimal.Parse(File.ReadAllText(GetPath(saveType) + "/" + key));
        }
        Directory.CreateDirectory(GetPath(saveType));
        File.WriteAllText(GetPath(saveType) + "/" + key, (varout + var).ToString());
        return (varout + var);
    }
    public static decimal LoadMoney(string key, decimal var)
    {
        decimal varout = 0.0m;
        if (File.Exists(path + "/" + key))
        {
            if (isNumber(File.ReadAllText(path + "/" + key))) varout = decimal.Parse(File.ReadAllText(path + "/" + key));
        }
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/" + key, (varout + var).ToString());
        return (varout + var);
    }
    public static void SetTrash(string key, double var)
    {
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/" + key, var.ToString());
    }
    public static void SetTrash(string key, double var, SaveType saveType)
    {
        Directory.CreateDirectory(GetPath(saveType));
        File.WriteAllText(GetPath(saveType) + "/" + key, var.ToString());
    }
    public static double LoadTrash(string key, double var, SaveType saveType)
    {
        double varout = 0.0d;
        if (File.Exists(GetPath(saveType) + "/" + key))
        {
            if (isNumber(File.ReadAllText(GetPath(saveType) + "/" + key))) varout = double.Parse(File.ReadAllText(GetPath(saveType) + "/" + key));
        }
        Directory.CreateDirectory(GetPath(saveType));
        File.WriteAllText(GetPath(saveType) + "/" + key, (varout + var).ToString());
        return (varout + var);
    }
    public static double LoadTrash(string key, double var)
    {
        double varout = 0.0d;
        if (File.Exists(path + "/" + key))
        {
            if (isNumber(File.ReadAllText(path + "/" + key))) varout = double.Parse(File.ReadAllText(path + "/" + key));
        }
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/" + key, (varout + var).ToString());
        return (varout + var);
    }
    public static int LoadInt(string key, int var, SaveType saveType)
    {
        int varout = 0;
        if (File.Exists(GetPath(saveType) + "/" + key))
        {
            if (isNumber(File.ReadAllText(GetPath(saveType) + "/" + key))) varout = int.Parse(File.ReadAllText(GetPath(saveType) + "/" + key));
        }
        Directory.CreateDirectory(GetPath(saveType));
        File.WriteAllText(GetPath(saveType) + "/" + key, (varout + var).ToString());
        return (varout + var);
    }
    public static int LoadInt(string key, int var)
    {
        int varout = 0;
        if (File.Exists(path + "/" + key))
        {
            if (isNumber(File.ReadAllText(path + "/" + key))) varout = int.Parse(File.ReadAllText(path + "/" + key));
        }
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/" + key, (varout + var).ToString());
        return (varout + var);
    }
    public static float LoadFloat(string key, float var, SaveType saveType)
    {
        float varout = 0;
        if (File.Exists(GetPath(saveType) + "/" + key))
        {
            if (isNumber(File.ReadAllText(GetPath(saveType) + "/" + key))) varout = float.Parse(File.ReadAllText(GetPath(saveType) + "/" + key));
        }
        Directory.CreateDirectory(GetPath(saveType));
        File.WriteAllText(GetPath(saveType) + "/" + key, (varout + var).ToString());
        return (varout + var);
    }
    public static float LoadFloat(string key, float var)
    {
        float varout = 0;
        if (File.Exists(path + "/" + key))
        {
            if (isNumber(File.ReadAllText(path + "/" + key))) varout = float.Parse(File.ReadAllText(path + "/" + key));
        }
        Directory.CreateDirectory(path);
        File.WriteAllText(path + "/" + key, (varout + var).ToString());
        return (varout + var);
    }
    public static decimal GetMoney(string key)
    {
        decimal varout = 0.0m;
        if (File.Exists(path + "/" + key))
        {
            if (isNumber(File.ReadAllText(path + "/" + key))) varout = decimal.Parse(File.ReadAllText(path + "/" + key));
        }
        return varout;
    }
    public static decimal GetMoney(string key, SaveType saveType)
    {
        decimal varout = 0.0m;
        if (File.Exists(GetPath(saveType) + "/" + key))
        {
            if (isNumber(File.ReadAllText(GetPath(saveType) + "/" + key))) varout = decimal.Parse(File.ReadAllText(GetPath(saveType) + "/" + key));
        }
        return varout;
    }
    public static double GetTrash(string key)
    {
        double varout = 0.0d;
        if (File.Exists(path + "/" + key))
        {
            if (isNumber(File.ReadAllText(path + "/" + key))) varout = double.Parse(File.ReadAllText(path + "/" + key));
        }
        return varout;
    }
    public static double GetTrash(string key, SaveType saveType)
    {
        double varout = 0.0d;
        if (File.Exists(GetPath(saveType) + "/" + key))
        {
            if (isNumber(File.ReadAllText(GetPath(saveType) + "/" + key))) varout = double.Parse(File.ReadAllText(GetPath(saveType) + "/" + key));
        }
        return varout;
    }
    public static void SetGlobalFloat(string key, float var)
    {
        Directory.CreateDirectory(Globalpath);
        File.WriteAllText(Globalpath + "/" + key, var.ToString());
    }
    public static float GetGlobalFloat(string key)
    {
        float varout = 0.0f;
        if (File.Exists(Globalpath + "/" + key))
        {
            if (isNumber(File.ReadAllText(Globalpath + "/" + key))) varout = float.Parse(File.ReadAllText(Globalpath + "/" + key));
        }
        return varout;
    }
    public static bool ExistenceVar(string key)
    {
        bool a = false;
        if (File.Exists(path + "/" + key))
        {
            a = true;
        }
        return a;
    }
    public static bool ExistenceVar(string key, SaveType saveType)
    {
        bool a = false;
        if (File.Exists(GetPath(saveType) + "/" + key))
        {
            a = true;
        }
        return a;
    }
    public static bool ExistenceGlobalVar(string key)
    {
        bool a = false;
        if (File.Exists(Globalpath + "/" + key))
        {
            a = true;
        }
        return a;
    }

}
