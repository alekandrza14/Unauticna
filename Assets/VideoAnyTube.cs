using UnityEngine;
using UnityEngine.UI;

public class VideoAnyTube : MonoBehaviour
{
    public Text VideoName;
    public Text VideoViews;
    public int Views;
    public void UpadateVideo(string Video)
    {
        Views = VarSave.GetInt(Video);
        VideoName.text = Video;
        VideoViews.text = Views.ToString() + " Views";

    }
    public void PlayVideo()
    {
        Views++;
        VarSave.SetInt(VideoName.text, Views);
        VideoViews.text = Views.ToString()+" Views";
        Acaunt.Spawn("AAA;AnyTube.un\\" + VideoName.text);
    }
}
