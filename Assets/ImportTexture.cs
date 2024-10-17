using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImportTexture : MonoBehaviour
{
    [SerializeField] InputField ifd;
    [SerializeField] RaymarchCam img;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

         StartCoroutine(GetText());
    }
    public void EditTexture()
    {
        VarSave.SetString("imageIcon", ifd.text);


         StartCoroutine(GetText());
    }
    IEnumerator GetText()
    {
         if (VarSave.GetString("imageIcon") != "") ifd.text = VarSave.GetString("imageIcon");
        Debug.Log(Path.GetDirectoryName(Application.dataPath) + @"res/image/Other/" + ifd.text);
        Debug.Log(Path.GetDirectoryName(@"res/image/Other/" + ifd.text));
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"/res/image/Other/" + ifd.text))
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
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Application.dataPath) + @"/res/image/Other/" + ifd.text))
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

        img._globalGeometryTexture13 = (Texture2D)t;

    }
}
