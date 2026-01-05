using UnityEngine;

public class Virus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<mover>())
        {

            VarSave.SetInt("Virus",1);
            hello.windowmesenge.LoadApplication("NoVirus906Erorr");
        }
    }
}
