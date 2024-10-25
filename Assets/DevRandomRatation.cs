using UnityEngine;

[ExecuteAlways]
public class DevRandomRatation : MonoBehaviour
{
    
    void Start()
    {
        
        transform.rotation = Random.rotation;
        Destroy(this);
    }
}
