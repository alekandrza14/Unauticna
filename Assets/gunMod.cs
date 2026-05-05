using UnityEngine;

public class gunMod : MonoBehaviour
{
    public Transform point;
    public void OnInteractive()
    {
        Ray ray = new Ray(point.position, point.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            if (hit.collider!=null)
            {
                Instantiate(Resources.Load<GameObject>("DamageObject"), hit.point,Quaternion.identity);
            }
        }
    }
}