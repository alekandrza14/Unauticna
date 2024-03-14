using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flybody : ScriptObject
{
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position -= new Vector3(script1.outsv3[0].x, script1.outsv3[0].y, script1.outsv3[0].z)*7.5f;
        if (!gameObject.GetComponent<Rigidbody>())
        {


            gameObject.AddComponent<Rigidbody>().useGravity = false;
        }
        if (script1.outs2.Count != 0)
        {


            time = float.Parse(script1.outs2[0]);
        }
    }

        // Update is called once per frame
        void Update()
    {
        if (tir >= script1.outsv3.Count)
        {
            tir=0;
            tic = 0;
        }
        
        tic += Time.deltaTime;
        if (tic >= time)
        {
            

            GetComponent<Rigidbody>().velocity = new Vector3(script1.outsv3[tir].x, script1.outsv3[tir].y, script1.outsv3[tir].z)*10;
            tir++;
            tic = 0;
        }
    }
}
