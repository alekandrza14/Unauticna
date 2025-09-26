using Photon.Pun;
using UnityEngine;

public class LoadItemMultp : MonoBehaviourPun
{
    [PunRPC]
    void ChangeObject(string a)
    {
        GameObject b = Instantiate(Resources.Load<GameObject>(a),transform.position,transform.rotation);
        Destroy(b);
    }
}
