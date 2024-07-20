using UnityEngine;
using UnityEngine.SceneManagement;

public class Godline : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<itemName>())
        {
            if (other.GetComponent<itemName>()._Name == "sunkey")
            {
                SceneManager.LoadScene("Nervana");
            }
        }
    }
}
