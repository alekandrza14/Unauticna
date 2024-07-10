using UnityEngine;
using UnityEngine.SceneManagement;

public class TpLoka : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hit.collider.gameObject == gameObject)
            {
                SceneManager.LoadScene(220);

            }
        }
    }
}
