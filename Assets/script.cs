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
    public GameObject sc;
    public InputField ifd;
    public List<string> words = new List<string>();
    public string word;
    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.Tab))
        {


            for (int i = 0; i < ifd.text.Length; i++)
            {
                if (ifd.text[i] == ' ')
                {
                    words.Add(word);
                    word = "";
                }
                else if (ifd.text[i] == '\n')
                {
                    
                }
                else if (ifd.text[i] == ';')
                {
                    words.Add(word);
                    words.Add("end");
                    word = "";
                }
                else
                {
                    word += ifd.text[i];
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
                    File.WriteAllText("log.txt",JsonUtility.ToJson(V));
                    typedata = "end";
                }
                if (typedata == "end" && words[i] == "end")
                {

                }
            }
            if (true)
            {
                Destroy(gameObject);
                words.Clear();
            }
        }

    }
}
