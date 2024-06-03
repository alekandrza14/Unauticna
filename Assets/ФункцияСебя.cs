using UnityEngine;

public class ФункцияСебя : MonoBehaviour
{
    bool a;
    void recurse()
    {
        while (true)
        {
            a = !a;
        }
        recurse();
    }
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider.gameObject == gameObject)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                recurse();
            }
        }
    }
}
