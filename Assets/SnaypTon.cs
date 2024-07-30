using UnityEngine;

public class SnaypTon : MonoBehaviour
{
    private void Start()
    {
        Instantiate(Resources.Load("DeadMetka"));
    }
    void Update()
    {
        if (!lml1.Find())
        {
            Instantiate(Resources.Load("SEffect/Snayp"));
            Destroy(gameObject);
        }
        transform.rotation = Quaternion.LookRotation(mover.main().transform.position - transform.position, Vector3.up);
        Ray r = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(r,out RaycastHit hit))
        {
            if (hit.collider !=null)
            {
                if (hit.collider.GetComponent<DeadMetka>())
                {
                    Instantiate(Resources.Load("SEffect/Snayp"));
                }
            }
        }
    }
}
