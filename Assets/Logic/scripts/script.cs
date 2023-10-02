using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
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

    private void Update()
    {
        if (itemName && string.IsNullOrEmpty(ifd.text))
        {
            ifd.text = (itemName.ItemData.Replace('_', ' ')).Replace('^', '\n');
        }
        if(Input.GetKeyDown(KeyCode.Return)) 
        {
            itemName.ItemData = (ifd.text.Replace(' ','_')).Replace('\n','^');
            Global.PauseManager.Play();
            Destroy(gameObject);
        }
    }
    public static void Use(string _script, GameObject sc)
    {





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
        string typedata = "";
        for (int i = 0; i < words.Count; i++)
        {


            if (words[i] == "this")
            {
                typedata = "operator";
            }

            if (typedata == "operator" && words[i] == "copy")
            {
                Instantiate(sc, sc.transform.position, Quaternion.identity);
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
