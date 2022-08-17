using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LOADGAME : MonoBehaviour
{
    public gsave gsave = new gsave();
    public InputField ifd;
    // Start is called before the first frame update
    void Start()
    {
        Directory.CreateDirectory("unsave");
        
        if (File.Exists("unsave/s"))
        {
            ifd.text = File.ReadAllText("unsave/s");
        }
    }
    public void LOAD()
    {

        if (!File.Exists("unsave/capterg/" + ifd.text))
        {
            string s = "";
            s = ifd.text;
            File.WriteAllText("unsave/s", s);
            SceneManager.LoadScene(1);

        }
        if (File.Exists("unsave/capterg/" + ifd.text))
        {
            gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + ifd.text));
            string s = "";
            s = ifd.text;
            File.WriteAllText("unsave/s", s);
            SceneManager.LoadScene(gsave.sceneid);
        }
       
    }
    public void RESSET()
    {
        VarSave.DeleteAll();
        if (Directory.Exists("unsave"))
        {
            Directory.Delete("unsave", true);
        }
    }
}
