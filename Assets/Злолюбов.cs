using UnityEngine;
using UnityEngine.UI;

public class Злолюбов : MonoBehaviour
{
    public Text Интерфейс;
    public Text Еда;
    public telo сущ;
    //Зло-<color=red>0000000000</color><color=green>8888888888</color>-Любовь
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float carma = (((float)сущ.agry+1) / ((float)сущ.social+1))*20f;
        float carma2 = (((float)сущ.love+1) / ((float)сущ.social+1)) * 20f;
        string lovetext = "";
        string agrytext = "";
        for (int i = 0; i < carma; i++)
        {
            agrytext += "0";
        }
        for (int i = 0; i < carma2; i++)
        {

            lovetext += "8";
        }
        Еда.text = сущ.grass.ToString();
        Интерфейс.text = "Зло-<color=red>" + agrytext + "</color><color=green>"+ lovetext + "</color>-Любовь";
    }
}
