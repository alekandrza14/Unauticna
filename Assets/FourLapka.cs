using UnityEngine;

public class FourLapka : MonoBehaviour
{
    
    void Start()
    {
       if(!Globalprefs.fourlapka) gameObject.SetActive(false);
    }

    
}
