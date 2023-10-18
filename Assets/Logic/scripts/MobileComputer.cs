using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public enum ComputerOperations
{
    None, Stocks, Games, Porducts, Map, Servers
}
public enum ComputerOperationsServers
{
    Nophing, Clearing, FireDepartment, SellAllItemsOnLocation
}
public enum StocksType
{
    UMU,CrinjeGame,DupCorporated,Ceribrals,MiniHome
}
public class MobileComputer : MonoBehaviour
{
    [SerializeField] RawImage Screen;
    [SerializeField] Texture[] sprites;
    [SerializeField] Text txt;
    [SerializeField] Text txt2;
    [SerializeField] itemName[] ClearItems;
    float stockold;
    float stocknew;
    int CurrentProduct;
    int CurrentStock;
    [SerializeField] ComputerOperations operations;
    [SerializeField] ComputerOperationsServers servers;
    [SerializeField] GameObject[] planshet;
    public static MobileComputer Computer()
    {
        return FindFirstObjectByType<MobileComputer>();
    }
    private void Start()
    {
        planshet[0].SetActive(false);
        planshet[1].SetActive(false);
    }
    public void StockMarket()
    {
        float sec = DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 60;
        Screen.texture = sprites[0];
        txt.text = stockConst().ToString();
        operations = ComputerOperations.Stocks;
    }
    public void MultinetShop()
    {

        operations = ComputerOperations.Porducts;
        txt.text = complsave.t3[CurrentProduct].name + " Const : " + (complsave.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 1.5f*(float)(Globalprefs.GetProcentInflitiuon()+1));

        Screen.texture = sprites[2];
    }
    public void MultinetServers()
    {

        operations = ComputerOperations.Servers;
        txt.text = "Отчистка месности";

        servers = ComputerOperationsServers.Clearing;
        Screen.texture = sprites[4];
    }
    public float stockConst()
    {
        float sec = DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 60;


        return ((math.cos(sec / 600f) * 500f) + 420f + new System.Random((int)sec).Next(-3, 4));

    }
    public float oldstockConst()
    {
        float sec = DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 60;
        sec -= 1;

        return ((math.cos(sec / 600f) * 500f) + 420f + new System.Random((int)sec).Next(-3, 4));

    }
    public float stockConst1()
    {
        float sec = DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 60;


        return ((math.sin(sec / 6000f) * 5000f) + 900f + new System.Random((int)sec).Next(-6, 3));

    }
    public float oldstockConst1()
    {
        float sec = DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 60;
        sec -= 1;


        return ((math.sin(sec / 6000f) * 5000f) + 900f + new System.Random((int)sec).Next(-6, 3));

    }
    public float stockConst2()
    {
        float sec = DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 60;


        return ((math.cos(sec / 40000000f) * 20000000f) + 220000f + new System.Random((int)sec).Next(-60, 80));

    }
    public float oldstockConst2()
    {
        float sec = DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 60;
        sec -= 1;

        return ((math.cos(sec / 40000000f) * 20000000f) + 220000f + new System.Random((int)sec).Next(-60, 80));

    }
    public float stockConst3()
    {
        float sec = DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 60;


        return ((math.sin(sec / 150f) * 100f) + 120f + new System.Random((int)sec).Next(-1, 4));

    }
    public float oldstockConst3()
    {
        float sec = DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 60;
        sec -= 1;

        return ((math.sin(sec / 150f) * 100f) + 120f + new System.Random((int)sec).Next(-1, 4));

    }
    public float stockConst4()
    {
        float sec = DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 60;


        return ((math.cos(sec / 10000f) * 400000f) + 200000f + new System.Random((int)sec).Next(-2, 1));

    }
    public float oldstockConst4()
    {
        float sec = DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 60;
        sec -= 1;

        return ((math.cos(sec / 10000f) * 400000f) + 200000f + new System.Random((int)sec).Next(-2, 1));

    }
    public void Map()
    {

        txt.text = "Map";
        Screen.texture = sprites[3];

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            planshet[0].SetActive(!planshet[0].activeSelf);
            planshet[1].SetActive(!planshet[1].activeSelf);
        }
        float sec = DateTime.Now.Second + DateTime.Now.Minute *60 + DateTime.Now.Hour *60;



