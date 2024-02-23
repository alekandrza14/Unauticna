using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object3Dtrans : MonoBehaviour
{
   public  scrollbareditWpos Wposplayer;
    public float wpos;
    public float wscale;

    Vector3 oldpos;
    public AnimationCurve s;
    public AnimationCurve sx; 
    public AnimationCurve sy;
    public AnimationCurve sz;

    private void Awake()
    {
        oldpos = transform.position;
    }

    void Update()
    {
        float w = 0;
        w = wscale + wpos;
        w /= 2;
        float wh = 0;
        wh = wscale + wpos;
        
        
            transform.position = new Vector3(sx.Evaluate(-Wposplayer.Wpos.value + wpos + wscale),
                sy.Evaluate(-Wposplayer.Wpos.value + wpos + wscale) ,
                sz.Evaluate(-Wposplayer.Wpos.value + wpos + wscale)) + oldpos;
        
        
    }
    public void chek_w(float wposeditor)
    {

        float w = 0;
        w = wscale + wpos;
        w /= 2;
        float wh = 0;
        wh = wscale + wpos;


        transform.position = new Vector3(sx.Evaluate(-wposeditor + wpos + wscale), sy.Evaluate(-wposeditor + wpos + wscale), sz.Evaluate(-wposeditor + wpos + wscale));

    }
}
