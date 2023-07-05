using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using Unity.Mathematics;

public class load1
{
    static public float tjump;
    static public float jump;
    static public float rjump;
    static public bool islight;
    static public bool isCamd;
    static public bool isplanet;
    static public bool stad;
    public static Polar3 pt;
    static public RawImage watermask;
    static public float gr; static public float pl;
    static public Color bg; static public CameraClearFlags bg2;
}
public class save
{
    public string idsave;
    public Vector3 pos, pos2, rotW;
    public Vector4 pos3;
    public float wpos;
    public Quaternion q1, q2, q3, q4;
    public Vector3 velosyty; public Vector3 angularvelosyty;
    public float vive;
}
public class tsave
{
    
    public Vector3 pos, pos2, rotW;
    public Vector4 pos3;
    public float wpos;
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
    [SerializeField] bool islight = false;
    [SerializeField] bool inglobalspace;
    [SerializeField] float jumpforse;
    [SerializeField] float jumpPower;
    [SerializeField] float gravity; 
    [SerializeField] float ForseSwaem;
    [SerializeField] Rigidbody rigidbody3d;
    [SerializeField] float Speed;
    [SerializeField] Animator animator;
    save save = new save();
    tsave tsave = new tsave();
    gsave gsave = new gsave();

    [SerializeField] public float W_position;
    public int planet_position;
    public InputField SaveFileInputField;
    float JumpTimer;
    [HideInInspector] public bool IsGraund;
    bool InWater;
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
    bool fly; bool Xray;
    [SerializeField] GameObject[] PlayersModelObjObjects;
    [HideInInspector] public HyperbolicCamera hyperbolicCamera;
    bool stand_stay;
    [SerializeField] GameObject PlayerModelObject;
    [SerializeField] GameObject[] PlayerModelObjects;
    faceView faceViewi;
    bool Sprint;
    string lepts = "";
    [HideInInspector] public string lif;

    
    public static RaymarchCam Get4DCam()
    {
        return (RaymarchCam)FindAnyObjectByType(typeof(RaymarchCam));
    }

