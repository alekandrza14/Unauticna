using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultyverseManager : MonoBehaviour
{
    private void Start()
    {
        int i = 0;
        foreach (PolarHyperbolicPoint g in FindObjectsByType<PolarHyperbolicPoint>(sortmode.main))
        {
            float MuLtyverseCont = (float)(VarSave.GetMoney("MultyverseX")*2 + VarSave.GetMoney("MultyverseY")*3 + VarSave.GetMoney("MultyverseZ")*4 + VarSave.GetMoney("MultyverseW")*5);
            i++;
            if (g.tag == "Star" && MuLtyverseCont != 0f)
            {
                g.HyperboilcPoistion.s = Globalprefs.Hash(new Vector2((float)(MuLtyverseCont) * i*2, -
                    (float)(MuLtyverseCont) * i*9)) * 4;
                g.HyperboilcPoistion.n = Globalprefs.Hash(new Vector2((float)(MuLtyverseCont ) * i*4, -
                    (float)(MuLtyverseCont) * i*2)) * 6;
                g.transform.position = Vector3.up * Globalprefs.Hash(new Vector2((float)(MuLtyverseCont ) * i*2, -
                    (float)(MuLtyverseCont ) * i*8))*20;
              //  g.HyperboilcPoistion.m = Globalprefs.Hash(new Vector2((float)(VarSave.GetMoney("MultyverseX") + VarSave.GetMoney("MultyverseY") + VarSave.GetMoney("MultyverseZ") + VarSave.GetMoney("MultyverseW") + i), i)) * 5;
            }
        }
    }
    private void OnGUI()
    {
        GUILayout.Label("X : " + VarSave.GetMoney("MultyverseX") + " Y : " + VarSave.GetMoney("MultyverseY") + " Z : " + VarSave.GetMoney("MultyverseZ") + " W : " +0);
    }
}
