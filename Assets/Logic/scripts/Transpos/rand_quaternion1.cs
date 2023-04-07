using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rand_quaternion : MonoBehaviour
{
    // Start is called before the first frame update
    	public decimal Fract(decimal value) { return value - decimal.Truncate(value); }

    public float Frac(float value)
    {
        return (float)Fract((decimal)value);
    }
    float Hash(Vector2 p)
    {
        float d = Vector2.Dot(-p, new Vector2(12.9898f, 78.233f));
        return Frac(Mathf.Sin(d) * 43758.5453123f);
    }
    void Start()
    {
        float s = Hash(new Vector2(
                           VarSave.GetInt("planet"), -VarSave.GetInt("planet") * -1));
        float s2 = Hash(new Vector2(
                           VarSave.GetInt("planet"), -VarSave.GetInt("planet") * -2));
        float s3 = Hash(new Vector2(
                           VarSave.GetInt("planet"), -VarSave.GetInt("planet") * -3)) ;
        float s4 = Hash(new Vector2(
                           VarSave.GetInt("planet"), -VarSave.GetInt("planet") * -4)) ;
        transform.rotation = new Quaternion(s,s2,s3,s4);
    }

    
}
