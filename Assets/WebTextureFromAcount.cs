
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Networking;
using UnityEngine.UI;


public class WebTextureFromAcount : MonoBehaviour
{

    [SerializeField] public string CoTex;
    [SerializeField] RawImage mr;
    string pichure;
    string oldpichure;
    // Start is called before the first frame update
    /*
     *  public InputField GithubAcountUrl;
    public VideoPlayer video;
    private void Start()
    {
      if(VarSave.GetString("acount.AAAnet")=="")  VarSave.SetString("acount.AAAnet", GithubAcountUrl.text);
        video.url = "https://" + VarSave.GetString("acount.AAAnet") + ".github.io/YourAcount/умерь.mp4";

    }
    public void LoadAcount()
    {
        //https://alekandrza14.github.io/YourAcount/умерь.mp4

        video.url = "https://" + GithubAcountUrl.text+ ".github.io/YourAcount/умерь.mp4";
        VarSave.SetString("acount.AAAnet", GithubAcountUrl.text);
    }
     */
    IEnumerator GetText()
    {
       // video.url = "https://" + GithubAcountUrl.text + ".github.io/YourAcount/умерь.mp4";
        Debug.Log("https://" + VarSave.GetString("acount.AAAnet") + ".github.io/YourAcount/Avatar.png");
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://" + VarSave.GetString("acount.AAAnet").ToLower() + ".github.io/YourAcount/Avatar.png");
        yield return www.SendWebRequest();
        if (!mr.texture)
        {
            Debug.Log("<color=red>https://" + VarSave.GetString("acount.AAAnet").ToLower() + ".github.io/YourAcount/Avatar.png</color>");
        }
        if (www.result != UnityWebRequest.Result.Success)
        {
            if (!mr.texture)
            {
                Debug.Log(www.error);
                Debug.Log("<color=red>https://" + VarSave.GetString("acount.AAAnet").ToLower() + ".github.io/YourAcount/Avatar.png</color>");
            }
        }
        else
        {
            if (mr.texture)
            {
                mr.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                Debug.Log("<color=red>https://" + VarSave.GetString("acount.AAAnet").ToLower() + ".github.io/YourAcount/Avatar.png</color>");
            }
        }
       

    }
    IEnumerator GetTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://" + VarSave.GetString("acount.AAAnet").ToLower() + ".github.io/YourAcount/Avatar.png");
        yield return www.SendWebRequest();

        Texture myTexture = DownloadHandlerTexture.GetContent(www);
        mr.texture = myTexture;
    }
    private void TextureLoad(Texture t)
    {
       
            mr.texture = (Texture2D)t;
        Debug.Log("<color=red>https://" + VarSave.GetString("acount.AAAnet").ToLower() + ".github.io/YourAcount/Avatar.png</color>");
    }

    bool i;
    float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            StartCoroutine(GetTexture());
            timer = 0;
        }
    }
}

