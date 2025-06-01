using System.Collections.Generic;
using UnityEngine;

public enum Formation
{
    right,
    left
}

public class FormationSwap : MonoBehaviour
{
    public Formation formation;
    
    void Update()
    {
        if (formation == Formation.left)
        {
            VarSave.SetMoney("tevro",1000);
            VarSave.SetTrash("MOMU", 0);
            playerdata.hasClearEffect("Unyverseium_money_cart");
            playerdata.hasClearEffect("No kapitalism");
            LigtherMonolitLevel1[] monolits = FindObjectsByType<LigtherMonolitLevel1>(sortmode.main);
            GameObject teranMonolit = Resources.Load<GameObject>("items/ТерраныйМонолит(1)");
            if (monolits.Length > 0)
            {
                foreach (LigtherMonolitLevel1 item in monolits)
                {
                    Instantiate(teranMonolit, item.transform.position, item.transform.rotation);
                    item.gameObject.AddComponent<DELETE>();
                }
            }
            if (cistalenemy.dies<-100)
            {
                cistalenemy.dies = 10000;
            }
            Globalprefs.flowteuvro = -20;
            Globalprefs.OverFlowteuvro = 0;
            VarSave.SetMoney("CashFlow", -20);
            VarSave.SetMoney("OverFlow", 0);
          if(SpawnRadeBonus.m_SpawnRadeBonusList.Count==0)  SpawnRadeBonus.m_SpawnRadeBonusList = new List<SpawnRadeBonus>() { new SpawnRadeBonus() };
        }
    }
}