    void Building()
    {

        string vaule1 = "";
        string vaule2 = "";

        if (GlobalInputMenager.KeyCode_build != "")
        {
            vaule1 = GlobalInputMenager.KeyCode_build;
            Ray r = musave.pprey();
            RaycastHit hit;
            if (UnityEngine.Physics.Raycast(r, out hit))
            {
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
                    VarSave.SetString("cms" + SceneManager.GetActiveScene().buildIndex + lif, JsonUtility.ToJson(cms),SaveType.world);
                    GlobalInputMenager.build.text = "";

                }

            }




            if (Input.GetKeyDown(KeyCode.F1))
            {
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
            bool j = Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace);
            Ray r2 = musave.pprey();
            RaycastHit hit2;
            if (UnityEngine.Physics.Raycast(r2, out hit2))
            {
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
        v4.x = c1.polarTransform.n;
        v4.y = c1.polarTransform.s;
        v4.z = c1.polarTransform.m;
        v4.w = c1.transform.position.y;
        return v4;
    }
    public void LoadHyperbolicVector(Vector4 v4,HyperbolicCamera c1)
    {
        c1.polarTransform.n = v4.x;
        c1.polarTransform.s = v4.y;
        c1.polarTransform.m = v4.z;
        c1.transform.position = new Vector3(0,v4.w,0);

    }
    //физика
    void OnCollisionStay(Collision collision)
    {
        
        IsGraund = false;
        if (JumpTimer < -2)
        {
            Debug.Log(JumpTimer);
            hp += Mathf.FloorToInt(JumpTimer) / 3;
        }
        JumpTimer = jumpPower;
        if (InWater)
        {
            IsGraund = false;
            JumpTimer = 0;
        }
        c = collision;
        if (collision.collider.tag == "sc")
        {
            JumpTimer = -jumpPower / 2;

        }

        if (collision.collider.tag == "sc2")
        {
            
            
                JumpTimer = -jumpPower / 2;
                s2 = false;
             if(GravityConstant() > -0)   IsGraund = true;

            
           

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
        StartCoroutine(coroutine());
        Globalprefs.bunkrot = VarSave.GetBool("Bunkrot");
        Globalprefs.flowteuvro = VarSave.GetInt("CashFlow");
        Globalprefs.OverFlowteuvro = VarSave.GetInt("uptevro");
        if (FindFirstObjectByType<GenTest>()) { lif = Globalprefs.GetIdPlanet().ToString(); }
        lif += "_" + Globalprefs.GetTimeline();
        
            SaveFileInputField.text = Globalprefs.GetTimeline();
        
        if (File.Exists("unsave/capterg/" + SaveFileInputField.text))
        {
            gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + SaveFileInputField.text));
            planet_position = gsave.Spos;
            lepts = "-"+ planet_position.ToString();
        }
        stand_stay = load1.stad;
        if (VarSave.ExistenceVar("cms" + SceneManager.GetActiveScene().buildIndex + lif))
        {
            if (FindFirstObjectByType<GenTest>()) { lif = Globalprefs.GetIdPlanet().ToString(); }
            custommedelsave cms = JsonUtility.FromJson<custommedelsave>(VarSave.GetString("cms" + SceneManager.GetActiveScene().buildIndex + lif));
            for (int i = 0; i < cms.name.Length; i++)
            {
                genmodel g = Instantiate(Resources.Load<GameObject>("Custom model"), cms.v3[i], Quaternion.identity).GetComponent<genmodel>();
                g.s = cms.name[i];
            }
        }
        Camera c = Instantiate(Resources.Load<GameObject>("point"), PlayerCamera.transform).AddComponent<Camera>();
        c.targetDisplay = 2;
        c.targetTexture = new RenderTexture(Screen.width, Screen.height, 1000);
        c.renderingPath = RenderingPath.DeferredShading;
        Globalprefs.camera = c;
        c.gameObject.AddComponent<Logic_tag_3>();
        if (hyperbolicCamera)
        {
            load1.pt = hyperbolicCamera.polarTransform;
        }
        if (isplanet)
        {
            gameObject.AddComponent<PlanetGravity>().body = transform;
            gameObject.GetComponent<PlanetGravity>().gravity = JumpTimer;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        playerdata.Loadeffect();

        ionenergy.energy = 0;
        vel = GetComponent<CapsuleCollider>().height;
       
        
            Instantiate(Resources.LoadAll<GameObject>("ui/postrender")[0]);

        

        Instantiate(Resources.Load<GameObject>("player inventory"));
        Instantiate(Resources.Load<GameObject>("player inventory element 2"));
        if (!tutorial && inglobalspace != true)
        {
            
            WorldSave.GetVector4("var");
            WorldSave.GetVector3("var1");
            WorldSave.GetMusic(SceneManager.GetActiveScene().name);
            Directory.CreateDirectory("unsave");
            Directory.CreateDirectory("unsave/capterg");
            Directory.CreateDirectory("unsave/capter" + SceneManager.GetActiveScene().buildIndex );
            if (File.Exists("unsave/s"))
            {
                SaveFileInputField.text = File.ReadAllText("unsave/s");
            }
            if (File.Exists("unsave/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + SaveFileInputField.text))
            {
                save = JsonUtility.FromJson<save>(File.ReadAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + SaveFileInputField.text));
                rigidbody3d.angularVelocity = save.angularvelosyty;
                rigidbody3d.velocity = save.velosyty;
                if (portallNumer.Portal == "")
                {
                    if (true)
                    {
                        PlayerBody.transform.position = save.pos;

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
                W_position = save.wpos;
                PlayerBody.transform.rotation = save.q1;
                HeadCameraSetup.transform.rotation = save.q3;
                PlayerCamera.transform.rotation = save.q2;
                if (hyperbolicCamera != null)
                {

                    hyperbolicCamera.transform.rotation = save.q4;
                    hyperbolicCamera.position = save.pos3;
                }
                if (Get4DCam()) Get4DCam()._wRotation = save.rotW;
                PlayerCamera.GetComponent<Camera>().fieldOfView = save.vive;
                if (FindObjectsByType<Logic_tag_3>(sortmode.main).Length != 0)
                {
                    FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = save.vive; ;
                }
            }
            if (File.Exists("unsave/capterg/" + SaveFileInputField.text))
            {
                gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + SaveFileInputField.text));
                hp = gsave.hp;
                oxygen = gsave.oxygen;
                faceViewi = gsave.fv;
                planet_position = gsave.Spos;
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

            if (File.Exists("unsavet/capter" + SceneManager.GetActiveScene().buildIndex  + "/"  + SaveFileInputField.text))
            {
                save = JsonUtility.FromJson<save>(File.ReadAllText("unsavet/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + SaveFileInputField.text));
                rigidbody3d.angularVelocity = save.angularvelosyty;
                rigidbody3d.velocity = save.velosyty;
                if (portallNumer.Portal == "")
                {
                    PlayerBody.transform.position = save.pos;
                    //  sr.transform.position = save.pos2;
                }

                W_position = save.wpos;
                PlayerBody.transform.rotation = save.q1;
                HeadCameraSetup.transform.rotation = save.q3;
                PlayerCamera.transform.rotation = save.q2;
                if (hyperbolicCamera != null)
                {

                    hyperbolicCamera.transform.rotation = save.q4;
                    hyperbolicCamera.position = save.pos3;
                }
                if (Get4DCam()) Get4DCam()._wRotation = save.rotW;
                PlayerCamera.GetComponent<Camera>().fieldOfView = save.vive;
                if (FindObjectsByType<Logic_tag_3>(sortmode.main).Length != 0)
                {
                    FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = save.vive; ;
                }
            }
            if (File.Exists("unsavet/capterg/" + SaveFileInputField.text))
            {
                gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsavet/capterg/" + SaveFileInputField.text));
                hp = gsave.hp;
                oxygen = gsave.oxygen;
                faceViewi = gsave.fv;
                planet_position = gsave.Spos;
            }


           

        }
      if (FindObjectsByType<GenTest>(sortmode.main).Length !=0)  FindFirstObjectByType<GenTest>().load_planet();

    }
    //Пробуждение кода
    //Приметивный интерфейс
    private void OnGUI()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            GUI.DrawTexture(new Rect((Screen.width / 2) - 10, (Screen.height / 2) - 10, 20, 20), Resources.Load<Texture>("cursor"));
        }
        if (Input.GetKey(KeyCode.F8))
        {
            GUI.Label(new Rect(0f, 0, 200f, 100f), "Unauticna Alpha-version");
            if (!hyperbolicCamera) GUI.Label(new Rect(0f, 20, 200f, 100f), "Euclidian World Position x : " + transform.position.x.ToString() + " y : " + transform.position.y.ToString() + " z : " + transform.position.z.ToString() + " w : " + W_position.ToString());
            if (hyperbolicCamera) GUI.Label(new Rect(0f, 20, 200f, 100f), "Hyperbolic World Position x : " + hyperbolicCamera.polarTransform.n.ToString() + " y : " + hyperbolicCamera.polarTransform.s.ToString() + " z : " + hyperbolicCamera.polarTransform.m.ToString() + " w : " + transform.position.y.ToString() + " h : " + W_position.ToString());
            GUI.Label(new Rect(0f, 70, 200f, 100f), "Cotinuum Position : " + SceneManager.GetActiveScene().buildIndex);
            if (FindObjectsByType<GenTest>(sortmode.main).Length != 0) GUI.Label(new Rect(0f, 90, 200f, 100f), "Space Position : " + planet_position);
            GUI.Label(new Rect(0f, 90, 200f, 100f), "Cotinuum name : " + SceneManager.GetActiveScene().name);

            GUI.Label(new Rect(0f, 120, 200f, 100f), "Unity Version : " + Application.unityVersion);
            GUI.Label(new Rect(0f, 130, 200f, 100f), "Game Version : " + Application.version);


        }
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            GUI.Label(new Rect(0f, 0, 200f, 100f), "Game Varibles :");
            GUI.Label(new Rect(0f, 20, 200f, 100f), "Teuvro ($) : " + VarSave.GetMoney("tevro").ToString());
            GUI.Label(new Rect(0f, 40, 200f, 100f), "Flow Teuvro ($^) : " + Globalprefs.flowteuvro);
            GUI.Label(new Rect(0f, 60, 200f, 100f), "Bunkrot : " + Globalprefs.bunkrot);
            GUI.Label(new Rect(0f, 80, 200f, 100f), "Item price : " + Globalprefs.ItemPrise);


        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            GUI.Label(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 10, (Screen.width / 2) + 100, (Screen.height / 2) + 30), "4D move : "+Sprint.ToString());
            if (!hyperbolicCamera) GUI.Label(new Rect(0f, 00, 200f, 100f), "Euclidian World Position x : " + transform.position.x.ToString() + " y : " + transform.position.y.ToString() + " z : " + transform.position.z.ToString() + " w : " + W_position.ToString());
            if (hyperbolicCamera) GUI.Label(new Rect(0f, 00, 200f, 100f), "Hyperbolic World Position x : " + hyperbolicCamera.polarTransform.n.ToString() + " y : " + hyperbolicCamera.polarTransform.s.ToString() + " z : " + hyperbolicCamera.polarTransform.m.ToString() + " w : " + transform.position.y.ToString() + " h : " + W_position.ToString());
        }
    }
    //Приметивный интерфейс
    void Start()
    {
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
       

    }
    public void load()
    {


      
        if (!tutorial)
        {
            if (Input.GetKey(KeyCode.F2))
            {
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
                    if (hyperbolicCamera != null)
                    {

                        hyperbolicCamera.transform.rotation = save.q4;
                        hyperbolicCamera.position = save.pos3;
                    }
                    PlayerCamera.GetComponent<Camera>().fieldOfView = save.vive;
                    if (FindObjectsByType<Logic_tag_3>(sortmode.main).Length != 0)
                    {
                        FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = save.vive; ;
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
                    planet_position = gsave.Spos;
                }

                if (FindFirstObjectByType<GenTest>()) FindFirstObjectByType<GenTest>().load_planet();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.F2))
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
                    if (hyperbolicCamera != null)
                    {

                        hyperbolicCamera.position = save.pos3;
                    }
                    PlayerCamera.transform.rotation = save.q2;
                    PlayerCamera.GetComponent<Camera>().fieldOfView = save.vive;
                    if (FindObjectsByType<Logic_tag_3>(sortmode.main).Length != 0)
                    {
                        FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = save.vive; ;
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
                    planet_position = gsave.Spos;
                }
            }

        }

    }
    public void Unload()
    {
        File.Delete("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + SaveFileInputField.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void stop()
    {
        
        bool r = !Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.UpArrow);
        
        if (Directory.Exists("debug")&& !stand_stay)
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
        
            if (!Sprint)
            {



                if (Input.GetKey(KeyCode.DownArrow))
                {
                    W_position -= 1f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    W_position += 1f * Time.deltaTime;
                }
            }
            if (Sprint)
            {



                if (Input.GetKey(KeyCode.DownArrow))
                {
                    W_position -= 10f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    W_position += 10f * Time.deltaTime;
                }
            }
            if (Input.GetKeyDown(KeyCode.F4))
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
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
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
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            fly = !fly;
        }

        if (fly)
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
    float timer;

    public void physicsStop()
    {
      //  IsGraund = false;
       

       
    }
    public void physicsStart()
    {
       // IsGraund = true;
    }
    void Update()
    {

        //авто-Пост-Ренбер
        PlayerRayMarchCollider ry = GetComponent<PlayerRayMarchCollider>();
        if (ry != null) 
        {
            if(ry.GetCameraDist() > 26.5f)
            {
                postrender.main().Disable();
            }
            else
            {

                postrender.main().Enable();
            }

        }

        //авто-Пост-Ренбер

        WPositionUpdate();
        EconomicUpdate();
        Inputnravix();


        Ray r = musave.pprey();
        RaycastHit hit;
        if (Physics.Raycast(r,out hit))
        {
            if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (hit.collider.GetComponent<transport4>())
                    hit.collider.GetComponent<transport4>().sitplayer = !hit.collider.GetComponent<transport4>().sitplayer;
                if (hit.collider.GetComponent<transport4>())
                    hit.collider.GetComponent<transport4>().player = transform;
            }
            if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (hit.collider.GetComponent<GravityBoard>())
                    hit.collider.GetComponent<GravityBoard>().sitplayer = !hit.collider.GetComponent<GravityBoard>().sitplayer;
                if (hit.collider.GetComponent<GravityBoard>())
                    hit.collider.GetComponent<GravityBoard>().player = transform;
            }
        }

        //
        Building();
        if (isplanet)
        {

            gameObject.GetComponent<PlanetGravity>().gravity = JumpTimer;
        }
        EffectUpdate();
        if (File.Exists("unsave/capterg/" + SaveFileInputField.text) && Input.GetKeyDown(KeyCode.F3))
        {
            gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + SaveFileInputField.text));
            string s = "";
            s = SaveFileInputField.text;
            File.WriteAllText("unsave/s", s);
            SceneManager.LoadScene(gsave.sceneid);
        }

      
        TridFace();
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
        HpUpdate();

        WorldSave.SetMusic(SceneManager.GetActiveScene().name);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        MoveUpdate();


        //"unsave/capter/"+ifd.text
        //Mouse ScrollWheel
        if (FindObjectsByType<Logic_tag_3>(sortmode.main).Length != 0)
        {
            FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = PlayerCamera.GetComponent<Camera>().fieldOfView;
        }
        PlayerCamera.GetComponent<Camera>().fieldOfView += Input.GetAxis("Mouse ScrollWheel") / ZoomConficent;
        save.angularvelosyty = rigidbody3d.angularVelocity;
        save.velosyty = rigidbody3d.velocity;
        save.q1 = PlayerBody.transform.rotation;
        save.q2 = PlayerCamera.transform.rotation;
        save.pos = PlayerBody.transform.position;
        save.pos2 = HeadCameraSetup.transform.position;
        save.q3 = HeadCameraSetup.transform.rotation;
        save.wpos = W_position;
        if (Get4DCam()) save.rotW = Get4DCam()._wRotation;

        save.vive = PlayerCamera.GetComponent<Camera>().fieldOfView;
        if (hyperbolicCamera != null)
        {

            save.q4 = hyperbolicCamera.transform.rotation;
            save.pos3 = hyperbolicCamera.position;
        }
        gsave.hp = hp;
        if (VarSave.ExistenceVar("res3") && Input.GetKeyDown(KeyCode.F11))
        {
            VarSave.SetBool("windowed", !VarSave.GetBool("windowed"));
            Screen.SetResolution(VarSave.GetInt("res3"), VarSave.GetInt("res4"), !VarSave.GetBool("windowed"));

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKey(KeyCode.F1) && !tutorial && !inglobalspace)
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

        load();

        PhysicsUpdate();

        Creaive();
    }

    private void EconomicUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {

            VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") + Globalprefs.flowteuvro);

            timer = 0;
        }
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            VarSave.SetMoney("tevro", VarSave.GetMoney("tevro") + Globalprefs.ItemPrise);
            Destroy(Globalprefs.selectitemobj.gameObject);
            Globalprefs.selectitem = "";
            Globalprefs.ItemPrise = 0;
        }
    }

    void WPositionUpdate()
    {
        Get4DCam()._wPosition = W_position;
    }


    public float GravityConstant()
    {
        float gravity1 = jumpforse * JumpTimer;
        gravity1 = Mathf.Clamp(gravity1,-4,18);
        return gravity1;
    }

    private void PhysicsUpdate()
    {
        if (faceViewi != faceView.fourd)
        {
            

           
            

            
           
                gameObject.GetComponent<Rigidbody>().useGravity = false;
            
        }
    }
    float ftho;
    bool isKinematic;
    private void MoveUpdate()
    {
        Sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        IsGraund = Physics.Raycast(transform.position, -transform.up, 1.2f);
        PlayerRayMarchCollider ry = GetComponent<PlayerRayMarchCollider>();
        if (ry != null)
        {
            if (ry.GetCenterDist() < 1.2f)
            {
                IsGraund = true;
            }
            else
            {

            }

        }

        isKinematic = Input.GetKey(KeyCode.F);
       
        
        if (IsGraund)
        {
            JumpTimer = jumpPower;
            rigidbody3d.drag = 5;
            jumpforse = Mathf.Clamp(jumpforse,0,1000);
        }
        else
        {
            jumpforse = Mathf.Clamp(JumpTimer, -10, 1000);

            rigidbody3d.drag = 3;
        }

        bool flyinng = InWater || inglobalspace || isKinematic;
        if (!flyinng) JumpTimer -= Time.deltaTime*gravity;
        if (faceViewi != faceView.fourd)
        {
           if(ftho > 0) ftho -= Time.deltaTime;
            if (!isKinematic) if (Input.GetKeyDown(KeyCode.F) && gsave.progressofthepassage > 0)
            {
                ftho += 1;
                if (ftho > 1)
                {
                    transform.Translate(Vector3.forward * 4); ftho = 0;
                }
            }

            float deltaX = Input.GetAxis("Horizontal") * Speed;
            float deltaZ = Input.GetAxis("Vertical") * Speed;
            float deltaW = Input.GetAxis("HyperHorizontal") *0.1f;
            float deltaY = 0.0f;
          if(flyinng)  deltaY = (Input.GetAxis("Jump") * Speed)-0.1f;
            if (!flyinng) if (!flyinng) if (Input.GetKey(KeyCode.Space) && IsGraund)
                    {
                        jumpforse = Mathf.Clamp(JumpTimer, -10, 1000);
                    }
            if (!flyinng) deltaY += jumpforse * Time.deltaTime * 600;
            if ((flyinng) && Input.GetKey(KeyCode.Space)) deltaY += 1 * Time.deltaTime * 600;
            if (Sprint) deltaY -= 1*(Time.deltaTime*100f);
            float sprintCnficent = 1f;
            if (Sprint)
            {


                if (!isKinematic) W_position += deltaW *5;
                sprintCnficent = 2;
            }
            else
            {

                if (!isKinematic) W_position += deltaW;
            }
            float deltaSumXZ = deltaX + deltaZ;

            //  if(deltaSumXZ == 0) rigidbody3d.velocity = Vector3.zero;
            if (!flyinng) animator.SetFloat("MoveVelosity", deltaSumXZ + .5f);
            if (!flyinng) animator.SetBool("InWater", InWater);
            if (!isKinematic) if (Input.GetKey(KeyCode.Space)) transform.Translate(0, 0.1f, 0);
            if (!isKinematic) if (Sprint) { transform.Translate(0, -0.1f, 0); JumpTimer = 0; }
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, Speed);
            
            movement = transform.TransformDirection(movement);

            if (!isKinematic) rigidbody3d.AddForce((movement* sprintCnficent)+ transform.up * deltaY,ForceMode.Force);


           

            if (tics >= 2)
            {
                transform.Translate(0, 0, 5);
                tics = 0;
            }

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
        if (tic >= time && hp < 199)
        {
            hp += 1;
            tic = 0;

        }
    }

    private void Inputnravix()
    {
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
            PlayerModelObject.layer = 8;
            foreach (GameObject i in PlayerModelObjects)
            {
                i.layer = 8;
            }
        }
        if (faceViewi == faceView.trid)
        {
            
           GameObject t = PhotoCapture.FindObjectOfType<PhotoCapture>().gameObject;
            foreach (GameObject i in PlayerModelObjects)
            {
                i.layer = 0;
            }
            PlayerModelObject.layer = 0;
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
            GameObject t = PhotoCapture.FindObjectOfType<PhotoCapture>().gameObject;
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
            GameObject t = PhotoCapture.FindObjectOfType<PhotoCapture>().gameObject;
            if (t.GetComponent<FreeCam>())
            {
                Destroy(t.GetComponent<FreeCam>());
            }
        }
    }

    private void EffectUpdate()
    {
        if (playerdata.Geteffect("invisible") != null)
        {


            for (int i = 0; i < PlayersModelObjObjects.Length; i++)
            {
               
                if (PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>())
                {


                    PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>().materials[1] = Resources.Load<Material>("pm/playermatinvisible");
                }
            }

            //playermatinvisible
        }
        if (playerdata.Geteffect("invisible") == null)
        {
            for (int i = 0; i < PlayersModelObjObjects.Length; i++)
            {
               
                if (PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>())
                {


                    PlayersModelObjObjects[i].GetComponent<SkinnedMeshRenderer>().materials[1] = Resources.Load<Material>("pm/playermat");
                }
            }
            //playermat
        }
        playerdata.checkeffect();
        musave.GetUF();
    }
    public static mover main()
    {
      return  FindFirstObjectByType<mover>();
    }
    public void saveing()
    {
        if (playerdata.Geteffect("LevelUp") != null)
        {
            VarSave.SetInt("progress",gsave.progressofthepassage+1);
            gsave.progressofthepassage += 1;
            musave.chargescene(0);

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
            if(Get4DCam()) save.rotW = Get4DCam()._wRotation;
            if (hyperbolicCamera != null)
            {

                save.q4 = hyperbolicCamera.transform.rotation;
                save.pos3 = GetHyperbolicVector(hyperbolicCamera);
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
            if (Get4DCam()) save.rotW = Get4DCam()._wRotation;
            if (hyperbolicCamera!=null)
            {
                save.q4 = hyperbolicCamera.transform.rotation;

                save.pos3 = GetHyperbolicVector(hyperbolicCamera);
            }
            tsave.angularvelosyty = rigidbody3d.angularVelocity;
            tsave.velosyty = rigidbody3d.velocity;
            tsave.q1 = PlayerBody.transform.rotation;
            tsave.q2 = PlayerCamera.transform.rotation;
            tsave.pos = PlayerBody.transform.position;
            tsave.vive = Camera.main.fieldOfView;
            tsave.wpos = W_position;
            gsave.hp = hp;
            gsave.oxygen = oxygen;
            gsave.fv = faceViewi;
            save.idsave = SaveFileInputField.text;
            Directory.CreateDirectory("unsavet/capter" + SceneManager.GetActiveScene().buildIndex );
            File.WriteAllText("unsavet/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + SaveFileInputField.text, JsonUtility.ToJson(save));
            gsave.idsave = SaveFileInputField.text;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsavet/capterg/" + SaveFileInputField.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = SaveFileInputField.text;
            File.WriteAllText("unsavet/s", s);
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


