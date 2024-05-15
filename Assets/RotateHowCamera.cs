using UnityEngine;

public class RotateHowCamera : MonoBehaviour
{
    
    void Update()
    {
        transform.rotation = mover.main().transform.rotation;
    }
}
