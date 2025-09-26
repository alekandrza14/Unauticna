using UnityEngine;

public class литунка : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    private void Update()
    {
        rb.AddForce(transform.forward*5,ForceMode.VelocityChange);
    }
    public void CooldownRotate()
    {
        transform.rotation = Random.rotation;
    }
}
