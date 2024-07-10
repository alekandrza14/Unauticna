using UnityEngine;

public class Ranport : MonoBehaviour
{
    public Transform target;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<mover>())
        {
            Ranport[] jir = FindObjectsByType<Ranport>(sortmode.main);
            other.GetComponent<mover>().transform.position = jir[Random.Range(0, jir.Length)].target.position;
        }
    }
}
