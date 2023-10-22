using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    public static string word;
    public List<string> words2 = new List<string>();
    public bool Magic_stick;
    public GameObject Magic_obj;

    private void Update()
    {
        if (!Magic_stick)
        {


            if (itemName && string.IsNullOrEmpty(ifd.text))
            {
                ifd.text = (itemName.ItemData.Replace('_', ' ')).Replace('^', '\n');
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                itemName.ItemData = (ifd.text.Replace(' ', '_')).Replace('\n', '^');
                Global.PauseManager.Play();
                Destroy(gameObject);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {

                Global.PauseManager.Play();
                Use(ifd.text, Magic_obj);
                Destroy(gameObject);
            }
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {

                Global.PauseManager.Play();
                Destroy(gameObject);
            }

        }
    }
    public static bool isNumber(string s)
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
        return false;
    }
    public static void Use(string _script, GameObject sc)
    {

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
            if (words[i] == "give")
            {
                typedata = "give";

                i++;
            }
<<<<<<< HEAD
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
            if (words[i] == "UnlockOmniscience_item")
            {
                typedata = "end"; foreach (GameObject g in complsave.t3)
                {

                    if (!VarSave.ExistenceVar("researchs/" + g.name))
                    {
                        Directory.CreateDirectory("unsave/var/researchs");


                        VarSave.LoadMoney("research", 1);

                        Globalprefs.research = VarSave.GetMoney("research");
                        VarSave.SetInt("researchs/" + g.name, 0);

                    }
                }
                VarSave.LoadMoney("Inflaition", 10, SaveType.global);
                    i++;
            }
=======
>>>>>>> parent of 3785344c (0.2.87)
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

            if (typedata == "operator" && words[i] == "copy")
            {
                Instantiate(sc, sc.transform.position, Quaternion.identity);
                typedata = "end";
            }
            if (typedata == "give")
            {
                foreach (GameObject g in complsave.t3)
                {


                    if (g.GetComponent<itemName>()._Name == words[i])
                    {

                        Instantiate(g, mover.main().transform.position, Quaternion.identity);
                    }
                }
                typedata = "end";
            }
            if (typedata == "timespeed" && isNumber(words[i]))
            {
                Time.timeScale = (float)(int.Parse(words[i])) / 20;
                typedata = "end";
            }
            if (typedata == "heal" && isNumber(words[i]))
            {
<<<<<<< HEAD
                mover.main().hp += (int)(float)(GetNumber(words[i], mover.main().hp));
                typedata = "end";
            }
            if (typedata == "agr")
            {
                cistalenemy.dies += (int)(float)(GetNumber(words[i], cistalenemy.dies));
                typedata = "end";
            }
            if (typedata == "Money")
            {

                VarSave.LoadMoney("Inflation", (GetNumber(words[i], VarSave.LoadMoney("tevro", 0)))/2000, SaveType.global);
                VarSave.LoadMoney("tevro",(GetNumber(words[i], VarSave.LoadMoney("tevro",0))));
=======
                mover.main().hp += (int.Parse(words[i]));
>>>>>>> parent of 3785344c (0.2.87)
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
        }


    }
}
