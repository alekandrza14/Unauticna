using UnityEngine;

public class NegaLightControler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<mover>())
        {
            NegativeLight[] nl = objFind.ArrayByType<NegativeLight>();
            foreach (NegativeLight item in nl)
            {
                item.enabled = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<mover>())
        {
            NegativeLight[] nl = objFind.ArrayByType<NegativeLight>();
            foreach (NegativeLight item in nl)
            {
                item.enabled = true;
            }
        }
    }
}
