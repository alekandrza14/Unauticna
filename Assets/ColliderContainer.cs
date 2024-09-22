using System.Collections.Generic;
using UnityEngine;

public class ColliderContainer : MonoBehaviour
{
    public List<GameObject> obj = new();
    private void OnTriggerEnter(Collider other)
    {
        if (!obj.Contains(other.gameObject))
        {
            obj.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (obj.Contains(other.gameObject))
        {
            obj.Remove(other.gameObject);
        }
    }
    void Update()
    {
        if (obj.Contains(null))
        {
            obj.Remove(null);
        }
    }
}
