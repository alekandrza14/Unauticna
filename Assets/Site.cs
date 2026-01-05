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
            text = text.Replace("а","-14");
            text = text.Replace("б","-15");
            text = text.Replace("в","-16");
            text = text.Replace("г","-18");
            text = text.Replace("д","-19");
            text = text.Replace("е","-20");
            text = text.Replace("ё","-21");
            text = text.Replace("ж","-22");
            text = text.Replace("з","-23");
            text = text.Replace("у","-24");
            text = text.Replace("ф","-25");
            text = text.Replace("х","-26");
            text = text.Replace("ч","-27");
            text = text.Replace("щ","-28");
            text = text.Replace("о","-29");
            text = text.Replace("п","-30");
            text = text.Replace("р","-31");
            text = text.Replace("с","-32");
            text = text.Replace("т","-33");
            text = text.Replace("ь","-34");
            text = text.Replace("ы","-35");
            text = text.Replace("ъ","-36");
            text = text.Replace("э","-37");
            text = text.Replace("ю","-38");
            text = text.Replace("я","-39");
            File.WriteAllText("res/support/file" + files.Length + ".data", text);
            in_text.text = "файл " + files.Length + " записывайте окуратно шифровка данных не совершена";
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
                        text = text.Replace("-14", "а");
                        text = text.Replace("-15", "б");
                        text = text.Replace("-16", "в");
                        text = text.Replace("-18", "г");
                        text = text.Replace("-19", "д");
                        text = text.Replace("-20", "е");
                        text = text.Replace("-21", "ё");
                        text = text.Replace("-22", "ж");
                        text = text.Replace("-23", "з");
                        text = text.Replace("-24", "у");
                        text = text.Replace("-25", "ф");
                        text = text.Replace("-26", "х");
                        text = text.Replace("-27", "ч");
                        text = text.Replace("-28", "щ");
                        text = text.Replace("-29", "о");
                        text = text.Replace("-30", "п");
                        text = text.Replace("-31", "р");
                        text = text.Replace("-32", "с");
                        text = text.Replace("-33", "т");
                        text = text.Replace("-34", "ь");
                        text = text.Replace("-35", "ы");
                        text = text.Replace("-36", "ъ");
                        text = text.Replace("-37", "э");
                        text = text.Replace("-38", "ю");
                        text = text.Replace("-39", "я");
                    }
                    if (i == 1)
                    {
                        in_text.text = text;
                    }
                }
            }
        }
    }
    private void Start()
    {
        hello.windowmesenge.LoadApplication("loaderAnyTubeVideo");
        Application.OpenURL("c:/");
    }
    public void UploadVideo()
    {
        if (VarSave.GetString("uploadvideo.sing", SaveType.computer) != "")
        {
            Interface InterfaceFile = new Interface();
            GameObject canvas = Instantiate(Resources.Load<GameObject>("DefaultCanvas"));
            if (File.Exists("res/UserWorckspace/Iterface/AAA;AnyTube.un/video1.json"))
            {
                InterfaceFile = JsonUtility.FromJson<Interface>(File.ReadAllText("res/UserWorckspace/Iterface/AAA;AnyTube.un/video1.json"));
                Path.GetFileName(VarSave.GetString("uploadvideo.sing", SaveType.computer));
                File.Copy(VarSave.GetString("uploadvideo.sing", SaveType.computer), "res/Video/" + Path.GetFileName(VarSave.GetString("uploadvideo.sing", SaveType.computer)) + "",true);
                InterfaceFile.image2texture[0] = "Video\\\\" + Path.GetFileName(VarSave.GetString("uploadvideo.sing", SaveType.computer));
                File.WriteAllText("res/UserWorckspace/Iterface/AAA;AnyTube.un/" + Path.GetFileName(VarSave.GetString("uploadvideo.sing", SaveType.computer)) + ".json",JsonUtility.ToJson(InterfaceFile));
                siteFinder.text = "AAA;AnyTube.un/" + Path.GetFileName(VarSave.GetString("uploadvideo.sing", SaveType.computer)+ "");
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
