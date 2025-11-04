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
    public GameData gsave = new GameData();
    public InputField ifd;
    public ParticleSystem[] ps;
    public Material mat;
    public Animator Animator_camera;
    public InputField data;
    public Toggle postrender;
    public Toggle isnotwindowed;
    public Toggle full4D;
    public Color prc;
    public TMP_Dropdown dd;
    public Button[] buttons;
    public TMP_Dropdown ddpr;
    public FileSelectorExample fse;
    // Start is called before the first frame update
    void Start()
    {
        if (VarSave.GetBool("lol you Banned"))
        {
            SceneManager.LoadScene("Banned forever");
        }
        if (VarSave.GetString("Ñâàäüáà") == "íà÷èíàåì")
        {
            SceneManager.LoadScene("SeXHome");
        }
        if (VarSave.ExistenceVar("Ban non-Begin"))
        {
            SceneManager.LoadScene("Nervana");
        }
        QualitySettings.SetQualityLevel(0);
        GameObject g = new GameObject("init");
        gameInit.Init(g);
        DontDestroyOnLoad(g);
        Cursor.lockState = CursorLockMode.None;
        if (!VarSave.ExistenceVar("res1", SaveType.global))
        {

            VarSave.SetInt("res1", Screen.width / 4, SaveType.global);
            VarSave.SetInt("res2", Screen.height / 4, SaveType.global);
            VarSave.SetInt("res3", Screen.width, SaveType.global);
            VarSave.SetInt("res4", Screen.height, SaveType.global);
            Screen.SetResolution(640, 480, true);
        }
        if (VarSave.ExistenceVar("res3", SaveType.global))
        {


            Screen.SetResolution(VarSave.GetInt("res3", SaveType.global), VarSave.GetInt("res4", SaveType.global), !VarSave.GetBool("windowed", SaveType.global));
        }
        isnotwindowed.isOn = !VarSave.GetBool("windowed");
        postrender.isOn = VarSave.GetBool("postrender");
        Directory.CreateDirectory("unsave"); 
        Directory.CreateDirectory("unsavet");
        full4D.isOn = VarSave.GetBool("full4D");
        if (!VarSave.ExistenceVar("color"))
        {
            VarSave.SetString("color", "gray");
            mat.SetColor("_Color", Color.gray);
        }
        if (VarSave.GetString("color") == "white")
        {
            mat.SetColor("_Color", Color.white);
        }
        if (VarSave.GetString("color") == "gray")
        {
            mat.SetColor("_Color", Color.gray);
        }
        if (VarSave.GetString("color") == "black")
        {
            mat.SetColor("_Color", Color.black);
        }
        if (File.Exists("unsave/s"))
        {
            ifd.text = File.ReadAllText("unsave/s");
        }
        if (VarSave.ExistenceVar("processSettings"))
        {
            data.text = VarSave.GetInt("processSettings").ToString();
        }
        if (!VarSave.ExistenceVar("processSettings"))
        {
            data.text = stadart.data.ToString();
        }
        if (VarSave.CreateEvent("spawnMana"))
        {
            VarSave.LoadFloat("mana", 10000f);
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
    public void Tutorial4()
    {

        SceneManager.LoadScene("tutorial3");
    }
    public void Tutorial5()
    {

        SceneManager.LoadScene("tutorial4");
    }
    public void GeometryStraight()
    {

        SceneManager.LoadScene("StraightGeometry");
    }
    public void GeometryCircle()
    {

        SceneManager.LoadScene("CircleGeometry");
    }
    public void GeometryHyperblic()
    {

        SceneManager.LoadScene("HyperbolicGeometry");
    }
    public void GeometryLoop()
    {

        SceneManager.LoadScene("LoopGeometry");
    }
    public void GeometryLiminal()
    {

        SceneManager.LoadScene("LiminalGeometry");
    }
    public void mainmenu_mini_Games()
    {

        Animator_camera.Play("c1menu_mgame");
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
    public void GetEditorCeratures()
    {

        SceneManager.LoadScene("EditorCeratures");
    }
    public void CustomRsolutionSetup()
    {

        SceneManager.LoadScene(129);
    }
    //SceneManager.LoadScene(0);
    public void GetGameLab()
    {

        SceneManager.LoadScene("Lab");
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
        else if (ifd.text == "100024")
        {
            SceneManager.LoadScene(60);
        }
        else if (ifd.text == "-1")
        {
            SceneManager.LoadScene(85);
        }
        else if (!VarSave.ExistenceVar("scppos"))
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
                gsave = JsonUtility.FromJson<GameData>(File.ReadAllText("unsave/capterg/" + ifd.text));
                string s = "";
                s = ifd.text;
                File.WriteAllText("unsave/s", s);
                SceneManager.LoadScene(gsave.sceneid);
            }
        }
        else if (VarSave.ExistenceVar("scppos"))
        {


           
            SceneManager.LoadScene(VarSave.GetString("scppos"));

          
        }
    }
    public void engLENGUAGE()
    {
        VarSave.SetBool("lenguage_english", true);

    }
    public void SkinLobby()
    {
        SceneManager.LoadScene("CharactorLobby");

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
        mat.SetColor("_Color", Color.white);
        VarSave.SetString("color", "white");
    }
    public void SETmat2()
    {
        mat.SetColor("_Color", Color.gray);
        VarSave.SetString("color", "gray");
    }
    public void SETmat3()
    {
        mat.SetColor("_Color", Color.black);
        VarSave.SetString("color", "black");
    }
    public void setgraficsetings()
    {
        VarSave.SetBool("postrender", postrender.isOn, SaveType.global);
        VarSave.SetBool("windowed",!isnotwindowed.isOn, SaveType.global);
     
        
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
        VarSave.SetBool("full4D", full4D.isOn);
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
