using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forsebody : ScriptObject
{
    public debug script;
    // Start is called before the first frame update
    void Start()
    {
        if (!gameObject.GetComponent<Rigidbody>())
        {


            gameObject.AddComponent<Rigidbody>();
        }
        if (script != null)
        {
            if (script.outs2.Count != 0)
            {


                time = float.Parse(script.outs2[0]);
            }

        }
        if (script1 != null)
        {
            if (script1.outs2.Count != 0)
            {


                time = float.Parse(script1.outs2[0]);
            }
        }
    }

        // Update is called once per frame
    void Update()
    {
        if (script != null)
        {
            if (tir >= script.outsv.Count)
            {
                tir = 0;
                tic = 0;
            }

            tic += Time.deltaTime;
            if (tic >= time)
            {
                GetComponent<Rigidbody>().velocity += new Vector3(script.outsv[tir].x, 0, script.outsv[tir].y) * 10;
                tir++;
                tic = 0;
            }
        }
        if (script1 != null)
        {
            
            if (tir >= script1.outsv.Count)
            {

                tir = 0;
                tic = 0;
            }

            tic += Time.deltaTime;
            if (tic >= time)
            {
                GetComponent<Rigidbody>().velocity += new Vector3(script1.outsv[tir].x, 0, script1.outsv[tir].y) * 10;
                tir++;
                tic = 0;
            }
        }
    }
}
