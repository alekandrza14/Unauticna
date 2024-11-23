using UnityEngine;

public class HBOctopusTintacle : MonoBehaviour
{
    private void OnDestroy()
    {
        HyperbolicOctopusBoss.HP -= 1;
    }
}
