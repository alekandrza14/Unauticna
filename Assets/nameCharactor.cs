using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class nameCharactor : MonoBehaviourPunCallbacks
{
    public Text txt;
    public PhotonView player;
    void Start()
    {
        
            txt.text = player.Owner.NickName;
            
       
    }
}
