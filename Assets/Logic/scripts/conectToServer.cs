using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System.IO;

public class conectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public void Playtest()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    private void Start()
    {
        if (isloader)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }
    // Update is called once per frame
    public bool isloader;
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.SendRate = 20; 
        PhotonNetwork.SerializationRate = 10;
        CrateRoom();
    }
    public InputField createroom;
    public InputField joinroom;
    public gsave gsave = new gsave();
    public void CrateRoom()
    {
        if (!isloader)
        {


            if (File.Exists("munsave/capterg/" + createroom.text))
            {
                gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("munsave/capterg/" + createroom.text));





                RoomOptions roomOptions = new RoomOptions();
                roomOptions.MaxPlayers = 3;
                musave.saveid = createroom.text;

                PhotonNetwork.JoinOrCreateRoom(gsave.sceneid + createroom.text, roomOptions, TypedLobby.Default);





            }
            if (!File.Exists("munsave/capterg/" + createroom.text))
            {







                RoomOptions roomOptions = new RoomOptions();
                roomOptions.MaxPlayers = 3;
                musave.saveid = createroom.text;

                PhotonNetwork.JoinOrCreateRoom("1"+musave.saveid, roomOptions, TypedLobby.Default);





            }
        }
        if (isloader)
        {


                





                RoomOptions roomOptions = new RoomOptions();
                roomOptions.MaxPlayers = 3;
            File.WriteAllText("munsave/s", musave.saveid); 
            File.WriteAllText("unsave/s", musave.saveid);

            PhotonNetwork.JoinOrCreateRoom(musave.scene + musave.saveid, roomOptions, TypedLobby.Default);





            
            
        }

    }



    public override void OnJoinedRoom()
    {
        if (!isloader)
        {
            File.WriteAllText("munsave/s", musave.saveid);
            File.WriteAllText("unsave/s", musave.saveid);

            Screen.SetResolution(Screen.width, Screen.height, false);

            if (!File.Exists("munsave/capterg/" + createroom.text))
            {
                string s = "";
                s = createroom.text;
                File.WriteAllText("munsave/s", s);
                PhotonNetwork.LoadLevel(1);

            }
            if (File.Exists("munsave/capterg/" + createroom.text))
            {
                gsave = JsonUtility.FromJson<gsave>(File.ReadAllText("munsave/capterg/" + createroom.text));
                string s = "";
                s = createroom.text;
                File.WriteAllText("munsave/s", s);
                PhotonNetwork.LoadLevel(gsave.sceneid);
            }
        }
        if (isloader)
        {


            

            
            
                
                string s = "";
                s = musave.saveid;
                File.WriteAllText("munsave/s", s);
                PhotonNetwork.LoadLevel(musave.scene);
            
        }
    }

}
