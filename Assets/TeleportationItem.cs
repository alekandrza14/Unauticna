using UnityEngine;

public class TeleportationItem : MonoBehaviour
{
    void Update()
    {
        FindFirstObjectByType<itemName>().transform.position = transform.position;
    }
}
