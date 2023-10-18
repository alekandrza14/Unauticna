using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockSold : MonoBehaviour
{
    [SerializeField] MobileComputer mobileComputer;
    public void OpenSocksMarket()
    {
        mobileComputer.StockMarket();
    }
}
