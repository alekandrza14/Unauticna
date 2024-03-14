using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public enum scriptFormat
{
    s,uns,lua,txt
}

public class PathUns : MonoBehaviour
{
    [SerializeField] InputField Path,Output;
    [SerializeField] scriptFormat ScriptFormat;
    private void Start()
    {
        switch (ScriptFormat)
        {
            case scriptFormat.s:
                Path.text += ".s";
                break;
            case scriptFormat.uns:
                Path.text += ".uns";
                break;
            case scriptFormat.lua:
                Path.text += ".lua";
                break;
            case scriptFormat.txt:
                Path.text += ".txt";
                break;
        }
    }
    public void GetString()
    {
        if (File.Exists(Path.text))
        {
            Output.text = File.ReadAllText(Path.text);
        }
    }
    public void saveString()
    {
       
            File.WriteAllText(Path.text, Output.text);

    }
}
