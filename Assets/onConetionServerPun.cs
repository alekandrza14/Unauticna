using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class onConetionServerPun : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("LobyLab");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("ЌеучишникиЋогин–ег");
    }
}
