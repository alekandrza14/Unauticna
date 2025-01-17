using UnityEngine;

public class PositionalContent : MonoBehaviour
{
    void Start()
    {
        if (PolitDate.IsGood(politicfreedom.NonPositionalian))
        {
            gameObject.SetActive(false);
        }    
    }
}
