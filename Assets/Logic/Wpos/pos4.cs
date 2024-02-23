using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pos4 : MonoBehaviour
{
    bool w;
    // Start is called before the first frame update
    void Start()
    {

        w = 0 >= mover.main().W_position;

        GetComponent<Animator>().SetBool("inits", false);


        if (w && gameObject.name == "w1")
        {
            GetComponent<Animator>().SetTrigger("exit");
        }
        if (!w && gameObject.name == "w1")
        {
            GetComponent<Animator>().SetTrigger("enter");
        }
        if (!w && gameObject.name == "w2")
        {
            GetComponent<Animator>().SetTrigger("exit");
        }
        if (w && gameObject.name == "w2")
        {
            GetComponent<Animator>().SetTrigger("enter");
        }


        GetComponent<Animator>().SetBool("transf", w);
    }
    bool side;
    // Update is called once per frame
    void Update()
    {




        if (Input.GetAxis("HyperHorizontal") != 0)
        {
            GetComponent<Animator>().SetBool("inits", false);

            w = 0 >= mover.main().W_position;
            if (w && gameObject.name == "w1" && side)
            {
                GetComponent<Animator>().SetTrigger("exit");
                side = false;
            }
            if (!w && gameObject.name == "w1" && !side)
            {
                GetComponent<Animator>().SetTrigger("enter");
                side = true;
            }
            if (!w && gameObject.name == "w2" && !side)
            {
                GetComponent<Animator>().SetTrigger("exit");
                side = true;

            }
            if (w && gameObject.name == "w2" && side)
            {
                GetComponent<Animator>().SetTrigger("enter");
                side = false;
            }

        }

    }


  
}
