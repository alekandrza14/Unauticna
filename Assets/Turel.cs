using UnityEngine;

public class Turel : MonoBehaviour
{
    void FixedUpdate()
    {
        float input = Input.GetAxis("Horizontal");
        transform.Rotate(0, input*5*Time.fixedTime, 0);
    }
}
