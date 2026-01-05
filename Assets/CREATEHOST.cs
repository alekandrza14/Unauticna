using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CREATEHOST : MonoBehaviourPunCallbacks
{
    public InputField nik;
    public InputField server;
    private void Start()
    {
        nik.text = VarSave.GetString("akaunt");
    }
    public void CreateRoomOrJoin()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 100000;
        PhotonNetwork.NickName = nik.text;
        VarSave.SetString("akaunt", nik.text);
        PhotonNetwork.JoinOrCreateRoom(server.text, roomOptions, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("JoinedRoom");
        PhotonNetwork.LoadLevel("НеучишникиЧаты");
    }
}
