using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class pv : MonoBehaviourPunCallbacks
{
    [PunRPC]
    private void setPVector(float v1, float v2, float v3, float v4)
    {
        

            GetComponent<Camdpoint>().p2 = new Polar3(v1, v2, v3);
            GetComponent<Camdpoint>().v1 = v4;
        

    }
    [PunRPC]
    private void setColor(float v1, float v2, float v3)
    {
       

            GetComponent<player>().d = new Color(v1, v2, v3);
        

    }
}
