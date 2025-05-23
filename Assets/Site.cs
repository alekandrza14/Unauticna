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
    public void SendRealityEditor(InputField in_text)
    {
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            Directory.CreateDirectory("res/support");
            DirectoryInfo info = new DirectoryInfo("res/support");
            FileInfo[] files = info.GetFiles();
            string text = in_text.text;
            text = text.ToLower();
            text = text.Replace("a","+1");
            text = text.Replace("b","+2");
            text = text.Replace("c","+3");
            text = text.Replace("d","+4");
            text = text.Replace("e","+5");
            text = text.Replace("f","+6");
            text = text.Replace("g","+7");
            text = text.Replace("h","+8");
            text = text.Replace("r","+9");
            text = text.Replace("q","+10");
            text = text.Replace("k","+11");
            text = text.Replace("o","+12");
            text = text.Replace("m","+13");
            text = text.Replace("�","-14");
            text = text.Replace("�","-15");
            text = text.Replace("�","-16");
            text = text.Replace("�","-18");
            text = text.Replace("�","-19");
            text = text.Replace("�","-20");
            text = text.Replace("�","-21");
            text = text.Replace("�","-22");
            text = text.Replace("�","-23");
            text = text.Replace("�","-24");
            text = text.Replace("�","-25");
            text = text.Replace("�","-26");
            text = text.Replace("�","-27");
            text = text.Replace("�","-28");
            text = text.Replace("�","-29");
            text = text.Replace("�","-30");
            text = text.Replace("�","-31");
            text = text.Replace("�","-32");
            text = text.Replace("�","-33");
            text = text.Replace("�","-34");
            text = text.Replace("�","-35");
            text = text.Replace("�","-36");
            text = text.Replace("�","-37");
            text = text.Replace("�","-38");
            text = text.Replace("�","-39");
            File.WriteAllText("res/support/file" + files.Length + ".data", text);
            in_text.text = "���� " + files.Length + " ����������� �������� �������� ������ �� ���������";
        }
        else
        {
            if(File.Exists("res/support/file"+ in_text.text + ".data"))
            {
                string text = File.ReadAllText("res/support/file" + in_text.text+".data");
                for (int i = 0; i < 2; i++)
                {

                    if (i == 0) 
                    {
                        text = text.Replace("+1",  "a");
                        text = text.Replace("+2",  "b");
                        text = text.Replace("+3",  "c");
                        text = text.Replace("+4",  "d");
                        text = text.Replace("+5",  "e");
                        text = text.Replace("+6",  "f");
                        text = text.Replace("+7",  "g");
                        text = text.Replace("+8",  "h");
                        text = text.Replace("+9",  "r");
                        text = text.Replace("+10", "q");
                        text = text.Replace("+11", "k");
                        text = text.Replace("+12", "o");
                        text = text.Replace("+13", "m");
                        text = text.Replace("-14", "�");
                        text = text.Replace("-15", "�");
                        text = text.Replace("-16", "�");
                        text = text.Replace("-18", "�");
                        text = text.Replace("-19", "�");
                        text = text.Replace("-20", "�");
                        text = text.Replace("-21", "�");
                        text = text.Replace("-22", "�");
                        text = text.Replace("-23", "�");
                        text = text.Replace("-24", "�");
                        text = text.Replace("-25", "�");
                        text = text.Replace("-26", "�");
                        text = text.Replace("-27", "�");
                        text = text.Replace("-28", "�");
                        text = text.Replace("-29", "�");
                        text = text.Replace("-30", "�");
                        text = text.Replace("-31", "�");
                        text = text.Replace("-32", "�");
                        text = text.Replace("-33", "�");
                        text = text.Replace("-34", "�");
                        text = text.Replace("-35", "�");
                        text = text.Replace("-36", "�");
                        text = text.Replace("-37", "�");
                        text = text.Replace("-38", "�");
                        text = text.Replace("-39", "�");
                    }
                    if (i == 1)
                    {
                        in_text.text = text;
                    }
                }
            }
        }
    }
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
            siteinfo2.text = "�� " + CurrentCoin.CoinCount + " ����� " + CurrentCoin.Capitalization + " �����";
            siteinfo3.text = "������ " + PriseCoin();
            siteinfo4.text = "������� " + PriseCoin();
            siteinfo5.text = "� ������� �� " + PriseCoin();
            siteinfo6.text = "� ��� ���� " + CurrentCoin.CoinName + " " + CurrentCoin.CoinPlayer + " � ����� " + Globalprefs.LoadTevroPrise(0).ToString();
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
