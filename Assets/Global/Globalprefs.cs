using System;
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
    public static bool RadarOn;
    public static bool Iteract;
    public static bool RaymarchOn;
    public static bool AutoSave;
    public static GameObject socksObj;
    public static Collider[] allTransphorms;
    public static Vector3[] allpos;
    public static decimal KomplexX;
    public static float KomplexY = 1;
    public static List<string> SelfFunctions = new List<string>();
    public static decimal flowteuvro;
    public static double MultTevro =0;
    public static double Infinitysteuvro;
    public static double Reality;
    public static System.Random hashReal;

    public static void GetRealiyHash(int offset)
    {
        Reality = VarSave.GetTrash("RealityX");
        System.Random r = new System.Random(offset + (int)Reality);
        hashReal = r;
    }
    public static decimal LoadTevroPrise(decimal prise)
    {
        if (prise != 0)
        {
            if ((MultTevro * 2) > 64)
            {
                return decimal.MaxValue;

            }
            VarSave.LoadMoney("tevro", prise / (decimal)Math.Exp(MultTevro * 2));
        }
        if (MultTevro == 0) return currenttevro;
        return currenttevro * (decimal)Math.Exp(MultTevro * 2);
    }
    public static void UpadateTevro()
    {

        currenttevro = VarSave.GetMoney("tevro");
      
    }
    public static float GetRealiyChaos(float var)
    {
        if (hashReal == null)
        {
            GetRealiyHash(4);
        }
       Reality = VarSave.GetTrash("RealityX");
      System.Random r = hashReal;
        float f = r.Next(-(int)145674, (int)145674);
        f *= var;
        f /= 145674;
        if (Reality == 0) 
        { 
            f = 0;
            return f;
        }
        return f;
    }

    public static decimal knowlages;
    public static decimal currenttevro;
    public static short QuestItemKollect;
    public static decimal technologies;
    public static decimal research;
    public static decimal OverFlowteuvro;
    public static decimal ItemPrise;
    public static bool born;
    public static bool fourlapka;
    public static bool bunkrot;
    public static bool LockRotate; 
    public static bool TryBar;

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
    static public decimal GetProcentInflitiuon()
    {
        return VarSave.LoadMoney("Inflation", 0, SaveType.global)/100;
    }
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
            VarSave.GetMoney("MultyverseW") * 5) * 100) +
            (VarSave.GetInt("planetM") * 100);

        return seed;
    }
    public static decimal GetIdStar(int Planet)
    {
        decimal seed = Planet +
            (VarSave.GetInt("planetS") * 100) +
            (VarSave.GetInt("planetG") * 100) +
            (VarSave.GetInt("planetU") * 100) +
            ((VarSave.GetMoney("MultyverseX") * 2 +
            VarSave.GetMoney("MultyverseY") * 3 +
            VarSave.GetMoney("MultyverseZ") * 4 +
            VarSave.GetMoney("MultyverseW") * 5) * 100) +
            (VarSave.GetInt("planetM") * 100);

        return seed;
    }
    public static decimal GetIdStars()
    {
        decimal seed =
            (VarSave.GetInt("planetS") * 100) +
            (VarSave.GetInt("planetG") * 100) +
            (VarSave.GetInt("planetU") * 100) +
            ((VarSave.GetMoney("MultyverseX") * 2 +
            VarSave.GetMoney("MultyverseY") * 3 +
            VarSave.GetMoney("MultyverseZ") * 4 +
            VarSave.GetMoney("MultyverseW") * 5) * 100) +
            (VarSave.GetInt("planetM") * 100);

        return seed;
    }
    public static decimal GetIdGalaxy()
    {
        decimal seed =
            (VarSave.GetInt("planetG") * 100) +
            (VarSave.GetInt("planetU") * 100) +
            ((VarSave.GetMoney("MultyverseX") * 2 +
            VarSave.GetMoney("MultyverseY") * 3 +
            VarSave.GetMoney("MultyverseZ") * 4 +
            VarSave.GetMoney("MultyverseW") * 5) * 100) +
            (VarSave.GetInt("planetM") * 100);

        return seed;
    }
    public static decimal GetIdUniverse()
    {
        decimal seed =
            (VarSave.GetInt("planetU") * 100) +
            ((VarSave.GetMoney("MultyverseX") * 2 +
            VarSave.GetMoney("MultyverseY") * 3 +
            VarSave.GetMoney("MultyverseZ") * 4 +
            VarSave.GetMoney("MultyverseW") * 5) * 100) +
            (VarSave.GetInt("planetM") * 100);

        return seed;
    }
    public static decimal GetIdMultiverse()
    {
        decimal seed =
            ((VarSave.GetMoney("MultyverseX") * 2 +
            VarSave.GetMoney("MultyverseY") * 3 +
            VarSave.GetMoney("MultyverseZ") * 4 +
            VarSave.GetMoney("MultyverseW") * 5) * 100) +
            (VarSave.GetInt("planetM") * 100);

        return seed;
    }
    public static decimal GetIdAnyverse()
    {
        decimal seed = (VarSave.GetInt("planetM") * 100);

        return seed;
    }
    public static float alterversion;
    public static float reasone;
    public static void UpdatePsiho()
    {
        alterversion = VarSave.GetFloat(
         "Alterversion" + "_gameSettings", SaveType.global);
        reasone = VarSave.GetFloat("reason");
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
