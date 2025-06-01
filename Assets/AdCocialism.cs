using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class AdCocialism : MonoBehaviour
{
    public bool off;
    void Start()
    {
        if (!off)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo("res/SocialAd");
            FileInfo files = directoryInfo.GetFiles()[((int)Random.Range(0, directoryInfo.GetFiles().Length))];
            GetComponent<VideoPlayer>().url = files.FullName; 
        }
    }
    public void LOADVIDIO(string video, out RenderTexture rt)
    {
        rt = new RenderTexture(500, 500, UnityEngine.Experimental.Rendering.GraphicsFormat.R16G16B16A16_UNorm, UnityEngine.Experimental.Rendering.GraphicsFormat.R16G16B16A16_UNorm);
        GetComponent<VideoPlayer>().url = new DirectoryInfo("res").FullName + "/" + video;
        GetComponent<VideoPlayer>().targetTexture = rt;
        GetComponent<VideoPlayer>().Play();
    }
}
