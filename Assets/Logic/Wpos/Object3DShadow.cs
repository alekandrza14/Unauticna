using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object3DShadow : MonoBehaviour
{
   public  scrollbareditWpos Wposplayer;
    public float wpos;
    public float wscale;
    public float wxscale, wyscale, wzscale;

    public AnimationCurve s;


    void Update()
    {
        float w = 0;
        w = wscale + wpos;
        w /= 2;
        float wh = 0;
        wh = wscale + wpos;
        
        
            transform.localScale = new Vector3(s.Evaluate(-Wposplayer.Wpos.value + wpos + wscale) * wxscale, s.Evaluate(-Wposplayer.Wpos.value + wpos + wscale) * wyscale, s.Evaluate(-Wposplayer.Wpos.value + wpos + wscale) * wzscale);
        
        
    }
    public void chek_w(float wposeditor)
    {

        float w = 0;
        w = wscale + wpos;
        w /= 2;
        float wh = 0;
        wh = wscale + wpos;


        transform.localScale = new Vector3(s.Evaluate(-wposeditor + wpos + wxscale) * wxscale, s.Evaluate(-wposeditor + wpos + wyscale) * wyscale, s.Evaluate(-wposeditor + wpos + wzscale) * wzscale);

    }
}
