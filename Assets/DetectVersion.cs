using UnityEngine;
using UnityEngine.UI;

public class DetectVersion : MonoBehaviour
{
    void Start()
    {
        if (PolitDate.IsVersion() == politicfreedom.avtoritatian) GetComponent<Text>().text = "Autoritarian Version";
        if (PolitDate.IsVersion() == politicfreedom.democratian) GetComponent<Text>().text = "Democratian Version";
        if (PolitDate.IsVersion() == politicfreedom.lidertatian) GetComponent<Text>().text = "Libertatian Version";
        if (PolitDate.IsVersion() == politicfreedom.centrarian) GetComponent<Text>().text = "Centerian Version";
        if (PolitDate.IsVersion() == politicfreedom.NonPositionalian) GetComponent<Text>().text = "_non-positionalian Version";
    }
}
