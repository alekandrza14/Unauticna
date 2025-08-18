using UnityEngine;
using UnityEngine.UI;

public class КамуИнтерфейсХлеба : MonoBehaviour
{
    public GameObject prefab;
    public Text Bread1;
    public Text Bread2;
    int Bread;
    void Update()
    {
        bool cansetator = (PolitDate.IsVersionF(politicfreedom.avtoritatian) && PolitDate.IsVersionE(politiceconomic.right));
        bool anarhist = (PolitDate.IsVersionF(politicfreedom.lidertatian) && PolitDate.IsVersionE(politiceconomic.mind));
        if (!cansetator && !anarhist)
        {
            Bread1.text = "Произведи 6 хлеба в день для камунистов " + Bread + " \\ 6 хлеба камунизировано";
            Bread2.text = "Произведи 6 хлеба в день для камунистов " + Bread + " \\ 6 хлеба камунизировано";
        }
        if (cansetator || anarhist)
        {
            Bread1.text = "Произведи 6 хлеба в день для камунистов " + Bread + " \\ 6 хлеба камунизировано" + " отказаться M";
            Bread2.text = "Произведи 6 хлеба в день для камунистов " + Bread + " \\ 6 хлеба камунизировано" + " отказаться M";
        }
        RaycastHit hit = MainRay.MainHit;
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (hit.collider.GetComponent<itemName>()._Name == "Хлеб")
            {
                Bread++;
                Instantiate(prefab, hit.collider.transform.position, Quaternion.identity);
                Destroy(hit.collider.gameObject);
            } 
        }
        if (cansetator || anarhist)
        {
            if (Input.GetKeyDown(KeyCode.M)) Bread = 6;
        }
        if (Bread > 5)
        {
            VarSave.SetInt("LastPrisved6BreadData", DatePlus.dayOfEra());
            Destroy(gameObject);
        }
        if (VarSave.GetInt("LastPrisved6BreadData") < DatePlus.dayOfEra() - 1)
        {
            VarSave.SetMoney("OwerFlow", 0);
            VarSave.SetMoney("CashFlow", 0);
            VarSave.SetMoney("Inflation", 0, SaveType.global);
            VarSave.SetMoney("tevro", 0);

            VarSave.SetInt("LastPrisved6BreadData", DatePlus.dayOfEra() - 1);
        }
    }
}
