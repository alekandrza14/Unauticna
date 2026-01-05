using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class RPCChat : MonoBehaviourPunCallbacks
{
    public InputField txt;
    public InputField chat;
    public PhotonView player;
    private void Start()
    {
        RPCChat[] rPCChats = FindObjectsByType<RPCChat>(sortmode.main);
        foreach (RPCChat c in rPCChats)
        {
            c.player.RPC("Chat", RpcTarget.All, VarSave.GetString(PhotonNetwork.CurrentRoom.Name + "Text"));
        }
        if (!player.IsMine)
        {
           
            transform.localScale = Vector3.zero;
        }

        VarSave.GetString(PhotonNetwork.CurrentRoom.Name + "Text");
    }
    private void Update()
    {
        if (!player.IsMine)
        {

            transform.localScale = Vector3.zero;
        }
    }
    public void send()
    {
        RPCChat[] rPCChats = FindObjectsByType<RPCChat>(sortmode.main);

        foreach (RPCChat c in rPCChats)
        {
            c.player.RPC("Chat", RpcTarget.All, player.Owner.NickName + " имя : " + VarSave.GetFloat("руб",SaveType.computer) + " руб. : " + VarSave.GetMoney("tevro") + " тевр. : " + chat.text);
        }

    }
    [PunRPC]
    private void Chat(string msg)
    {
        txt.text += msg+'\n'+'\n';
        VarSave.SetString(PhotonNetwork.CurrentRoom.Name+"Text", txt.text);
    }
}
