using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoting : MonoBehaviour
{
    public debug script;
   float tic;  float time = 1;
    public long hp = 1;
    // Start is called before the first frame update
    void Start()
    {
        
        if (script.outs2.Count != 0)
        {


            time = float.Parse(script.outs2[0]);
        }
        if (script.outs2.Count >= 3)
        {


            hp = long.Parse(script.outs2[2]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        tic += Time.deltaTime;
        if (tic >= time && script.outs2.Count >= 2)
        {
            Instantiate(Resources.Load<GameObject>("bulets/" + script.outs2[1]),transform.position,Quaternion.identity);
            
            tic = 0;
        }
    }
}
