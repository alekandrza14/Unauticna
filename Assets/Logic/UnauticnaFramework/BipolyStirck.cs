using UnityEngine;

public class BipolyStirck : MonoBehaviour
{
    void Start()
    {
        if (PolitDate.IsVersionE() != politiceconomic.bipoly)
        {
            gameObject.SetActive(false);
        }
    }
}
