using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[AddComponentMenu("UnScript/Unauticna Script")]

public class unScript : MonoBehaviour
{

    public UnsFormat ins;
    string pre;
    string pre1;
    string pre2;
    string pre3 = "0";
    string pre4 = "0";
    [HideInInspector]
    public List<string> outs = new List<string>();
    [HideInInspector]
    public List<string> outs2 = new List<string>();
    [HideInInspector]
    public List<string> deathtime = new List<string>();
    List<string> outs3 = new List<string>();
    [HideInInspector]
    public List<string> outsst = new List<string>();
    [HideInInspector]
    public List<Vector2> outsv = new List<Vector2>();
    [HideInInspector]
    public List<Vector3> outsv3 = new List<Vector3>();
    [HideInInspector]
    public List<GameObject> outsg = new List<GameObject>();
    float tic;
    // Start is called before the first frame update
    void Start()
    {

        pre = ins.script;

        for (int i = 0; i < pre.Length; i++)
        {
            pre1 += pre[i];
            if (pre[i] == '\n' && pre3 == "0")
            {
                pre3 = "1";
                pre1 = "";

            }
            if (pre[i] == '#')
            {
                pre4 = "б";

            }
            if (pre[i] == '%' && VarSave.EnterFloat("el"))
            {
                pre4 = "3";

            }
            if (pre[i] == '\n' && pre3 == "1")
            {
                pre3 = "1";

                outsst.Add(pre1);
                pre1 = "";
            }
            if (pre[i] == '+')
            {
                pre3 = "2";
                if (pre3 != "1")
                {


                    outs.Add(pre1);
                }

                pre1 = "";
                for (int x = 0; x < outs.Count; x++)
                {
                    if (outs[x] == "/stop/+")
                    {
                        Debug.LogWarning("остановка");
                        i = pre.Length;
                    }
                    if (outs[x] == "/done/+")
                    {
                        Debug.LogWarning("готово");
                        i = pre.Length;
                    }
                    if (outs[x] == "/debug/+")
                    {
                        Debug.LogWarning("нет доступа");
                        i = pre.Length;
                    }
                }
            }
        }
    }
    void Update()
    {
        tic += Time.deltaTime;
        if (pre4 == "3")
        {
            Destroy(gameObject);
        }
        if (deathtime.Count != 0)
        {
            if (tic > int.Parse(deathtime[0]) && pre4 != "s")
            {
                for (int i = 0; i < 250; i++)
                {


                    Instantiate(Resources.Load<GameObject>("deathparticles"), gameObject.transform.position, Quaternion.identity);

                }

                Destroy(gameObject);
            }


            if (tic > int.Parse(deathtime[0]) && pre4 == "s")
            {
                if (pre3 == "s")
                {
                    outsg.Add(Instantiate(ins.gs[0], transform.position, Quaternion.identity));
                }
                for (int i = 0; i < outsg.Count; i++)
                {
                    for (int i2 = 0; i2 < ins.uns.Length; i2++)
                    {


                        outsg[i].AddComponent<unScript>().ins = ins.uns[i2];


                    }

                }
                if (GetComponent<unScript>() || ins.uns.Length == 0)
                {


                    Destroy(gameObject);
                }

            }
        }

        if (pre4 != "д"&&pre4 != "s")
        {
            for (int x = 0; x < outs.Count; x++)
            {

                if (outs[x][0] == '/' && outs[x][1] == 'v' && outs[x][2] == 'a' && outs[x][3] == 'r' && outs[x][4] == ' ')
                {
                    for (int y = 5; y < outs[x].Length - 2; y++)
                    {
                        pre2 += outs[x][y];

                    }
                    outs2.Add(pre2);
                    pre2 = "";
                    Debug.LogWarning("значение записано");

                }
                if (outs[x][0] == '/' && outs[x][1] == 'd' && outs[x][2] == 'e' && outs[x][3] == 's' && outs[x][4] == ' ')
                {
                    for (int y = 5; y < outs[x].Length - 2; y++)
                    {
                        pre2 += outs[x][y];

                    }
                    deathtime.Add(pre2);
                    pre2 = "";
                    Debug.LogWarning("значение записано");

                }


                if (outs[x] == "/randpos/+")
                {


                    gameObject.AddComponent<rand>().script1 = this;
                    Debug.LogWarning("рандомное перемещение задано");

                }
                if (outs[x] == "/flybody/+")
                {


                    gameObject.AddComponent<Flybody>().script1 = this;
                    Debug.LogWarning("3D перемещение задано");

                }
                if (outs[x] == "/forsebody/+")
                {


                    gameObject.AddComponent<forsebody>().script1 = this;
                    Debug.LogWarning("перемещение задано");

                }
                if (outs[x] == "/dialog/+")
                {


                    gameObject.GetComponent<deldialog>().s = outsst.ToArray();
                    Debug.LogWarning("dialog задано");

                }
                if (outs[x] == "/setNotstabileColider/+")
                {

                    if (!gameObject.GetComponent<BoxCollider>())
                    {


                        gameObject.AddComponent<BoxCollider>().size = new Vector3(Random.Range(0, 20), Random.Range(0, 20), Random.Range(0, 20));
                    }
                    if (gameObject.GetComponent<BoxCollider>())
                    {


                        gameObject.GetComponent<BoxCollider>().size = new Vector3(Random.Range(0, 20), Random.Range(0, 20), Random.Range(0, 20));
                    }
                    Debug.LogWarning("setNotstabileColider задано");

                }
                if (outs[x] == "/setNotstabilesize/+")
                {


                    gameObject.transform.localScale = new Vector3(Random.Range(0, 20), Random.Range(0, 20), Random.Range(0, 20));
                    pre3 = "s";
                    x++;
                    Debug.LogWarning("setNotstabilesize задано");

                }
                if (pre3 == "s")
                {
                    if (outs[x] == "/setNotstabileColider/+")
                    {


                        gameObject.AddComponent<BoxCollider>().size = new Vector3(Random.Range(0, 40), Random.Range(0, 40), Random.Range(0, 40));
                        pre3 = "s";
                        Debug.LogWarning("setNotstabileColider задано");

                    }
                }

                if (outs[x] == "/buletbody/+")
                {


                    gameObject.AddComponent<forsebody>().script1 = this;
                    Debug.LogWarning("перемещение задано");

                }
                if (outs[x] == "/bum/+")
                {


                    gameObject.AddComponent<tnt>().g = ins.gs[0];
                    Debug.LogWarning("перемещение задано");

                }
                if (outs[x] == "/bum 1/+")
                {


                    gameObject.AddComponent<tnt>().g = ins.gs[1];
                    Debug.LogWarning("перемещение задано");

                }
                if (outs[x] == "/bumact1/+")
                {


                    outsg.Add(Instantiate(ins.gs[0], transform.position, Quaternion.identity));
                    pre4 = "s";
                    Debug.LogWarning("перемещение задано");

                }
                if (outs[x] == "/bumact2/+")
                {


                    //outsg.Add(Instantiate(ins.gs[0], transform.position, Quaternion.identity));
                    pre4 = "s"; pre3 = "s";
                    Debug.LogWarning("перемещение задано");

                }
                if (outs[x] == "/shoting/+")
                {

                    gameObject.AddComponent<shoting>().script1 = this;

                    Debug.LogWarning("перемещение задано");

                }
                if (outs[x][0] == '/' && outs[x][1] == 'v' && outs[x][2] == 'e' && outs[x][3] == 'l' && outs[x][4] == ' ')
                {
                    int x1 = 0;
                    Vector2 v2 = new Vector2();
                    for (int y = 5; y < outs[x].Length - 2; y++)
                    {
                        if (outs[x][y] != ',' && x1 == 0)
                        {

                            pre2 += outs[x][y];
                        }


                        if (outs[x][y] == ',')
                        {

                            outs3.Add(pre2);

                            pre2 = "";
                        }
                        if (y == outs[x].Length - 3)
                        {

                            outs3.Add(pre2);

                            pre2 = "";
                        }


                    }

                    if (x1 == 0)
                    {
                        v2 = new Vector2(float.Parse(outs3[0]), float.Parse(outs3[1]));


                    }
                    outsv.Add(v2);
                    outs3 = new List<string>();
                    pre2 = "";
                    Debug.LogWarning("движение записано");

                }
                if (outs[x][0] == '/' && outs[x][1] == 'v' && outs[x][2] == 'e' && outs[x][3] == 'l' && outs[x][4] == '3' && outs[x][5] == ' ')
                {
                    int x1 = 0;
                    Vector3 v3 = new Vector3();
                    for (int y = 6; y < outs[x].Length - 2; y++)
                    {
                        if (outs[x][y] != ',' && x1 == 0)
                        {

                            pre2 += outs[x][y];
                        }


                        if (outs[x][y] == ',')
                        {

                            outs3.Add(pre2);

                            pre2 = "";
                        }
                        if (y == outs[x].Length - 3)
                        {

                            outs3.Add(pre2);

                            pre2 = "";
                        }


                    }

                    if (x1 == 0)
                    {
                        v3 = new Vector3(float.Parse(outs3[0]), float.Parse(outs3[1]), float.Parse(outs3[2]));


                    }
                    outsv3.Add(v3);
                    outs3 = new List<string>();
                    pre2 = "";
                    Debug.LogWarning("движение записано");

                }
            }






        }
        if (pre4 == "б")
        {
            pre4 = "д";
        }


    }



}
