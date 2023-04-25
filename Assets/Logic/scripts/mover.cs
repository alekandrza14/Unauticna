using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

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
    public GameObject g;
    public GameObject g2;
    [SerializeField] Rigidbody g1;
    [SerializeField] float sm;
    [SerializeField] save save = new save();
    [SerializeField] tsave tsave = new tsave();
    [SerializeField] gsave gsave = new gsave();
    public InputField ifd;
    public float tjump;
    [SerializeField] float jump;
    [SerializeField] float rjump;
    [SerializeField] float gr;[SerializeField] float pl;
    public bool igr;
    [SerializeField] bool isplanet;
    [SerializeField] bool issweming;
    Collision c;
    [SerializeField] Animator anim;
    [SerializeField] float vive = int.MaxValue;
    [SerializeField] RawImage watermask;
    [SerializeField] float fog;[SerializeField] float fog2;
    [SerializeField] Color fogonwater;
    [SerializeField] Color fogonair = new Color(0, 0, 0, 0);
   [HideInInspector] public int hp = 200; float oxygen = 20;
    float tic, time = 4; float tic2, time2 = 4;
    bool s2 = true;
    public GameObject sr;
    [HideInInspector] public deldialog del;
    [SerializeField] bool islight = false;
    float vel;
    [SerializeField] bool tutorial;
    float tics;
    bool fly; bool Xray;
    [SerializeField] GameObject[] mybody;
    [HideInInspector] public Camd cd;
    [SerializeField] public float w;
    [SerializeField] bool stand_stay;
    [SerializeField] GameObject model;
    [SerializeField] GameObject[] forach;
    [SerializeField] bool inglobalspace;
    [SerializeField] faceView faceViewi;
    bool move4D;
    string lepts = "";
    public string lif;

    void swapWX3(Transform x, mover w)
    {
        RaymarchCam m = GameObject.FindObjectOfType<RaymarchCam>();
        float save = x.localPosition.x;
        if (m._wRotation.x == 0) x.localPosition = new Vector3(w.w, x.localPosition.y, x.localPosition.z);
        if (m._wRotation.x == -90) x.localPosition = new Vector3(-w.w, x.localPosition.y, x.localPosition.z);
        if (m._wRotation.x == 0) w.w = -save;
        if (m._wRotation.x == -90) w.w = save;
    }

    public static void swapWXALL()
    {
        RaymarchCam m = GameObject.FindObjectOfType<RaymarchCam>();
        mover w = GameObject.FindObjectOfType<mover>();
        w.swapWX3(w.transform, w);
        if (m._wRotation.x == 0)  m._wRotation.x = -90; else m._wRotation.x = 0;

    }
    public static RaymarchCam Get4DCam()
    {
        return GameObject.FindObjectOfType<RaymarchCam>();
    }

    void getSignal()
    {
        if (FindFirstObjectByType<GenTest>()) { lif = VarSave.GetInt("planet").ToString(); }
        int vaule = 0;
        if (File.Exists("C:/myMods/sig1.sig"))
        {
            vaule = int.Parse(File.ReadAllText("C:/myMods/sig1.sig"));
            Ray r = musave.pprey();
            RaycastHit hit;
            if (UnityEngine.Physics.Raycast(r, out hit))
            {
                if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.position += (gameObject.transform.forward) * vaule;
                    File.Delete("C:/myMods/sig1.sig");
                }
            }

        }
        if (File.Exists("C:/myMods/sig4.sig"))
        {
            vaule = int.Parse(File.ReadAllText("C:/myMods/sig4.sig"));
            Ray r = musave.pprey();
            RaycastHit hit;
            if (UnityEngine.Physics.Raycast(r, out hit))
            {
                if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.position -= (gameObject.transform.forward) * vaule;
                    File.Delete("C:/myMods/sig4.sig");
                }
            }

        }
        if (File.Exists("C:/myMods/sig2.sig"))
        {
            vaule = int.Parse(File.ReadAllText("C:/myMods/sig2.sig"));
            Ray r = musave.pprey();
            RaycastHit hit;
            if (UnityEngine.Physics.Raycast(r, out hit))
            {
                if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.position -= (gameObject.transform.right) * vaule;
                    File.Delete("C:/myMods/sig2.sig");
                }
            }

        }
        if (File.Exists("C:/myMods/sig3.sig"))
        {
            vaule = int.Parse(File.ReadAllText("C:/myMods/sig3.sig"));
            Ray r = musave.pprey();
            RaycastHit hit;
            if (UnityEngine.Physics.Raycast(r, out hit))
            {
                if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.position += (gameObject.transform.right) * vaule;
                    File.Delete("C:/myMods/sig3.sig");
                }
            }

        }
        if (File.Exists("C:/myMods/sig5.sig"))
        {
            vaule = int.Parse(File.ReadAllText("C:/myMods/sig5.sig"));
            Ray r = musave.pprey();
            RaycastHit hit;
            if (UnityEngine.Physics.Raycast(r, out hit))
            {
                if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.position += (gameObject.transform.up) * vaule;
                    File.Delete("C:/myMods/sig5.sig");
                }
            }

        }
        if (File.Exists("C:/myMods/sig6.sig"))
        {
            vaule = int.Parse(File.ReadAllText("C:/myMods/sig6.sig"));
            Ray r = musave.pprey();
            RaycastHit hit;
            if (UnityEngine.Physics.Raycast(r, out hit))
            {
                if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.position -= (gameObject.transform.up) * vaule;
                    File.Delete("C:/myMods/sig6.sig");
                }
            }

        }
        if (File.Exists("C:/myMods/sig7.sig"))
        {
            vaule = int.Parse(File.ReadAllText("C:/myMods/sig7.sig"));
            Ray r = musave.pprey();
            RaycastHit hit;
            if (UnityEngine.Physics.Raycast(r, out hit))
            {
                if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.position = (gameObject.transform.position);
                    File.Delete("C:/myMods/sig7.sig");
                }
            }

        }
        string vaule1 = "";

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
                    for (int i = 0; i < GameObject.FindObjectsOfType<genmodel>().Length; i++)
                    {
                        name.Add(FindObjectsOfType<genmodel>()[i].s);
                        v3.Add(FindObjectsOfType<genmodel>()[i].transform.position);
                    }
                    custommedelsave cms = new custommedelsave();
                    cms.name = name.ToArray();
                    cms.v3 = v3.ToArray();
                    VarSave.SetString("cms" + SceneManager.GetActiveScene().buildIndex +lif, JsonUtility.ToJson(cms));

                }
            }

        }
        if (true)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                List<string> name = new List<string>();
                List<Vector3> v3 = new List<Vector3>();
                for (int i = 0; i < GameObject.FindObjectsOfType<genmodel>().Length; i++)
                {
                    name.Add(FindObjectsOfType<genmodel>()[i].s);
                    v3.Add(FindObjectsOfType<genmodel>()[i].transform.position);
                }
                custommedelsave cms = new custommedelsave();
                cms.name = name.ToArray();
                cms.v3 = v3.ToArray();
                if (GameObject.FindObjectsOfType<genmodel>().Length >= 2) { VarSave.SetString("cms" + SceneManager.GetActiveScene().buildIndex + lif, JsonUtility.ToJson(cms)); }
                else
                {
                    cms.name = new string[] { };
                    cms.v3 = new Vector3[] { };
                    VarSave.SetString("cms" + SceneManager.GetActiveScene().buildIndex + lif, JsonUtility.ToJson(cms));
                }
            }
            bool j = Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace);
            Ray r = musave.pprey();
            RaycastHit hit;
            if (UnityEngine.Physics.Raycast(r, out hit))
            {
                if (hit.collider != null && j)
                {
                    if (hit.collider.GetComponent<genmodel>())
                    {
                        hit.collider.gameObject.AddComponent<DELETE>();
                        List<string> name = new List<string>();
                        List<Vector3> v3 = new List<Vector3>();
                        for (int i = 0; i < GameObject.FindObjectsOfType<genmodel>().Length; i++)
                        {
                            name.Add(FindObjectsOfType<genmodel>()[i].s);
                            v3.Add(FindObjectsOfType<genmodel>()[i].transform.position);
                        }
                        custommedelsave cms = new custommedelsave();
                        cms.name = name.ToArray();
                        cms.v3 = v3.ToArray();
                        if (GameObject.FindObjectsOfType<genmodel>().Length >= 2) { VarSave.SetString("cms" + SceneManager.GetActiveScene().buildIndex + lif, JsonUtility.ToJson(cms)); } else
                        {
                            cms.name = new string[] { };
                            cms.v3 = new Vector3[] { };
                            VarSave.SetString("cms" + SceneManager.GetActiveScene().buildIndex + lif, JsonUtility.ToJson(cms));
                        }
                    }
                }
            }

        }
        //используйте на здоровье
        /*
        if (File.Exists("C:/myMods/sig1.sig"))
        {
            vaule = int.Parse(File.ReadAllText("C:/myMods/sig1.sig"));
            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.position += (gameObject.transform.forward*vaule) - gameObject.transform.position;
                    File.Delete("C:/myMods/sig1.sig");
                }
            }

        }
        if (File.Exists("C:/myMods/sig4.sig"))
        {
            vaule = int.Parse(File.ReadAllText("C:/myMods/sig4.sig"));
            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.position -= (gameObject.transform.forward * vaule) - gameObject.transform.position;
                    File.Delete("C:/myMods/sig4.sig");
                }
            }

        }
        if (File.Exists("C:/myMods/sig2.sig"))
        {
            vaule = int.Parse(File.ReadAllText("C:/myMods/sig2.sig"));
            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.position -= (gameObject.transform.right * vaule) - gameObject.transform.position;
                    File.Delete("C:/myMods/sig2.sig");
                }
            }

        }
        if (File.Exists("C:/myMods/sig3.sig"))
        {
            vaule = int.Parse(File.ReadAllText("C:/myMods/sig3.sig"));
            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.position += (gameObject.transform.right * vaule) - gameObject.transform.position;
                    File.Delete("C:/myMods/sig3.sig");
                }
            }

        }
        if (File.Exists("C:/myMods/sig5.sig"))
        {
            vaule = int.Parse(File.ReadAllText("C:/myMods/sig5.sig"));
            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.position += (gameObject.transform.up * vaule) - gameObject.transform.position;
                    File.Delete("C:/myMods/sig5.sig");
                }
            }

        }
        if (File.Exists("C:/myMods/sig6.sig"))
        {
            vaule = int.Parse(File.ReadAllText("C:/myMods/sig6.sig"));
            Ray r = musave.pprey();
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
                {
                    hit.collider.transform.position -= (gameObject.transform.up * vaule) - gameObject.transform.position;
                    File.Delete("C:/myMods/sig6.sig");
                }
            }

        }
        */

    }

    public faceView GETistp()
    {
        return faceViewi;
    }
    public void SETistp(faceView a)
    {
       faceViewi =a;
    }
    public Vector4 convertPvectorinVector4(Camd c1)
    {
        Vector4 v4 = new Vector4();
        v4.x = c1.polarTransform.n;
        v4.y = c1.polarTransform.s;
        v4.z = c1.polarTransform.m;
        v4.w = c1.transform.position.y;
        return v4;
    }
    public void convertinPvector(Vector4 v4,Camd c1)
    {
        c1.polarTransform.n = v4.x;
        c1.polarTransform.s = v4.y;
        c1.polarTransform.m = v4.z;
        c1.transform.position = new Vector3(0,v4.w,0);

    }

    void OnCollisionStay(Collision collision)
    {
        igr = false;
        if (tjump < -2)
        {
            Debug.Log(tjump);
            hp += Mathf.FloorToInt(tjump) / 3;
        }
        tjump = rjump;
        if (issweming)
        {
            igr = false;
            tjump = 0;
        }
        c = collision;
        if (collision.collider.tag == "sc")
        {
            tjump = -rjump / 2;

        }

        if (collision.collider.tag == "sc2")
        {
            if (g1.velocity.y >= 2)
            {
                tic2 += Time.deltaTime;
            }
            if (g1.velocity.y <= 2 && tic2 >= 0)
            {
                tic2 -= Time.deltaTime;
            }
            if (tic2 >= time2)
            {
                tjump = -rjump / 2;
                s2 = false;
                igr = true;

            }
            if (!s2)
            {
                tjump = -rjump / 2;
                s2 = false;
                igr = true;
                tic2 -= Time.deltaTime * 2;
                if (tic2 <= 0)
                {

                    s2 = true;

                }
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
            igr = true;

        }
        if (other.GetComponent<notswiming>())
        {
            issweming = true;

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "lagi")
        {
            g2.GetComponent<Camera>().enabled = 1 == Random.Range(0, 3);

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<notswiming>())
        {
            issweming = false;

        }
        if (other.tag == "lagi")
        {
            g2.GetComponent<Camera>().enabled = true;

        }
    }
    void OnCollisionExit(Collision collision)
    {

        c = null;
    }
    private void Awake()
    {
        if (FindFirstObjectByType<GenTest>()) { lif = VarSave.GetInt("planet").ToString(); }
        if (File.Exists("unsave/s"))
        {
            ifd.text = File.ReadAllText("unsave/s");
        }
        if (File.Exists("unsave/capterg/" + ifd.text))
        {
            gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + ifd.text));
            planet_position = gsave.Spos;
            lepts = "-"+ planet_position.ToString();
        }
        stand_stay = load1.stad;
        if (VarSave.EnterFloat("cms" + SceneManager.GetActiveScene().buildIndex + lif))
        {
            if (FindFirstObjectByType<GenTest>()) { lif = VarSave.GetInt("planet").ToString(); }
            custommedelsave cms = JsonUtility.FromJson<custommedelsave>(VarSave.GetString("cms" + SceneManager.GetActiveScene().buildIndex + lif));
            for (int i = 0; i < cms.name.Length; i++)
            {
                genmodel g = Instantiate(Resources.Load<GameObject>("Custom model"), cms.v3[i], Quaternion.identity).GetComponent<genmodel>();
                g.s = cms.name[i];
            }
        }
        Camera c = Instantiate(Resources.Load<GameObject>("point"), g2.transform).AddComponent<Camera>();
        c.targetDisplay = 2;
        c.targetTexture = new RenderTexture(Screen.width, Screen.height, 1000);
        c.gameObject.AddComponent<Logic_tag_3>();
        if (cd)
        {
            load1.pt = cd.polarTransform;
        }
        if (isplanet)
        {
            gameObject.AddComponent<PlanetGravity>().body = transform;
            gameObject.GetComponent<PlanetGravity>().gravity = tjump;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        playerdata.Loadeffect();

        ionenergy.energy = 0;
        vel = GetComponent<CapsuleCollider>().height;
        if (Photon.Pun.PhotonNetwork.IsConnected)
        {
            load1.isplanet = isplanet;
            load1.gr = gr;
            load1.jump = jump;
            load1.rjump = rjump;
            load1.tjump = tjump;
            load1.islight = islight;
            load1.pl = pl;
            load1.watermask = watermask;
            load1.isCamd = cd != null;
            load1.bg = g2.GetComponent<Camera>().backgroundColor;
            load1.bg2 = g2.GetComponent<Camera>().clearFlags;
            Photon.Pun.PhotonNetwork.Instantiate("nr", transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        if (VarSave.GetBool("postrender") == true)
        {
            Instantiate(Resources.LoadAll<GameObject>("ui/postrender")[0]);

        }

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
                ifd.text = File.ReadAllText("unsave/s");
            }
            if (File.Exists("unsave/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + ifd.text))
            {
                save = JsonUtility.FromJson<save>(File.ReadAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + ifd.text));
                g1.angularVelocity = save.angularvelosyty;
                g1.velocity = save.velosyty;
                if (!portallNumer.p2 && !portallNumer.p1 && !portallNumer.p3 && !portallNumer.p4 && !portallNumer.p5 && !portallNumer.p6 && !portallNumer.p7 && !portallNumer.p8)
                {
                    if (true)
                    {
                        g.transform.position = save.pos;

                        //  sr.transform.position = save.pos2;
                        g2.transform.position = sr.transform.position;

                    }
                    if (Globalprefs.isnew)
                    {


                        g.transform.position += Globalprefs.newv3;
                        g.transform.rotation = Globalprefs.q[0];
                        sr.transform.rotation = Globalprefs.q[2];
                        g2.transform.rotation = Globalprefs.q[1];
                        Globalprefs.isnew = false;
                    }
                }
                w = save.wpos;
                g.transform.rotation = save.q1;
                sr.transform.rotation = save.q3;
                g2.transform.rotation = save.q2;
                if (cd != null)
                {

                    cd.transform.rotation = save.q4;
                    cd.position = save.pos3;
                }
                if (Get4DCam()) Get4DCam()._wRotation = save.rotW;
                g2.GetComponent<Camera>().fieldOfView = save.vive;
                if (FindObjectsOfType<Logic_tag_3>().Length != 0)
                {
                    FindObjectOfType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = save.vive; ;
                }
            }
            if (File.Exists("unsave/capterg/" + ifd.text))
            {
                gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + ifd.text));
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

            ifd.text = "tutorial";

            if (File.Exists("unsavet/capter" + SceneManager.GetActiveScene().buildIndex  + "/"  + ifd.text))
            {
                save = JsonUtility.FromJson<save>(File.ReadAllText("unsavet/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + ifd.text));
                g1.angularVelocity = save.angularvelosyty;
                g1.velocity = save.velosyty;
                if (!portallNumer.p2 && !portallNumer.p1 && !portallNumer.p3 && !portallNumer.p4)
                {
                    g.transform.position = save.pos;
                    //  sr.transform.position = save.pos2;
                }

                w = save.wpos;
                g.transform.rotation = save.q1;
                sr.transform.rotation = save.q3;
                g2.transform.rotation = save.q2;
                if (cd != null)
                {

                    cd.transform.rotation = save.q4;
                    cd.position = save.pos3;
                }
                if (Get4DCam()) Get4DCam()._wRotation = save.rotW;
                g2.GetComponent<Camera>().fieldOfView = save.vive;
                if (FindObjectsOfType<Logic_tag_3>().Length != 0)
                {
                    FindObjectOfType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = save.vive; ;
                }
            }
            if (File.Exists("unsavet/capterg/" + ifd.text))
            {
                gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsavet/capterg/" + ifd.text));
                hp = gsave.hp;
                oxygen = gsave.oxygen;
                faceViewi = gsave.fv;
                planet_position = gsave.Spos;
            }


           

        }
      if (FindObjectsOfType<GenTest>().Length !=0)  FindObjectOfType<GenTest>().load_planet();

    }
    public int planet_position;
    private void OnGUI()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            GUI.DrawTexture(new Rect((Screen.width / 2) - 10, (Screen.height / 2) - 10, 20, 20), Resources.Load<Texture>("cursor"));
        }
        if (Input.GetKey(KeyCode.F8))
        {
            GUI.Label(new Rect(0f,0,200f,100f),"Unauticna Alpha-version");
            if (!cd) GUI.Label(new Rect(0f, 20, 200f, 100f), "Euclidian World Position x : " + transform.position.x.ToString() + " y : " + transform.position.y.ToString() + " z : " + transform.position.z.ToString() + " w : "+ w.ToString());
          if(cd)  GUI.Label(new Rect(0f, 20, 200f, 100f), "Hyperbolic World Position x : " + cd.polarTransform.n.ToString() + " y : " + cd.polarTransform.s.ToString() + " z : " + cd.polarTransform.m.ToString() + " w : " + transform.position.y.ToString() + " h : " + w.ToString());
            GUI.Label(new Rect(0f, 70, 200f, 100f), "Cotinuum Position : " + SceneManager.GetActiveScene().buildIndex);
          if(FindObjectsOfType<GenTest>().Length !=0)  GUI.Label(new Rect(0f, 90, 200f, 100f), "Space Position : " + planet_position);
            GUI.Label(new Rect(0f, 100, 200f, 100f), "All objects : " + FindObjectsOfType<GameObject>().Length);

            GUI.Label(new Rect(0f, 120, 200f, 100f), "Unity Version : " + Application.unityVersion); 
            GUI.Label(new Rect(0f, 130, 200f, 100f), "Game Version : " + Application.version);


        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            GUI.Label(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 10, (Screen.width / 2) + 100, (Screen.height / 2) + 30), "4D move : "+move4D.ToString());
            if (!cd) GUI.Label(new Rect(0f, 00, 200f, 100f), "Euclidian World Position x : " + transform.position.x.ToString() + " y : " + transform.position.y.ToString() + " z : " + transform.position.z.ToString() + " w : " + w.ToString());
            if (cd) GUI.Label(new Rect(0f, 00, 200f, 100f), "Hyperbolic World Position x : " + cd.polarTransform.n.ToString() + " y : " + cd.polarTransform.s.ToString() + " z : " + cd.polarTransform.m.ToString() + " w : " + transform.position.y.ToString() + " h : " + w.ToString());
        }
    }

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
        if (VarSave.EnterFloat2("mus"))
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("game musig").Length; i++)
            {
                GameObject.FindGameObjectsWithTag("game musig")[i].GetComponent<AudioSource>().volume = VarSave.GetFloat2("mus");
            }
        }
       

    }
    public void load()
    {


        if (Input.GetKey(KeyCode.G))
        {
            DirectoryInfo di = new DirectoryInfo("unsave/capter-" + SceneManager.GetActiveScene().buildIndex);
            if (File.Exists("unsave/capter-" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text + "-" + (di.GetFiles().Length -1)))
            {
                tsave = JsonUtility.FromJson<tsave>(File.ReadAllText("unsave/capter-" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text + "-" + (di.GetFiles().Length - 1)));
                g1.angularVelocity = tsave.angularvelosyty;
                g1.velocity = tsave.velosyty;
                g.transform.position = tsave.pos;
                g.transform.rotation = tsave.q1;
                sr.transform.rotation = tsave.q2;
                g2.transform.rotation = tsave.q3;

                if (Get4DCam()) Get4DCam()._wRotation = tsave.rotW ;
                w = tsave.wpos;
              //  sr.transform.position = tsave.pos2;
                g2.transform.position = sr.transform.position;
                if (cd!=null)
                {

                    cd.transform.rotation = tsave.q4;
                    cd.position = save.pos3;
                }
                g2.GetComponent<Camera>().fieldOfView = tsave.vive;
                if (FindObjectsOfType<Logic_tag_3>().Length != 0)
                {
                    FindObjectOfType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = save.vive; ;
                }
                File.Delete("unsave/capter-" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text + "-" + (di.GetFiles().Length - 1));
            }
            
        }
        if (!tutorial)
        {
            if (Input.GetKey(KeyCode.F2))
            {
                playerdata.Loadeffect();
                if (File.Exists("unsave/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + ifd.text))
                {
                    save = JsonUtility.FromJson<save>(File.ReadAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + ifd.text));
                    g1.angularVelocity = save.angularvelosyty;
                    g1.velocity = save.velosyty;
                    g.transform.position = save.pos;// sr.transform.position = save.pos2;
                    g.transform.rotation = save.q1;
                    sr.transform.rotation = save.q3;
                    g2.transform.rotation = save.q2;
                    if (Get4DCam()) Get4DCam()._wRotation = save.rotW;
                    w = save.wpos;
                    if (cd != null)
                    {

                        cd.transform.rotation = save.q4;
                        cd.position = save.pos3;
                    }
                    g2.GetComponent<Camera>().fieldOfView = save.vive;
                    if (FindObjectsOfType<Logic_tag_3>().Length != 0)
                    {
                        FindObjectOfType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = save.vive; ;
                    }
                    WorldSave.GetVector4("var"); WorldSave.GetVector3("var1");
                    WorldSave.GetMusic(SceneManager.GetActiveScene().name);
                }
                if (File.Exists("unsave/capterg/" + ifd.text))
                {
                    gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + ifd.text));
                    hp = gsave.hp;
                    oxygen = gsave.oxygen;
                    faceViewi = gsave.fv;
                    planet_position = gsave.Spos;
                }

                if (FindObjectOfType<GenTest>()) FindObjectOfType<GenTest>().load_planet();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.F2))
            {
                playerdata.Loadeffect();
                if (File.Exists("unsavet/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + ifd.text))
                {
                    save = JsonUtility.FromJson<save>(File.ReadAllText("unsavet/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + ifd.text));
                    g1.angularVelocity = save.angularvelosyty;
                    g1.velocity = save.velosyty;
                    g.transform.position = save.pos; //sr.transform.position = save.pos2;
                    g.transform.rotation = save.q1;
                    sr.transform.rotation = save.q3;

                    if (Get4DCam()) Get4DCam()._wRotation = save.rotW;
                    w = save.wpos;
                    if (cd != null)
                    {

                        cd.position = save.pos3;
                    }
                    g2.transform.rotation = save.q2;
                    g2.GetComponent<Camera>().fieldOfView = save.vive;
                    if (FindObjectsOfType<Logic_tag_3>().Length != 0)
                    {
                        FindObjectOfType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = save.vive; ;
                    }
                    WorldSave.GetVector4("var"); WorldSave.GetVector3("var1");
                    WorldSave.GetMusic(SceneManager.GetActiveScene().name);
                }
                if (File.Exists("unsavet/capterg/" + ifd.text))
                {
                    gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsavet/capterg/" + ifd.text));
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
        File.Delete("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text);
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
        if (!stand_stay)
        {
            if (!move4D)
            {



                if (Input.GetKey(KeyCode.DownArrow))
                {
                    w -= 1f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    w += 1f * Time.deltaTime;
                }
            }
            if (move4D)
            {



                if (Input.GetKey(KeyCode.DownArrow))
                {
                    w -= 10f * Time.deltaTime;
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    w += 10f * Time.deltaTime;
                }
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                Unload();
            }
        }
        
        if (FindObjectsOfType<RaymarchCam>().Length != 0)
        {
            RaymarchCam ra = FindObjectOfType<RaymarchCam>();
            ra._wPosition = w;
        }
        if (inglobalspace != true)
        {


            GetComponent<CapsuleCollider>().height = vel;
            if (tjump < -vel * 2)
            {


                GetComponent<CapsuleCollider>().height += -tjump * 0.5f;
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {


                g1.velocity = Vector3.zero;
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
            tjump = 0;
            c = new Collision();
            if (Input.GetKey(KeyCode.W))
            {

                anim.SetBool("swem", true);
                g1.velocity += g.transform.forward * 30;
            }
            if (Input.GetKey(KeyCode.S))
            {

                anim.SetBool("swem", true);
                g1.velocity += -g.transform.forward * 30;
            }
            if (Input.GetKey(KeyCode.D))
            {

                anim.SetBool("swem", true);
                g1.velocity += g.transform.right * 30;
            }
            if (Input.GetKey(KeyCode.A))
            {

                anim.SetBool("swem", true);
                g1.velocity += -g.transform.right * 30;
            }
            if (Input.GetKey(KeyCode.Space))
            {

                anim.SetBool("swem", true);
                g1.velocity += g.transform.up * 30;
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {

                anim.SetBool("swem", true);
                g1.velocity -= g.transform.up * 30;
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
            for (int i = 0; i < GameObject.FindObjectsOfType<MeshRenderer>().Length; i++)
            {
                GameObject.FindObjectsOfType<MeshRenderer>()[i].enabled = true;
                GameObject.FindObjectsOfType<MeshRenderer>()[i].material = Resources.Load<Material>("mats/xray");
                if (GameObject.FindObjectsOfType<MeshRenderer>()[i].gameObject.GetComponent<BoxCollider>())
                {
                    if (GameObject.FindObjectsOfType<MeshRenderer>()[i].gameObject.GetComponent<BoxCollider>().isTrigger == true)
                    {
                        GameObject.FindObjectsOfType<MeshRenderer>()[i].material = Resources.Load<Material>("mats/xray3");
                    }
                }
            }
            for (int i = 0; i < GameObject.FindObjectsOfType<SkinnedMeshRenderer>().Length; i++)
            {
                GameObject.FindObjectsOfType<SkinnedMeshRenderer>()[i].enabled = true;
                GameObject.FindObjectsOfType<SkinnedMeshRenderer>()[i].material = Resources.Load<Material>("mats/xray2");
            }

        }
    }

    public void physicsStop()
    {
        igr = false;
        if (tjump < -2)
        {
            Debug.Log(tjump);
            hp += Mathf.FloorToInt(tjump) / 3;
        }
        tjump = rjump;
        if (issweming)
        {
            igr = false;
            tjump = 0;
        }
        c = new Collision();
       

       
    }
    public void physicsStart()
    {
        
        c = null;
    }
    void Update()
    {
        Inputnravix();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            stand_stay = !stand_stay;
            load1.stad = stand_stay;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            move4D = !move4D;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            swapWXALL();
        }
        //
        getSignal();
        if (isplanet)
        {

            gameObject.GetComponent<PlanetGravity>().gravity = tjump;
        }
        EffectUpdate();
        if (File.Exists("unsave/capterg/" + ifd.text) && Input.GetKeyDown(KeyCode.F3))
        {
            gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + ifd.text));
            string s = "";
            s = ifd.text;
            File.WriteAllText("unsave/s", s);
            SceneManager.LoadScene(gsave.sceneid);
        }

        Ray r1 = musave.pprey();
        RaycastHit hit;
        if (UnityEngine.Physics.Raycast(r1, out hit))
        {
            if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (hit.collider.GetComponent<transport4>())
                {
                    if (hit.collider.GetComponent<transport4>().sitplayer)
                    {
                        Globalprefs.sit_player = null;
                    }
                    hit.collider.GetComponent<transport4>().sitplayer = !hit.collider.GetComponent<transport4>().sitplayer;
                    hit.collider.GetComponent<transport4>().player = transform;
                    
                }

            }
            if (hit.collider != null && Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (hit.collider.GetComponent<GravityBoard>())
                {
                    if (hit.collider.GetComponent<GravityBoard>().sitplayer)
                    {
                        Globalprefs.sit_player = null;
                    }
                    hit.collider.GetComponent<GravityBoard>().sitplayer = !hit.collider.GetComponent<GravityBoard>().sitplayer;
                    hit.collider.GetComponent<GravityBoard>().player = transform;
                }

            }

        }

        TridFace();
        if (GameObject.FindGameObjectsWithTag("oxy").Length != 0)
        {
            GameObject.FindGameObjectWithTag("oxy").GetComponent<Image>().fillAmount = oxygen / 20;
        }
        if (issweming == true)
        {
            if (!GameObject.FindGameObjectWithTag("oxy"))
            {
                Instantiate(Resources.Load<GameObject>("ui/info/oxygen").gameObject, transform.position, Quaternion.identity);
            }
            oxygen -= Time.deltaTime;
        }
        if (issweming == false && oxygen <= 5)
        {

            oxygen += Time.deltaTime;
        }
        if (issweming == false && oxygen >= 5 && oxygen <= 20)
        {
            if (GameObject.FindGameObjectWithTag("oxy"))
            {
                Destroy(GameObject.FindWithTag("oxy"));
            }
            oxygen += Time.deltaTime * 2;
        }
        if (VarSave.GetBool("partic") && 0 <= GameObject.FindObjectsOfType<ParticleSystem>().Length - 1)
        {
            DestroyImmediate(GameObject.FindObjectsOfType<ParticleSystem>()[0].gameObject);
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
            if (FindObjectsOfType<Logic_tag_3>().Length != 0)
        {
            FindObjectOfType<Logic_tag_3>().GetComponent<Camera>().fieldOfView = g2.GetComponent<Camera>().fieldOfView;
        }
        g2.GetComponent<Camera>().fieldOfView += Input.GetAxis("Mouse ScrollWheel") / vive;
        save.angularvelosyty = g1.angularVelocity;
        save.velosyty = g1.velocity;
        save.q1 = g.transform.rotation;
        save.q2 = g2.transform.rotation;
        save.pos = g.transform.position;
        save.pos2 = sr.transform.position;
        save.q3 = sr.transform.rotation;
        save.wpos = w;
        if (Get4DCam()) save.rotW = Get4DCam()._wRotation;

        save.vive = g2.GetComponent<Camera>().fieldOfView;
        if (cd != null)
        {

            save.q4 = cd.transform.rotation;
            save.pos3 = cd.position;
        }
        gsave.hp = hp;
        if (VarSave.EnterFloat("res3") && Input.GetKeyDown(KeyCode.F11))
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
            save.idsave = ifd.text;
            Directory.CreateDirectory("unsave/capter" + SceneManager.GetActiveScene().buildIndex );
            File.WriteAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + ifd.text, JsonUtility.ToJson(save));

            Directory.CreateDirectory("unsave/capter" + SceneManager.GetActiveScene().buildIndex );
            gsave.idsave = ifd.text;
            gsave.hp = hp;
            gsave.oxygen = oxygen;
            gsave.fv = faceViewi;

            gsave.Spos = planet_position;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsave/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = ifd.text;
            File.WriteAllText("unsave/s", s);
            WorldSave.SetVector4("var");
            WorldSave.SetVector3("var1");

        }

        load();

        Physics();
        if (!stand_stay && Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("sit", true);
        }
        if (!stand_stay && Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("sit", false);
        }
        Creaive();
        timesaveing();
    }

    private void Physics()
    {
        if (faceViewi != faceView.fourd)
        {
            if (c == null && !issweming && !Input.GetKey(KeyCode.F) && inglobalspace != true && !Input.GetKey(KeyCode.G))
            {
                tjump -= Time.deltaTime * gr;

                g1.velocity += -transform.up * 10;
            }

            if (issweming && inglobalspace != true)
            {
                if (tjump > 0)
                {

                    anim.SetBool("swem", true);
                    tjump -= 1 * Time.deltaTime * pl;
                }
                if (tjump <= 0)
                {


                    tjump = 0;
                }

                g1.velocity += g2.transform.forward * tjump;
                g1.useGravity = false;


                if (tjump >= rjump / 2)
                {
                    igr = false;
                }
            }
            if (!stand_stay && inglobalspace == true && Input.GetKey(KeyCode.W))
            {

                anim.SetBool("swem", true);
                gameObject.GetComponent<Rigidbody>().useGravity = false;

                g1.velocity += g2.transform.forward * pl;
                g1.useGravity = false;



            }
            if (!stand_stay && inglobalspace == true && Input.GetKey(KeyCode.S))
            {

                anim.SetBool("swem", true);
                gameObject.GetComponent<Rigidbody>().useGravity = false;

                g1.velocity -= g2.transform.forward * pl;
                g1.useGravity = false;



            }
            if (!stand_stay && inglobalspace == true && Input.GetKey(KeyCode.D))
            {

                anim.SetBool("swem", true);
                gameObject.GetComponent<Rigidbody>().useGravity = false;

                g1.velocity += g2.transform.right * pl;
                g1.useGravity = false;



            }
            if (!stand_stay && inglobalspace == true && Input.GetKey(KeyCode.A))
            {

                anim.SetBool("swem", true);

                gameObject.GetComponent<Rigidbody>().useGravity = false;
                g1.velocity -= g2.transform.right * pl;
                g1.useGravity = false;



            }
            if (!stand_stay && inglobalspace == true && Input.GetKey(KeyCode.Space))
            {

                anim.SetBool("swem", true);
                gameObject.GetComponent<Rigidbody>().useGravity = false;

                g1.velocity += g2.transform.up * pl;
                g1.useGravity = false;



            }
            if (!stand_stay && inglobalspace == true && Input.GetKey(KeyCode.LeftControl))
            {

                anim.SetBool("swem", true);

                gameObject.GetComponent<Rigidbody>().useGravity = false;
                g1.velocity -= g2.transform.up * pl;
                g1.useGravity = false;



            }
            if (!stand_stay && Input.GetKey(KeyCode.Space) && !igr && !issweming && inglobalspace != true && s2 && !Input.GetKey(KeyCode.LeftShift))
            {
                igr = true;
            }
            if (igr && !issweming && !Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.G) && s2 && inglobalspace != true)
            {
                g1.velocity += transform.up * jump * tjump;
            }
            if (igr && !issweming && !s2 && inglobalspace != true)
            {
                g1.velocity -= transform.up * tjump;
                g1.velocity += -transform.up * -50;
            }

            if (!stand_stay && Input.GetKey(KeyCode.Space) && !igr && issweming && tjump < rjump / 2 && !Input.GetKey(KeyCode.LeftShift) && inglobalspace != true)
            {
                igr = true;
            }
            if (igr && issweming && inglobalspace != true)
            {
                tjump = rjump;
            }
            if (isplanet)
            {

                gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
        }
    }

    private void MoveUpdate()
    {
        g1.velocity = Vector3.zero;
        if (cd != null)
        {

            transform.position = new Vector3(0, transform.position.y, 0);

            Ray r4 = new Ray(transform.position, new Vector3(0, -1f, 0));

            RaycastHit hit4;
            if (UnityEngine.Physics.Raycast(r4, out hit4))
            {
                if (hit4.distance <= 1.2f * -tjump)
                {
                    //  c = new Collision();
                    physicsStop();
                }
                else
                {
                    physicsStart();
                }
            }
        }
        bool yp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        if (!yp)
        {
            anim.SetBool("walke", false);
            anim.SetBool("swem", false);
            

        }
       if (Globalprefs.sit_player == null) if (faceViewi != faceView.fourd )
        {
           

            float ispeed = 10f;
            if (Input.GetKey(KeyCode.Mouse0) && Directory.Exists("debug"))
            {
                ispeed *= 2.5f;
            }
            if (Directory.Exists("debug"))
            {


            }
            

            if (!stand_stay && !issweming && inglobalspace != true && !Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.G) && del == null && !Input.GetKey(KeyCode.LeftShift))
            {

                RenderSettings.fogStartDistance = fog;
                RenderSettings.fogEndDistance = fog2; if (fogonair.a != 0)
                {
                    RenderSettings.fogColor = fogonair;
                }
                if (cd != null)
                {
                    if (Input.GetKey(KeyCode.W))
                    {

                        if (c != null)
                        {


                            anim.SetBool("walke", true);
                        }
                        g1.velocity += g.transform.forward * ispeed;
                    }
                    if (Input.GetKey(KeyCode.S))
                    {

                        if (c != null)
                        {


                            anim.SetBool("walke", true);
                        }
                        g1.velocity += -g.transform.forward * ispeed;
                    }

                    if (Input.GetKey(KeyCode.D))
                    {

                        if (c != null)
                        {


                            anim.SetBool("walke", true);
                        }
                        g1.velocity += g.transform.right * ispeed;
                    }
                    if (Input.GetKey(KeyCode.A))
                    {

                        if (c != null)
                        {


                            anim.SetBool("walke", true);
                        }
                        g1.velocity += -g.transform.right * ispeed;
                    }
                }
                if (cd == null)
                {
                    if (Input.GetKey(KeyCode.W))
                    {

                        anim.SetBool("walke", true);
                        g1.velocity += g.transform.forward * ispeed;
                    }
                    if (Input.GetKey(KeyCode.S))
                    {

                        anim.SetBool("walke", true);
                        g1.velocity += -g.transform.forward * ispeed;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {

                        anim.SetBool("walke", true);
                        g1.velocity += g.transform.right * ispeed;
                    }
                    if (Input.GetKey(KeyCode.A))
                    {

                        anim.SetBool("walke", true);
                        g1.velocity += -g.transform.right * ispeed;
                    }
                }
            }
            if (c == null && igr)
            {
                anim.SetBool("fall", true);
            }
                if (c == null && !igr)
                {
                    anim.SetBool("fall", false);
                }
                if (c != null && !igr)
                {
                    anim.SetBool("fall", false);
                }
                if (c != null && igr)
                {
                    anim.SetBool("fall", false);
                }
                if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.G))
            {
                g1.useGravity = false;
            }

            if (!Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.G) && inglobalspace != true)
            {
                tics += Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.F) && Input.GetKeyDown(KeyCode.Tab) && Getstats.GetPlayerLevel() >= 1)
            {

                if (cd)
                {
                    if (tics >= 2)
                    {

                        cd.polarTransform.preApplyTranslationZ(-1.0f / 5);
                        tics = 0;
                    }
                }
                else
                {


                    if (tics >= 2)
                    {
                        transform.Translate(0, 0, 5);
                        tics = 0;
                    }
                }
            }

            if (!stand_stay && issweming && inglobalspace == true && !Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.G) && del != null && !Input.GetKey(KeyCode.LeftShift))
            {
                if (!del.stopPlayer)
                {


                    RenderSettings.fogStartDistance = fog / 2;
                    RenderSettings.fogEndDistance = fog2 / 2;
                    RenderSettings.fogColor = fogonwater; if (cd == null)
                    {
                        if (Input.GetKey(KeyCode.W))
                        {

                            anim.SetBool("swem", true);
                            g1.velocity += g.transform.forward * ispeed / 4;
                        }
                        if (Input.GetKey(KeyCode.S))
                        {

                            anim.SetBool("swem", true);
                            g1.velocity += -g.transform.forward * ispeed / 4;
                        }
                        if (Input.GetKey(KeyCode.D))
                        {

                            anim.SetBool("swem", true);
                            g1.velocity += g.transform.right * ispeed / 4;
                        }
                        if (Input.GetKey(KeyCode.A))
                        {

                            anim.SetBool("swem", true);
                            g1.velocity += -g.transform.right * ispeed / 4;
                        }
                    }
                    if (cd != null)
                    {
                        if (Input.GetKey(KeyCode.W))
                        {

                            anim.SetBool("walke", true);
                        }
                        if (Input.GetKey(KeyCode.S))
                        {

                            anim.SetBool("walke", true);
                        }
                        if (Input.GetKey(KeyCode.D))
                        {

                            anim.SetBool("walke", true);
                        }
                        if (Input.GetKey(KeyCode.A))
                        {

                            anim.SetBool("walke", true);
                        }
                    }
                }
            }
            if (!stand_stay && !issweming && inglobalspace != true && !Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.G) && del != null && !Input.GetKey(KeyCode.LeftShift))
            {
                if (!del.stopPlayer)
                {

                    RenderSettings.fogStartDistance = fog;
                    RenderSettings.fogEndDistance = fog2; if (fogonair.a != 0)
                    {
                        RenderSettings.fogColor = fogonair;
                    }
                    if (cd == null)
                    {
                        if (Input.GetKey(KeyCode.W))
                        {

                            anim.SetBool("walke", true);
                            g1.velocity += g.transform.forward * ispeed;
                        }
                        if (Input.GetKey(KeyCode.S))
                        {

                            anim.SetBool("walke", true);
                            g1.velocity += -g.transform.forward * ispeed;
                        }
                        if (Input.GetKey(KeyCode.D))
                        {

                            anim.SetBool("walke", true);
                            g1.velocity += g.transform.right * ispeed;
                        }
                        if (Input.GetKey(KeyCode.A))
                        {

                            anim.SetBool("walke", true);
                            g1.velocity += -g.transform.right * ispeed;
                        }
                    }
                    if (cd != null)
                    {
                        if (Input.GetKey(KeyCode.W))
                        {

                            anim.SetBool("walke", true);
                        }
                        if (Input.GetKey(KeyCode.S))
                        {

                            anim.SetBool("walke", true);
                        }
                        if (Input.GetKey(KeyCode.D))
                        {

                            anim.SetBool("walke", true);
                        }
                        if (Input.GetKey(KeyCode.A))
                        {

                            anim.SetBool("walke", true);
                        }
                    }
                }
            }
            if (!stand_stay && issweming && inglobalspace != true && !Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.G) && del == null && !Input.GetKey(KeyCode.LeftShift))
            {



                RenderSettings.fogStartDistance = fog / 2;
                RenderSettings.fogEndDistance = fog2 / 2;
                RenderSettings.fogColor = fogonwater; if (cd == null)
                {
                    if (Input.GetKey(KeyCode.W))
                    {

                        anim.SetBool("swem", true);
                        g1.velocity += g.transform.forward * ispeed / 4;
                    }
                    if (Input.GetKey(KeyCode.S))
                    {

                        anim.SetBool("swem", true);
                        g1.velocity += -g.transform.forward * ispeed / 4;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {

                        anim.SetBool("swem", true);
                        g1.velocity += g.transform.right * ispeed / 4;
                    }
                    if (Input.GetKey(KeyCode.A))
                    {

                        anim.SetBool("swem", true);
                        g1.velocity += -g.transform.right * ispeed / 4;
                    }

                }
                if (cd != null)
                {
                    if (Input.GetKey(KeyCode.W))
                    {

                        anim.SetBool("swem", true);
                    }
                    if (Input.GetKey(KeyCode.S))
                    {

                        anim.SetBool("swem", true);
                    }
                    if (Input.GetKey(KeyCode.D))
                    {

                        anim.SetBool("swem", true);
                    }
                    if (Input.GetKey(KeyCode.A))
                    {

                        anim.SetBool("swem", true);
                    }

                }
            }
        }
        stop(); if (watermask)
        {


            watermask.enabled = issweming;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            if (faceViewi == faceView.first)
            {


                g2.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * sm, 0, 0));
            }
            if (faceViewi == faceView.trid)
            {


                sr.transform.Rotate(-Input.GetAxis("Mouse Y") * sm, 0, 0);
            }
            if (cd == null)
            {
                if (!Input.GetKey(KeyCode.LeftShift) && faceViewi != faceView.fourd)
                {

                    g.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * sm, 0));
                }
            }

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void HpUpdate()
    {
        if (hp <= 0)
        {
            VarSave.SetBool("умерли от ран", true);
            VarSave.SetBool("cry", true);

            gsave.hp = 20;


            gsave.idsave = ifd.text;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsave/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = ifd.text;
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


            gsave.idsave = ifd.text;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsave/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = ifd.text;
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
        if (Input.GetKeyDown(KeyCode.F5))
        {
            g.transform.rotation = Quaternion.identity;
            g2.transform.rotation = sr.transform.rotation;


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
            g2.transform.position = sr.transform.position;
            model.layer = 8;
            foreach (GameObject i in forach)
            {
                i.layer = 8;
            }
        }
        if (faceViewi == faceView.trid)
        {
            
           GameObject t = PhotoCapture.FindObjectOfType<PhotoCapture>().gameObject;
            foreach (GameObject i in forach)
            {
                i.layer = 0;
            }
            model.layer = 0;
            Ray r = new Ray(sr.transform.position, -sr.transform.forward);
            RaycastHit hit1;
            if (UnityEngine.Physics.Raycast(r, out hit1))
            {
                if (hit1.collider != null)
                {
                    if (hit1.distance < 6)
                    {

                        g2.transform.position = hit1.point;
                    }
                    if (hit1.distance > 6)
                    {

                        g2.transform.position = sr.transform.position - sr.transform.forward * 6;
                    }
                }
                else
                {
                    g2.transform.position = sr.transform.position - sr.transform.forward * 6;
                }

            }
            else
            {
                g2.transform.position = sr.transform.position - sr.transform.forward * 6;
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


            for (int i = 0; i < mybody.Length; i++)
            {
               
                if (mybody[i].GetComponent<SkinnedMeshRenderer>())
                {


                    mybody[i].GetComponent<SkinnedMeshRenderer>().materials[1] = Resources.Load<Material>("pm/playermatinvisible");
                }
            }

            //playermatinvisible
        }
        if (playerdata.Geteffect("invisible") == null)
        {
            for (int i = 0; i < mybody.Length; i++)
            {
               
                if (mybody[i].GetComponent<SkinnedMeshRenderer>())
                {


                    mybody[i].GetComponent<SkinnedMeshRenderer>().materials[1] = Resources.Load<Material>("pm/playermat");
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
            save.angularvelosyty = g1.angularVelocity;
            save.velosyty = g1.velocity;
            save.q1 = g.transform.rotation;
            save.q2 = g2.transform.rotation;
            save.pos = g.transform.position;
            save.wpos = w;
            if(Get4DCam()) save.rotW = Get4DCam()._wRotation;
            if (cd != null)
            {

                save.q4 = cd.transform.rotation;
                save.pos3 = convertPvectorinVector4(cd);
            }
            save.vive = Camera.main.fieldOfView;
            gsave.hp = hp;
            gsave.oxygen = oxygen;
            gsave.fv = faceViewi;

            save.idsave = ifd.text;
            Directory.CreateDirectory("unsave/capter" + SceneManager.GetActiveScene().buildIndex );
            File.WriteAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + ifd.text, JsonUtility.ToJson(save));
            gsave.idsave = ifd.text;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsave/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = ifd.text;
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
            save.angularvelosyty = g1.angularVelocity;
            save.velosyty = g1.velocity;
            save.q1 = g.transform.rotation;
            save.q2 = g2.transform.rotation;
            save.pos = g.transform.position;
            save.vive = Camera.main.fieldOfView;
            save.wpos = w;
            if (Get4DCam()) save.rotW = Get4DCam()._wRotation;
            if (cd!=null)
            {
                save.q4 = cd.transform.rotation;

                save.pos3 = convertPvectorinVector4(cd);
            }
            tsave.angularvelosyty = g1.angularVelocity;
            tsave.velosyty = g1.velocity;
            tsave.q1 = g.transform.rotation;
            tsave.q2 = g2.transform.rotation;
            tsave.pos = g.transform.position;
            tsave.vive = Camera.main.fieldOfView;
            tsave.wpos = w;
            timesaveing();
            gsave.hp = hp;
            gsave.oxygen = oxygen;
            gsave.fv = faceViewi;
            save.idsave = ifd.text;
            Directory.CreateDirectory("unsavet/capter" + SceneManager.GetActiveScene().buildIndex );
            File.WriteAllText("unsavet/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + ifd.text, JsonUtility.ToJson(save));
            gsave.idsave = ifd.text;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsavet/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = ifd.text;
            File.WriteAllText("unsavet/s", s);
            WorldSave.SetVector4("var");
            WorldSave.SetVector3("var1");
        }
    }
    public void timesaveing()
    {



        if (!tutorial && !Input.GetKey(KeyCode.G) && Random.Range(0,8) ==2)
        {


            Directory.CreateDirectory("unsave/capter-" + SceneManager.GetActiveScene().buildIndex);
            tsave.angularvelosyty = g1.angularVelocity;
            tsave.velosyty = g1.velocity;
            tsave.q1 = g.transform.rotation;
            tsave.q2 = g2.transform.rotation;
            tsave.pos = g.transform.position;
            tsave.pos2 = sr.transform.position;
            tsave.vive = Camera.main.fieldOfView;
            tsave.wpos = w;
            if (Get4DCam()) tsave.rotW = Get4DCam()._wRotation;
            if (cd != null)
            {
                tsave.q4 = cd.transform.rotation;

                tsave.pos3 = convertPvectorinVector4(cd);
            }
            save.idsave = ifd.text;
            DirectoryInfo di = new DirectoryInfo("unsave/capter-" + SceneManager.GetActiveScene().buildIndex);
            File.WriteAllText("unsave/capter-" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text + "-" + di.GetFiles().Length, JsonUtility.ToJson(tsave));



        }

    }
    
    public void deleteing()
    {

        if (!tutorial)
        {
            File.Delete("unsave/capter" + SceneManager.GetActiveScene().buildIndex  + "/" + ifd.text);
            
        }
        else
        {
            File.Delete("unsavet/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text);
            WorldSave.RemoveVector3();
        }

    }
}


