using UnityEngine;

public class ActiveGaster : MonoBehaviour
{
    public GameObject chell;
    public void Gas()
    {
        chell.SetActive(true);
    }
}
