using UnityEngine;

public class TransformRotationFromCameraRotation : MonoBehaviour
{
    void Update()
    {
        transform.rotation = mover.main().transform.rotation;
    }
}
