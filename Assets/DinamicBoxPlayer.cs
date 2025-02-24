using UnityEngine;

public class DinamicBoxPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<mover>()) other.transform.SetParent(transform);
        if (other.GetComponent<CustomSaveObject>()) other.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<mover>()) other.transform.SetParent(new GameObject("none").transform);
        if (other.GetComponent<CustomSaveObject>()) other.transform.SetParent(new GameObject("none").transform);
    }
}
