using UnityEngine;

public class MoverBlyuvota : MonoBehaviour
{
    void Update()
    {
        mover.main().transform.position -= mover.main().transform.forward*Time.deltaTime*5;
    }
}
