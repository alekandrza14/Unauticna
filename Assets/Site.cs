using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CriptoCoin
{
    public string CoinName;
    public float CoinMinValue;
    public float CoinCount;
    public float Capitalization;
    public string CoinDiscription;
    public float CoinPlayer;
    public float CoinPepole;
    public string CoinLogo;
    public string CoinShapka;
}

public class Site : MonoBehaviour
{
    public string SiteName;
    public InputField siteFinder;
    public InputField paket;
    public CriptoCoin CurrentCoin;
    public Text siteDiscription;
    public Text siteinfo1;
    public Text siteinfo2;
    public Text siteinfo3;
    public Text siteinfo4;
    public Text siteinfo5;
    public Text siteinfo6;
    public RawImage texture1;
    public RawImage texture2;
    public RawImage texture3;
    public float MinValue;
    IEnumerator GetLogoCoin(string CoinLogo)
    {

        Debug.Log(Path.GetDirectoryName(Application.dataPath) + @"\res\image\coin\" + CoinLogo);
        Debug.Log(Path.GetDirectoryName(@"\res\image\coin\" + CoinLogo));
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\res\image\coin\" + CoinLogo))
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
                Texture1Load(t);
                Debug.Log("1");
                //  im.enabled = true;
                //   anim.Play("panel");

            }
        }
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Application.dataPath) + @"\res\image\coin\" + CoinLogo))
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
                Texture1Load(t);
                Debug.Log("1");
                //  im.enabled = true;
                //   anim.Play("panel");

            }
        }
    }

   
    IEnumerator GetShapkaCoin(string CoinShapka)
    {

        Debug.Log(Path.GetDirectoryName(Application.dataPath) + @"\res\image\Shapka\" + CoinShapka);
        Debug.Log(Path.GetDirectoryName(@"\res\image\Shapka\" + CoinShapka));
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Path.GetDirectoryName(Application.dataPath)) + @"\res\image\Shapka\" + CoinShapka))
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
                Texture2Load(t);
                Debug.Log("1");
                //  im.enabled = true;
                //   anim.Play("panel");

            }
        }
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(Path.GetDirectoryName(Application.dataPath) + @"\res\image\Shapka\" + CoinShapka))
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
                Texture2Load(t);
                Debug.Log("1");
                //  im.enabled = true;
                //   anim.Play("panel");

            }
        }
    }

    private void Texture1Load(Texture t)
    {

        texture1.texture = (Texture2D)t;

    }
    private void Texture2Load(Texture t)
    {

        texture2.texture = (Texture2D)t;

    }
    float PriseCoin()
    {
        return (CurrentCoin.Capitalization / (CurrentCoin.CoinCount* CurrentCoin.CoinMinValue))+ CurrentCoin.CoinMinValue;
    }
    void Update()
    {
        if (SiteName == "$Cripto" && CurrentCoin != null)
        {
            siteinfo2.text = "на " + CurrentCoin.CoinCount + " монет " + CurrentCoin.Capitalization + " тевро";
            siteinfo3.text = "купить " + PriseCoin();
            siteinfo4.text = "продать " + PriseCoin();
            siteinfo5.text = "в рабство за " + PriseCoin();
            siteinfo6.text = "У вас есть " + CurrentCoin.CoinName + " " + CurrentCoin.CoinPlayer + " а тевро " + Globalprefs.LoadTevroPrise(0).ToString();
        }
    }
    public void CreateCriptoCoin()
    {
        if (!File.Exists("res/UserWorckspace/Coins/" + siteFinder.text + ".txt"))
        {
            CurrentCoin = new();
            CurrentCoin.CoinName = siteFinder.text;
            File.WriteAllText("res/UserWorckspace/Coins/" + siteFinder.text + ".txt",JsonUtility.ToJson(CurrentCoin));
        }
    }
    public void FindCriptoCoin()
    {
        if (File.Exists("res/UserWorckspace/Coins/" + siteFinder.text + ".txt"))
        {
            CurrentCoin = JsonUtility.FromJson<CriptoCoin>(File.ReadAllText("res/UserWorckspace/Coins/" + siteFinder.text + ".txt"));
            StartCoroutine(GetLogoCoin(CurrentCoin.CoinLogo));
            StartCoroutine(GetShapkaCoin(CurrentCoin.CoinShapka));
            siteDiscription.text = CurrentCoin.CoinDiscription;
            siteinfo1.text = CurrentCoin.CoinName;
            MinValue = CurrentCoin.CoinMinValue;
        }
    }
    public void ByeCoin()
    {
        int paketCoins = int.Parse(paket.text);
       for (int i =0;i<paketCoins;i++)
       {
            if (File.Exists("res/UserWorckspace/Coins/" + siteFinder.text + ".txt"))
            {

                CurrentCoin = JsonUtility.FromJson<CriptoCoin>(File.ReadAllText("res/UserWorckspace/Coins/" + siteFinder.text + ".txt"));
                Globalprefs.UpadateTevro();
                if (CurrentCoin.CoinCount >= 1 && Globalprefs.LoadTevroPrise(0) > (decimal)PriseCoin())
                {
                    CurrentCoin.CoinCount -= 1;
                    CurrentCoin.CoinPlayer += 1;
                    CurrentCoin.Capitalization += PriseCoin();
                    Globalprefs.LoadTevroPrise(-(decimal)PriseCoin());
                    File.WriteAllText("res/UserWorckspace/Coins/" + siteFinder.text + ".txt", JsonUtility.ToJson(CurrentCoin));
                }
            } 
        }
    }
    public void SellCoin()
    {
        int paketCoins = int.Parse(paket.text);
        for (int i = 0; i < paketCoins; i++)
        {

            if (File.Exists("res/UserWorckspace/Coins/" + siteFinder.text + ".txt"))
            {

                CurrentCoin = JsonUtility.FromJson<CriptoCoin>(File.ReadAllText("res/UserWorckspace/Coins/" + siteFinder.text + ".txt"));
                Globalprefs.UpadateTevro();
                if (CurrentCoin.CoinPlayer >= 1)
                {
                    CurrentCoin.CoinCount += 1;
                    CurrentCoin.CoinPlayer -= 1;
                    CurrentCoin.Capitalization -= PriseCoin();
                    Globalprefs.LoadTevroPrise((decimal)PriseCoin());
                    File.WriteAllText("res/UserWorckspace/Coins/" + siteFinder.text + ".txt", JsonUtility.ToJson(CurrentCoin));
                }
            }
        }
       
    }
    public void QuitSite()
    {
        Destroy(gameObject);
    }
}
