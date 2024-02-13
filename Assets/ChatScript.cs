using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class DialogString
{
    public string get_word;
    public string otvet_word;
    public string otvet_funck;
}

public class ChatScript : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] GameObject _string;
    [SerializeField] GameObject[] audio;
    [SerializeField] GameObject[] pichers;
    [SerializeField] string[] repeat_words;
    [SerializeField] string[] ����_words;
    [SerializeField] DialogString[] get_words;
    void Send(string mesange,string name)
    {
       GameObject str = Instantiate(_string,panel.transform);
        str.transform.GetChild(0).GetComponent<Text>().text =name+ mesange;
        string[] slov = mesange.Split(' ');
        foreach (string word in repeat_words)
        {
            if (word.ToLower() == mesange.ToLower() && name != "�������:")
            {
                Send(mesange, "�������:");
            }
        }
        foreach (string word in ����_words)
        {
            if (word.ToLower() == mesange.ToLower() && name != "�������:")
            {
                Send("jkffsggnrkljeslgeksrJBKVGHDCJKH>>KUIFYFDJHkjhktyuerihsuiehruNBHGVHMFJU <nfhtkjserhtuiyarhsukthjrhtgiuweytujh", "�������:");
                Send("jkffsggnrkljeslgeksrJBKVGHDCJKH>>KUIFYFDJHkjhktyuerihsuiehruNBHGVHMFJU <nfhtkjserhtuiyarhsukthjrhtgiuweytujh", "�������:");
                Send("jkffsggnrkljeslgeksrJBKVGHDCJKH>>KUIFYFDJHkjhktyuerihsuiehruNBHGVHMFJU <nfhtkjserhtuiyarhsukthjrhtgiuweytujh", "�������:");
                Send("jkffsggnrkljeslgeksrJBKVGHDCJKH>>KUIFYFDJHkjhktyuerihsuiehruNBHGVHMFJU <nfhtkjserhtuiyarhsukthjrhtgiuweytujh", "�������:");
                Send("jkffsggnrkljeslgeksrJBKVGHDCJKH>>KUIFYFDJHkjhktyuerihsuiehruNBHGVHMFJU <nfhtkjserhtuiyarhsukthjrhtgiuweytujh", "�������:");
                Send("jkffsggnrkljeslgeksrJBKVGHDCJKH>>KUIFYFDJHkjhktyuerihsuiehruNBHGVHMFJU <nfhtkjserhtuiyarhsukthjrhtgiuweytujh", "�������:");
                Send("jkffsggnrkljeslgeksrJBKVGHDCJKH>>KUIFYFDJHkjhktyuerihsuiehruNBHGVHMFJU <nfhtkjserhtuiyarhsukthjrhtgiuweytujh", "�������:");
                Send("jkffsggnrkljeslgeksrJBKVGHDCJKH>>KUIFYFDJHkjhktyuerihsuiehruNBHGVHMFJU <nfhtkjserhtuiyarhsukthjrhtgiuweytujh", "�������:");
            }
        }
        foreach (DialogString word in get_words)
        {
            for (int i=0;i< slov.Length;i++ )
            { if (word.get_word.ToLower() == slov[i].ToLower() && name != "�������:")
                {
                    Send(word.otvet_word, "�������:");
                    Invoke(word.otvet_funck,1);
                }
                
            }
        }
    }
    public int sizefile;
    public void filelink() 
    {
        Send("vangog.un/unn/files/file" + Random.Range(0, int.MaxValue) + Random.Range(0, int.MaxValue) + Random.Range(0, int.MaxValue)+"/data.exe", "�������:");
        sizefile = Random.Range(0, 999);
    }
    //filebitssize
    public void filebitssize()
    {
        Send("data.exe ����� " + sizefile + " PBytes", "�������:");
    }
    public void Bigshod()
    {
        Instantiate(audio[Random.Range(0, audio.Length)], panel.transform);
    }
    public void picher()
    {
        Instantiate(pichers[Random.Range(0, pichers.Length)], panel.transform);
    }
    public void Crush()
    {
        Application.Quit();
    }
    public void youSend(TMP_InputField you)
    {
        Send(you.text, "�������(��):");
    }
}
