using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class debug : MonoBehaviour
{
    public string ins;
    string pre;
    string pre1;
    string pre2; 
    string pre3 = "0";
    public List<string> outs = new List<string>();
    public List<string> outs2 = new List<string>();
    List<string> outs3 = new List<string>(); 
    public List<string> outsst = new List<string>();
    public List<Vector2> outsv = new List<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        if(File.Exists(ins))
        {
            pre = File.ReadAllText(ins);
        }
        for (int i = 0; i < pre.Length; i++)
        {
            pre1 += pre[i];
            if (pre[i] == '\n' && pre3 == "0")
            {
                pre3 = "1";
                pre1 = "";

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


            if (outs[x] == "/randpos/+")
            {


                gameObject.AddComponent<rand>().script = this;
                Debug.LogWarning("рандомное перемещение задано");

            }
            if (outs[x] == "/forsebody/+")
            {


                gameObject.AddComponent<forsebody>().script = this;
                Debug.LogWarning("перемещение задано");

            }
            if (outs[x] == "/dialog/+")
            {


                gameObject.GetComponent<deldialog>().s = outsst.ToArray();
                Debug.LogWarning("dialog задано");

            }
            
            if (outs[x] == "/buletbody/+")
            {


                gameObject.AddComponent<forsebody>().script = this;
                Debug.LogWarning("перемещение задано");

            }
            if (outs[x] == "/shoting/+")
            {

                gameObject.AddComponent<shoting>().script = this;
                
                Debug.LogWarning("перемещение задано");

            }


            if (outs[x][0] == '/' && outs[x][1] == 'v' && outs[x][2] == 'e' && outs[x][3] == 'l' && outs[x][4] == ' ')
            {
                int x1 = 0;
                Vector2 v2= new Vector2();
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
        }

    }

    
}
