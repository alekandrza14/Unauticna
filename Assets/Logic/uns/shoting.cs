using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoting : ScriptObject
{
    public debug script;
    public long hp = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (script != null)
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
    }

        // Update is called once per frame
    void Update()
    {
        if (script != null)
        {
            tic += Time.deltaTime;
            if (tic >= time && script.outs2.Count >= 2)
            {
                Instantiate(Resources.Load<GameObject>("bulets/" + script.outs2[1]), transform.position, Quaternion.identity);

                tic = 0;
            }
        }
    }
}
