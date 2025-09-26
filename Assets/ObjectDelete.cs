using UnityEngine;
using UnityEngine.UI;

public class ObjectDelete : MonoBehaviour
{
    public GameObject Object2;
    public Text objname;
    public void deleting()
    {
        Object2.gameObject.AddComponent<DELETE>();
        gameObject.AddComponent<DELETE>();
    }
}
