using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mining : MonoBehaviour
{
    private void Start()
    {
        VarSave.SetFloat("timeminingdays", System.DateTime.Now.Date.DayOfYear);
        VarSave.SetFloat("timeminingyear", System.DateTime.Now.Date.Year);
        if (!VarSave.ExistenceVar("timeminingyear1"))
        {
            VarSave.SetFloat("timeminingyear1", System.DateTime.Now.Date.Year);
        }
        if (!VarSave.ExistenceVar("timeminingdays1"))
        {
            VarSave.SetFloat("timeminingdays1", System.DateTime.Now.Date.DayOfYear);
        }
        if (VarSave.GetFloat("timeminingyear") <= VarSave.GetFloat("timeminingyear1"))
        {
            if (VarSave.GetFloat("timeminingdays") > VarSave.GetFloat("timeminingdays1"))
            {
                Pluss();
                VarSave.SetFloat("timeminingdays1", System.DateTime.Now.Date.DayOfYear);

            }
        }
        if (VarSave.GetFloat("timeminingyear") > VarSave.GetFloat("timeminingyear1"))
        {
            Pluss1();
            VarSave.SetFloat("timeminingyear1", System.DateTime.Now.Date.Year);
        }

    }
    void Pluss()
    {
        int i = Mathf.FloorToInt(VarSave.GetFloat("timeminingdays") - VarSave.GetFloat("timeminingdays1")) *20;
        int i2 = i;
        Globalprefs.LoadTevroPrise(+ i2);
    }
    void Pluss1()
    {
        Globalprefs.LoadTevroPrise(+ 7300);
    }
}
