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
        Bread1.text = "Произведи 6 хлеба в день для камунистов "+ Bread + " \\ 6 хлеба камунизировано";
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
        if (Bread > 5)
        {
            VarSave.SetInt("LastPrisved6BreadData", System.DateTime.Now.DayOfYear);
            Destroy(gameObject);
        }
        if (VarSave.GetInt("LastPrisved6BreadData") < System.DateTime.Now.DayOfYear-1)
        {
            VarSave.SetMoney("OwerFlow", 0);
            VarSave.SetMoney("CashFlow", 0);
            VarSave.SetMoney("Inflation", 0, SaveType.global);
            VarSave.SetMoney("tevro", 0);

            VarSave.SetInt("LastPrisved6BreadData", System.DateTime.Now.DayOfYear - 1);
        }
    }
}
