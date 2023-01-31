using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
public class useeffect
{
    public string effect = "";
    public float time = 0;
}
public class playerdata
{
    
    static public useeffect[] effects = new useeffect[3]
    {
        new useeffect(),
        new useeffect(),
        new useeffect()
    };
    static public useeffect[] Paniceffect = new useeffect[1]
    {
        new useeffect()
    };
    static public void checkeffect()
    {
        
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            
            if (i < playerdata.effects.Length)
            {


                if (playerdata.effects[i].time <= 0)
                {
                    playerdata.effects[i].effect = "";
                }
                if (playerdata.effects[i].time >= 0)
                {
                    playerdata.effects[i].time -= Time.deltaTime;
                }

            }
        }
        if (playerdata.Paniceffect[0].time <= 0)
        {
            playerdata.Paniceffect[0].effect = "";
        }
        if (playerdata.Paniceffect[0].time >= 0)
        {
            playerdata.Paniceffect[0].time -= Time.deltaTime;
        }

    }
    static public void Loadeffect()
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            useeffect[] us1 = new useeffect[1] {
               new useeffect()
           };
            if (VarSave.EnterFloat("effect_" + i))
            {
                us1[0] = JsonUtility.FromJson<useeffect>(VarSave.GetString("effect_" + i));

            }

            playerdata.effects[i] = us1[0];
        }
        useeffect[] us = new useeffect[1] {
               new useeffect()
           };
        if (VarSave.EnterFloat("effect_" + "panic"))
        {


            us[0] = JsonUtility.FromJson<useeffect>(VarSave.GetString("effect_" + "panic"));

        }

        playerdata.Paniceffect[0] = us[0];
    }
    static public void Saveeffect()
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
           

            VarSave.SetString("effect_"+i,JsonUtility.ToJson(playerdata.effects[i]));



        }
        
        VarSave.SetString("effect_" + "panic", JsonUtility.ToJson(playerdata.Paniceffect[0]));
    }
    static public void Addeffect(string name, float time)
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            if (playerdata.effects[i].effect == "")
            {
                playerdata.effects[i].effect = name;
                playerdata.effects[i].time = time;
                i = playerdata.effects.Length;
            }
        }
    }
    static public void SetPaniceffect(string name, float time)
    {
        playerdata.Paniceffect[0].effect = name;
        playerdata.Paniceffect[0].time = time;
    }
    static public void Cleareffect()
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            playerdata.effects[i].effect = "";
            playerdata.effects[i].time = 0;
        }
    }
    static public useeffect Geteffect(string name)
    {
        useeffect ef = null;
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            if (playerdata.effects[i].effect == name)
            {
                ef = playerdata.effects[i];
            }
        }
        if (playerdata.Paniceffect[0].effect != "")
        {
            ef = playerdata.Paniceffect[0];
        }
        return ef;
    }
    public static int overload()
    {
        int defult = 1;
        if (playerdata.Geteffect("overload") != null)
        {
            defult = 2;
        }
        return defult;
    }
}
public class currentAtackk
{

}
public class musave : MonoBehaviourPunCallbacks
{
    public static string saveid;
    public static void save()
    {
        FindObjectOfType<getind>().save();
        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {


            GameObject.FindObjectOfType<mover>().saveing();
        }
        if (GameObject.FindObjectsOfType<player>().Length != 0)
        {
            Photon.Pun.PhotonView[] players = new Photon.Pun.PhotonView[0];
            players = GameObject.FindObjectsOfType<Photon.Pun.PhotonView>();

            for (int i = 0; i < players.Length; i++)
            {

                if (players[i].IsMine)
                {
                    players[i].GetComponent<player>().redownsave();
                }

            }
        }
    }
    public static void saveandhill()
    {
        FindObjectOfType<getind>().save();
        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {

            GameObject.FindObjectOfType<mover>().hp = 200;
            GameObject.FindObjectOfType<mover>().saveing();
        }
        if (GameObject.FindObjectsOfType<player>().Length != 0)
        {
            Photon.Pun.PhotonView[] players = new Photon.Pun.PhotonView[0];
            players = GameObject.FindObjectsOfType<Photon.Pun.PhotonView>();

            for (int i = 0; i < players.Length; i++)
            {

                if (players[i].IsMine)
                {
                    players[i].GetComponent<player>().hp = 200;
                    players[i].GetComponent<player>().redownsave();
                }

            }
        }
    }
    public static Transform GetPlayer()
    {
        Transform t = GameObject.FindObjectOfType<GameObject>().transform;
        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {


           t = GameObject.FindObjectOfType<mover>().transform;
            
        }
        if (GameObject.FindObjectsOfType<player>().Length != 0)
        {
            Photon.Pun.PhotonView[] players = new Photon.Pun.PhotonView[0];
            players = GameObject.FindObjectsOfType<Photon.Pun.PhotonView>();


            for (int i = 0; i < players.Length; i++)
            {

                if (players[i].IsMine)
                {
                    Photon.Pun.PhotonNetwork.MasterClient.NickName = players[Random.Range(0, players.Length)].ViewID.ToString();
                    t = Photon.Pun.PhotonNetwork.GetPhotonView(int.Parse(Photon.Pun.PhotonNetwork.MasterClient.NickName)).transform;

                }
            }







                }
                return t;
    }
    static public void load(Transform transform)
    {
        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {


            GameObject.FindWithTag("Player").transform.position = transform.position;
        }
        if (GameObject.FindObjectsOfType<player>().Length != 0)
        {
            Photon.Pun.PhotonView[] players = new Photon.Pun.PhotonView[0];
            players = GameObject.FindObjectsOfType<Photon.Pun.PhotonView>();

            for (int i = 0; i < players.Length; i++)
            {

                if (players[i].IsMine)
                {
                    players[i].GetComponent<player>().transform.position = transform.position;
                }

            }
        }

    }
    static public void load5(Polar3 pl,float i3)
    {
        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {


            GameObject.FindObjectsOfType<mover>()[0].cd.polarTransform = pl;
            GameObject.FindObjectsOfType<mover>()[0].transform.position = new Vector3(0,i3*2,0);
        }
        if (GameObject.FindObjectsOfType<player>().Length != 0)
        {
            Photon.Pun.PhotonView[] players = new Photon.Pun.PhotonView[0];
            players = GameObject.FindObjectsOfType<Photon.Pun.PhotonView>();

            for (int i = 0; i < players.Length; i++)
            {

                if (players[i].IsMine)
                {
                    players[i].GetComponent<player>().cd.polarTransform = pl;
                    players[i].GetComponent<player>().transform.position = new Vector3(0, i3, 0);
                }

            }
        }

    }
    static public void GetUF()
    {
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A)
            && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.Mouse1))
        {
            for (int i = 0; i < Resources.LoadAll<Material>("UF").Length; i++)
            {
                if (Resources.LoadAll<Material>("UF")[i].color.a <1)
                {


                    Resources.LoadAll<Material>("UF")[i].color = new Color(Resources.LoadAll<Material>("UF")[i].color.r, Resources.LoadAll<Material>("UF")[i].color.g, Resources.LoadAll<Material>("UF")[i].color.b, Resources.LoadAll<Material>("UF")[i].color.a);
                    Resources.LoadAll<Material>("UF")[i].color += new Color(0, 0, 0, Time.deltaTime / 2);
                }
            }
        }
        else
        {
            for (int i = 0; i < Resources.LoadAll<Material>("UF").Length; i++)
            {
                Resources.LoadAll<Material>("UF")[i].color = new Color(Resources.LoadAll<Material>("UF")[i].color.r, Resources.LoadAll<Material>("UF")[i].color.g, Resources.LoadAll<Material>("UF")[i].color.b, 0);
            }
        }
    }
    static public Ray pprey()
    {
        Ray r = new Ray();
        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {


            r = GameObject.FindObjectOfType<Logic_tag_3>().GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            GameObject.FindObjectOfType<Logic_tag_3>().GetComponent<Camera>().targetDisplay = 2;
        }
        if (GameObject.FindObjectsOfType<player>().Length != 0)
        {
            Photon.Pun.PhotonView[] players = new Photon.Pun.PhotonView[0];
            players = GameObject.FindObjectsOfType<Photon.Pun.PhotonView>();

            for (int i = 0; i < players.Length; i++)
            {

                if (players[i].IsMine)
                {
                    
                    r = players[i].GetComponent<player>().g2.transform.GetChild(0).GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                    players[i].GetComponent<player>().g2.transform.GetChild(0).GetComponent<Camera>().targetDisplay = 2;
                }

            }
        }
        return r;

    }
    static public void fall(GameObject other)
    {

        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {


            if (other.tag == "Player" && other.gameObject.GetComponent<mover>().tjump <= -2)
            {

                other.gameObject.GetComponent<mover>().tjump = -2;
            }
        }
        if (GameObject.FindObjectsOfType<player>().Length != 0)
        {

            if (other.tag == "Player" && other.gameObject.GetComponent<player>().tjump <= -2)
            {

                other.gameObject.GetComponent<player>().tjump = -2;


            }
        }


    }
    static public void chargescene(int scene)
    {
        FindObjectOfType<getind>().save();
        if (!Photon.Pun.PhotonNetwork.IsConnected)
        {

            SceneManager.LoadScene(scene);
            
        }
        if (Photon.Pun.PhotonNetwork.IsConnected)
        {
            

                
                musave.scene = scene;

            Photon.Pun.PhotonView[] players = new Photon.Pun.PhotonView[0];
            players = GameObject.FindObjectsOfType<Photon.Pun.PhotonView>();

            for (int i = 0; i < players.Length; i++)
            {

                if (players[i].IsMine)
                {
                    
                        players[i].GetComponent<player>().leave();
                    
                }

            }





            }


    }
    static public int scene = 0;
    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.Log("OnPlayerLeftRoom() " + other.NickName); // seen when other disconnects
        if (PhotonNetwork.IsMasterClient)
        {
            
        }
    }

    public override void OnLeftRoom()
    {




        if (PhotonNetwork.IsMasterClient)
        {
            
        }









    }

    //Photon.Realtime.RoomOptions roomOptions = new Photon.Realtime.RoomOptions();
  //  roomOptions.MaxPlayers = 3;
     //   PhotonNetwork.JoinOrCreateRoom(musave.saveid + musave.scene, roomOptions, TypedLobby.Default);
    
    static public Transform isplayer()
    {
        Transform t = GameObject.FindObjectsOfType<GameObject>()[0].transform;
        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {


            t = GameObject.FindObjectsOfType<mover>()[Random.Range(0, GameObject.FindObjectsOfType<mover>().Length)].transform;
        }
        if (GameObject.FindObjectsOfType<player>().Length != 0)
        {
            Photon.Pun.PhotonView[] players = new Photon.Pun.PhotonView[0];
            players = GameObject.FindObjectsOfType<Photon.Pun.PhotonView>();

            
                if (PhotonNetwork.MasterClient.IsMasterClient)
                {
                    PhotonNetwork.NickName = Random.Range(0,players.Length).ToString();
                }
            t = players[int.Parse( PhotonNetwork.MasterClient.NickName)].transform;
        }
            return t;

    }
    static public bool player(GameObject a)
    {
        bool t = false;
        if (Photon.Pun.PhotonNetwork.IsConnected)
        {
            Photon.Pun.PhotonView[] players = new Photon.Pun.PhotonView[0];
            players = GameObject.FindObjectsOfType<Photon.Pun.PhotonView>();

            for (int i = 0; i < players.Length; i++)
            {

                if (a.gameObject.GetComponent<PhotonView>().IsMine)
                {

                    t = true;

                }
            }
                
        }
        if (!Photon.Pun.PhotonNetwork.IsConnected)
        {
            t = true;
        }

        return t;

    }
}

