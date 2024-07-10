using UnityEngine;

public class SetupEventCamera : MonoBehaviour
{
    void Update()
    {
        GetComponent<Canvas>().worldCamera = Globalprefs.camera;
    }

}
