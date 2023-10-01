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
    Nophing,Clearing, FireDepartment
}
public class MobileComputer : MonoBehaviour
{
    [SerializeField] RawImage Screen;
    [SerializeField] Texture[] sprites;
    [SerializeField] Text txt;
    [SerializeField] itemName[] ClearItems;
    float stockold;
    float stocknew;
    int CurrentProduct;
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
        txt.text = complsave.t3[CurrentProduct].name + " Const : " + (complsave.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 1.5f);

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

            stocknew = stockConst();
            stockold = oldstockConst();
            if (stockold > stocknew)
            {

                Screen.texture = sprites[1];
            }
            if (stockold < stocknew)
            {

                Screen.texture = sprites[0];
            }
            txt.text = "UMU Const" + Math.Round((decimal)stockConst(), 2);
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
                txt.text = complsave.t3[CurrentProduct].name + " Const : " + (complsave.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 1.5f);
            }

            Screen.texture = sprites[2];
        }
       
    }
    public void Return()
    {
        if (operations == ComputerOperations.Stocks)
        {
            decimal stocks = VarSave.GetMoney("Stocks", 0);
                VarSave.LoadMoney("tevro", stocks * (decimal)stocknew);
                VarSave.SetMoney("Stocks", 0);
            
        }
        if (operations == ComputerOperations.Porducts)
        {
            if (VarSave.LoadMoney("tevro", 0) >= (decimal)(complsave.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 1.5f))
            {
                if (VarSave.ExistenceVar("researchs/" + complsave.t3[CurrentProduct].name))
                {
                    VarSave.LoadMoney("tevro", -(decimal)(complsave.t3[CurrentProduct].GetComponent<itemName>().ItemPrise * 1.5f));
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
        }
    }
    public void Next()
    {
        if (operations == ComputerOperations.Servers)
        {
            int serversIndex = (int)servers;
            if (3 - 1 > serversIndex)
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
                serversIndex = 3-1;
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
    }
}
