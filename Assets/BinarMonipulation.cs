using UnityEngine;

public class BinarMonipulation : MonoBehaviour
{
    public void Move()
    {
        transform.rotation = mover.main().PlayerCamera.transform.rotation;
        transform.Translate(0, 0, 1f*BinarMagic.speed);
    }
}
