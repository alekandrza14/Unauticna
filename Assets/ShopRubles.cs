using System.Diagnostics;
using UnityEditor.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopRubles : MonoBehaviour
{
    public Text ShopName;
    public Text HelpName;
    public float rubles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rubles = VarSave.GetFloat("руб", SaveType.computer);
        ShopName.text = "Баланс " + rubles + " р";
        Process[] processes = Process.GetProcessesByName("MinerRubles");
        if (processes.Length > 0)
        {

            HelpName.color = Color.red;
        }
        else
        {

            HelpName.color = Color.white;
        }
        
    }
  
    public void Teuro()
{
        if (UpdateRubles(2))
        {
            Globalprefs.LoadTevroPrise(100);
        }
    }
    public void BiginTagetBrak()
    {
        if (VarSave.GetFloat("руб", SaveType.computer)>0.0) 
        {
            SceneManager.LoadScene("SeXHome");
        }
    }
    // Update is called once per frame
    bool UpdateRubles(float rub)
    {
        Process[] processes = Process.GetProcessesByName("MinerRubles");
        if (processes.Length > 0)
        {

            return false;
        }
        else
        {
            rubles -= rub;
            ShopName.text = "Баланс " + rubles + " р";
            VarSave.SetFloat("руб", rubles, SaveType.computer);
            return true;
        }
    }
}
