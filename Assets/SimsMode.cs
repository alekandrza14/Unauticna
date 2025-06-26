using UnityEngine;

public class SimsMode : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Destroy(gameObject);
        }
    }
}
