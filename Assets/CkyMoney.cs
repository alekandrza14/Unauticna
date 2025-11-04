using System.Data;
using UnityEngine;

public class CkyMoney : MonoBehaviour
{
    void Start()
    {
        VarSave.SetFloat("руб", 1000, SaveType.computer);
        VarSave.DeleteKey("Свадьба");
    }
}
