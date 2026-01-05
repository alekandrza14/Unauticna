using UnityEngine;

[AddComponentMenu("Physics/InfTubeCollider")]
public class InfTubeCollider : MonoBehaviour
{

    [SerializeField] Transform tragetObject;
    void Start()
    {
        
    }

    void Update()
    {
        Transform player = mover.main().transform;
        float x = player.position.x;
        if (tragetObject.position.x > x)
        {
            x = tragetObject.position.x;
        }
        transform.position = new Vector3(x, tragetObject.position.y, tragetObject.position.z);
    }
}
