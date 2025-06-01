using UnityEngine;

public class EnemyeAnarhoKamuPolitic : MonoBehaviour
{
    void Start()
    {
        if ((PolitDate.IsVersionF(politicfreedom.lidertatian) && PolitDate.IsVersionE(politiceconomic.right))) Invoke("Timeout",30);
    }
    public void Timeout()
    {
        Destroy(gameObject);
    }
}
