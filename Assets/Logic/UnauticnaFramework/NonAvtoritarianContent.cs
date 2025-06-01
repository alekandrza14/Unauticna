using UnityEngine;

public class NonAvtoritarianContent : MonoBehaviour
{
    void Start()
    {
        if(PolitDate.IsGood(politicfreedom.avtoritatian))
        {
            gameObject.SetActive(false);
        }
    }
}
