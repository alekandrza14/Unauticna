using UnityEngine;

public class CumRain : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("AddCumen", 5, 30);
    }
    public void AddCumen()
    {
        GameObject g = Resources.Load<GameObject>("Items/������������_������");
        Instantiate(g, mover.main().transform.position + (Vector3.up * 30), Quaternion.identity);
        if (Global.Random.Chance(8))
        {
            GameObject g2 = Resources.Load<GameObject>("Items/spamton��������");
            Instantiate(g2, mover.main().transform.position + (Vector3.up * 3), Quaternion.identity);
        }
    }
}
