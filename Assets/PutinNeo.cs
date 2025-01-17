using UnityEngine;

public class PutinNeo : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("NaebaKreditOtPutina",5,5);
    }
    void NaebaKreditOtPutina()
    {
        Instantiate(Resources.Load<GameObject>("voices/СпижюДенег"));
        Globalprefs.LoadTevroPrise(-1000000);
    }
}
