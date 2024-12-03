using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<mover>())
        {
            animator.SetTrigger("опен");
        }
    }
}
