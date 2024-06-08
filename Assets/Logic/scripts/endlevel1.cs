using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class Getstats
{
    static public int GetPlayerLevel()
    {
        GameData g = new GameData();
        if (File.Exists("unsave/s"))
        {


            g = JsonUtility.FromJson<GameData>(File.ReadAllText("unsave/capterg/" + File.ReadAllText("unsave/s")));
            

        }
        return g.progressofthepassage;
    }
}

public class endlevel1 : MonoBehaviour
{
    public void Awake()
    {
        GameData g = new GameData();
        if (File.Exists("unsave/s"))
        {


            g = JsonUtility.FromJson<GameData>(File.ReadAllText("unsave/capterg/" + File.ReadAllText("unsave/s")));
            if (g.progressofthepassage >= 1)
            {
                Destroy(gameObject);
            }

        }
        if (!VarSave.ExistenceVar("dies-zellotton"))
        {
            Destroy(gameObject);
        }
    }
}
