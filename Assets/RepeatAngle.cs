using UnityEngine;

public class RepeatAngle : MonoBehaviour
{
    void Update()
    {
        GetComponent<Camera>().fieldOfView = Globalprefs.camera.fieldOfView;
        GetComponent<Camera>().fieldOfView += 1;
    }
}
