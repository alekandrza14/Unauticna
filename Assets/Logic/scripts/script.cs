using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class vectors
{
   public Vector3 v3;
}

public class script : MonoBehaviour
{
    public InputField ifd;
    public itemName itemName;
    public static List<string> words = new List<string>();
    public static List<string> postuse = new List<string>();
    public static string word;
    public List<string> words2 = new List<string>();
    public bool Magic_stick;
    public GameObject Magic_obj;
    public bool uns;
    public static GameObject Lost_Magic_obj;

    void Start()
    {

        Globalprefs.Iteract = true;
        if (Magic_stick)  ifd.text = VarSave.GetString("MagicUnaScript", SaveType.global);
    }
    public void NOedit()
    {
        Globalprefs.Iteract = false;
    }
    public void ONedit()
    {
        Globalprefs.Iteract = true;
    }
    private void Update()
    {
        if (!uns)
        {
            if (!Magic_stick)
            {


                if (itemName && string.IsNullOrEmpty(ifd.text))
                {
                    ifd.text = (itemName.ItemData.Replace('♥', ' ')).Replace('♦', '\n');
                }
                if (Input.GetKeyDown(KeyCode.Return) && !Globalprefs.Iteract)
                {
                    itemName.ItemData = (ifd.text.Replace(' ', '♥')).Replace('\n', '♦');
                    Global.PauseManager.Play();
                    Destroy(gameObject);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return) && !Globalprefs.Iteract)
                {

                    Global.PauseManager.Play();
                    VarSave.SetString("MagicUnaScript", ifd.text, SaveType.global);
                    Use(ifd.text, Magic_obj);
                    Destroy(gameObject);
                }
                if (Input.GetKeyDown(KeyCode.LeftAlt) && !Globalprefs.Iteract)
                {

                    Global.PauseManager.Play();
                    Destroy(gameObject);
                }

            }
        }
        if (uns)
        {
            if (!Magic_stick)
            {


                if (itemName && string.IsNullOrEmpty(ifd.text))
                {
                    ifd.text = (itemName.ItemData.Replace('♥', ' ')).Replace('♦', '\n');
                }
                if (Input.GetKeyDown(KeyCode.Return) && !Globalprefs.Iteract)
                {
                    itemName.ItemData = (ifd.text.Replace(' ', '♥')).Replace('\n', '♦');
                    Global.PauseManager.Play();
                    Destroy(gameObject);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Return) && !Globalprefs.Iteract)
                {

                    Global.PauseManager.Play();
                    UnsFormat uf = new UnsFormat();
                    uf.script = ifd.text;
                    Magic_obj.AddComponent<unScript>().ins = uf;
                    Destroy(gameObject);
                }
                if (Input.GetKeyDown(KeyCode.LeftAlt) && !Globalprefs.Iteract)
                {

                    Global.PauseManager.Play();
                    Destroy(gameObject);
                }

            }
        }
    }
    public static bool isNumber(string s)
    {
        if (s.Length > 0)
        {
            if (
              s[0] == '0' ||
              s[0] == '1' ||
              s[0] == '2' ||
              s[0] == '3' ||
              s[0] == '4' ||
              s[0] == '5' ||
              s[0] == '6' ||
              s[0] == '7' ||
              s[0] == '8' ||
              s[0] == '9' ||
              s[0] == '-')
            {

                return true;
            }
        }
            return false;
    }
    public static bool isboolean(string s)
    {
        if (s.Length > 0)
        {
            if (
              s[0] == 'F' ||
              s[0] == 'T')
            {

                return true;
            }
        }
            return false;
    }
    public static bool isKomplexNumber(string s)
    {
        if (s == "Xp")
        {

            return true;
        }
        if (s == "Yp")
        {

            return true;
        }
        if (s == "-Xp")
        {

            return true;
        }
        if (s == "-Yp")
        {

            return true;
        }
        if (s == "AntiThis")
        {

            return true;
        }
        return false;
    }
    public static decimal GetNumber(string s,decimal Count)
    {
        if (isNumber(s))
        {

            return (decimal.Parse(s));
        }
        else if (isKomplexNumber(s))
        {
            if (s == "-Xp")
            {
                s = (-Globalprefs.KomplexX).ToString();
            }
            if (s == "-Yp")
            {
                s = Math.Abs(Count*-Globalprefs.KomplexX).ToString();
            }
            if (s == "Xp")
            {
                s = Globalprefs.KomplexX.ToString();
            }
            if (s == "Yp")
            {
                s = Math.Abs(Count * Globalprefs.KomplexX).ToString();
            }
            if (s == "AntiThis")
            {


                    s = (-Count).ToString();
              
            }

            return decimal.Parse(s);
        }
        return 0;
    }
 

    public static void Use(string _script, GameObject sc)
    {
        Lost_Magic_obj = sc;
        words = new List<string>();
        word = "";


        for (int i = 0; i < _script.Length; i++)
        {
            if (_script[i] == ' ')
            {
                words.Add(word);
                word = "";
            }
            else if (_script[i] == '\n')
            {
                
            }
            else if (_script[i] == ';')
            {
                words.Add(word);
                words.Add("end");
                word = "";
            }
            else
            {
                word += _script[i];
            }
        }
     if (FindFirstObjectByType<script>())  FindFirstObjectByType<script>(). words2 = words;
        string typedata = "";
        for (int i = 0; i < words.Count; i++)
        {


            if (words[i] == "this")
            {
                typedata = "operator";
            }
            if (words[i] == "Self")
            {
                Globalprefs.SelfFunctions.Add(_script.Replace("Self;", ""));
                typedata = "end";
            }
            if (words[i] == "#Save.it" && typedata != "Save")
            {

                typedata = "Save";
            }
            if (words[i] == "#Use.uns" && typedata != "uns")
            {

                typedata = "uns";
            }
            if (words[i] == "#Use.script" && typedata != "script")
            {

                typedata = "script";
            }
            if (words[i] == "ImSelf")
            {
                Globalprefs.SelfFunctions.Add(_script);
                typedata = "end";
            }

            if (words[i] == "give")
            {
                typedata = "give";

                i++;
            }
            //Omniscience
            if (words[i] == "morph")
            {
                typedata = "morph";

                i++;
            }
            if (words[i] == "ExtItemName")
            {
                typedata = "ExtItemName";

                i++;
            }
            if (words[i] == "UnlockOmniscience.item")
            {
                typedata = "end";
                if (!PolitDate.IsGood(politicfreedom.avtoritatian))
                {
                    foreach (GameObject g in Map_saver.t3)
                    {
                        {

                            if (!VarSave.ExistenceVar("researchs/" + g.name))
                            {
                                Directory.CreateDirectory("unsave/var/researchs");


                                VarSave.LoadMoney("research", 1);

                                Globalprefs.research = VarSave.GetMoney("research");
                                VarSave.SetInt("researchs/" + g.name, 0);

                            }

                        }
                    }
                    VarSave.LoadMoney("Inflation", 10, SaveType.global);
                }
                i++;
            }
            if (words[i] == "ResetScience.item")
            {
               
                    typedata = "end";




                    VarSave.SetMoney("research", 0);

                    Globalprefs.research = VarSave.GetMoney("research");

                    Directory.Delete(VarSave.path + "/researchs", true);

                    Directory.CreateDirectory(VarSave.path + "/researchs");
                
                
                i++;
            }
            if (words[i] == "time")
            {
                typedata = "timespeed";
                i++;
            }
            if (words[i] == "heal")
            {
                //  mover.main().hp = 200;

                typedata = "heal";
                i++;
            }
            if (words[i] == "agr")
            {
                //  mover.main().hp = 200;

                typedata = "agr";
                i++;
            }
            if (words[i] == "Money")
            {
                //  mover.main().hp = 200;

                typedata = "Money";
                i++;
            }

            if (typedata == "operator" && words[i] == "copy")
            {
                Instantiate(sc, sc.transform.position, Quaternion.identity);
                typedata = "end";
            }

            if (typedata == "Save" && words[i] != "#Save.it")
            {
                File.WriteAllText("res/scripts/script" + words[i] + ".s", _script);
                typedata = "end";
            }
            if (typedata == "uns" && words[i] != "#Use.uns")
            {
                if (File.Exists(words[i]))
                {
                    Debug.Log("fuond script");
                    UnsFormat uf = new UnsFormat();
                    uf.script = File.ReadAllText(words[i]);
                    sc.gameObject.AddComponent<unScript>().ins = uf;

             
                }
                Debug.Log("TypeGenergy script");
                typedata = "end";
               
            }
            if (typedata == "script" && words[i] != "#Use.script")
            {
                if (File.Exists(words[i]))
                {

                    Debug.Log("fuond script");
                    postuse.Add(File.ReadAllText(words[i]));

                   
                }
               
                    typedata = "end";
               
            }
            if (typedata == "morph")
            {
                foreach (GameObject g in Map_saver.t3)
                {


                    if (g.GetComponent<itemName>()._Name == words[i])
                    {

                        Instantiate(g, sc.transform.position, Quaternion.identity);
                    }
                }

                Destroy(sc);
                typedata = "end";
            }
            if (typedata == "ExtItemName")
            {

               GameObject g = Instantiate(Resources.Load<GameObject>("String"), sc.transform.position, Quaternion.identity);
              g.GetComponent<MagicString>().SetText(  sc.GetComponent<itemName>()._Name);



                Destroy(sc);
                typedata = "end";
            }
            if (typedata == "give")
            {
                foreach (GameObject g in Map_saver.t3)
                {


                    if (g.GetComponent<itemName>()._Name == words[i])
                    {

                        Instantiate(g, mover.main().transform.position, Quaternion.identity);
                    }
                }
                typedata = "end";
            }
            if (typedata == "timespeed")
            {
                Time.timeScale = (float)((int)(float)GetNumber(words[i], (decimal)Time.timeScale)) / 20;
                typedata = "end";
            }
            if (typedata == "heal")
            {
                mover.main().hp += (int)(float)(GetNumber(words[i], mover.main().hp));
                typedata = "end";
            }
            if (typedata == "agr")
            {
                if (!PolitDate.IsGood(politicfreedom.avtoritatian))
                {
                    cistalenemy.dies += (int)(float)(GetNumber(words[i], cistalenemy.dies));
                }
                typedata = "end";
            }
            if (typedata == "Money")
            {
                if (!PolitDate.IsGood(politicfreedom.avtoritatian))
                {
                    VarSave.LoadInt("SlaversNervs", 1);
                    VarSave.LoadMoney("Inflation", (GetNumber(words[i], VarSave.LoadMoney("tevro", 0))) / 2000, SaveType.global);
                    Globalprefs.LoadTevroPrise((GetNumber(words[i], VarSave.LoadMoney("tevro", 0))));
                }
                typedata = "end";
            }
            if (typedata == "operator" && words[i] == "del")
            {
                Destroy(sc);
                typedata = "end";
            }
            if (typedata == "operator" && words[i] == "GETmove")
            {

                typedata = "GETtranslate";
            }
            if (typedata == "operator" && words[i] == "move")
            {

                typedata = "translate";
            }
            if (typedata == "translate" && words[i] != "move")
            {

                sc.transform.position += JsonUtility.FromJson<vectors>(words[i]).v3;
                typedata = "end";
            }
            if (typedata == "GETtranslate" && words[i] != "GETmove")
            {

                vectors V = new vectors();
                V.v3 = sc.transform.position;
                File.WriteAllText("log.txt", JsonUtility.ToJson(V));
                typedata = "end";
            }
            if (typedata == "end" && words[i] == "end")
            {

            }
        }
        if (true)
        {

            words.Clear();
            string scr = "";
          if(postuse.Count > 0)  for (int i =0;i<3;i++)
            {
                if (i == 0) scr = (string)postuse[postuse.Count - 1].Clone();
                if (i == 1) postuse.RemoveAt(postuse.Count-1);
                if (i == 2) Use(scr, sc);
            }
        }


    }
}
