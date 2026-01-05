using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class spawnНеучей : MonoBehaviourPunCallbacks
{
    public GameObject _player;
    public GameObject _player2;
    public Transform canvas;
    public static Transform main_canvas_canvas;
    void Start()
    {
        main_canvas_canvas = canvas;
        GameObject sou2 = PhotonNetwork.Instantiate(_player2.name, new Vector3(700, 600, 0), Quaternion.identity);
        GameObject sou = PhotonNetwork.Instantiate(_player.name, new Vector3(Random.Range(-280, 280) + 400, Random.Range(-280, 280) + 300, 0), Quaternion.identity);
        
    }
}


