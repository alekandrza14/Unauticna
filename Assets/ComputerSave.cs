using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;


public class ComputerSave : MonoBehaviour
{

    [SerializeField] itemName itemName;
    public ItemsInfo itemsinfo = new();
    [SerializeField] Text itemView;
    public Acaunt aka;
    public string Acaunt_data;
    public bool SigIn{ get; private set; }
    private void Start()
    {
        Acaunt_data = GetComponent<itemName>().ItemData;

        if (string.IsNullOrEmpty(Acaunt_data))
        {
            if (Map_saver.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());

                Acaunt_data = aka.fullUserName + "√" + aka.loign.text + "√" + aka.ct.text + "√" + JsonUtility.ToJson(itemsinfo) + "√" + aka.Private;
                GetComponent<itemName>().ItemData = Acaunt_data;
            }
        }
        SetVaules();
    }

    private void SetVaules()
    {
        aka.fullUserName = Acaunt_data.Split('√')[0];
        aka.loign.text = Acaunt_data.Split('√')[1];
        aka.ct.text = Acaunt_data.Split('√')[2]; itemsinfo = new();
        int pageNum = Acaunt_data.Split('√').Length;
        if (pageNum > 3) if (!string.IsNullOrEmpty(Acaunt_data.Split('√')[3])) { itemsinfo = JsonUtility.FromJson<ItemsInfo>(Acaunt_data.Split('√')[3]); } else itemsinfo = new();
        if (pageNum > 4) if (!string.IsNullOrEmpty(Acaunt_data.Split('√')[4])) { aka.Private = Acaunt_data.Split('√')[4]; }
        aka.UpdateAcaunt();
    }

    public void Load1()
    {
        if (GetComponent<itemName>())
        {

            Acaunt_data = GetComponent<itemName>().ItemData;
            if (string.IsNullOrEmpty(Acaunt_data))
            {
                if (Map_saver.LoadADone)
                {
                    // time = JsonUtility.ToJson(Random.ColorHSV());

                    Acaunt_data = aka.fullUserName + "√" + aka.loign.text + "√" + aka.ct.text + "√" + JsonUtility.ToJson(itemsinfo) + "√" + aka.Private;
                    GetComponent<itemName>().ItemData = Acaunt_data;
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
        itemsinfo ??= new();
        SigIn = !string.IsNullOrEmpty(aka.fullUserName);
        Acaunt_data = aka.fullUserName + "√" + aka.loign.text + "√" + aka.ct.text + "√" + JsonUtility.ToJson(itemsinfo)+"√"+aka.Private;
        GetComponent<itemName>().ItemData = Acaunt_data;
        if (itemsinfo.namesitem.Count > 0) itemView.text = "Late Object : " + itemsinfo.namesitem[^1];
        if (itemsinfo.namesitem.Count <= 0) itemView.text = "Late Object : None";


    }
}
