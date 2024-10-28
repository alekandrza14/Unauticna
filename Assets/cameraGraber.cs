using UnityEngine;

public class cameraGraber : MonoBehaviour
{
    void Update()
    {
        mover.main().PlayerCamera.transform.position = transform.position;
    }
}
