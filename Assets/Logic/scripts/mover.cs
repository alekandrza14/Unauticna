using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using System;
using UnityEngine.ProBuilder.MeshOperations;
using System.Runtime.ExceptionServices;

public class load1
{
    static public float tjump;
    static public float jump;
    static public float rjump;
    static public bool islight;
    static public bool isCamd;
    static public bool isplanet;
    static public bool stad;
    public static Hyperbolic2D pt;
    static public RawImage watermask;
    static public float gr; static public float pl;
    static public Color bg; static public CameraClearFlags bg2;
}
public class save
{
    public string idsave;
    public Vector3 pos, pos2, rotW;
    public Vector4 pos3;
    public string hpos_Polar3;
    public float wpos;
    public List<float> npos = new List<float>();
    public int cnpos = 0;
    public float hpos;
    public float hxrot;
    public Quaternion q1, q2, q3, q4;
    public Vector3 velosyty; public Vector3 angularvelosyty;
    public float vive;
}
public class tsave
{

    public string idsave;
    public string timesave;
    public Vector3 pos, pos2, rotW;
    public Vector4 pos3;
    public string hpos_Polar3;
    public float wpos;
    public List<float> npos = new List<float>();
    public int cnpos = 0;
    public float hpos;
    public float hxrot;
    public Quaternion q1, q2, q3, q4;
    public Vector3 velosyty; public Vector3 angularvelosyty;
    public float vive;
}
public class gsave
{
    public int progressofthepassage = 0;
    public int hp;
    public float oxygen;
    public faceView fv;
    public int Spos;
    public DateTime starttimepos;
    public string DateTimeJson;
    public string idsave;
    public int sceneid;
    public List<string> inventory = new List<string>();
    public List<string> inventoryname = new List<string>();
}

public enum faceView
{
    first ,trid,fourd
}

public class mover : MonoBehaviour
{
    public GameObject PlayerBody;
    public GameObject PlayerCamera;
    [SerializeField] bool isplanet;
    [SerializeField] bool tutorial;
    [SerializeField] bool tutorialsave;
    [SerializeField] bool islight = false;
    [SerializeField] bool inglobalspace;
    [SerializeField] float jumpforse;
    [SerializeField] float jumpPower;
    [SerializeField] public float gravity; 
    [SerializeField] float ForseSwaem;
    [SerializeField] Rigidbody rigidbody3d;
    [SerializeField] float Speed;
    [SerializeField] Animator animator;
    [SerializeField] Animator[] SkinedAnimators;
    save save = new save();
    tsave tsave = new tsave();
  public  gsave gsave = new gsave();

    [SerializeField] public float W_position;
    [SerializeField] public float H_position;
    [SerializeField] public List<float> N_position = new List<float>()
    {
        0
    };
    [SerializeField] public int cur_N_position;
    public int planet_position;
    public InputField SaveFileInputField;
    float JumpTimer;
    [HideInInspector] public bool IsGraund;
    [HideInInspector] public bool InWater;
    bool LateInWater;
    Collision c;
    float ZoomConficent = 0.04f;
    [SerializeField] RawImage watermask;
    float fog = 1000;  float fog2 = 1000;
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
   public PlayerDNA DNA = new PlayerDNA();
    public Material DebugMat;
    faceView faceViewi;
    bool Sprint;
    float fireInk;
    string lepts = "";
    [HideInInspector] public string lif;
    [HideInInspector] public float HX_Rotation;

    void swapHX3(Transform x, mover w)
    {
        RaymarchCam m = Get4DCam();
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
        
        if (w.HX_Rotation == 0) w.HX_Rotation  =- 90; else w.HX_Rotation = 0;
        

    }
    public static RaymarchCam maincam4;
    public static RaymarchCam Get4DCam()
    {
     if(!maincam4)   maincam4 = (RaymarchCam)FindAnyObjectByType(typeof(RaymarchCam)); else return maincam4 = (RaymarchCam)FindAnyObjectByType(typeof(RaymarchCam));
        return maincam4;
    }
    DateTime timeUnauticna()
    {
        DateTime _new = new DateTime((int)6599, (int)7, (int)22, (int)3, (int)46, (int)23);
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
        DateTime id2 = (gsave.starttimepos);
        DateTime v = timeUnauticna();
        int year = (v.Year + (id.Year - id2.Year));
        int Month = (int)fmod2((float)(v.Month + (id.Month - id2.Month)), 12f);
        int Day = (int)fmod2((float)(v.Day + (id.Day - id2.Day)), 30f);
        int Hour = (int)fmod2((float)(v.Hour + (id.Hour - id2.Hour)), 60f);
        int Minute = (int)fmod2((float)(v.Minute + (id.Minute - id2.Minute)), 60f);
        _new = "30" + year + " г. " +Month+ " м. " + Day + " д. " +Hour + " ч. " +Minute + " м. ";
        return _new;
    }
    void Building()
    {

        string vaule1 = "";
        string vaule2 = "";
        lif = Globalprefs.GetIdPlanet().ToString();
        lif += "_" + Globalprefs.GetTimeline();
        if (GlobalInputMenager.KeyCode_build != "")
        {
            vaule1 = GlobalInputMenager.KeyCode_build;
            RaycastHit hit = MainRay.MainHit;
           
                if (hit.collider != null && Input.GetKeyDown(KeyCode.Tab))
                {
                    genmodel g = Instantiate(Resources.Load<GameObject>("Custom model"), hit.point, Quaternion.identity).GetComponent<genmodel>();
                    g.s = vaule1;
                    g.gameObject.transform.position = hit.point;
                    List<string> name = new List<string>();
                    List<Vector3> v3 = new List<Vector3>();
                    for (int i = 0; i < GameObject.FindObjectsByType<genmodel>(sortmode.main).Length; i++)
                    {
                        name.Add(FindObjectsByType<genmodel>(sortmode.main)[i].s);
                        v3.Add(FindObjectsByType<genmodel>(sortmode.main)[i].transform.position);
                    }
                    custommedelsave cms = new custommedelsave();
                    cms.name = name.ToArray();
                    cms.v3 = v3.ToArray();
                    VarSave.SetString("cms" + SceneManager.GetActiveScene().buildIndex + lif, JsonUtility.ToJson(cms), SaveType.world);
                    GlobalInputMenager.build.text = "";

                }



        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            List<string> name = new List<string>();
            List<Vector3> v3 = new List<Vector3>();
            List<Vector3> scale = new List<Vector3>();
            for (int i = 0; i < GameObject.FindObjectsByType<genmodel>(sortmode.main).Length; i++)
            {
                name.Add(FindObjectsByType<genmodel>(sortmode.main)[i].s);
                v3.Add(FindObjectsByType<genmodel>(sortmode.main)[i].transform.position);
                scale.Add(FindObjectsByType<genmodel>(sortmode.main)[i].transform.localScale);
            }
            custommedelsave cms = new custommedelsave();
            cms.name = name.ToArray();
            cms.v3 = v3.ToArray();
            cms.scale = scale.ToArray();

            VarSave.SetString("cms" + SceneManager.GetActiveScene().buildIndex + lif, JsonUtility.ToJson(cms), SaveType.world);

        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            for (int i = 0; i < FindObjectsByType<genmodel>(sortmode.main).Length; i++)
            {
                FindObjectsByType<genmodel>(sortmode.main)[i].gameObject.AddComponent<deleter1>();
            }
            custommedelsave cms = JsonUtility.FromJson<custommedelsave>(VarSave.GetString("cms" + SceneManager.GetActiveScene().buildIndex + lif, SaveType.world));
            for (int i = 0; i < cms.v3.Length; i++)
            {
                genmodel g = Instantiate(Resources.Load<GameObject>("Custom model"), cms.v3[i], Quaternion.identity).GetComponent<genmodel>();
                g.s = cms.name[i];
                g.transform.localScale = cms.scale[i];

            }
        }
            bool j = Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace);
            RaycastHit hit2 = MainRay.MainHit;
            
