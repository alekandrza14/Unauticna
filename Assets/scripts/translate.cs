using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class translate
{
    public string loadlenguage = "unaricicha.txt"; string loadlenguage2;
    public List<string> words = new List<string>();
    public List<string> zwords = new List<string>();
    public List<string> curword = new List<string>();
    public List<string> edcurword = new List<string>();
    public InputField ifd; public string ifd2;
    public int cur2;

    // Start is called before the first frame update
    public void innichializishon()
    {
        words = new List<string>();
        zwords = new List<string>();
        curword = new List<string>();
        cur2 = 0;
        if (File.Exists("res/lenguage/" + loadlenguage))
        {
            edcurword.Add("");
            loadlenguage2 = File.ReadAllText("res/lenguage/" + loadlenguage);

            for (int i = 0; i < loadlenguage2.Length; i++)
            {

                if (loadlenguage2[i] != '=' && loadlenguage2[i] != '\n' && loadlenguage2[i] != ' ')
                {
                    edcurword[cur2] += loadlenguage2[i];

                }
                if (loadlenguage2[i] == '=')
                {
                    edcurword.Add("");

                    cur2++;
                }
                if (loadlenguage2[i] == '\n')
                {

                    edcurword.Add("");
                    cur2++;

                }


            }
            for (int i = 0; i < edcurword.Count; i++)
            {



                if (i < edcurword.Count)
                {

                    zwords.Add(edcurword[i]);


                }

                i++;


                if (i < edcurword.Count)
                {
                    words.Add(edcurword[i]);
                }







            }
            con();
        }
    }
    void tr()
    {
        for (int i2 = 0; i2 < curword.Count; i2++)
        {
            for (int i = 0; i < zwords.Count; i++)
            {

                if (curword[i2] == words[i])
                {
                    curword[i2] = zwords[i];

                }
            }
        }

    }
    void con()
    {

       
        for (int i = 0; i < words.Count; i++)
        {
            string s5 = "";
            
            for (int i2 = 0; i2 < words[i].Length - 2; i2++)
            {

                


                    s5 += words[i][i2];
                

                



            }
            words[i] = s5;




        }
    }


    // Update is called once per frame
    public string translit(string d)
    {

        
        
            cur2 = 0;
            curword.Clear();
            curword.Add("");
            ifd2 = d;
            d = "загруска";
            for (int i = 0; i < ifd2.Length; i++)
            {
                if (ifd2[i] != ' ')
                {
                    curword[cur2] += ifd2[i];
                }
                if (ifd2[i] == ' ')
                {
                    
                    
                    cur2++;
                    curword.Add("");
                    curword[cur2] += '-';
                    cur2++;
                    curword.Add("");
                }
                if (i == ifd2.Length -1)
                {

                    
                    cur2++;
                    curword.Add(".");
                }

            }
            tr();
            ifd2 = "";
            d = "";
            for (int i = 0; i < curword.Count; i++)
            {

                d += curword[i];

            }
        return d;
        
    }
}
