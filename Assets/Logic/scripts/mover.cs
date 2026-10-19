using Unauticna.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using System;
using System.Runtime.InteropServices;
using Photon.Pun;
using MoonSharp.Interpreter;
using System.Diagnostics;


public class PlayerData
{
    public string idsave;
    public Vector3 pos, pos2, rotW;
    public Vector4 pos3;
    public string hpos_Polar3;
    public float wpos;
    public List<float> npos = new();
    public int cnpos = 0;
    public float hpos;
    public float hxrot;
    public Quaternion q1, q2, q3, q4;
    public Vector3 velosyty; public Vector3 angularvelosyty;
    public float vive;
}
public class TimePlayerData
{

    public string idsave;
    public string timesave;
    public Vector3 pos, pos2, rotW;
    public Vector4 pos3;
    public string hpos_Polar3;
    public float wpos;
    public List<float> npos = new();
    public int cnpos = 0;
    public float hpos;
    public float hxrot;
    public Quaternion q1, q2, q3, q4;
    public Vector3 velosyty; public Vector3 angularvelosyty;
    public float vive;
}
public class GameData
{
    public int progressofthepassage = 0;
    public int hp;
    public float oxygen;
    public float PlayerScale = 1;
    public faceView fv;
    public int Spos;
    public int DayOfEra;
    public string idsave;
    public int sceneid;
    public List<string> inventory = new();
    public List<string> inventoryname = new();
}

public enum faceView
{
    first ,trid,fourd,sims
}

public class mover : CustomSaveObject
{
    // Media Studio: created lazily by F9/F10; existing movement stays in mover.
    private bool mediaStudioOwnsPause, mediaStudioPreviousPause;
    private bool MediaStudioTick()
    {
        if (PhotonNetwork.IsConnected && (photonView == null || !photonView.IsMine)) return false;
        bool editing = Unauticna.MediaStudio.MediaStudioHost.PlayerUpdate(PlayerCamera);
        if (editing)
        {
            if (!mediaStudioOwnsPause)
            {
                mediaStudioPreviousPause = Globalprefs.Pause;
                mediaStudioOwnsPause = true;
            }
            Globalprefs.Pause = true;
            return true;
        }
        MediaStudioReleasePause();
        return false;
    }
    private void MediaStudioReleasePause()
    {
        if (!mediaStudioOwnsPause) return;
        Globalprefs.Pause = mediaStudioPreviousPause;
        mediaStudioOwnsPause = false;
    }
    public void OpenMediaStudio() => Unauticna.MediaStudio.MediaStudioHost.OpenEditor(PlayerCamera);
    public void ToggleVideoRecording() => Unauticna.MediaStudio.MediaStudioHost.TogglePlayerRecording(PlayerCamera);


    sealed class MechanicTimer
    {
        public string name; public float delay, repeat; public bool running;
    }
    readonly List<MechanicTimer> mechanicTimers = new List<MechanicTimer>();
    float nextStrategyScan, nextTalentScan, nextPostrenderScan, nextInputSettings;
    bool cachedXboxMode, creativeAvailable, mechanicStarted, mechanicRaymarchWasOn;
    JSPlayer mechanicJs;
    bool CachedXboxMode
    {
        get { if (Time.unscaledTime >= nextInputSettings) { nextInputSettings = Time.unscaledTime + 0.5f; cachedXboxMode = VarSave.GetBool("Xbox"); } return cachedXboxMode; }
    }
    void ScheduleMechanic(string name, float delay, float repeat)
    {
        mechanicTimers.Add(new MechanicTimer { name = name, delay = delay, repeat = repeat });
        RefreshMechanicTimers();
    }
    void RefreshMechanicTimers()
    {
        foreach (var timer in mechanicTimers)
        {
            bool wanted = nameIsCore(timer.name) || PlayerMechanics.Active(MechanicId.WorldEvents);
            if (wanted == timer.running) continue;
            timer.running = wanted;
            if (wanted) InvokeRepeating(timer.name, timer.delay, timer.repeat); else CancelInvoke(timer.name);
        }
    }
    static bool nameIsCore(string name) { return name == "ResetSpace" || name == "reasonUpdate"; }
    void MechanicSettingsChanged()
    {
        RefreshMechanicTimers();
        creativeAvailable = PlayerMechanics.Active(MechanicId.Creative) && Directory.Exists("debug");
        if (!PlayerMechanics.Active(MechanicId.Dimensions)) { new_offset = Vector3.zero; Globalprefs.customcenter = Vector3.zero; }
        bool raymarchOn = PlayerMechanics.Active(MechanicId.Raymarch);
        if (!raymarchOn && mechanicRaymarchWasOn) { Globalprefs.RaymarchOn = false; if (postrender.main() != null) postrender.main().Disable(); }
        mechanicRaymarchWasOn = raymarchOn;
        if (sali != null) sali.enabled = PlayerMechanics.Active(MechanicId.Building);
        if (!mechanicStarted) return;
        if (PlayerMechanics.Active(MechanicId.CustomScripts) && mechanicJs == null)
        { mechanicJs = GetComponent<JSPlayer>(); if (mechanicJs == null) mechanicJs = gameObject.AddComponent<JSPlayer>(); }
        if (mechanicJs != null) mechanicJs.enabled = PlayerMechanics.Active(MechanicId.CustomScripts);
    }


    public GameObject PlayerBody;
    public GameObject PlayerCamera;
    [SerializeField] bool isplanet;
    [SerializeField] public bool tutorial;
    [SerializeField] public bool tutorialsave;
    [SerializeField] bool islight = false;
    [SerializeField] bool inglobalspace;
    [SerializeField] float jumpforse;
    [SerializeField] float jumpPower;
    [SerializeField] public float gravity;
    [SerializeField] float ForseSwaem;
    [SerializeField] Rigidbody rigidbody3d;
    [SerializeField] float Speed;
    public static bool DeadGod{ private set; get;}
    [SerializeField] public Animator animator;
    [SerializeField] Animator[] SkinedAnimators;
    PlayerData save = new();
    TimePlayerData tsave = new();
    public GameData gsave = new();
    [SerializeField] GUISkin editor;
    [SerializeField] public float W_position;
    [SerializeField] public float H_position;
    [SerializeField] public List<float> N_position = new()
    {
        0
    };
    [SerializeField] public int cur_N_position;
    public int planet_position;
    public InputField SaveFileInputField;
    float JumpTimer;
    [HideInInspector] public bool IsGraund;
    public bool InWater;
    bool LateInWater;
    Collision c;
    float ZoomConficent = 0.04f;
    [SerializeField] RawImage watermask;
    float fog = 1000; float fog2 = 1000;
    Color fogonwater;
    [HideInInspector] public int hp = 200; float oxygen = 20;
    float tic, time = 4; float tic2, time2 = 4;
    bool s2 = true;
    public GameObject HeadCameraSetup;
    float vel;
    float tics;
    [HideInInspector] public int nonnatureprogress;
    [HideInInspector] public bool fly; bool Xray;
    [SerializeField] GameObject[] PlayersModelObjObjects;
    [HideInInspector] public HyperbolicCamera hyperbolicCamera;
    bool stand_stay;
    [SerializeField] GameObject PlayerModelObject;
    [SerializeField] GameObject[] PlayerModelObjects;
    [SerializeField] int[] PlayerModelTags;
    public PlayerDNA DNA = new();
    public Material DebugMat;
    Seson seson;
    [HideInInspector] public faceView faceViewi;
    bool Sprint;
    float fireInk;
    string lepts = "";

    ItemDemake Demake = new ItemDemake();
    [HideInInspector] public string lif;
    [HideInInspector] public float HX_Rotation;

    private PlayerRayMarchCollider rayMarchCollider;
	private Camera mainCamera;

    void swapHX3(Transform x, mover w)
    {
        float save = x.localPosition.x;
        if (HX_Rotation == 0) x.localPosition = new Vector3(w.H_position, x.localPosition.y, x.localPosition.z);
        if (HX_Rotation == -90) x.localPosition = new Vector3(-w.H_position, x.localPosition.y, x.localPosition.z);
        if (HX_Rotation == 0) w.H_position = -save;
        if (HX_Rotation == -90) w.H_position = save;
    }
    void swapWX3(Transform x, mover w)
    {
        RaymarchCam m = Get4DCam();
        float save = x.localPosition.x;
        if (m._wRotation.x == 0) x.localPosition = new Vector3(w.W_position, x.localPosition.y, x.localPosition.z);
        if (m._wRotation.x == -90) x.localPosition = new Vector3(-w.W_position, x.localPosition.y, x.localPosition.z);
        if (m._wRotation.x == 0) w.W_position = -save;
        if (m._wRotation.x == -90) w.W_position = save;
    }

