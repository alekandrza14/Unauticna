using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml.Linq;

public class PlayerDNA
{
    public Color colour;
    public float metabolism = 1;
    public float hp = 0;
    public float Jumping = 0;
    public float regeneration = 0;
    public List<useeffect> bakeeffects;
    public List<int> talant = new List<int>(2);
}
[System.Serializable]
public class useeffect
{
    public string effect = "";
    public float time = 0;
    public useeffect(string name, float secoundstime)
    {
        this.effect = name;
        this.time = secoundstime;
    }
    public useeffect()
    {
    }
}
public class playerdata
{
    
    static public useeffect[] effects = new useeffect[]
    {
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
        new useeffect(),
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
    static public int counteffect()
    {
        int count =0;
        for (int i = 0; i < playerdata.effects.Length; i++)
        {

            if (i < playerdata.effects.Length)
            {


               
                if (playerdata.effects[i].time >= 0)
                {
                    count += 1;
                }

            }
        }
       
        if (playerdata.Paniceffect[0].time >= 0)
        {
            count += 1;
        }
        return count;
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
    static public void LoadBakeeffect()
    {
        PlayerDNA dna = mover.main().DNA;
        if (dna != null) if (dna.bakeeffects != null) for (int i = 0; i < dna.bakeeffects.Count; i++)
        {
            if (playerdata.Geteffect(dna.bakeeffects[i].effect)==null)
            {
                Addeffect(dna.bakeeffects[i].effect, float.PositiveInfinity);
            }
        }
       
    }
    static public void Saveeffect()
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {


            VarSave.SetString("effect_" + i, JsonUtility.ToJson(playerdata.effects[i]));



        }

        VarSave.SetString("effect_" + "panic", JsonUtility.ToJson(playerdata.Paniceffect[0]));
    }
    static public void FreezeAlleffect()
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {


            playerdata.effects[i].time = float.PositiveInfinity;



        }

    }
    static public void BakeAlleffect()
    {
        PlayerDNA dna = new PlayerDNA();
       if (mover.main()) dna = mover.main().DNA; else
        {
            dna.bakeeffects = new();
        }
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            if (playerdata.effects[i].effect != "")
            {
                foreach (useeffect dnaitem in dna.bakeeffects)
                {
                    if (Geteffect(dnaitem.effect)==null)
                    {



                        playerdata.effects[i].time = float.PositiveInfinity;


                        mover.main().DNA.bakeeffects.Add(playerdata.effects[i]);
                    }
                }
            }


        }

        if (mover.main()) VarSave.SetString("DNA", JsonUtility.ToJson(mover.main().DNA));
        if (mover.main()) VarSave.SetString("DNA", JsonUtility.ToJson(dna));
    }
    static public void Addeffect(string name, float secoundstime)
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            if (playerdata.effects[i].effect == "")
            {
                playerdata.effects[i].effect = name;
                playerdata.effects[i].time = secoundstime;
                i = playerdata.effects.Length;
            }
            else if (playerdata.effects[i].time<0)
            {
                playerdata.effects[i].effect = name;
                playerdata.effects[i].time = secoundstime;
                i = playerdata.effects.Length;
            }
        }
    }
    static public void SetPaniceffect(string name, float secoundstime)
    {
        playerdata.Paniceffect[0].effect = name;
        playerdata.Paniceffect[0].time = secoundstime;
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
                return ef;
            }
        }
        if (playerdata.Paniceffect[0].effect == name)
        {
            ef = playerdata.Paniceffect[0]; return ef;
        }
        return ef;
    }
    static public useeffect Geteffect(string name,List<useeffect> effects)
    {
        useeffect ef = null;
      if(effects!=null)  for (int i = 0; i < effects.Count; i++)
        {
            if (effects[i].effect == name)
            {
                ef = effects[i];
                return ef;
            }
        }
        
        return ef;
    }
    static public void Upeffect(string name, float secoundstime)
    {
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            if (playerdata.effects[i].effect == name)
            {
                playerdata.effects[i].time += secoundstime;
            }
        }
        if (playerdata.Paniceffect[0].effect == name)
        {
            playerdata.Paniceffect[0].time += secoundstime;
        }
    }
    static public useeffect hasClearEffect(string name)
    {
        useeffect ef = null;
        for (int i = 0; i < playerdata.effects.Length; i++)
        {
            if (playerdata.effects[i].effect == name)
            {
                ef = playerdata.effects[i];

                playerdata.effects[i].effect = "";
                playerdata.effects[i].time = 0;
            }
        }
        if (playerdata.Paniceffect[0].effect == name)
        {
            ef = playerdata.Paniceffect[0];

            playerdata.Paniceffect[0].effect = "";
            playerdata.Paniceffect[0].time = 0;
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



        mover.main().saveing();

    }
    public static void Dest()
    {


        mover.main().deleteing();
       
    }
    public static void saveandhill()
    {
        
            mover.main().hp = 200;
            mover.main().saveing();
       


    }
    public static void saveandDamage()
    {


        mover.main().saveing();

        mover.main().hp -= 100;
       


    }
    public static Transform GetPlayer()
    {
        Transform t = mover.main().transform;
        

        return t;
    }
    static public void load(Transform transform, HyperbolicPoint hyperbolicPoint)
    {
       


            if (hyperbolicPoint == null) mover.main().transform.position = transform.position;
            else { HyperbolicCamera.Main().RealtimeTransform = hyperbolicPoint.HyperboilcPoistion.copy().inverse(); mover.main().transform.position = transform.position; }



    }
    static public void loadoutReincarnation()
    {
       
            GameData sr = JsonUtility.FromJson<GameData>(File.ReadAllText("unsave/capterg/" + Globalprefs.GetTimeline()));
            SceneManager.LoadSceneAsync(sr.sceneid);

      


    }
    static public void load5(Hyperbolic2D pl,float i3)
    {



        mover.main().hyperbolicCamera.RealtimeTransform = pl;
        mover.main().transform.position = new Vector3(0,i3*2,0);
       
   

    }
    static public void GetUF()
    {
        
    }
    static public Ray pprey()
    {
        Ray r = new Ray();


        Globalprefs.camera = Logic_tag_3.main().GetComponent<Camera>();

            r = Globalprefs.camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            //FindFirstObjectByType<Logic_tag_3>().GetComponent<Camera>().targetDisplay = 2;
       
      
        return r;

    }
    static public void fall(GameObject other)
    {

       if(other!=null) mover.main().transform.position = new Vector3(mover.main().transform.position.x,other.transform.position.y, mover.main().transform.position.z);


    }
    static public void chargescene(int scene)
    {
        

            SceneManager.LoadSceneAsync(scene);
            
      


    }
    static public int scene = 0;
  

  
    //Photon.Realtime.RoomOptions roomOptions = new Photon.Realtime.RoomOptions();
  //  roomOptions.MaxPlayers = 3;
     //   PhotonNetwork.JoinOrCreateRoom(musave.saveid + musave.scene, roomOptions, TypedLobby.Default);
    
    static public Transform isplayer()
    {
        Transform t = mover.main().transform;
        


        
       
            return t;

    }
  
}
