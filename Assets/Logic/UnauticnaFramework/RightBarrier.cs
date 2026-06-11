using UnityEngine;

public class RightBarrier : MonoBehaviour
{
    void Start()
    {
       if(PolitDate.IsVersionE() != politiceconomic.bipoly) if (PolitDate.IsVersionE() != politiceconomic.right) if (PolitDate.IsVersionE() != politiceconomic.overright)
                {
            gameObject.SetActive(false);
        }
    }
}
