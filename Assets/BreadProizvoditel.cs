using UnityEngine;
using UnityEngine.UI;

public class BreadProizvoditel : MonoBehaviour
{
    public GameObject itemTraget;
    public GameObject itemPrefab;
    int numklic;
    public Text ClickCounter;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit = MainRay.MainHit;
            if (hit.collider.gameObject == gameObject)
            {
                numklic++;
                ClickCounter.text = "Хлеб Клики : " + numklic + " / 5";
                if (numklic > 4)
                {
                    Instantiate(itemPrefab, itemTraget.transform);
                    numklic = 0;
                }
            }
        }
    }
}
