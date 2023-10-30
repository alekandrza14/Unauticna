using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class Yourjuise : InventoryEvent
{
    
    [SerializeField] itemName itemName;
    [SerializeField] MeshRenderer[] mr;
    string pichure;
    string oldpichure;
    // Start is called before the first frame update
    public void Load1()
    {

        if (GetComponent<itemName>())
        {

            pichure = GetComponent<itemName>().ItemData;

            if (string.IsNullOrEmpty(pichure))
            {
                pichure = @"image\customJuice.png";
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
                foreach (MeshRenderer render in mr)
                {
                    render.material.SetTexture("_MainTex", (Texture2D)t);
                }
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
                foreach (MeshRenderer render in mr)
                {
                    render.material.SetTexture("_MainTex", (Texture2D)t);
                }
                Debug.Log("1");
                //  im.enabled = true;
                //   anim.Play("panel");

            }
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
