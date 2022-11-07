using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;
[System.Serializable]
public class save4d
{
    public string idsave;
    public Vector3 pos, pos2;
    public Vector4 pos3;
    public int scene;

    public Quaternion q1, q2, q3, q4;
    public float vive;
}

public class GlobalGreadSpaseImage : MonoBehaviour
{
    public Image im;
  public  Camera c;
    public mover m;
    public Sprite t;
    public GameObject g;
    public bool end;
    public Animator anim;
    public GameObject pref;
    IEnumerator GetText()
    {
        Debug.Log(Path.GetDirectoryName(Application.dataPath) + @"\unsave\var\Screenshot.png");
        Debug.Log(Path.GetDirectoryName("unsave/var/Screenshot.png"));
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Application.dataPath) + @"\unsave\var\Screenshot.png"))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                Globalprefs.txt = DownloadHandlerTexture.GetContent(uwr);
                Texture t = Globalprefs.txt;

                im.sprite = Sprite.Create((Texture2D)t, new Rect(0, 0, Globalprefs.txt.width, Globalprefs.txt.height), Vector2.zero);
                Debug.Log("1");
                im.enabled = true;
                anim.Play("panel");

            }
        }
    }
    void Start()
    {
        
            if (File.Exists("unsave/global_var/id"))
        {
            Globalprefs.idscene = int.Parse( File.ReadAllText("unsave/global_var/id"));
        }
        m.transform.position = Vector3.zero;
        Debug.Log("1");
        if (Globalprefs.txt == null)
        {
            StartCoroutine(GetText());
        }
        if (Globalprefs.txt != null)
        {
            Texture t = Globalprefs.txt;

            im.sprite = Sprite.Create((Texture2D)t, new Rect(0, 0, Globalprefs.txt.width, Globalprefs.txt.height), Vector2.zero);
            Debug.Log("1");
            im.enabled = true;
            anim.Play("panel");
        }
        string s = "";
        save save = new save();
        if (File.Exists("unsave/s"))
        {
            s = File.ReadAllText("unsave/s");
        }
        if (File.Exists("unsave/capter" + Globalprefs.idscene + "/" + s))
        {
            save = JsonUtility.FromJson<save>(File.ReadAllText("unsave/capter" + Globalprefs.idscene + "/" + s));
        }
        if (File.Exists("unsave/capterg/" + s))
        {
            m.SETistp(JsonUtility.FromJson<gsave>(File.ReadAllText("unsave/capterg/" + s)).tp);
        }
        m.g.transform.rotation = save.q1;
        m.sr.transform.rotation = save.q3;
        m.g2.transform.rotation = save.q2;
        g.transform.position = Globalprefs.pos - save.pos;

        if (Globalprefs.postes != null)
        {


            if (Globalprefs.postes.Length != 0)
            {
                for (int i = 0; i < Globalprefs.postes.Length; i++)
                {
                    Instantiate(pref.gameObject, Globalprefs.postes[i] - save.pos, Quaternion.identity);
                }
            }
        }
        if (m.cd != null)
        {

            m.cd.transform.rotation = save.q4;
            m.convertinPvector(save.pos3, m.cd);
        }
        Globalprefs.isnew = true;
        Camera.main.fieldOfView = save.vive;
    }
    private void Update()
    {
        string s = "";
        save save = new save();
        if (File.Exists("unsave/s"))
        {
            s = File.ReadAllText("unsave/s");
        }
        if (File.Exists("unsave/capter" + Globalprefs.idscene + "/" + s))
        {
            save = JsonUtility.FromJson<save>(File.ReadAllText("unsave/capter" + Globalprefs.idscene + "/" + s));
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            save4d s4 = new save4d();
            s4.pos = save.pos;
            s4.pos2 = save.pos2;
            s4.pos3 = save.pos3;
            s4.q1 = save.q1;
            s4.q2 = save.q2;
            s4.q3 = save.q3;
            s4.q4 = save.q4;
            s4.vive = save.vive;
            s4.idsave = save.idsave;
            s4.scene = Globalprefs.idscene;

            File.WriteAllText("unsave/capter" + Globalprefs.idscene + "/" + s + ".det", JsonUtility.ToJson(s4));

        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (File.Exists("unsave/capter" + Globalprefs.idscene + "/" + s + ".det"))
            {
                Globalprefs.isnew = false;

                save4d s4 = JsonUtility.FromJson<save4d>(File.ReadAllText("unsave/capter" + Globalprefs.idscene + "/" + s + ".det"));
                save.pos = s4.pos;
                save.pos2 = s4.pos2;
                save.pos3 = s4.pos3;
                save.q1 = s4.q1;
                save.q2 = s4.q2;
                save.q3 = s4.q3;
                save.q4 = s4.q4;
                save.vive = s4.vive;
                save.idsave = s4.idsave;
                File.WriteAllText("unsave/capter" + Globalprefs.idscene + "/" + s, JsonUtility.ToJson(save));

            }
            if (true)
            {
                SceneManager.LoadSceneAsync(Globalprefs.idscene);
            }

        }
        if (Input.GetKeyDown(KeyCode.P) && SceneManager.GetActiveScene().name == "Gread_space")
        {
            anim.Play("panel1");
            im.sprite = t;

        }
        if (end)
        {
            
        
           
            if (File.Exists("unsave/global_var/id"))
            {
                Globalprefs.idscene = int.Parse(File.ReadAllText("unsave/global_var/id"));
            }

            SceneManager.LoadScene(Globalprefs.idscene);

            Globalprefs.newv3 = m.transform.position;
            Globalprefs.q = new Quaternion[]
            {
                m.g.transform.rotation,
                m.g2.transform.rotation,
                m.sr.transform.rotation
            };



        }
    }



}
