using UnityEngine;

public class PlayerController33 :
    MonoBehaviour
{
    public WindowsReceiver input;

    public float speed = 5f;

    void Update()
    {
        Vector3 move =
            new Vector3(
                input.stickX,
                0,
                input.stickY);

        transform.Translate(
            move *
            speed *
            Time.deltaTime);

        if (input.A)
            Debug.Log("A");

        if (input.B)
            Debug.Log("B");

        if (input.X)
            Debug.Log("X");

        if (input.Y)
            Debug.Log("Y");
    }
}