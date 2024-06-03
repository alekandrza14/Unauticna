using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Networking;

public enum ContryTextures
{
    simvol,flag
}
public class LoadCustomSimvolic : MonoBehaviour
{
    [SerializeField] InputField ifd;
    [SerializeField] RawImage img;
    [SerializeField] ContryTextures contryTextures;
    string pichure;
    public bool Tex3d;
    string oldpichure;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (contryTextures == ContryTextures.simvol) StartCoroutine(GetText());
        if (contryTextures == ContryTextures.flag) StartCoroutine(GetTextflag());
    }
    public void EditSimvolic()
    {
        if (contryTextures == ContryTextures.simvol) VarSave.SetString("CustomSimvolic", ifd.text);
        if (contryTextures == ContryTextures.flag) VarSave.SetString("Customflag", ifd.text);


        if (contryTextures == ContryTextures.simvol) StartCoroutine(GetText());
        if (contryTextures == ContryTextures.flag) StartCoroutine(GetTextflag());
    }
    IEnumerator GetText()
    {
        if (contryTextures == ContryTextures.simvol) if (VarSave.GetString("CustomSimvolic") != "") ifd.text = VarSave.GetString("CustomSimvolic");
        if (contryTextures == ContryTextures.flag) if (VarSave.GetString("Customflag") != "") ifd.text = VarSave.GetString("Customflag");
        Debug.Log(Path.GetDirectoryName(Application.dataPath) + @"\res\image\simvolica\" + ifd.text);
        Debug.Log(Path.GetDirectoryName(@"\res\image\simvolica\" + ifd.text));
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\res\image\simvolica\" + ifd.text))
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
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Application.dataPath) + @"\res\image\simvolica\" + ifd.text))
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
    IEnumerator GetTextflag()
    {
        if (contryTextures == ContryTextures.simvol) if (VarSave.GetString("CustomSimvolic") != "") ifd.text = VarSave.GetString("CustomSimvolic");
        if (contryTextures == ContryTextures.flag) if (VarSave.GetString("Customflag") != "") ifd.text = VarSave.GetString("Customflag");
        Debug.Log(Path.GetDirectoryName(Application.dataPath) + @"\res\image\flag\" + ifd.text);
        Debug.Log(Path.GetDirectoryName(@"\res\image\flag\" + ifd.text));
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\res\image\flag\" + ifd.text))
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
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Application.dataPath) + @"\res\image\flag\" + ifd.text))
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

        img.texture= (Texture2D)t;
       
    }
}