    public static void swapWXALL()
    {
        RaymarchCam m = Get4DCam();
        mover w = mover.main();

        w.swapWX3(w.transform, w);
        if (m._wRotation.x == 0) m._wRotation.x = -90; else m._wRotation.x = 0;


    }
    public static void swapHXALL()
    {
        mover w = mover.main();

        w.swapHX3(w.transform, w);

        if (w.HX_Rotation == 0) w.HX_Rotation = -90; else w.HX_Rotation = 0;


    }
    public static RaymarchCam maincam4;
    public static RaymarchCam Get4DCam()
    {
        var player = mover.main();
        if (player == null || player.PlayerCamera == null) return null;
        if (maincam4 == null) maincam4 = player.PlayerCamera.GetComponent<RaymarchCam>();
        return maincam4;
    }
    DateTime timeUnauticna()
    {
        DateTime _new = new((int)6599, (int)7, (int)22, (int)3, (int)46, (int)23);
        return _new;
    }
    float fmod2(float a, float b)
    {
        float c = Unity.Mathematics.math.frac(Unity.Mathematics.math.abs(a / b)) * Unity.Mathematics.math.abs(b);
        if (a < 0)
        {
            c = -c + b;
        }
        return c;
    }
    string CurrentTime()
    {
        string _new; 
        DateTime id = (DateTime.Now);
        int StartDate = gsave.DayOfEra;
        int year = 306599+ ((2 + ((DatePlus.dayOfEra()- StartDate) / 3) / 40) / 20);
        int Month = (2 + ((DatePlus.dayOfEra() - StartDate) / 3) / 40)%20;
        int Day = (36 + ((DatePlus.dayOfEra() - StartDate) / 3)%40);
        int Hours = (DatePlus.dayOfEra() - StartDate) % 3;
        int Hour = id.Hour;
        int Minute = id.Minute;
        _new = year + " г. " + Month + " м. " + Day + " д. " + Hour + " \\ " + Hours + " ч. " + Minute + " м. ";
        return _new;
    }
    string oldCurrentTime()
    {
        string _new = "";
        DateTime id = (DateTime.Now);
       // DateTime id2 = (gsave.starttimepos);
        DateTime v = timeUnauticna();
       // int year = (v.Year + (id.Year - id2.Year));
       // int Month = (int)fmod2((float)(v.Month + (id.Month - id2.Month)), 12f);
       // int Day = (int)fmod2((float)(v.Day + (id.Day - id2.Day)), 30f);
       // int Hour = (int)fmod2((float)(v.Hour + (id.Hour - id2.Hour)), 60f);
       // int Minute = (int)fmod2((float)(v.Minute + (id.Minute - id2.Minute)), 60f);
       // _new = "30" + year + " г. " + Month + " м. " + Day + " д. " + Hour + " ч. " + Minute + " м. ";
        return _new;
    }
    void Building()
    {
        if (!PlayerMechanics.Active(MechanicId.Building)) return;


        string vaule1;
        string vaule2;
        lif = Globalprefs.GetIdPlanet().ToString();
        lif += "_" + Globalprefs.GetTimeline();
        if (GlobalInputMenager.KeyCode_build != "")
        {
            vaule1 = GlobalInputMenager.KeyCode_build;
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null && Input.GetKeyDown(KeyCode.Tab))
            {
                if (VarSave.GetFloat(
        "Freedomfil" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
                if (VarSave.GetFloat(
            "Creative" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
                genmodel g = Instantiate(Resources.Load<GameObject>("Custom model"), hit.point, Quaternion.identity).GetComponent<genmodel>();
                g.s = vaule1;
                g.gameObject.transform.position = hit.point;


            }



        }

        if (Input.GetKeyDown(KeyCode.F1))
        {


        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (VarSave.GetFloat(
           "Freedomfil" + "_gameSettings", SaveType.global) >= .1f)
            {
                VarSave.LoadFloat("reason", 1);
            }

        }
        bool j = Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace);
        RaycastHit hit2 = MainRay.MainHit;

        if (hit2.collider != null && j)
        {
            if (hit2.collider.GetComponent<genmodel>())
            {
                if (VarSave.GetFloat(
    "Freedomfil" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
                if (VarSave.GetFloat(
            "Creative" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
                hit2.collider.gameObject.AddComponent<DELETE>();

            }
        }




        if (GlobalInputMenager.KeyCode_Spawn != "")
        {
            vaule2 = GlobalInputMenager.KeyCode_Spawn;
            RaycastHit hit = MainRay.MainHit;


            if (hit.collider != null && Input.GetKeyDown(KeyCode.Tab))
            {
                if (VarSave.GetFloat(
            "Creative" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
                if (VarSave.GetFloat(
           "Freedomfil" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
                telo g = Instantiate(Resources.Load<GameObject>("Custom Creature"), hit.point, Quaternion.identity).GetComponent<telo>();
                g.nameCreature = vaule2;
                g.gameObject.transform.position = hit.point;

                GlobalInputMenager.KeyCode_Spawn = "";
                GlobalInputMenager.build.text = "";
            }


        }
    }
    public faceView GetViewFace()
    {
        return faceViewi;
    }
    public void SetViewFace(faceView a)
    {
        faceViewi = a;
    }

    public void LoadHyperbolicVector(Vector4 v4, HyperbolicCamera c1)
    {
        c1.RealtimeTransform.n = v4.x;
        c1.RealtimeTransform.s = v4.y;
        c1.RealtimeTransform.m = v4.z;
        c1.transform.position = new Vector3(0, v4.w, 0);

    }
    //физика
    void OnCollisionStay(Collision collision)
    {

        if (!collision.collider.CompareTag("sc") && !inputGpress) if (JumpTimer < -2)
            {
                UnityEngine.Debug.Log(JumpTimer);
                hp += Mathf.FloorToInt(JumpTimer) / 3;
            }
        if (!collision.collider.CompareTag("sc") && Input.GetKey(KeyCode.Space)) JumpTimer = jumpPower;


        if (!collision.collider.CompareTag("sc") && !Input.GetKey(KeyCode.Space)) JumpTimer = 0;
        if (InWater)
        {
            IsGraund = false;
            JumpTimer = 0;
        }
        c = collision;
        if (collision.collider.CompareTag("sc"))
        {

            //IsGraund = false;

        }

        if (collision.collider.CompareTag("sc2"))
        {


            JumpTimer = -jumpPower / 2;
            s2 = false;
            if (GravityConstant() > -0) IsGraund = true;




        }
    }
    public List<Collider> s45 = new();
    public List<int> s45i = new();
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Rigidbody>())
        {
            if (!s45.Contains(collision.collider))
            {
                s45.Add(collision.collider);
                s45i.Add(0);
            }
            else
            {

                s45i[ s45.IndexOf(collision.collider)]+=1;
                if (s45i[s45.IndexOf(collision.collider)]>6)
                {
                    VarSave.SetMoney("Либидо♀AAA", 5);
                }
            }
        }
        if (collision.collider.GetComponent<Logic_tag_DamageObject>())
        {
            hp -= 2;
        }
        if (collision.collider.GetComponent<fire>())
        {
            if (fireInk + 10 < 100)
            {
                fireInk += 10;

            }
            else
            {
                fireInk = 100;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("dead"))
        {
            VarSave.SetBool("обычный сельский бог гипер смерти урбил вас", true);
            VarSave.SetBool("cry", true);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        if (other.CompareTag("airhole"))
        {
            IsGraund = true;

        }
        if (other.GetComponent<notswiming>())
        {
            InWater = true;

        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("lagi"))
        {
            playerCameraComponent.enabled = 1 == Global.Random.Range(0, 3);

        }
        if (other.GetComponent<notswiming>())
        {
            if (VarSave.LoadMoney("Либидо♀AAA", 0.0m) < 1) VarSave.LoadMoney("Либидо♀", 0.5m); 
            else
            {
                if (VarSave.LoadMoney("Либидо♀", 0.0m) < 100) VarSave.LoadMoney("Либидо♀", 0.5m);
            }
            
        }
        if (other.GetComponent<FreedomOxygen>()) oxygen = 20;
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<notswiming>())
        {
            InWater = false;

        }
        if (other.CompareTag("lagi"))
        {
            playerCameraComponent.enabled = true;

        }

    }
    void OnCollisionExit(Collision collision)
    {

        c = null;
    }
    //физика

    public IEnumerator coroutine()
    {
        yield return new WaitForSeconds(1);
        portallNumer.Portal = "";
        yield return new WaitForSeconds(1);
        UnityEngine.Debug.Log("log");
    }
    System.Random rand = new();
    void reasonUpdate()
    {
        var reason =
        VarSave.GetFloat("reason");
        if (rand.Next(0, 10) < 1) reason -= 1;
        int min = 0;
        int max = 100;
        max += (int)(data_BGPU * 10);
        for (int i = 0; i < 2; i++) { if (i == 0) if (Globalprefs.alterversion >= 0.1f)
                {
                    UnityEngine.Debug.Log("Fork?");
                    min = 10;

                }
            if (i == 1) if (reason < 0 + min)
                {
                    reason = 0 + min;
                }
        }
        if (reason > 0 + max)
        {
            reason = 0 + max;
        }
        if (VarSave.CreateEvent("reason"))
        {
            reason = 100;

        }

        if (reason < 10)
        {
            Application.targetFrameRate = 7;
        }
        else if (reason > 10 && reason < 100)
        {
            Application.targetFrameRate = 30;
        }
        else if (reason > 100)
        {
            Application.targetFrameRate = 60;
        }
        VarSave.SetFloat("reason", reason);
    }

    public GameObject _player;
    //Пробуждение кода
    private void Awake()
    {
        PlayerMechanics.Changed += MechanicSettingsChanged;
        photonView = GetComponent<PhotonView>();

       
        if (PhotonNetwork.IsConnected) 
        {
            if (!photonView)
            {

                PhotonNetwork.Instantiate(_player.name, transform.position, Quaternion.identity);
                Invoke("selfDest",0);
            }
            if (photonView) if (photonView.IsMine) Init();
        }
        else
        {
            if (!photonView) Init();
        }
        //  DNA = JsonUtility.FromJson
#if !UNITY_EDITOR
        if (PlayerMechanics.Active(MechanicId.CustomScripts)) dnSpyModer.MainModData.LoadScene();
#endif
        point = transform.position;
    }

    public void selfDest()
    {
        Destroy(gameObject);
    }

    [HideInInspector] public Color c1;
    int maxhp2;
    int regen;
    bool swapWHaN;
    public float CamDistanceMult = 1;
    public Logic_tag_3[] lt;
    public JsonGame file = new JsonGame();
    public AudioClip voiceResource; RawImage sas; bool sas1; Light[] all;
    bool Mobile;
    float timermodile;
    GameObject unityedit;
    private void Init()
    {
		varibleUpdate();
		var xbox2 = CachedXboxMode;
		  rayMarchCollider = GetComponent<PlayerRayMarchCollider>();
    mainCamera = Camera.main;
        //CharactorDebate
        //Хбокс
        //GeneratorPlakats
        if (true)
        {
            GameObject g = Resources.Load<GameObject>("GeneratorPlakats");
            Instantiate(g, transform);
        }
        if (true)
        {
            GameObject g = Resources.Load<GameObject>("CharactorDebate");
            Instantiate(g, transform);
        }
        if (true)
        {
            GameObject g = Resources.Load<GameObject>("067");
            Instantiate(g, transform.position, g.transform.rotation);
        }
        if (true)
        {
            GameObject g = Resources.Load<GameObject>("Политик стар");
            Instantiate(g, transform.position,Quaternion.identity);
		}
        if (xbox2)
        {
            GameObject g = Resources.Load<GameObject>("Хбокс");
            Instantiate(g, transform);
        }
        GameObject g7 = Resources.Load<GameObject>("AcountIco");
            Instantiate(g7, transform);
        GameObject g5 = Resources.Load<GameObject>("SpaceBorder");
            Instantiate(g5, transform.position,Quaternion.identity);

        if (VarSave.ExistenceVar("CapiKill"))
        {
            GameObject g = Resources.Load<GameObject>("ui/quests/killKapitalism");
            Instantiate(g, transform);
        }
        _san = new GameObject();
        _san.transform.position = Vector3.left * float.PositiveInfinity;
        _san.AddComponent<RawImage>();
        
        DirectoryInfo directory = new DirectoryInfo("res");
		lightFromFile =
    File.Exists("res/mick/Light.ini") &&
    File.ReadAllText("res/mick/Light.ini") == "True";
        if (lightFromFile) StartCoroutine(DnSpyFunctionalEasyActivator.GetTextResFolder("mick\\Light.png", sanImage));
        all = FindObjectsByType<Light>(sortmode.main);
        if (VarSave.ExistenceVar("interface")) Acaunt.Spawn(VarSave.GetString("interface"));
        if (VarSave.GetFloat("SevenSouls") > 0)
        {
            GameObject g = Resources.Load<GameObject>("UT.SevenSoulsScin");
            Instantiate(g, transform);
        }
        if ((UniverseSkyType)VarSave.GetInt("UST") == UniverseSkyType.AntyLight)
        {
            GameObject g = Resources.Load<GameObject>("NLRule");
            Instantiate(g, transform);
        }
        seson = (Seson)VarSave.GetInt("Seson");
        if (VarSave.GetFloat("Можно игрока обзывать" + "_gameSettings", SaveType.global) > -0.1)
        {

            if (UnityEngine.Random.Range(0, 12) == 0)
            {
                GameObject g = Resources.Load<GameObject>("voices/Metapov");
                Instantiate(g, transform);
            }
        }
        else if (VarSave.GetFloat("Можно игрока обзывать" + "_gameSettings", SaveType.global) < -0.1)
        {
            if (UnityEngine.Random.Range(0, 1000) == 0)
            {
                GameObject g = Resources.Load<GameObject>("voices/Metapov");
                Instantiate(g, transform);
            }
        }
        if (VarSave.GetFloat("Можно игрока обзывать" + "_gameSettings", SaveType.global) > 0.5)
        {
            if (UnityEngine.Random.Range(0, 5) == 0)
            {
                GameObject g = Resources.Load<GameObject>("voices/Metapov");
                Instantiate(g, transform);
            }
        }
        if (VarSave.GetFloat("Можно игрока обзывать" + "_gameSettings", SaveType.global) >= 1)
        {

            GameObject g = Resources.Load<GameObject>("voices/Metapov");
            Instantiate(g, transform);

        }
        if (seson == Seson.Зима)
        {
            GameObject g = Resources.Load<GameObject>("Осатки/Зима");
            Instantiate(g, transform);
        }
        if (seson == Seson.Мака)
        {
            GameObject g = Resources.Load<GameObject>("Осатки/Мака");
            Instantiate(g, transform);
        }
        if (VarSave.ExistenceVar("Ban non-Begin"))
        {
            SceneManager.LoadScene("Nervana");
        }
        if (File.Exists("res/UserWorckspace/games/" + VarSave.GetString("GameActive") + ".ugame"))
        {
            file = JsonUtility.FromJson<JsonGame>(File.ReadAllText("res/UserWorckspace/games/" + VarSave.GetString("GameActive") + ".ugame"));
            GameEditor.Opened = file;
        }
        if (VarSave.GetMoney("Winks", SaveType.local) > 0)
        {
            GameObject g = Resources.Load<GameObject>("WinksPM");
            Instantiate(g, transform);
        }
        GameObject g6 = Resources.Load<GameObject>("ExportGCPlanForCO");
        Instantiate(g6, transform);
        if (VarSave.GetBool("UnlockOmniscience", SaveType.computer))
        {
            foreach (GameObject g in Map_saver.t3)
            {

                if (!VarSave.ExistenceVar("researchs/" + g.name))
                {
                    Directory.CreateDirectory("unsave/var/researchs");


                    VarSave.LoadMoney("research", 1);

                    Globalprefs.research = VarSave.GetMoney("research");
                    VarSave.SetInt("researchs/" + g.name, 0);

                }
            }
        }
        if (VarSave.GetBool("ClearEffect", SaveType.computer))
        {
            playerdata.Cleareffect();
        }
        if (VarSave.GetBool("iddqd", SaveType.computer))
        {
            playerdata.Addeffect("Undyning", float.PositiveInfinity);
        }
        if (VarSave.GetBool("OrtoCam", SaveType.computer))
        {
            GameObject g = Resources.Load<GameObject>("OratographicCamera");
            Instantiate(g, Vector3.zero, Quaternion.identity);
        }
        if (VarSave.GetBool("Ranall", SaveType.computer))
        {
            GameObject g = Resources.Load<GameObject>("CameraRandomObject");
            Instantiate(g, Vector3.zero, Quaternion.identity);
        }
        Global.MEM.UE();
        ScheduleMechanic("reasonUpdate", 1, 10);

        /*  Collider[] allobj = FindObjectsByType<Collider>(sortmode.main);
          Vector3[] allpos = new Vector3[allobj.Length];
          int i2 = 0;
          for (int i =0;i<allobj.Length;i++)
          {
              Collider obj = allobj[i];
              if (!obj.GetComponent<CustomSaveObject>())  allpos[i2] = obj.transform.position; else
              {
                  allpos[i2] = Vector3.negativeInfinity;
              }
              if (true) i2 += 1;
          }
          Globalprefs.allTransphorms = allobj;
          Globalprefs.allpos = allpos;

         */
        GameObject g2 = new("init");
        gameInit.Init(g2);
        if (gameInit.init != null)
        {
            DontDestroyOnLoad(g2);
        }
        if ((UniverseSkyType)VarSave.GetInt("UST") == UniverseSkyType.Litch)
        {
            Instantiate(Resources.Load<GameObject>("events/LitchUniverse"));
        }
        Instantiate(Resources.Load<GameObject>("Sutck"));
        if (VarSave.GetBool("lol you Banned"))
        {
            SceneManager.LoadScene("Banned forever");
        }
        Globalprefs.QuestItemKollect = (short)VarSave.GetInt("QuestItemKollect", SaveType.global);
        Globalprefs.GetRealiyHash(4);
        if (gsave.DayOfEra==0) gsave.DayOfEra = DatePlus.dayOfEra();

        if (N_position.Count <= 0) N_position.Add(0);
        if (FindObjectsByType<MultyTransform>(sortmode.main).Length == 0)
        {


            GameObject g = new("4D Controler")
            {

            };


            g.AddComponent<MultyTransform>();
        }
        Instantiate(Resources.Load<GameObject>("audios/Nill"), transform.position, Quaternion.identity);
        editor = Resources.Load<GUISkin>("ui/test");
        List<TalantDNA> tals = new List<TalantDNA>();
        if (VarSave.ExistenceVar("DNA"))
        {
            DNA = JsonUtility.FromJson<PlayerDNA>(VarSave.GetString("DNA"));
            c1 = DNA.colour;
            Time.timeScale = DNA.metabolism;
            jumpPower += DNA.Jumping;
            maxhp2 = (int)DNA.hp;
            regen = (int)DNA.regeneration;
            if (DNA.talant != null)
            {
                if (DNA.talant.Count > 0)
                {
                    tals.Add((TalantDNA)DNA.talant[0]);
                    tals.Add((TalantDNA)DNA.talant[1]);
                    foreach (TalantDNA item in tals)
                    {
                        if (item == TalantDNA.fourLapka)
                        {
                            Globalprefs.fourlapka = true;
                        }
                        if (item == TalantDNA.born)
                        {
                            Globalprefs.born = true;
                        }
                        if (item == TalantDNA.KillZone)
                        {
                            GameObject g = Resources.Load<GameObject>("KillZone");
                            Instantiate(g, transform.position, quaternion.identity);
                        }
                    }
                }
            }
        }
        jumpPower += Globalprefs.GetRealiyChaos(4);
        cistalenemy.dies = VarSave.LoadInt("Agr", 0);
        Globalprefs.Chanse_fire = 0;
        if (RenderSettings.skybox.name == "Default-Skybox")
        {
            RenderSettings.skybox = Resources.Load<Material>("UniversesSkys/defaultSkybox");
        }
        timer5 += (decimal)(System.DateTime.Now.Hour);
        timer5 += (decimal)(System.DateTime.Now.DayOfYear) * 24;
        timer5 += (decimal)(System.DateTime.Now.Year) * 24 * 365;
        timer7 = (decimal)(System.DateTime.Now.Hour);
        timer7 += (decimal)(System.DateTime.Now.DayOfYear) * 24;
        timer7 += (decimal)(System.DateTime.Now.Year) * 24 * 365;
        decimal LastSesion = VarSave.GetMoney("LastSesion");
        decimal LastSesionHours = VarSave.GetMoney("LastSesionHours");
        if (LastSesion == 0)
        {
            LastSesion = timer5;
        }
        if (LastSesionHours == 0)
        {
            LastSesionHours = timer7;
        }
        if (VarSave.GetFloat("HorrorMode" + "_gameSettings", SaveType.global) > 0.5)
        {


            Instantiate(Resources.Load<GameObject>("audios/Шум"));
        }
        if (!Global.Random.determindAll)
        {
            float Chance = 100 / (VarSave.GetFloat("ChancePiratAttack" + "_gameSettings", SaveType.global) * (100f + Globalprefs.GetRealiyChaos(50)));
            if (UnityEngine.Random.Range(0, (float)Chance + 1) == 0)
            {
                UnityEngine.Debug.Log("CahncePiratAttack" + (int)Chance);
                Instantiate(Resources.Load<GameObject>("events/Pirats"));
            }
            float Chance2 = 100 / (VarSave.GetFloat("ChanceUMUTaxes" + "_gameSettings", SaveType.global) * (100f + Globalprefs.GetRealiyChaos(50)));
            if (UnityEngine.Random.Range(0, (float)Chance2 + 1) == 0)
            {
                cistalenemy.dies -= 2;
                Globalprefs.LoadTevroPrise(-100);
            }
            float Chance3 = 100 / (VarSave.GetFloat("ChanceDegradation" + "_gameSettings", SaveType.global) * (100f + Globalprefs.GetRealiyChaos(50)));
            if (UnityEngine.Random.Range(0, (float)Chance3 + 1) == 0)
            {
                DirectoryInfo di = new("unsave/var/researchs");
                int random = (int)Global.Random.Range(0, di.GetFiles().Length);
                File.Delete(di.GetFiles()[random].FullName);
                VarSave.LoadMoney("research", -1);
            }
        }
        else
        {

            Instantiate(Resources.Load<GameObject>("events/Pirats"));
            cistalenemy.dies -= 2;
            Globalprefs.LoadTevroPrise(-100);
            DirectoryInfo di = new("unsave/var/researchs");
            int random = (int)Global.Random.Range(0, di.GetFiles().Length);
            File.Delete(di.GetFiles()[random].FullName);
            VarSave.LoadMoney("research", -1);
        }
        if (timer7 != LastSesionHours)
        {

            //      VarSave.LoadMoney("tevro", Global.Random.Range(150,600) * VarSave.LoadMoney("Stocks", 0));



            //      VarSave.SetMoney("Stocks", 0);




        }
        decimal cashFlow = ((timer5 - LastSesion) * VarSave.GetMoney("CashFlow"));
        if (Sutck.day != 0) VarSave.LoadMoney("tevro", cashFlow);
        decimal overFlow = ((timer5 - LastSesion) * VarSave.GetMoney("OverFlow"));
        if (Sutck.day != 0) VarSave.LoadMoney("CashFlow", overFlow);
        Globalprefs.MultTevro = VarSave.GetTrash("MOMU", 0);
        fireInk = VarSave.GetFloat("FireInk");
        hyperbolicCamera = HyperbolicCamera.Main();
        StartCoroutine(coroutine());
        Globalprefs.bunkrot = VarSave.GetBool("Bunkrot");
        Globalprefs.research = VarSave.GetMoney("research");
        Globalprefs.technologies = VarSave.GetMoney("_technologies");
        Globalprefs.flowteuvro = VarSave.GetMoney("CashFlow") + ((decimal)Globalprefs.GetRealiyChaos(10f) / 100);
        Globalprefs.OverFlowteuvro = VarSave.GetMoney("OverFlow");
        Globalprefs.Infinitysteuvro = VarSave.GetTrash("inftevro");
        //  Globalprefs.OverFlowteuvro = VarSave.GetInt("uptevro");
        lif = Globalprefs.GetIdPlanet().ToString();
        lif += "_" + Globalprefs.GetTimeline();

        SaveFileInputField.text = Globalprefs.GetTimeline();

        if (File.Exists("unsave/capterg/" + SaveFileInputField.text))
        {
            gsave = JsonUtility.FromJson<GameData>(File.ReadAllText("unsave/capterg/" + SaveFileInputField.text));
            planet_position = gsave.Spos;
            lepts = "-" + planet_position.ToString();
        }


        Camera c = Instantiate(Resources.Load<GameObject>("point"), PlayerCamera.transform).AddComponent<Camera>();
        c.targetDisplay = 0;
		CreateCameraTexture(c);
        c.renderingPath = RenderingPath.DeferredShading;

        Globalprefs.camera = c;
        c.gameObject.AddComponent<Logic_tag_3>();

        if (isplanet)
        {
            gameObject.AddComponent<PlanetGravity>().body = transform;
            planetGravity.gravity = JumpTimer;
            if (!Smuta) gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        playerdata.Loadeffect();

        if (DNA != null) playerdata.LoadBakeeffect();
        ionenergy.energy = 0;
        vel = capsuleCollider.height;


        if (!VarSave.GetBool("Stone")) Instantiate(Resources.LoadAll<GameObject>("ui/postrender")[0]);


        //four-Dimentional-Axis
        if (GameObject.FindGameObjectsWithTag("i3").Length == 0) Instantiate(Resources.Load<GameObject>("player inventory"));
        if (VarSave.ExistenceVar("Player_On_Pirat_Attack")) Instantiate(Resources.Load<GameObject>("events/Pirats"));
        if (VarSave.ExistenceGlobalVar("eventPlevraSpamtona"))
        {
            Instantiate(Resources.Load<GameObject>("items/Смачный_плевок_Спамтона"));
            Instantiate(Resources.Load<GameObject>("events/ПлевокСпамтона"));
        }
        Instantiate(Resources.Load<GameObject>("ui/four-Dimentional-Axis"));
        Instantiate(Resources.Load<GameObject>("player inventory element 2"));
        if (!VarSave.GetBool("Stone")) Instantiate(Resources.Load<GameObject>("360AngleCamera"));
        Instantiate(Resources.Load<GameObject>("Rm/Hyper_null"));

        lt = FindObjectsByType<Logic_tag_3>(sortmode.main);
        if (!tutorial && inglobalspace != true)
        {

            WorldSave.GetVector4("var");
            WorldSave.GetVector3("var1");
            WorldSave.GetMusic(SceneManager.GetActiveScene().name);
            Directory.CreateDirectory("unsave");
            Directory.CreateDirectory("unsave/capterg");
            Directory.CreateDirectory("unsave/capter" + SceneManager.GetActiveScene().buildIndex);
            if (File.Exists("unsave/s"))
            {
                SaveFileInputField.text = File.ReadAllText("unsave/s");
            }
            if (File.Exists("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text))
            {
                save = JsonUtility.FromJson<PlayerData>(File.ReadAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text));
                rigidbody3d.angularVelocity = save.angularvelosyty;
                rigidbody3d.linearVelocity = save.velosyty;


                W_position = save.wpos;
                H_position = save.hpos;
                N_position = save.npos;
                cur_N_position = save.cnpos;
                HX_Rotation = save.hxrot;


                if (VarSave.GetBool("Stone"))
                {
                    GameObject g = Resources.Load<GameObject>("RockPlayer");
                    Instantiate(g, save.pos + Globalprefs.newv3, Quaternion.identity);
                    gameObject.AddComponent<DELETE>();
                }
                PlayerBody.transform.position = save.pos + Globalprefs.newv3;
                UnityEngine.Debug.Log(Globalprefs.newv3);
                Globalprefs.newv3 = Vector3.zero;
                //  sr.transform.position = Save.pos2;
                if (HyperbolicCamera.Main() != null)
                {
                    HyperbolicCamera.Main().RealtimeTransform = JsonUtility.FromJson<Hyperbolic2D>(save.hpos_Polar3);
                }
                if (Globalprefs.isnew)
                {


                    PlayerBody.transform.position += Globalprefs.newv3;
                    PlayerBody.transform.rotation = Globalprefs.q[0];
                    HeadCameraSetup.transform.rotation = Globalprefs.q[2];
                    PlayerCamera.transform.rotation = Globalprefs.q[1];
                    Globalprefs.isnew = false;
                }

                if (portallNumer.Portal == "WMove+")
                {
                    if (true)
                    {
                        PlayerBody.transform.position = Globalprefs.WMovepos;
                        W_position = -499;
                        if (HyperbolicCamera.Main() != null)
                        {
                            HyperbolicCamera.Main().RealtimeTransform = JsonUtility.FromJson<Hyperbolic2D>(save.hpos_Polar3);
                        }
                        //  sr.transform.position = Save.pos2;
                        PlayerCamera.transform.position = HeadCameraSetup.transform.position;

                    }
                    if (Globalprefs.isnew)
                    {


                        PlayerBody.transform.position += Globalprefs.newv3;
                        PlayerBody.transform.rotation = Globalprefs.q[0];
                        HeadCameraSetup.transform.rotation = Globalprefs.q[2];
                        PlayerCamera.transform.rotation = Globalprefs.q[1];
                        Globalprefs.isnew = false;
                    }
                }
                else if (portallNumer.Portal == "WMove-")
                {
                    if (true)
                    {
                        PlayerBody.transform.position = Globalprefs.WMovepos;
                        W_position = 499;
                        if (HyperbolicCamera.Main() != null)
                        {
                            HyperbolicCamera.Main().RealtimeTransform = JsonUtility.FromJson<Hyperbolic2D>(save.hpos_Polar3);
                        }
                        //  sr.transform.position = Save.pos2;
                        PlayerCamera.transform.position = HeadCameraSetup.transform.position;

                    }
                    if (Globalprefs.isnew)
                    {


                        PlayerBody.transform.position += Globalprefs.newv3;
                        PlayerBody.transform.rotation = Globalprefs.q[0];
                        HeadCameraSetup.transform.rotation = Globalprefs.q[2];
                        PlayerCamera.transform.rotation = Globalprefs.q[1];
                        Globalprefs.isnew = false;
                    }
                }

                PlayerBody.transform.rotation = save.q1;
                HeadCameraSetup.transform.rotation = save.q3;
                PlayerCamera.transform.rotation = save.q2;

                if (Get4DCam()) Get4DCam()._wRotation = save.rotW;
                playerCameraComponent.fieldOfView = save.vive;
                if (lt.Length != 0)
                {
                    lt[0].GetComponent<Camera>().fieldOfView = save.vive;
                }
            }
            if (File.Exists("unsave/capterg/" + SaveFileInputField.text))
            {
                gsave = JsonUtility.FromJson<GameData>(File.ReadAllText("unsave/capterg/" + SaveFileInputField.text));
                if (VarSave.GetBool("Stone"))
                {
                    GameObject g = Resources.Load<GameObject>("RockPlayer");
                    Instantiate(g, transform.position, Quaternion.identity);
                    gameObject.AddComponent<DELETE>();
                }
                CamDistanceMult = gsave.PlayerScale;
                transform.localScale = Vector3.one * gsave.PlayerScale;
                hp = gsave.hp;
                oxygen = gsave.oxygen;
                faceViewi = gsave.fv;
                planet_position = gsave.Spos;

                if (gsave.DayOfEra == 0) gsave.DayOfEra = DatePlus.dayOfEra();

            }
        }
        if (tutorial)
        {
            WorldSave.GetVector4("var");
            WorldSave.GetVector3("var1");
            WorldSave.GetMusic(SceneManager.GetActiveScene().name);
            Directory.CreateDirectory("unsavet");
            Directory.CreateDirectory("unsavet/capterg");
            Directory.CreateDirectory("unsavet/capter" + SceneManager.GetActiveScene().buildIndex);

            SaveFileInputField.text = "tutorial";

            if (File.Exists("unsavet/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text))
            {
                save = JsonUtility.FromJson<PlayerData>(File.ReadAllText("unsavet/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text));
                rigidbody3d.angularVelocity = save.angularvelosyty;
                rigidbody3d.linearVelocity = save.velosyty;

                W_position = save.wpos;
                H_position = save.hpos;
                N_position = save.npos;
                cur_N_position = save.cnpos;
                HX_Rotation = save.hxrot;
                if (VarSave.GetBool("Stone"))
                {
                    GameObject g = Resources.Load<GameObject>("RockPlayer");
                    Instantiate(g, save.pos + Globalprefs.newv3, Quaternion.identity);
                    gameObject.AddComponent<DELETE>();
                }

                PlayerBody.transform.position = save.pos + Globalprefs.newv3;
                UnityEngine.Debug.Log(Globalprefs.newv3);
                Globalprefs.newv3 = Vector3.zero;
                //  sr.transform.position = Save.pos2;
                if (HyperbolicCamera.Main() != null)
                {
                    HyperbolicCamera.Main().RealtimeTransform = JsonUtility.FromJson<Hyperbolic2D>(save.hpos_Polar3);
                }
                if (Globalprefs.isnew)
                {


                    PlayerBody.transform.position += Globalprefs.newv3;
                    PlayerBody.transform.rotation = Globalprefs.q[0];
                    HeadCameraSetup.transform.rotation = Globalprefs.q[2];
                    PlayerCamera.transform.rotation = Globalprefs.q[1];
                    Globalprefs.isnew = false;
                }
                if (portallNumer.Portal == "WMove+")
                {
                    if (true)
                    {
                        PlayerBody.transform.position = Globalprefs.WMovepos;
                        W_position = -499;
                        if (HyperbolicCamera.Main() != null)
                        {
                            HyperbolicCamera.Main().RealtimeTransform = JsonUtility.FromJson<Hyperbolic2D>(save.hpos_Polar3);
                        }
                        //  sr.transform.position = Save.pos2;
                        PlayerCamera.transform.position = HeadCameraSetup.transform.position;

                    }

                }
                else if (portallNumer.Portal == "WMove-")
                {
                    if (true)
                    {
                        PlayerBody.transform.position = Globalprefs.WMovepos;
                        W_position = 499;
                        if (HyperbolicCamera.Main() != null)
                        {
                            HyperbolicCamera.Main().RealtimeTransform = JsonUtility.FromJson<Hyperbolic2D>(save.hpos_Polar3);
                        }
                        //  sr.transform.position = Save.pos2;
                        PlayerCamera.transform.position = HeadCameraSetup.transform.position;

                    }

                }
                PlayerBody.transform.rotation = save.q1;
                HeadCameraSetup.transform.rotation = save.q3;
                PlayerCamera.transform.rotation = save.q2;

                if (Get4DCam()) Get4DCam()._wRotation = save.rotW;
                playerCameraComponent.fieldOfView = save.vive;
                if (lt.Length != 0)
                {
                    lt[0].GetComponent<Camera>().fieldOfView = save.vive;
                }
            }
            if (File.Exists("unsavet/capterg/" + SaveFileInputField.text))
            {
                gsave = JsonUtility.FromJson<GameData>(File.ReadAllText("unsavet/capterg/" + SaveFileInputField.text));
                CamDistanceMult = gsave.PlayerScale;
                transform.localScale = Vector3.one * gsave.PlayerScale;
                if (VarSave.GetBool("Stone"))
                {
                    GameObject g = Resources.Load<GameObject>("RockPlayer");
                    Instantiate(g, transform.position, Quaternion.identity);
                    gameObject.AddComponent<DELETE>();
                }
                if (gsave.hp >= 20) hp = gsave.hp; else
                {
                    hp = 20;
                }
                oxygen = gsave.oxygen;
                faceViewi = gsave.fv;
                planet_position = gsave.Spos;

                if (gsave.DayOfEra == 0) gsave.DayOfEra = DatePlus.dayOfEra();
            }




        }

        lif = Globalprefs.GetIdPlanet().ToString();
        lif += "_" + Globalprefs.GetTimeline();
        hyperbolicCamera = HyperbolicCamera.Main();
    }

   
    float data_BGPU;
    float data_mana;
    float data_luck;
    decimal data_stocks;
    string data_profstatus;
    decimal data_inflation;
    decimal data_Cumbs;
    decimal data_meats;
    decimal data_relic;
    decimal data_tears;
    decimal data_shits;
    decimal data_Karma;
    UniverseSkyType data_universetype;
    //Пробуждение кода
    //Приметивный интерфейс
	private Metka[] metka2 = Array.Empty<Metka>();

private float nextRefresh;
private float nextRefresh2;
int metkaLengthold;
    Texture[] metka;
    FileInfo[] customVaribles;
	private RenderTexture cameraTexture;

void CreateCameraTexture(Camera camera)
{
    if (cameraTexture != null)
    {
        cameraTexture.Release();
        Destroy(cameraTexture);
    }

    cameraTexture = new RenderTexture(
        Screen.width,
        Screen.height,
        24,
        RenderTextureFormat.ARGB32
    );

    cameraTexture.Create();

    camera.targetTexture = cameraTexture;
}
    private void OnGUI()
    {
        if (Unauticna.MediaStudio.MediaStudioHost.IsOpen) return;
        if (PlayerMechanics.CapturesInput || Event.current.type != EventType.Repaint) return;






        if (PlayerMechanics.Active(MechanicId.Markers) && Globalprefs.camera != null && metka2.Length != 0)
        {
            for (int i = 0; i < metka2.Length; i++)
            {

                if (metka2[i] != null)
                {
                    Vector3 t = Globalprefs.camera.WorldToViewportPoint(metka2[i].transform.position);
                    if (t.z > 0)
                    {
                        Vector3 u = Globalprefs.camera.ViewportToScreenPoint(t);
						if(metka[i]==null)metka[i] =metka2[i].GetComponent<MeshRenderer>().sharedMaterial.GetTexture("_MainTex");
                        GUI.DrawTexture(new Rect(u.x - 10, (Screen.height - u.y) - 10, 20, 20), metka[i]);
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            GUI.DrawTexture(new Rect((Screen.width / 2) - 10, (Screen.height / 2) - 10, 20, 20), cursorTexture);
        }
        if (PlayerMechanics.Active(MechanicId.DebugHud) && Input.GetKey(KeyCode.F8))
        {
            GUI.Label(new Rect(0f, 0, 200f, 100f), "Unauticna Alpha*and Omega*-version");
            if (!hyperbolicCamera) GUI.Label(new Rect(0f, 20, 200f, 100f), "Euclidian World Position x : " + new_center.x.ToString() + " y : " + new_center.y.ToString() + " z : " + new_center.z.ToString() + " w : " + W_position.ToString());
            if (hyperbolicCamera) GUI.Label(new Rect(0f, 20, 200f, 100f), "Hyperbolic World Position x : " + hyperbolicCamera.RealtimeTransform.n.ToString() + " y : " + hyperbolicCamera.RealtimeTransform.s.ToString() + " z : " + hyperbolicCamera.RealtimeTransform.m.ToString() + " w : " + new_center.y.ToString() + " h : " + W_position.ToString());
            GUI.Label(new Rect(0f, 70, 200f, 100f), "Cotinuum Position : " + SceneManager.GetActiveScene().buildIndex);
            if (FindObjectsByType<GenTest>(sortmode.main).Length != 0) GUI.Label(new Rect(0f, 90, 200f, 100f), "Space Position : " + planet_position);
            GUI.Label(new Rect(0f, 90, 200f, 100f), "Cotinuum name : " + SceneManager.GetActiveScene().name);

            GUI.Label(new Rect(0f, 120, 200f, 100f), "Unity Version : " + Application.unityVersion);
            GUI.Label(new Rect(0f, 130, 200f, 100f), "Game Version : " + Application.version);


        }
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            GUI.Label(new Rect(0f, 0, 200f, 100f), "Game Varibles :");

            if (playerdata.Geteffect("No kapitalism") == null)
            {
                if (playerdata.Geteffect("Unyverseium_money_cart") != null)
                {
                    if (Globalprefs.Infinitysteuvro > 0) GUI.Label(new Rect(0f, 440, 300f, 100f), "Teuvro (T) : ∞ * " + Globalprefs.Infinitysteuvro + "E" + Globalprefs.MultTevro);
                    else GUI.Label(new Rect(0f, 460, 300f, 100f), "Teuvro (T) : " + Math.Round(VarSave.GetMoney("tevro1"), 2) + "E" + Globalprefs.MultTevro);

                }
                else
                {
                    GUI.Label(new Rect(0f, 480, 300f, 100f), "Teuvro (T) : " + Math.Round(VarSave.GetMoney("tevro1"), 2) + "E" + Globalprefs.MultTevro);
                }
            }
            int maxcollect = 0;
            if (VarSave.GetString("quest", SaveType.global) == "капуста") maxcollect = 10;
            if (playerdata.Geteffect("No kapitalism") != null) GUI.Label(new Rect(0f, 500, 300f, 100f), "Teuvro (T) : " + "∞" + "E" + Globalprefs.MultTevro);
            
            if (playerdata.Geteffect("No kapitalism") == null)
            {
                if (playerdata.Geteffect("Unyverseium_money_cart") != null)
                {
                    if (Globalprefs.Infinitysteuvro > 0) GUI.Label(new Rect(0f, 20, 300f, 100f), "Non-verify Teuvro (T) : ∞ * " + Globalprefs.Infinitysteuvro + "E" + Globalprefs.MultTevro);
                    else GUI.Label(new Rect(0f, 20, 300f, 100f), "Non-verify Teuvro (T) : " + Math.Round(VarSave.GetMoney("tevro"), 2) + "E" + Globalprefs.MultTevro);

                }
                else
                {
                    GUI.Label(new Rect(0f, 20, 300f, 100f), "Non-verify Teuvro (T) : " + Math.Round(VarSave.GetMoney("tevro"), 2) + "E" + Globalprefs.MultTevro);
                }
            }
            if (VarSave.GetString("quest", SaveType.global) == "капуста") maxcollect = 10;
            if (playerdata.Geteffect("No kapitalism") != null) GUI.Label(new Rect(0f, 20, 300f, 100f), "Non-verify Teuvro (T) : " + "∞" + "E" + Globalprefs.MultTevro);
            GUI.Label(new Rect(0f, 40, 300f, 100f), "Non-verify Flow Teuvro on hour (T^) : " + Math.Round(Globalprefs.flowteuvro, 2) + "E" + Globalprefs.MultTevro);
            GUI.Label(new Rect(0f, 60, 200f, 100f), "Bunkrot : " + Globalprefs.bunkrot);
            if (Globalprefs.selectitemobj)
            {
                if (!Globalprefs.selectitemobj.GetComponent<itemName>().ItemInfinitysPrise) GUI.Label(new Rect(0f, 80, 200f, 100f), "Item price : " + Globalprefs.ItemPrise * (Globalprefs.GetProcentInflitiuon() + 1));
                if (Globalprefs.selectitemobj.GetComponent<itemName>().ItemInfinitysPrise) GUI.Label(new Rect(0f, 80, 300f, 100f), "Item price : ∞ * " + Globalprefs.ItemPrise * (Globalprefs.GetProcentInflitiuon() + 1) + " По скидке");
            }
            else
            {
                GUI.Label(new Rect(0f, 80, 200f, 100f), "Item price : " + Globalprefs.ItemPrise * (Globalprefs.GetProcentInflitiuon() + 1));
            }
            GUI.Label(new Rect(0f, 100, 200f, 100f), "Scientific research (?) : " + Globalprefs.research);
            GUI.Label(new Rect(0f, 120, 200f, 100f), "Knowlages (!) : " + (Globalprefs.knowlages + gsave.progressofthepassage).ToString());
            GUI.Label(new Rect(0f, 140, 200f, 100f), "Technologies (!^) : " + Globalprefs.technologies);
            GUI.Label(new Rect(0f, 160, 200f, 100f), "Universe Type (*) : " + data_universetype);
            if (playerdata.Geteffect("Undyning") == null) GUI.Label(new Rect(0f, 180, 200f, 100f), "Healf Point (♦) : " + hp);
            if (playerdata.Geteffect("Undyning") != null) GUI.Label(new Rect(0f, 180, 200f, 100f), "Healf Point (■) : " + "∞ ok is this mean we don't dyeing?");
            GUI.Label(new Rect(0f, 200, 200f, 100f), "Fire (▲) : " + fireInk);
            GUI.Label(new Rect(0f, 220, 200f, 100f), "Stocks (T*) : " + data_stocks);
            GUI.Label(new Rect(0f, 240, 200f, 100f), "violation of the pacific regime (V^V) : " + cistalenemy.dies);
            GUI.Label(new Rect(0f, 270, 200f, 100f), "Inflation : " + data_inflation + "%");
            if (data_profstatus != "")
            {
                GUI.Label(new Rect(0f, 300, 200f, 100f), "ProfStatus : " + data_profstatus);
            }
            else
            {
                GUI.Label(new Rect(0f, 300, 200f, 100f), "ProfStatus : " + "Unknown");
            }
            GUI.Label(new Rect(0f, 320, 200f, 100f), "QuestItemCollect : " + Globalprefs.QuestItemKollect.ToString() + " / " + maxcollect);
            GUI.Label(new Rect(0f, 340, 200f, 100f), "Intelect : " + (100 + (CosProgress()) * 10));
            GUI.Label(new Rect(0f, 360, 200f, 100f), "Mana : " + data_mana);
            GUI.Label(new Rect(0f, 380, 200f, 100f), "Luck : " + data_luck);
            GUI.Label(new Rect(0f, 400, 200f, 100f), "Reason : " + Globalprefs.reasone + " / " + (100 + (data_BGPU * 10)));
            GUI.Label(new Rect(0f, 420, 300f, 100f), "Flow Flow Teuvro on hour (T^^) : " + Math.Round(Globalprefs.OverFlowteuvro, 2) + "E" + Globalprefs.MultTevro);

            GUI.Label(new Rect(Screen.width - 200, 0, 200, 40), "TimeRegion : " + ((TimeOfGame)Sutck.day).ToString(), editor.label);
            GUI.Label(new Rect(Screen.width - 200, 20, 200, 40), "Temperature : " + Sutck.Temperature() + "˚", editor.label);
            GUI.Label(new Rect(Screen.width - 200, 40, 200, 40), "Count pepole in your contry : " + VarSave.GetInt("pepole"), editor.label);
            GUI.Label(new Rect(Screen.width - 200, 60, 200, 40), "Avtoritet : " + VarSave.GetMoney("Avtoritet"), editor.label);
            GUI.Label(new Rect(Screen.width - 200, 80, 200, 40), "Slave : " + VarSave.GetBool("Slave"), editor.label);
            GUI.Label(new Rect(Screen.width - 200, 100, 200, 40), "Clumbs : " + data_Cumbs, editor.label);
            GUI.Label(new Rect(Screen.width - 200, 120, 200, 40), "Meats : " + data_meats, editor.label);
            GUI.Label(new Rect(Screen.width - 200, 140, 200, 40), "Relic : " + data_relic, editor.label);
            GUI.Label(new Rect(Screen.width - 200, 160, 200, 40), "Tears : " + data_tears, editor.label);
            GUI.Label(new Rect(Screen.width - 200, 180, 200, 40), "Shits : " + data_shits, editor.label);
            GUI.Label(new Rect(Screen.width - 200, 200, 200, 40), "Karma : " + data_Karma, editor.label);
            int i2 = 0;
          if(customVaribles.Length>0)  foreach (FileInfo i in customVaribles)
            {
                GUI.Label(new Rect(Screen.width - 200, 220+(i2*20), 200, 40), i.Name + " : " + VarSave.GetMoney(i.Name), editor.label);
                i2++;
            }
            //data_Karma
            // VarSave.LoadMoney("Avtoritet", 1)
            //cistalenemy.dies


        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (CosProgress() <= 1)
            {
                GUI.Label(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 10, (Screen.width / 2) + 100, (Screen.height / 2) + 30), "4D move : " + Sprint.ToString());
                if (!hyperbolicCamera && gameObject.layer == 2) Globalprefs.PlayerPositionInfo = "Euclidian World Position x : " + new_center.x.ToString() + " y : " + new_center.y.ToString() + " z : " + new_center.z.ToString() + " w : " + W_position.ToString();
                else if (hyperbolicCamera) Globalprefs.PlayerPositionInfo = "Hyperbolic World Position x : " + hyperbolicCamera.RealtimeTransform.s.ToString() + " y : " + new_center.y.ToString() + " z : " + hyperbolicCamera.RealtimeTransform.m.ToString() + " w : " + W_position.ToString();
                if (gameObject.layer == 11) Globalprefs.PlayerPositionInfo = "Liminal World Position x : " + new_center.x.ToString() + " y : " + new_center.y.ToString() + " z : " + new_center.z.ToString() + " s : " + "1";
                if (gameObject.layer == 12) Globalprefs.PlayerPositionInfo = "Liminal World Position x : " + new_center.x.ToString() + " y : " + new_center.y.ToString() + " z : " + new_center.z.ToString() + " s : " + "2";
            }
            if (CosProgress() > 1 && CosProgress() <= 2)
            {
                GUI.Label(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 10, (Screen.width / 2) + 100, (Screen.height / 2) + 30), "4D move : " + Sprint.ToString());
                if (!hyperbolicCamera && gameObject.layer == 2) Globalprefs.PlayerPositionInfo = "Euclidian World Position x : " + new_center.x.ToString() + " y : " + new_center.y.ToString() + " z : " + new_center.z.ToString() + " w : " + W_position.ToString() + " h : " + H_position.ToString();
                else if (hyperbolicCamera) Globalprefs.PlayerPositionInfo = "Hyperbolic World Position x : " + hyperbolicCamera.RealtimeTransform.s.ToString() + " y : " + new_center.y.ToString() + " z : " + hyperbolicCamera.RealtimeTransform.m.ToString() + " w : " + W_position.ToString() + " h : " + H_position.ToString();
                if (gameObject.layer == 11) Globalprefs.PlayerPositionInfo = "Liminal World Position x : " + new_center.x.ToString() + " y : " + new_center.y.ToString() + " z : " + new_center.z.ToString() + " s : " + "1" + " h : " + H_position.ToString();
                if (gameObject.layer == 12) Globalprefs.PlayerPositionInfo = "Liminal World Position x : " + new_center.x.ToString() + " y : " + new_center.y.ToString() + " z : " + new_center.z.ToString() + " s : " + "2" + " h : " + H_position.ToString();
            }
            if (CosProgress() > 2)
            {

                if (N_position.Count <= 0) N_position.Add(0);
                GUI.Label(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 10, (Screen.width / 2) + 100, (Screen.height / 2) + 30), "4D move : " + Sprint.ToString());
                if (!hyperbolicCamera && gameObject.layer == 2) Globalprefs.PlayerPositionInfo = "Euclidian World Position x : " + new_center.x.ToString() + " y : " + new_center.y.ToString() + " z : " + new_center.z.ToString() + " w : " + W_position.ToString() + " h : " + H_position.ToString() + " n [" + cur_N_position + "] : " + N_position[cur_N_position].ToString();
                else if (hyperbolicCamera) Globalprefs.PlayerPositionInfo = "Hyperbolic World Position x : " + hyperbolicCamera.RealtimeTransform.s.ToString() + " y : " + new_center.y.ToString() + " z : " + hyperbolicCamera.RealtimeTransform.m.ToString() + " w : " + W_position.ToString() + " h : " + H_position.ToString() + " n [" + cur_N_position + "] : " + N_position[cur_N_position].ToString();
                if (!hyperbolicCamera)
                {
                    if (gameObject.layer == 11) Globalprefs.PlayerPositionInfo = "Liminal World Position x : " + new_center.x.ToString() + " y : " + new_center.y.ToString() + " z : " + new_center.z.ToString() + " s : " + "1" + " h : " + H_position.ToString() + " n [" + cur_N_position + "] : " + N_position[cur_N_position].ToString();
                    if (gameObject.layer == 12) Globalprefs.PlayerPositionInfo = "Liminal World Position x : " + new_center.x.ToString() + " y : " + new_center.y.ToString() + " z : " + new_center.z.ToString() + " s : " + "2" + " h : " + H_position.ToString() + " n [" + cur_N_position + "] : " + N_position[cur_N_position].ToString();
                }
                if (hyperbolicCamera)
                {
                    if (gameObject.layer == 11) Globalprefs.PlayerPositionInfo = "Hyperkomplex World Position x : " + hyperbolicCamera.RealtimeTransform.s.ToString() + " y : " + new_center.y.ToString() + " z : " + hyperbolicCamera.RealtimeTransform.m.ToString() + " s : " + "1" + " h : " + H_position.ToString() + " n [" + cur_N_position + "] : " + N_position[cur_N_position].ToString();
                    if (gameObject.layer == 12) Globalprefs.PlayerPositionInfo = "Hyperkomplex World Position x : " + hyperbolicCamera.RealtimeTransform.s.ToString() + " y : " + new_center.y.ToString() + " z : " + hyperbolicCamera.RealtimeTransform.m.ToString() + " s : " + "2" + " h : " + H_position.ToString() + " n [" + cur_N_position + "] : " + N_position[cur_N_position].ToString();
                }
            }
            Globalprefs.AnyversePlayerPositionInfo = "Freedom Anyverse Position x : " + Globalprefs.GetIdPlanet() + " y : " + Globalprefs.GetTimeline() + "," + (CurrentTime()) + " z : re " + Globalprefs.Reality + " , muc " + "0" + " , li " + VarSave.GetString("CurrentSpace") + " " + VarSave.GetMoney("datasurface/" + VarSave.GetString("CurrentSpace")) + " , gli " + "0";

        }
    }
    bool perMorphin;
    public static GameObject DopPlayerModel;
    [DllImport("AssemblyCPP")]
    public static extern long my_cpp_pluss(long a, long b);
    public static FemLibido fl;
    public static translate leng = new translate();
    private Texture cursorTexture;
    //Приметивный интерфейс
	void StopInvoke_Repeating(string name)
	{
	}
	void StopInvoke_Repeating(string name,float time)
	{
	}
	void StopInvoke_Repeating(string name,float time,float time2)
	{
	}
	private Camera playerCameraComponent;
	private CapsuleCollider capsuleCollider;
	private PlanetGravity planetGravity;
	private PhotonView photonView;
	private SimsMover simsMover;
	private PhotoCapture photoCapture;
	private Camera globalCameraComponent;
	void varibleUpdate()
	{
		playerCameraComponent = PlayerCamera != null
		? PlayerCamera.GetComponent<Camera>()
		: null;
	
		capsuleCollider = GetComponent<CapsuleCollider>();
		photonView = GetComponent<PhotonView>();
		
		if (isplanet)
			planetGravity = GetComponent<PlanetGravity>();
		
				if (PlayerMechanics.Active(MechanicId.Strategy) && simsMover == null) simsMover = FindFirstObjectByType<SimsMover>();
				if (photoCapture == null && faceViewi != faceView.first) photoCapture = FindFirstObjectByType<PhotoCapture>();
	}
    void Start()
    {
		cursorTexture = Resources.Load<Texture>("cursor");
        leng.innichializishon();
        if (PlayerMechanics.Active(MechanicId.ExternalApps))
        {
        Process[] processes = Process.GetProcessesByName("MinerRubles.exe");
        if (processes.Length > 0)
        {

        }
        else
        {

            hello.windowmesenge.LoadApplication("MinerRubles");
        }
        Process[] processes1 = Process.GetProcessesByName("VoicePlayer.exe");
        if (processes1.Length > 0)
        {

        }
        else
        {

            hello.windowmesenge.LoadApplication("VoicePlayer");
        }
        }
        if (VarSave.GetFloat("PetDetermination") > 0)
        {
            for (int i = 0; i < VarSave.GetFloat("PetDetermination"); i++)
            {


                GameObject g = Resources.Load<GameObject>("Determination");
                Instantiate(g, transform.position, Quaternion.identity);
            }
        }
        if (VarSave.GetInt("SlaversNervs") > 15)
        {
            VarSave.SetBool("Slave",true);
        }
        if (VarSave.GetBool("Slave"))
        {
          if(VarSave.GetFloat("SevenSouls") == 0)  if (SceneManager.GetActiveScene().name!="Slave")
            {
                SceneManager.LoadScene("Slave");
            }
        }
        // ScheduleMechanic("GameUpdate", 1, 0.07f);
        gameObject.AddComponent<Conseole_trigger>();
        fog = RenderSettings.fogStartDistance;
        fog2 = RenderSettings.fogEndDistance;
        if (VarSave.GetBool("cry"))
        {
            Instantiate(Resources.Load<GameObject>("ui/defet/achievement").gameObject, transform.position, Quaternion.identity);

            VarSave.SetBool("cry", false);
        }
        if (VarSave.ExistenceGlobalVar("mus"))
        {
            GameObject[] g = GameObject.FindGameObjectsWithTag("game musig");

            for (int i = 0; i < g.Length; i++)
            {
                g[i].GetComponent<AudioSource>().volume = VarSave.GetGlobalFloat("mus");
            }
        }
        Map_saver.GetAllMorphs();
        if (playerdata.Geteffect("KsenoMorfin") != null)
        {
            GameObject morphmodel = null;
            morphmodel = Instantiate(Map_saver.t5[VarSave.GetInt("CurrentMorf")], transform);
            if (morphmodel != null) if (morphmodel.GetComponent<MoveCamera>()) HeadCameraSetup.transform.position += PlayerBody.transform.up * morphmodel.GetComponent<MoveCamera>().yPos;
            DopPlayerModel = morphmodel;
            perMorphin = true;
        }
        else if (VarSave.GetString("ActiveScin") != "")
        {
            GameObject morphmodel = null;
            morphmodel = Instantiate(Resources.Load<GameObject>("Morfs/CustomObject"), transform);
            Scin scin;
            if (File.Exists("res/UserWorckspace/skins/" + VarSave.GetString("ActiveScin") + ".txt"))
            {
                scin = JsonUtility.FromJson<Scin>(File.ReadAllText("res/UserWorckspace/skins/" + VarSave.GetString("ActiveScin") + ".txt"));
                VarSave.SetString("Scin", scin.CO_name);
                if(scin.isfemale)
                {

                    fl = Instantiate(Resources.Load<GameObject>("FemLibido"), transform).GetComponent<FemLibido>(); 
                    if (playerdata.Geteffect("BoreDomLibido") != null)
                    {
                        fl.minlibido = 6;
                        fl.porogvozbujenia = 1;
                        fl.porogvozbujeniamin = 1;
                        fl.porogvozbujeniamax = 1;
                    }
                }
                morphmodel.transform.position += scin.pos;
                HeadCameraSetup.transform.position = transform.position + scin.cum;
            }
            if (morphmodel != null) if (morphmodel.GetComponent<MoveCamera>()) HeadCameraSetup.transform.position += PlayerBody.transform.up * morphmodel.GetComponent<MoveCamera>().yPos;
            DopPlayerModel = morphmodel;
            perMorphin = true;
        }
        int Spawnrade = SpawnRadeBonus.m_SpawnRadeBonusList.Count + 1;
        if (PolitDate.IsVersionF(politicfreedom.lidertatian) && PolitDate.IsVersionE(politiceconomic.mind)) Spawnrade += 1;
           // ScheduleMechanic("UpdateTargets", 0, 1);
        if ((PolitDate.IsGood(politicfreedom.avtoritatian) && cistalenemy.dies>0) || PolitDate.IsGood(politicfreedom.lidertatian) || PolitDate.IsGood(politicfreedom.NonPositionalian))
        {
            int i7 = UnityEngine.Random.Range(0,14);
            

                if (i7 == 0)ScheduleMechanic("bomjspawn", (60 * 3f) / Spawnrade, (60 * 3) / Spawnrade);
                if (i7 == 1)ScheduleMechanic("мгеspawn", (60 * 5f) / Spawnrade, (60 * 2.7f) / Spawnrade);
                if (i7 == 2)ScheduleMechanic("kilspawn", (60 * 5f) / Spawnrade, (60 * 2.5f) / Spawnrade);
                if (i7 == 3)ScheduleMechanic("Raydspawn", (60 * 5f) / Spawnrade, (60 * 1.5f) / Spawnrade);
                if (i7 == 4)ScheduleMechanic("pirspawn", (60 * 5f) / Spawnrade, (60 * 1.5f) / Spawnrade);
                if (i7 == 5)ScheduleMechanic("Rayhspawn", (60 * 5f) / Spawnrade, (60 * 1.5f) / Spawnrade);
                if (i7 == 6)ScheduleMechanic("spamspawn", (60 * 5f) / Spawnrade, (60 * 1.5f) / Spawnrade);
            if (i7 == 7) ScheduleMechanic("hamspawn", (60 * 5f) / Spawnrade, (60 * 1.5f) / Spawnrade);
            if (i7 == 8) ScheduleMechanic("Karavanspawn", (10f) / Spawnrade, (60 * 2f) / Spawnrade);
            if (i7 == 9)ScheduleMechanic("libspawn", 20f / Spawnrade, 20f / Spawnrade);
                if (i7 == 10)ScheduleMechanic("Ultralibspawn", 10f / Spawnrade, 10f / Spawnrade);
            if (i7 == 11) ScheduleMechanic("LeftAnarhistspawn", 10f / Spawnrade, 10f / Spawnrade);
            if (i7 == 12) ScheduleMechanic("Plantspawn", 10f / Spawnrade, 10f / Spawnrade);
            if (i7 == 13) ScheduleMechanic("libertaectspawn", 10f / Spawnrade, 10f / Spawnrade);
            ScheduleMechanic("NAKOMANightmares", 10f / Spawnrade, 10f / Spawnrade);

            //libertaectspawn()
        }
        ScheduleMechanic("Portal", 0, 1);
        if(VarSave.GetInt("Virus")>=1) ScheduleMechanic("Virus", 0, 5);
        //  Invoke("Karavanspawn", 10f / Spawnrade);
        //Ultralibspawn
        if (UnityEngine.Random.Range(0, 35) < 1)
        {
            SceneManager.LoadScene("Donat");
        }
        DirectoryInfo dif = new DirectoryInfo("res/UserWorckspace/Vars");
        customVaribles = dif.GetFiles();
        //
        ScheduleMechanic("ResetSpace", 5, 1);
        if (sali == null) sali = FindFirstObjectByType<RaycastCubeBuilder>(FindObjectsInactive.Include);
        mechanicJs = GetComponent<JSPlayer>();
        mechanicStarted = true;
        MechanicSettingsChanged();

    }
    public static string curbutton;
    List<float> TimeButtonMacros = new List<float>();
    public List<string> Key = new List<string>();
    int patrn = 0;
    public void ResetSpace()
    {
		varibleUpdate();
        RayCastStars.nravixOverbunds = false;
		if (_san != null && sanImage == null) sanImage = _san.GetComponent<RawImage>();
		FindOxygenUI();//он не дооступен изначально он создаеться только когда игрок вводе
    }
    public void LoadLuaLogicMacros(string loadedCode)
    {
        if (!PlayerMechanics.Active(MechanicId.CustomScripts)) return;

        TimeButtonMacros = new();
        Key = new();
        //   string scriptCode = @"    
        //	-- defines a Jump function
        //	function Jump (time)
        //		if (time>= 1) then
        //			return 1
        //       else
        //           return 0
        //		end
        //	end";
        UserData.RegisterType<List<float>>();
        UserData.RegisterType<List<string>>();
        Script script = new Script();
        script.Globals["_time"] = TimeButtonMacros;
        script.Globals["_key"] = Key;
        script.DoString(loadedCode);


        DynValue luaFactFunction = script.Globals.Get("Time");

        DynValue res = script.Call(luaFactFunction, new object[]
        {
            ((double)patrn)
        }
        );
        DynValue luaFactFunction2 = script.Globals.Get("Key");

        DynValue res2 = script.Call(luaFactFunction2, new object[]
        {
            ((double)patrn)
        }
        );



        if (res.UserData.Object != null)
        {
            TimeButtonMacros = (List<float>)res.UserData.Object;
        }
        if (res2.UserData.Object != null)
        {
            Key = (List<string>)res2.UserData.Object;
        }
        patrn++;




    }
    float timer13;
    public void IRMacros()
    {
        if (!PlayerMechanics.Active(MechanicId.CustomScripts)) return;

        timer13 += 0.01f;
        if (TimeButtonMacros.Count!= 0)
        {
            if (timer13 > TimeButtonMacros[0])
            {
                curbutton = Key[0];
                TimeButtonMacros.Remove(TimeButtonMacros[0]);
                Key.Remove(Key[0]);
                timer13 = 0;
            }
        }
        else
        {
            curbutton = "";
        }
    }
    public static bool xboxKeyMacros(string key)
    {
        return key == curbutton;
    }
    public List<Vector3> BuildPosition(List<float> vec)
    {
        List<Vector3> vec3 = new List<Vector3>();
        for (int i = 0; i < vec.Count; i += 3)
        {

            vec3.Add(new(vec[i], vec[i + 1], vec[i + 2]));


        }
        return vec3;
    }
    Vector3 randommaze()
    {
        Vector3 rand = new(UnityEngine.Random.rotation.x, UnityEngine.Random.rotation.y, UnityEngine.Random.rotation.z);
        return rand;
    }
    bool IfSpawn(string itemname)
    {
        if (PolitDate.IsVersionF(politicfreedom.avtoritatian))
        {
            return false;
        }
        return true;
    }
    //РейдерГипопотам
    void NAKOMANightmares()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;

        //Чёрное_радио


        for (int i = 0; i < 6; i++)
        {
            Ray r = new(transform.position + (transform.up * 40), randommaze());
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    Instantiate(Resources.Load<GameObject>("Items/БоссАруаРастрахиватель"), hit.point, Quaternion.identity);
                }
            }
        }

    }
    void Portal()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;

        //Чёрное_радио
        if (button6.randomportal1)
        {

            transform.position += Vector3.up * 20;

            Instantiate(Resources.Load<GameObject>("Items/(Rand)Portal"), transform.position, Quaternion.identity);
            button6.randomportal1 = false;
        }

    }
    void Virus()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;

        //Чёрное_радио
        if (!lml1.Find())
        {

            for (int i = 0; i < 6; i++)
            {
                Ray r = new(transform.position, randommaze());
                RaycastHit hit;
                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider != null)
                    {
                        //ГлистБесконейнойДлины
                        Instantiate(Resources.Load<GameObject>("Items/Infection"), hit.point, Quaternion.identity);
                    }
                }
            } //ГлистБесконейнойДлины
            if (UnityEngine.Random.Range(0, 4) < 1) Instantiate(Resources.Load<GameObject>("Items/ГлистБесконейнойДлины"), transform.position, Quaternion.identity);
        }

    }
    void bomjspawn()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;

        //Чёрное_радио
        if (VarSave.LoadInt("одинСпамтонПопрошайка" + Map_saver.total_lif + SceneManager.GetActiveScene().name, 1) > 7) if (IfSpawn("Попрашайка")) if (Global.Random.Chance(2))
                {
                    if (UnityEngine.Random.Range(0, 35) < 1)
                    {
                        SceneManager.LoadScene("Donat");
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        Ray r = new(transform.position + (transform.up * 40), randommaze());
                        RaycastHit hit;
                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                Instantiate(Resources.Load<GameObject>("Items/Попрашайка"), hit.point, Quaternion.identity);
                            }
                        }
                    }
                }
        if (IfSpawn("Чёрное_радио")) if (Global.Random.Chance(2))
            {
                if (UnityEngine.Random.Range(0, 35) < 1)
                {
                    SceneManager.LoadScene("Donat");
                }
                for (int i = 0; i < 6; i++)
                {
                    Ray r = new(transform.position + (transform.up * 40), randommaze());
                    RaycastHit hit;
                    if (Physics.Raycast(r, out hit))
                    {
                        if (hit.collider != null)
                        {
                            Instantiate(Resources.Load<GameObject>("Items/Чёрное_радио"), hit.point, Quaternion.identity);
                        }
                    }
                }
            }
        if (!VarSave.ExistenceVar("одинСпамтонРеламотр" + Map_saver.total_lif + SceneManager.GetActiveScene().name)) if (!VarSave.ExistenceVar("Служба выполнена!")) if (IfSpawn("spamtonAnarhyUMUVoencom")) if (Global.Random.Chance(2))
                    {
                        if (UnityEngine.Random.Range(0, 35) < 1)
                        {
                            SceneManager.LoadScene("Donat");//почини или похуй! я не знаю не уверен был полностью в полнонужности это го контента я больше хотел раздражать людей сложностью игры чем была аудитория готовая плотить деньги? ок понятно бюрократы просто приближаються и я не готов требовать деньги с игроков и не известная посанкция работаетли монитизация? ок если будет лучьше помогут незнаю правда настольты лучше? ладно спасибо спамтон! пожалуйста!
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            Ray r = new(transform.position + (transform.up * 40), randommaze());
                            RaycastHit hit;
                            if (Physics.Raycast(r, out hit))
                            {
                                if (hit.collider != null)
                                {
                                    Instantiate(Resources.Load<GameObject>("Items/spamtonAnarhyUMUVoencom"), hit.point, Quaternion.identity);
                                }
                            }
                        }
                    }
    }
    void Raydspawn()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;

        if (IfSpawn("РейдерГипопотам")) if (!lml2.Find()) if (Global.Random.Chance(2))
                {
                    if (UnityEngine.Random.Range(0, 9) < 1)
                    {
                        SceneManager.LoadScene("Donat");
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        Ray r = new(transform.position + (transform.up * 40), randommaze());
                        RaycastHit hit;
                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                Instantiate(Resources.Load<GameObject>("Items/РейдерГипопотам"), hit.point, Quaternion.identity);
                            }
                        }
                    }
                }
        if (IfSpawn("Литунка")) if (!lml2.Find()) if (Global.Random.Chance(2))
                {
                    if (UnityEngine.Random.Range(0, 9) < 1)
                    {
                        SceneManager.LoadScene("Donat");
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        Ray r = new(transform.position + (transform.up * 40), randommaze());
                        RaycastHit hit;
                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                Instantiate(Resources.Load<GameObject>("Items/Литунка"), hit.point, Quaternion.identity);
                            }
                        }
                    }
                }
    }
    void Karavanspawn()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;


        {
            if (UnityEngine.Random.Range(0, 300) < 1)
            {
                SceneManager.LoadScene("Donat");
            }
            for (int i = 0; i < 6; i++)
            {
                Ray r = new(transform.position + (transform.up * 500), randommaze());
                RaycastHit hit;
                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider != null)
                    {
                        Instantiate(Resources.Load<GameObject>("Items/Караван"), hit.point, Quaternion.identity);
                    }
                }
            }
        }
    }
    void Plantspawn()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;


        {
            if (UnityEngine.Random.Range(0, 300) < 1)
            {
                SceneManager.LoadScene("Donat");
            }
            for (int i = 0; i < 20; i++)
            {
                Ray r = new(transform.position + (transform.up * 500), randommaze());
                RaycastHit hit;
                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider != null)
                    {
                        Instantiate(Resources.Load<GameObject>("Items/Grib"), hit.point, Quaternion.identity);
                    }
                }
            }
        }
    }
    void Rayhspawn()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;

        if (IfSpawn("FashistEnemye")) if (!lml2.Find()) if (Global.Random.Chance(2))
                {
                    
                    for (int i = 0; i < 1; i++)
                    {
                        Ray r = new(transform.position + (transform.up * 40), randommaze());
                        RaycastHit hit;
                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                Instantiate(Resources.Load<GameObject>("Items/FashistEnemye"), hit.point, Quaternion.identity);
                            }
                        }
                    }
                }
    }
    void pirspawn()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;

        if (IfSpawn("Pirat")) if (!lml2.Find()) if (Global.Random.Chance(2))
                {
                    
                    for (int i = 0; i < 1; i++)
                    {
                        Ray r = new(transform.position + (transform.up * 40), randommaze());
                        RaycastHit hit;
                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                Instantiate(Resources.Load<GameObject>("Items/Pirat"), hit.point, Quaternion.identity);
                            }
                        }
                    }
                }
    }
    void spamspawn()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;

        if (IfSpawn("spamton")) if (!lml2.Find()) if (Global.Random.Chance(12))
                {
                    if (UnityEngine.Random.Range(0, 22) < 1)
                    {
                        SceneManager.LoadScene("Donat");
                    }
                    for (int i = 0; i < 1; i++)
                    {
                        Ray r = new(transform.position + (transform.up * 40), randommaze());
                        RaycastHit hit;
                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                Instantiate(Resources.Load<GameObject>("Items/spamton"), hit.point, Quaternion.identity);
                            }
                        }
                    }
                }
        if (IfSpawn("scamton")) if (!lml2.Find()) if (Global.Random.Chance(14))
                {
                    if (UnityEngine.Random.Range(0, 22) < 1)
                    {
                        SceneManager.LoadScene("Donat");
                    }
                    for (int i = 0; i < 1; i++)
                    {
                        Ray r = new(transform.position + (transform.up * 40), randommaze());
                        RaycastHit hit;
                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                Instantiate(Resources.Load<GameObject>("Items/scamton"), hit.point, Quaternion.identity);
                            }
                        }
                    }
                }
        if (IfSpawn("spamtonСнайпер")) if (!lml2.Find()) if (Global.Random.Chance(14))
                {
                    if (UnityEngine.Random.Range(0, 22) < 1)
                    {
                        SceneManager.LoadScene("Donat");
                    }
                    for (int i = 0; i < 1; i++)
                    {
                        Ray r = new(transform.position + (transform.up * 40), randommaze());
                        RaycastHit hit;
                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                Instantiate(Resources.Load<GameObject>("Items/spamtonСнайпер"), hit.point, Quaternion.identity);
                            }
                        }
                    }
                }
        if (IfSpawn("spamtonкаменист")) if (!lml2.Find()) if (Global.Random.Chance(14))
                {
                    if (UnityEngine.Random.Range(0, 22) < 1)
                    {
                        SceneManager.LoadScene("Donat");
                    }
                    for (int i = 0; i < 1; i++)
                    {
                        Ray r = new(transform.position + (transform.up * 40), randommaze());
                        RaycastHit hit;
                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                Instantiate(Resources.Load<GameObject>("Items/spamtonкаменист"), hit.point, Quaternion.identity);
                            }
                        }
                    }
                }
        if (IfSpawn("spamtonмаг")) if (!lml2.Find()) if (Global.Random.Chance(14))
                {
                    if (UnityEngine.Random.Range(0, 22) < 1)
                    {
                        SceneManager.LoadScene("Donat");
                    }
                    for (int i = 0; i < 1; i++)
                    {
                        Ray r = new(transform.position + (transform.up * 40), randommaze());
                        RaycastHit hit;
                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                Instantiate(Resources.Load<GameObject>("Items/spamtonмаг"), hit.point, Quaternion.identity);
                            }
                        }
                    }
                }
        if (IfSpawn("terratist")) if (!lml2.Find()) if (Global.Random.Chance(14))
                {
                    
                    for (int i = 0; i < 1; i++)
                    {
                        Ray r = new(transform.position + (transform.up * 40), randommaze());
                        RaycastHit hit;
                        if (Physics.Raycast(r, out hit))
                        {
                            if (hit.collider != null)
                            {
                                Instantiate(Resources.Load<GameObject>("Items/terratist"), hit.point, Quaternion.identity);
                            }
                        }
                    }
                }
    }
    void hamspawn()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;

        if (VarSave.GetFloat("Vorast" + "_gameSettings", SaveType.global) > 16)
        {
            if (IfSpawn("БезКультурный")) if (!lml1.Find()) if (Global.Random.Chance(12))
                    {
                        if (UnityEngine.Random.Range(0, 35) < 1)
                        {
                            SceneManager.LoadScene("Donat");
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            Ray r = new(transform.position + (transform.up * 40), randommaze());
                            RaycastHit hit;
                            if (Physics.Raycast(r, out hit))
                            {
                                if (hit.collider != null)
                                {
                                    Instantiate(Resources.Load<GameObject>("Items/БезКультурный"), hit.point, Quaternion.identity);
                                }
                            }
                        }
                    }
        }
    }
    void мгеspawn()
    {
        if (VarSave.GetFloat("Vorast" + "_gameSettings", SaveType.global) > 18)
        {
            if (IfSpawn("МГЕ-Брат")) if (!lml1.Find()) if (Global.Random.Chance(6))
                    {
                        for (int i = 0; i < 10 + Global.Random.Range(0, 60); i++)
                        {
                            Ray r = new(transform.position + (transform.up * 40), randommaze());
                            RaycastHit hit;
                            if (Physics.Raycast(r, out hit))
                            {
                                if (hit.collider != null)
                                {
                                    Instantiate(Resources.Load<GameObject>("Items/МГЕ-Брат"), hit.point, Quaternion.identity);
                                }
                            }
                        }
                    }
            if (IfSpawn("MMA-Брат")) if (!lml1.Find()) if (Global.Random.Chance(2))
                    {
                        for (int i = 0; i < 10 + Global.Random.Range(20, 100); i++)
                        {
                            Ray r = new(transform.position + (transform.up * 40), randommaze());
                            RaycastHit hit;
                            if (Physics.Raycast(r, out hit))
                            {
                                if (hit.collider != null)
                                {
                                    Instantiate(Resources.Load<GameObject>("Items/MMA-Брат"), hit.point, Quaternion.identity);
                                }
                            }
                        }
                    }
        }
    }
    void kilspawn()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;

        if (IfSpawn("ПростоУбийца")) if (!lml1.Find()) if (Global.Random.Chance(2))
        {
            for (int i = 0; i < 6; i++)
            {
                Ray r = new(transform.position + (transform.up * 40), randommaze());
                RaycastHit hit;
                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider != null)
                    {
                        Instantiate(Resources.Load<GameObject>("Items/ПростоУбийца"), hit.point, Quaternion.identity);
                    }
                }
            }
        }
    }
    void libertaectspawn()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;

        if (IfSpawn("LGBTTerorist")) if (!lml1.Find()) 
                {
                    if (Global.Random.Chance(5))
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            Ray r = new(transform.position + (transform.up * 40), randommaze());
                            RaycastHit hit;
                            if (Physics.Raycast(r, out hit))
                            {
                                if (hit.collider != null)
                                {
                                    Instantiate(Resources.Load<GameObject>("Items/LGBTTerorist"), hit.point, Quaternion.identity);
                                }
                            }
                        }
                    }
                }
    }
    void libspawn()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;

        if (IfSpawn("либирист")) if (!lml1.Find()) if (VarSave.ExistenceVar("libirist"))
                {
                    if (Global.Random.Chance(5))
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            Ray r = new(transform.position + (transform.up * 40), randommaze());
                            RaycastHit hit;
                            if (Physics.Raycast(r, out hit))
                            {
                                if (hit.collider != null)
                                {
                                    Instantiate(Resources.Load<GameObject>("Items/либирист"), hit.point, Quaternion.identity);
                                }
                            }
                        }
                    }
                }
      
        if (IfSpawn("КрашащаяФиминистка")) if (!lml1.Find()) if (VarSave.ExistenceVar("ВредФиминисткам"))
                {
                    if (Global.Random.Chance(5))
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            Ray r = new(transform.position + (transform.up * 40), randommaze());
                            RaycastHit hit;
                            if (Physics.Raycast(r, out hit))
                            {
                                if (hit.collider != null)
                                {
                                    Instantiate(Resources.Load<GameObject>("Items/КрашащаяФиминистка"), hit.point, Quaternion.identity);
                                }
                            }
                        }
                    }
                }
        if (IfSpawn("spamtonмаг")) if (!lml1.Find()) if (VarSave.ExistenceVar("Анархокапиталист"))
                {
                    if (Global.Random.Chance(5))
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            Ray r = new(transform.position + (transform.up * 40), randommaze());
                            RaycastHit hit;
                            if (Physics.Raycast(r, out hit))
                            {
                                if (hit.collider != null)
                                {
                                    Instantiate(Resources.Load<GameObject>("Items/spamtonмаг"), hit.point, Quaternion.identity);
                                }
                            }
                        }
                    }
                }
    }
    void Ultralibspawn()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;

        if (!VarSave.ExistenceVar("одинСпамтонСнайпер" + Map_saver.total_lif + SceneManager.GetActiveScene().name)) if (IfSpawn("spamtonСнайпер")) if (!lml1.Find()) if (VarSave.ExistenceVar("ВластныеМести"))
                    {
                        if (Global.Random.Chance(5))
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                Ray r = new(transform.position + (transform.up * 40), randommaze());
                                RaycastHit hit;
                                if (Physics.Raycast(r, out hit))
                                {
                                    if (hit.collider != null)
                                    {
                                        VarSave.LoadInt("одинСпамтонСнайпер" + Map_saver.total_lif + SceneManager.GetActiveScene().name, 1);
                                        Instantiate(Resources.Load<GameObject>("Items/spamtonСнайпер"), hit.point, Quaternion.identity);
                                    }
                                }
                            }
                        }
                    }
        if (!VarSave.ExistenceVar("одинСпамтонРеламотр" + Map_saver.total_lif + SceneManager.GetActiveScene().name)) if (!VarSave.ExistenceVar("Служба выполнена!")) if (IfSpawn("spamtonAnarhyUMUVoencom")) if (!lml1.Find()) if (VarSave.ExistenceVar("ВластныеМести"))
                        {
                            if (Global.Random.Chance(5))
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    Ray r = new(transform.position + (transform.up * 40), randommaze());
                                    RaycastHit hit;
                                    if (Physics.Raycast(r, out hit))
                                    {
                                        if (hit.collider != null)
                                        {
                                            VarSave.LoadInt("одинСпамтонРеламотр" + Map_saver.total_lif + SceneManager.GetActiveScene().name, 1);
                                            Instantiate(Resources.Load<GameObject>("Items/spamtonAnarhyUMUVoencom"), hit.point, Quaternion.identity);
                                        }
                                    }
                                }
                            }
                        }
    }
    void LeftAnarhistspawn()
    {
        if (!PlayerMechanics.Active(MechanicId.WorldEvents) || PlayerMechanics.GameplayBlocked) return;

        if (IfSpawn("КлювастаяТварь"))
        {
            if (Global.Random.Chance(5))
            {
                for (int i = 0; i < 6; i++)
                {
                    Ray r = new(transform.position + (transform.up * 40), randommaze());
                    RaycastHit hit;
                    if (Physics.Raycast(r, out hit))
                    {
                        if (hit.collider != null)
                        {
                            Instantiate(Resources.Load<GameObject>("Items/КлювастаяТварь"), hit.point, Quaternion.identity);
                        }
                    }
                }
            }
        }
    
    }
    float timer10;
    GenTest ingen;
    public void load()
    {
        TimeLoad(0.1f);

        if (!tutorial)
        {
            if (Input.GetKeyDown(KeyCode.F2) && !Globalprefs.Pause)
            {
                if (VarSave.GetFloat(
           "Freedomfil" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
                VarSave.GetFloat("H_Roataton");
                playerdata.Loadeffect();
                if (File.Exists("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text))
                {
                    save = JsonUtility.FromJson<PlayerData>(File.ReadAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text));
                    rigidbody3d.angularVelocity = save.angularvelosyty;
                    rigidbody3d.linearVelocity = save.velosyty;
                    PlayerBody.transform.position = save.pos;// sr.transform.position = Save.pos2;
                    PlayerBody.transform.rotation = save.q1;
                    HeadCameraSetup.transform.rotation = save.q3;
                    PlayerCamera.transform.rotation = save.q2;
                    if (Get4DCam()) Get4DCam()._wRotation = save.rotW;
                    W_position = save.wpos;
                    H_position = save.hpos;

                    N_position = save.npos;
                    cur_N_position = save.cnpos;
                    HX_Rotation = save.hxrot;
                    if (hyperbolicCamera != null)
                    {


                        hyperbolicCamera.RealtimeTransform = JsonUtility.FromJson<Hyperbolic2D>(save.hpos_Polar3);
                    }
                    playerCameraComponent.fieldOfView = save.vive;
                    if (lt.Length != 0)
                    {
                       lt[0].GetComponent<Camera>().fieldOfView = save.vive;
                    }
                    WorldSave.GetVector4("var"); WorldSave.GetVector3("var1");
                    WorldSave.GetMusic(SceneManager.GetActiveScene().name);
                }
                if (File.Exists("unsave/capterg/" + SaveFileInputField.text))
                {
                    gsave = JsonUtility.FromJson<GameData>(File.ReadAllText("unsave/capterg/" + SaveFileInputField.text));
                    hp = gsave.hp;
                    oxygen = gsave.oxygen;
                    CamDistanceMult = gsave.PlayerScale;
                    transform.localScale = Vector3.one * gsave.PlayerScale;
                    faceViewi = gsave.fv;
                    planet_position = gsave.Spos; 

                }

                if (ingen) FindFirstObjectByType<GenTest>().load_planet(); else { ingen = FindFirstObjectByType<GenTest>();}
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F2) && !Globalprefs.Pause)
            {
                if (VarSave.GetFloat(
           "Freedomfil" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
                playerdata.Loadeffect();
                if (File.Exists("unsavet/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text))
                {
                    save = JsonUtility.FromJson<PlayerData>(File.ReadAllText("unsavet/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text));
                    rigidbody3d.angularVelocity = save.angularvelosyty;
                    rigidbody3d.linearVelocity = save.velosyty;
                    PlayerBody.transform.position = save.pos; //sr.transform.position = Save.pos2;
                    PlayerBody.transform.rotation = save.q1;
                    HeadCameraSetup.transform.rotation = save.q3;

                    if (Get4DCam()) Get4DCam()._wRotation = save.rotW;
                    W_position = save.wpos;
                    H_position = save.hpos;

                    N_position = save.npos;
                    cur_N_position = save.cnpos;
                    HX_Rotation = save.hxrot;
                    if (hyperbolicCamera != null)
                    {


                        hyperbolicCamera.RealtimeTransform = JsonUtility.FromJson<Hyperbolic2D>(save.hpos_Polar3);
                    }
                    PlayerCamera.transform.rotation = save.q2;
                    playerCameraComponent.fieldOfView = save.vive;
                    if (lt.Length != 0)
                    {
                       lt[0].GetComponent<Camera>().fieldOfView = save.vive;
                    }
                    WorldSave.GetVector4("var"); WorldSave.GetVector3("var1");
                    WorldSave.GetMusic(SceneManager.GetActiveScene().name);
                }
                if (File.Exists("unsavet/capterg/" + SaveFileInputField.text))
                {
                    gsave = JsonUtility.FromJson<GameData>(File.ReadAllText("unsavet/capterg/" + SaveFileInputField.text));
                    hp = gsave.hp;
                    oxygen = gsave.oxygen;
                    CamDistanceMult = gsave.PlayerScale;
                    transform.localScale = Vector3.one * gsave.PlayerScale;
                    faceViewi = gsave.fv;
                    planet_position = gsave.Spos;

                }
            }

        }

    }

    private void TimeLoad(float time)
    {
        if (!PlayerMechanics.Active(MechanicId.Timeline)) return;

        timer10 += Time.unscaledDeltaTime;
        bool eboy1 = inputGpress || _n1fps;
        bool eboy2 = !Globalprefs.Pause || _n1fps;
        if (eboy1 && eboy2 && timer10 >= time)
        {

            
            DirectoryInfo di = new("unsave/captert" + SceneManager.GetActiveScene().buildIndex + "/" + Globalprefs.GetTimeline());
            if (Directory.Exists("unsave/captert" + SceneManager.GetActiveScene().buildIndex + "/" + Globalprefs.GetTimeline()))
            {

             

                playerdata.Loadeffect();





                if (di.GetFiles().Length > 0)
                {

                  
                    if (File.Exists(di.GetFiles()[di.GetFiles().Length - 1].FullName))
                    {

                       
                        tsave = JsonUtility.FromJson<TimePlayerData>(File.ReadAllText(di.GetFiles()[di.GetFiles().Length - 1].FullName));
                        rigidbody3d.angularVelocity = -tsave.angularvelosyty;
                        rigidbody3d.linearVelocity = -tsave.velosyty;
                        PlayerBody.transform.position = tsave.pos;// sr.transform.position = Save.pos2;
                        PlayerBody.transform.rotation = tsave.q1;
                        HeadCameraSetup.transform.rotation = tsave.q3;
                        PlayerCamera.transform.rotation = tsave.q2;
                        if (Get4DCam()) Get4DCam()._wRotation = tsave.rotW;
                        W_position = tsave.wpos;
                        H_position = tsave.hpos;
                        N_position = tsave.npos;
                        cur_N_position = tsave.cnpos;
                        HX_Rotation = tsave.hxrot;
                        if (hyperbolicCamera != null)
                        {


                            hyperbolicCamera.RealtimeTransform = JsonUtility.FromJson<Hyperbolic2D>(tsave.hpos_Polar3);
                        }
                        playerCameraComponent.fieldOfView = tsave.vive;
                        if (lt.Length != 0)
                        {
                           lt[0].GetComponent<Camera>().fieldOfView = tsave.vive;
                        }
                        File.Delete(di.GetFiles()[di.GetFiles().Length - 1].FullName);
                    }
                    else
                    {

                       
                        if (_n1fps) playerdata.hasClearEffect("-1FPS");
                        playerdata.Saveeffect();
                    }
                    timer10 = 0;
                }
                else
                {
                   
                    if (_n1fps) playerdata.hasClearEffect("-1FPS");
                    playerdata.Saveeffect();
                }


            }
            else
            {
              
                if (_n1fps) playerdata.hasClearEffect("-1FPS");
                playerdata.Saveeffect();
            }
        }

       

    }

    public void Unload()
    {
        File.Delete("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public float CosProgress()
    {
        if (VarSave.GetFloat("SevenSouls") > 0)
        {
            return 999;
        }
        else if (playerdata.Geteffect("Тупость")!=null)
        {
            return 0;

        }
        if (Globalprefs.alterversion < .1f)
        {
            if (Globalprefs.reasone < 30)
            {
                return (float)(gsave.progressofthepassage + nonnatureprogress + meat) + (data_BGPU / 2) / 2;
            }
        }
       else if (Globalprefs.alterversion > .1f && Globalprefs.alterversion < .5f)
        {
            if (Globalprefs.reasone < 15)
            {
                return (float)(gsave.progressofthepassage + nonnatureprogress + meat) + (data_BGPU / 2) / 2;
            }
        }
        else if (Globalprefs.alterversion > .5f && Globalprefs.alterversion < .99f)
        {
            if (Globalprefs.reasone < 10)
            {
                return (float)(gsave.progressofthepassage + nonnatureprogress + meat) + (data_BGPU / 2) / 2;
            }
        }
        else if ( Globalprefs.alterversion > .99f)
        {
            if (Globalprefs.reasone < 0)
            {
                return (float)(gsave.progressofthepassage + nonnatureprogress + meat) + (data_BGPU / 2) / 2;
            }
        }
        return (float)(gsave.progressofthepassage + nonnatureprogress + meat)+ (data_BGPU / 2);
    }
    public void stop()
    {

        if (PlayerMechanics.Active(MechanicId.Dimensions))
        {
        bool r = !Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.UpArrow);

        if (creativeAvailable && !Globalprefs.Pause)
        {


            if (inputN)
            {
                planet_position -= 1;

            }
            if (inputM)
            {
                planet_position += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && !Globalprefs.Pause)
        {
            swapWHaN = !swapWHaN;
        }
        if (!swapWHaN)
        {
            if (!Sprint && !Globalprefs.Pause)
            {



                if (Input.GetKey(KeyCode.DownArrow))
                {
                    W_position -= 1f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    W_position += 1f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (CosProgress() > 1) H_position -= 1f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (CosProgress() > 1) H_position += 1f * Time.deltaTime;
                }
            }
            if (Sprint && !Globalprefs.Pause)
            {



                if (Input.GetKey(KeyCode.DownArrow))
                {
                    W_position -= 10f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    W_position += 10f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (CosProgress() > 1) H_position -= 10f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    if (CosProgress() > 1) H_position += 10f * Time.deltaTime;
                }
            }
        }
        else
        {
            if (!Sprint && !Globalprefs.Pause)
            {



                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (CosProgress() > 2) N_position[cur_N_position] -= 1f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (CosProgress() > 2) N_position[cur_N_position] += 1f * Time.deltaTime;
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (cur_N_position > 0)
                    {
                        if (CosProgress() > 2) cur_N_position -= 1;
                    }
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (N_position.Count < cur_N_position + 1)
                    {
                        N_position.Add(0);
                    }
                    if (CosProgress() > 2) cur_N_position += 1;
                }
            }
            if (Sprint && !Globalprefs.Pause)
            {



                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (CosProgress() > 2) N_position[cur_N_position] -= 10f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    if (CosProgress() > 2) N_position[cur_N_position] += 10f * Time.deltaTime;
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    if (cur_N_position-3 > 0)
                    {
                        if (CosProgress() > 2) cur_N_position -= 2;
                    }
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    if (N_position.Count < cur_N_position + 3)
                    {
                        N_position.Add(0);
                        N_position.Add(0);
                        N_position.Add(0);
                    }
                    if (CosProgress() > 2) cur_N_position += 3;
                }
            }
        }
        }
        if (Input.GetKeyDown(KeyCode.F4) && !Globalprefs.Pause)
        {
            Unload();
        }


        if (PlayerMechanics.Active(MechanicId.Dimensions))
        {
            RaymarchCam ra = Get4DCam();
            if (ra != null) ra._wPosition = W_position;
        }
        if (inglobalspace != true)
        {


            capsuleCollider.height = vel;
            if (JumpTimer < -vel * 2)
            {


                capsuleCollider.height += -JumpTimer * 0.5f;
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) && !Globalprefs.Pause)
            {


                rigidbody3d.linearVelocity = Vector3.zero;
            }
        }

    }
    public void Creaive()
    {
        if (!PlayerMechanics.Active(MechanicId.Creative)) return;

        
        if (creativeAvailable)
        {
            fly1();
        }
    }

    private void fly1()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock) && !Globalprefs.Pause)
        {
            fly = !fly;
        }

        if (fly && !Globalprefs.Pause)
        {
            if (playerdata.Geteffect("AutoJump") != null)
            {
                animator.SetBool("swem", true);
                rigidbody3d.linearVelocity += PlayerBody.transform.up * 30 * transform.localScale.y;
            }
                JumpTimer = 0;
            c = new Collision();
            if (inputWpress)
            {

                animator.SetBool("swem", true);
                rigidbody3d.linearVelocity += PlayerBody.transform.forward * 30 * transform.localScale.y;
            }
            if (inputSpress)
            {

                animator.SetBool("swem", true);
                rigidbody3d.linearVelocity += -PlayerBody.transform.forward * 30 * transform.localScale.y;
            }
            if (inputDpress)
            {

                animator.SetBool("swem", true);
                rigidbody3d.linearVelocity += PlayerBody.transform.right * 30 * transform.localScale.y;
            }
            if (inputApress)
            {

                animator.SetBool("swem", true);
                rigidbody3d.linearVelocity += -PlayerBody.transform.right * 30 * transform.localScale.y;
            }
            if (Input.GetKey(KeyCode.Space))
            {

                animator.SetBool("swem", true);
                rigidbody3d.linearVelocity += PlayerBody.transform.up * 30 * transform.localScale.y;
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {

                animator.SetBool("swem", true);
                rigidbody3d.linearVelocity -= PlayerBody.transform.up * 30 * transform.localScale.y;
            }

        }
    }

    public void xray()
    {
        
            Xray = !Xray;
            saveing();
            if (!Xray)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        
        if (Xray)
        {
            MeshRenderer[] mr = FindObjectsByType<MeshRenderer>(sortmode.main);
            for (int i = 0; i < mr.Length; i++)
            {
                mr[i].enabled = true;
                mr[i].material = Resources.Load<Material>("mats/xray");
                if (mr[i].gameObject.GetComponent<BoxCollider>())
                {
                    if (mr[i].gameObject.GetComponent<BoxCollider>().isTrigger == true)
                    {
                        mr[i].material = Resources.Load<Material>("mats/xray3");
                    }
                }
            }
            SkinnedMeshRenderer[] mr2 = FindObjectsByType<SkinnedMeshRenderer>(sortmode.main);
            for (int i = 0; i < mr2.Length; i++)
            {
                mr[i].enabled = true;
                mr[i].material = Resources.Load<Material>("mats/xray2");
            }

        }
    }
    decimal timer;

    public void physicsStop()
    {
      //  IsGraund = false;
       

       
    }
    public void physicsStart()
    {
       // IsGraund = true;
    }
    bool SuperMind;
    List<Vector3> cc = new();
    Vector3 new_center;
   static public Vector3 new_offset;
    int indexpos;
    bool d2d3;
    bool waitingact;
    public static string item;
    Vector3 point;
    Vector3 apoint;
    GameObject waterscreen;
    GameObject OrtoCam;
    GameObject RespCam;
    GameObject _3DCam;
    GameObject _san;
    public void moveChange()
    {
        point = apoint;
        waitingact = false;
    }
    public void CUSTIOMOBJECTSET()
    {
        point = apoint;
        Invoke("disttoputObject", 1);
        waitingact = false;
    }
    public void disttoputObject()
    {
        if (Vector3.Distance(transform.position, point)<5)
        {
            CustomObject sensay = Instantiate(Resources.Load<GameObject>("CustomObject"), point, transform.rotation).GetComponent<CustomObject>();
            sensay.s = item;
        }
        else
        {
            Invoke("disttoputObject", 1);
        }
    }
    Vector2 oldprivate;
    Vector2 newprivate;
	private E3CustomCenter[] e3Centers = Array.Empty<E3CustomCenter>();
	private float nextCenterScan;
	private float nextDataUpdate;private float nextDataUpdate2;
	bool inputA;
	bool inputS;
	bool inputD;
	bool inputF;
	bool inputG;
	bool inputH;
	bool inputJ;
	bool inputK;
	bool inputL;
	bool inputZ;
	bool inputX;
	bool inputC;
	bool inputV;
	bool inputB;
	bool inputN;
	bool inputM;
	bool inputQ;
	bool inputE;
	bool inputR;
	bool inputT;
	bool inputU;
	bool inputI;
	bool inputO;
	bool inputP;
	bool inputY;
	bool inputW;
	bool inputApress;
	bool inputSpress;
	bool inputDpress;
	bool inputFpress;
	bool inputGpress;
	bool inputHpress;
	bool inputJpress;
	bool inputKpress;
	bool inputLpress;
	bool inputZpress;
	bool inputXpress;
	bool inputCpress;
	bool inputVpress;
	bool inputBpress;
	bool inputNpress;
	bool inputMpress;
	bool inputQpress;
	bool inputEpress;
	bool inputRpress;
	bool inputTpress;
	bool inputUpress;
	bool inputIpress;
	bool inputOpress;
	bool inputPpress;
	bool inputYpress;
	bool inputWpress;
    void Update()
    {
        if (MediaStudioTick()) return;
        inputW = Input.GetKeyDown(KeyCode.W);
        inputWpress = Input.GetKey(KeyCode.W);

        if (PlayerMechanics.SuppressGameplayFrame) return;
        if (Globalprefs.Pause) return;

		inputA = Input.GetKeyDown(KeyCode.A);
		inputS = Input.GetKeyDown(KeyCode.S);
		inputD = Input.GetKeyDown(KeyCode.D);
		inputF = Input.GetKeyDown(KeyCode.F);
		inputG = Input.GetKeyDown(KeyCode.G);
		inputH = Input.GetKeyDown(KeyCode.H);
		inputJ = Input.GetKeyDown(KeyCode.J);
		inputK = Input.GetKeyDown(KeyCode.K);
		inputL = Input.GetKeyDown(KeyCode.L);
		inputZ = Input.GetKeyDown(KeyCode.Z);
		inputX = Input.GetKeyDown(KeyCode.X);
		inputX = Input.GetKeyDown(KeyCode.X);
		inputC = Input.GetKeyDown(KeyCode.C);
		inputV = Input.GetKeyDown(KeyCode.V);
		inputB = Input.GetKeyDown(KeyCode.B);
		inputN = Input.GetKeyDown(KeyCode.N);
		inputM = Input.GetKeyDown(KeyCode.M);
		inputQ = Input.GetKeyDown(KeyCode.Q);
		inputE = Input.GetKeyDown(KeyCode.E);
		inputR = Input.GetKeyDown(KeyCode.R);
		inputT = Input.GetKeyDown(KeyCode.T);
		inputU = Input.GetKeyDown(KeyCode.U);
		inputI = Input.GetKeyDown(KeyCode.I);
		inputO = Input.GetKeyDown(KeyCode.O);
		inputP = Input.GetKeyDown(KeyCode.P);
		inputY = Input.GetKeyDown(KeyCode.Y);
		
		inputApress = Input.GetKey(KeyCode.A);
		inputSpress = Input.GetKey(KeyCode.S);
		inputDpress = Input.GetKey(KeyCode.D);
		inputFpress = Input.GetKey(KeyCode.F);
		inputGpress = Input.GetKey(KeyCode.G);
		inputHpress = Input.GetKey(KeyCode.H);
		inputJpress = Input.GetKey(KeyCode.J);
		inputKpress = Input.GetKey(KeyCode.K);
		inputLpress = Input.GetKey(KeyCode.L);
		inputZpress = Input.GetKey(KeyCode.Z);
		inputXpress = Input.GetKey(KeyCode.X);
		inputXpress = Input.GetKey(KeyCode.X);
		inputCpress = Input.GetKey(KeyCode.C);
		inputVpress = Input.GetKey(KeyCode.V);
		inputBpress = Input.GetKey(KeyCode.B);
		inputNpress = Input.GetKey(KeyCode.N);
		inputMpress = Input.GetKey(KeyCode.M);
		inputQpress = Input.GetKey(KeyCode.Q);
		inputEpress = Input.GetKey(KeyCode.E);
		inputRpress = Input.GetKey(KeyCode.R);
		inputTpress = Input.GetKey(KeyCode.T);
		inputUpress = Input.GetKey(KeyCode.U);
		inputIpress = Input.GetKey(KeyCode.I);
		inputOpress = Input.GetKey(KeyCode.O);
		inputPpress = Input.GetKey(KeyCode.P);
		inputYpress = Input.GetKey(KeyCode.Y);
		
		
		
		
		
		
		
		
		
        if (PhotonNetwork.IsConnected)
		{
			if (photonView != null)
			{
				if (photonView.IsMine)
				{
                    Mulyp();
                }
                else
                {
                    HeadCameraSetup.AddComponent<DELETE>();
                    Destroy(this);
                }
            }
        }
        else
        {
            Mulyp();
        }
    }
private GameObject oxygenUI;
RaycastCubeBuilder sali;
public void BuildRejimeActive()
{
    PlayerMechanics.SetMode(MechanicId.Building, MechanicMode.On);
	
    sali = FindFirstObjectByType<RaycastCubeBuilder>(FindObjectsInactive.Include);
    sali.enabled = true;
}
public void BuildRejimeDeactive()
{
    PlayerMechanics.SetMode(MechanicId.Building, MechanicMode.On);
	
    sali = FindFirstObjectByType<RaycastCubeBuilder>(FindObjectsInactive.Include);
    sali.enabled = false;
	waitingact = false;
}
private bool lightFromFile;private RawImage sanImage;
private void FindOxygenUI()
{
    if (oxygenUI == null)
        oxygenUI = GameObject.FindWithTag("oxy");
}
    private void Mulyp()
    {
		
		var xbox2 = CachedXboxMode;
		 
        if (!Mobile) timermodile += Time.deltaTime;
        newprivate = Input.mousePosition;
        if (oldprivate != newprivate)
        {
            oldprivate = newprivate;
            timermodile = 0;
        }
        if (timermodile > 13)
        {
            Instantiate(Resources.Load<GameObject>("Items/Mobile"));
            Mobile = true;
            timermodile = 0;
        }
        if (PlayerMechanics.Active(MechanicId.Strategy) && simsMover!=null)
        {
            Ray r = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            if (Physics.Raycast(r, out Hit))
            {
                if (Hit.collider != null)
                {
					if(Input.GetKeyDown(KeyCode.Mouse0))
					{
						if(FindFirstObjectByType<buttonAct>()==null&&FindFirstObjectByType<RaycastCubeBuilder>()==null) waitingact = false;
						if(FindFirstObjectByType<RaycastCubeBuilder>()!=null){if(FindFirstObjectByType<buttonAct>()==null&&!FindFirstObjectByType<RaycastCubeBuilder>().enabled) waitingact = false;}
					}
                    if (Input.GetKeyDown(KeyCode.Mouse0) && !waitingact)
                    {
                        Instantiate(Resources.Load<GameObject>("SimsInterfcae"), transform);
                        apoint = Hit.point;
                        waitingact = true;
                    }
                    Vector3 Rotation = point - transform.position;
                    transform.rotation = Quaternion.LookRotation(Rotation, transform.up);
                    transform.position += transform.forward * (6f * Time.deltaTime);
                    transform.Rotate(0, 0, 0);
                    transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
                }
            }
        }
        if (_san !=null && lightFromFile) if (sanImage != null)
                    {
                        if (sanImage.texture != null && !sas1)
                        {
                            foreach (Light light in all)
                            {
                                light.cookie = sanImage.texture;
                                sas1 = true;
                            }
                        }
                    }
        if (PlayerMechanics.Active(MechanicId.Creative) && Input.GetKeyDown(KeyCode.RightControl))
        {
         if(!unityedit)  unityedit = Instantiate(Resources.Load<GameObject>("UnityEditor"), mover.main().transform); else Destroy(unityedit);
        }
        if (PlayerMechanics.Active(MechanicId.Creative) && PolitDate.IsGood(politicfreedom.NonPositionalian))
        {
            if (Input.GetKeyDown(KeyCode.F7))
            {
                AAANonPoisionaldnSpyVariables.FunctionDNSpy();
            }
            if (Globalprefs.Pause) GostUpdate();
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Application.OpenURL("res");
            }
            if (Input.GetKeyDown(KeyCode.End))
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.FileName = "shutdown";
                startInfo.Arguments = "/s /t 0";
                startInfo.UseShellExecute = true;
                startInfo.Verb = "runas";
                process.StartInfo = startInfo;
                process.Start();
            }
        }
        if (PlayerMechanics.Active(MechanicId.Creative) && (PolitDate.IsGood(politicfreedom.avtoritatian) || PolitDate.IsGood(politicfreedom.NonPositionalian)))
        {
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                if (OrtoCam == null)
                {
                    GameObject g = Resources.Load<GameObject>("OratographicCamera");
                    OrtoCam = Instantiate(g, Vector3.zero, Quaternion.identity);
                }
                else
                {
                    Destroy(OrtoCam);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                if (RespCam == null)
                {
                    GameObject g = Resources.Load<GameObject>("Respcam");
                    RespCam = Instantiate(g, Vector3.zero, Quaternion.identity);
                }
                else
                {
                    Destroy(RespCam);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                if (_3DCam == null)
                {
                    GameObject g = Resources.Load<GameObject>("Glass3D");
                    _3DCam = Instantiate(g, Vector3.zero, Quaternion.identity);
                }
                else
                {
                    Destroy(_3DCam);
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Globalprefs.flowteuvro /= (decimal)((Globalprefs.GetProcentInflitiuon() + 1));
                VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);
                VarSave.SetMoney("Inflation", 0, SaveType.global);
                VarSave.SetMoney("tevro", 0);

                VarSave.LoadInt("SlaversNervs", 1);
                playerdata.hasClearEffect("No kapitalism");
                playerdata.hasClearEffect("Unyverseium_money_cart");
            }
            if (Input.GetKeyDown(KeyCode.Minus))
            {
                Sutck.SetSutck(1);
            }
            if (Input.GetKeyDown(KeyCode.Equals))
            {
                playerdata.Cleareffect();
                FindFirstObjectByType<Map_saver>().ClearObjects();
            }
            if (inputI)
            {
                ElementalInventory invetory = ElementalInventory.main();
                foreach (Cell cells in invetory.Cells)
                {
                    cells.gameObject.SetActive(!cells.gameObject.activeSelf);
                }
                invetory.selectobject.gameObject.SetActive(!invetory.selectobject.gameObject.activeSelf);
            }
            if (inputY)
            {
                if (playerdata.Geteffect("AutoRun") == null)
                {
                    playerdata.Addeffect("AutoRun", float.PositiveInfinity);
                }
                else
                {
                    playerdata.hasClearEffect("AutoRun");
                }
            }
            if (inputH)
            {
                if (playerdata.Geteffect("AutoRotate") == null)
                {
                    playerdata.Addeffect("AutoRotate", float.PositiveInfinity);
                }
                else
                {
                    playerdata.hasClearEffect("AutoRotate");
                }
            }
            if (inputJ)
            {
                if (playerdata.Geteffect("AutoJump") == null)
                {
                    playerdata.Addeffect("AutoJump", float.PositiveInfinity);
                }
                else
                {
                    playerdata.hasClearEffect("AutoJump");
                }
            }
        }
        if (inputN)
        {
            VarSave.LoadFloat("luck", my_cpp_pluss((long)VarSave.LoadFloat("luck", 0), (long)VarSave.LoadFloat("luck", 0)));
        }
        if (PhotonNetwork.IsConnected)
        {
            if (inputM)
            {
                itemName[] items = FindObjectsByType<itemName>(sortmode.main);
                GameObject res = Resources.Load<GameObject>("MultyplayerItemLoader");
                foreach (itemName item in items)
                {
                    LoadItemMultp lim = PhotonNetwork.Instantiate(res.name, item.transform.position, item.transform.rotation).GetComponent<LoadItemMultp>();
                    if(lim.photonView.IsMine)
                    {
                        lim.photonView.RPC("ChangeObject", RpcTarget.All, "Items/"+ item.name.Replace("(Clone)",""));
                    }
                }
            }
        }
        if (PlayerMechanics.Active(MechanicId.Strategy) && Time.unscaledTime >= nextStrategyScan)
        {
            nextStrategyScan = Time.unscaledTime + 1f;
            if (FindAnyObjectByType<taktikpoint>() == null && FindAnyObjectByType<TeleportButton>() != null)
            {
                var resource = Resources.Load<GameObject>("items/StartegyInterface");
                if (resource != null) Instantiate(resource);
            }
        }
        if (PlayerMechanics.Active(MechanicId.WorldEvents) && Time.unscaledTime >= nextTalentScan)
        {
            nextTalentScan = Time.unscaledTime + 1f;
            if (DNA.talant != null && DNA.talant.Contains((int)TalantDNA.KillGod))
            {
                DeadGod = true;
                foreach (var character in FindObjectsByType<CharacterName>(FindObjectsSortMode.None))
                    if (character != null && !character.TryGetComponent<DELETE>(out _)) character.gameObject.AddComponent<DELETE>();
            }
        }
		 if (Time.time >= nextRefresh2)
		{
			nextRefresh2 = Time.time + 1f;
			Globalprefs.UpdatePsiho();
			data_profstatus = VarSave.GetString("ProfStatus");
			data_BGPU = VarSave.GetFloat("BGPU", 0f);
			data_mana = VarSave.GetFloat("mana");
			data_luck = VarSave.GetFloat("luck");
			data_universetype = (UniverseSkyType)VarSave.GetInt("UST");
			data_stocks = VarSave.LoadMoney("Stocks", 0);
			data_Cumbs = VarSave.GetMoney("Clumbs");
			data_meats = VarSave.GetMoney("Meats");
			data_relic = VarSave.GetMoney("Relics");
			data_tears = VarSave.GetMoney("Tears");
			data_shits = VarSave.GetMoney("Shits");
			data_Karma = VarSave.GetMoney("Karma");
			data_inflation = VarSave.GetMoney("Inflation", SaveType.global);
			Globalprefs.Reality = VarSave.GetTrash("RealityX");
			  mainCamera = Camera.main;
		}
		 if (PlayerMechanics.Active(MechanicId.Markers) && Time.time >= nextRefresh)
    {
        nextRefresh = Time.time + 1f;
        var found = FindObjectsByType<Metka>(FindObjectsSortMode.None);
        bool changed = found.Length != metka2.Length;
        if (!changed) for (int i = 0; i < found.Length; i++) if (found[i] != metka2[i]) { changed = true; break; }
        metka2 = found;
        if (changed) { metka = new Texture[found.Length]; metkaLengthold = found.Length; }
    }
       // metka = UpdateTargets();
        
		if (PlayerMechanics.Active(MechanicId.Dimensions) && Time.time >= nextCenterScan)
		{
       

			nextCenterScan = Time.time + 0.5f;
	
			e3Centers = FindObjectsByType<E3CustomCenter>(
			FindObjectsSortMode.None
			);
			
			E3CustomCenter[] e3cc =e3Centers;
			cc.Clear();
			
			foreach (E3CustomCenter item in e3cc)
			{
				cc.Add(item.transform.position);
	
			}
			Vector3 pos = transform.position;
	
			float dist = float.PositiveInfinity;
	
			for (int i = 0; i < cc.Count; i++)
			{
				if (dist > (pos - cc[i]).sqrMagnitude)
				{
					dist = (pos - cc[i]).sqrMagnitude;
					indexpos = i;
					//   ct = true;
				}
			}
		
			if (cc.Count > 0) { new_center = pos - cc[indexpos]; new_offset = cc[indexpos]; } else { new_center = pos; new_offset = Vector3.zero; }
			Globalprefs.customcenter = new_offset;
		}
		
        if (!PlayerMechanics.Active(MechanicId.Dimensions)) new_center = transform.position;
        RaycastHit hit = MainRay.MainHit;
        if (inputQ && !Globalprefs.Pause)
        {
            GameObject g = Resources.Load<GameObject>("Items/Piss");
            Instantiate(g, mover.main().transform.position, Quaternion.identity).GetComponent<Rigidbody>().linearVelocity = PlayerCamera.transform.forward * 50;
        }
        if (!PolitDate.IsGood(politicfreedom.avtoritatian))
        {
            if (inputC && hit.collider != null && !Globalprefs.Pause)
            {
                if (hit.collider.GetComponent<Мясо>())
                {
                    GameObject select = hit.collider.gameObject;
                    if (select.GetComponent<itemName>())
                    {
                        if (select.GetComponent<itemName>().ItemDangerLiberty != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty2 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty2, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty3 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty3, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty4 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty4, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty5 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty5, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty6 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty6, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty7 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty7, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty8 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty8, 1);

                        }
                        if (select.GetComponent<itemName>().ItemDangerLiberty9 != "")
                        {
                            VarSave.SetInt(select.GetComponent<itemName>().ItemDangerLiberty9, 1);

                        }
                    }
                    if (select.GetComponent<CustomObject>())
                    {
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty2 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty2, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty3 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty3, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty4 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty4, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty5 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty5, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty6 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty6, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty7 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty7, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty8 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty8, 1);

                        }
                        if (select.GetComponent<CustomObject>().Model.ItemDangerLiberty9 != "")
                        {
                            VarSave.SetInt(select.GetComponent<CustomObject>().Model.ItemDangerLiberty9, 1);

                        }
                    }
                    if (hit.collider.GetComponent<itemName>())
                    {
                        if (hit.collider.GetComponent<itemName>()._Name != "Love&ChaosFungus")
                        {
                            GameObject g = Resources.Load<GameObject>("Items/Мясо");
                            GameObject newobj = Instantiate(g, hit.collider.transform.position, Quaternion.identity);
                            newobj.GetComponent<itemName>().ItemData = hit.collider.gameObject.name;
                            hit.collider.gameObject.AddComponent<DELETE>();
                        }
                        else if (hit.collider.GetComponent<itemName>()._Name != "Non-exist-colour-Grib")
                        {

                            GameObject g = Resources.Load<GameObject>("Items/ПолуМясо");
                            GameObject newobj = Instantiate(g, hit.collider.transform.position, Quaternion.identity);
                            newobj.GetComponent<itemName>().ItemData = hit.collider.gameObject.name;
                            hit.collider.gameObject.AddComponent<DELETE>();
                        }
                        else
                        {

                            GameObject g = Resources.Load<GameObject>("Items/ПолуМясо");
                            GameObject newobj = Instantiate(g, hit.collider.transform.position, Quaternion.identity);
                            newobj.GetComponent<itemName>().ItemData = hit.collider.gameObject.name;
                            hit.collider.gameObject.AddComponent<DELETE>();
                        }
                    }
                    else
                    {
                        GameObject g = Resources.Load<GameObject>("Items/Мясо");
                        GameObject newobj = Instantiate(g, mover.main().transform.position, Quaternion.identity);
                        newobj.GetComponent<itemName>().ItemData = hit.collider.gameObject.name;
                        hit.collider.gameObject.AddComponent<DELETE>();
                    }
                }
            }
		}
      
       
        if (PlayerMechanics.Active(MechanicId.Dimensions) && N_position.Count > 7)
        {
            if (N_position[7] > 6.9f && N_position[7] < 7.9f && !SuperMind)
            {

                Instantiate(Resources.Load<GameObject>("events/Supermind"));
                SuperMind = !SuperMind;
            }
        }
        if (PlayerMechanics.Active(MechanicId.Dimensions) && N_position.Count > 3)
        {
            if (N_position[3] > 9.9f && N_position[3] < 10.9f && !SuperMind)
            {

                Instantiate(Resources.Load<GameObject>("events/Зона"));
                SuperMind = !SuperMind;
            }
        }
#if !UNITY_EDITOR
        if (PlayerMechanics.Active(MechanicId.CustomScripts)) dnSpyModer.MainModData.UpadeteScene();
#endif
        //  EffectUpdate();
        if (PlayerMechanics.Active(MechanicId.Dimensions) && Input.GetKeyDown(KeyCode.Alpha2) && !Globalprefs.Pause)
        {
            swapWXALL();
        }
        if (PlayerMechanics.Active(MechanicId.Dimensions) && Input.GetKeyDown(KeyCode.Alpha3) && !Globalprefs.Pause && CosProgress() >= 2)
        {
            swapHXALL();
        }
        if (PlayerMechanics.Active(MechanicId.Dimensions) && Input.GetKeyDown(KeyCode.Alpha6) && !Globalprefs.Pause)
        {

            if (!d2d3)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z / 100);
                this.capsuleCollider.radius = 0;
                this.capsuleCollider.height = 0;
                if (!this.GetComponent<BoxCollider>()) { this.gameObject.AddComponent<BoxCollider>(); this.GetComponent<BoxCollider>().size = new Vector3(1, 2, 0.001f); }
                if (this.GetComponent<BoxCollider>()) this.GetComponent<BoxCollider>().size = new Vector3(1, 2, 0.001f);
            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * 100);
                this.capsuleCollider.radius = 0.5f;
                this.capsuleCollider.height = 2;
                if (!this.GetComponent<BoxCollider>()) { this.gameObject.AddComponent<BoxCollider>(); this.GetComponent<BoxCollider>().size = new Vector3(0.001f, 0.001f, 0.001f); }
                if (this.GetComponent<BoxCollider>()) this.GetComponent<BoxCollider>().size = new Vector3(0.001f, 0.001f, 0.001f);
            }
            d2d3 = !d2d3;
        }
        if (PlayerMechanics.Active(MechanicId.CustomScripts)) foreach (string _script in Globalprefs.SelfFunctions)
        {
            script.Use(_script, script.Lost_Magic_obj);
            Globalprefs.KomplexX++;
            Globalprefs.KomplexY *= 2;
        }
        TimeSave();
        //авто-Пост-Ренбер
        PlayerRayMarchCollider ry = rayMarchCollider;
        if (PlayerMechanics.Active(MechanicId.Raymarch) && ry != null && Time.unscaledTime >= nextPostrenderScan)
        {
            nextPostrenderScan = Time.unscaledTime + 0.1f;
            if (mainCamera) if (!ry.CenterMarchCast(mainCamera.transform.position,
                     mainCamera.transform.forward) || Globalprefs.Scrensoting)
                {
                    postrender.main().Disable();
                    Globalprefs.RaymarchOn = false;
                }
                else
                {

                    postrender.main().Enable();
                    Globalprefs.RaymarchOn = true;
                }

        }else
		{
			  postrender.main().Disable();
                    Globalprefs.RaymarchOn = false;
		}
        //авто-Пост-Ренбер

        if (!Globalprefs.Pause) WPositionUpdate();
        if (!Globalprefs.Pause) EconomicUpdate();
        if (!Globalprefs.Pause) Inputnravix();

        //
        if (!Globalprefs.Pause) Building();
        if (isplanet)
        {

            planetGravity.gravity = JumpTimer;
        }
        if (playerdata.counteffect() > 0) if (!Globalprefs.Pause || _n1fps) EffectUpdate();
        if (Input.GetKeyDown(KeyCode.F3) && File.Exists("unsave/capterg/" + SaveFileInputField.text) && !Globalprefs.Pause && !tutorial)
        {
            gsave = JsonUtility.FromJson<GameData>(File.ReadAllText("unsave/capterg/" + SaveFileInputField.text));
            string s = "";
            s = SaveFileInputField.text;
            File.WriteAllText("unsave/s", s);
            SceneManager.LoadScene(gsave.sceneid);
        }


        if (photoCapture!=null) if (!Globalprefs.Pause) TridFace();
        GameObject oxy = oxygenUI;


       
        if (oxy!=null)
        {
            oxy.GetComponent<Image>().fillAmount = oxygen / 20;
        }
        if (InWater == true)
        {
            if (oxy==null)
            {
                if (!waterscreen) waterscreen = Instantiate(Resources.Load<GameObject>("ui/Screens/Water").gameObject, transform.position, Quaternion.identity);
                oxygenUI = Instantiate(Resources.Load<GameObject>("ui/info/oxygen").gameObject, transform.position, Quaternion.identity);
            }

            oxygen -= Time.deltaTime;
        }
        if (InWater == false && oxygen <= 5)
        {

            oxygen += Time.deltaTime;
        }
        if (InWater == false && oxygen >= 5 && oxygen <= 20)
        {
            if (oxy!=null)
            {
                Destroy(oxy);
            }
            oxygen += Time.deltaTime * 2;
        }
        if (InWater == false && waterscreen)
        {

            Destroy(waterscreen);
        } 
		if (Time.time >= nextDataUpdate2)
		{
			nextDataUpdate2 = Time.time + 1f;
			ParticleSystem ps = VarSave.GetBool("partic") ? GameObject.FindObjectOfType<ParticleSystem>() : null;
		
			if (ps!=null)
			{
				DestroyImmediate(ps.gameObject);
			}
		}
        tic += Time.deltaTime;
        if (!Globalprefs.Pause) HpUpdate();

       if (Time.time >= nextDataUpdate)
	   {
		   nextDataUpdate = Time.time + 1f;

		   WorldSave.SetMusic(SceneManager.GetActiveScene().name);
		   
	   }

        if (!Globalprefs.Pause) MoveUpdate();
        if (!Globalprefs.LockRotate && !xbox2) playerCameraComponent.fieldOfView += Input.GetAxis("Mouse ScrollWheel") / ZoomConficent;
					
         Globalprefs.camera.fieldOfView = playerCameraComponent.fieldOfView;
					Globalprefs.camera.fieldOfView *= 1;
        //"unsave/capter/"+ifd.text
        //Mouse ScrollWheel
        if (lt.Length != 0)
        {
            lt[0].GetComponent<Camera>().fieldOfView = playerCameraComponent.fieldOfView;
        }
		for(int suas =0;suas<2;suas++)
		{
			if(suas == 0)
			{
				if (Input.GetKeyDown(KeyCode.F1) && !tutorial && !inglobalspace && !Globalprefs.Pause)
				{
					
					save.angularvelosyty = rigidbody3d.angularVelocity;
					save.velosyty = rigidbody3d.linearVelocity;
					save.q1 = PlayerBody.transform.rotation;
					save.q2 = PlayerCamera.transform.rotation;
					save.pos = PlayerBody.transform.position;
					save.pos2 = HeadCameraSetup.transform.position;
					save.q3 = HeadCameraSetup.transform.rotation;
					save.wpos = W_position;
					save.hpos = H_position;
					save.hxrot = HX_Rotation;
					save.npos = N_position;
					save.cnpos = cur_N_position;
					if (Get4DCam()) save.rotW = Get4DCam()._wRotation;
			
					save.vive = playerCameraComponent.fieldOfView;
					if (HyperbolicCamera.Main() != null)
					{
						save.hpos_Polar3 = JsonUtility.ToJson(HyperbolicCamera.Main().RealtimeTransform);
					}
					gsave.hp = hp;
				}
			}
			if(suas == 1)
			{
				if (Input.GetKeyDown(KeyCode.F1) && !tutorial && !inglobalspace && !Globalprefs.Pause)
				{
					playerdata.Saveeffect();
					save.idsave = SaveFileInputField.text;
					Directory.CreateDirectory("unsave/capter" + SceneManager.GetActiveScene().buildIndex);
					File.WriteAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text, JsonUtility.ToJson(save));
		
					Directory.CreateDirectory("unsave/capter" + SceneManager.GetActiveScene().buildIndex);
					gsave.idsave = SaveFileInputField.text;
					gsave.hp = hp;
					gsave.oxygen = oxygen;
					gsave.fv = faceViewi;
		
					gsave.PlayerScale = CamDistanceMult;
					gsave.Spos = planet_position;
					gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
					File.WriteAllText("unsave/capterg/" + SaveFileInputField.text, JsonUtility.ToJson(gsave));
					string s = "";
					s = SaveFileInputField.text;
					File.WriteAllText("unsave/s", s);
					WorldSave.SetVector4("var");
					WorldSave.SetVector3("var1");
		
				}
				if (Input.GetKeyDown(KeyCode.F1) && tutorial && tutorialsave && !inglobalspace && !Globalprefs.Pause)
				{
					playerdata.Saveeffect();
					save.idsave = SaveFileInputField.text;
					Directory.CreateDirectory("unsavet/capter" + SceneManager.GetActiveScene().buildIndex);
					File.WriteAllText("unsavet/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text, JsonUtility.ToJson(save));
		
					Directory.CreateDirectory("unsavet/capter" + SceneManager.GetActiveScene().buildIndex);
					gsave.idsave = SaveFileInputField.text;
					gsave.hp = hp;
					gsave.oxygen = oxygen;
					gsave.fv = faceViewi;
		
					gsave.PlayerScale = CamDistanceMult;
					gsave.Spos = planet_position;
					gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
					File.WriteAllText("unsavet/capterg/" + SaveFileInputField.text, JsonUtility.ToJson(gsave));
					string s = "";
					s = SaveFileInputField.text;
					WorldSave.SetVector4("var");
					WorldSave.SetVector3("var1");
		
				}
			}
		}
        if (Input.GetKeyDown(KeyCode.F11) && VarSave.ExistenceVar("res3", SaveType.global) && !Globalprefs.Pause)
        {
            VarSave.SetBool("windowed", !VarSave.GetBool("windowed", SaveType.global), SaveType.global);
            Screen.SetResolution(VarSave.GetInt("res3", SaveType.global), VarSave.GetInt("res4", SaveType.global), !VarSave.GetBool("windowed", SaveType.global));

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

       

        if (!Globalprefs.Pause) load();

        if (!Globalprefs.Pause) PhysicsUpdate();

        if (!Globalprefs.Pause) Creaive();
		
    }

    decimal timer2 = 0; decimal timer5 = 0;
    decimal timer8 = 0;
    decimal timer6 = 0; decimal timer7 = 0;

    private void OnDestroy()
    {
        if (mediaStudioOwnsPause) Unauticna.MediaStudio.MediaStudioHost.CloseEditor();
        MediaStudioReleasePause();
        PlayerMechanics.Changed -= MechanicSettingsChanged;

	
    if (cameraTexture != null)
    {
        cameraTexture.Release();
        Destroy(cameraTexture);
        cameraTexture = null;
    }
        timer2 = (decimal)(System.DateTime.Now.Hour);
        timer2 += (decimal)(System.DateTime.Now.DayOfYear) * 24;
        timer2 += (decimal)(System.DateTime.Now.Year) * 24 * 365;
        VarSave.SetMoney("LastSesion", timer2); 
        timer6 = (decimal)(System.DateTime.Now.Hour);
        timer6 += (decimal)(System.DateTime.Now.DayOfYear) * 24;
        timer6 += (decimal)(System.DateTime.Now.Year) * 24 * 365;
        VarSave.SetMoney("LastSesionHours", timer6);
    }
    private void EconomicUpdate()
    {
        if (!PlayerMechanics.Active(MechanicId.Economy)) return;

        Globalprefs.UpadateTevro();
        if (VarSave.GetMoney("Inflation", SaveType.global) < 0) VarSave.SetMoney("Inflation", 0, SaveType.global);
        timer += (decimal)Time.deltaTime;
        if (timer > 60m * 60m)
        {

            Globalprefs.LoadTevroPrise(Globalprefs.flowteuvro);

            timer = 0;
        }
        
          timer8 += (decimal)Time.deltaTime;
          if (timer8 > 5 && cistalenemy.dies > 0&& invisibeobject>0)
          {


              cistalenemy.dies-=1+invisibeobject;

              VarSave.SetInt("Agr", cistalenemy.dies);
              if(VarSave.GetFloat(
                  "Sadist" + "_gameSettings", SaveType.global)>=.1f)
              {
                  VarSave.LoadFloat("reason", 1);
              }
              timer8 = 0;
          }
        
        if (Globalprefs.selectitemobj) if (!Globalprefs.selectitemobj.GetComponent<itemName>().ItemInfinitysPrise)
            {
                if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Mouse0) && !Globalprefs.Pause && Globalprefs.selectitemobj)
                {
                    if (Globalprefs.selectitemobj.GetComponent<itemName>().isLife)
                    {

                        cistalenemy.dies += 100;
                        VarSave.SetInt("Agr", cistalenemy.dies);
                    }
                   
                    Globalprefs.LoadTevroPrise(Globalprefs.ItemPrise * (Globalprefs.GetProcentInflitiuon() + 1));
                    Destroy(Globalprefs.selectitemobj.gameObject);
                    Globalprefs.selectitem = "";
                    Globalprefs.ItemPrise = 0;
                }
            }
        if (Globalprefs.selectitemobj) if (Globalprefs.selectitemobj.GetComponent<itemName>().ItemInfinitysPrise)
            {
                if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Mouse0) && !Globalprefs.Pause && Globalprefs.selectitemobj)
                {
                    if (Globalprefs.selectitemobj.GetComponent<itemName>().isLife)
                    {

                        cistalenemy.dies += 100;
                        VarSave.SetInt("Agr", cistalenemy.dies);
                    }
                    playerdata.Addeffect("Unyverseium_money_cart", float.PositiveInfinity);
                    Globalprefs.Infinitysteuvro += (double)Globalprefs.ItemPrise * (double)(Globalprefs.GetProcentInflitiuon() + 1);
                    VarSave.SetTrash("inftevro", VarSave.GetTrash("inftevro") + (double)Globalprefs.ItemPrise * (double)(Globalprefs.GetProcentInflitiuon() + 1));
                    Destroy(Globalprefs.selectitemobj.gameObject);
                    Globalprefs.selectitem = "";
                    Globalprefs.ItemPrise = 0;
                }
            }
        if (Globalprefs.selectcoobj) if (Globalprefs.selectcoobj.GetComponent<CustomObject>())
            {
                if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Mouse0) && !Globalprefs.Pause && Globalprefs.selectcoobj)
                {
                    if (Globalprefs.selectcoobj.GetComponent<SocialObject>())
                    {

                        cistalenemy.dies += 100;
                        VarSave.SetInt("Agr", cistalenemy.dies);
                    }

                    Globalprefs.LoadTevroPrise(Globalprefs.ItemPrise * (Globalprefs.GetProcentInflitiuon() + 1));
                    Destroy(Globalprefs.selectcoobj.gameObject);
                    Globalprefs.selectitem = "";
                    Globalprefs.ItemPrise = 0;
                }
            }
        // playerdata.Addeffect("Unyverseium_money_cart", float.PositiveInfinity);
    }

        void WPositionUpdate()
    {
        if (!PlayerMechanics.Active(MechanicId.Dimensions)) return;

        if (Get4DCam() != null) Get4DCam()._wPosition = W_position;
        if (((int)W_position) >= 500 && ((int)W_position) <= 550 && !FindFirstObjectByType<Logic_tag_kataBlock>())
        {
            Globalprefs.WMovepos = transform.position;
            portallNumer.Portal = "WMove+";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (((int)W_position) <= -500 && ((int)W_position) >= -550 && !FindFirstObjectByType<Logic_tag_anaBlock>())
        {

            Globalprefs.WMovepos = transform.position;
            portallNumer.Portal = "WMove-";
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }


    public float GravityConstant()
    {
        float gravity1 = jumpforse * JumpTimer * transform.localScale.y;
        gravity1 = Mathf.Clamp(gravity1,-5,18);
        return gravity1;
    }
    float timer3;
    float timer4;
    private void PhysicsUpdate()
    {
        if (faceViewi != faceView.fourd)
        {







            if (!Smuta) gameObject.GetComponent<Rigidbody>().useGravity = false;

        }
       
        timer3 += Time.deltaTime;
        timer4 += Time.deltaTime;
        if (timer3 >= 3f && fireInk > 10 && fireInk < 25)
        {
            if (fire.Init()) Instantiate(fire.o, transform.position, Quaternion.identity);
            fireInk -= 12;
            timer3 = 0;
        }
        else if (timer3 >= .5f && fireInk > 25)
        {
            if (fire.Init()) Instantiate(fire.o, transform.position, Quaternion.identity);
            fireInk -= 12;
            timer3 = 0;
        }
        else if(timer3 >= 3f && fireInk > 0)
        {

            fireInk -= 1;

            timer3 = 0;
        }

        float deltaX = Input.GetAxis("Horizontal") * Speed;
        float deltaZ = Input.GetAxis("Vertical") * Speed;
        if (timer4 >= 1 && deltaX+deltaZ != 0)
        {

            fireInk -= 15;
            timer4 = 0;

        }
        if (fireInk <= 0)
        {
            fireInk = 0;
        }

        VarSave.SetFloat("FireInk", fireInk);

    }
    public IEnumerator SpawnFire(Vector3 pos,float conf)
    {
        yield return new WaitForSeconds(conf);
        fire.Init();
        GameObject g = Instantiate(fire.o, pos, Quaternion.identity);
        g.name = "Fire(Clone)";
    }
   public void Spawninitfire(Vector3 pos)
    {

        StartCoroutine(SpawnFire(pos,Global.Random.Range(0f,.5f)));
      
    }
    float ftho;
    bool isKinematic;
    [SerializeField] public bool Smuta;
    public bool NeedsRest { get; private set; }
    private bool smutaBeforeNeedsRest;

    public void SetNeedsRest(bool value)
    {
        if (NeedsRest == value) return;
        NeedsRest = value;
        if (value)
        {
            smutaBeforeNeedsRest = Smuta;
            Smuta = true;
            // Stop existing player momentum once; gravity and collisions remain active.
            var body = GetComponent<Rigidbody>();
            if (body != null && !body.isKinematic)
            {
                body.linearVelocity = Vector3.zero;
                body.angularVelocity = Vector3.zero;
            }
        }
        else
        {
            Smuta = smutaBeforeNeedsRest;
            if (!Smuta) transform.rotation = Quaternion.identity;
        }
    }
    float movegrag;
    static float speed = 8;
    private void GostUpdate()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            speed += 0.1f;
            speed /= 2;
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            speed += 0.1f;
            speed *= 2;
        }
        if (inputWpress)
        {
            transform.position += transform.forward * speed;
        }
        if (inputSpress)
        {
            transform.position -= transform.forward * speed;
        }
        if (inputDpress)
        {
            transform.position += transform.right * speed;
        }
        if (inputApress)
        {
            transform.position -= transform.right * speed;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.up * speed;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.position -= transform.up * speed;
        }
       
        if (playerdata.Geteffect("AutoRotate") == null)
        {
            if (!Globalprefs.LockRotate)
            {
                if (Input.GetKey(KeyCode.Mouse1))
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    if (faceViewi == faceView.first)
                    {


                        PlayerCamera.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * 2, 0, 0));
                    }
                    if (faceViewi == faceView.trid)
                    {


                        HeadCameraSetup.transform.Rotate(-Input.GetAxis("Mouse Y") * 2, 0, 0);
                    }
                    if (hyperbolicCamera == null)
                    {
                        if (faceViewi != faceView.fourd)
                        {

                            PlayerBody.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 2, 0));
                        }
                    }
                    else if (!hyperbolicCamera.gameObject.activeSelf)
                    {
                        if (faceViewi != faceView.fourd)
                        {

                            PlayerBody.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 2, 0));
                        }
                    }

                }
                else
                {
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
        if (playerdata.Geteffect("AutoRotate") != null)
        {
            if (!Globalprefs.LockRotate)
            {
                Cursor.lockState = CursorLockMode.Locked;
                if (faceViewi == faceView.first)
                {


                    PlayerCamera.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * 2, 0, 0));
                }
                if (faceViewi == faceView.trid)
                {


                    HeadCameraSetup.transform.Rotate(-Input.GetAxis("Mouse Y") * 2, 0, 0);
                }
                if (hyperbolicCamera == null)
                {
                    if (faceViewi != faceView.fourd)
                    {

                        PlayerBody.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * 2, 0));
                    }
                }

            }
        }
    }
    private void OnDisable()
    {
        if (mediaStudioOwnsPause) Unauticna.MediaStudio.MediaStudioHost.CloseEditor();
        MediaStudioReleasePause();
        // Do not reactivate the player while another mechanic owns control.

    }
    public bool HyperbolicPlanetHookInstalled => true;
    private void MoveUpdate()
    {
        // H2 planet mode owns movement only while the player is on a planet.
        
        if (NeedsRest)
        {
            Smuta = true;
            Sprint = false;
            JumpTimer = 0f;
            rigidbody3d.freezeRotation = false;
            rigidbody3d.useGravity = true;
            rigidbody3d.linearDamping = 3f;
            if (animator != null) animator.SetFloat("MoveVelosity", 0f);
            return;
        }
		var xbox2 = CachedXboxMode;
		var xbox = WindowsReceiver.GetInput();
		RaycastHit hit;
        Sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)|| xbox.Y;
		IsGraund = Physics.Raycast(
		transform.position,
		-transform.up,
		1.3f,
		0
	);
	
	RaycastHit hit35;
	
	if (Physics.Raycast(
		transform.position,
		-transform.up,
		out hit35,
		100.3f))
	{
		if (hit35.collider != null &&
			hit35.distance > 1.3f)
		{
			movegrag = 5 / transform.localScale.y;
		}
	}
	else
	{
		movegrag = 5 / transform.localScale.y;
	}
        if (inputC)
        {
            if (Smuta)
            {
                transform.rotation = Quaternion.identity;
            }
            Smuta = !Smuta;
        }
        if (Smuta)
        {
            rigidbody3d.freezeRotation = false;
            rigidbody3d.useGravity = true;
            rigidbody3d.linearDamping = 0.0f;
        }
        else
        {
            rigidbody3d.freezeRotation = true;
            rigidbody3d.useGravity = false;
        }
        PlayerRayMarchCollider ry = rayMarchCollider;
        if (ry != null)
        {
          if(mainCamera)  if (ry.GetCenterDist() < 1.2f)
            {

                movegrag = 1 / transform.localScale.y;
                IsGraund = true;
            }
            else
            {

            }

        }

        isKinematic = inputFpress;


        if (!Smuta)
        {
            if (IsGraund)
            {
                if (Input.GetKey(KeyCode.Space) || xbox.X) JumpTimer = jumpPower * transform.localScale.y;
                if (!Input.GetKey(KeyCode.Space) || xbox.X) JumpTimer = 0;

                rigidbody3d.linearDamping =( 6 - (axelerate) );
                jumpforse = Mathf.Clamp(jumpforse, 0, 1000) * transform.localScale.y;
            }
            else
            {
                jumpforse = Mathf.Clamp(JumpTimer, -10, 1000) * transform.localScale.y;
                if (jumpforse > 0.25f || jumpforse < -0.25f)
                { movegrag = 5; }
                else
                {
                    movegrag = 1;
                }
                rigidbody3d.linearDamping = (4.5f - (axelerate));
            }
        }
        bool flyinng = InWater || inglobalspace || isKinematic || gravity == 0 || god;
        if (!flyinng) JumpTimer -= Time.deltaTime* gravity;
        if (faceViewi != faceView.fourd )
        {
           if(ftho > 0) ftho -= Time.deltaTime;
            if (inputF && CosProgress() > 0)
            {
                ftho += 1;
                if (ftho > 1)
                {
                    transform.Translate(Vector3.forward * 4 * transform.localScale.y); ftho = 0;
                }
            }
            float macrosX = (xboxKeyMacros("a") ? 1 : 0) + (xboxKeyMacros("d") ? -1 : 0) + ((inputQpress) ? -1 : 0);
            float macrosZ = (xboxKeyMacros("w") || (Input.GetKey(KeyCode.Mouse0)&& Input.GetKey(KeyCode.Mouse1)) ? 1 : 0) +((inputZpress) ? 1 : 0) + (xboxKeyMacros("s") ? -1 : 0)+(xbox.B ? 1 : 0);
            float macrosMy = (xboxKeyMacros("MY+") || (Input.GetAxis("Mouse ScrollWheel")>0.1f && xbox2) ? 1 : 0) + (xboxKeyMacros("MY-") || (Input.GetAxis("Mouse ScrollWheel") < -0.1f && xbox2) ? -1 : 0) - (xbox.stickY*2);
            float macrosMx = (xboxKeyMacros("MX+") || Input.GetKey(KeyCode.Period) || (Input.GetKey(KeyCode.Mouse1) && xbox2) ? 1 : 0) + (xboxKeyMacros("MY-") || (Input.GetKey(KeyCode.Comma) || Input.GetKey(KeyCode.Mouse0) && xbox2) ? -1 : 0)+(xbox.stickX * 2);
            macrosMx +=  (Input.GetKey(KeyCode.Period)  ? 5 : 0) + (Input.GetKey(KeyCode.Comma) ? -5 : 0);
            float deltaX = (Input.GetAxis("Horizontal")+ macrosX) * (Speed * (1f / movegrag));
            float deltaZ = (Input.GetAxis("Vertical") + macrosZ )* (Speed * (1f / movegrag));
            //AutoRun
            //AutoRotate
            if (playerdata.Geteffect("AutoRun") != null)
            {
                deltaZ += (Speed * (1f / movegrag)) * transform.localScale.y;
            }
            if (playerdata.Geteffect("AutoRight") != null)
            {
                deltaX += (Speed * (1f / movegrag)) * transform.localScale.y;
            }
            if (playerdata.Geteffect("AutoLeft") != null)
            {
                deltaX += -(Speed * (1f / movegrag)) * transform.localScale.y;
            }
            float Dimenshonal = VarSave.GetFloat("Dimenshonal");
            float deltaW = Input.GetAxis("HyperHorizontal") * 0.1f;
            float deltaH = Input.GetAxis("HyperVertical") * 0.1f;
            if (playerdata.Geteffect("AutoDimenshonal") != null)
            {
                if (Dimenshonal == 4) deltaW += (1f);
                if (Dimenshonal == 5) deltaH += (1f);
                if (Dimenshonal > 5) N_position[(int)Dimenshonal - 6] += (0.1f);
            }
            if (playerdata.Geteffect("-AutoDimenshonal") != null)
            {
                if (Dimenshonal == 4) deltaW += -(1f);
                if (Dimenshonal == 5) deltaH += -(1f);
                if (Dimenshonal > 5) N_position[(int)Dimenshonal - 6] += -(0.1f);
            }
            float deltaY = 0.0f;
             if(flyinng)  deltaY = (Input.GetAxis("Jump") * Speed*1)-0.1f;
            if (!flyinng) if (!flyinng) if (Input.GetKey(KeyCode.Space) && IsGraund|| xbox.X && IsGraund)
                    {
                        jumpforse = Mathf.Clamp(JumpTimer, -10, 1000) * transform.localScale.y;
                    }
            if (!flyinng) deltaY += jumpforse * Time.deltaTime * 600 * transform.localScale.y;
            if ((flyinng) && Input.GetKey(KeyCode.Space)|| xbox.X) deltaY += 1 * Speed * Time.deltaTime * 6 * transform.localScale.y;
            if ((flyinng) && Sprint) deltaY -= 1 * Speed * Time.deltaTime * 6 * transform.localScale.y;
            if (!flyinng) if (Sprint) deltaY -= 1 * (Time.deltaTime * 100f) * transform.localScale.y;
            if (Sprint && (VarSave.GetMoney("Winks", SaveType.local) > 0 || VarSave.GetFloat("SevenSouls") > 0))
            {
                Vector3 v3 = PlayerCamera.transform.forward*15 * transform.localScale.y;
                rigidbody3d.AddForce(v3, ForceMode.VelocityChange);
            }
            float sprintCnficent = 1f;
            if (Input.GetKeyDown(KeyCode.Alpha4) && !Globalprefs.Pause)
            {
                if (CosProgress() > 2) swapWHaN = !swapWHaN;
            }
          if (swapWHaN)
            {
                if (!Sprint && !Globalprefs.Pause)
                {



                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        if (CosProgress() > 2) N_position[cur_N_position] -= 1f * Time.deltaTime;
                    }
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        if (CosProgress() > 2) N_position[cur_N_position] += 1f * Time.deltaTime;
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (cur_N_position > 0)
                        {
                            if (CosProgress() > 2) cur_N_position -= 1;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if (N_position.Count -1 < cur_N_position + 1)
                        {
                            N_position.Add(0);
                        }
                        if (CosProgress() > 2) cur_N_position += 1;
                    }
                }
                if (Sprint && !Globalprefs.Pause)
                {



                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        if (CosProgress() > 2) N_position[cur_N_position] -= 10f * Time.deltaTime;
                    }
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        if (CosProgress() > 2) N_position[cur_N_position] += 10f * Time.deltaTime;
                    }
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        if (cur_N_position - 3 > 0)
                        {
                            if (CosProgress() > 2) cur_N_position -= 3;
                        }
                    }
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        if (N_position.Count-1 < cur_N_position + 3)
                        {
                            N_position.Add(0);
                            N_position.Add(0);
                            N_position.Add(0);
                        }
                        if (CosProgress() > 2) cur_N_position += 3;
                    }
                }
            }
            if (Sprint && !swapWHaN)
            {


                if (!isKinematic) W_position += (deltaW * 5) * Time.deltaTime * 60;
                if (CosProgress() > 1) if (!isKinematic) H_position += (deltaH * 5) * Time.deltaTime * 60;
                sprintCnficent = 2;
            }
            else if (!swapWHaN)
            {

                if (!isKinematic) W_position += (deltaW) * Time.deltaTime * 60;
                if (CosProgress() > 1) if (!isKinematic) H_position += (deltaH) * Time.deltaTime * 60;
            }
            float deltaSumXZ = deltaX + deltaZ;

            //  if(deltaSumXZ == 0) rigidbody3d.velocity = Vector3.zero;
            if (inputM)
            {
                animator.SetTrigger("uhov");

                GameObject g3 = Resources.Load<GameObject>("voices/мяу");
                Instantiate(g3, (Vector3.up), Quaternion.identity); 
            }
                animator.SetFloat("MoveVelosity", deltaSumXZ + .5f);
            
            if (LateInWater != InWater)
            {

                animator.SetBool("InWater", InWater);
                LateInWater = InWater;
            }
            if ((flyinng)) if (!isKinematic) if (playerdata.Geteffect("AutoJump") != null)
                    {
                        deltaY = Speed * Time.deltaTime * 6;
                        transform.Translate(0, 0.1f * transform.localScale.y, 0);
                        rigidbody3d.AddForce(transform.up * (deltaY * 3) * transform.localScale.y, ForceMode.Force);
                    }
            if ((flyinng)) if (!isKinematic) if (playerdata.Geteffect("AutoDown") != null)
                    {
                        deltaY = -Speed * Time.deltaTime * 6;
                        transform.Translate(0, 0.1f * transform.localScale.y, 0);
                        rigidbody3d.AddForce(transform.up * (deltaY * 1) * transform.localScale.y, ForceMode.Force);
                    }
            if (!(flyinng)) if (!isKinematic) if (playerdata.Geteffect("AutoDown") != null)
                    {
                        deltaY = -Speed * Time.deltaTime * 6;
                        transform.Translate(0, 0.1f * transform.localScale.y, 0);
                        rigidbody3d.AddForce(transform.up * (deltaY * 1) * transform.localScale.y, ForceMode.Force);
                        JumpTimer = 0;
                    }
            if (!(flyinng)) if (!isKinematic) if (playerdata.Geteffect("AutoJump") != null)
                    {
                        if (IsGraund)
                        {
                            deltaY = Speed * Time.deltaTime * 6;
                            transform.Translate(0, 0.1f * transform.localScale.y, 0);
                            rigidbody3d.AddForce(transform.up * (deltaY * 3) * transform.localScale.y, ForceMode.Force);
                        }
                    }
            if (!isKinematic) if (Input.GetKey(KeyCode.Space)&& xbox.X) transform.Translate(0, 0.1f * transform.localScale.y, 0);
            if (!isKinematic) if (Sprint) { transform.Translate(0, -0.1f * transform.localScale.y, 0); JumpTimer = 0; }
            Vector3 movement = new(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, Speed * transform.localScale.y);
            
            movement = transform.TransformDirection(movement);

            if ((flyinng)) if (!isKinematic) rigidbody3d.AddForce(((movement * sprintCnficent) + transform.up * (deltaY * 3)), ForceMode.Force); 
            if (!(flyinng)) if (!isKinematic) rigidbody3d.AddForce(((movement * sprintCnficent) + transform.up * deltaY), ForceMode.Force); 




            if (tics >= 2)
            {
                transform.Translate(0, 0, 5* CamDistanceMult * transform.localScale.y);
                tics = 0;
            }
           
                if (playerdata.Geteffect("AutoRotate") == null)
            {
                if (!Globalprefs.LockRotate)
                {
                    if (Input.GetKey(KeyCode.Mouse1))
                    {
                        Cursor.lockState = CursorLockMode.Locked;
                        if (faceViewi == faceView.first)
                        {


                            PlayerCamera.transform.Rotate(new Vector3(-((Input.GetAxis("Mouse Y")* (xbox2== true ? 0 : 1))) * 2, 0, 0));
                        }
                        if (faceViewi == faceView.trid)
                        {


                            HeadCameraSetup.transform.Rotate(-(Input.GetAxis("Mouse Y") * (xbox2 == true ? 0 : 1)) * 2, 0, 0);
                        }
                        if (hyperbolicCamera == null)
                        {
                            if (faceViewi != faceView.fourd)
                            {

                                PlayerBody.transform.Rotate(new Vector3(0, (Input.GetAxis("Mouse X") * (xbox2 == true ? 0 : 1)) * 2, 0));
                            }
                        }
                        else if(!hyperbolicCamera.gameObject.activeSelf)
                        {
                            if (faceViewi != faceView.fourd)
                            {

                                PlayerBody.transform.Rotate(new Vector3(0, (Input.GetAxis("Mouse X") * (xbox2 == true ? 0 : 1)) * 2, 0));
                            }
                        }

                    }
                    else
                    {
                        Cursor.lockState = CursorLockMode.None;
                    }
                }
            }
            if (playerdata.Geteffect("AutoRotate") != null)
            {
                if (!Globalprefs.LockRotate)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    if (faceViewi == faceView.first)
                    {


                        HeadCameraSetup.transform.Rotate(-(Input.GetAxis("Mouse Y") * (xbox2 == true ? 0 : 1)) * 2, 0, 0);
                    }
                    if (faceViewi == faceView.trid)
                    {


                        HeadCameraSetup.transform.Rotate(-(Input.GetAxis("Mouse Y") * (xbox2 == true ? 0 : 1)) * 2, 0, 0);
                    }

                    if (hyperbolicCamera == null)
                    {
                        if (faceViewi != faceView.fourd)
                        {

                            PlayerBody.transform.Rotate(new Vector3(0, (Input.GetAxis("Mouse X") * (xbox2 == true ? 0 : 1)) * 2, 0));
                        }
                    }

                }
            }
                    if (faceViewi == faceView.first)
                    {


                        HeadCameraSetup.transform.Rotate(macrosMy * 2, 0, 0);
                    }
                    if (faceViewi == faceView.trid)
                    {


                        HeadCameraSetup.transform.Rotate(macrosMy * 2, 0, 0);
                    }

                    if (hyperbolicCamera == null)
                    {
                        if (faceViewi != faceView.fourd)
                        {

                            PlayerBody.transform.Rotate(new Vector3(0, macrosMx * 2, 0));
                        }
                    }

        }
    }
    GameObject sas4;
    int maxhp;
    public void death()
    {
        Globalprefs.TryBar = false;
        if (!Globalprefs.TryBar) 
        {
            VarSave.SetBool("умерли от ран", true);
            VarSave.SetBool("cry", true);

            gsave.hp = 20;


            gsave.idsave = SaveFileInputField.text;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsave/capterg/" + SaveFileInputField.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = SaveFileInputField.text;
            File.WriteAllText("unsave/s", s);
            WorldSave.SetVector4("var");
            WorldSave.SetVector3("var1");

            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex); 
        }
    }
    bool hplow;
    bool oxylow;
    private void HpUpdate()
    {
        if (!PolitDate.IsGood(politicfreedom.NonPositionalian))
        {
            if (hp <= 0)
            {
                if (VarSave.GetFloat(
              "встал_и_пошол" + "_gameSettings", SaveType.global) <= -1f)
                {
                    VarSave.SetBool("lol you Banned", true);
                    SceneManager.LoadSceneAsync("Banned forever");
                }

                if (VarSave.GetFloat(
              "встал_и_пошол" + "_gameSettings", SaveType.global) < .5f)
                {
                    VarSave.SetBool("умерли от ран", true);
                    VarSave.SetBool("cry", true);

                    gsave.hp = 20;


                    gsave.idsave = SaveFileInputField.text;
                    gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
                    File.WriteAllText("unsave/capterg/" + SaveFileInputField.text, JsonUtility.ToJson(gsave));
                    string s = "";
                    s = SaveFileInputField.text;
                    File.WriteAllText("unsave/s", s);
                    WorldSave.SetVector4("var");
                    WorldSave.SetVector3("var1");

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                else
                {
                    if (!hplow) Globalprefs.TryBar = true;
                    hplow = true;
                }

            }
            else
            {
                hplow = false;
            }
        }
        if (oxygen <= 0)
        {
            if (VarSave.GetFloat(
          "встал_и_пошол" + "_gameSettings", SaveType.global) <= -1f)
            {
                VarSave.SetBool("lol you Banned", true);
                SceneManager.LoadSceneAsync("Banned forever");
            }
            if (VarSave.GetFloat(
          "встал_и_пошол" + "_gameSettings", SaveType.global) < .5f)
            {
                VarSave.SetBool("oxygen", true);
                VarSave.SetBool("cry", true);

                gsave.oxygen = 20;


                gsave.idsave = SaveFileInputField.text;
                gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
                File.WriteAllText("unsave/capterg/" + SaveFileInputField.text, JsonUtility.ToJson(gsave));
                string s = "";
                s = SaveFileInputField.text;
                File.WriteAllText("unsave/s", s);
                WorldSave.SetVector4("var");
                WorldSave.SetVector3("var1");

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                if (!oxylow) Globalprefs.TryBar = true;
                oxylow = true;
            }

        }
        else
        {
            oxylow = false;
        }
        if (!PolitDate.IsGood(politicfreedom.NonPositionalian))
        {
            GameObject g = GameObject.FindWithTag("blood");
            if (hp >= 20 && g)
            {
                Destroy(g);
            }



            if (hp <= 20 && !g)
            {
                Instantiate(Resources.Load<GameObject>("ui/damage/blood").gameObject, transform.position, Quaternion.identity);
            }
        }

        GameObject g2 = GameObject.FindWithTag("blood1");


        if (oxygen >= 5 && g2)
        {
            Destroy(g2);
        }
        if (oxygen <= 5 && !g2)
        {
            Instantiate(Resources.Load<GameObject>("ui/damage/blood1").gameObject, transform.position, Quaternion.identity);
        }

        if (VarSave.GetFloat(
           "встал_и_пошол" + "_gameSettings", SaveType.global) > -0.5f)
        {
            if (tic >= time && hp < 200 + maxhp + maxhp2)
            {
                hp += 1 + hpregen + regen;
                tic = 0;

            }
        }

    }
    GameObject mats;
    float timer12;
    public void DieFromSnayp()
    {
        VarSave.SetBool("Пристрелен Спамтоном", true);
        VarSave.SetBool("cry", true);


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Inputnravix()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Globalprefs.born)
        {
            timer12 += Time.timeScale;
            if (timer12 > 10) { Instantiate(Resources.Load<GameObject>("Items/Маленький_Терратик").gameObject, transform.position, Quaternion.identity); timer12 = 0; }
        }
        if (Input.GetKeyDown("5"))
        {
          if(mats == null)  mats = Instantiate(Resources.Load<GameObject>("ui/mats/mats").gameObject, transform.position, Quaternion.identity);
          else  if (mats != null) Destroy(mats);
        }
        if (Input.GetKeyDown("1"))
        {
            Instantiate(Resources.Load<GameObject>("Primetives/E2/PowerMetka").gameObject, transform.position, Quaternion.identity);
        }
        if (Input.GetKey("1") && Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject[] pp = GameObject.FindGameObjectsWithTag("PaintPoint");
            foreach (GameObject g in pp)
            {
                g.AddComponent<deleter1>();
            }
        }
        RaycastHit hit = MainRay.MainHit;

        if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0) && !Globalprefs.Pause)
        {
            if (hit.collider.GetComponent<transport4>())
                hit.collider.GetComponent<transport4>().sitplayer = !hit.collider.GetComponent<transport4>().sitplayer;
            if (hit.collider.GetComponent<transport4>())
                hit.collider.GetComponent<transport4>().player = transform;
        }
        if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0) && !Globalprefs.Pause)
        {
            if (hit.collider.GetComponent<UMUITank>())
                hit.collider.GetComponent<UMUITank>().sitplayer = !hit.collider.GetComponent<UMUITank>().sitplayer;
            if (hit.collider.GetComponent<UMUITank>())
                hit.collider.GetComponent<UMUITank>().player = transform;
        }
        if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0) && !Globalprefs.Pause)
        {
            if (hit.collider.GetComponent<CustomTransport>())
                hit.collider.GetComponent<CustomTransport>().sitplayer = !hit.collider.GetComponent<CustomTransport>().sitplayer;
            if (hit.collider.GetComponent<CustomTransport>())
                hit.collider.GetComponent<CustomTransport>().player = transform;
        }
        if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0) && !Globalprefs.Pause)
            {
                if (hit.collider.GetComponent<GravityBoard>())
                    hit.collider.GetComponent<GravityBoard>().sitplayer = !hit.collider.GetComponent<GravityBoard>().sitplayer;
                if (hit.collider.GetComponent<GravityBoard>())
                    hit.collider.GetComponent<GravityBoard>().player = transform;
            }
        

        if (Input.GetKeyDown(KeyCode.F4))
        {
            Unload();
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
          
            PlayerBody.transform.rotation = Quaternion.identity;
            PlayerCamera.transform.rotation = HeadCameraSetup.transform.rotation;


            if (faceViewi == faceView.first)
            {


                faceViewi = faceView.trid;
                Global.MEM.UE();
                return;
            }
            if (faceViewi == faceView.trid)
            {


                faceViewi = faceView.fourd; Global.MEM.UE(); return;
            }
            if (faceViewi == faceView.fourd)
            {

                point = transform.position;
                faceViewi = faceView.sims; Global.MEM.UE(); return;
            }
            if (faceViewi == faceView.sims)
            {


                faceViewi = faceView.first; Global.MEM.UE(); return;
            }
        }
    }
    GameObject t;
    private void TridFace()
    {
       
        
        if (faceViewi == faceView.first)
        {
            PlayerCamera.transform.position = HeadCameraSetup.transform.position;
            SkinOff();
        }
        if (faceViewi == faceView.trid)
        {
            if (photoCapture!=null) 
                {
                    if (t == null)
                    {
                        if (photoCapture!=null) t = photoCapture.gameObject;
                    }

                    SkinManager();
                    Ray r = new(HeadCameraSetup.transform.position, -HeadCameraSetup.transform.forward);
                    RaycastHit hit1;
                    float distcam = 0;
                    // CamDistanceMult
                    float dist = (6 + distcam) * CamDistanceMult * transform.localScale.y;
                    if (Globalprefs.sit_player) distcam = 5; else distcam = 0;
                    if (UnityEngine.Physics.Raycast(r, out hit1))
                    {
                        if (hit1.collider != null)
                        {
                            if (hit1.distance < dist)
                            {

                                PlayerCamera.transform.position = hit1.point;
                            }
                            if (hit1.distance > dist)
                            {

                                PlayerCamera.transform.position = HeadCameraSetup.transform.position - HeadCameraSetup.transform.forward * (dist);
                            }
                        }
                        else
                        {
                            PlayerCamera.transform.position = HeadCameraSetup.transform.position - HeadCameraSetup.transform.forward * (dist);
                        }
                    }
                    else
                    {
                        PlayerCamera.transform.position = HeadCameraSetup.transform.position - HeadCameraSetup.transform.forward * (dist);
                    }

                }
        }
        if (photoCapture!=null) if (faceViewi == faceView.fourd)
            {
                SkinManager();
                if (t == null)
                {
                    t = photoCapture.gameObject;
                }
                if (t.GetComponent<FreeCam>())
                {

                }
                if (!t.GetComponent<FreeCam>())
                {
                    if (photoCapture!=null) t.AddComponent<FreeCam>();
                }
            }
            else
            {
                if (photoCapture!=null)
                {
                    if (t == null)
                    {
                        if (photoCapture!=null) t = photoCapture.gameObject;
                    }
                    if (t.GetComponent<FreeCam>())
                    {
                        if (photoCapture!=null) Destroy(t.GetComponent<FreeCam>());
                    }
                }
            }
        if (photoCapture!=null) if (faceViewi == faceView.sims&&sas4==null)
            {
                SkinManager();

                sas4 = Instantiate(Resources.Load<GameObject>("Items/SimsEditor"), transform.position, UnityEngine.Quaternion.identity);

            }

    }

    private void SkinOff()
    {
      /*  Logic_tag_Skin[] ls = FindObjectsByType<Logic_tag_Skin>(sortmode.main);
        foreach (Logic_tag_Skin i in ls)
        {
            i.gameObject.layer = 8;
        }
        for (int i = 0; i < PlayerModelObjects.Length; i++)
        {

            if (VarSave.ExistenceVar("Controler"))
            {
                if (i == int.Parse(VarSave.GetString("Controler")))
                {

                    PlayerModelObjects[i].SetActive(true);
                    SkinedAnimators[i].enabled = true;
                    animator = SkinedAnimators[i];
                }
                else
                {

                    PlayerModelObjects[i].SetActive(false);
                    SkinedAnimators[i].enabled = false;
                }
            }
            else
            {
                if (i == 0)
                {

                    PlayerModelObjects[i].SetActive(true);
                    SkinedAnimators[i].enabled = true;
                    animator = SkinedAnimators[i];
                }
                else
                {

                    PlayerModelObjects[i].SetActive(false);
                    SkinedAnimators[i].enabled = false;
                }
            }
        }*/
    }

    private void SkinManager()
    {
     /*   Logic_tag_Skin[] ls = FindObjectsByType<Logic_tag_Skin>(sortmode.main);
        foreach (Logic_tag_Skin i in ls)
        {
            if (playerdata.Geteffect("KsenoMorfin") == null)
            {
                i.gameObject.layer = 0;
            }
            if (playerdata.Geteffect("KsenoMorfin") != null)
            {
                i.gameObject.layer = 8;
            }
        }
        for (int i =0;i< PlayerModelObjects.Length;i++)
        {

            if (VarSave.ExistenceVar("Controler")) {
                if (i == int.Parse(VarSave.GetString("Controler")))
                {

                    PlayerModelObjects[i].SetActive(true);
                    SkinedAnimators[i].enabled = true;
                    animator = SkinedAnimators[i];
                }
                else
                {

                    PlayerModelObjects[i].SetActive(false);
                    SkinedAnimators[i].enabled = false;
                }
            }
            else
            {
                if (i == 0)
                {

                    PlayerModelObjects[i].SetActive(true);
                    SkinedAnimators[i].enabled = true;
                    animator = SkinedAnimators[i];
                }
                else
                {

                    PlayerModelObjects[i].SetActive(false);
                    SkinedAnimators[i].enabled = false;
                }
            }
        }*/
    }
    float axelerate;
    int hpregen;
  [HideInInspector] public int invisibeobject;
    float timerTrip;
    float timerFlowUp;
    bool big;
    bool _n1fps;
    bool soveVision;
    bool allVision;
    bool noVision;
    GameObject nov;
    bool god;
    Vector3 uniepos;
    private void EffectUpdate()
    {
        // playerdata.Addeffect("No kapitalism", float.PositiveInfinity);
        //"Шизфрения"
        if (playerdata.Geteffect("Undyning") != null)
        {
            hp = int.MaxValue;
            //playermatinvisible
        }
        if (playerdata.Geteffect("No kapitalism") != null)
        {
            VarSave.SetMoney("tevro", decimal.MaxValue-1000000);
            //playermatinvisible
        }
        if (playerdata.Geteffect("Unyverseium_money_cart") != null)
        {
           if(Globalprefs.Infinitysteuvro>0) VarSave.SetMoney("tevro", decimal.MaxValue - 1000000);
            //playermatinvisible
        }

        //MetabolismUp
        if (playerdata.Geteffect("KsenoMorfin") == null && perMorphin && VarSave.GetString("ActiveScin") == "")
        {

            playerdata.Addeffect("Trip", 5);
            GameManager.save();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        
        //playerdata.Addeffect("Trip", 60)
        if (playerdata.Geteffect("Trip") != null)
        {
            Get4DCam().hue += 0.1f * Time.deltaTime;
            timerTrip += 0.01f;
            PlayerCamera.transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 5, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 5, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 5);

            //playermatinvisible
        }
        if (playerdata.Geteffect("Trin") != null)
        {
            Get4DCam().hue += 0.1f * Time.deltaTime;
            hpregen += 600;
            maxhp += 30000;
            //playermatinvisible
        }
        axelerate = 0;
        if (playerdata.Geteffect("Axelerate") != null)
        {
            axelerate += 2;

            //playermatinvisible
        }
        if (playerdata.Geteffect("BoreDomLibido") != null)
        {
            if (fl) 
            {

                fl.minlibido = 6;
                fl.porogvozbujenia = 1;
                fl.porogvozbujeniamin = 1;
                fl.porogvozbujeniamax = 1;
            }
        }
        if (playerdata.Geteffect("█_█__██") != null)
        {
            RaycastHit hit = MainRay.MainHit;
            if(hit.point.ToString()!= uniepos.ToString())
            {
                rigidbody3d.mass = Global.Random.Range(0, 400);
                rigidbody3d.linearDamping = Global.Random.Range(0, 400);
                rigidbody3d.linearVelocity += Global.math.randomCube(-1, 1);
                uniepos = hit.point;
            }
        }
        if (playerdata.Geteffect("Vampaire") != null)
        {
            RaycastHit hit = MainRay.MainHit;
            if (inputE)
            {
                if (hit.collider != null)
                {
                    Globalprefs.socksObj = hit.collider.gameObject;
                    Instantiate(Resources.Load<GameObject>("Voices/сосание"));
                }
                if (hit.collider == null)
                {
                    Instantiate(Resources.Load<GameObject>("Voices/сосание"));
                }
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                playerdata.Addeffect("KsenoMorfin", 600);
                int index = 0;
                for (int i = 0; i < Map_saver.t5.Length; i++)
                {
                    if (Map_saver.t5[i].CompareTag("FlyingMouse"))
                    {
                        index = i; break;
                    }
                }
                VarSave.SetInt("CurrentMorf", index);
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                playerdata.Addeffect("KsenoMorfin", 600);
                int index = 0;
                for (int i = 0; i < Map_saver.t5.Length; i++)
                {
                    if (Map_saver.t5[i].name == "Ctulchu")
                    {
                        index = i; break;
                    }
                }
                VarSave.SetInt("CurrentMorf", index);
            }
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                playerdata.hasClearEffect("KsenoMorfin");
               
            }

        }
        if (VarSave.GetFloat("SevenSouls") > 0)
        {
           if(Globalprefs.LoadTevroPrise(0)<1000000)
            {
                Globalprefs.LoadTevroPrise(1000000 - Globalprefs.LoadTevroPrise(0));
            }

            fireInk = 0;
            Directory.CreateDirectory("debug");
            Get4DCam().hue += 1f * Time.deltaTime;
        }
        if (playerdata.Geteffect("BigShot") != null)
        {
            timerFlowUp += Time.deltaTime;
            if (timerFlowUp >= 5)
            {
                if (Sutck.day != 0) Globalprefs.LoadTevroPrise( Globalprefs.flowteuvro);
                timerFlowUp = 0;
            }
            if (!big)
            {
                Instantiate(Resources.Load("audios/BigShot"));
                big = true;
            }
            //playermatinvisible
        }
        if (playerdata.Geteffect("Шизфрения") != null)
        {

            if (!big)
            {
                Instantiate(Resources.Load("audios/Шиза"));
                big = true;
            }
            //playermatinvisible
        }
        if (playerdata.Geteffect("Шизфрения") == null)
        {

            big = false;
            //playermatinvisible
        }
        if (playerdata.Geteffect("Совиное Зрение") != null)
        {

            if (!soveVision)
            {
                Instantiate(Resources.Load("ui/info/backcamera"));
                soveVision = true; 
            }
            //playermatinvisible
        }
        if (playerdata.Geteffect("Совиное Зрение") == null)
        {

            soveVision = false;
            //playermatinvisible
        }
        if (playerdata.Geteffect("novision") != null)
        {

            if (!noVision)
            {
                nov = Instantiate(Resources.Load<GameObject>("NoVision"));
                noVision = true;
            }
            //playermatinvisible
        }
        if (playerdata.Geteffect("novision") == null)
        {
            Destroy(nov);
            noVision = false;
            //playermatinvisible
        }
        if (playerdata.Geteffect("Все Зрение") != null)
        {

            if (!allVision)
            {
                Instantiate(Resources.Load("CameraRandomObject"));
                allVision = true;
            }
            //playermatinvisible
        }
        if (playerdata.Geteffect("Все Зрение") == null)
        {

            allVision = false;
            //playermatinvisible
        }
        //Совиное Зрение
        hpregen = 0;
        maxhp = 0;
        //ImbalenceRegeneration
        if (playerdata.Geteffect("MetabolismUp") != null)
        {
            // axelerate = 2;
            Time.timeScale = 0.8f;
            fireInk = 20;
            hpregen += 1;
            maxhp += 250;
            //playermatinvisible
        }
        if (playerdata.Geteffect("Metabolism") != null)
        {
            // axelerate = 2;
            Time.timeScale = 0.3f;
            //playermatinvisible
        }
        if (playerdata.Geteffect("Regeneration") != null)
        {
            // axelerate = 2;
            //  Time.timeScale = 0.8f;
            //   fireInk = 20;
            hpregen += 10;
            maxhp += 300;
            //playermatinvisible
        }
        if (playerdata.Geteffect("ImbalenceRegeneration") != null)
        {
            // axelerate = 2;
            //  Time.timeScale = 0.8f;
            //   fireInk = 20;
            axelerate += 2;
            hpregen += 100000;
            maxhp += 300000;
            //playermatinvisible
        }
        if (PolitDate.IsGood(politicfreedom.NonPositionalian))
        {

            capsuleCollider.enabled = false;
          if (GetComponent<BoxCollider>())  GetComponent<BoxCollider>().enabled = false;
        }
            if (playerdata.Geteffect("█_GodMode_█") != null)
        {
            god = true;
            Directory.CreateDirectory("debug");
            capsuleCollider.enabled = false;
            if (GetComponent<BoxCollider>()) GetComponent<BoxCollider>().enabled = false;
        }
        if (playerdata.Geteffect("█_GodMode_█") == null)
        {
            for (int i =0;i<2;i++)
            {


                if (i == 0)
                {
                    if (god)
                    {
                        Directory.Delete("debug");
                    }
                }
                if (i == 1)
                {
                    god = false;
                    if (!PolitDate.IsGood(politicfreedom.NonPositionalian))
                    {
                        capsuleCollider.enabled = true;
                        if (GetComponent<BoxCollider>()) GetComponent<BoxCollider>().enabled = true;
                    }
                }
            }
            }
            //█_GodMode_█
            if (playerdata.Geteffect("-1FPS") != null)
        {
            _n1fps = true;
            TimeLoad(4);
            Global.PauseManager.Pause();
            // axelerate = 2;
            //  Time.timeScale = 0.8f;
            //   fireInk = 20;
            //playermatinvisible
        }
        if (playerdata.Geteffect("-1FPS") == null)
        {

            if (_n1fps) { Global.PauseManager.Play();
                _n1fps = false;
            }
                // axelerate = 2;
                //  Time.timeScale = 0.8f;
                //   fireInk = 20;
                //playermatinvisible
            }
        //-1FPS


        if (playerdata.Geteffect("Tripl2") != null)
        {

            Get4DCam().hue += 0.1f * Time.deltaTime;
            timerTrip += 0.01f;
            PlayerCamera.transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);
            transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);
            //  HeadCameraSetup.transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);

            //playermatinvisible
        }
        if (playerdata.Geteffect("Tripl3") != null)
        {
            Get4DCam()._ChaosColor = UnityEngine.Random.ColorHSV() + new Color(0,0,0,1);
            Get4DCam().hue += 1f * Time.deltaTime;
           //  HeadCameraSetup.transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);

            //playermatinvisible
        }

        if (playerdata.Geteffect("mild hangover") != null)
        {

            timerTrip += 0.01f;
            PlayerCamera.transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 12, 0, 0);
            //  transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);
            //  HeadCameraSetup.transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);

            //playermatinvisible
        }
        if (playerdata.Geteffect("severe hangover") != null)
        {

            timerTrip += 0.1f;
            PlayerCamera.transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) * 8, 0, 0);
            //  transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);
            //  HeadCameraSetup.transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);

            //playermatinvisible
        }
        if (playerdata.Geteffect("InfaltionUp") != null)
        {

            VarSave.LoadMoney("Inflation", 0.1m, SaveType.global);
            //  transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);
            //  HeadCameraSetup.transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);

            //playermatinvisible
        }
        //playerdata.Addeffect("meat", 10);
        if (playerdata.Geteffect("meat") != null)
        {
            PlayerCamera.transform.Rotate(Global.Random.Range(-1f, 1f), Global.Random.Range(-1f, 1f), Global.Random.Range(-1f, 1f));
            transform.Rotate(Global.Random.Range(-1f, 1f), Global.Random.Range(-1f, 1f), Global.Random.Range(-1f, 1f));
            meat = 1;
            //  transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);
            //  HeadCameraSetup.transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);

            //playermatinvisible
        }
        if (playerdata.Geteffect("meat") == null)
        {
           meat = 0;
            //  transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);
            //  HeadCameraSetup.transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);

            //playermatinvisible
        }
        playerdata.checkeffect();
      //  GameManager.GetUF();
    }
    int meat;
  static public  mover Instance;
    public static mover main()
    {
        if (Instance == null)
        {
            Instance = FindFirstObjectByType<mover>();
        }
        return Instance;
    }
    float timer9;
    public void TimeSave()
    {
        if (!PlayerMechanics.Active(MechanicId.Timeline)) return;


        timer9 += Time.deltaTime;
        if (timer9 >= .1f && !inputGpress && !_n1fps) {
            VarSave.LoadMoney(SceneManager.GetActiveScene().buildIndex.ToString() + "_SceneTime", 1);
            string patch = "";
            int timeString = 10;
            for (int i =0;i < VarSave.GetMoney(SceneManager.GetActiveScene().buildIndex.ToString() + "_SceneTime").ToString().Length;i++)
            {
                timeString -= 1;
            }
            for (int i = 0;i<timeString;i++)
            {
                patch += "0";
            }
            patch += VarSave.GetMoney(SceneManager.GetActiveScene().buildIndex.ToString() + "_SceneTime").ToString();
            tsave.timesave = patch;
            tsave.angularvelosyty = rigidbody3d.angularVelocity;
            tsave.velosyty = rigidbody3d.linearVelocity;
            tsave.q1 = PlayerBody.transform.rotation;
            tsave.q2 = PlayerCamera.transform.rotation;
            tsave.pos = PlayerBody.transform.position;
            tsave.wpos = W_position; 
            tsave.hpos = H_position;
            tsave.hxrot = HX_Rotation;
            tsave.npos = N_position;
            tsave.cnpos = cur_N_position;
            if (Get4DCam()) tsave.rotW = Get4DCam()._wRotation;
            if (HyperbolicCamera.Main() != null)
            {


                tsave.hpos_Polar3 = JsonUtility.ToJson(HyperbolicCamera.Main().RealtimeTransform);
            }
          if(mainCamera)  tsave.vive = mainCamera.fieldOfView;

            tsave.idsave = SaveFileInputField.text;
            Directory.CreateDirectory("unsave/captert" + SceneManager.GetActiveScene().buildIndex+"/" + Globalprefs.GetTimeline());
            DirectoryInfo di = new("unsave/captert" + SceneManager.GetActiveScene().buildIndex + "/" + Globalprefs.GetTimeline());
           
            File.WriteAllText("unsave/captert" + SceneManager.GetActiveScene().buildIndex + "/" + Globalprefs.GetTimeline() + "/" + SaveFileInputField.text + tsave.timesave, JsonUtility.ToJson(tsave));

            timer9 = 0;
            if (di.GetFiles().Length > 500)
            {
                File.Delete(di.GetFiles()[0].FullName);
            }
        }
    }
    public void SucksEnd()
    {
        Instantiate(Resources.Load<GameObject>("items/Куча_дерьма"), Globalprefs.socksObj.transform.position,Quaternion.identity);
        Destroy(Globalprefs.socksObj);
    }
    public void saveing()
    {
        
            if (playerdata.Geteffect("LevelUp") != null)
            {
                VarSave.SetInt("progress", gsave.progressofthepassage + 1);
                gsave.progressofthepassage += 1;
                GameManager.chargescene(0);

                playerdata.Cleareffect();
            }
       
            playerdata.Saveeffect();
        
        if (!tutorial)
        {


         //   if (GameObject.Find("w2"))
         //   {
              //  GameObject.Find("w2").GetComponent<pos4>().Save();
         //   }
            save.angularvelosyty = rigidbody3d.angularVelocity;
            save.velosyty = rigidbody3d.linearVelocity;
            save.q1 = PlayerBody.transform.rotation;
            save.q2 = PlayerCamera.transform.rotation;
            save.pos = PlayerBody.transform.position;
            save.wpos = W_position;

            save.npos = N_position;
            save.cnpos = cur_N_position;
            save.hpos = H_position;
            save.hxrot = HX_Rotation;
            if (Get4DCam()) save.rotW = Get4DCam()._wRotation;
            if (hyperbolicCamera != null)
            {


                save.hpos_Polar3 = JsonUtility.ToJson(HyperbolicCamera.Main().RealtimeTransform);
            }
            save.vive = mainCamera.fieldOfView;
            gsave.hp = hp;
            gsave.oxygen = oxygen;
            gsave.fv = faceViewi;
            gsave.PlayerScale = CamDistanceMult;

            save.idsave = SaveFileInputField.text;
            Directory.CreateDirectory("unsave/capter" + SceneManager.GetActiveScene().buildIndex );
            File.WriteAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + SaveFileInputField.text, JsonUtility.ToJson(save));
            gsave.idsave = SaveFileInputField.text;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsave/capterg/" + SaveFileInputField.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = SaveFileInputField.text;
            File.WriteAllText("unsave/s", s);
            WorldSave.SetVector4("var");
            WorldSave.SetVector3("var1");
        }
        else
        {
         //   if (GameObject.Find("w2"))
         //   {
            //    GameObject.Find("w2").GetComponent<pos4>().Save();
         //   }
            save.angularvelosyty = rigidbody3d.angularVelocity;
            save.velosyty = rigidbody3d.linearVelocity;
            save.q1 = PlayerBody.transform.rotation;
            save.q2 = PlayerCamera.transform.rotation;
            save.pos = PlayerBody.transform.position;
            save.vive = mainCamera.fieldOfView;
            save.wpos = W_position;
            save.hpos = H_position;
            save.npos = N_position;
            save.cnpos = cur_N_position;
            save.hxrot = HX_Rotation;
            if (Get4DCam()) save.rotW = Get4DCam()._wRotation;
            if (hyperbolicCamera!=null)
            {

                save.hpos_Polar3 = JsonUtility.ToJson(HyperbolicCamera.Main().RealtimeTransform);
            }
            tsave.angularvelosyty = rigidbody3d.angularVelocity;
            tsave.velosyty = rigidbody3d.linearVelocity;
            tsave.q1 = PlayerBody.transform.rotation;
            tsave.q2 = PlayerCamera.transform.rotation;
            tsave.pos = PlayerBody.transform.position;
            tsave.vive = mainCamera.fieldOfView;
            tsave.wpos = W_position;

            tsave.hpos = H_position;
            gsave.hp = hp;
            gsave.oxygen = oxygen;
            gsave.PlayerScale = CamDistanceMult;
            gsave.fv = faceViewi;
            Directory.CreateDirectory("unsavet/capter" + SceneManager.GetActiveScene().buildIndex );
            File.WriteAllText("unsavet/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + SaveFileInputField.text, JsonUtility.ToJson(save));
          
         
            WorldSave.SetVector4("var");
            WorldSave.SetVector3("var1");
        }
    }
  
    
    public void deleteing()
    {

        if (!tutorial)
        {
            File.Delete("unsave/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + SaveFileInputField.text);
            
        }
        else
        {
            File.Delete("unsavet/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text);
            WorldSave.RemoveVector3();
        }

    }
}


