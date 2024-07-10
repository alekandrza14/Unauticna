using UnityEngine;

public class TimerTeleport : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(mover.main().PlayerCamera.transform.forward * 15, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        mover.main().transform.position = transform.position+Vector3.up;
        Destroy(gameObject);
    }
}
