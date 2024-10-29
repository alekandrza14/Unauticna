using UnityEngine;

public class CrashTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<mover>())
        {
            Application.Quit();
        }
    }
}
