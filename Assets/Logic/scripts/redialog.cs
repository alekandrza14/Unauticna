using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class redialog : MonoBehaviour
{
    public deldialog dialog;
    public string[] s;
    public string sm;
    public string[] se;
    public string sme; 
    public string[] su;
    public string smu;
    public string text;
    public string bol;
    public bool iznendial;
    
    // Start is called before the first frame update
    void Start()
    {
       
        if (VarSave.ExistenceVar(bol) && !iznendial)
        {
            dialog.s = s;
            dialog.sm = sm;
            dialog.se = se;
            dialog.sme = sme;
            dialog.se = su;
            dialog.sme = smu;
            dialog.text.text = text;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (VarSave.ExistenceVar(bol) && iznendial)
        {
            dialog.s = s;
            dialog.sm = sm;
	  dialog.se = se;
            dialog.sme = sme;
            dialog.text.text = text;
            dialog.se = su;
            dialog.sme = smu;
            VarSave.DeleteKey(bol);
        }
    }
}