        if (operations == ComputerOperations.Stocks)
        {
            if (CurrentStock == 0) stocknew = stockConst();
            if (CurrentStock == 1) stocknew = stockConst1();
             if (CurrentStock == 2) stocknew = stockConst2();
             if (CurrentStock == 3) stocknew = stockConst3();
             if (CurrentStock == 4) stocknew = stockConst4();
            if (CurrentStock == 0) stockold = oldstockConst();
             if (CurrentStock == 1) stockold = oldstockConst1();
            if (CurrentStock == 2) stockold = oldstockConst2();
            if (CurrentStock == 3) stockold = oldstockConst3();
          if (CurrentStock == 4) stockold = oldstockConst4();
            if (CurrentStock == 0) txt2.text = "UMU Count" + VarSave.GetMoney("StocksUMU", 0);
            if (CurrentStock == 1) txt2.text = "CrinjeGame Count" + VarSave.GetMoney("StocksCrinjeGame", 0);
            if (CurrentStock == 2) txt2.text = "DupCorporated Count" + VarSave.GetMoney("StocksDupCorporated", 0);
            if (CurrentStock == 3) txt2.text = "Ceribrals Count" + VarSave.GetMoney("StocksCeribrals", 0);
            if (CurrentStock == 4) txt2.text = "MiniHome Count" + VarSave.GetMoney("StocksMiniHome", 0);
            if (stockold > stocknew)
            {

                Screen.texture = sprites[1];
            }
            if (stockold < stocknew)
            {

                Screen.texture = sprites[0];
            }
            //CrinjeGame,DupCorporated,Ceribrals,MiniHome
            if (CurrentStock == 0) txt.text = "UMU Const" + Math.Round((decimal)stockConst(), 2);
            if (CurrentStock == 1) txt.text = "CrinjeGame Const" + Math.Round((decimal)stockConst1(), 2);
            if (CurrentStock == 2) txt.text = "DupCorporated Const" + Math.Round((decimal)stockConst2(), 2);
            if (CurrentStock == 3) txt.text = "Ceribrals Const" + Math.Round((decimal)stockConst3(), 2);
            if (CurrentStock == 4) txt.text = "MiniHome Const" + Math.Round((decimal)stockConst4(), 2);
        }
        if (operations == ComputerOperations.Porducts)
        {

            operations = ComputerOperations.Porducts;
            if (!VarSave.ExistenceVar("researchs/" + complsave.t3[CurrentProduct].name))
            {
                txt.text = "Unknown " + CurrentProduct + " Const : " + "NULL";

            }
            if (VarSave.ExistenceVar("researchs/" + complsave.t3[CurrentProduct].name))
            {
                txt.text = complsave.t3[CurrentProduct].name + " Const : " + (complsave.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 1.5f * (float)(Globalprefs.GetProcentInflitiuon() + 1));
            }

            Screen.texture = sprites[2];
        }
       
    }
    public void Return()
    {
        if (operations == ComputerOperations.Stocks)
        {
            if (CurrentStock == 0)
            {
                decimal stocks = VarSave.GetMoney("StocksUMU", 0);
                VarSave.LoadMoney("tevro", stocks * (decimal)stocknew);
                VarSave.LoadMoney("Stocks", -VarSave.GetMoney("StocksUMU", 0));
                VarSave.SetMoney("StocksUMU", 0);
            }
           if (CurrentStock == 1)
            {
                decimal stocks = VarSave.GetMoney("StocksCrinjeGame", 0);
                VarSave.LoadMoney("tevro", stocks * (decimal)stocknew);
                VarSave.LoadMoney("Stocks", -VarSave.GetMoney("StocksCrinjeGame", 0));
                VarSave.SetMoney("StocksCrinjeGame", 0);
            }
           if (CurrentStock == 2)
            {
                decimal stocks = VarSave.GetMoney("StocksDupCorporated", 0);
                VarSave.LoadMoney("tevro", stocks * (decimal)stocknew);
                VarSave.LoadMoney("Stocks", -VarSave.GetMoney("StocksDupCorporated", 0));
                VarSave.SetMoney("StocksDupCorporated", 0);
            }
           if (CurrentStock == 3)
            {
                decimal stocks = VarSave.GetMoney("StocksCeribrals", 0);
                VarSave.LoadMoney("tevro", stocks * (decimal)stocknew);
                VarSave.LoadMoney("Stocks", -VarSave.GetMoney("StocksCeribrals", 0));
                VarSave.SetMoney("StocksCeribrals", 0);
            }
            if (CurrentStock == 4)
            {
                decimal stocks = VarSave.GetMoney("StocksMiniHome", 0);
                VarSave.LoadMoney("tevro", stocks * (decimal)stocknew);
                VarSave.LoadMoney("Stocks", -VarSave.GetMoney("StocksMiniHome", 0));
                VarSave.SetMoney("StocksMiniHome", 0);
            }

        }
        if (operations == ComputerOperations.Porducts)
        {
            if (VarSave.LoadMoney("tevro", 0) >= (decimal)(complsave.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 1.5f * (float)(Globalprefs.GetProcentInflitiuon() + 1)))
            {
                if (VarSave.ExistenceVar("researchs/" + complsave.t3[CurrentProduct].name))
                {
                    VarSave.LoadMoney("tevro", -(decimal)(complsave.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 1.5f * (float)(Globalprefs.GetProcentInflitiuon() + 1)));
                    Instantiate(complsave.t3[CurrentProduct], mover.main().transform.position, Quaternion.identity);
                }
            }
        }
        if (operations == ComputerOperations.Servers)
        {
            if (servers == ComputerOperationsServers.Clearing)
            {
                foreach (itemName item in FindObjectsByType<itemName>(sortmode.main))
                {
                    foreach (itemName classitem in ClearItems)
                    {
                        if (item._Name == classitem._Name)
                        {
                            item.gameObject.AddComponent<DELETE>();
                        }
                    }
                }
                foreach (StandartObject item in FindObjectsByType<StandartObject>(sortmode.main))
                {

                    item.gameObject.AddComponent<DELETE>();

                }
            }
            if (servers == ComputerOperationsServers.FireDepartment)
            {
                Globalprefs.Chanse_fire = -40;
            }
            if (servers == ComputerOperationsServers.SellAllItemsOnLocation)
            {
                foreach (itemName item in FindObjectsByType<itemName>(sortmode.main))
                {
                    foreach (GameObject classitem in complsave.t3)
                    {
                        if (item._Name == classitem.GetComponent<itemName>()._Name)
                        {
                            VarSave.LoadMoney("tevro", (decimal)item.ItemPrise);
                           item.gameObject.AddComponent<DELETE>();
                        }
                    }
                }
            }
        }
    }
    public void Next()
    {
        if (operations == ComputerOperations.Servers)
        {
            int serversIndex = (int)servers;
            if (4 - 1 > serversIndex)
            {
                serversIndex++;
            }
            else
            {
                serversIndex = 0;
            }
            servers = (ComputerOperationsServers)serversIndex;
            if (servers == ComputerOperationsServers.Clearing)
            {
                txt.text = "Отчистка месности";

                servers = ComputerOperationsServers.Clearing;
                Screen.texture = sprites[4];
            }
            if (servers == ComputerOperationsServers.FireDepartment)
            {
                txt.text = "Пожарная служба";

                servers = ComputerOperationsServers.FireDepartment;
                Screen.texture = sprites[4];
            }
            if (servers == ComputerOperationsServers.Nophing)
            {
                txt.text = "Безделье";

                Screen.texture = sprites[4];
            }
            if (servers == ComputerOperationsServers.SellAllItemsOnLocation)
            {
                txt.text = "Распродажа";

                Screen.texture = sprites[4];
            }
        }

        if (operations == ComputerOperations.Porducts)
        {
            if (complsave.t3.Length - 1 > CurrentProduct)
            {
                CurrentProduct++;
            }
            else
            {
                CurrentProduct = 0;
            }
        }
        if (operations == ComputerOperations.Stocks)
        {
            if (5 - 1 > CurrentStock)
            {
                CurrentStock++;
            }
            else
            {
                CurrentStock = 0;
            }
        }
    }
    public void Back()
    {
        if (operations == ComputerOperations.Servers)
        {
            int serversIndex = (int)servers;
            if (0 < serversIndex)
            {
                serversIndex--;
            }
            else
            {
                serversIndex = 4-1;
            }
            servers = (ComputerOperationsServers)serversIndex;
            if (servers == ComputerOperationsServers.Clearing)
            {
                txt.text = "Отчистка месности";

                Screen.texture = sprites[4];
            }
            if (servers == ComputerOperationsServers.FireDepartment)
            {
                txt.text = "Пожарная служба";

                Screen.texture = sprites[4];
            }
            if (servers == ComputerOperationsServers.Nophing)
            {
                txt.text = "Безделье";

                Screen.texture = sprites[4];
            }
        }
        if (operations == ComputerOperations.Porducts)
        {
            if (0 < CurrentProduct)
            {
                CurrentProduct--;
            }
            else
            {
                CurrentProduct = complsave.t3.Length - 1;
            }
        }
        if (operations == ComputerOperations.Stocks)
        {
            if (0 < CurrentStock)
            {
                CurrentStock--;
            }
            else
            {
                CurrentStock = 5 - 1;
            }
        }
    }
}