public class player : MonoBehaviour
{
    public GameObject g;
    public GameObject g2;
    public Rigidbody g1;
    public float sm;
    public save save = new save();
    public gsave gsave = new gsave();
    public InputField ifd;
    public float tjump;
    public float jump;
    public float rjump;
    public float gr; public float pl;
    public bool igr;
    public bool issweming;
    public Collision c;
    public Animator anim;
    public float vive = int.MaxValue;
    public RawImage watermask;
    public float fog; public float fog2;
    public Color fogonwater;
    public Color fogonair = new Color(0, 0, 0, 0);
    public int hp = 200; private float oxygen = 20;
    float tic, time = 4; public float tic2, time2 = 4;
    bool s2 = true;
    bool isthirdperson;
    bool isplanet;
    bool isCamd;
    public GameObject sr; 
    public GameObject thelight;
    public Material memat;
    public Material othermat;
    public GameObject[] mybody;
    float tics;
    float vel;
    public Color d;
    public Camd cd = null;
    public Camdpoint sp = null;
    public GameObject model;
    public Vector4 convertPvectorinVector4(Camd c1)
    {
        Vector4 v4 = new Vector4();
        v4.x = c1.polarTransform.n;
        v4.y = c1.polarTransform.s;
        v4.z = c1.polarTransform.m;
        v4.w = c1.transform.position.y;
        return v4;
    }
    public void convertinPvector(Vector4 v4, Camd c1)
    {
        c1.polarTransform.n = v4.x;
        c1.polarTransform.s = v4.y;
        c1.polarTransform.m = v4.z;
        c1.transform.position = new Vector3(0, v4.w, 0);

    }
    public void load()
    {
        if (Input.GetKey(KeyCode.F2))
        {
            if (GetComponent<Photon.Pun.PhotonView>().IsMine)
            {
                playerdata.Loadeffect();
            }
            if (File.Exists("munsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text))
            {
                save = JsonUtility.FromJson<save>(File.ReadAllText("munsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text));
                g1.angularVelocity = save.angularvelosyty;
                g1.velocity = save.velosyty;
                g.transform.position = save.pos; sr.transform.position = save.pos2;
                g.transform.rotation = save.q1;
                sr.transform.rotation = save.q3;
                g2.transform.rotation = save.q2;
                if (cd != null)
                {

                    cd.transform.rotation = save.q4;
                    convertinPvector(save.pos3, cd);
                }
                Camera.main.fieldOfView = save.vive;
                WorldSave.GetVector4("var"); WorldSave.GetVector3("var1");
                WorldSave.GetMusic(SceneManager.GetActiveScene().name);
            }
            if (File.Exists("munsave/capterg/" + ifd.text))
            {
                gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("munsave/capterg/" + ifd.text));
                hp = gsave.hp;
                oxygen = gsave.oxygen;
                isthirdperson = gsave.tp;
            }
        }
    }
    public void main_load()
    {

        if (isplanet)
        {
            gameObject.AddComponent<PlanetGravity>().body = transform;
            gameObject.GetComponent<PlanetGravity>().gravity = tjump;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
        playerdata.Loadeffect();
        ionenergy.energy = 0;
        if (GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            playerdata.Loadeffect();
        }
        vel = GetComponent<CapsuleCollider>().height;
        Photon.Pun.PhotonNetwork.NickName = SceneManager.GetActiveScene().name;
        
        gr = load1.gr;
        jump = load1.jump;
        tjump = load1.tjump;
        rjump = load1.rjump; 
        isplanet = load1.isplanet;
        isCamd = load1.isCamd;
        if (isCamd == true)
        {
            if (GetComponent<Photon.Pun.PhotonView>().IsMine)
            {
              cd =  gameObject.AddComponent<Camd>();
                cd.light1 = Light.GetLights(LightType.Directional,0)[0];
                cd.radiuscolider = 2;
                cd.rb = g1;
                cd.polarTransform =load1.pt;
            }
        }
        if (isCamd == true)
        {
            if (!GetComponent<Photon.Pun.PhotonView>().IsMine)
            {
              sp =  gameObject.AddComponent<Camdpoint>();
                sp.ls = Vector3.one;
            }
        }
        pl = load1.pl;
        watermask = load1.watermask;
        if (!load1.islight)
        {
            Destroy(thelight);
        }
        g2.GetComponent<Camera>().backgroundColor = load1.bg;
        g2.GetComponent<Camera>().clearFlags = load1.bg2;
        WorldSave.GetVector4("var");
        WorldSave.GetVector3("var1");
        WorldSave.GetMusic(SceneManager.GetActiveScene().name);
        Directory.CreateDirectory("munsave");
        Directory.CreateDirectory("munsave/capterg");
        Directory.CreateDirectory("munsave/capter" + SceneManager.GetActiveScene().buildIndex);
        if (File.Exists("munsave/s"))
        {
            ifd.text = File.ReadAllText("munsave/s");
        }
        if (File.Exists("munsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text))
        {
            save = JsonUtility.FromJson<save>(File.ReadAllText("munsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text));
            g1.angularVelocity = save.angularvelosyty;
            g1.velocity = save.velosyty;
            if (!portallNumer.p2 && !portallNumer.p1 && !portallNumer.p3 && !portallNumer.p4)
            {
                g.transform.position = save.pos;
                sr.transform.position = save.pos2;
            }
            g.transform.rotation = save.q1;
            sr.transform.rotation = save.q3;
            g2.transform.rotation = save.q2;
            if (cd != null)
            {

                cd.transform.rotation = save.q4;
                convertinPvector(save.pos3, cd);
            }
            Camera.main.fieldOfView = save.vive;

        }
        if (File.Exists("munsave/capterg/" + ifd.text))
        {
            gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("munsave/capterg/" + ifd.text));
            hp = gsave.hp;
            oxygen = gsave.oxygen;
            isthirdperson = gsave.tp;
        }
    }
    public void stop()
    {

        if (GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            GetComponent<CapsuleCollider>().height = vel * g1.velocity.y * 2;
            if (g1.velocity.y < -vel * 2)
            {
                GetComponent<CapsuleCollider>().height = vel * g1.velocity.y * 2;
            }
            if (g1.velocity.y > -vel * 2)
            {
                GetComponent<CapsuleCollider>().height = vel;
            }
            if (tjump < vel * 2)
            {


                GetComponent<CapsuleCollider>().height += -tjump * 1f;
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {


                g1.velocity = Vector3.zero;
            }
        }

        }
    void OnCollisionExit(Collision collision)
    {
        if (GetComponent<Photon.Pun.PhotonView>().IsMine)
        {

            c = null;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (GetComponent<Photon.Pun.PhotonView>().IsMine)
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
        }
        private void OnTriggerEnter(Collider other)
    {
        if (GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            if (other.tag == "dead")
            {
                VarSave.SetBool("обычный сельский бог гипер смерти урбил вас", true);
                VarSave.SetBool("cry", true);

              musave.chargescene(SceneManager.GetActiveScene().buildIndex);

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
    }
    private void OnTriggerStay(Collider other)
    {
        if (GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            if (other.tag == "lagi")
            {
                g2.GetComponent<Camera>().enabled = 1 == Random.Range(0, 3);

            }
        }

    }

        private void OnTriggerExit(Collider other)
    {
        if (GetComponent<Photon.Pun.PhotonView>().IsMine)
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
    }
    private void Awake()
    {
        Camera c = Instantiate(Resources.Load<GameObject>("point"), g2.transform).AddComponent<Camera>();
        c.targetDisplay = 2;
        c.targetTexture = new RenderTexture(Screen.width,Screen.height,1000);
        if (GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            GetComponent<Photon.Pun.PhotonView>().RPC("setColor", RpcTarget.OthersBuffered, memat.color.r, memat.color.g, memat.color.b);
            for (int i = 0; i < mybody.Length; i++)
            {
                if (mybody[i].GetComponent<MeshRenderer>())
                {


                    mybody[i].GetComponent<MeshRenderer>().material = memat;
                }
                if (mybody[i].GetComponent<SkinnedMeshRenderer>())
                {


                    mybody[i].GetComponent<SkinnedMeshRenderer>().material = memat;
                }
            }
        }
        
       
        Ray r1 = new Ray(g2.transform.position, g2.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(r1, out hit))
        {
            if (hit.collider != null && Input.GetKeyDown(KeyCode.Tab))
            {
                if (hit.collider.GetComponent<transport4>())
                {
                    hit.collider.GetComponent<transport4>().sitplayer = !hit.collider.GetComponent<transport4>().sitplayer;
                    hit.collider.GetComponent<transport4>().player = transform;
                }

            }

        }

        if (GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            Instantiate(Resources.Load<GameObject>("player inventory"));

        }
        if (GetComponent<Photon.Pun.PhotonView>().IsMine && VarSave.GetBool("postrender") == true)
        {
            Instantiate(Resources.LoadAll<GameObject>("ui/postrender")[0]);

        }
        main_load();
        if (!GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            g2.GetComponent<Camera>().enabled = false;
        }
        if (GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            if (File.Exists("unauticna.license"))
            {
                if (Resources.Load<license>("delux/license").code + Resources.Load<license>("delux/license").version == File.ReadAllText("unauticna.license"))
                {
                    for (int i3 = 0; i3 < GameObject.FindGameObjectsWithTag("license").Length; i3++)
                    {





                        GameObject.FindGameObjectsWithTag("license")[i3].AddComponent<deleter1>();

                    }
                }
            }
            if (File.Exists("unauticna.license"))
            {
                if (Resources.Load<license>("delux/license").code + Resources.Load<license>("delux/license").version != File.ReadAllText("unauticna.license"))
                {
                    for (int i3 = 0; i3 < GameObject.FindGameObjectsWithTag("delux").Length; i3++)
                    {





                        GameObject.FindGameObjectsWithTag("delux")[i3].AddComponent<deleter1>();

                    }
                }
            }
            if (!File.Exists("unauticna.license"))
            {

                for (int i3 = 0; i3 < GameObject.FindGameObjectsWithTag("delux").Length; i3++)
                {





                    GameObject.FindGameObjectsWithTag("delux")[i3].AddComponent<deleter1>();

                }

            }
            if (GetComponent<Photon.Pun.PhotonView>().IsMine)
            {
                WorldSave.GetVector4("var");
                WorldSave.GetVector3("var1");
                WorldSave.GetMusic(SceneManager.GetActiveScene().name);

            }
        }
    }
    void Start()
    {
        if (GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            fog = RenderSettings.fogStartDistance;
            fog2 = RenderSettings.fogEndDistance;
            if (VarSave.GetBool("cry"))
            {
                Instantiate(Resources.Load<GameObject>("ui/defet/achievement").gameObject, transform.position, Quaternion.identity);

                VarSave.SetBool("cry", false);
            }
            if (VarSave.EnterFloat("mus"))
            {
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("game musig").Length; i++)
                {
                    GameObject.FindGameObjectsWithTag("game musig")[i].GetComponent<AudioSource>().volume = VarSave.GetFloat("mus");
                }
            }
        }


    }
    void Update()
    {
        if (!GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            for (int i = 0; i < mybody.Length; i++)
            {
                if (mybody[i].GetComponent<MeshRenderer>())
                {


                    mybody[i].GetComponent<MeshRenderer>().material.color = d;
                }
                if (mybody[i].GetComponent<SkinnedMeshRenderer>())
                {


                    mybody[i].GetComponent<SkinnedMeshRenderer>().material.color = d;
                }
            }
        }
        if (isplanet)
        {

            gameObject.GetComponent<PlanetGravity>().gravity = tjump;
        }
        musave.GetUF();
        if (!GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
           Destroy(g2.GetComponent<AudioListener>());
        }
            if (GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            playerdata.checkeffect();
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
            if (hp <= 0)
            {
                VarSave.SetBool("умерли от ран", true);
                VarSave.SetBool("cry", true);

                gsave.hp = 20;


                gsave.idsave = ifd.text;
                gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
                File.WriteAllText("munsave/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
                string s = "";
                s = ifd.text;
                File.WriteAllText("munsave/s", s);
                WorldSave.SetVector4("var");
                WorldSave.SetVector3("var1");

               musave.chargescene(SceneManager.GetActiveScene().buildIndex);

            }
            if (oxygen <= 0)
            {
                VarSave.SetBool("oxygen", true);
                VarSave.SetBool("cry", true);

                gsave.oxygen = 20;


                gsave.idsave = ifd.text;
                gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
                File.WriteAllText("munsave/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
                string s = "";
                s = ifd.text;
                File.WriteAllText("munsave/s", s);
                WorldSave.SetVector4("var");
                WorldSave.SetVector3("var1");

                musave.chargescene(SceneManager.GetActiveScene().buildIndex);

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
            load();
        if (GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            Ray r1 = new Ray(g2.transform.position, g2.transform.forward);
            RaycastHit hit1;
            if (Physics.Raycast(r1, out hit1))
            {
                if (hit1.collider != null && Input.GetKeyDown(KeyCode.Tab))
                {
                    if (hit1.collider.GetComponent<transport4>())
                    {
                        hit1.collider.GetComponent<transport4>().sitplayer = !hit1.collider.GetComponent<transport4>().sitplayer;
                        hit1.collider.GetComponent<transport4>().player = transform;
                    }

                }

            }
        }
        if (GetComponent<Photon.Pun.PhotonView>().IsMine)
        {


            if (!isthirdperson)
            {
                g2.transform.position = sr.transform.position;
                model.SetActive(false);
            }
            if (isthirdperson)
            {
                model.SetActive(true);
                Ray r = new Ray(sr.transform.position, -sr.transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(r, out hit))
                {
                    if (hit.collider != null)
                    {
                        if (hit.distance < 6)
                        {

                            g2.transform.position = hit.point;
                        }
                        if (hit.distance > 6)
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




            if (VarSave.GetBool("partic") && 0 <= GameObject.FindObjectsOfType<ParticleSystem>().Length - 1)
            {
                DestroyImmediate(GameObject.FindObjectsOfType<ParticleSystem>()[0].gameObject);
            }

            WorldSave.SetMusic(SceneManager.GetActiveScene().name);
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
            g1.velocity = Vector3.zero;
            if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S) || !Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D))
            {
                anim.SetBool("walke", false);
                anim.SetBool("swem", false);
            }
            if (cd != null)
            {
                c = null;
                transform.position = new Vector3(0, transform.position.y, 0);

                Ray r4 = new Ray(transform.position, new Vector3(0, -1f, 0));

                RaycastHit hit4;
                if (Physics.Raycast(r4, out hit4))
                {
                    if (hit4.distance <= 1.2f)
                    {
                        c = new Collision();
                    }
                }
            }
            float ispeed = 10f;
            if (cd != null)
            {
                if (!issweming && !Input.GetKey(KeyCode.F))
                {

                    RenderSettings.fogStartDistance = fog;
                    RenderSettings.fogEndDistance = fog2; if (fogonair.a != 0)
                    {
                        RenderSettings.fogColor = fogonair;
                    }
                    if (Input.GetKey(KeyCode.W))
                    {

                        if (c != null)
                        {


                            anim.SetBool("walke", true);
                        }
                    }
                    if (Input.GetKey(KeyCode.S))
                    {

                        if (c != null)
                        {


                            anim.SetBool("walke", true);
                        }
                    }
                    if (Input.GetKey(KeyCode.D))
                    {

                        if (c != null)
                        {


                            anim.SetBool("walke", true);
                        }
                    }
                    if (Input.GetKey(KeyCode.A))
                    {

                        if (c != null)
                        {


                            anim.SetBool("walke", true);
                        }
                    }
                }
            }
            if (cd == null)
            {
                if (!issweming && !Input.GetKey(KeyCode.F))
                {

                    RenderSettings.fogStartDistance = fog;
                    RenderSettings.fogEndDistance = fog2; if (fogonair.a != 0)
                    {
                        RenderSettings.fogColor = fogonair;
                    }
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
            }
            if (c == null)
            {
                anim.SetBool("fall", true);
            }
            if (c != null)
            {
                anim.SetBool("fall", false);
            }
            if (Input.GetKey(KeyCode.F))
            {
                g1.useGravity = false;
            }
            if (Input.GetKeyDown(KeyCode.F5))
            {
                g.transform.rotation = Quaternion.identity;
                g2.transform.rotation = sr.transform.rotation;

                isthirdperson = !isthirdperson;
            }
            if (!Input.GetKey(KeyCode.F))
            {
                g1.useGravity = true;
            }
            if (cd != null)
            {
                if (issweming && !Input.GetKey(KeyCode.F))
                {
                    RenderSettings.fogStartDistance = fog / 2;
                    RenderSettings.fogEndDistance = fog2 / 2;
                    RenderSettings.fogColor = fogonwater;
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
            if (cd == null)
            {
                if (issweming && !Input.GetKey(KeyCode.F))
                {
                    RenderSettings.fogStartDistance = fog / 2;
                    RenderSettings.fogEndDistance = fog2 / 2;
                    RenderSettings.fogColor = fogonwater;
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
            }
            stop(); if (watermask)
            {


                watermask.enabled = issweming;
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                Cursor.lockState = CursorLockMode.Locked;
                if (!isthirdperson)
                {


                    g2.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * sm, 0, 0));
                }
                if (isthirdperson)
                {


                    sr.transform.Rotate(-Input.GetAxis("Mouse Y") * sm, 0, 0);
                }
                if (cd == null)
                {
                    g.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * sm, 0));
                }

                }
                else
            {
                Cursor.lockState = CursorLockMode.None;
            }

            //"unsave/capter/"+ifd.text
            //Mouse ScrollWheel

            upsave(); 
            downsave();

            if (c == null && !issweming && !Input.GetKey(KeyCode.F))
            {
                tjump -= Time.deltaTime * gr;

                g1.velocity += new Vector3(0, -10, 0);
            }
            if (issweming)
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
            if (Input.GetKey(KeyCode.Space) && !igr && !issweming && s2)
            {
                igr = true;
            }
            if (igr && !issweming && !Input.GetKey(KeyCode.F) && s2)
            {
                g1.velocity += new Vector3(0, jump * tjump, 0);
            }
            if (igr && !issweming && !s2)
            {
                g1.velocity += new Vector3(0, tjump, 0);
                g1.velocity = -new Vector3(0, 50, 0);
            }

            if (Input.GetKey(KeyCode.Space) && !igr && issweming && tjump < rjump / 2)
            {
                igr = true;
            }
            if (igr && issweming)
            {
                tjump = rjump;
            }

            if (isplanet)
            {

                gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetBool("sit", true);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetBool("sit", false);
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
            if (!Input.GetKey(KeyCode.F))
            {
                tics += Time.deltaTime;
                g1.useGravity = true;
            }
        }

    }
    public void upsave()
    {
        
        Camera.main.fieldOfView += Input.GetAxis("Mouse ScrollWheel") / vive;
        save.angularvelosyty = g1.angularVelocity;
        save.velosyty = g1.velocity;
        save.q1 = g.transform.rotation;
        save.q2 = g2.transform.rotation;
        save.pos = g.transform.position;
        save.pos2 = sr.transform.position;
        save.q3 = sr.transform.rotation;
        save.vive = Camera.main.fieldOfView;
        if (cd != null)
        {
            
            save.q4 = cd.transform.rotation;
            save.pos3 = convertPvectorinVector4(cd);
            GetComponent<PhotonView>().RPC("setPVector",RpcTarget.Others, save.pos3.x, save.pos3.y, save.pos3.z, save.pos3.w);
        }
        gsave.hp = hp;

    }
    public void downsave()
    {
        if (Input.GetKey(KeyCode.F1))
        {
            if (GetComponent<Photon.Pun.PhotonView>().IsMine)
            {
                playerdata.Saveeffect();
            }
            save.idsave = ifd.text;
            File.WriteAllText("munsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text, JsonUtility.ToJson(save));
            gsave.idsave = ifd.text;
            gsave.hp = hp;
            gsave.oxygen = oxygen;
            gsave.tp = isthirdperson;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("munsave/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = ifd.text;
            File.WriteAllText("munsave/s", s);
            WorldSave.SetVector4("var");
            WorldSave.SetVector3("var1");

        }

    }
    public void redownsave()
    {
        if (GetComponent<Photon.Pun.PhotonView>().IsMine)
        {
            playerdata.Saveeffect();
        }
        save.idsave = ifd.text;
            File.WriteAllText("munsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text, JsonUtility.ToJson(save));
            gsave.idsave = ifd.text;
            gsave.hp = hp;
            gsave.oxygen = oxygen;
            gsave.tp = isthirdperson;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("munsave/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = ifd.text;
            File.WriteAllText("munsave/s", s);
            WorldSave.SetVector4("var");
            WorldSave.SetVector3("var1");

        

    }
     public void leave()
    {
        StartCoroutine(disconnectandload());
    }
    IEnumerator disconnectandload()
    {
        PhotonNetwork.LeaveRoom();
        while (PhotonNetwork.InRoom)
        {
            yield return null;

        }
        SceneManager.LoadScene("test");
    }
}
