using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globalprefs
{
    public static Texture txt;
    public static int idscene;
    public static Vector3 newv3;
    public static Vector3 pos;
    public static decimal flowteuvro;
    public static decimal OverFlowteuvro;
    public static decimal ItemPrise;
    public static bool bunkrot;

    public static Vector3[] postes;
    public static Vector3[] postes2;
    public static Quaternion[] q;
    public static string selectitem;
    public static itemName selectitemobj;
    public static bool isnew;
    public static string item;
    public static bool signedgamejolt;
    public static GameObject sit_player;
    public static Camera camera;
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
   
    public static int GetIdPlanet()
    {
        int seed = VarSave.GetInt("planet") + (VarSave.GetInt("planetS") * 1000) + (VarSave.GetInt("planetG") * 100000);
        
        return seed;
    }

}
