using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
public class Общение : MonoBehaviour
{
    public GameObject canvas;
    public Text UiDialog;
    public Text UiConsole;
    public Text UiButton0;
    public Text UiButton1;
    public Text UiButton2;
    public GameObject[] Souls;
    public GameObject[] targets;
    public GameObject[] morpfs;
    public List<GameObject> chars = new();
    public bool Enter_dialog;
    public string curname;

    string hue;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<mover>())
        {
            Enter_dialog = true;
            canvas.SetActive(true);

            UiButton0.text = $"\nИгрок говорит : {file2[Noice.Next(0, file2.Length)]}";
            UiButton1.text = $"\nИгрок говорит : {file2[Noice.Next(0, file2.Length)]}";
            UiButton2.text = $"\nИгрок говорит : {file2[Noice.Next(0, file2.Length)]}";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<mover>())
        {
            Enter_dialog = false;
            canvas.SetActive(false);
        }
    }
    void Awake()
    {
        morpfs = Resources.LoadAll<GameObject>("Morfs");
        foreach (GameObject go in targets)
        {
            chars.Add(Instantiate(morpfs[Noice.Next(0, morpfs.Length)],go.transform.position,Quaternion.identity));
        }
    }
    public string[] file;
    public string[] file2;
    static System.Random Noice = new System.Random(System.DateTime.Now.Minute);
    public string book()
    {
        //"D:\2new\Unauticna test\game-unauticna\res\books\book1.txt"
        if (file.Length == 0) file = File.ReadAllText("res/books/book1.txt").Split(' ');
        if (file2.Length == 0) file2 = File.ReadLines("res/books/book1.txt").ToArray();
        return ($"{file2[Noice.Next(0, file2.Length)]} {file[Noice.Next(0, file.Length)]} {file[Noice.Next(0, file.Length)]} {file2[Noice.Next(0, file2.Length)]} {file[Noice.Next(0, file.Length)]}").Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
    }
    translate tre = new translate();
    public void ButtonClick(int buttonid)
    {
        string Voice  = "";
        curname = chars[Noice.Next(0, chars.Count)].name;
        if (Enter_dialog)
        {
            if (VarSave.GetString("lenguage_english") != "none")
            {
                UiDialog.text = book();
                if (buttonid == 0)
                {
                    hue += "\n" + UiButton0.text.Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    Voice += UiButton0.text.Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    Voice += $"<color=green>Слоп отвечает : </color>\"{UiDialog.text}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton0.text = $"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton1.text = $"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton2.text = $"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);

                }
                if (buttonid == 1)
                {
                    hue += "\n" + UiButton1.text.Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    Voice += UiButton1.text.Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    Voice += $"<color=green>Слоп отвечает : </color>\"{UiDialog.text}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton0.text = $"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton1.text = $"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton2.text = $"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                }
                if (buttonid == 2)
                {
                    hue += "\n" + UiButton2.text;
                    Voice += UiButton2.text;
                    Voice += $"<color=green>Слоп отвечает : </color>\"{UiDialog.text}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton0.text = $"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton1.text = $"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton2.text = $"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                }
            }
            else
            {
                UiDialog.text = mover.leng.translit(book());
                if (buttonid == 0)
                {
                    hue += "\n" + mover.leng.translit(UiButton0.text.Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname));
                    Voice += UiButton0.text.Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    Voice += $"<color=green>Слоп отвечает : </color>\"{UiDialog.text}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton0.text = mover.leng.translit($"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}").Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton1.text = mover.leng.translit($"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}").Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton2.text = mover.leng.translit($"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}").Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);

                }
                if (buttonid == 1)
                {
                    hue += "\n" + mover.leng.translit(UiButton1.text).Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    Voice += UiButton1.text.Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    Voice += $"<color=green>Слоп отвечает : </color>\"{UiDialog.text}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton0.text = mover.leng.translit($"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}").Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton1.text = mover.leng.translit($"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}").Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton2.text = mover.leng.translit($"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}").Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                }
                if (buttonid == 2)
                {
                    hue += "\n" + mover.leng.translit(UiButton2.text).Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    Voice += UiButton2.text.Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    Voice += $"<color=green>Слоп отвечает : </color>\"{UiDialog.text}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton0.text = mover.leng.translit($"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}").Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton1.text = mover.leng.translit($"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}").Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                    UiButton2.text = mover.leng.translit($"<color=red>Игрок говорит : </color>{file2[Noice.Next(0, file2.Length)]}").Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
                }
            }
            hue += $"\n<color=green>Слоп отвечает : </color>\"{UiDialog.text}".Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);
         
            if (VarSave.GetString("lenguage_english") == "none")
            {
                UiConsole.text = mover.leng.translit(hue);
                Voice = mover.leng.translit(Voice);
                Voice = Regex.Replace(Voice.Replace("<color=red>", "").Replace("<color=green>", "").Replace("'", "").Replace("</color>", "").Replace("\"", ""), @"\r\n?|\n", " новая строка").Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);

                VarSave.SetString("dialog.txt", Voice.ToLower(), SaveType.computer);
            }
            else
            {
                UiConsole.text = hue;
                Voice = Regex.Replace(Voice.Replace("<color=red>", "").Replace("<color=green>", "").Replace("'", "").Replace("</color>", "").Replace("\"", ""), @"\r\n?|\n", " новая строка").Replace("Слоп", curname).Replace("cлоп", curname).Replace("СЛОП", curname);

                VarSave.SetString("dialog.txt", Voice.ToLower(), SaveType.computer);
            }
            
           int i = 0;
            int x = 0;
            x = Noice.Next(0, Souls.Length);
            foreach (GameObject go in Souls) 
            {
                if (i == x)
                {
                    go.SetActive(true);
                }
                else
                {
                    go.SetActive(false);
                }
                i++;
            }
        }
    }
}
