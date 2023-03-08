using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class stadart
{
    static public int data = 1000;
}

public class LOADGAME : MonoBehaviour
{
    public gsave gsave = new gsave();
    public InputField ifd;
    public ParticleSystem[] ps;
    public Material mat;
    public Animator Animator_camera;
    public InputField data;
    public Toggle postrender;
    public Toggle isnotwindowed;
    public Color prc;
    public TMP_Dropdown dd;
    public Button[] buttons;
    public TMP_Dropdown ddpr;
    public FileSelectorExample fse;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.SetQualityLevel(0);
        GameObject g = new GameObject("init");
        gameInit.Init(g);
        DontDestroyOnLoad(g);
        Cursor.lockState = CursorLockMode.None;
        if (!VarSave.EnterFloat("res3"))
        {


            Screen.SetResolution(640, 480, true);
        }
        if (VarSave.EnterFloat("res3"))
        {


            Screen.SetResolution(VarSave.GetInt("res3"), VarSave.GetInt("res4"), !VarSave.GetBool("windowed"));
        }
        isnotwindowed.isOn = !VarSave.GetBool("windowed");
        postrender.isOn = VarSave.GetBool("postrender");
        Directory.CreateDirectory("unsave"); 
        Directory.CreateDirectory("unsavet");

        if (!VarSave.EnterFloat("color"))
        {
            VarSave.SetString("color", "gray");
            mat.color = Color.gray;
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
        if (VarSave.EnterFloat("processSettings"))
        {
            data.text = VarSave.GetInt("processSettings").ToString();
        }
        if (!VarSave.EnterFloat("processSettings"))
        {
            data.text = stadart.data.ToString();
        }
    }
    public void Tutorials()
    {
        Animator_camera.SetTrigger(">");
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
        Animator_camera.SetTrigger("<");
    }
    public void mainmenu_settings()
    {
        Animator_camera.Play("c1set_menu");
    }
    public void settings()
    {
        Animator_camera.Play("c1menu_set");
    }
    public void Update()
    {
        
            
        for (int i = 0;i<ps.Length; i++)
        {
            ps[i].gameObject.SetActive(!VarSave.GetBool("partic"));
        }
        voidupdate();
        
    }
    public void LOAD()
    {
        if (ifd.text == "022564")
        {
            SceneManager.LoadScene(43);
        }
        if (ifd.text == "100024")
        {
            SceneManager.LoadScene(60);
        }
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
        if (ifd.text == "022564")
        {
            SceneManager.LoadScene(43);
        }
        if (ifd.text == "100024")
        {
            SceneManager.LoadScene(60);
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
        Application.Quit();
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
    public void setgraficsetings()
    {
        VarSave.SetBool("postrender", postrender.isOn);
        VarSave.SetBool("windowed",!isnotwindowed.isOn);
        if (dd.value == 0)
        {
            Screen.SetResolution(640, 480, isnotwindowed.isOn);
            VarSave.SetInt("res3", 640);
            VarSave.SetInt("res4", 480);
        }
        if (dd.value == 1)
        {
            Screen.SetResolution(1024, 768, isnotwindowed.isOn);
            VarSave.SetInt("res3", 1024);
            VarSave.SetInt("res4", 768);
        }
        if (dd.value == 2)
        {
            Screen.SetResolution(1600, 1200, isnotwindowed.isOn);
            VarSave.SetInt("res3", 1600);
            VarSave.SetInt("res4", 1200);
        }
        if (dd.value == 3)
        {
            Screen.SetResolution(2560, 1600, isnotwindowed.isOn);
            VarSave.SetInt("res3", 2560);
            VarSave.SetInt("res4", 1600);
        }
        if (postrender.isOn)
        {
            

            if (ddpr.value == 0)
            {
                VarSave.SetInt("res1", 320);
                VarSave.SetInt("res2", 240);
            }
            if (ddpr.value == 1)
            {
                VarSave.SetInt("res1", 640);
                VarSave.SetInt("res2", 480);
            }
            if (ddpr.value == 2)
            {
                VarSave.SetInt("res1", 1024);
                VarSave.SetInt("res2", 768);
            }
            if (ddpr.value == 3)
            {
                VarSave.SetInt("res1", 1600);
                VarSave.SetInt("res2", 1200);
            }
            if (ddpr.value == 4)
            {
                VarSave.SetInt("res1", 2560);
                VarSave.SetInt("res2", 1600);
            }
        }
    }
    public void setprocessSetings()
    {
       VarSave.SetInt("processSettings",int.Parse( data.text));
    }
    public void setcolorpr()
    {

        fse.usewindowOpen = true;
    }
    public void voidupdate()
    {
        
        if (fse.usewindowOpen)
        {
            for (int i = 0;i < buttons.Length;i++)
            {
                buttons[i].interactable = false;
            }
            postrender.interactable = false;
            ddpr.interactable = false; 
            dd.interactable = false;
            isnotwindowed.interactable = false;
        }
        else
        {
            if (File.Exists(fse.path))
            {


                VarSave.SetString("postrender_color", File.ReadAllText(fse.path));
            }
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = true;
            }
            postrender.interactable = true;
            ddpr.interactable = true;
            dd.interactable = true;

            isnotwindowed.interactable = true;
        }
    }
}
