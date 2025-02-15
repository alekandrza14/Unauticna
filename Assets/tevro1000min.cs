using UnityEngine;

public class tevro1000min : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("k1", 60, 60);
    }
    void k1()
    {
        Globalprefs.LoadTevroPrise(1000);
    }
}
