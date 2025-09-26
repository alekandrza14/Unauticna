using UnityEngine;

public class Арбуз : MonoBehaviour
{
    public GameObject blood;
    public GameObject bone;
    void Update()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(r , out hit))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider != null)
                {
                    Instantiate(blood,transform.position,Quaternion.identity);
                    if (Random.Range(0,5)<1)
                    {
                        Instantiate(bone, transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
