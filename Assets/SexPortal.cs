using UnityEngine;
using UnityEngine.SceneManagement;

public class SexPortal : MonoBehaviour
{
    public int SexNumber;
    void Update()
    {
        RaycastHit hit = MainRay.MainHit;
        if (hit.collider != null &&Input.GetKey(KeyCode.E))
        {
            if (hit.collider.gameObject == gameObject)
            {
                SceneManager.LoadScene("KisyMiniGame" + SexNumber);
            }
        }
    }
}
