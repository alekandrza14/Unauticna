using System.IO;
using UnityEngine;

public class VideoNab : MonoBehaviour
{
    bool recordfilm;
    string[] items = new string[]
    {
        "script","script.u",
    };
    public static VideoNab vn;
    void Start()
    {
        ToggleRecording();
    }

    void OnRecording()
    {
       
     
                    s2 = Random.Range(-9999999, 9999999);
                    s = 0;
                    recordfilm = !recordfilm;


        if (recordfilm)
        {
            SaveFilm();
        }
        else
        {
            vn = null;
            ToggleRecording();
        }
    }
    private void Update()
    {
        if (recordfilm)
        {
            SaveFilm();
        }
    }
    private void ToggleRecording()
    {
        if (vn == null)
        {
            VideoNab[] s = objFind.ArrayByType<VideoNab>();
            vn = s[Random.Range(0, s.Length)];
            foreach (VideoNab item in s)
            {
                item.datarecording.targetTexture = off;
            }
            vn.datarecording.targetTexture = rt;
            vn.Invoke("OnRecording", 5 * 3);
            vn.Invoke("OnRecording", 10 * 3);
        }
    }

    public RenderTexture rt;
    public RenderTexture off;
    public Camera datarecording;
    public Vector2Int resolution;
    int s;
    string sstring;
    int s2;
    public void OnSignal()
    {
        SaveTexture();
    }
    // Use this for initialization
    public void SaveTexture()
    {
        byte[] bytes = toTexture2D(rt).EncodeToPNG();
        Directory.CreateDirectory("res/AnyTube/RenderScrin");
        System.IO.File.WriteAllBytes("res/AnyTube/RenderScrin/text" + Random.Range(-9999999, 9999999) + ".png", bytes);
    }
    public void SaveFilm()
    {
        byte[] bytes = toTexture2D(rt).EncodeToPNG();
        Directory.CreateDirectory("res/AnyTube/RenderScrins" + s2);
        sstring = s.ToString();
        for (int i = 0; i < 10; i++)
        {
            if (sstring.Length < 10)
            {
                sstring = "0" + sstring;
            }
        }
        System.IO.File.WriteAllBytes("res/AnyTube/RenderScrins" + s2 + "/text" + sstring + ".png", bytes);
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
