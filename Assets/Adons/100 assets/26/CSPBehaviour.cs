using UnityEngine;
using Jint;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Reflection;

public class CSPBehaviour : MonoBehaviour
{
    
}
public class CSP
{
	public static void Climp(object type,CSPBehaviour script)
	{
		script.gameObject.AddComponent((Type)GetSharpComponent(((string)type)+"CSP"));
	}
	public static object GetSharpComponent(object type)
    {
        foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            if (asm.GetName().Name.Contains("Unity"))
            {
                foreach (Type t in asm.GetExportedTypes())
                {
                    if (t.FullName.Contains((string)type)) return t;
                }
            }
        }
		
		return null;
    }
}