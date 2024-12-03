using UnityEngine;

public class BluvotDog : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<mover>())
        {
            Instantiate(Resources.Load<GameObject>("Блювота"));
            gameObject.AddComponent<DELETE>();
        }
    }
}
