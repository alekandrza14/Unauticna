using TMPro;
using UnityEngine;

public class Itendifikator : MonoBehaviour
{
    [SerializeField] TextMeshPro txt;
    public string mamov;
    public string papov;
    void Update()
    {
        txt.text = mamov + " + " + VarSave.GetInt(papov);
    }
}
