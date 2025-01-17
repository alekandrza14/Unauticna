using UnityEngine;

public class NonLibertatianContent : MonoBehaviour
{
    void Start()
    {
        if (PolitDate.IsGood(politicfreedom.lidertatian))
        {
            gameObject.SetActive(false);
        }
    }
}
