using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductsBye : MonoBehaviour
{
    [SerializeField] MobileComputer mobileComputer;
    public void OpenShopMultinet()
    {
        mobileComputer.MultinetShop();
    }
}

