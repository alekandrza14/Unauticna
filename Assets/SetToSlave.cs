using UnityEngine;

public class SetToSlave : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CustomObject>()) if (other.gameObject.GetComponent<Slave>() == null) other.gameObject.AddComponent<Slave>(); 
        if (other.gameObject.GetComponent<itemName>()) if (other.gameObject.GetComponent<Slave>() == null) other.gameObject.AddComponent<Slave>();
        if (other.gameObject.GetComponent<telo>()) if (other.gameObject.GetComponent<Slave>() == null) other.gameObject.AddComponent<Slave>();
    }
}
