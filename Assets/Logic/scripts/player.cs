using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            if (VarSave.ExistenceVar("effect_" + i))
            {
                us1[0] = JsonUtility.FromJson<useeffect>(VarSave.GetString("effect_" + i));

            }

            playerdata.effects[i] = us1[0];
        }
        useeffect[] us = new useeffect[1] {
               new useeffect()
           };
        if (VarSave.ExistenceVar("effect_" + "panic"))
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
public class GameManager : MonoBehaviour
{
    public static string saveid;
    public static void save()
    {
        if (FindObjectsByType<mover>(sortmode.main).Length != 0)
        {


            FindFirstObjectByType<mover>().saveing();
        }
    }
    public static void Dest()
    {
        if (FindObjectsByType<mover>(sortmode.main).Length != 0)
        {


            FindFirstObjectByType<mover>().deleteing();
        }
    }
    public static void saveandhill()
    {
        if (FindObjectsByType<mover>(sortmode.main).Length != 0)
        {

            FindFirstObjectByType<mover>().hp = 200;
            FindFirstObjectByType<mover>().saveing();
        }
      
        
    }
    public static Transform GetPlayer()
    {
        Transform t = FindFirstObjectByType<GameObject>().transform;
        if (GameObject.FindObjectsByType<mover>(sortmode.main).Length != 0)
        {


           t = FindFirstObjectByType<mover>().transform;
            
        }
      
                return t;
    }
    static public void load(Transform transform,HyperbolicPoint hyperbolicPoint)
    {
        if (FindObjectsByType<mover>(sortmode.main).Length != 0)
        {


            if (hyperbolicPoint == null) mover.main().transform.position = transform.position;
            else { HyperbolicCamera.Main().RealtimeTransform = hyperbolicPoint.HyperboilcPoistion.copy().inverse(); mover.main().transform.position = transform.position; }
           
        }
      

    }
    static public void load5(Hyperbolic2D pl,float i3)
    {
        if (FindObjectsByType<mover>(sortmode.main).Length != 0)
        {


            FindObjectsByType<mover>(sortmode.main)[0].hyperbolicCamera.RealtimeTransform = pl;
            FindObjectsByType<mover>(sortmode.main)[0].transform.position = new Vector3(0,i3*2,0);
        }
   

    }
    static public void GetUF()
    {
        
    }
    static public Ray pprey()
    {
        Ray r = new Ray();
        


            r = Globalprefs.camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            //FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().targetDisplay = 2;
       
      
        return r;

    }
    static public void fall(GameObject other)
    {

       


    }
    static public void chargescene(int scene)
    {
        

            SceneManager.LoadScene(scene);
            
      


    }
    static public int scene = 0;
  

  
    //Photon.Realtime.RoomOptions roomOptions = new Photon.Realtime.RoomOptions();
  //  roomOptions.MaxPlayers = 3;
     //   PhotonNetwork.JoinOrCreateRoom(musave.saveid + musave.scene, roomOptions, TypedLobby.Default);
    
    static public Transform isplayer()
    {
        Transform t = GameObject.FindObjectsOfType<GameObject>()[0].transform;
        if (FindObjectsByType<mover>(sortmode.main).Length != 0)
        {


            t = FindObjectsByType<mover>(sortmode.main)[Random.Range(0, FindObjectsByType<mover>(sortmode.main).Length)].transform;
        }
       
            return t;

    }
  
}
