using UnityEngine;
using UnityEngine.UI;

public class Hal : InventoryEvent
{

    [SerializeField] public bool halActived;

    public Text Халароний;
    public GeneratorEnergyData energyData = new GeneratorEnergyData();



    private void Start()
    {
        halActived = bool.Parse(GetComponent<itemName>().ItemData);

        if (string.IsNullOrEmpty(halActived.ToString()))
        {
            if (Map_saver.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
                GetComponent<itemName>().ItemData = halActived.ToString();
            }
        }

    }
    public void Load1()
    {
        halActived = bool.Parse(GetComponent<itemName>().ItemData);

        if (string.IsNullOrEmpty(halActived.ToString()))
        {
            if (Map_saver.LoadADone)
            {
                // time = JsonUtility.ToJson(Random.ColorHSV());
                GetComponent<itemName>().ItemData = halActived.ToString();
            }

        }
    }
    void Update()
    {
     
        if (halActived)
        {
            GetComponent<itemName>().ItemPrise = 100;
            Халароний.text = "Активирован!";
        }
        else
        {
            GetComponent<itemName>().ItemPrise = 10;
            Халароний.text = "Не активирован!";
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

}
