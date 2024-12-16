using System.IO;
using UnityEngine;

public enum TredeTaktic
{
    byeAlvase = 0,byeAwake = 1,byeUpdate = 2,sellAlvase = 3,sellAwake = 4,sellUpdate = 5
}

public class CriptoAgent : MonoBehaviour
{
    public float tevro = 1000000;
    public TredeTaktic taktic;
    public CriptoCoin CurrentCoin;
    public void Repeat1Minuts()
    {
        if (TredeTaktic.byeUpdate == taktic)
        {
            ByeCoin(tevro);
        }
        if (TredeTaktic.sellUpdate == taktic)
        {
            SellCoin(tevro);
        }
    }
    private void Awake()
    {
        if (TredeTaktic.byeUpdate == taktic)
        {
            InvokeRepeating("Repeat1Minuts",0,60);
        }
        if (TredeTaktic.sellUpdate == taktic)
        {
            InvokeRepeating("Repeat1Minuts", 0, 60);
        }
        if (TredeTaktic.byeAwake == taktic)
        {
            ByeCoin(tevro);
        }
        if (TredeTaktic.sellAwake == taktic)
        {
            SellCoin(tevro);
        }
        if (gameObject == FindFirstObjectByType<CriptoAgent>().gameObject)
        {
            float tevro1 = 1000000;
            TredeTaktic taktic1 = TredeTaktic.byeAlvase;

            GameObject[] items = Map_saver.t3;
            foreach (GameObject item in items)
            {
                if(item.GetComponent<CriptoAgent>())
                {
                    taktic1 = item.GetComponent<CriptoAgent>().taktic;
                    tevro1 = item.GetComponent<CriptoAgent>().tevro;
                    if (TredeTaktic.byeAlvase == taktic1)
                    {
                        ByeCoin(tevro1);
                    }
                    if (TredeTaktic.sellAlvase == taktic1)
                    {
                        SellCoin(tevro1);
                    }
                }
            }
           
        }
    }
    float PriseCoin()
    {
        return (CurrentCoin.Capitalization / (CurrentCoin.CoinCount * CurrentCoin.CoinMinValue)) + CurrentCoin.CoinMinValue;
    }
    public void ByeCoin(dynamic tevro)
    {
        DirectoryInfo di = new DirectoryInfo("res/UserWorckspace/Coins");
        FileInfo[] fi = di.GetFiles();
        FileInfo item = fi[Random.Range(0, fi.Length)];
        int paketCoins = Random.Range(0, 3);
        for (int i = 0; i < paketCoins; i++)
        {
            if (File.Exists("res/UserWorckspace/Coins/" + item.Name))
            {

                CurrentCoin = JsonUtility.FromJson<CriptoCoin>(File.ReadAllText("res/UserWorckspace/Coins/" + item.Name));
                Globalprefs.UpadateTevro();
                if (CurrentCoin.CoinCount >= 1 && tevro > PriseCoin())
                {
                    CurrentCoin.CoinCount -= 1;
                    CurrentCoin.CoinPepole += 1;
                    CurrentCoin.Capitalization += PriseCoin();
                    tevro -= PriseCoin();
                    File.WriteAllText("res/UserWorckspace/Coins/" + item.Name, JsonUtility.ToJson(CurrentCoin));
                }
            }
        }
    }
    public void SellCoin(dynamic tevro)
    {
        DirectoryInfo di = new DirectoryInfo("res/UserWorckspace/Coins");
        FileInfo[] fi = di.GetFiles();
        FileInfo item = fi[Random.Range(0, fi.Length)];
        int paketCoins = Random.Range(0, 3);
        for (int i = 0; i < paketCoins; i++)
        {
            if (File.Exists("res/UserWorckspace/Coins/" + item.Name))
            {

                CurrentCoin = JsonUtility.FromJson<CriptoCoin>(File.ReadAllText("res/UserWorckspace/Coins/" + item.Name));
                Globalprefs.UpadateTevro();
                if (CurrentCoin.CoinCount >= 1 && tevro > PriseCoin())
                {
                    CurrentCoin.CoinCount += 1;
                    CurrentCoin.CoinPepole -= 1;
                    CurrentCoin.Capitalization -= PriseCoin();
                    tevro += PriseCoin();
                    File.WriteAllText("res/UserWorckspace/Coins/" + item.Name, JsonUtility.ToJson(CurrentCoin));
                }
            }
        }
    }
}
