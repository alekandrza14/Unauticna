using UnityEngine;

public class RuleG170I360 : MonoBehaviour
{
    public GameObject camera;
    void Update()
    {
        if (Globalprefs.camera.fieldOfView>170)
        {
            camera.SetActive(true);
        }
        else
        {
            camera.SetActive(false);
        }
    }
}
