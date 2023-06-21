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
        GetComponent<Animator>().SetBool("inits", true);

        w = VarSave.GetBool(SceneManager.GetActiveScene().name);


        GetComponent<Animator>().SetBool("transf", w);
    }

    // Update is called once per frame
    void Update()
    {




        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Animator>().SetBool("inits", false);
            w = !w;
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

        }
        if (Input.GetKeyDown(KeyCode.F1))
        {


            if (gameObject.name == "w2")
            {

                VarSave.SetBool(SceneManager.GetActiveScene().name, w,SaveType.world);
            }

        }
        if (Input.GetKeyDown(KeyCode.F2))
        {


            GetComponent<Animator>().SetBool("inits", true);

            w = VarSave.GetBool(SceneManager.GetActiveScene().name, SaveType.world);


            GetComponent<Animator>().SetBool("transf", w);

        }

    }
    public void save()
    {
        if (gameObject.name == "w2")
            {

                VarSave.SetBool(SceneManager.GetActiveScene().name, w, SaveType.world);
            }
    }
}
