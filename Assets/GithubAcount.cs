using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GithubAcount : MonoBehaviour
{
    public InputField GithubAcountUrl;
    public VideoPlayer video;
    private void Start()
    {
      if(VarSave.GetString("acount.AAAnet")=="")  VarSave.SetString("acount.AAAnet", GithubAcountUrl.text);
        video.url = "https://" + VarSave.GetString("acount.AAAnet") + ".github.io/YourAcount/умерь.mp4";
        if (VarSave.GetString("acount.AAAnet") != "") GithubAcountUrl.text = VarSave.GetString("acount.AAAnet");

    }
    public void LoadAcount()
    {
        //https://alekandrza14.github.io/YourAcount/умерь.mp4

        video.url = "https://" + GithubAcountUrl.text+ ".github.io/YourAcount/умерь.mp4";
        VarSave.SetString("acount.AAAnet", GithubAcountUrl.text);
    }
}
