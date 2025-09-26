using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class MultyPlayerMenu : MonoBehaviourPunCallbacks
{
    private void Start()
    {
    }
    public void CreateRoomOrJoin()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.JoinOrCreateRoom("Sovet", roomOptions, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("JoinedRoom");
        PhotonNetwork.LoadLevel("test3");
    }
}
