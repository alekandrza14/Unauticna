using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public enum scriptFormat
{
    s,uns,lua
}

public class PathUns : MonoBehaviour
{
    [SerializeField] InputField Path,Output;
    [SerializeField] scriptFormat scriptFormat;
    public void GetString()
    {
        if (File.Exists(Path.text))
        {
            Output.text = File.ReadAllText(Path.text);
        }
    }
    public void saveString()
    {
        if (scriptFormat == scriptFormat.s) 
                File.WriteAllText(Path.text + ".s", Output.text);
           
        if (scriptFormat == scriptFormat.uns) 
                File.WriteAllText(Path.text + ".uns", Output.text);
          
    }
}
