using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


public class ComputerSave : MonoBehaviour
{

    [SerializeField] itemName itemName;
    public ItemsInfo itemsinfo = new ItemsInfo();
    [SerializeField] Text itemView;
    public Acaunt aka;
    public string acauntdata;
    public bool iteractive { get; private set; }
    private void Start()
    {
        acauntdata = GetComponent<itemName>().ItemData;

        if (string.IsNullOrEmpty(acauntdata))
        {
            if (complsave.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());

                acauntdata = aka.fullUserName + "√" + aka.loign.text + "√" + aka.ct.text + "√" + JsonUtility.ToJson(itemsinfo) + "√" + aka.Private;
                GetComponent<itemName>().ItemData = acauntdata;
            }
        }
        SetVaules();
    }

    private void SetVaules()
    {
        aka.fullUserName = acauntdata.Split('√')[0];
        aka.loign.text = acauntdata.Split('√')[1];
        aka.ct.text = acauntdata.Split('√')[2]; itemsinfo = new ItemsInfo();
        int pageNum = acauntdata.Split('√').Length;
        if (pageNum > 3) if (!string.IsNullOrEmpty(acauntdata.Split('√')[3])) { itemsinfo = JsonUtility.FromJson<ItemsInfo>(acauntdata.Split('√')[3]); } else itemsinfo = new ItemsInfo();
        if (pageNum > 4) if (!string.IsNullOrEmpty(acauntdata.Split('√')[4])) { aka.Private = acauntdata.Split('√')[4]; }
        aka.UpdateAcaunt();
    }

    public void Load1()
    {
        if (GetComponent<itemName>())
        {

            acauntdata = GetComponent<itemName>().ItemData;
            if (string.IsNullOrEmpty(acauntdata))
            {
                if (complsave.LoadADone)
                {
                    // time = JsonUtility.ToJson(Random.ColorHSV());

                    acauntdata = aka.fullUserName + "√" + aka.loign.text + "√" + aka.ct.text + "√" + JsonUtility.ToJson(itemsinfo) + "√" + aka.Private;
                    GetComponent<itemName>().ItemData = acauntdata;
                }
            }
        }

        SetVaules();

    }
    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;
      if(other.GetComponent<itemName>())  if (other.GetComponent<itemName>()._Name=="GPU")
        {
            Globalprefs.flowteuvro += 0.1m;

            VarSave.SetMoney("CashFlow", Globalprefs.flowteuvro);
            Destroy(other.gameObject); 
        }
    }
    
    private void Update()
    {
      if(!string.IsNullOrEmpty(aka.Private)&&!aka.PrivateOn)  aka.UpdateAcaunt();
        if (itemsinfo==null)
        {
            itemsinfo = new ItemsInfo();
        }
        iteractive = !string.IsNullOrEmpty(aka.fullUserName);
        acauntdata = aka.fullUserName + "√" + aka.loign.text + "√" + aka.ct.text + "√" + JsonUtility.ToJson(itemsinfo)+"√"+aka.Private;
        GetComponent<itemName>().ItemData = acauntdata;
        if (itemsinfo.namesitem.Count > 0) itemView.text = "Late Object : " + itemsinfo.namesitem[itemsinfo.namesitem.Count - 1];
        if (itemsinfo.namesitem.Count <= 0) itemView.text = "Late Object : None";


    }
}
