using UnityEngine;

public class AutoFindCamera : MonoBehaviour
{

    void LateUpdate()
    {
        transform.position = Globalprefs.camera.transform.position;
        transform.rotation = Globalprefs.camera.transform.rotation;
    }
    void Update()
    {
        transform.position = Globalprefs.camera.transform.position;
        transform.rotation = Globalprefs.camera.transform.rotation;
    }
}
