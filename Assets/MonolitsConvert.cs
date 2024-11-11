using UnityEngine;

public class MonolitsConvert : MonoBehaviour
{
    
    void Update()
    {
        LigtherMonolitLevel1[] monolits = FindObjectsByType<LigtherMonolitLevel1>(sortmode.main);
        GameObject teranMonolit = Resources.Load<GameObject>("items/ТерраныйМонолит(1)");
        if (monolits.Length > 0)
        {
            foreach (LigtherMonolitLevel1 item in monolits)
            {
                Instantiate(teranMonolit, item.transform.position, item.transform.rotation);
                item.gameObject.AddComponent<DELETE>();
            }
        }
    }
}
