using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceSheepPosition
{
    public Vector3 pos;
    public Quaternion rot;
    public Hyperbolic2D hyperbolic;
}
public enum size
{
    Stars, Galaxy, Universe, Multyverse, Anyverse
}
public enum UniverseSkyType
{
    Default,Bright,Arua,Darck,Litch
}
public class Targets
{
    public List<Vector3> vector3s = new List<Vector3>();

    public List<Hyperbolic2D> hyperbolic2Ds = new List<Hyperbolic2D>();
}

public class RayCastStars : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] UniverseSkyType skyType;
    SpaceSheepPosition scp = new SpaceSheepPosition();
    public HyperbolicCamera HyperbolicCamera;
    public string[] scenename;
    public size s;
    private void Start()
    {

        Instantiate(Resources.Load<GameObject>("audios/Nill"), transform.position, Quaternion.identity);
        VarSave.SetString("scppos", SceneManager.GetActiveScene().name);
        VarSave.SetString("Universe_Position", SceneManager.GetActiveScene().name);
      if(s== size.Universe)  VarSave.SetInt("UST",((int)skyType));
        if (s == size.Galaxy) VarSave.SetString("Universe_galaxy_Position", SceneManager.GetActiveScene().name);
        if (s == size.Universe) VarSave.SetString("Multyverse_Universe_Position", SceneManager.GetActiveScene().name);
        if (s == size.Multyverse) VarSave.SetString("Multyverse_Position", SceneManager.GetActiveScene().name);

        if (VarSave.ExistenceVar("scp"+SceneManager.GetActiveScene().name))
        {
            scp = JsonUtility.FromJson<SpaceSheepPosition>(VarSave.GetString("scp" + SceneManager.GetActiveScene().name));
            transform.position = scp.pos;
            transform.rotation = scp.rot;
          if(HyperbolicCamera)  HyperbolicCamera.RealtimeTransform = scp.hyperbolic;
        }

        LoadTargets();
    }
    private void OnGUI()
    {
        if (s == size.Universe) GUI.Label(new Rect(0f, 20, 300f, 100f), "Universe (*) : " + Globalprefs.GetIdUniverse());
        if (s == size.Multyverse) GUI.Label(new Rect(0f, 20, 300f, 100f), "Multiverse (*) : " + Globalprefs.GetIdMultiverse());
        if (s == size.Galaxy) GUI.Label(new Rect(0f, 20, 300f, 100f), "Galaxy (*) : " + Globalprefs.GetIdGalaxy());
        if (s == size.Stars) GUI.Label(new Rect(0f, 20, 300f, 100f), "Stars (*) : " + Globalprefs.GetIdStars());
        for (int i = 0; i < GameObject.FindObjectsByType<Metka>(sortmode.main).Length; i++)
        {

            Vector3 t = Camera.main.WorldToViewportPoint(GameObject.FindObjectsByType<Metka>(sortmode.main)[i].transform.position);
            if (t.z > 0)
            {
                Vector3 u = Camera.main.ViewportToScreenPoint(t);
                GUI.DrawTexture(new Rect(u.x - 10, (Screen.height - u.y) - 10, 20, 20), GameObject.FindObjectsByType<Metka>(sortmode.main)[i].GetComponent<MeshRenderer>().sharedMaterial.GetTexture("_MainTex"));
            }
        }

    }
    public decimal GetPointAnyverse()
    {
        if (s == size.Universe) return Globalprefs.GetIdUniverse();
        if (s == size.Multyverse) return Globalprefs.GetIdMultiverse();
        if (s == size.Galaxy) return Globalprefs.GetIdGalaxy();
        if (s == size.Stars) return Globalprefs.GetIdStars(); 
        return 0;
    }
    public decimal Fract(decimal value) { return value - decimal.Truncate(value); }
    public float Frac(float value)
    {
        return (float)Fract((decimal)value);
    }
    float Hash(Vector2 p)
    {
        float d = Vector2.Dot(-p, new Vector2(12.9898f, 78.233f));
        return Frac(Mathf.Sin(d) * 43758.5453123f);
    }
    void Update()
    {
        scp.pos = transform.position;
        scp.rot = transform.rotation;

        if (Input.GetKeyDown("1"))
        {
            Transform t = Instantiate(Resources.Load<GameObject>("SpaceItems/PowerMetka").gameObject, transform.position, Quaternion.identity).transform;

            if (s == size.Multyverse) {


                HyperbolicCamera c = HyperbolicCamera.Main();
                t.gameObject.AddComponent<HyperbolicPoint>().HyperboilcPoistion = c.RealtimeTransform.inverse();
                t.transform.position = new Vector3(
                    0,
                    t.transform.position.y,
                    0
                    );
                t.gameObject.GetComponent<HyperbolicPoint>().ScriptSacle = t.localScale;
            }
        }

        if (HyperbolicCamera) scp.hyperbolic = HyperbolicCamera.RealtimeTransform;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.distance < 500)
            {
                if (hit.collider.tag == "Star" && s == size.Stars)
                {

                    int o = (int)(hit.collider.transform.position.x - hit.collider.transform.position.y - hit.collider.transform.position.z);
                    text.text = "Звезда " + StarNameGenrator.Create_word(Globalprefs.GetIdStar(o)) + " : s" + o.ToString();
                    if (o == 0)
                    {

                        text.text = "Звезда " + "Оурт" + " : s" + o.ToString();
                    }
                    else if (o == -11)
                    {

                        text.text = "Звезда " + "Геоп" + " : s" + o.ToString();
                    }
                    else if (o == 186)
                    {

                        text.text = "Звезда " + "Лароннн" + " : s" + o.ToString();
                    }
                    else if (o == -173 && Globalprefs.GetIdStar(o) == 1815127)
                    {

                        text.text = "Звезда " + "Ецлнос Сонечный" + " : s" + o.ToString();
                    }
                    else if (o == 112 && Globalprefs.GetIdStar(o) == 1065612)
                    {

                        text.text = "Звезда " + "Свобода от Любовселенского кансервационера" + " : s" + o.ToString();
                    }
                    else
                    {
                        text.text = "Звезда " + StarNameGenrator.Create_word(Globalprefs.GetIdStar(o)) + " : s" + o.ToString();
                    }
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        SaveTargets();
                    }
                    if (o == 0 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("dark1");
                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                        VarSave.SetInt("planet", 0);
                    }
                    else if (o == -11 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("dark2");
                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                        VarSave.SetInt("planet", 0);
                    }
                    else if (o == 186 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("dark3");
                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                        VarSave.SetInt("planet", 0);
                    }
                    else if (o == -173 && Globalprefs.GetIdStar(o) == 1815127 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        VarSave.SetInt("planet", o);
                        SceneManager.LoadScene("dark5");
                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                    }
                    else if (o == 112 && Globalprefs.GetIdStar(o) == 1065612 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        VarSave.SetInt("planet", o);
                        SceneManager.LoadScene("dark6");
                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                    }
                    else if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        VarSave.SetInt("planet", o);
                        SceneManager.LoadScene("dark4");
                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                    }
                }
                else if (hit.collider.tag == "Cell" && s == size.Stars)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        SaveTargets();
                    }
                    text.text = "Галактический ретранслятор";
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("Galaxy full loader");
                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                    }
                }
                else if (hit.collider.tag == "Cell" && s == size.Galaxy)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        SaveTargets();
                    }
                    text.text = "Вселенский ретранслятор";
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("Universe loader");
                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                    }
                }
                else if (hit.collider.tag == "Cell" && s == size.Universe)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        SaveTargets();
                    }
                    text.text = "Вселенский край";
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("Multyverse");
                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                    }
                }
                else if (hit.collider.tag == "Cell" && s == size.Multyverse)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        SaveTargets();
                    }
                    text.text = "Мультивселенская дыра";
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        if (hit.collider.GetComponent<MultyverseHole>().m_type == MultyverseHoleType.Xp)
                        {

                            VarSave.SetMoney("MultyverseX", VarSave.GetMoney("MultyverseX") + 1);
                        }
                        if (hit.collider.GetComponent<MultyverseHole>().m_type == MultyverseHoleType.Xm)
                        {

                            VarSave.SetMoney("MultyverseX", VarSave.GetMoney("MultyverseX") - 1);
                        }
                        if (hit.collider.GetComponent<MultyverseHole>().m_type == MultyverseHoleType.Yp)
                        {

                            VarSave.SetMoney("MultyverseY", VarSave.GetMoney("MultyverseY") + 1);
                        }
                        if (hit.collider.GetComponent<MultyverseHole>().m_type == MultyverseHoleType.Ym)
                        {

                            VarSave.SetMoney("MultyverseY", VarSave.GetMoney("MultyverseY") - 1);
                        }
                        if (hit.collider.GetComponent<MultyverseHole>().m_type == MultyverseHoleType.Zp)
                        {

                            VarSave.SetMoney("MultyverseZ", VarSave.GetMoney("MultyverseZ") + 1);
                        }
                        if (hit.collider.GetComponent<MultyverseHole>().m_type == MultyverseHoleType.Zm)
                        {

                            VarSave.SetMoney("MultyverseZ", VarSave.GetMoney("MultyverseZ") - 1);
                        }
                        if (hit.collider.GetComponent<MultyverseHole>().m_type == MultyverseHoleType.Wp)
                        {

                            VarSave.SetMoney("MultyverseW", VarSave.GetMoney("MultyverseW") + 1);
                        }
                        if (hit.collider.GetComponent<MultyverseHole>().m_type == MultyverseHoleType.Wm)
                        {

                            VarSave.SetMoney("MultyverseW", VarSave.GetMoney("MultyverseW") - 1);
                        }
                        SceneManager.LoadSceneAsync("Multyverse");
                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                    }
                }
                else if (hit.collider.tag == "Star" && s == size.Galaxy)
                {
                    int o = (int)(hit.collider.transform.position.x - hit.collider.transform.position.y - hit.collider.transform.position.z);
                    int o2 = (int)(hit.collider.transform.position.x - hit.collider.transform.position.y - hit.collider.transform.position.z);
                    o = (int)(((Hash(new Vector2(o, -o)) + 1) / 2) * scenename.Length);

                    text.text = "stars : s" + o2.ToString(); if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        SaveTargets();
                    }
                    if (o2 == 0 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("Galactic demo");
                        VarSave.SetInt("planetS", 0);
                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                    }
                    else if (Input.GetKeyDown(KeyCode.Mouse0))
                    {


                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));

                        VarSave.SetInt("planetS", o2);
                        SceneManager.LoadScene(scenename[o]);
                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                    }
                }
                else if (hit.collider.tag == "Star" && s == size.Universe)
                {
                    int o = (int)(hit.collider.transform.position.x - hit.collider.transform.position.y - hit.collider.transform.position.z);
                    int o2 = (int)(hit.collider.transform.position.x - hit.collider.transform.position.y - hit.collider.transform.position.z);
                    o = (int)(((Hash(new Vector2(o, -o)) + 1) / 2) * scenename.Length);

                    text.text = "Galaxy : s" + o2.ToString(); if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        SaveTargets();
                    }
                    if (o2 == 0 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("Galactic full");
                        VarSave.SetInt("planetG", 0);
                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                    }
                    else if (Input.GetKeyDown(KeyCode.Mouse0))
                    {


                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));

                        VarSave.SetInt("planetG", o2);
                        SceneManager.LoadScene(scenename[o]);
                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                    }
                }
                else if (hit.collider.tag == "Star" && s == size.Multyverse)
                {
                    int o = (int)((hit.collider.GetComponent<HyperbolicPoint>().HyperboilcPoistion.s * 200f) +
                       (hit.collider.GetComponent<HyperbolicPoint>().HyperboilcPoistion.n * 200f) -
                        hit.collider.transform.position.y)*200;
                    int o2 = (int)((hit.collider.GetComponent<HyperbolicPoint>().HyperboilcPoistion.s * 200f) +
                       ( hit.collider.GetComponent<HyperbolicPoint>().HyperboilcPoistion.n * 200f) -
                        hit.collider.transform.position.y);
                    o = (int)(((Hash(new Vector2(o, -o)) + 1) / 2) * scenename.Length);

                    text.text = "Universe : s" + o2.ToString(); if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        SaveTargets();
                    }
                    if (o2 == 0 && Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
                        SceneManager.LoadScene("Universe");
                        VarSave.SetInt("planetU", 0);
                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                    }
                    else if (Input.GetKeyDown(KeyCode.Mouse0))
                    {


                        VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));

                        VarSave.SetInt("planetU", o2);
                        SceneManager.LoadScene(scenename[o]);

                        VarSave.SetBool("NoStop", false);
                        VarSave.DeleteKey("scppos");
                    }
                }
                else
                {
                    text.text = "";
                }
            }
            else
            {

                text.text = "";
            }
        }
        else
        {

            text.text = "";
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            VarSave.SetString("scppos", SceneManager.GetActiveScene().name);
            VarSave.SetString("Universe_Position", SceneManager.GetActiveScene().name);
            VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));
            VarSave.SetBool("NoStop",true);
            SceneManager.LoadScene("dark4");
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            VarSave.SetString("scp" + SceneManager.GetActiveScene().name, JsonUtility.ToJson(scp));

            SaveTargets();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            LoadTargets();
            if (VarSave.ExistenceVar("scp" + SceneManager.GetActiveScene().name))
            {
                scp = JsonUtility.FromJson<SpaceSheepPosition>(VarSave.GetString("scp" + SceneManager.GetActiveScene().name));
                transform.position = scp.pos;
                transform.rotation = scp.rot;

                if (HyperbolicCamera) HyperbolicCamera.RealtimeTransform = scp.hyperbolic;
            }
        }
    }

    private void LoadTargets()
    {
        for (int i = 0; i < GameObject.FindObjectsByType<SpaceObject>(sortmode.main).Length; i++)
        {
            GameObject.FindObjectsByType<SpaceObject>(sortmode.main)[i].gameObject.AddComponent<DELETE>();
        }
        Targets t = JsonUtility.FromJson<Targets>(VarSave.GetString("spaceData" + SceneManager.GetActiveScene().name + GetPointAnyverse()));
        int i2 = 0;
        foreach (Vector3 v3 in t.vector3s)
        {
            
           Transform t2 = Instantiate(Resources.Load<GameObject>("SpaceItems/PowerMetka").gameObject, v3, Quaternion.identity).transform;
            if (s == size.Multyverse)
            {



                t2.gameObject.AddComponent<HyperbolicPoint>().HyperboilcPoistion = t.hyperbolic2Ds[i2];
                t2.transform.position = new Vector3(
                    0,
                    t2.transform.position.y,
                    0
                    );
                t2.gameObject.GetComponent<HyperbolicPoint>().ScriptSacle = t2.localScale;
            }
            i2++;
        }
    }

    private void SaveTargets()
    {
        Targets t = new Targets();
        for (int i = 0; i < GameObject.FindObjectsByType<SpaceObject>(sortmode.main).Length; i++)
        {
            t.vector3s.Add(GameObject.FindObjectsByType<SpaceObject>(sortmode.main)[i].transform.position);
            if (s == size.Multyverse)
            {
                t.hyperbolic2Ds.Add(GameObject.FindObjectsByType<SpaceObject>(sortmode.main)[i].GetComponent<HyperbolicPoint>().HyperboilcPoistion);
            }
        }
        VarSave.SetString("spaceData" + SceneManager.GetActiveScene().name + GetPointAnyverse(), JsonUtility.ToJson(t));
    }
}
