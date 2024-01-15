using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FilmCamera : MonoBehaviour
{
    bool recordfilm;
    string[] items = new string[]
    {
        "script","script.u",
    };
    bool Function()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (Globalprefs.item != items[i])
            {

                return true;
            }
        }
        return false;
    }
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (Input.GetKeyDown(KeyCode.Mouse0) && hit.collider != null)
        {
            if (gameObject == hit.collider.gameObject)
            {
                SaveTexture();
            }
        }
     if(Function()) if (Input.GetKeyDown(KeyCode.E) && hit.collider != null)
        {
            if (gameObject == hit.collider.gameObject)
            {
                s2 = Random.Range(-9999999, 9999999);
                s = 0;
                recordfilm = !recordfilm;
            }
        }
        if (recordfilm)
        {
            SaveFilm();
        }
    }
    public RenderTexture rt;
    public Vector2Int resolution;
    int s;
    string sstring;
    int s2;
    // Use this for initialization
    public void SaveTexture()
    {
        byte[] bytes = toTexture2D(rt).EncodeToPNG();
        Directory.CreateDirectory("C:/Sceenshots Unauticna/RenderScrin");
        System.IO.File.WriteAllBytes("C:/Sceenshots Unauticna/RenderScrin/text" + Random.Range(-9999999, 9999999) + ".png", bytes);
    }
    public void SaveFilm()
    {
        byte[] bytes = toTexture2D(rt).EncodeToPNG();
        Directory.CreateDirectory("C:/Sceenshots Unauticna/RenderScrins" + s2);
        sstring = s.ToString();
        for (int i =0;i<10;i++)
        {
            if (sstring.Length<10)
            {
                sstring = "0" + sstring;
            }
        }
        System.IO.File.WriteAllBytes("C:/Sceenshots Unauticna/RenderScrins"+ s2+"/text"+ sstring + ".png", bytes);
        s++;
    }
    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(resolution.x, resolution.y, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}
