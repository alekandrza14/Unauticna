using System.IO;
using UnityEngine;

public class ViewScroll : MonoBehaviour
{
    public Transform VideoCanvas;
    public GameObject VideoButton;
    private void Start()
    {
        DirectoryInfo info = new DirectoryInfo("res\\UserWorckspace\\Iterface\\AAA;AnyTube.un");
        FileInfo[] files = info.GetFiles();
        foreach (FileInfo file in files)
        {
            GameObject obj = Instantiate(VideoButton, VideoCanvas);
            obj.GetComponent<VideoAnyTube>().UpadateVideo(file.Name.Replace(".json",""));
        }
    }
    void Update()
    {
        GetComponent<RectTransform>().anchoredPosition -= Vector2.up * Input.GetAxisRaw("Mouse ScrollWheel")*50;
    }
}
