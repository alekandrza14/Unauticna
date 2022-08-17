using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forsebody : MonoBehaviour
{
    public debug script;
    float tic; int tir; float time = 1;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<Rigidbody>();
        if (script.outs2.Count != 0)
        {


            time = float.Parse(script.outs2[0]);
        }
    }

        // Update is called once per frame
        void Update()
    {
        if (tir >= script.outsv.Count)
        {
            tir=0;
            tic = 0;
        }
        
        tic += Time.deltaTime;
        if (tic >= time)
        {
            GetComponent<Rigidbody>().velocity += new Vector3(script.outsv[tir].x, 0, script.outsv[tir].y)*10;
            tir++;
            tic = 0;
        }
    }
}
