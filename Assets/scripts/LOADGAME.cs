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
    public ParticleSystem[] ps;
    public Material mat;
    public Animator camera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Screen.SetResolution(1924, 867, true);
        Directory.CreateDirectory("unsave"); 
        Directory.CreateDirectory("unsavet");
        Directory.CreateDirectory("munsave");

        if (!VarSave.EnterFloat("color"))
        {
            VarSave.SetString("color", "white");
        }
        if (VarSave.GetString("color") == "white")
        {
            mat.color = Color.white;
        }
        if (VarSave.GetString("color") == "gray")
        {
            mat.color = Color.gray;
        }
        if (VarSave.GetString("color") == "black")
        {
            mat.color = Color.black;
        }
        if (File.Exists("unsave/s"))
        {
            ifd.text = File.ReadAllText("unsave/s");
        }
    }
    public void Tutorials()
    {
        camera.SetTrigger(">");
    }
    public void Tutorial1()
    {

        SceneManager.LoadScene("tutorial0");
    }
    public void Tutorial2()
    {

        SceneManager.LoadScene("tutorial1");
    }
    public void Tutorial3()
    {

        SceneManager.LoadScene("tutorial2");
    }
    public void mainmenu()
    {
        camera.SetTrigger("<");
    }
    public void mainmenu_settings()
    {
        camera.Play("c1set_menu");
    }
    public void settings()
    {
        camera.Play("c1menu_set");
    }
    public void Update()
    {
        
            
        for (int i = 0;i<ps.Length; i++)
        {
            ps[i].gameObject.SetActive(!VarSave.GetBool("partic"));
        }
        
    }
    public void LOAD()
    {
        if (ifd.text == "022564")
        {
            SceneManager.LoadScene(43);
        }
        if (!File.Exists("unsave/capterg/" + ifd.text) && ifd.text != "022564")
        {
            string s = "";
            s = ifd.text;
            File.WriteAllText("unsave/s", s);
            SceneManager.LoadScene(1);

        }
        if (File.Exists("unsave/capterg/" + ifd.text) && ifd.text != "022564")
        {
            gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + ifd.text));
            string s = "";
            s = ifd.text;
            File.WriteAllText("unsave/s", s);
            SceneManager.LoadScene(gsave.sceneid);
        }
       
    }
    public void engLENGUAGE()
    {
        VarSave.SetBool("lenguage_english", true);
        
    }
    public void rusLENGUAGE()
    {
        VarSave.SetBool("lenguage_english", false);

    }
    public void unéLENGUAGE()
    {
        VarSave.SetString("lenguage_english", "none");

    }
    public void onoffparticles()
    {
        VarSave.SetBool("partic", !VarSave.GetBool("partic"));
    }
    public void RESSET()
    {
        VarSave.DeleteAll();
        if (Directory.Exists("unsave"))
        {
            Directory.Delete("unsave", true);
        }
    }
    public void SETmat1()
    {
        mat.color = Color.white;
        VarSave.SetString("color", "white");
    }
    public void SETmat2()
    {
        mat.color = Color.gray;
        VarSave.SetString("color", "gray");
    }
    public void SETmat3()
    {
        mat.color = Color.black;
        VarSave.SetString("color", "black");
    }
}
