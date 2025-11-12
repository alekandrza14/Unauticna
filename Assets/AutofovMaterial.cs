using UnityEngine;

public class AutofovMaterial : MonoBehaviour
{
    
    void Update()
    {
        GetComponent<MeshRenderer>().material.SetFloat("_FoV",Camera.main.fieldOfView-0.001f);
    }
}
