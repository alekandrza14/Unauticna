﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        shorta1();
        float sec = DateTime.Now.Second + DateTime.Now.Minute * 60 + DateTime.Now.Hour * 60;
        Screen.texture = sprites[0];
        txt.text = stockConst().ToString();
        operations = ComputerOperations.Stocks;
    }
    public void MultinetShop()
    {


        shorta1();
        operations = ComputerOperations.Porducts;
        txt.text = Map_saver.t3[CurrentProduct].name + " Const : " + (Map_saver.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 1.5f*(float)(Globalprefs.GetProcentInflitiuon()+1));

        Screen.texture = sprites[2];
    }
    public void MultinetServers()
    {
        shorta1();
        operations = ComputerOperations.Servers;
        txt.text = "Отчистка месности";

        servers = ComputerOperationsServers.Clearing;
        Screen.texture = sprites[4];
    }

    private void shorta1()
    {
        if (playerdata.Geteffect("free") == null)
        {
            if (VarSave.LoadFloat("luck", 0f) > 3 && UnityEngine.Random.Range(0, 2) == 0)
            {
                shorta = 1.5m;
            }
            if (VarSave.LoadFloat("luck", 0f) > 24 && UnityEngine.Random.Range(0, 7) == 0)
            {

                shorta = 4.5m;
            }
            if (VarSave.LoadFloat("luck", 0f) > 666 && UnityEngine.Random.Range(0, 80) == 0)
            {

                shorta = 400.5m;
            }
            if (VarSave.LoadFloat("luck", 0f) > 906 && UnityEngine.Random.Range(0, 100) == 0)
            {

                shorta = decimal.MaxValue;
            }
            if (VarSave.LoadFloat("luck", 0f) < -40 && UnityEngine.Random.Range(0, 1) == 0)
            {

                shorta = 0;
            }
        }
        else
        {
            shorta = decimal.MaxValue;

        }
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

        shorta1();
        operations = ComputerOperations.Map;
        txt.text = "Map";
        Screen.texture = sprites[3];

    }
    decimal shorta = 1;
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
        else
        {
            if (operations != ComputerOperations.Porducts) txt2.text = "";
        }
        if (operations == ComputerOperations.Porducts)
        {

            operations = ComputerOperations.Porducts;
            if (!Directory.Exists("debug"))
            {
                if (!VarSave.ExistenceVar("researchs/" + Map_saver.t3[CurrentProduct].name))
                {
                    txt.text = "Unknown " + CurrentProduct + " Const : " + "NULL";

                }
                if (VarSave.ExistenceVar("researchs/" + Map_saver.t3[CurrentProduct].name))
                {
                    if (!Map_saver.t3[CurrentProduct].GetComponent<Запрещён>())
                    {
                        txt.text = Map_saver.t3[CurrentProduct].name + " Const : " + ((Map_saver.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 1.5f  * (float)(Globalprefs.GetProcentInflitiuon() + 1)) / (float)shorta ) ;
                    }
                    if (Map_saver.t3[CurrentProduct].GetComponent<Запрещён>())
                    {
                        txt.text = Map_saver.t3[CurrentProduct].name + " Const : " + ((Map_saver.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 101.5f  * (float)(Globalprefs.GetProcentInflitiuon() + 1)) / (float)shorta ) ;
                    }
                    if (Map_saver.t3[CurrentProduct].GetComponent<itemName>().ItemInfinitysPrise)
                    {
                        txt.text = Map_saver.t3[CurrentProduct].name + " Const : ∞ * " + (Map_saver.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 1.5f * (float)(Globalprefs.GetProcentInflitiuon() + 1)) / (float)shorta ;
                    }
                }
            }
            if (Directory.Exists("debug"))
            {
               
                 
                        txt.text = Map_saver.t3[CurrentProduct].name + " Const : Халява";
                   
            }
            if (Map_saver.t3[CurrentProduct].name == "AllAnyphingItems")
            {
                txt2.text = "если ты это купишь ты буквально сломаешь сохранения игры удачи";
                txt2.color = Color.red;
            }
            if (Map_saver.t3[CurrentProduct].name != "AllAnyphingItems")
            {
                txt2.text = "";
                txt2.color = Color.black;
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
                Globalprefs.LoadTevroPrise(stocks * (decimal)stocknew * shorta);
                VarSave.LoadMoney("Stocks", -VarSave.GetMoney("StocksUMU", 0));
                VarSave.SetMoney("StocksUMU", 0); if (VarSave.GetFloat(
             "Creative" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
            }
           if (CurrentStock == 1)
            {
                decimal stocks = VarSave.GetMoney("StocksCrinjeGame", 0);
                Globalprefs.LoadTevroPrise(stocks * (decimal)stocknew * shorta);
                VarSave.LoadMoney("Stocks", -VarSave.GetMoney("StocksCrinjeGame", 0));
                VarSave.SetMoney("StocksCrinjeGame", 0); if (VarSave.GetFloat(
             "Creative" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
            }
           if (CurrentStock == 2)
            {
                decimal stocks = VarSave.GetMoney("StocksDupCorporated", 0);
                Globalprefs.LoadTevroPrise(stocks * (decimal)stocknew * shorta);
                VarSave.LoadMoney("Stocks", -VarSave.GetMoney("StocksDupCorporated", 0));
                VarSave.SetMoney("StocksDupCorporated", 0); if (VarSave.GetFloat(
             "Creative" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
            }
           if (CurrentStock == 3)
            {
                decimal stocks = VarSave.GetMoney("StocksCeribrals", 0);
                Globalprefs.LoadTevroPrise(stocks * (decimal)stocknew * shorta);
                VarSave.LoadMoney("Stocks", -VarSave.GetMoney("StocksCeribrals", 0));
                VarSave.SetMoney("StocksCeribrals", 0); if (VarSave.GetFloat(
             "Creative" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
            }
            if (CurrentStock == 4)
            {
                decimal stocks = VarSave.GetMoney("StocksMiniHome", 0);
                Globalprefs.LoadTevroPrise(stocks * (decimal)stocknew * shorta);
                VarSave.LoadMoney("Stocks", -VarSave.GetMoney("StocksMiniHome", 0));
                VarSave.SetMoney("StocksMiniHome", 0); if (VarSave.GetFloat(
             "Creative" + "_gameSettings", SaveType.global) >= .1f)
                {
                    VarSave.LoadFloat("reason", 1);
                }
            }

        }
        if (operations == ComputerOperations.Porducts)
        {
            if (!Directory.Exists("debug"))
            {
                if (Globalprefs.LoadTevroPrise(0) >= (decimal)(Map_saver.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 1.5f * (float)(Globalprefs.GetProcentInflitiuon() + 1)))
                {
                    if (VarSave.ExistenceVar("researchs/" + Map_saver.t3[CurrentProduct].name))
                    {
                        if (!Map_saver.t3[CurrentProduct].GetComponent<itemName>().ItemInfinitysPrise)
                        {
                            if (!Map_saver.t3[CurrentProduct].GetComponent<Запрещён>())
                            {
                                Globalprefs.LoadTevroPrise(-(decimal)(Map_saver.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 1.5f * (float)(Globalprefs.GetProcentInflitiuon() + 1)) / shorta);
                                Instantiate(Map_saver.t3[CurrentProduct], mover.main().transform.position, Quaternion.identity);
                                if (VarSave.GetFloat(
             "Creative" + "_gameSettings", SaveType.global) >= .1f)
                                {
                                    VarSave.LoadFloat("reason", 1);
                                }
                            }
                            if (Map_saver.t3[CurrentProduct].GetComponent<Запрещён>())
                            {
                                Globalprefs.LoadTevroPrise(-(decimal)(Map_saver.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 101.5f * (float)(Globalprefs.GetProcentInflitiuon() + 1)) / shorta);
                                Instantiate(Map_saver.t3[CurrentProduct], mover.main().transform.position, Quaternion.identity); if (VarSave.GetFloat(
             "Creative" + "_gameSettings", SaveType.global) >= .1f)
                                {
                                    VarSave.LoadFloat("reason", 1);
                                }
                            }
                        }
                    }
                }
                if (VarSave.LoadTrash("inftevro", 0) >= (double)(Map_saver.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 1.5f * (double)(Globalprefs.GetProcentInflitiuon() + 1)) / (double)shorta)
                {
                    if (VarSave.ExistenceVar("researchs/" + Map_saver.t3[CurrentProduct].name))
                    {

                        if (Map_saver.t3[CurrentProduct].GetComponent<itemName>().ItemInfinitysPrise)
                        {
                            VarSave.LoadTrash("inftevro", -(double)(Map_saver.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 1.5f * (double)(Globalprefs.GetProcentInflitiuon() + 1)) / (double)shorta);
                            Instantiate(Map_saver.t3[CurrentProduct], mover.main().transform.position, Quaternion.identity);
                            Globalprefs.Infinitysteuvro = VarSave.LoadTrash("inftevro", 0); if (VarSave.GetFloat(
             "Creative" + "_gameSettings", SaveType.global) >= .1f)
                            {
                                VarSave.LoadFloat("reason", 1);
                            }
                        }
                    }
                }
            }
            if (Directory.Exists("debug"))
            {
                Instantiate(Map_saver.t3[CurrentProduct], mover.main().transform.position, Quaternion.identity);
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
                            if (!item.GetComponent<Logic_tag_UnDeleteing>()) item.gameObject.AddComponent<DELETE>();
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
                decimal prise =0;
                foreach (itemName item in FindObjectsByType<itemName>(sortmode.main))
                {
                    foreach (GameObject classitem in Map_saver.t3)
                    {
                        if (item._Name == classitem.GetComponent<itemName>()._Name)
                        {

                                   prise += (decimal)item.ItemPrise;
                            if (!item.GetComponent<Logic_tag_UnDeleteing>()) item.gameObject.AddComponent<DELETE>();
                          
                        }
                    }
                }
               
                if (prise > 0) { if (Globalprefs.LoadTevroPrise(0) < decimal.MaxValue - prise) Globalprefs.LoadTevroPrise(prise * shorta); }
                else if(Globalprefs.LoadTevroPrise(0) > decimal.MinValue - prise)Globalprefs. LoadTevroPrise( prise * shorta);

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
            if (Map_saver.t3.Length - 1 > CurrentProduct)
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
                CurrentProduct = Map_saver.t3.Length - 1;
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