                if (hit2.collider != null && j)
                {
                    if (hit2.collider.GetComponent<genmodel>())
                    {
                        hit2.collider.gameObject.AddComponent<DELETE>();
                        List<string> name = new List<string>();
                        List<Vector3> v3 = new List<Vector3>();
                        for (int i = 0; i < GameObject.FindObjectsByType<genmodel>(sortmode.main).Length; i++)
                        {
                            name.Add(FindObjectsByType<genmodel>(sortmode.main)[i].s);
                            v3.Add(FindObjectsByType<genmodel>(sortmode.main)[i].transform.position);
                        }
                        custommedelsave cms = new custommedelsave();
                        cms.name = name.ToArray();
                        cms.v3 = v3.ToArray();
                        if (GameObject.FindObjectsByType<genmodel>(sortmode.main).Length >= 2) { VarSave.SetString("cms" + SceneManager.GetActiveScene().buildIndex + lif, JsonUtility.ToJson(cms), SaveType.world); }
                        else
                        {
                            cms.name = new string[] { };
                            cms.v3 = new Vector3[] { };
                            VarSave.SetString("cms" + SceneManager.GetActiveScene().buildIndex + lif, JsonUtility.ToJson(cms), SaveType.world);
                        }
                    }
                }
          


        
        if (GlobalInputMenager.KeyCode_Spawn != "")
        {
            vaule2 = GlobalInputMenager.KeyCode_Spawn;
            RaycastHit hit = MainRay.MainHit;
          

                if (hit.collider != null && Input.GetKeyDown(KeyCode.Tab))
                {
                    telo g = Instantiate(Resources.Load<GameObject>("Custom Creature"), hit.point, Quaternion.identity).GetComponent<telo>();
                    g.nameCreature = vaule2;
                    g.gameObject.transform.position = hit.point;
                    GlobalInputMenager.KeyCode_Spawn = "";

                }
            

        }
    }
    public faceView GetViewFace()
    {
        return faceViewi;
    }
    public void SetViewFace(faceView a)
    {
       faceViewi =a;
    }
    public Vector4 GetHyperbolicVector(HyperbolicCamera c1)
    {
        Vector4 v4 = new Vector4();
        v4.x = c1.RealtimeTransform.n;
        v4.y = c1.RealtimeTransform.s;
        v4.z = c1.RealtimeTransform.m;
        v4.w = c1.transform.position.y;
        return v4;
    }
    public void LoadHyperbolicVector(Vector4 v4,HyperbolicCamera c1)
    {
        c1.RealtimeTransform.n = v4.x;
        c1.RealtimeTransform.s = v4.y;
        c1.RealtimeTransform.m = v4.z;
        c1.transform.position = new Vector3(0,v4.w,0);

    }
    //физика
    void OnCollisionStay(Collision collision)
    {

        if (collision.collider.tag != "sc" && !Input.GetKey(KeyCode.G)) if (JumpTimer < -2)
        {
            Debug.Log(JumpTimer);
            hp += Mathf.FloorToInt(JumpTimer) / 3;
            }
        if (collision.collider.tag != "sc" && Input.GetKey(KeyCode.Space)) JumpTimer = jumpPower;


        if (collision.collider.tag != "sc" && !Input.GetKey(KeyCode.Space)) JumpTimer = 0;
        if (InWater)
        {
            IsGraund = false;
            JumpTimer = 0;
        }
        c = collision;
        if (collision.collider.tag == "sc")
        {
            
        //IsGraund = false;

        }

        if (collision.collider.tag == "sc2")
        {
            
            
                JumpTimer = -jumpPower / 2;
                s2 = false;
             if(GravityConstant() > -0)   IsGraund = true;

            
           

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Logic_tag_DamageObject>())
        {
            hp -= 2;
        }
        if (collision.collider.GetComponent<fire>())
        {
            if (fireInk+10 < 100)
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
        if (other.tag == "dead")
        {
            VarSave.SetBool("обычный сельский бог гипер смерти урбил вас", true);
            VarSave.SetBool("cry", true);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        if (other.tag == "airhole")
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
        if (other.tag == "lagi")
        {
            PlayerCamera.GetComponent<Camera>().enabled = 1 ==UnityEngine.Random.Range(0, 3);

        }

        if (other.GetComponent<FreedomOxygen>()) oxygen = 20;
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<notswiming>())
        {
            InWater = false;

        }
        if (other.tag == "lagi")
        {
            PlayerCamera.GetComponent<Camera>().enabled = true;

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
        Debug.Log("log");
    }

    //Пробуждение кода
    private void Awake()
    {
        Init();
      //  DNA = JsonUtility.FromJson
#if !UNITY_EDITOR
        dnSpyModer.MainModData.LoadScene();
#endif
    }
    Color c1;
    int maxhp2;
    int regen;
    bool swapWHaN;
    private void Init()
    {
        Globalprefs.GetRealiyHash(4);
        if (!string.IsNullOrEmpty(gsave.DateTimeJson)) gsave.starttimepos = DateTime.Parse(gsave.DateTimeJson);
        else gsave.starttimepos = DateTime.Now;

        if (N_position.Count <= 0) N_position.Add(0);
        if (FindObjectsByType<MultyTransform>(sortmode.main).Length == 0)
        {


            GameObject g = new GameObject("4D Controler")
            {

            };


            g.AddComponent<MultyTransform>();
        }
        Instantiate(Resources.Load<GameObject>("audios/Nill"), transform.position, Quaternion.identity);
        if (VarSave.ExistenceVar("DNA"))
        {
            DNA = JsonUtility.FromJson<PlayerDNA>(VarSave.GetString("DNA"));
            c1 = DNA.colour;
            Time.timeScale = DNA.metabolism;
            jumpPower += DNA.Jumping;
            maxhp2 = (int)DNA.hp;
            regen = (int)DNA.regeneration;
        }
        jumpPower += Globalprefs.GetRealiyChaos(4);
        cistalenemy.dies = VarSave.LoadInt("Agr",0);
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
        float Chance = 100 / (VarSave.GetFloat("ChancePiratAttack" + "_gameSettings", SaveType.global) * 100f+Globalprefs.GetRealiyChaos(50));
        if (UnityEngine.Random.Range(0, (int)Chance + 1) == 0)
        {
            Debug.Log("CahncePiratAttack" + (int)Chance);
            Instantiate(Resources.Load<GameObject>("events/Pirats"));
        }
        float Chance2 = 100 / (VarSave.GetFloat("ChanceUMUTaxes" + "_gameSettings", SaveType.global) * 100f + Globalprefs.GetRealiyChaos(50));
        if (UnityEngine.Random.Range(0, (int)Chance2 + 1) == 0)
        {
            cistalenemy.dies -= 2;
            VarSave.LoadMoney("tevro", -100);
        }
        float Chance3 = 100 / (VarSave.GetFloat("ChanceDegradation" + "_gameSettings", SaveType.global) * 100f + Globalprefs.GetRealiyChaos(50));
        if (UnityEngine.Random.Range(0, (int)Chance3 + 1) == 0)
        {
            DirectoryInfo di = new DirectoryInfo("unsave/var/researchs");
            int random = UnityEngine.Random.Range(0,di.GetFiles().Length);
           File.Delete( di.GetFiles()[random].FullName);
            VarSave.LoadMoney("research",-1);
        }
        if (timer7 != LastSesionHours)
        {
            
          //      VarSave.LoadMoney("tevro", UnityEngine.Random.Range(150,600) * VarSave.LoadMoney("Stocks", 0));
             


              //      VarSave.SetMoney("Stocks", 0);
            
            
            
            
        }
        decimal cashFlow = ((timer5 - LastSesion) * VarSave.GetMoney("CashFlow"));
        VarSave.LoadMoney("tevro", cashFlow);
        fireInk = VarSave.GetFloat("FireInk");
        hyperbolicCamera = HyperbolicCamera.Main();
        StartCoroutine(coroutine());
        Globalprefs.bunkrot = VarSave.GetBool("Bunkrot");
        Globalprefs.research = VarSave.GetMoney("research");
        Globalprefs.technologies = VarSave.GetMoney("_technologies");
        Globalprefs.flowteuvro = VarSave.GetMoney("CashFlow")+ ((decimal)Globalprefs.GetRealiyChaos(10f)/100);
        Globalprefs.Infinitysteuvro = VarSave.GetTrash("inftevro");
        Globalprefs.OverFlowteuvro = VarSave.GetInt("uptevro");
        lif = Globalprefs.GetIdPlanet().ToString();
        lif += "_" + Globalprefs.GetTimeline();
        if (VarSave.ExistenceVar("cms" + SceneManager.GetActiveScene().buildIndex + lif,SaveType.world))
        {
            custommedelsave cms = JsonUtility.FromJson<custommedelsave>(VarSave.GetString("cms" + SceneManager.GetActiveScene().buildIndex + lif, SaveType.world));
            for (int i = 0; i < cms.v3.Length; i++)
            {
                genmodel g = Instantiate(Resources.Load<GameObject>("Custom model"), cms.v3[i], Quaternion.identity).GetComponent<genmodel>();
                if (cms.name.Length > i) g.s = cms.name[i];

             if(cms.scale.Length > i)   g.transform.localScale = cms.scale[i];
            }
        }
        SaveFileInputField.text = Globalprefs.GetTimeline();

        if (File.Exists("unsave/capterg/" + SaveFileInputField.text))
        {
            gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + SaveFileInputField.text));
            planet_position = gsave.Spos;
            lepts = "-" + planet_position.ToString();
        }
        stand_stay = load1.stad;

           Camera c = Instantiate(Resources.Load<GameObject>("point"), PlayerCamera.transform).AddComponent<Camera>();
           c.targetDisplay = 2;
           c.targetTexture = new RenderTexture(Screen.width, Screen.height, 1000);
          c.renderingPath = RenderingPath.DeferredShading;

        Globalprefs.camera = c;
        c.gameObject.AddComponent<Logic_tag_3>();

        if (isplanet)
        {
            gameObject.AddComponent<PlanetGravity>().body = transform;
            gameObject.GetComponent<PlanetGravity>().gravity = JumpTimer;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        playerdata.Loadeffect();

      if(DNA != null)  playerdata.LoadBakeeffect();
        ionenergy.energy = 0;
        vel = GetComponent<CapsuleCollider>().height;


        Instantiate(Resources.LoadAll<GameObject>("ui/postrender")[0]);


        //four-Dimentional-Axis
        Instantiate(Resources.Load<GameObject>("player inventory"));
        if (VarSave.ExistenceVar("Player_On_Pirat_Attack")) Instantiate(Resources.Load<GameObject>("events/Pirats"));
        if (VarSave.ExistenceGlobalVar("eventPlevraSpamtona"))
        {
            Instantiate(Resources.Load<GameObject>("items/Смачный_плевок_Спамтона"));
            Instantiate(Resources.Load<GameObject>("events/ПлевокСпамтона")); 
        }
        Instantiate(Resources.Load<GameObject>("ui/four-Dimentional-Axis"));
        Instantiate(Resources.Load<GameObject>("player inventory element 2"));
        Instantiate(Resources.Load<GameObject>("Rm/Hyper_null"));
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
                save = JsonUtility.FromJson<save>(File.ReadAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text));
                rigidbody3d.angularVelocity = save.angularvelosyty;
                rigidbody3d.velocity = save.velosyty;

                W_position = save.wpos;
                H_position = save.hpos;
                N_position = save.npos;
                cur_N_position = save.cnpos;
                HX_Rotation = save.hxrot;
                if (portallNumer.Portal == "")
                {

                    PlayerBody.transform.position = save.pos;
                    //  sr.transform.position = save.pos2;
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
                }
                else if (portallNumer.Portal == "WMove+")
                {
                    if (true)
                    {
                        PlayerBody.transform.position = Globalprefs.WMovepos;
                        W_position = -499;
                        if (HyperbolicCamera.Main() != null)
                        {
                            HyperbolicCamera.Main().RealtimeTransform = JsonUtility.FromJson<Hyperbolic2D>(save.hpos_Polar3);
                        }
                        //  sr.transform.position = save.pos2;
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
                        //  sr.transform.position = save.pos2;
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
                PlayerCamera.GetComponent<Camera>().fieldOfView = save.vive;
                if (FindObjectsByType<Logic_tag_3>(sortmode.main).Length != 0)
                {
                    FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = save.vive;
                }
            }
            if (File.Exists("unsave/capterg/" + SaveFileInputField.text))
            {
                gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + SaveFileInputField.text));
                hp = gsave.hp;
                oxygen = gsave.oxygen;
                faceViewi = gsave.fv;
                planet_position = gsave.Spos; if (!string.IsNullOrEmpty(gsave.DateTimeJson)) gsave.starttimepos = DateTime.Parse(gsave.DateTimeJson);
                else gsave.starttimepos = DateTime.Now;
                if (gsave.starttimepos != null)
                {
                    if (gsave.starttimepos.Minute == DateTime.Now.Minute)
                    {

                        gsave.starttimepos = DateTime.Now;
                        gsave.DateTimeJson = gsave.starttimepos.ToString();
                    }
                }

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
                save = JsonUtility.FromJson<save>(File.ReadAllText("unsavet/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text));
                rigidbody3d.angularVelocity = save.angularvelosyty;
                rigidbody3d.velocity = save.velosyty;

                W_position = save.wpos;
                H_position = save.hpos;
                N_position = save.npos;
                cur_N_position = save.cnpos;
                HX_Rotation = save.hxrot;
                if (portallNumer.Portal == "")
                {

                    PlayerBody.transform.position = save.pos;
                    //  sr.transform.position = save.pos2;
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
                }
              else  if (portallNumer.Portal == "WMove+")
                {
                    if (true)
                    {
                        PlayerBody.transform.position = Globalprefs.WMovepos;
                        W_position = -499;
                        if (HyperbolicCamera.Main() != null)
                        {
                            HyperbolicCamera.Main().RealtimeTransform = JsonUtility.FromJson<Hyperbolic2D>(save.hpos_Polar3);
                        }
                        //  sr.transform.position = save.pos2;
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
             else   if (portallNumer.Portal == "WMove-")
                {
                    if (true)
                    {
                        PlayerBody.transform.position = Globalprefs.WMovepos;
                        W_position = 499;
                        if (HyperbolicCamera.Main() != null)
                        {
                            HyperbolicCamera.Main().RealtimeTransform = JsonUtility.FromJson<Hyperbolic2D>(save.hpos_Polar3);
                        }
                        //  sr.transform.position = save.pos2;
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
                PlayerCamera.GetComponent<Camera>().fieldOfView = save.vive;
                if (FindObjectsByType<Logic_tag_3>(sortmode.main).Length != 0)
                {
                    FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = save.vive;
                }
            }
            if (File.Exists("unsavet/capterg/" + SaveFileInputField.text))
            {
                gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsavet/capterg/" + SaveFileInputField.text));
               if(gsave.hp >= 20) hp = gsave.hp; else
                {
                    hp = 20;
                }
                oxygen = gsave.oxygen;
                faceViewi = gsave.fv;
                planet_position = gsave.Spos;
                if (!string.IsNullOrEmpty(gsave.DateTimeJson)) gsave.starttimepos = DateTime.Parse(gsave.DateTimeJson);
                else gsave.starttimepos = DateTime.Now;
                if (gsave.starttimepos != null)
                {
                    if (gsave.starttimepos.Minute == DateTime.Now.Minute)
                    {

                        gsave.starttimepos = DateTime.Now;
                        gsave.DateTimeJson = gsave.starttimepos.ToString();
                    }
                }
            }




        }
        lif = Globalprefs.GetIdPlanet().ToString();
        lif += "_" + Globalprefs.GetTimeline();
        hyperbolicCamera = HyperbolicCamera.Main();
    }

    void UpdateTargets()
    {
        metka = GameObject.FindObjectsByType<Metka>(sortmode.main);
    }
    //Пробуждение кода
    //Приметивный интерфейс
    Metka[] metka;
    private void OnGUI()
    {


        if (metka.Length == 0) metka = GameObject.FindObjectsByType<Metka>(sortmode.main);
     
        if (metka.Length != 0) for (int i = 0; i < metka.Length; i++)
        {

            Vector3 t = Globalprefs.camera.WorldToViewportPoint(metka[i].transform.position);
            if (t.z > 0)
            {
                Vector3 u = Globalprefs.camera.ViewportToScreenPoint(t);
                GUI.DrawTexture(new Rect(u.x - 10, (Screen.height - u.y) - 10, 20, 20), metka[i].GetComponent<MeshRenderer>().sharedMaterial.GetTexture("_MainTex"));
            }
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            GUI.DrawTexture(new Rect((Screen.width / 2) - 10, (Screen.height / 2) - 10, 20, 20), Resources.Load<Texture>("cursor"));
        }
        if (Input.GetKey(KeyCode.F8))
        {
            GUI.Label(new Rect(0f, 0, 200f, 100f), "Unauticna Alpha-version");
            if (!hyperbolicCamera) GUI.Label(new Rect(0f, 20, 200f, 100f), "Euclidian World Position x : " + transform.position.x.ToString() + " y : " + transform.position.y.ToString() + " z : " + transform.position.z.ToString() + " w : " + W_position.ToString());
            if (hyperbolicCamera) GUI.Label(new Rect(0f, 20, 200f, 100f), "Hyperbolic World Position x : " + hyperbolicCamera.RealtimeTransform.n.ToString() + " y : " + hyperbolicCamera.RealtimeTransform.s.ToString() + " z : " + hyperbolicCamera.RealtimeTransform.m.ToString() + " w : " + transform.position.y.ToString() + " h : " + W_position.ToString());
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
                    if (Globalprefs.Infinitysteuvro > 0) GUI.Label(new Rect(0f, 20, 300f, 100f), "Teuvro ($) : ∞ * " + Globalprefs.Infinitysteuvro);
                    else GUI.Label(new Rect(0f, 20, 300f, 100f), "Teuvro ($) : " + Math.Round(VarSave.GetMoney("tevro"), 2));

                }
                else
                {
                     GUI.Label(new Rect(0f, 20, 300f, 100f), "Teuvro ($) : " + Math.Round(VarSave.GetMoney("tevro"), 2));
                }
            }
                if (playerdata.Geteffect("No kapitalism") != null) GUI.Label(new Rect(0f, 20, 300f, 100f), "Teuvro ($) : " + "∞");
            GUI.Label(new Rect(0f, 40, 300f, 100f), "Flow Teuvro on hour ($^) : " + Math.Round(Globalprefs.flowteuvro, 2));
            GUI.Label(new Rect(0f, 60, 200f, 100f), "Bunkrot : " + Globalprefs.bunkrot);
            GUI.Label(new Rect(0f, 80, 200f, 100f), "Item price : " + Globalprefs.ItemPrise * (Globalprefs.GetProcentInflitiuon() + 1));
            GUI.Label(new Rect(0f, 100, 200f, 100f), "Scientific research (?) : " + Globalprefs.research);
            GUI.Label(new Rect(0f, 120, 200f, 100f), "Knowlages (!) : " + (Globalprefs.knowlages + gsave.progressofthepassage).ToString());
            GUI.Label(new Rect(0f, 140, 200f, 100f), "Technologies (!^) : " + Globalprefs.technologies);
            GUI.Label(new Rect(0f, 160, 200f, 100f), "Universe Type (*) : " + (UniverseSkyType)VarSave.GetInt("UST"));
            if (playerdata.Geteffect("Undyning") == null) GUI.Label(new Rect(0f, 180, 200f, 100f), "Healf Point (♥) : " + hp);
            if (playerdata.Geteffect("Undyning") != null) GUI.Label(new Rect(0f, 180, 200f, 100f), "Healf Point (♥) : " + "∞ ok is this mean we don't dyeing?");
            GUI.Label(new Rect(0f, 200, 200f, 100f), "Fire (▲) : " + fireInk);
            GUI.Label(new Rect(0f, 220, 200f, 100f), "Stocks ($*) : " + VarSave.LoadMoney("Stocks", 0));
            GUI.Label(new Rect(0f, 240, 200f, 100f), "violation of the pacific regime (V^V) : " + cistalenemy.dies);
            GUI.Label(new Rect(0f, 270, 200f, 100f), "Inflation : " + VarSave.GetMoney("Inflation", SaveType.global) + "%");
            if (VarSave.GetString("ProfStatus") !="")
            { 
                GUI.Label(new Rect(0f, 300, 200f, 100f), "ProfStatus : " + VarSave.GetString("ProfStatus"));
            }
            else 
            {
                GUI.Label(new Rect(0f, 300, 200f, 100f), "ProfStatus : " + "Unknown");
            }
            //cistalenemy.dies


        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (CosProgress() <= 1)
            {
                GUI.Label(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 10, (Screen.width / 2) + 100, (Screen.height / 2) + 30), "4D move : " + Sprint.ToString());
                if (!hyperbolicCamera && gameObject.layer == 2) Globalprefs.PlayerPositionInfo = "Euclidian World Position x : " + transform.position.x.ToString() + " y : " + transform.position.y.ToString() + " z : " + transform.position.z.ToString() + " w : " + W_position.ToString();
                else if (hyperbolicCamera) Globalprefs.PlayerPositionInfo = "Hyperbolic World Position x : " + hyperbolicCamera.RealtimeTransform.s.ToString() + " y : " + transform.position.y.ToString() + " z : " + hyperbolicCamera.RealtimeTransform.m.ToString() + " w : " + W_position.ToString();
                if (gameObject.layer == 11) Globalprefs.PlayerPositionInfo = "Liminal World Position x : " + transform.position.x.ToString() + " y : " + transform.position.y.ToString() + " z : " + transform.position.z.ToString() + " s : " + "1";
                if (gameObject.layer == 12) Globalprefs.PlayerPositionInfo = "Liminal World Position x : " + transform.position.x.ToString() + " y : " + transform.position.y.ToString() + " z : " + transform.position.z.ToString() + " s : " + "2";
            }
            if (CosProgress() > 1 && CosProgress() <= 2)
            {
                GUI.Label(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 10, (Screen.width / 2) + 100, (Screen.height / 2) + 30), "4D move : " + Sprint.ToString());
                if (!hyperbolicCamera && gameObject.layer == 2) Globalprefs.PlayerPositionInfo = "Euclidian World Position x : " + transform.position.x.ToString() + " y : " + transform.position.y.ToString() + " z : " + transform.position.z.ToString() + " w : " + W_position.ToString() + " h : " + H_position.ToString();
                else if (hyperbolicCamera) Globalprefs.PlayerPositionInfo = "Hyperbolic World Position x : " + hyperbolicCamera.RealtimeTransform.s.ToString() + " y : " + transform.position.y.ToString() + " z : " + hyperbolicCamera.RealtimeTransform.m.ToString() + " w : " + W_position.ToString() + " h : " + H_position.ToString();
                if (gameObject.layer == 11) Globalprefs.PlayerPositionInfo = "Liminal World Position x : " + transform.position.x.ToString() + " y : " + transform.position.y.ToString() + " z : " + transform.position.z.ToString() + " s : " + "1" + " h : " + H_position.ToString();
                if (gameObject.layer == 12) Globalprefs.PlayerPositionInfo = "Liminal World Position x : " + transform.position.x.ToString() + " y : " + transform.position.y.ToString() + " z : " + transform.position.z.ToString() + " s : " + "2" + " h : " + H_position.ToString();
            }
            if (CosProgress() > 2)
            {

                if (N_position.Count <= 0) N_position.Add(0);
                GUI.Label(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 10, (Screen.width / 2) + 100, (Screen.height / 2) + 30), "4D move : " + Sprint.ToString());
                if (!hyperbolicCamera && gameObject.layer == 2) Globalprefs.PlayerPositionInfo = "Euclidian World Position x : " + transform.position.x.ToString() + " y : " + transform.position.y.ToString() + " z : " + transform.position.z.ToString() + " w : " + W_position.ToString() + " h : " + H_position.ToString() + " n ["+cur_N_position+"] : " + N_position[cur_N_position].ToString();
                else if (hyperbolicCamera) Globalprefs.PlayerPositionInfo = "Hyperbolic World Position x : " + hyperbolicCamera.RealtimeTransform.s.ToString() + " y : " + transform.position.y.ToString() + " z : " + hyperbolicCamera.RealtimeTransform.m.ToString() + " w : " + W_position.ToString() + " h : " + H_position.ToString() + " n [" + cur_N_position + "] : " + N_position[cur_N_position].ToString();
                if (!hyperbolicCamera)
                {
                    if (gameObject.layer == 11) Globalprefs.PlayerPositionInfo = "Liminal World Position x : " + transform.position.x.ToString() + " y : " + transform.position.y.ToString() + " z : " + transform.position.z.ToString() + " s : " + "1" + " h : " + H_position.ToString() + " n [" + cur_N_position + "] : " + N_position[cur_N_position].ToString();
                    if (gameObject.layer == 12) Globalprefs.PlayerPositionInfo = "Liminal World Position x : " + transform.position.x.ToString() + " y : " + transform.position.y.ToString() + " z : " + transform.position.z.ToString() + " s : " + "2" + " h : " + H_position.ToString() + " n [" + cur_N_position + "] : " + N_position[cur_N_position].ToString();
                }
                if (hyperbolicCamera)
                {
                    if (gameObject.layer == 11) Globalprefs.PlayerPositionInfo = "Hyperkomplex World Position x : " + hyperbolicCamera.RealtimeTransform.s.ToString() + " y : " + transform.position.y.ToString() + " z : " + hyperbolicCamera.RealtimeTransform.m.ToString() + " s : " + "1" + " h : " + H_position.ToString() + " n [" + cur_N_position + "] : " + N_position[cur_N_position].ToString();
                    if (gameObject.layer == 12) Globalprefs.PlayerPositionInfo = "Hyperkomplex World Position x : " + hyperbolicCamera.RealtimeTransform.s.ToString() + " y : " + transform.position.y.ToString() + " z : " + hyperbolicCamera.RealtimeTransform.m.ToString() + " s : " + "2" + " h : " + H_position.ToString() + " n [" + cur_N_position + "] : " + N_position[cur_N_position].ToString();
                }
            }
            Globalprefs.AnyversePlayerPositionInfo = "Freedom Anyverse Position x : " + Globalprefs.GetIdPlanet() + " y : " + Globalprefs.GetTimeline() + "," + (CurrentTime()) + " z : re " + Globalprefs.Reality + " , muc " + "0" + " , li " + "0" + " , gli " + "0";

        }
    }
    bool perMorphin;

    //Приметивный интерфейс
    void Start()
    {
     
            // InvokeRepeating("GameUpdate", 1, 0.07f);
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
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("game musig").Length; i++)
            {
                GameObject.FindGameObjectsWithTag("game musig")[i].GetComponent<AudioSource>().volume = VarSave.GetGlobalFloat("mus");
            }
        }
        complsave.getallMorfs();
        if (playerdata.Geteffect("KsenoMorfin") != null)
        {
            Instantiate(complsave.t5[VarSave.GetInt("CurrentMorf")], transform);
            perMorphin = true;
        }
        InvokeRepeating("UpdateTargets", 0,1);

    }
        float timer10;
    public void load()
    {
        timer10 += Time.deltaTime;
        if (Input.GetKey(KeyCode.G) && !Globalprefs.Pause && timer10 >= 0.1f)
        {

            DirectoryInfo di = new DirectoryInfo("unsave/captert" + SceneManager.GetActiveScene().buildIndex);

            playerdata.Loadeffect();
            if (File.Exists(di.GetFiles()[di.GetFiles().Length - 1].FullName))
            {
                tsave = JsonUtility.FromJson<tsave>(File.ReadAllText(di.GetFiles()[di.GetFiles().Length - 1].FullName));
                rigidbody3d.angularVelocity = -tsave.angularvelosyty;
                rigidbody3d.velocity = -tsave.velosyty;
                PlayerBody.transform.position = tsave.pos;// sr.transform.position = save.pos2;
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
                PlayerCamera.GetComponent<Camera>().fieldOfView = tsave.vive;
                if (FindObjectsByType<Logic_tag_3>(sortmode.main).Length != 0)
                {
                    FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = tsave.vive;
                }
                File.Delete(di.GetFiles()[di.GetFiles().Length - 1].FullName);
            }
            timer10 = 0;

        }


        if (!tutorial)
        {
            if (Input.GetKey(KeyCode.F2) && !Globalprefs.Pause)
            {
                VarSave.GetFloat("H_Roataton");
                playerdata.Loadeffect();
                if (File.Exists("unsave/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + SaveFileInputField.text))
                {
                    save = JsonUtility.FromJson<save>(File.ReadAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + SaveFileInputField.text));
                    rigidbody3d.angularVelocity = save.angularvelosyty;
                    rigidbody3d.velocity = save.velosyty;
                    PlayerBody.transform.position = save.pos;// sr.transform.position = save.pos2;
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
                    PlayerCamera.GetComponent<Camera>().fieldOfView = save.vive;
                    if (FindObjectsByType<Logic_tag_3>(sortmode.main).Length != 0)
                    {
                        FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = save.vive;
                    }
                    WorldSave.GetVector4("var"); WorldSave.GetVector3("var1");
                    WorldSave.GetMusic(SceneManager.GetActiveScene().name);
                }
                if (File.Exists("unsave/capterg/" + SaveFileInputField.text))
                {
                    gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + SaveFileInputField.text));
                    hp = gsave.hp;
                    oxygen = gsave.oxygen;
                    faceViewi = gsave.fv;
                    planet_position = gsave.Spos; if (!string.IsNullOrEmpty(gsave.DateTimeJson)) gsave.starttimepos = DateTime.Parse(gsave.DateTimeJson);
                    else gsave.starttimepos = DateTime.Now;

                }

                if (FindFirstObjectByType<GenTest>()) FindFirstObjectByType<GenTest>().load_planet();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.F2) && !Globalprefs.Pause)
            {
                playerdata.Loadeffect();
                if (File.Exists("unsavet/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + SaveFileInputField.text))
                {
                    save = JsonUtility.FromJson<save>(File.ReadAllText("unsavet/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + SaveFileInputField.text));
                    rigidbody3d.angularVelocity = save.angularvelosyty;
                    rigidbody3d.velocity = save.velosyty;
                    PlayerBody.transform.position = save.pos; //sr.transform.position = save.pos2;
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
                    PlayerCamera.GetComponent<Camera>().fieldOfView = save.vive;
                    if (FindObjectsByType<Logic_tag_3>(sortmode.main).Length != 0)
                    {
                        FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = save.vive;
                    }
                    WorldSave.GetVector4("var"); WorldSave.GetVector3("var1");
                    WorldSave.GetMusic(SceneManager.GetActiveScene().name);
                }
                if (File.Exists("unsavet/capterg/" + SaveFileInputField.text))
                {
                    gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsavet/capterg/" + SaveFileInputField.text));
                    hp = gsave.hp;
                    oxygen = gsave.oxygen;
                    faceViewi = gsave.fv;
                    planet_position = gsave.Spos; if (!string.IsNullOrEmpty(gsave.DateTimeJson)) gsave.starttimepos = DateTime.Parse(gsave.DateTimeJson);
                    else gsave.starttimepos = DateTime.Now;

                }
            }

        }

    }
    public void Unload()
    {
        File.Delete("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    int CosProgress()
    {
        return gsave.progressofthepassage + nonnatureprogress + meat;
    }
    public void stop()
    {

        bool r = !Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.UpArrow);

        if (Directory.Exists("debug") && !Globalprefs.Pause)
        {


            if (Input.GetKeyDown(KeyCode.N))
            {
                planet_position -= 1;

            }
            if (Input.GetKeyDown(KeyCode.M))
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
        if (Input.GetKeyDown(KeyCode.F4) && !Globalprefs.Pause)
        {
            Unload();
        }


        if (FindObjectsByType<RaymarchCam>(sortmode.main).Length != 0)
        {
            RaymarchCam ra = FindFirstObjectByType<RaymarchCam>();
            ra._wPosition = W_position;
        }
        if (inglobalspace != true)
        {


            GetComponent<CapsuleCollider>().height = vel;
            if (JumpTimer < -vel * 2)
            {


                GetComponent<CapsuleCollider>().height += -JumpTimer * 0.5f;
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) && !Globalprefs.Pause)
            {


                rigidbody3d.velocity = Vector3.zero;
            }
        }

    }
    public void Creaive()
    {
        
        if (Directory.Exists("debug"))
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
            JumpTimer = 0;
            c = new Collision();
            if (Input.GetKey(KeyCode.W))
            {

                animator.SetBool("swem", true);
                rigidbody3d.velocity += PlayerBody.transform.forward * 30;
            }
            if (Input.GetKey(KeyCode.S))
            {

                animator.SetBool("swem", true);
                rigidbody3d.velocity += -PlayerBody.transform.forward * 30;
            }
            if (Input.GetKey(KeyCode.D))
            {

                animator.SetBool("swem", true);
                rigidbody3d.velocity += PlayerBody.transform.right * 30;
            }
            if (Input.GetKey(KeyCode.A))
            {

                animator.SetBool("swem", true);
                rigidbody3d.velocity += -PlayerBody.transform.right * 30;
            }
            if (Input.GetKey(KeyCode.Space))
            {

                animator.SetBool("swem", true);
                rigidbody3d.velocity += PlayerBody.transform.up * 30;
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {

                animator.SetBool("swem", true);
                rigidbody3d.velocity -= PlayerBody.transform.up * 30;
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
            for (int i = 0; i < GameObject.FindObjectsByType<MeshRenderer>(sortmode.main).Length; i++)
            {
                GameObject.FindObjectsByType<MeshRenderer>(sortmode.main)[i].enabled = true;
                GameObject.FindObjectsByType<MeshRenderer>(sortmode.main)[i].material = Resources.Load<Material>("mats/xray");
                if (GameObject.FindObjectsByType<MeshRenderer>(sortmode.main)[i].gameObject.GetComponent<BoxCollider>())
                {
                    if (GameObject.FindObjectsByType<MeshRenderer>(sortmode.main)[i].gameObject.GetComponent<BoxCollider>().isTrigger == true)
                    {
                        GameObject.FindObjectsByType<MeshRenderer>(sortmode.main)[i].material = Resources.Load<Material>("mats/xray3");
                    }
                }
            }
            for (int i = 0; i < GameObject.FindObjectsByType<SkinnedMeshRenderer>(sortmode.main).Length; i++)
            {
                GameObject.FindObjectsByType<SkinnedMeshRenderer>(sortmode.main)[i].enabled = true;
                GameObject.FindObjectsByType<SkinnedMeshRenderer>(sortmode.main)[i].material = Resources.Load<Material>("mats/xray2");
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
    void Update()
    {
        Globalprefs.Reality = VarSave.GetTrash("RealityX");
        if (N_position.Count > 7)
        {
            if (N_position[7] > 6.9f && N_position[7] < 7.9f && !SuperMind)
            {

                Instantiate(Resources.Load<GameObject>("events/Supermind"));
                SuperMind = !SuperMind;
            }
        }
        if (N_position.Count > 3)
        {
            if (N_position[3] > 9.9f && N_position[7] < 10.9f && !SuperMind)
            {

                Instantiate(Resources.Load<GameObject>("events/Зона"));
                SuperMind = !SuperMind;
            }
        }
#if !UNITY_EDITOR
        dnSpyModer.MainModData.UpadeteScene();
#endif
        //  EffectUpdate();
        if (Input.GetKeyDown(KeyCode.Alpha2) && !Globalprefs.Pause)
        {
            swapWXALL();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && !Globalprefs.Pause && CosProgress() >= 2)
        {
            swapHXALL();
        }
        foreach (string _script in Globalprefs.SelfFunctions)
        {
            script.Use(_script,script.Lost_Magic_obj);
            Globalprefs.KomplexX++;
            //Globalprefs.KomplexY*=2;
        }
        TimeSave();
        //авто-Пост-Ренбер
        PlayerRayMarchCollider ry = GetComponent<PlayerRayMarchCollider>();
        if (ry != null) 
        {
            if(!ry.CenterMarchCast(Globalprefs.camera.GetComponent<Camera>().transform.position,
                Globalprefs.camera.GetComponent<Camera>().transform.forward)||Globalprefs.Scrensoting)
            {
                postrender.main().Disable();
            }
            else
            {

                postrender.main().Enable();
            }

        }
        //авто-Пост-Ренбер

        if (!Globalprefs.Pause) WPositionUpdate();
        if (!Globalprefs.Pause) EconomicUpdate();
        if (!Globalprefs.Pause) Inputnravix();

        //
        if (!Globalprefs.Pause) Building();
        if (isplanet)
        {

            gameObject.GetComponent<PlanetGravity>().gravity = JumpTimer;
        }
        if (!Globalprefs.Pause) EffectUpdate();
        if (File.Exists("unsave/capterg/" + SaveFileInputField.text) && Input.GetKeyDown(KeyCode.F3) && !Globalprefs.Pause)
        {
            gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + SaveFileInputField.text));
            string s = "";
            s = SaveFileInputField.text;
            File.WriteAllText("unsave/s", s);
            SceneManager.LoadScene(gsave.sceneid);
        }


        if (!Globalprefs.Pause) TridFace();
        if (GameObject.FindGameObjectsWithTag("oxy").Length != 0)
        {
            GameObject.FindGameObjectWithTag("oxy").GetComponent<Image>().fillAmount = oxygen / 20;
        }
        if (InWater == true)
        {
            if (!GameObject.FindGameObjectWithTag("oxy"))
            {
                Instantiate(Resources.Load<GameObject>("ui/info/oxygen").gameObject, transform.position, Quaternion.identity);
            }
            oxygen -= Time.deltaTime;
        }
        if (InWater == false && oxygen <= 5)
        {

            oxygen += Time.deltaTime;
        }
        if (InWater == false && oxygen >= 5 && oxygen <= 20)
        {
            if (GameObject.FindGameObjectWithTag("oxy"))
            {
                Destroy(GameObject.FindWithTag("oxy"));
            }
            oxygen += Time.deltaTime * 2;
        }
        if (VarSave.GetBool("partic") && 0 <= GameObject.FindObjectsByType<ParticleSystem>(sortmode.main).Length - 1)
        {
            DestroyImmediate(GameObject.FindObjectsByType<ParticleSystem>(sortmode.main)[0].gameObject);
        }
        tic += Time.deltaTime;
        if (!Globalprefs.Pause) HpUpdate();

        WorldSave.SetMusic(SceneManager.GetActiveScene().name);
        

        if (!Globalprefs.Pause) MoveUpdate();


        //"unsave/capter/"+ifd.text
        //Mouse ScrollWheel
        if (FindObjectsByType<Logic_tag_3>(sortmode.main).Length != 0)
        {
            FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = PlayerCamera.GetComponent<Camera>().fieldOfView;
        }
     if (!Globalprefs.LockRotate)   PlayerCamera.GetComponent<Camera>().fieldOfView += Input.GetAxis("Mouse ScrollWheel") / ZoomConficent;
        save.angularvelosyty = rigidbody3d.angularVelocity;
        save.velosyty = rigidbody3d.velocity;
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

        save.vive = PlayerCamera.GetComponent<Camera>().fieldOfView;
        if (hyperbolicCamera != null)
        {
            save.hpos_Polar3 = JsonUtility.ToJson(HyperbolicCamera.Main().RealtimeTransform);
        }
        gsave.hp = hp;
        if (VarSave.ExistenceVar("res3", SaveType.global) && Input.GetKeyDown(KeyCode.F11) && !Globalprefs.Pause)
        {
            VarSave.SetBool("windowed", !VarSave.GetBool("windowed", SaveType.global), SaveType.global);
            Screen.SetResolution(VarSave.GetInt("res3", SaveType.global), VarSave.GetInt("res4", SaveType.global), !VarSave.GetBool("windowed", SaveType.global));

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKey(KeyCode.F1) && !tutorial && !inglobalspace && !Globalprefs.Pause)
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

            gsave.Spos = planet_position;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsave/capterg/" + SaveFileInputField.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = SaveFileInputField.text;
            File.WriteAllText("unsave/s", s);
            WorldSave.SetVector4("var");
            WorldSave.SetVector3("var1");

        }
        if (Input.GetKey(KeyCode.F1) && tutorial && tutorialsave && !inglobalspace && !Globalprefs.Pause)
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

            gsave.Spos = planet_position;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsavet/capterg/" + SaveFileInputField.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = SaveFileInputField.text;
            WorldSave.SetVector4("var");
            WorldSave.SetVector3("var1");

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
        if (VarSave.GetMoney("Inflation", SaveType.global) < 0) VarSave.SetMoney("Inflation", 0, SaveType.global);
        timer += (decimal)Time.deltaTime;
        if (timer > 60m * 60m)
        {

            VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") + Globalprefs.flowteuvro);

            timer = 0;
        }
        timer8 += (decimal)Time.deltaTime;
        if (timer8 > 5 && cistalenemy.dies > 0)
        {


            cistalenemy.dies-=1+invisibeobject;

            VarSave.SetInt("Agr", cistalenemy.dies);

            timer8 = 0;
        }
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Mouse0) && !Globalprefs.Pause && Globalprefs.selectitemobj)
        {
            if (Globalprefs.selectitemobj.GetComponent<itemName>().isLife)
            {

                cistalenemy.dies += 100;
                VarSave.SetInt("Agr", cistalenemy.dies);
            }
            VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") + Globalprefs.ItemPrise * (Globalprefs.GetProcentInflitiuon() + 1));
            Destroy(Globalprefs.selectitemobj.gameObject);
            Globalprefs.selectitem = "";
            Globalprefs.ItemPrise = 0;
        }
    }

    void WPositionUpdate()
    {
        Get4DCam()._wPosition = W_position;
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
        float gravity1 = jumpforse * JumpTimer;
        gravity1 = Mathf.Clamp(gravity1,-5,18);
        return gravity1;
    }
    float timer3;
    float timer4;
    private void PhysicsUpdate()
    {
        if (faceViewi != faceView.fourd)
        {
            

           
            

            
           
                gameObject.GetComponent<Rigidbody>().useGravity = false;

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

            fireInk -= 10;
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

        StartCoroutine(SpawnFire(pos,UnityEngine.Random.Range(0f,.5f)));
      
    }
    float ftho;
    bool isKinematic;
    float movegrag;
    private void MoveUpdate()
    {
        Sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        IsGraund = Physics.Raycast(transform.position, -transform.up, 1.3f, 0);
        RaycastHit hit35;
        if (Physics.Raycast(transform.position, -transform.up,out hit35, 100.3f))
        {
            if (hit35.collider != null)
            {
                if (hit35.distance > 1.3f)
                {
                    movegrag = 5;
                }
            }
        }
        else
        {

            movegrag = 5;
        }
        PlayerRayMarchCollider ry = GetComponent<PlayerRayMarchCollider>();
        if (ry != null)
        {
            if (ry.GetCenterDist() < 1.2f)
            {

                movegrag = 1;
                IsGraund = true;
            }
            else
            {

            }

        }

        isKinematic = Input.GetKey(KeyCode.F);


        if (IsGraund)
        {
            if (Input.GetKey(KeyCode.Space)) JumpTimer = jumpPower;
            if (!Input.GetKey(KeyCode.Space)) JumpTimer = 0;
         
            rigidbody3d.drag = 6 - axelerate;
            jumpforse = Mathf.Clamp(jumpforse, 0, 1000);
        }
        else
        {
            jumpforse = Mathf.Clamp(JumpTimer, -10, 1000);
            if (jumpforse > 0.25f || jumpforse < -0.25f)
            { movegrag = 5; }
            else
            {
                movegrag = 1;
            }
            rigidbody3d.drag = 4.5f- axelerate;
        }

        bool flyinng = InWater || inglobalspace || isKinematic || gravity == 0;
        if (!flyinng) JumpTimer -= Time.deltaTime*gravity;
        if (faceViewi != faceView.fourd )
        {
           if(ftho > 0) ftho -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.F) && CosProgress() > 0)
            {
                ftho += 1;
                if (ftho > 1)
                {
                    transform.Translate(Vector3.forward * 4); ftho = 0;
                }
            }

            float deltaX = Input.GetAxis("Horizontal") * (Speed * (1f / movegrag));
            float deltaZ = Input.GetAxis("Vertical") * (Speed * (1f / movegrag));
            float deltaW = Input.GetAxis("HyperHorizontal") * 0.1f;
            float deltaH = Input.GetAxis("HyperVertical") * 0.1f;
            float deltaY = 0.0f;
        //  if(flyinng)  deltaY = (Input.GetAxis("Jump") * Speed*1)-0.1f;
            if (!flyinng) if (!flyinng) if (Input.GetKey(KeyCode.Space) && IsGraund)
                    {
                        jumpforse = Mathf.Clamp(JumpTimer, -10, 1000);
                    }
            if (!flyinng) deltaY += jumpforse * Time.deltaTime * 600;
            if ((flyinng) && Input.GetKey(KeyCode.Space)) deltaY += 1 * Speed * Time.deltaTime * 6;
            if ((flyinng) && Sprint) deltaY -= 1 * Speed * Time.deltaTime * 6;
            if (!flyinng) if (Sprint) deltaY -= 1 * (Time.deltaTime * 100f);
           
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
            
                animator.SetFloat("MoveVelosity", deltaSumXZ + .5f);
            
            if (LateInWater != InWater)
            {

                animator.SetBool("InWater", InWater);
                LateInWater = InWater;
            }
            if (!isKinematic) if (Input.GetKey(KeyCode.Space)) transform.Translate(0, 0.1f, 0);
            if (!isKinematic) if (Sprint) { transform.Translate(0, -0.1f, 0); JumpTimer = 0; }
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, Speed);
            
            movement = transform.TransformDirection(movement);

            if ((flyinng)) if (!isKinematic) rigidbody3d.AddForce((movement * sprintCnficent) + transform.up * (deltaY * 3), ForceMode.Force); 
            if (!(flyinng)) if (!isKinematic) rigidbody3d.AddForce((movement * sprintCnficent) + transform.up * deltaY, ForceMode.Force); 




            if (tics >= 2)
            {
                transform.Translate(0, 0, 5);
                tics = 0;
            }
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

                }
                else
                {
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
    }
    int maxhp;
    private void HpUpdate()
    {
        if (hp <= 0)
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
        if (oxygen <= 0)
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
        if (hp <= 20 && !GameObject.FindWithTag("blood"))
        {
            Instantiate(Resources.Load<GameObject>("ui/damage/blood").gameObject, transform.position, Quaternion.identity);
        }
        if (hp >= 20 && GameObject.FindWithTag("blood"))
        {
            Destroy(GameObject.FindWithTag("blood"));
        }
        if (oxygen <= 5 && !GameObject.FindWithTag("blood1"))
        {
            Instantiate(Resources.Load<GameObject>("ui/damage/blood1").gameObject, transform.position, Quaternion.identity);
        }
        if (oxygen >= 5 && GameObject.FindWithTag("blood1"))
        {
            Destroy(GameObject.FindWithTag("blood1"));
        }
        if (tic >= time && hp < 200 + maxhp + maxhp2)
        {
            hp += 1 + hpregen + regen;
            tic = 0;

        }
    }

    private void Inputnravix()
    {

        if (Input.GetKeyDown("1"))
        {
            Instantiate(Resources.Load<GameObject>("Primetives/E2/PowerMetka").gameObject, transform.position, Quaternion.identity);
        }
        if (Input.GetKey("1") && Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("PaintPoint"))
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
                return;
            }
            if (faceViewi == faceView.trid)
            {


                faceViewi = faceView.fourd; return;
            }
            if (faceViewi == faceView.fourd)
            {


                faceViewi = faceView.first; return;
            }
        }
    }

    private void TridFace()
    {
        if (faceViewi == faceView.first)
        {
            PlayerCamera.transform.position = HeadCameraSetup.transform.position;
            SkinOff();
        }
        if (faceViewi == faceView.trid)
        {
            
           GameObject t = FindFirstObjectByType<PhotoCapture>().gameObject;

            SkinManager(); if (playerdata.Geteffect("KsenoMorfin") == null)
            {
                PlayerModelObject.layer = 0;
            }
            if (playerdata.Geteffect("KsenoMorfin") != null)
            {
                PlayerModelObject.layer = 8;
            }
            Ray r = new Ray(HeadCameraSetup.transform.position, -HeadCameraSetup.transform.forward);
            RaycastHit hit1;
            if (UnityEngine.Physics.Raycast(r, out hit1))
            {
                if (hit1.collider != null)
                {
                    if (hit1.distance < 6)
                    {

                        PlayerCamera.transform.position = hit1.point;
                    }
                    if (hit1.distance > 6)
                    {

                        PlayerCamera.transform.position = HeadCameraSetup.transform.position - HeadCameraSetup.transform.forward * 6;
                    }
                }
                else
                {
                    PlayerCamera.transform.position = HeadCameraSetup.transform.position - HeadCameraSetup.transform.forward * 6;
                }
            }
            else
            {
                PlayerCamera.transform.position = HeadCameraSetup.transform.position - HeadCameraSetup.transform.forward * 6;
            }

        }
        if (faceViewi == faceView.fourd)
        {
            SkinManager();
            GameObject t = PhotoCapture.FindFirstObjectByType<PhotoCapture>().gameObject;
            if (t.GetComponent<FreeCam>())
            {

            }
            if (!t.GetComponent<FreeCam>())
            {
                t.AddComponent<FreeCam>();
            }
        }
        else
        {
            GameObject t = PhotoCapture.FindFirstObjectByType<PhotoCapture>().gameObject;
            if (t.GetComponent<FreeCam>())
            {
                Destroy(t.GetComponent<FreeCam>());
            }
        }
    }

    private void SkinOff()
    {
        foreach (Logic_tag_Skin i in FindObjectsByType<Logic_tag_Skin>(sortmode.main))
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
        }
    }

    private void SkinManager()
    {
        foreach (Logic_tag_Skin i in FindObjectsByType<Logic_tag_Skin>(sortmode.main))
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
        }
    }
    float axelerate;
    int hpregen;
    int invisibeobject;
    float timerTrip;
    float timerFlowUp;
    bool big;
    bool soveVision;
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
            VarSave.SetMoney("tevro", decimal.MaxValue);
            //playermatinvisible
        }
        if (playerdata.Geteffect("Unyverseium_money_cart") != null)
        {
           if(Globalprefs.Infinitysteuvro>0) VarSave.SetMoney("tevro", decimal.MaxValue);
            //playermatinvisible
        }
        if (playerdata.Geteffect("invisible") == null)
        {

            invisibeobject = 0;
            for (int i = 0; i < PlayersModelObjObjects.Length; i++)
            {

                if (PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>())
                {
                    Material m3 = Resources.Load<Material>("pm/playermat");
                    if (c1.r + c1.g + c1.b != 0) m3.color = c1;
                    List<Material> m = new List<Material>();
                    foreach (Material m2 in PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>().materials)
                    {
                        m.Add(m2);
                    }
                    m[PlayerModelTags[i]] = m3;
                    PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>().SetMaterials(m);
                }
                if (PlayersModelObjObjects[i].GetComponent<MeshRenderer>())
                {

                    Material m3 = Resources.Load<Material>("pm/playermat");
                    if (c1.r + c1.g + c1.b != 0) m3.color = c1;
                    List<Material> m = new List<Material>();
                    foreach (Material m2 in PlayersModelObjObjects[i].GetComponent<MeshRenderer>().materials)
                    {
                        m.Add(m2);
                    }
                    m[PlayerModelTags[i]] = m3;
                    PlayersModelObjObjects[i].GetComponent<MeshRenderer>().SetMaterials(m);
                }
            }
            //playermat
        }
        if (playerdata.Geteffect("invisible") != null)
        {

            invisibeobject = 10;
            for (int i = 0; i < PlayersModelObjObjects.Length; i++)
            {

                if (PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>())
                {
                    Material m3 = Resources.Load<Material>("pm/playermatinvisible");
                    if (c1.r + c1.g + c1.b != 0) m3.color = new Color(0,0,0,0) + (c1*0.1f);
                    List<Material> m = new List<Material>();
                    foreach (Material m2 in PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>().materials)
                    {
                        m.Add(m2);
                    }
                    m[PlayerModelTags[i]] = m3;
                    PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>().SetMaterials(m);
                }
                if (PlayersModelObjObjects[i].GetComponent<MeshRenderer>())
                {

                    Material m3 = Resources.Load<Material>("pm/playermatinvisible");
                    if (c1.r + c1.g + c1.b != 0) m3.color = new Color(0, 0, 0, 0) + (c1 * 0.1f);
                    List<Material> m = new List<Material>();
                    foreach (Material m2 in PlayersModelObjObjects[i].GetComponent<MeshRenderer>().materials)
                    {
                        m.Add(m2);
                    }
                    m[PlayerModelTags[i]] = m3;
                    PlayersModelObjObjects[i].GetComponent<MeshRenderer>().SetMaterials(m);
                }
            }
            //playermat
        }
        //MetabolismUp
        if (playerdata.Geteffect("KsenoMorfin") == null && perMorphin)
        {

            playerdata.Addeffect("Trip", 5);
            GameManager.save();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
            //playerdata.Addeffect("Trip", 60)
            if (playerdata.Geteffect("Trip") != null)
        {

            timerTrip += 0.01f;
            PlayerCamera.transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 5, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 5, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 5);

            //playermatinvisible
        }
        axelerate = 0;
        if (playerdata.Geteffect("Axelerate") != null)
        {
            axelerate += 2;

            //playermatinvisible
        }
        if (playerdata.Geteffect("BigShot") != null)
        {
            timerFlowUp += Time.deltaTime;
            if (timerFlowUp >= 5)
            {
                VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") + Globalprefs.flowteuvro);
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



        if (playerdata.Geteffect("Tripl2") != null)
        {

            timerTrip += 0.01f;
            PlayerCamera.transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);
            transform.Rotate(UnityEngine.Mathf.PerlinNoise1D(timerTrip + .25f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip + .5f) / 3, UnityEngine.Mathf.PerlinNoise1D(timerTrip) / 3);
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
            PlayerCamera.transform.Rotate(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
            transform.Rotate(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
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
    public static mover main()
    {
      return  FindFirstObjectByType<mover>();
    }
    float timer9;
    public void TimeSave()
    {

        timer9 += Time.deltaTime;
        if (timer9 >= .1f && !Input.GetKey(KeyCode.G)) {
            tsave.timesave = VarSave.LoadMoney(SceneManager.GetActiveScene().buildIndex.ToString(),1).ToString();
            tsave.angularvelosyty = rigidbody3d.angularVelocity;
            tsave.velosyty = rigidbody3d.velocity;
            tsave.q1 = PlayerBody.transform.rotation;
            tsave.q2 = PlayerCamera.transform.rotation;
            tsave.pos = PlayerBody.transform.position;
            tsave.wpos = W_position; 
            tsave.hpos = H_position;
            tsave.hxrot = HX_Rotation;
            tsave.npos = N_position;
            tsave.cnpos = cur_N_position;
            if (Get4DCam()) tsave.rotW = Get4DCam()._wRotation;
            if (hyperbolicCamera != null)
            {


                tsave.hpos_Polar3 = JsonUtility.ToJson(HyperbolicCamera.Main().RealtimeTransform);
            }
            tsave.vive = Camera.main.fieldOfView;

            tsave.idsave = SaveFileInputField.text;
            Directory.CreateDirectory("unsave/captert" + SceneManager.GetActiveScene().buildIndex);
            DirectoryInfo di = new DirectoryInfo("unsave/captert" + SceneManager.GetActiveScene().buildIndex);
           
            File.WriteAllText("unsave/captert" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text + tsave.timesave, JsonUtility.ToJson(tsave));

            timer9 = 0;
            if (di.GetFiles().Length > 500)
            {
                File.Delete(di.GetFiles()[0].FullName);
            }
        }
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


            if (GameObject.Find("w2"))
            {
                GameObject.Find("w2").GetComponent<pos4>().save();
            }
            save.angularvelosyty = rigidbody3d.angularVelocity;
            save.velosyty = rigidbody3d.velocity;
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
            save.vive = Camera.main.fieldOfView;
            gsave.hp = hp;
            gsave.oxygen = oxygen;
            gsave.fv = faceViewi;

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
            if (GameObject.Find("w2"))
            {
                GameObject.Find("w2").GetComponent<pos4>().save();
            }
            save.angularvelosyty = rigidbody3d.angularVelocity;
            save.velosyty = rigidbody3d.velocity;
            save.q1 = PlayerBody.transform.rotation;
            save.q2 = PlayerCamera.transform.rotation;
            save.pos = PlayerBody.transform.position;
            save.vive = Camera.main.fieldOfView;
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
            tsave.velosyty = rigidbody3d.velocity;
            tsave.q1 = PlayerBody.transform.rotation;
            tsave.q2 = PlayerCamera.transform.rotation;
            tsave.pos = PlayerBody.transform.position;
            tsave.vive = Camera.main.fieldOfView;
            tsave.wpos = W_position;

            tsave.hpos = H_position;
            gsave.hp = hp;
            gsave.oxygen = oxygen;
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


