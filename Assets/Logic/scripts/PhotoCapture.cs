using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class PhotoCapture : MonoBehaviour
{
    public Camera captureCamera;
    public RawImage ri;
    public Texture2D texture1;
   IEnumerator GetText()
   {
        Debug.Log(Path.GetDirectoryName(Application.dataPath) + @"\unsave\var\Screenshot.png");
        Debug.Log(Path.GetDirectoryName("unsave/var/Screenshot.png"));
        using UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\unsave\var\Screenshot.png");
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            // Get downloaded asset bundle
            texture1 = DownloadHandlerTexture.GetContent(uwr);
            ri.texture = texture1;
            Globalprefs.txt = texture1;
        }

    }
    IEnumerator Screenhoting()
    {
        Globalprefs.Scrensoting = true;
        yield return new WaitForSeconds(.5f);
        Directory.CreateDirectory(@"C:\Sceenshots Unauticna");
        ScreenCapture.CaptureScreenshot(@"C:\Sceenshots Unauticna\Screenshot" + Random.Range(-9999999, 9999999) + ".png", 1);

        yield return new WaitForSeconds(.5f);

        Globalprefs.Scrensoting = false;

    }
    private void Start()
    {
        StartCoroutine(GetText());
        
    }
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.F12))
        {
            StartCoroutine(Screenhoting());
        }

        //texture1;
        if (!Globalprefs.Pause)
        {
            if (Input.GetKeyDown(KeyCode.P) && SceneManager.GetActiveScene().name != "Gread_space" && !GameObject.FindWithTag("console"))
            {
                Globalprefs.isnew = true;
                int width = this.captureCamera.pixelWidth;
                int height = this.captureCamera.pixelHeight;
                Texture2D texture = new(width, height);

                ScreenCapture.CaptureScreenshot(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\unsave\var\Screenshot.png", 1);

                RenderTexture targetTexture = RenderTexture.GetTemporary(width, height);

                this.captureCamera.targetTexture = targetTexture;
                this.captureCamera.Render();
                Globalprefs.postes = new Vector3[GameObject.FindObjectsByType<tesseraktenemy4>(sortmode.main).Length];
                Globalprefs.postes2 = new Vector3[GameObject.FindGameObjectsWithTag("tesseract").Length];
                for (int i = 0; i < FindObjectsByType<tesseraktenemy4>(sortmode.main).Length; i++)
                {
                    Globalprefs.postes[i] = FindObjectsByType<tesseraktenemy4>(sortmode.main)[i].transform.position;
                }
                for (int i = 0; i < GameObject.FindGameObjectsWithTag("tesseract").Length; i++)
                {
                    Globalprefs.postes2[i] = GameObject.FindGameObjectsWithTag("tesseract")[i].transform.position;
                }

                RenderTexture.active = targetTexture;

                Rect rect = new(0, 0, width, height);
                texture.ReadPixels(rect, 0, 0);
                texture.Apply();

                ri.texture = texture;
                Globalprefs.txt = texture;
                Globalprefs.idscene = SceneManager.GetActiveScene().buildIndex;
                Directory.CreateDirectory("unsave/global_var");
                File.WriteAllText("unsave/global_var/id", Globalprefs.idscene.ToString());
                GameManager.save();
                SceneManager.LoadScene("Gread_space");

                Ray r = new(Camera.main.transform.position, Camera.main.transform.forward);
                if (Physics.Raycast(r, out RaycastHit hit))
                {
                    if (hit.collider != null)
                    {
                        Globalprefs.pos = hit.point;
                    }
                }


            }

        }
    }

}