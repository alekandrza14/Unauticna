using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Globalprefs
{
    public static Texture txt;
    public static int idscene;
    public static int Chanse_fire;
    public static string PlayerPositionInfo;
    public static string AnyversePlayerPositionInfo;
    public static Vector3 newv3;
    public static Vector3 pos;
    public static Vector3 WMovepos;
    public static bool RaymarchHitError;
    public static bool Scrensoting;
    public static decimal flowteuvro;
    public static decimal knowlages;
    public static decimal technologies;
    public static decimal research;
    public static decimal OverFlowteuvro;
    public static decimal ItemPrise;
    public static bool bunkrot;

    public static Vector3[] postes;
    public static Vector3[] postes2;
    public static Quaternion[] q;
    public static string selectitem;
    public static string selectcharacter;
    public static itemName selectitemobj;
    public static bool isnew;
    public static string item;
    public static bool signedgamejolt;
    public static GameObject sit_player;
    public static Camera camera;
    public static bool Pause;
    static public float Hash(Vector2 p)
    {
        float d = Vector2.Dot(-p, new Vector2(12.9898f, 78.233f));
        return Frac(Mathf.Sin(d) * 43758.5453123f);
    }
    static public decimal Fract(decimal value) { return value - decimal.Truncate(value); }

    static public float Frac(float value)
    {
        return (float)Fract((decimal)value);
    }

    public static decimal GetIdPlanet()
    {
        decimal seed = VarSave.GetInt("planet") +
            (VarSave.GetInt("planetS") * 100) +
            (VarSave.GetInt("planetG") * 100) +
            (VarSave.GetInt("planetU") * 100) +
            ((VarSave.GetMoney("MultyverseX") * 2 +
            VarSave.GetMoney("MultyverseY") * 3 +
            VarSave.GetMoney("MultyverseZ") * 4 +
            VarSave.GetMoney("MultyverseW") * 5) * 100);

        return seed;
    }
    public static decimal GetIdStar(int Planet)
    {
        decimal seed = Planet +
            (VarSave.GetInt("planetS") * 100) +
            (VarSave.GetInt("planetG") * 100) +
            (VarSave.GetInt("planetU") * 100) +
            ((VarSave.GetMoney("MultyverseX")*2 +
            VarSave.GetMoney("MultyverseY") * 3 +
            VarSave.GetMoney("MultyverseZ") * 4 +
            VarSave.GetMoney("MultyverseW") * 5) * 100);

        return seed;
    }

    public static string GetTimeline()
    {
        string timeline = "1";
        if (File.Exists("unsave/s"))
        {
          timeline = File.ReadAllText("unsave/s");
        }
        return timeline;

    }
}
