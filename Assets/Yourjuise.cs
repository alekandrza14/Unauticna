using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Networking;

public class Yourjuise : InventoryEvent
{
    
    [SerializeField] itemName itemName;
    [SerializeField] MeshRenderer[] mr;
    string pichure;
    public bool Tex3d;
    string oldpichure;
    // Start is called before the first frame update
    public void Load1()
    {

        if (GetComponent<itemName>())
        {

            pichure = GetComponent<itemName>().ItemData;

            if (string.IsNullOrEmpty(pichure))
            {
                if (!Tex3d) pichure = @"image\customJuice.png";
                if (Tex3d) pichure = @"tex3D\Cillinder.png";
                GetComponent<itemName>().ItemData = pichure;
            }


        }
        StartCoroutine(GetText());
    }
    IEnumerator GetText()
    {
        Debug.Log(Path.GetDirectoryName(Application.dataPath) + @"\res\" + pichure);
        Debug.Log(Path.GetDirectoryName(@"res\"+ pichure));
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\res\" + pichure))
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
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Application.dataPath) + @"\res\" + pichure))
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
        if (!Tex3d) foreach (MeshRenderer render in mr)
            {
                render.material.SetTexture("_MainTex", (Texture2D)t);
            }
        if (Tex3d) foreach (MeshRenderer render in mr)
            {

                IntPtr r = IntPtr.Zero;
                Texture3D tex = new Texture3D(((Texture2D)t).width, ((Texture2D)t).width, ((Texture2D)t).width, TextureFormat.RGBA32, true, r) { hideFlags = HideFlags.NotEditable ,filterMode = FilterMode.Point, wrapMode = TextureWrapMode.Clamp ,mipMapBias =-1000};
                //  tex.
                int dim = ((Texture2D)t).width;
                Color[] c2D = ((Texture2D)t).GetPixels();
                Color[] c3D = new Color[c2D.Length];
                for (int x = 0; x < dim; ++x)
                {
                    for (int y = 0; y < dim; ++y)
                    {
                        for (int z = 0; z < dim; ++z)
                        {
                            int y_ = dim - y - 1;
                            c3D[x + (y * dim) + (z * dim * dim)] = c2D[z * dim + x + y_ * dim * dim];
                        }
                    }
                }
                  tex.SetPixels(c3D);
                tex.Apply();
                render.material.SetTexture("_MainTex", tex);
            }
    }

    bool i;
    private void Start()
    {
         pichure = GetComponent<itemName>().ItemData;
        if (!string.IsNullOrEmpty(pichure))
        {
            if (pichure != oldpichure)
            {

                StartCoroutine(GetText());
                oldpichure = pichure;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Input.GetKey(KeyCode.Mouse1))
        {
            RaycastHit hit = MainRay.MainHit;

            if (hit.collider != null)
            {
                if (hit.collider == GetComponent<Collider>())
                {
                    // itemName.ItemData
                    GameObject g = Instantiate(Resources.Load<GameObject>("ui/console/патч картинки"), Vector3.zero, Quaternion.identity);
                    g.GetComponent<NameYourJuice>().itemName = itemName;
                    Global.PauseManager.Pause();
                    i = true;
                }
            }
        }

       if(i) pichure = GetComponent<itemName>().ItemData;
        if (!string.IsNullOrEmpty(pichure))
        {
            if (pichure != oldpichure)
            {

                StartCoroutine(GetText());
                oldpichure = pichure;
            }
        }
    }
}
