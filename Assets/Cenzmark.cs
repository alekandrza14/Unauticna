using UnityEngine;
using UnityEngine.UI;

public class Cenzmark : MonoBehaviour
{
    public Toggle cenzMark;
    public GameObject cenzPrefab;
    void Update()
    {
        if(cenzMark.isOn)
        {
            cenzPrefab.SetActive(true);
        }
        else
        {
            cenzPrefab.SetActive(false);
        }
    }
}
