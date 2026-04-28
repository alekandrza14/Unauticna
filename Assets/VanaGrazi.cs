using UnityEngine;

public class VanaGrazi : MonoBehaviour
{
    public Material newMaterial;
    void OnTriggerEnter(Collider other)
    {
        foreach (Renderer child in other.GetComponentsInChildren<Renderer>())
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = newMaterial;
            }
        }
    }
    private void Update()
    {
        Ray r = new Ray(transform.position, transform.up);
        RaycastHit hit;
        if (Physics.Raycast(r,out hit))
        {
            if (hit.collider!=null)
            {
                if (hit.distance < 1) 
                {
                    foreach (Renderer child in hit.collider.GetComponentsInChildren<Renderer>())
                    {
                        Renderer renderer = child.GetComponent<Renderer>();
                        if (renderer != null)
                        {
                            renderer.material = newMaterial;
                        }
                    } 
                }
            }
        }
    }
}
