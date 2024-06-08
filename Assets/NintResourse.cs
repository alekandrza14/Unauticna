using Global;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NintResourse : InventoryEvent
{
    public Text text;
    public Nint res;
    public Nint res2;
    public Nint Max;
    public bool svich;
    public void Load1()
    {

    if(VarSave.ExistenceVar("overdoh"+Map_saver.ObjectSaveManager.lif))    res.Num(VarSave.GetString("overdoh" + Map_saver.ObjectSaveManager.lif));
        if (!VarSave.ExistenceVar("YourPlanet" + Map_saver.ObjectSaveManager.lif))
        {
            text.text = res.StrDeco(res) + " / " + Max.StrDeco(Max);
            if (res.bytes.Length > 201) text.text += " + + + ";
        }
    }
    void Update()
    {
        if (!VarSave.ExistenceVar("YourPlanet" + Map_saver.ObjectSaveManager.lif))
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                VarSave.SetString("overdoh" + Map_saver.ObjectSaveManager.lif, res.Str(res));
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                if (VarSave.ExistenceVar("overdoh" + Map_saver.ObjectSaveManager.lif)) res.Num(VarSave.GetString("overdoh" + Map_saver.ObjectSaveManager.lif));
                text.text = res.StrDeco(res) + " / " + Max.StrDeco(Max);
                if (res.bytes.Length > 201) text.text += " + + + ";
            }
        }

    }
    public void EndMake()
    {

        VarSave.SetString("YourPlanet" + Map_saver.ObjectSaveManager.lif, "1");
        text.text = null;
    }
    public void Eatlicense()
    {
        if (!VarSave.ExistenceVar("YourPlanet" + Map_saver.ObjectSaveManager.lif))
        {
            // if (!svich)
            res.Mult(res, -200);
            // if (svich) res.Move(res, res2);
            //   res.Move(res, res2);
            //   text.text = res.StrDeco(res);// + " / " + Max.StrDeco(Max);
            if (!res.negative)
            {
                if (res.bytes.Length >= 200 && res.bytes.Length < 201)
                {
                    if (res.bytes[0] > 70)
                    {
                        text.text = res.StrDeco(res) + " / " + Max.StrDeco(Max) + " + + + ";
                    }
                    else
                    {
                        text.text = res.StrDeco(res) + " / " + Max.StrDeco(Max);
                    }
                }
                else if (res.bytes.Length > 201)
                {

                    text.text = res.StrDeco(res) + " / " + Max.StrDeco(Max) + " + + + ";
                }
                else
                {
                    text.text = res.StrDeco(res) + " / " + Max.StrDeco(Max);
                }
            }
            else
            {
                text.text = res.StrDeco(res) + " / " + Max.StrDeco(Max);
            }
        }
    }
}
