using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object2DShadow : MonoBehaviour
{
    public scrollbareditWpos Wposplayer;
    public float wpos;
    public float wscale;
    public AnimationCurve s;
    void Start()
    {
        
    }
    private void Awake()
    {
        
    }

    void Update()
    {
        float w = 0;
        w = wscale + wpos;
        w /= 2;
        float wh = 0;
        wh = wscale + wpos;
        
        
            transform.localScale = new Vector3(s.Evaluate(-Wposplayer.Wpos.value + wpos + wscale), s.Evaluate(-Wposplayer.Wpos.value + wpos + wscale), s.Evaluate(-Wposplayer.Wpos.value + wpos + wscale));
        
        
    }
    public void chek_w(float wposeditor)
    {

        float w = 0;
        w = wscale + wpos;
        w /= 2;
        float wh = 0;
        wh = wscale + wpos;


        transform.localScale = new Vector3(s.Evaluate(-wposeditor + wpos + wscale), s.Evaluate(-wposeditor + wpos + wscale), s.Evaluate(-wposeditor + wpos + wscale));

    }
}
