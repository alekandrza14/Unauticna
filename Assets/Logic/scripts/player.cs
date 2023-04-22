using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
public class useeffect
{
    public string effect = "";
    public float time = 0;
}
public class playerdata
{
    
    static public useeffect[] effects = new useeffect[3]
    {
        new useeffect(),
        new useeffect(),
        new useeffect()
    };
    static public useeffect[] Paniceffect = new useeffect[1]
    {
        new useeffect()
    };
    static public void checkeffect()
    {
        
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            
            if (i < playerdata.effects.Length)
            {


                if (playerdata.effects[i].time <= 0)
                {
                    playerdata.effects[i].effect = "";
                }
                if (playerdata.effects[i].time >= 0)
                {
                    playerdata.effects[i].time -= Time.deltaTime;
                }

            }
        }
        if (playerdata.Paniceffect[0].time <= 0)
        {
            playerdata.Paniceffect[0].effect = "";
        }
        if (playerdata.Paniceffect[0].time >= 0)
        {
            playerdata.Paniceffect[0].time -= Time.deltaTime;
        }

    }
    static public void Loadeffect()
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            useeffect[] us1 = new useeffect[1] {
               new useeffect()
           };
            if (VarSave.EnterFloat("effect_" + i))
            {
                us1[0] = JsonUtility.FromJson<useeffect>(VarSave.GetString("effect_" + i));

            }

            playerdata.effects[i] = us1[0];
        }
        useeffect[] us = new useeffect[1] {
               new useeffect()
           };
        if (VarSave.EnterFloat("effect_" + "panic"))
        {


            us[0] = JsonUtility.FromJson<useeffect>(VarSave.GetString("effect_" + "panic"));

        }

        playerdata.Paniceffect[0] = us[0];
    }
    static public void Saveeffect()
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
           

            VarSave.SetString("effect_"+i,JsonUtility.ToJson(playerdata.effects[i]));



        }
        
        VarSave.SetString("effect_" + "panic", JsonUtility.ToJson(playerdata.Paniceffect[0]));
    }
    static public void Addeffect(string name, float time)
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            if (playerdata.effects[i].effect == "")
            {
                playerdata.effects[i].effect = name;
                playerdata.effects[i].time = time;
                i = playerdata.effects.Length;
            }
        }
    }
    static public void SetPaniceffect(string name, float time)
    {
        playerdata.Paniceffect[0].effect = name;
        playerdata.Paniceffect[0].time = time;
    }
    static public void Cleareffect()
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            playerdata.effects[i].effect = "";
            playerdata.effects[i].time = 0;
        }
    }
    static public useeffect Geteffect(string name)
    {
        useeffect ef = null;
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            if (playerdata.effects[i].effect == name)
            {
                ef = playerdata.effects[i];
            }
        }
        if (playerdata.Paniceffect[0].effect != "")
        {
            ef = playerdata.Paniceffect[0];
        }
        return ef;
    }
    public static int overload()
    {
        int defult = 1;
        if (playerdata.Geteffect("overload") != null)
        {
            defult = 2;
        }
        return defult;
    }
}
public class currentAtackk
{

}
public class musave : MonoBehaviourPunCallbacks
{
    public static string saveid;
    public static void save()
    {
        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {


            GameObject.FindObjectOfType<mover>().saveing();
        }
    }
    public static void Dest()
    {
        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {


            GameObject.FindObjectOfType<mover>().deleteing();
        }
    }
    public static void saveandhill()
    {
        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {

            GameObject.FindObjectOfType<mover>().hp = 200;
            GameObject.FindObjectOfType<mover>().saveing();
        }
      
        
    }
    public static Transform GetPlayer()
    {
        Transform t = GameObject.FindObjectOfType<GameObject>().transform;
        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {


           t = GameObject.FindObjectOfType<mover>().transform;
            
        }
      
                return t;
    }
    static public void load(Transform transform)
    {
        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {


            GameObject.FindWithTag("Player").transform.position = transform.position;
        }
      

    }
    static public void load5(Polar3 pl,float i3)
    {
        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {


            GameObject.FindObjectsOfType<mover>()[0].cd.polarTransform = pl;
            GameObject.FindObjectsOfType<mover>()[0].transform.position = new Vector3(0,i3*2,0);
        }
   

    }
    static public void GetUF()
    {
        
    }
    static public Ray pprey()
    {
        Ray r = new Ray();
        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {


            r = GameObject.FindObjectOfType<Logic_tag_3>().GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            GameObject.FindObjectOfType<Logic_tag_3>().GetComponent<Camera>().targetDisplay = 2;
        }
      
        return r;

    }
    static public void fall(GameObject other)
    {

        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {


            if (other.tag == "Player" && other.gameObject.GetComponent<mover>().tjump <= -2)
            {

                other.gameObject.GetComponent<mover>().tjump = -2;
            }
        }
      


    }
    static public void chargescene(int scene)
    {
        if (!Photon.Pun.PhotonNetwork.IsConnected)
        {

            SceneManager.LoadScene(scene);
            
        }
        if (Photon.Pun.PhotonNetwork.IsConnected)
        {
            

                
                musave.scene = scene;

            Photon.Pun.PhotonView[] players = new Photon.Pun.PhotonView[0];
            players = GameObject.FindObjectsOfType<Photon.Pun.PhotonView>();

          




            }


    }
    static public int scene = 0;
    public override void OnPlayerLeftRoom(Player other)
    {
        Debug.Log("OnPlayerLeftRoom() " + other.NickName); // seen when other disconnects
        if (PhotonNetwork.IsMasterClient)
        {
            
        }
    }

    public override void OnLeftRoom()
    {




        if (PhotonNetwork.IsMasterClient)
        {
            
        }









    }

    //Photon.Realtime.RoomOptions roomOptions = new Photon.Realtime.RoomOptions();
  //  roomOptions.MaxPlayers = 3;
     //   PhotonNetwork.JoinOrCreateRoom(musave.saveid + musave.scene, roomOptions, TypedLobby.Default);
    
    static public Transform isplayer()
    {
        Transform t = GameObject.FindObjectsOfType<GameObject>()[0].transform;
        if (GameObject.FindObjectsOfType<mover>().Length != 0)
        {


            t = GameObject.FindObjectsOfType<mover>()[Random.Range(0, GameObject.FindObjectsOfType<mover>().Length)].transform;
        }
       
            return t;

    }
    static public bool player(GameObject a)
    {
        bool t = false;
     
        if (!Photon.Pun.PhotonNetwork.IsConnected)
        {
            t = true;
        }

        return t;

    }
}
