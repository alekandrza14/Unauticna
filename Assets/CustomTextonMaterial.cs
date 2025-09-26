
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Networking;


public class CustomTextonMaterial : MonoBehaviour
{

    [SerializeField] public string CoTex;
    [SerializeField] MeshRenderer[] mr;
    string pichure;
    string oldpichure;
    // Start is called before the first frame update
    public void Load1()
    {

        pichure = CoTex;

        StartCoroutine(GetText());
    }
    IEnumerator GetText()
    {
        Debug.Log(Path.GetDirectoryName(Application.dataPath) + @"\res\" + pichure);
        Debug.Log(Path.GetDirectoryName(@"res\" + pichure));
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\res\" + pichure))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                Texture t = DownloadHandlerTexture.GetContent(uwr);
                //   Texture t = Globalprefs.txt;

                //   im.sprite = Sprite.Create((Texture2D)t, new Rect(0, 0, Globalprefs.txt.width, Globalprefs.txt.height), Vector2.zero);
                TextureLoad(t);
                Debug.Log("1");
                //  im.enabled = true;
                //   anim.Play("panel");

            }
        }
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Application.dataPath) + @"\res\" + pichure))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(uwr.error);
            }
            else
            {
                // Get downloaded asset bundle
                Texture t = DownloadHandlerTexture.GetContent(uwr);
                //   Texture t = Globalprefs.txt;

                //   im.sprite = Sprite.Create((Texture2D)t, new Rect(0, 0, Globalprefs.txt.width, Globalprefs.txt.height), Vector2.zero);
                TextureLoad(t);
                Debug.Log("1");
                //  im.enabled = true;
                //   anim.Play("panel");

            }
        }
    }

    private void TextureLoad(Texture t)
    {
        foreach (MeshRenderer render in mr)
        {
            render.material.SetTexture("_MainTex", (Texture2D)t);
        }
      
    }

    bool i;
    private void Start()
    {
        pichure = CoTex;

        StartCoroutine(GetText());
    }
}

