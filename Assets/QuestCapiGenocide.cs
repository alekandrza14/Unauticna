using UnityEngine;
using UnityEngine.UI;

public class QuestCapiGenocide : MonoBehaviour
{
    
    void Update()
    {
        GetComponent<Text>().text = VarSave.GetInt("CapiKill")+"\\20";
        if (VarSave.GetInt("CapiKill")>=20)
        {
            VarSave.DeleteKey("CapiKill");
        }
    }
}
