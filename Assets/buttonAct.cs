using UnityEngine;

public class buttonAct : MonoBehaviour
{
    public GameObject INTERFACE;
    public void moverfuntionrun(string namefuntion)
    {
        mover.main().Invoke(namefuntion,0);
        Destroy(INTERFACE);
    }
}
