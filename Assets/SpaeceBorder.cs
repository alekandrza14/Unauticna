using UnityEngine;

public class SpaeceBorder : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<mover>())
        {
            RayCastStars.nravixOverbunds = true;
            SceneLoad.loadbar("Galactic loader");
        }
    }
}
