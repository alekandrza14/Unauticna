using UnityEngine;

public class GateRight : MonoBehaviour
{
    void Start()
    {
        if (PolitDate.IsVersionE() == politiceconomic.overright)
        {
            gameObject.SetActive(false);
        }
    }
}
