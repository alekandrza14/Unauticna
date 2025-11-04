using UnityEngine;

public class FemBreackOrganizm : MonoBehaviour
{
    public GameObject active;
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider.gameObject == gameObject)
        {
            if (Kisy.Hp >= 100 - Pill.femaliting) 
            {
                active.SetActive(true);
                Invoke("off", 1);
            }
        }
    }
    void off()
    {
        active.SetActive(false);
    }
}
