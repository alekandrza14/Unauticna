using UnityEngine;

public class GallaxyCenterTrigger : MonoBehaviour
{
    public GameObject Pinsel;
    private void Start()
    {
        Pinsel.transform.SetParent(Camera.main.transform);
        Pinsel.transform.position = Camera.main.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        VarSave.SetInt("InCenterGallaxy",1);
        Debug.Log("player in GallaxyCenter");
    }
    private void OnTriggerExit(Collider other)
    {
        VarSave.SetInt("InCenterGallaxy", 0);
        Debug.Log("player out GallaxyCenter");
    }
}
