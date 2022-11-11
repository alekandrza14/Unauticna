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
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\unsave\var\Screenshot.png"))
        {
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

    }
    private void Start()
    {
        StartCoroutine(GetText());
        
    }
    public void Update()
    {



        //texture1;
        if (Input.GetKeyDown(KeyCode.P) && SceneManager.GetActiveScene().name != "Gread_space")
        {
            Globalprefs.isnew = true;
            int width = this.captureCamera.pixelWidth;
            int height = this.captureCamera.pixelHeight;
            Texture2D texture = new Texture2D(width, height);

            ScreenCapture.CaptureScreenshot(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath))+@"\unsave\var\Screenshot.png", 1);

            RenderTexture targetTexture = RenderTexture.GetTemporary(width, height);

            this.captureCamera.targetTexture = targetTexture;
            this.captureCamera.Render();
            Globalprefs.postes = new Vector3[GameObject.FindObjectsOfType<tesseraktenemy4>().Length];
            for (int i = 0;i<FindObjectsOfType<tesseraktenemy4>().Length;i++)
            {
                Globalprefs.postes[i] = FindObjectsOfType<tesseraktenemy4>()[i].transform.position;
            }

            RenderTexture.active = targetTexture;

            Rect rect = new Rect(0, 0, width, height);
            texture.ReadPixels(rect, 0, 0);
            texture.Apply();

            ri.texture = texture;
            Globalprefs.txt = texture;
            Globalprefs.idscene = SceneManager.GetActiveScene().buildIndex;
            Directory.CreateDirectory("unsave/global_var");
            File.WriteAllText("unsave/global_var/id",Globalprefs.idscene.ToString());
            musave.save();
            SceneManager.LoadScene("Gread_space");

            Ray r = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null)
                {
                    Globalprefs.pos = hit.point;
                }
            }


        }
        
    }

}