using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickMoveToAnyverse : MonoBehaviour
{
    private void OnMouseEnter()
    {
        SceneManager.LoadScene("Anyverse");
    }
}
