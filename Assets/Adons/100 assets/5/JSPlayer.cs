using System.IO;
using UnityEngine;

public class JSPlayer : MonoBehaviour
{
    void Start()
    {
        DirectoryInfo dir = new DirectoryInfo("res/scripts/player.javascript");
        foreach (FileInfo var in dir.GetFiles())
        {
            if (var.Name.Contains(".js"))
                gameObject.AddComponent<JSBehaviour>().js_File = "player.javascript/" + var.Name.Replace(".js", "");
        }
        DirectoryInfo dir2 = new DirectoryInfo("res/scripts/player.assembler");
        foreach (FileInfo var in dir2.GetFiles())
        {
           if(var.Name.Contains(".asm")) gameObject.AddComponent<ASMBehaviour>().deStart(var.Name.Replace(".asm", ""), @"res\scripts\player.assembler\");
        }
        DirectoryInfo dir3 = new DirectoryInfo("res/scripts/player.pyton");
        foreach (FileInfo var in dir3.GetFiles())
        {
            if (var.Name.Contains(".py"))
                gameObject.AddComponent<PyBehaviour>().deStart(var.Name.Replace(".py", ""), @"res\scripts\player.pyton\");
        }
        DirectoryInfo dir4 = new DirectoryInfo("res/scripts/player.unauticnascript");
        foreach (FileInfo var in dir4.GetFiles())
        {
            if (var.Name.Contains(".uns"))
                gameObject.AddComponent<unScript>().deStart(@"player.unauticnascript\" + var.Name);
        }
        DirectoryInfo dir5 = new DirectoryInfo(@"res\scripts\player.lua");
        foreach (FileInfo var in dir5.GetFiles())
        {
            if (var.Name.Contains(".lua"))
                gameObject.AddComponent<LuaTest>().lua_File = (@"res\scripts\player.lua\" + var.Name);
        }
        DirectoryInfo dir6 = new DirectoryInfo(@"res\scripts\player.autohotkey");
        foreach (FileInfo var in dir6.GetFiles())
        {
            if (var.Name.Contains(".ahk"))
                gameObject.AddComponent<AhkBehaviour>().deStart(var.Name.Replace(".ahk", ""), @"\res\scripts\player.autohotkey\");
        }
        DirectoryInfo dir7 = new DirectoryInfo(@"res\scripts\player.cminusminus");
        foreach (FileInfo var in dir7.GetFiles())
        {
            if (var.Name.Contains(".c--"))
                gameObject.AddComponent<CmmBehaviour>().deStart(var.Name.Replace(".c--", ""), @"\res\scripts\player.cminusminus\");
        }
        DirectoryInfo dir8 = new DirectoryInfo(@"res\scripts\player.rosscomnadzor");
        foreach (FileInfo var in dir8.GetFiles())
        {
            if (var.Name.Contains(".ркн"))
                gameObject.AddComponent<RKNBehaviour>().deStart(var.Name.Replace(".ркн", ""), @"\res\scripts\player.rosscomnadzor\");
        }
    }
}
