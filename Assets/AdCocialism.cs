using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class AdCocialism : MonoBehaviour
{
    void Start()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo("res/SocialAd");
        FileInfo files = directoryInfo.GetFiles()[((int)Random.Range(0, directoryInfo.GetFiles().Length))];
        GetComponent<VideoPlayer>().url = files.FullName;
    }
}
