using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class save
{
    public string idsave;
    public Vector3 pos;
    public Quaternion q1, q2;
    public Vector3 velosyty; public Vector3 angularvelosyty;
    public float vive;
}
public class gsave
{
    public string idsave;
    public int sceneid;
    public List<string> inventory = new List<string>();
    public List<string> inventoryname = new List<string>();
}

public class mover : MonoBehaviour
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
    public float gr;
    public bool igr;
    public Collision c;
    public Animator anim;
    public float vive = int.MaxValue;

    void OnCollisionStay(Collision collision)
    {
        igr = false;
        tjump = rjump;
        c = collision;
    }
    void OnCollisionExit(Collision collision)
    {
        
        c = null;
    }
    private void Awake()
    {
        WorldSave.GetVector4("var");
        WorldSave.GetVector3("var1");
    }
    void Start()
    {
        Directory.CreateDirectory("unsave");
        Directory.CreateDirectory("unsave/capterg");
        Directory.CreateDirectory("unsave/capter"+SceneManager.GetActiveScene().buildIndex);
        if (File.Exists("unsave/s"))
        {
           ifd.text = File.ReadAllText("unsave/s");
        }
        if (File.Exists("unsave/capter" + SceneManager.GetActiveScene().buildIndex+"/" + ifd.text))
        {
            save = JsonUtility.FromJson<save>(File.ReadAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text));
            g1.angularVelocity = save.angularvelosyty; 
            g1.velocity = save.velosyty;
            g.transform.position = save.pos;
            g.transform.rotation = save.q1;
            g2.transform.rotation = save.q2;
            Camera.main.fieldOfView = save.vive;
            
        }
        
    }
    public void load()
    {
        if (Input.GetKey(KeyCode.F2))
        {
            if (File.Exists("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text))
            {
                save = JsonUtility.FromJson<save>(File.ReadAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text));
                g1.angularVelocity = save.angularvelosyty;
                g1.velocity = save.velosyty;
                g.transform.position = save.pos;
                g.transform.rotation = save.q1;
                g2.transform.rotation = save.q2;
                Camera.main.fieldOfView = save.vive;
                WorldSave.GetVector4("var"); WorldSave.GetVector3("var1");
            }
        }
    }
    public void stop()
    {
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {


            g1.velocity = Vector3.zero;
        }
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        g1.velocity = Vector3.zero;
        if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.S) || !Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D))
        {
            anim.SetBool("walke", false);
        }
        if (Input.GetKey(KeyCode.W))
        {

            anim.SetBool("walke", true);
            g1.velocity += g.transform.forward * 10;
        }
        if (Input.GetKey(KeyCode.S))
        {

            anim.SetBool("walke", true);
            g1.velocity += -g.transform.forward * 10;
        }
        if (Input.GetKey(KeyCode.D))
        {

            anim.SetBool("walke", true);
            g1.velocity += g.transform.right * 10;
        }
        if (Input.GetKey(KeyCode.A))
        {

            anim.SetBool("walke",true);
            g1.velocity += -g.transform.right * 10;
        }
        stop();

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.Locked;

            g2.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y")*sm, 0, 0));
            g.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X")*sm, 0));

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        //"unsave/capter/"+ifd.text
        //Mouse ScrollWheel
        Camera.main.fieldOfView += Input.GetAxis("Mouse ScrollWheel") / vive;
        save.angularvelosyty = g1.angularVelocity;
        save.velosyty = g1.velocity;
        save.q1 = g.transform.rotation;
        save.q2 = g2.transform.rotation;
        save.pos = g.transform.position;
        save.vive = Camera.main.fieldOfView;
       
        if (Input.GetKey(KeyCode.F1))
        {
            save.idsave = ifd.text;
            File.WriteAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text, JsonUtility.ToJson(save));
            gsave.idsave = ifd.text;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsave/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
            string s = "";
            s= ifd.text;
            File.WriteAllText("unsave/s", s);
            WorldSave.SetVector4("var");
            WorldSave.SetVector3("var1");
        }
        load(); if (c == null)
        {
            tjump -= Time.deltaTime*gr;

            g1.velocity += new Vector3(0, -10, 0);
        }
        if (Input.GetKey(KeyCode.Space) && !igr)
        {
            igr = true;
        }
        if (igr)
        {
            g1.velocity += new Vector3(0, jump * tjump, 0);
        }


        }
        public void saveing()
    {
        save.angularvelosyty = g1.angularVelocity;
        save.velosyty = g1.velocity;
        save.q1 = g.transform.rotation;
        save.q2 = g2.transform.rotation;
        save.pos = g.transform.position;
        save.vive = Camera.main.fieldOfView;
        save.idsave = ifd.text;
            File.WriteAllText("unsave/capter" + SceneManager.GetActiveScene().buildIndex + "/" + ifd.text, JsonUtility.ToJson(save));
            gsave.idsave = ifd.text;
            gsave.sceneid = SceneManager.GetActiveScene().buildIndex;
            File.WriteAllText("unsave/capterg/" + ifd.text, JsonUtility.ToJson(gsave));
            string s = "";
            s = ifd.text;
            File.WriteAllText("unsave/s", s);
        WorldSave.SetVector4("var");
        WorldSave.SetVector3("var1");
    }
    
}
