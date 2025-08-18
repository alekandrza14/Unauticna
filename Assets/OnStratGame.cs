using UnityEngine;
using UnityEngine.SceneManagement;

public class OnStratGame : MonoBehaviour
{
    static bool gamenonstarted;
    void Start()
    {
        if (!gamenonstarted)
        {
            SceneManager.LoadScene("PresetDif");
            gamenonstarted = true;
        }
    }
}
